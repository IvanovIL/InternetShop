using ConsoleShop.Body;
using InternetShop.Body;
using System.Diagnostics.Contracts;
using static InternetShop.Models.Color;
using static InternetShop.Program;

namespace InternetShop.RegistrAndAuthorizat
{
	internal class personalAccount
	{
		private static bool run = true;
		

		public personalAccount(string Name , int value)
		{
			string history = "Ваш личный аккаунт";
			visitHistory History = new visitHistory(history);
			if (value == 0)
			{
				run = true;
				value++;
			}
			else if (value < 0)
			{
				value--;
			}

			while (run)
			{
				Console.Clear();
				Green();
				Console.WriteLine("======================================");
				Console.Write($"Добро пожаловать в личный кабинет {Name}");
				Console.WriteLine("======================================\n");
				Cyan();
				Console.WriteLine("1.Просмотр категорий товаров\n2.Поиск товара" +
					"\n3.Корзина\n4.История заказов\n5.Административные функции(только для администратора)\n6.Проверить баланс средств" +
					"\n7.Проверить свою историю посещения\n8.Выйти");
				
				Blue();
				string select = Console.ReadLine();

				userChoice(select);
			}
			Program program = new Program();
		}

		public static void userChoice(string select)
		{
			switch (select)
			{
				case "1":
					Menu();
					break;
				case "2":
					FindProduct find = new FindProduct();
					break;
				case "3":
					Cart cart = new Cart();
					break;
				case "4":
					historyOrder order = new historyOrder();
					break;
				case "5":
					ProductManager productManager = new ProductManager();
					break;
					case "6":
					Wallet wallet = new Wallet();
					break;
				case "7":
					visitHistory History = new visitHistory();
					break;
				case "8":
					Console.Clear();
					run = false;
					break;
				default:
                    Console.WriteLine("Я не знаю такой команды");
                    break;
			}
		}

		public personalAccount()
		{
			string Name = File.ReadAllText(@"C:\Users\Admin\source\repos\InternetShop\Name.txt");
			int value  = 0;

			personalAccount personalAccount = new personalAccount(Name, value);
		}
	}
}
