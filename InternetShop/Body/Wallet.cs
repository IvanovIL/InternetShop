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
			string history = "Кошелёк";
			historyOrder History = new historyOrder(history);
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

		public static void replenishBalance()
		{
			Console.Write("Сколько рублей перевести на ваш счет:");
			decimal userMoney = int.Parse(Console.ReadLine());

			wallet += userMoney;
			Console.WriteLine($"Ваш баланс равен: {userMoney} рублей");
		}

		public Wallet(decimal priceProduct)
		{

			if ((wallet -= priceProduct) >= 0)
			{
				Console.WriteLine("Заказ успешно оплачен");
				Console.ReadLine();
				List<Product> list = new List<Product>();
				var CartLists = File.ReadAllText(@"C:\Users\Admin\source\repos\InternetShop\CartList.json");
				list = JsonConvert.DeserializeObject<List<Product>>(CartLists);
				list.Clear();
				for (int i = 0; i < list.Count; i++)
				{
					Console.WriteLine($"{i + 1}:{list[i].Name} {list[i].Price} * {list[i].Amount}");
				}
				var CartListClear = JsonConvert.SerializeObject(list);
				File.WriteAllText(@"C:\Users\Admin\source\repos\InternetShop\CartList.json", CartListClear);
			}
			else
			{
				Console.WriteLine("На счету недостаточно средств!");
				Console.ReadLine();
				Wallet wallet = new Wallet();
			}

		}


	}
}
