using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using backend.Data;
using backend.Models;
using backend.DTOs;
using Microsoft.OpenApi.Models;

Environment.SetEnvironmentVariable("DOTNET_USE_POLLING_FILE_WATCHER", "1");


var builder = WebApplication.CreateBuilder(args);
var jwtKey = builder.Configuration["Jwt:Key"];
var jwtIssuer = builder.Configuration["Jwt:Issuer"];
var jwtAudience = builder.Configuration["Jwt:Audience"];

//DbContext
var connectionString = Environment.GetEnvironmentVariable("ConnectionStrings__DefaultConnection")
?? builder.Configuration.GetConnectionString("DefaultConnection");

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
              .AllowAnyMethod()
              .AllowCredentials();;
    });
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,

        ValidIssuer = jwtIssuer,
        ValidAudience = jwtAudience,

        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(jwtKey!)
        )
    };
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy =>
        policy.RequireRole("Admin"));
});
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Cloud9 API",
        Version = "v1"
    });

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter JWT token"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

var app = builder.Build();

app.UseStaticFiles();

app.UseCors("ReactPolicy");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/", () => "Hello World!");

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
        .Where(t => t.IsAvailable)
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
app.MapGet("/admin", () =>
{
    return Results.Ok("Welcome Admin!");
})
.RequireAuthorization("AdminOnly");
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
})
.RequireAuthorization(policy =>
    policy.RequireRole("Admin"));

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

Console.WriteLine(connectionString?.Contains("Host=") == true
    ? "Connection string loaded"
    : "Connection string missing");

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

app.MapPost("/register", async (Cloud9Context db, UserRegisterDto dto) =>
{
    if (await db.Users.AnyAsync(u => u.Email == dto.Email))
        return Results.BadRequest("Email already exists");

    var hashedPassword = BCrypt.Net.BCrypt.HashPassword(dto.Password);

    var user = new User
    {
        FullName = dto.FullName,
        Email = dto.Email,
        PasswordHash = hashedPassword,
        Role = "User"
    };

    db.Users.Add(user);
    await db.SaveChangesAsync();

    return Results.Ok("User created");
});

app.MapPost("/login", async (
    Cloud9Context db,
    LoginDto dto) =>
{
    var user = await db.Users
        .FirstOrDefaultAsync(u => u.Email == dto.Email);

    if (user == null)
        return Results.BadRequest("Invalid email or password");

    bool isPasswordValid = BCrypt.Net.BCrypt
        .Verify(dto.Password, user.PasswordHash);

    if (!isPasswordValid)
        return Results.BadRequest("Invalid email or password");

    var claims = new[]
    {
        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
        new Claim(ClaimTypes.Email, user.Email),
        new Claim(ClaimTypes.Role, user.Role)
    };

    var key = new SymmetricSecurityKey(
        Encoding.UTF8.GetBytes(
            builder.Configuration["Jwt:Key"]!
        ));

    var creds = new SigningCredentials(
        key,
        SecurityAlgorithms.HmacSha256
    );

    var token = new JwtSecurityToken(
        issuer: builder.Configuration["Jwt:Issuer"],
        audience: builder.Configuration["Jwt:Audience"],
        claims: claims,
        expires: DateTime.UtcNow.AddDays(7),
        signingCredentials: creds
    );

    var jwt = new JwtSecurityTokenHandler()
        .WriteToken(token);

    return Results.Ok(new
    {
        token = jwt,
        role = user.Role,
        fullName = user.FullName
    });
});

app.MapGet("/me", (ClaimsPrincipal user) =>
{
    var email = user.FindFirst(ClaimTypes.Email)?.Value;
    var role = user.FindFirst(ClaimTypes.Role)?.Value;

    return Results.Ok(new
    {
        Email = email,
        Role = role
    });
}).RequireAuthorization();

app.Run();
