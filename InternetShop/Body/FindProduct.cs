using InternetShop.Models;
using Newtonsoft.Json;
using static InternetShop.Program;
using static InternetShop.Models.Color;
using InternetShop.Exception;



namespace InternetShop.Body
{
	internal class FindProduct
	{

		/// <summary>
		/// Поиск продукта по его названию
		/// </summary>
		public FindProduct()
		{
			int number = 0;
			Green();
			Console.Write("Введите категорию продукта:");
			Blue();
			string userNameCategory = Console.ReadLine();
	
			switch (userNameCategory.ToLower())
			{
				case "электроника":
					Find(number = 1);
					break;
				case "одежда":
					Find(number = 2);
					break;
				case "книги":
					Find(number = 3);
					break;
				default:
					Console.WriteLine("У нас нет такой категории товаров!");
					Console.ReadLine();
					break;
			}

		}
		private static List<Products> ProductsList = new List<Products>();
		public static void Find(int number)
		{
			try
			{
				if (number == 1)
				{
					var jsonFileElectr = File.ReadAllText(@"C:\Users\Admin\source\repos\InternetShop\Electronic.json");
					ProductsList = JsonConvert.DeserializeObject<List<Products>>(jsonFileElectr);
				}
				else if (number == 2)
				{
					var jsonFileCloths = File.ReadAllText(@"C:\Users\Admin\source\repos\InternetShop\Cloth.json");
					ProductsList = JsonConvert.DeserializeObject<List<Products>>(jsonFileCloths);
				}
				else if (number == 3)
				{
					var jsonFileBook = File.ReadAllText(@"C:\Users\Admin\source\repos\InternetShop\Book.json");
					ProductsList = JsonConvert.DeserializeObject<List<Products>>(jsonFileBook);
				}
				Green();
				Console.Write("Введите назавние продукта:");
				Blue();
				string NameProduct = Console.ReadLine();

				for (int i = 0; i < ProductsList.Count; i++)
				{
					// приводит строки к нижнему регистру для точного сравнения
					NameProduct = NameProduct.ToLower();
					ProductsList[i].Name = ProductsList[i].Name.ToLower();

					// сравнивает запрос товара со списком и выводит на экран совпадение
					if (ProductsList[i].Name.Contains(NameProduct))
					{
						Console.WriteLine("--------------------------------------");
						Console.WriteLine($"Продукт:{ProductsList[i].Name}\nОписание:{ProductsList[i].Description}" +
							$"\nКоличество:{ProductsList[i].Amount}\nЦена:{ProductsList[i].Price} рублей\n ");
						Yellow();
						Console.WriteLine("Команды:\n№1add [количество] - добавить товар в корзину\n№2back - вернуться к списку товаров");
						int select = int.Parse(Console.ReadLine());
						int value = 0;
						if (select == 1)
						{
							if (ProductsList[i].Amount != 0)
							{
								// вычитает из общего товара количество заказного товара пользователя
								value = int.Parse(Console.ReadLine());
								ProductsList[i].Amount -= value;
								// сохраняет товар в json файл
								var jsonFileElectronic = JsonConvert.SerializeObject(ProductsList);
								File.WriteAllText(@"C:\Users\Admin\source\repos\InternetShop\Electronic.json", jsonFileElectronic);

								// передает товар в корзину
								Cart cart = new Cart(ProductsList[i].Name, ProductsList[i].Price, value, ProductsList[i].categoryId);
							}
							else
							{
								Console.WriteLine("Товар на складе отсутствует");
							}
						}
						else if (select == 2)
						{
							Menu();
						}

					}
				}
			}
			catch (MessageException exception)
			{
                Console.WriteLine("Ошибка");
            }

		}


	}
}
