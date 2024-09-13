using static InternetShop.Models.Color;

namespace InternetShop.Body
{
    internal class Basket
    {
       
     
		public  Basket(string userNameProduct, decimal userPriceProduct)

		{
			Green();
			Console.WriteLine("======================================");
			Console.Write("Добавленные товары в корзину: ");
			Console.WriteLine("======================================");
			Default();
            Console.WriteLine($"{userNameProduct} {userPriceProduct}");
            Console.ReadLine();
		}
	}
}
