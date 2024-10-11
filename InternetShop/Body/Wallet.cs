using ConsoleShop.Body;
using InternetShop.Models;
using InternetShop.RegistrAndAuthorizat;
using Newtonsoft.Json;


namespace InternetShop.Body
{
	public class Wallet
	{
		private static decimal wallet = 0;
		private static int value = 0;
		string Name = File.ReadAllText(@"C:\Users\Admin\source\repos\InternetShop\Name.txt");
		
		public Wallet()
		{
			var wallets = File.ReadAllText(@"C:\Users\Admin\source\repos\InternetShop\Wallet.json");
			wallet =Convert.ToDecimal(JsonConvert.DeserializeObject(wallets));

			string history = "Кошелёк";
			visitHistory History = new visitHistory(history);
			Console.WriteLine($"Баланс средств на вашем аккаунте равен: {wallet}" +
				$"\n\nВыберите команду:\n\n1 - Пополнить баланс" +
				$"\n2 - Посмотреть историю покупок\n3 - Выйти в меню");
			string select = Console.ReadLine();

			switch (select)
			{
				case "1":
					replenishBalance();
					break;
				case "2":
					historyOrder historyOrder = new historyOrder();
					break;
				case "3":
					personalAccount account = new personalAccount(Name, value);
					break;
			}

			Console.ReadLine();
		}
		/// <summary>
		/// Пополнение баланса
		/// </summary>
		public static void replenishBalance()
		{
			Console.Write("Сколько рублей перевести на ваш счет:");
			decimal userMoney = int.Parse(Console.ReadLine());

			wallet += userMoney;
			Console.WriteLine($"Ваш баланс равен: {userMoney} рублей");
			var wallets = JsonConvert.SerializeObject(wallet);
			File.WriteAllText(@"C:\Users\Admin\source\repos\InternetShop\Wallet.json", wallets);
		}
		/// <summary>
		/// Оплата товара
		/// </summary>
		
		public Wallet(decimal priceProduct)
		{
			var wallets = File.ReadAllText(@"C:\Users\Admin\source\repos\InternetShop\Wallet.json");
			wallet = Convert.ToDecimal(JsonConvert.DeserializeObject(wallets));

			if ((wallet -= priceProduct) >= 0)
			{
				var Wallets = JsonConvert.SerializeObject(wallet);
				File.WriteAllText(@"C:\Users\Admin\source\repos\InternetShop\Wallet.json", Wallets);

				Console.WriteLine("Заказ успешно оплачен");

				List<Product> list = new List<Product>();
				var CartLists = File.ReadAllText(@"C:\Users\Admin\source\repos\InternetShop\CartList.json");
				list = JsonConvert.DeserializeObject<List<Product>>(CartLists);
				for (int i = 0; i < list.Count; i++)
				{
					historyOrder historyOrder = new historyOrder(list[i].Name, list[i].Amount, list[i].Price);
				}
				list.Clear();
				var CartListClear = JsonConvert.SerializeObject(list);
				File.WriteAllText(@"C:\Users\Admin\source\repos\InternetShop\CartList.json", CartListClear);
			}
			else
			{
				Console.WriteLine("На счету недостаточно средств!");
				Wallet wallet = new Wallet();
			}

		}


	}
}
