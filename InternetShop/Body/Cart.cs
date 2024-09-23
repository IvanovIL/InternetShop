using InternetShop.Models;
using Newtonsoft.Json;
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
			WriterProductJson(userNameProduct, userPriceProduct * value);
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
		

		public static void WriterProductJson(string userNameProduct, decimal userPriceProduct)
		{
			Dictionary<string, decimal> list = new Dictionary<string, decimal>()
			{
				{userNameProduct,userPriceProduct }
			};
			 
			var CartList = JsonConvert.SerializeObject(list);
			
			File.WriteAllText(@"C:\Users\Admin\source\repos\InternetShop\CartList.json", CartList);
		}

		public Cart()
		{
			Green();
			Console.WriteLine("======================================");
			Console.WriteLine("Добавленные товары в корзину: ");
			Console.WriteLine("======================================");
			Default();

			Dictionary<string, decimal> lists = new Dictionary<string, decimal>();
			string jsonCart = File.ReadAllText(@"C:\Users\Admin\source\repos\InternetShop\CartList.json");
			lists = JsonConvert.DeserializeObject<Dictionary<string, decimal>>(jsonCart);

			foreach (var list in lists)
			{
                Console.WriteLine(list);
            }
			
			Console.ReadLine();
		}
	}
}
