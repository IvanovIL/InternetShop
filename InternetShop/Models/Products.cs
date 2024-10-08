

namespace InternetShop.Models
{
	public class Products()
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }

		public int Amount { get; set; }
		public decimal Price { get; set; }

		public int categoryId { get; set; }

	}

	public class Product
	{

		public string Name { get; set; }

		public decimal Price { get; set; }

		public int Amount { get; set; }

		public int generalId { get; set; }


	}

}
