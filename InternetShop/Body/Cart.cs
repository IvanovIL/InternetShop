using static InternetShop.Models.Color;
using static InternetShop.Program;

namespace InternetShop.Body
{
	internal class Cart
	{

		public Cart(string userNameProduct, decimal userPriceProduct, int value)
		{
			Green();
			Console.WriteLine("======================================");
			Console.WriteLine("Добавленные товары в корзину: ");
			Console.WriteLine("======================================");
			Default();

			Console.WriteLine($"{userNameProduct}-{userPriceProduct} * {value} = {userPriceProduct * value}");
			WriterTXT(userNameProduct, userPriceProduct * value);
			Console.Write("Команды:\n\nremove [номер] [количество] - удалить товар из корзины\ncheckout - оформить заказ" +
				"\nclear - очистить корзину\nback - вернуться в главное меню\n\nВведите команду:");
			string readLine = Console.ReadLine();
			switch (readLine)
			{
				case "remove":
					int number = int.Parse(Console.ReadLine());
					int userValue = int.Parse(Console.ReadLine());
					if (userValue <= value)
					{
						value = -userValue;
						break;
					}
					else if (userValue != 0)
					{

					}
					break;
				case "checkout":
					break;
				case "clear":
					break;
				case "back":
					Menu();
					break;
			}
					
			Console.ReadLine();
		}
		

		public static void WriterTXT(string userNameProduct, decimal userPriceProduct)
		{
			using (StreamWriter stream = new StreamWriter(@"C:\Users\Admin\source\repos\InternetShop\Cart.txt"))
			{
				stream.WriteLine(userNameProduct);
				stream.WriteLine(userPriceProduct);
				stream.Close();
			};
		}

		public Cart()
		{
			Green();
			Console.WriteLine("======================================");
			Console.Write("Добавленные товары в корзину: ");
			Console.WriteLine("======================================");
			Default();
			string userNameProduct;
			decimal userPriceProduct;
			using (StreamReader stream = new StreamReader(@"C:\Users\Admin\source\repos\InternetShop\Cart.txt"))
			{
				userNameProduct = stream.ReadToEnd();

				stream.Close();
			}
			Console.WriteLine(userNameProduct);
			Console.ReadLine();
		}
	}
}
