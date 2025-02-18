﻿using BusinessObject;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.Dtos
{
	public class CreateProductResponseDto
	{
		public int ProductId { get; set; }
		public string ProductName { get; set; }
		public int CategoryId { get; set; }
		public int UnitsInStock { get; set; }
		public decimal UnitPrice { get; set; }
	}
}
