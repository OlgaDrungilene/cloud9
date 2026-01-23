using Microsoft.EntityFrameworkCore;
using backend.Data;
using backend.Models;

var builder = WebApplication.CreateBuilder(args);

//DbContext
builder.Services.AddDbContext<Cloud9Context>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddCors(options =>
{
    options.AddPolicy("ReactPolicy", policy =>
    {
        policy.WithOrigins("http://localhost:3000")
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

app.MapGet("/menu", async (Cloud9Context db) =>
{
    var items = await db.MenuItems
        .Include(m => m.Category)
        .ToListAsync();

    return Results.Ok(items);
});

app.MapGet("/menu/{id}", async (Cloud9Context db, int id) =>
{
    var item = await db.MenuItems
        .Include(m => m.Category)
        .FirstOrDefaultAsync(m => m.Id == id);

    return item is null ? Results.NotFound() : Results.Ok(item);
});

app.MapGet("/menu/specials", async (Cloud9Context db) =>
{
    var specials = await db.MenuItems
        .Where(m => m.IsSpecial)
        .ToListAsync();

    return Results.Ok(specials);
});

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
    db.Bookings.Add(booking);
    await db.SaveChangesAsync();

    return Results.Created($"/bookings/{booking.Id}", booking)  ;
});

app.MapGet("/bookings", async (Cloud9Context db) =>
{
    var bookings = await db.Bookings
    .Include(b => b.Table)
    .ToListAsync();

    return Results.Ok(bookings);
});

app.MapPatch("/bookings/{id}/assign-table", async (Cloud9Context db, int id, int tableId) =>
{
    var booking = await db.Bookings.FindAsync(id);
    if (booking is null)
        return Results.NotFound($"Booking {id} not found.");

    var table = await db.Tables.FindAsync(tableId);
    if (table is null)
        return Results.NotFound($"Table {tableId} not found.");

    if (!table.IsAvailable)
        return Results.BadRequest($"Table {tableId} is not available.");

    table.IsAvailable = false; // markera upptaget
    booking.TableId = tableId;

    await db.SaveChangesAsync();

    return Results.Ok(booking);
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
            Category = new
            {
                m.Category.Id,
                m.Category.Name  
            } 
           
        })
        .ToListAsync();

    return Results.Ok(items);
});
app.Run();
