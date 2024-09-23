using static InternetShop.Program;
using InternetShop.Exception;
using static InternetShop.Models.Color ;
using InternetShop.Models;
using Newtonsoft.Json;

namespace InternetShop.Body.Category
{
	internal class Book
	{
		public static void choiceBook()
		{
			List<Products> ProductsBooksList = new List<Products>()
			{
				new Products
				{

					Id = 1,
					Name = "телевизор samsung",
					Description = "телевизор от производителей samsung, " +
					"43-дюймовым экраном и 4k-разрешением.\nподдержка hdr улучшает качество цветопередачи, делает изображение более красочным.",
					Amount = 20,
					Price = 9.999m
				},
			new Products
			{
				Id = 2,
				Name = "планшет huawie",
				Description = "планшет от производителей huawie, черного цвета имеет диагональ экрана 11" +
				" и использует android 13.x,\nчто раскрывает огромный потенциал устройства. " +
				"благодаря процессору qualcomm snapdragon 870 с 8-ядерной архитектурой аппарат справляется с любыми задачами.",
				Amount = 15,
				Price = 6.999m
			},
			new Products
			{
				Id = 3,
				Name = "смартфон redmi",
				Description = "смартфон от производителей redmi, обладает 6.5-дюймовым super amoled-дисплеем, " +
				"\nкоторый отображает глубокий черный цвет и гарантирует своевременную смену кадров.",
				Amount = 30,
				Price = 4.999m,
			}
			};
			try
			{

				///достает из json список товаров
				var jsonFileElectr = File.ReadAllText(@"C:\Users\Admin\source\repos\InternetShop\Electronic.json");
				ProductsBooksList = JsonConvert.DeserializeObject<List<Products>>(jsonFileElectr);

				// Выводит продукты на консоль
				Green();
				for (int i = 0; i < ProductsBooksList.Count; i++)
				{
					Console.WriteLine($"{ProductsBooksList[i].Id}.{ProductsBooksList[i].Name} {ProductsBooksList[i].Price}");
				}

				Console.Write("Выберите продукт по номеру: ");
				Blue();
				int selectId = int.Parse(Console.ReadLine());
				Console.Clear();

				Green();
				for (int i = 0; i < ProductsBooksList.Count; i++)
				{

					if (ProductsBooksList[i].Id == selectId)
					{
						// чтобы добавить продукт в корзину первое введеное число будет командой,а второе число количеством

						Console.WriteLine("--------------------------------------");
						Console.WriteLine($"Продукт:{ProductsBooksList[i].Name}\nОписание:{ProductsBooksList[i].Description}" +
							$"\nКоличество:{ProductsBooksList[i].Amount}\nЦена:{ProductsBooksList[i].Price} рублей\n ");
						Yellow();
						Console.WriteLine("Команды:\n№1add [количество] - добавить товар в корзину\n№2back - вернуться к списку товаров");
						int select = int.Parse(Console.ReadLine());
						int value = 0;
						if (select == 1)
						{
							if (ProductsBooksList[i].Amount != 0)
							{
								value = int.Parse(Console.ReadLine());
								ProductsBooksList[i].Amount -= value;

								var jsonFileElectronic = JsonConvert.SerializeObject(ProductsBooksList);
								File.WriteAllText(@"C:\Users\Admin\source\repos\InternetShop\Electronic.json", jsonFileElectronic);

								string userNameProduct = ProductsBooksList[i].Name;
								decimal userPriceProduct = ProductsBooksList[i].Price;

								Cart cart = new Cart(userNameProduct, userPriceProduct, value);
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
			catch (MessageException)
			{
				Console.WriteLine("Ошибка");
			}

		}

	}
}
