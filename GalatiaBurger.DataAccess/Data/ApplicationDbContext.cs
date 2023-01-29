using GalatiaBurger.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalatiaBurger.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Menu> Menus { get; set; }

        public DbSet<ExtraIngredient> ExtraIngredients { get; set; }

        public DbSet<SideMeal> SideMeals { get; set; }

        public DbSet<ShoppingCart> ShoppingCarts { get; set; }

        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Menu>().HasData(
                new Menu()
                {
                    Id = 1,
                    Name = "Hamburger",
                    Price = 50,
                    ImageUrl = "\\images\\menus\\b55eaa24-3bb5-4da2-aac9-dc7630c99fce.png"
                },
                new Menu()
                {
                    Id = 2,
                    Name = "Cheeseburger",
                    Price = 60,
                    ImageUrl = "\\images\\menus\\aa441fab-2272-4ff0-b301-651f11e1a45d.png"
                },
                new Menu()
                {
                    Id = 3,
                    Name = "Doubleburger",
                    Price = 80,
                    ImageUrl = "\\images\\menus\\e1be850d-5420-4922-b08b-d041281e60e8.png"
                },
                new Menu()
                {
                    Id = 4,
                    Name = "MixBurger",
                    Price = 70,
                    ImageUrl = "\\images\\menus\\1f5e765c-8b7b-4ea6-bdf1-8a17dc507958.png"
                }
                );

            builder.Entity<SideMeal>().HasData(
                new SideMeal()
                {
                    Id = 1,
                    Name = "French Fries",
                    Price = 20,
                    ImageUrl = "\\images\\sidemeals\\f25d8304-e7b4-4196-bac4-5c8eb78c2e46.png"
                },
                new SideMeal()
                {
                    Id = 2,
                    Name = "Onion Rings",
                    Price = 25,
                    ImageUrl = "\\images\\sidemeals\\170b0e23-382a-45de-8fa1-0d60a1ebeaf2.png"
                },
                new SideMeal()
                {
                    Id = 3,
                    Name = "Fried Cheese ",
                    Price = 30,
                    ImageUrl = "\\images\\sidemeals\\68c08a58-cbe9-4349-bf29-cf877b93190d.png"
                },
                new SideMeal()
                {
                    Id = 4,
                    Name = "Chicken Bites",
                    Price = 40,
                    ImageUrl = "\\images\\sidemeals\\cd664b15-0fd1-481d-852d-a100deb55315.png"
                }
                );
        }
    }
}
