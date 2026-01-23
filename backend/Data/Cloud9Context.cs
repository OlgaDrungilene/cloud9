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
            new Category { Id = 2, Name = "Mains" },
            new Category { Id = 3, Name = "Desserts" },
            new Category { Id = 4, Name = "Wine" },
            new Category { Id = 5, Name = "Beer" },
            new Category { Id = 6, Name = "Cocktails" }
            
        );

        modelBuilder.Entity<MenuItem>().HasData(
            new MenuItem { 
                Id = 1, 
                Name = "Bruschetta", 
                Price = 12, 
                Description = "Toasted bread topped with fresh tomatoes, basil, and a drizzle of balsamic glaze.", 
                Tags = "Tomato | Basil | Balsamic glaze",
                ImageUrl = "/images/bruschetta.jpg",
                CategoryId = 1 
                },
            new MenuItem { 
                Id = 2, 
                Name = "Garlic shrimp", 
                Price = 14, 
                Description = "Succulent shrimp sautéed in garlic butter sauce, served with a side of crusty bread.", 
                Tags = "Shrimp | Garlic | Butter",
                ImageUrl = "/images/garlicshrimp.jpg",
                CategoryId = 1 
                },
            new MenuItem { 
                Id = 3, 
                Name = "Stuffed Mushrooms", 
                Price = 14, 
                Description = "Mushroom caps stuffed with a savory mixture of cheese and herbs, baked to perfection.", 
                Tags = "Mushrooms | Cheese | Herbs",
                ImageUrl = "/images/stuffed_mushrooms.jpg",
                CategoryId = 1 
                },
            new MenuItem { 
                Id = 4, 
                Name = "Caprese Salad", 
                Price=11, 
                Description = "Fresh mozzarella, ripe tomatoes, and basil leaves drizzled with olive oil and balsamic reduction.", 
                Tags = "Mozzarella | Tomato | Basil",
                ImageUrl = "/images/caprese.jpg",
                CategoryId = 1
                },
            new MenuItem { 
                Id = 5, 
                Name = "Grilled Salmon", 
                Price= 25, 
                Description = "Freshly grilled salmon served with a side of lemon and asparagus.", 
                Tags = "Salmon | Lemon | Asparagus",
                ImageUrl = "/images/salmon.jpg",
                CategoryId = 2
                },
            new MenuItem { 
                Id = 6, 
                Name = "Ribeye Steak", 
                Price = 30, 
                Description = "Juicy ribeye steak cooked to perfection, topped with garlic butter and served with creamy mashed potatoes.", 
                Tags = "Beef | Garlic Butter | Mashed Potatoes",
                ImageUrl = "/images/ribeye.jpg",
                CategoryId = 2, 
                IsSpecial = true 
                },
            new MenuItem { 
                Id = 7, 
                Name = "Cheesecake", 
                Price = 8, 
                Description = "Classic cheesecake with a graham cracker crust, topped with fresh strawberry sauce.", 
                Tags = "Cream Cheese | Graham Cracker Crust | Strawberry Sauce",
                ImageUrl = "/images/cheesecake.jpg",
                CategoryId = 3 
                },
            new MenuItem { 
                Id = 8, 
                Name = "Chocolate Lava Cake", 
                Price = 9, 
                Description = "Warm chocolate cake with a gooey center, served with vanilla ice cream and raspberry sauce.", 
                Tags = "Dark Chocolate | Vanilla Ice Cream | Raspberry Sauce",
                ImageUrl = "/images/lava_cake.jpg",
                CategoryId = 3 
                },
            new MenuItem { 
                Id = 9, 
                Name = "Chapel Hill Shiraz", 
                Description = "A full-bodied red wine with rich flavors of dark fruit and a hint of spice.", 
                Tags = "AU | Bottle",
                ImageUrl = "/images/shiraz.jpg",
                Price = 56, 
                CategoryId = 4 
                },
            new MenuItem { 
                Id = 10, 
                Name = "Catena Malbee", 
                Description = "A robust red wine with notes of blackberry, plum, and a touch of oak.", 
                Tags = "AU | Bottle",
                ImageUrl = "/images/malbee.jpg",
                Price = 59, 
                CategoryId = 4 
                },
            new MenuItem { 
                Id = 11, 
                Name = "La Vieille Rose", 
                Description = "A crisp and refreshing rosé wine with flavors of strawberry and citrus.", 
                Tags = "FR | 750 ml",
                ImageUrl = "/images/rose.jpg",
                Price = 44, 
                CategoryId = 4
                 },
            new MenuItem { 
                Id = 12, 
                Name = "Rhino Pale Ale", 
                Description = "A smooth and hoppy pale ale with notes of citrus and pine.",
                Tags = "CA | 750 ml",
                ImageUrl = "/images/pale_ale.jpg",
                Price = 31, 
                CategoryId = 5 
                },
            new MenuItem
                {
                Id = 13, 
                Name = "Irish Guinness", 
                Description = "A classic Irish stout with a rich, creamy texture and flavors of roasted malt and coffee.",
                Tags = "IE | 750 ml",
                ImageUrl = "/images/irish_guiness.jpg",
                Price = 26, 
                CategoryId = 5 
                    
                },
                 new MenuItem
                {
                Id = 14, 
                Name = "Aperol Spritz", 
                Description = "A refreshing cocktail made with Aperol, prosecco, and a splash of soda, garnished with an orange slice.",
                Tags = "Aperol | Prosecco | soda | 30 ml",
                ImageUrl = "/images/aperol.jpg",
                Price = 20, 
                CategoryId = 6 
                    
                },
                 new MenuItem
                {
                Id = 15, 
                Name = "Dark 'N' Stormy", 
                Description = "A classic cocktail made with dark rum and ginger beer, served over ice with a slice of lime.",
                Tags = "Dark rum | Ginger beer | Slice of lime",
                ImageUrl = "/images/dark_stormy.jpg",
                Price = 16, 
                CategoryId = 6 
                    
                },
                 new MenuItem
                {
                Id = 16, 
                Name = "Strawberry Daiquiri", 
                Description = "A sweet and tangy cocktail made with rum, fresh strawberries, citrus juice, and a touch of sugar.",
                Tags = "Rum | Citrus juice | Sugar",
                ImageUrl = "/images/strawberry_daiquiri.jpg",
                Price = 10, 
                CategoryId = 6 
                    
                },
                 new MenuItem
                {
                Id = 17, 
                Name = "Old Fashioned", 
                Description = "A timeless cocktail made with bourbon, brown sugar, and Angostura bitters, garnished with an orange twist.",
                Tags = "Bourbon | Brown sugar | Angostura Bitters",
                ImageUrl = "/images/old_fashioned.jpg",
                Price = 31, 
                CategoryId = 6 
                    
                },
                 new MenuItem
                {
                Id = 18, 
                Name = "Negroni", 
                Description = "A classic Italian cocktail made with gin, sweet vermouth, and Campari, garnished with an orange slice.",
                Tags = "Gin | Vermouth | Campari | Orange garnish",
                ImageUrl = "/images/negroni.jpg",
                Price = 26, 
                CategoryId = 6 
                    
                }      
                
    );

    }
}
