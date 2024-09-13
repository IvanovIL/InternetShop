using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetShop.Models
{
	internal class Products
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }

		public int Amount { get; set; }
		public decimal Price { get; set; }
	}
}
