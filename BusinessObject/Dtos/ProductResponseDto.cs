using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.Dtos
{
	public class ProductResponseDto
	{
		public string ProductName { get; set; }
		public string CategoryName { get; set; }
		public int UnitsInStock { get; set; }
		public decimal UnitPrice { get; set; }
	}
}
