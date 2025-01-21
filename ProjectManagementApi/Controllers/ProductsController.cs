using AutoMapper;
using BusinessObjects;
using BusinessObjects.Dtos;
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
		private readonly IMapper _mapper;

		public ProductsController(IMapper mapper)
		{
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult GetProducts()
		{
			var products = repository.GetProducts();
			var productResponse = _mapper.Map<List<ProductResponseDto>>(products);
			return Ok(productResponse);
		}
		[HttpPost]
		public IActionResult PostProduct([FromBody] CreateProductDto productDto)
		{
			var product = _mapper.Map<Product>(productDto);
			repository.SaveProduct(product);
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
		public IActionResult UpdateProduct([FromRoute] int id, [FromBody] UpdateProductDto productDto)
		{
			var product = repository.GetProductById(id);
			if (product == null) return NotFound();
			var productUpdate = _mapper.Map<Product>(productDto);
			repository.UpdateProduct(productUpdate);
			return NoContent();
		}
	}
}
