using InternetShop.Body;
using System;
using System.ComponentModel.Design;
using static InternetShop.Models.Color;
using static InternetShop.Program;

namespace InternetShop.RegistrAndAuthorizat
{
	internal class personalAccount
	{
		public static bool run = true;
	
		public personalAccount(string Name , int value)
		{
			if (value == 0)
			{
				run = true;
				value++;
			}
			else if (value <= 0)
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
					"\n3.Корзина\n4.История заказов\n5.Административные функции(только для администратора)\n6.Выйти");
				
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
					break;
				case "3":
					Basket basket = new Basket("",0);
					break;
				case "4":
					break;
				case "5":
					break;
				case "6":
					run = false;
					Console.Clear();
					break;
			}
		}
	}
}
