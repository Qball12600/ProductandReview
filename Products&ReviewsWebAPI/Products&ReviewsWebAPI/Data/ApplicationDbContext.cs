using Microsoft.EntityFrameworkCore;
using Products_ReviewsWebAPI.Models;

namespace Products_ReviewsWebAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Product> Products { get; set; }
        public ApplicationDbContext(DbContextOptions options): base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed 5 products
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Wok Pan", Price = 29.99 },
                new Product { Id = 2, Name = "Heavy Duty Spatula", Price = 4.99 },
                new Product { Id = 3, Name = "Rice Cooker", Price = 49.99 },
                new Product { Id = 4, Name = "Bamboo Steamer", Price = 14.99 },
                new Product { Id = 5, Name = "Chopsticks Set", Price = 9.99 }
            );

            // Seed 15 reviews (3 reviews for each product)
            modelBuilder.Entity<Review>().HasData(
                new Review { Id = 1, Text = "Great wok for stir-frying!", Rating = 5, ProductId = 1 },
                new Review { Id = 2, Text = "Good quality product.", Rating = 4, ProductId = 2 },
                new Review { Id = 3, Text = "Makes perfect rice every time.", Rating = 5, ProductId = 3 },
                new Review { Id = 4, Text = "Perfect for steaming vegetables.", Rating = 4, ProductId = 4 },
                new Review { Id = 5, Text = "Nice chopsticks set for casual usage.", Rating = 4, ProductId = 5 },
                new Review { Id = 6, Text = "Decent wok, but could be better.", Rating = 3, ProductId = 1 },
                new Review { Id = 7, Text = "Melted on my stovetop.", Rating = 2, ProductId = 2 },
                new Review { Id = 8, Text = "Not very durable, broke after a few uses.", Rating = 2, ProductId = 3 },
                new Review { Id = 9, Text = "Steamer works well but could use more compartments.", Rating = 3, ProductId = 4 },
                new Review { Id = 10, Text = "Chopsticks are too slippery to hold properly.", Rating = 2, ProductId = 5 },
                new Review { Id = 11, Text = "Average wok, nothing special.", Rating = 3, ProductId = 1 },
                new Review { Id = 12, Text = "Standard spatula, everything you need.", Rating = 3, ProductId = 2 },
                new Review { Id = 13, Text = "Good value for the price.", Rating = 4, ProductId = 3 },
                new Review { Id = 14, Text = "Convenient for steaming various dishes.", Rating = 5, ProductId = 4 },
                new Review { Id = 15, Text = "Comfortable chopsticks to use.", Rating = 5, ProductId = 5 }
            );
        }
    }

}

