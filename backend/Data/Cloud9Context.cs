namespace backend.Data;
using backend.Models;
using Microsoft.EntityFrameworkCore;

public class Cloud9Context : DbContext
{
    public Cloud9Context(DbContextOptions<Cloud9Context> options) : base(options) { }

    public DbSet<Category> Categories => Set<Category>();
    public DbSet<MenuItem> MenuItems => Set<MenuItem>();
    public DbSet<Table> Tables => Set<Table>();
    public DbSet<Booking> Bookings => Set<Booking>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Seed fixed tables
        modelBuilder.Entity<Table>().HasData(
            new Table { Id = 1, Capacity = 2, IsAvailable = (1 % 2 == 0) },
            new Table { Id = 2, Capacity = 2, IsAvailable = (2 % 2 == 0) },
            new Table { Id = 3, Capacity = 4, IsAvailable = (3 % 2 == 0) },
            new Table { Id = 4, Capacity = 4 , IsAvailable = (4 % 2 == 0) },
            new Table { Id = 5, Capacity = 4, IsAvailable = (5 % 2 == 0) },
            new Table { Id = 6, Capacity = 4, IsAvailable = (6 % 2 == 0) },
            new Table { Id = 7, Capacity = 6, IsAvailable = (7 % 2 == 0) },
            new Table { Id = 8, Capacity = 6, IsAvailable = (8 % 2 == 0) },
            new Table { Id = 9, Capacity = 6, IsAvailable = (9 % 2 == 0) },
            new Table { Id = 10, Capacity = 6, IsAvailable = (10 % 2 == 0) },
            new Table { Id = 11, Capacity = 6, IsAvailable = (11 % 2 == 0) },
            new Table { Id = 12, Capacity = 6, IsAvailable = (12 % 2 == 0) }

        );

        modelBuilder.Entity<Booking>()
            .HasOne(b => b.Table)
            .WithMany()
            .HasForeignKey(b => b.TableId);

        modelBuilder.Entity<MenuItem>()
            .HasOne(m => m.Category)
            .WithMany(c => c.MenuItems)
            .HasForeignKey(m => m.CategoryId);

        modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Appetizers" },
            new Category { Id = 2, Name = "Main Courses" },
            new Category { Id = 3, Name = "Desserts" },
            new Category { Id = 4, Name = "Drinks" },
            new Category { Id = 5, Name = "Cocktails" },
            new Category { Id = 6, Name = "Wine" },
            new Category { Id = 7, Name = "Beer" },
            new Category { Id = 8, Name = "Tasting Menu" }
        );

        modelBuilder.Entity<MenuItem>().HasData(
            new MenuItem { Id = 1, Name = "Bruschetta", Price = 89, CategoryId = 1 },
            new MenuItem { Id = 2, Name = "Beef Carpaccio", Price = 149, CategoryId = 1 },
            new MenuItem { Id = 3, Name = "Ribeye Steak", Price = 289, CategoryId = 2, IsSpecial = true },
            new MenuItem { Id = 4, Name = "Spaghetti Carbonara", Price = 179, CategoryId = 2 },
            new MenuItem { Id = 5, Name = "Tiramisu", Price = 95, CategoryId = 3 },
            new MenuItem { Id = 6, Name = "Panna Cotta", Price = 85, CategoryId = 3 },
            new MenuItem { Id = 7, Name = "IPA Beer", Price = 79, CategoryId = 7 },
            new MenuItem { Id = 8, Name = "Merlot Wine", Price = 99, CategoryId = 6 },
            new MenuItem { Id = 9, Name = "Old Fashioned Cocktail", Price = 129, CategoryId = 5 },
            new MenuItem { Id = 10, Name = "Gin & Tonic", Price = 109, CategoryId = 5 }
);

    }
}
