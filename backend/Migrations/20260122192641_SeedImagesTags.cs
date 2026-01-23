using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class SeedImagesTags : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "MenuItems",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tags",
                table: "MenuItems",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Mains");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Wine");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Beer");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "Cocktails");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "ImageUrl", "Price", "Tags" },
                values: new object[] { "Toasted bread topped with fresh tomatoes, basil, and a drizzle of balsamic glaze.", "/images/bruschetta.jpg", 12m, "Tomato | Basil | Balsamic glaze" });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "ImageUrl", "Name", "Price", "Tags" },
                values: new object[] { "Succulent shrimp sautéed in garlic butter sauce, served with a side of crusty bread.", "/images/garlicshrimp.jpg", "Garlic shrimp", 14m, "Shrimp | Garlic | Butter" });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "IsSpecial", "Name", "Price", "Tags" },
                values: new object[] { 1, "Mushroom caps stuffed with a savory mixture of cheese and herbs, baked to perfection.", "/images/stuffed_mushrooms.jpg", false, "Stuffed Mushrooms", 14m, "Mushrooms | Cheese | Herbs" });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Name", "Price", "Tags" },
                values: new object[] { 1, "Fresh mozzarella, ripe tomatoes, and basil leaves drizzled with olive oil and balsamic reduction.", "/images/caprese.jpg", "Caprese Salad", 11m, "Mozzarella | Tomato | Basil" });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Name", "Price", "Tags" },
                values: new object[] { 2, "Freshly grilled salmon served with a side of lemon and asparagus.", "/images/salmon.jpg", "Grilled Salmon", 25m, "Salmon | Lemon | Asparagus" });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "IsSpecial", "Name", "Price", "Tags" },
                values: new object[] { 2, "Juicy ribeye steak cooked to perfection, topped with garlic butter and served with creamy mashed potatoes.", "/images/ribeye.jpg", true, "Ribeye Steak", 30m, "Beef | Garlic Butter | Mashed Potatoes" });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Name", "Price", "Tags" },
                values: new object[] { 3, "Classic cheesecake with a graham cracker crust, topped with fresh strawberry sauce.", "/images/cheesecake.jpg", "Cheesecake", 8m, "Cream Cheese | Graham Cracker Crust | Strawberry Sauce" });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Name", "Price", "Tags" },
                values: new object[] { 3, "Warm chocolate cake with a gooey center, served with vanilla ice cream and raspberry sauce.", "/images/lava_cake.jpg", "Chocolate Lava Cake", 9m, "Dark Chocolate | Vanilla Ice Cream | Raspberry Sauce" });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Name", "Price", "Tags" },
                values: new object[] { 4, "A full-bodied red wine with rich flavors of dark fruit and a hint of spice.", "/images/shiraz.jpg", "Chapel Hill Shiraz", 56m, "AU | Bottle" });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Name", "Price", "Tags" },
                values: new object[] { 4, "A robust red wine with notes of blackberry, plum, and a touch of oak.", "/images/malbee.jpg", "Catena Malbee", 59m, "AU | Bottle" });

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "IsSpecial", "Name", "Price", "SpecialDate", "Tags" },
                values: new object[,]
                {
                    { 11, 4, "A crisp and refreshing rosé wine with flavors of strawberry and citrus.", "/images/rose.jpg", false, "La Vieille Rose", 44m, null, "FR | 750 ml" },
                    { 12, 5, "A smooth and hoppy pale ale with notes of citrus and pine.", "/images/pale_ale.jpg", false, "Rhino Pale Ale", 31m, null, "CA | 750 ml" },
                    { 13, 5, "A classic Irish stout with a rich, creamy texture and flavors of roasted malt and coffee.", "/images/irish_guiness.jpg", false, "Irish Guinness", 26m, null, "IE | 750 ml" },
                    { 14, 6, "A refreshing cocktail made with Aperol, prosecco, and a splash of soda, garnished with an orange slice.", "/images/aperol.jpg", false, "Aperol Spritz", 20m, null, "Aperol | Prosecco | soda | 30 ml" },
                    { 15, 6, "A classic cocktail made with dark rum and ginger beer, served over ice with a slice of lime.", "/images/dark_stormy.jpg", false, "Dark 'N' Stormy", 16m, null, "Dark rum | Ginger beer | Slice of lime" },
                    { 16, 6, "A sweet and tangy cocktail made with rum, fresh strawberries, citrus juice, and a touch of sugar.", "/images/strawberry_daiquiri.jpg", false, "Strawberry Daiquiri", 10m, null, "Rum | Citrus juice | Sugar" },
                    { 17, 6, "A timeless cocktail made with bourbon, brown sugar, and Angostura bitters, garnished with an orange twist.", "/images/old_fashioned.jpg", false, "Old Fashioned", 31m, null, "Bourbon | Brown sugar | Angostura Bitters" },
                    { 18, 6, "A classic Italian cocktail made with gin, sweet vermouth, and Campari, garnished with an orange slice.", "/images/negroni.jpg", false, "Negroni", 26m, null, "Gin | Vermouth | Campari | Orange garnish" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "MenuItems");

            migrationBuilder.DropColumn(
                name: "Tags",
                table: "MenuItems");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Main Courses");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Drinks");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Cocktails");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "Wine");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 7, "Beer" },
                    { 8, "Tasting Menu" }
                });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Price" },
                values: new object[] { null, 89m });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Name", "Price" },
                values: new object[] { null, "Beef Carpaccio", 149m });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CategoryId", "Description", "IsSpecial", "Name", "Price" },
                values: new object[] { 2, null, true, "Ribeye Steak", 289m });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CategoryId", "Description", "Name", "Price" },
                values: new object[] { 2, null, "Spaghetti Carbonara", 179m });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CategoryId", "Description", "Name", "Price" },
                values: new object[] { 3, null, "Tiramisu", 95m });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CategoryId", "Description", "IsSpecial", "Name", "Price" },
                values: new object[] { 3, null, false, "Panna Cotta", 85m });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CategoryId", "Description", "Name", "Price" },
                values: new object[] { 7, null, "IPA Beer", 79m });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CategoryId", "Description", "Name", "Price" },
                values: new object[] { 6, null, "Merlot Wine", 99m });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CategoryId", "Description", "Name", "Price" },
                values: new object[] { 5, null, "Old Fashioned Cocktail", 129m });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CategoryId", "Description", "Name", "Price" },
                values: new object[] { 5, null, "Gin & Tonic", 109m });
        }
    }
}
