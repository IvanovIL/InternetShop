using static InternetShop.Program;
using InternetShop.Exception;
using static InternetShop.Models.Color;
using InternetShop.Models;
using Newtonsoft.Json;

namespace InternetShop.Body.Category
{
    internal class Сloth : Products
    {
		public static void choiceCloth()
		{
			List<Products> ProductsClothList = new List<Products>()
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
				ProductsClothList = JsonConvert.DeserializeObject<List<Products>>(jsonFileElectr);

				// Выводит продукты на консоль
				Green();
				for (int i = 0; i < ProductsClothList.Count; i++)
				{
					Console.WriteLine($"{ProductsClothList[i].Id}.{ProductsClothList[i].Name} {ProductsClothList[i].Price}");
				}

				Console.Write("Выберите продукт по номеру: ");
				Blue();
				int selectId = int.Parse(Console.ReadLine());
				Console.Clear();

				Green();
				for (int i = 0; i < ProductsClothList.Count; i++)
				{

					if (ProductsClothList[i].Id == selectId)
					{
						// чтобы добавить продукт в корзину первое введеное число будет командой,а второе число количеством

						Console.WriteLine("--------------------------------------");
						Console.WriteLine($"Продукт:{ProductsClothList[i].Name}\nОписание:{ProductsClothList[i].Description}" +
							$"\nКоличество:{ProductsClothList[i].Amount}\nЦена:{ProductsClothList[i].Price} рублей\n ");
						Yellow();
						Console.WriteLine("Команды:\n№1add [количество] - добавить товар в корзину\n№2back - вернуться к списку товаров");
						int select = int.Parse(Console.ReadLine());
						int value = 0;
						if (select == 1)
						{
							if (ProductsClothList[i].Amount != 0)
							{
								value = int.Parse(Console.ReadLine());
								ProductsClothList[i].Amount -= value;

								var jsonFileElectronic = JsonConvert.SerializeObject(ProductsClothList);
								File.WriteAllText(@"C:\Users\Admin\source\repos\InternetShop\Electronic.json", jsonFileElectronic);

								string userNameProduct = ProductsClothList[i].Name;
								decimal userPriceProduct = ProductsClothList[i].Price;

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
