using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
	public class ProductDAO
	{
		public static List<Product> GetProducts()
		{
			var products = new List<Product>();
			try
			{
				using (var context = new MyDbContext())
				{
					products = context.Products
						.Include(p => p.Category)
						.ToList();
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
			return products;
		}

		public static Product FindProductById(int productId)
		{
			Product product = new Product();
			try
			{
				using (var context = new MyDbContext())
				{
					product = context.Products
						.Include(p => p.Category)
						.SingleOrDefault(p => p.ProductId == productId);
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
			return product;
		}

		public static void SaveProduct(Product product)
		{
			try
			{
				using (var context = new MyDbContext())
				{
					context.Products.Add(product);
					context.SaveChanges();
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public static void UpdateProduct(Product product)
		{
			try
			{
				using (var context = new MyDbContext())
				{
					context.Entry<Product>(product).State = EntityState.Modified;
					context.SaveChanges();
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public static void DeleteProduct(Product product)
		{
			try
			{
				using (var context = new MyDbContext())
				{
					var productDelete = context.Products.SingleOrDefault(p => p.ProductId == product.ProductId);
					context.Products.Remove(productDelete);
					context.SaveChanges();
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
	}
}
