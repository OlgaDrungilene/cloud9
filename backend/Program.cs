using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using backend.Data;
using backend.Models;

Environment.SetEnvironmentVariable("DOTNET_USE_POLLING_FILE_WATCHER", "1");


var builder = WebApplication.CreateBuilder(args);

//DbContext
var connectionString =
    builder.Configuration.GetConnectionString("DefaultConnection")
    ?? Environment.GetEnvironmentVariable("ConnectionStrings__DefaultConnection");

builder.Services.AddDbContext<Cloud9Context>(options =>
    options.UseNpgsql(connectionString, o =>
    {
        o.EnableRetryOnFailure();
    }));

builder.Services.AddCors(options =>
{
    options.AddPolicy("ReactPolicy", policy =>
    {
        policy.WithOrigins(
            "http://localhost:3000",
            "https://cloud9-restaurant.netlify.app"
        )
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseStaticFiles();

app.UseCors("ReactPolicy");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/", () => "Hello World!");

// app.MapGet("/menu", async (Cloud9Context db) =>
// {
//     var items = await db.MenuItems
//         .Include(m => m.Category)
//         .ToListAsync();

//     return Results.Ok(items);
// });

// app.MapGet("/menu/{id}", async (Cloud9Context db, int id) =>
// {
//     var item = await db.MenuItems
//         .Include(m => m.Category)
//         .FirstOrDefaultAsync(m => m.Id == id);

//     return item is null ? Results.NotFound() : Results.Ok(item);
// });

// app.MapGet("/menu/specials", async (Cloud9Context db) =>
// {
//     var specials = await db.MenuItems
//         .Where(m => m.IsSpecial)
//         .ToListAsync();

//     return Results.Ok(specials);
// });

app.MapGet("/tables", async (Cloud9Context db) =>
{
    var tables = await db.Tables.ToListAsync();

    return Results.Ok(tables);
});

app.MapGet("/tables/{id}", async (Cloud9Context db, int id) =>
{
    var table = await db.Tables.FindAsync(id);

    return table is null ? Results.NotFound() : Results.Ok(table);
});

app.MapGet("/tables/available", async (Cloud9Context db) =>
{
    var availableTables = await db.Tables
        .Where(t => t.IsAvailable== true)
        .ToListAsync();

    return Results.Ok(availableTables);
});

app.MapPost("/bookings", async (Cloud9Context db, Booking booking) =>
{
    try
    {
        booking.BookingTime = DateTime
            .SpecifyKind(booking.BookingTime, DateTimeKind.Local)
            .ToUniversalTime();

        if (string.IsNullOrWhiteSpace(booking.FullName))
            return Results.BadRequest("Customer name is required.");

        if (booking.BookingTime < DateTime.UtcNow)
            return Results.BadRequest("Booking time must be in the future.");

        booking.TableId = null;

        db.Bookings.Add(booking);
        await db.SaveChangesAsync();

        return Results.Created($"/bookings/{booking.Id}", booking);
    }
    catch (Exception ex)
    {
        Console.WriteLine("BOOKING ERROR: " + ex.ToString());
        return Results.Problem(ex.Message);
    }
});

app.MapGet("/bookings", async (Cloud9Context db) =>
{
    var bookings = await db.Bookings
    .Include(b => b.Table)
    .Select(b => new {
            b.Id,
            b.FullName,
            b.Email,
            b.Phone,
            b.BookingTime,
            b.Persons,
            b.Notes,
            Table = b.Table == null ? null : new {
                b.Table.Id,
                b.Table.Capacity,
                b.Table.IsAvailable,
                b.Table.isActive
            }
        })
    .ToListAsync();

    return Results.Ok(bookings);
});
app.MapGet("/admin/bookings", async (Cloud9Context db) =>
{
    var bookings = await db.Bookings
        .Include(b => b.Table)
        .OrderBy(b => b.BookingTime)
        .Select(b => new {
            b.Id,
            b.FullName,
            b.Email,
            b.Phone,
            b.BookingTime,
            b.Persons,
            b.Notes,
            Table = b.Table == null ? null : new {
                b.Table.Id,
                b.Table.Capacity,
                b.Table.IsAvailable
            }
        })
        .ToListAsync();

    return Results.Ok(bookings);
});

app.MapPatch("/admin/bookings/{id}/assign-table", 
async (Cloud9Context db, int id, int tableId) =>
{
    var booking = await db.Bookings.FindAsync(id);
    if (booking is null)
        return Results.NotFound($"Booking {id} not found.");

    var table = await db.Tables.FindAsync(tableId);
    if (table is null)
        return Results.NotFound($"Table {tableId} not found.");

     var windowStart = booking.BookingTime.AddHours(-3);
    var windowEnd = booking.BookingTime.AddHours(3);

    var conflictingBooking = await db.Bookings.AnyAsync(b =>
        b.TableId == tableId &&
        b.Id != booking.Id &&
        b.BookingTime >= windowStart &&
        b.BookingTime <= windowEnd
    );

    if (conflictingBooking)
        return Results.BadRequest("Table already booked in this time window.");

    booking.TableId = tableId;
    table.IsAvailable = false;

    await db.SaveChangesAsync();

    return Results.Ok("Table assigned");
});

app.MapPatch("/admin/bookings/{id}/unassign-table", async (Cloud9Context db, int id) =>
{
    var booking = await db.Bookings
        .Include(b => b.Table)
        .FirstOrDefaultAsync(b => b.Id == id);

    if (booking is null)
        return Results.NotFound($"Booking {id} not found.");

    if (booking.Table is null)
        return Results.BadRequest("Booking has no assigned table.");

    booking.Table.IsAvailable = true;
    booking.TableId = null;

    await db.SaveChangesAsync();

    return Results.Ok(booking);
});
app.MapPost("/admin/cleanup", async (Cloud9Context db) =>
{
    await AutoCleanupBookings(db);
    return Results.Ok("Cleanup done");
});

app.MapGet("/categories", async (Cloud9Context db) =>
{
    var categories = await db.Categories.ToListAsync();

    return Results.Ok(categories);
});

app.MapGet("/categories/{id}/items", async (Cloud9Context db, int id) =>
{
    var items = await db.MenuItems
        .Where(m=>m.CategoryId==id)
        .ToListAsync();

    return Results.Ok(items);
});

app.MapGet("/menu-items", async (Cloud9Context db) =>
{
    var items = await db.MenuItems
        .Include(m => m.Category)
        .Select(m => new
        {
            m.Id,
            m.Name,
            m.Price,
            m.Description,
            m.Tags,
            m.ImageUrl,
            m.IsSpecial,
            Category = new
            {
                m.Category.Id,
                m.Category.Name  
            } 
           
        })
        .ToListAsync();

    return Results.Ok(items);
});

app.MapGet("/admin/tables", async (Cloud9Context db) =>
{
    var now = DateTime.UtcNow;
    var windowStart = now.AddHours(-3);
    var windowEnd = now.AddHours(3);

    var tables = await db.Tables
        .OrderBy(t => t.Id)
        .Select(t => new {
            t.Id,
            t.Capacity,
        IsAvailable= !db.Bookings.Any(b =>
                b.TableId == t.Id &&
                b.BookingTime >= windowStart &&
                b.BookingTime <= windowEnd  
            ),

            CurrentBooking = db.Bookings
                .Where(b =>
                 b.TableId == t.Id &&
                 b.BookingTime >= windowStart &&
                 b.BookingTime <= windowEnd)
                .Select(b => new {
                    b.Id,
                    b.FullName,
                    b.BookingTime,
                    b.Persons,
                    b.Notes
                })
                .FirstOrDefault()
        })
        .ToListAsync();

    return Results.Ok(tables);
});

app.MapGet("/admin/tables/available-for-booking/{bookingId}",
async (Cloud9Context db, int bookingId) =>
{
    var booking = await db.Bookings.FindAsync(bookingId);
    if (booking == null) return Results.NotFound();

    var windowStart = booking.BookingTime.AddHours(-3);
    var windowEnd = booking.BookingTime.AddHours(3);

    var availableTables = await db.Tables
        .Where(t => !db.Bookings.Any(b =>
                b.TableId == t.Id &&
                b.BookingTime >= windowStart &&
                b.BookingTime <= windowEnd
                ))
           
        .Select(t => new
        {
            t.Id,
            t.Capacity,
            t.IsAvailable
        })
        .ToListAsync();

        return Results.Ok(availableTables);
});

Console.WriteLine("CONNECTION STRING: " + connectionString);

app.MapGet("/test-db", async (Cloud9Context db) =>
{
    try
    {
        await db.Database.CanConnectAsync();
        return Results.Ok("DB works");
    }
    catch (Exception ex)
    {
        return Results.Problem(ex.Message);
    }
});
static async Task AutoCleanupBookings(Cloud9Context db)
{
    var now = DateTime.UtcNow;

    var releaseCutoff = now.AddHours(-3);   // release table after 3h
    var deleteCutoff = now.AddHours(-24);   // delete booking after 24h

        var releaseBookings = await db.Bookings
        .Include(b => b.Table)
        .Where(b =>
            b.TableId != null &&
            b.BookingTime < releaseCutoff
        )
        .ToListAsync();

    foreach (var booking in releaseBookings)
    {
        booking.Table!.IsAvailable = true;
        booking.TableId = null;
    }

      var deleteBookings = await db.Bookings
        .Where(b => b.BookingTime < deleteCutoff)
        .ToListAsync();

    if (deleteBookings.Any())
    {
        db.Bookings.RemoveRange(deleteBookings);
    }

    if (releaseBookings.Any() || deleteBookings.Any())
        await db.SaveChangesAsync();
}

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<Cloud9Context>();
    db.Database.EnsureCreated();
}
app.Run();
