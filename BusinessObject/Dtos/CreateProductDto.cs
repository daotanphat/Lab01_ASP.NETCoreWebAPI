using BusinessObject;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.Dtos
{
	public class CreateProductDto
	{
		[Required]
		[StringLength(40)]
		public string ProductName { get; set; }
		[Required]
		public int CategoryId { get; set; }
		[Required]
		public int UnitsInStock { get; set; }
		[Required]
		public decimal UnitPrice { get; set; }
	}
}
