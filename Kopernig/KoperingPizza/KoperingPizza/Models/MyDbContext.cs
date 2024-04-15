using KoperingPizza.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Reflection.Metadata;

namespace KoperingPizza.Models
{
    public class MyDbContext : IdentityDbContext<AppUser>
    {
        public MyDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SizeToProducts> SizeToProducts { get; set; }
		public DbSet<Slider> Sliders { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Slider>().HasData(
                new Slider
                {
                    Id = 1,
                    Name = "New Trend",
                    Title = "Summer Sale Stylish",
                    Description = "TestDescription",
                    Image = "pizza.png"
                }
                );
            base.OnModelCreating(modelBuilder);


			modelBuilder.Entity<SizeToProducts>()
	   .HasKey(stp => new { stp.ProductId, stp.SizeProductId });

			// Configuring the many-to-many relationship between Product and SizeProduct
			modelBuilder.Entity<SizeToProducts>()
				.HasOne(stp => stp.Product) // Each SizeToProducts has one Product
				.WithMany(p => p.SizeToProducts) // Each Product has many SizeToProducts
				.HasForeignKey(stp => stp.ProductId); // The foreign key in SizeToProducts pointing to Product

			modelBuilder.Entity<SizeToProducts>()
				.HasOne(stp => stp.SizeProduct) // Each SizeToProducts has one SizeProduct
				.WithMany(sp => sp.SizeToProducts) // Each SizeProduct has many SizeToProducts
				.HasForeignKey(stp => stp.SizeProductId); // The foreign key in SizeToProducts pointing to SizeProduct

		}
	}
}