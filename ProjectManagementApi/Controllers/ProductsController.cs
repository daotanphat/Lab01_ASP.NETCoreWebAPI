using BusinessObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories;

namespace ProjectManagementAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		private readonly IProductRepository repository = new ProductRepository();

		[HttpGet]
		public ActionResult<IEnumerable<Product>> GetProducts() => repository.GetProducts();

		[HttpPost]
		public IActionResult PostProduct(Product p)
		{
			repository.SaveProduct(p);
			return NoContent();
		}

		[HttpDelete("id")]
		public IActionResult DeleteProduct(int id)
		{
			var product = repository.GetProductById(id);
			if (product == null) return NotFound();
			repository.DeleteProduct(product);
			return NoContent();
		}

		[HttpPut("id")]
		public IActionResult UpdateProduct(int id, Product p)
		{
			var product = repository.GetProductById(id);
			if (product == null) return NotFound();
			repository.UpdateProduct(product);
			return NoContent();
		}
	}
}
