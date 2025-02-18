﻿using BusinessObjects;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using System.Net.Http.Headers;
using System.Text.Json;

namespace ProductManagementWebClient.Controllers
{
	public class ProductController : Controller
	{
		private readonly HttpClient client = null;
		private string ProductApiUrl = "";
		public ProductController()
		{
			client = new HttpClient();
			var contentType = new MediaTypeWithQualityHeaderValue("application/json");
			client.DefaultRequestHeaders.Accept.Add(contentType);
			ProductApiUrl = "https://localhost:7071/api/products";
		}
		public async Task<IActionResult> Index()
		{
			HttpResponseMessage response = await client.GetAsync(ProductApiUrl);
			string strData = await response.Content.ReadAsStringAsync();

			var options = new JsonSerializerOptions
			{
				PropertyNameCaseInsensitive = true
			};
			List<Product> products = JsonSerializer.Deserialize<List<Product>>(strData, options);
			return View(products);
		}
	}
}
