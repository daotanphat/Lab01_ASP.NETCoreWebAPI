using BusinessObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
	public class MyDbContext : DbContext
	{
		public MyDbContext(DbContextOptions<MyDbContext> options)
			: base(options)
		{
		}

		public MyDbContext()
		{

		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			var builder = new ConfigurationBuilder()
							   .SetBasePath(Directory.GetCurrentDirectory())
							   .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
			IConfigurationRoot configuration = builder.Build();
			optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
		}

		public virtual DbSet<Category> Category { get; set; }
		public virtual DbSet<Product> Products { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Category>().HasData(
				new Category { CategoryId = 1, CategoryName = "Beverages" },
				new Category { CategoryId = 2, CategoryName = "Condiments" },
				new Category { CategoryId = 3, CategoryName = "Confextions" },
				new Category { CategoryId = 4, CategoryName = "Dairy Products" },
				new Category { CategoryId = 5, CategoryName = "Grains/Cereals" },
				new Category { CategoryId = 6, CategoryName = "Meat/Poultry" },
				new Category { CategoryId = 7, CategoryName = "Produce" },
				new Category { CategoryId = 8, CategoryName = "Seafood" }
				);
		}
	}
}
