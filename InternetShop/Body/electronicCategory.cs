using InternetShop.Exception;
using InternetShop.Models;
using static InternetShop.Models.Color;
using static InternetShop.Program;


namespace InternetShop.Body
{
	/// <summary>
	/// Просмотр товаров электроники,а также добавление их в коризну
	/// </summary>
	internal class electronicCategory : Products
	{

		public static void choiceProduct()
		{
			List<Products> ProductsElectronicList = new List<Products>()
			{
				new Products
				{

					Id = 1,
					Name = "Телевизор Samsung",
					Description = "Телевизор от производителей Samsung, " +
					"43-дюймовым экраном и 4K-разрешением.\nПоддержка HDR улучшает качество цветопередачи, делает изображение более красочным.",
					Amount = 20,
					Price = 9.999m
				},
			new Products
			{
				Id = 2,
				Name = "планшет Huawie",
				Description = "Планшет от производителей Huawie, черного цвета имеет диагональ экрана 11" +
				" и использует Android 13.x,\nчто раскрывает огромный потенциал устройства. " +
				"Благодаря процессору Qualcomm Snapdragon 870 с 8-ядерной архитектурой аппарат справляется с любыми задачами.",
				Amount = 15,
				Price = 6.999m
			},
			new Products
			{
				Id = 3,
				Name = "смартфон redmi",
				Description = "смартфон от производителей redmi, обладает 6.5-дюймовым Super AMOLED-дисплеем, " +
				"\nкоторый отображает глубокий черный цвет и гарантирует своевременную смену кадров.",
				Amount = 30,
				Price = 4.999m,
			}
			};


			try
			{
				//using (StreamWriter store = new StreamWriter(@"C:\Users\Admin\source\repos\InternetShop\Store.txt"))
				//{
				//	foreach (Products Product in ProductsElectronicList)
				//	{
				//		store.WriteLine(Convert.ToInt32(Product.Id));
				//		store.WriteLine(Product.Name);
				//		store.WriteLine(Product.Description);
				//		store.WriteLine(Convert.ToInt32(Product.Amount));
				//		store.WriteLine(Convert.ToDecimal(Product.Price));

				//	}
				//	store.Close();
				//}

				// Выводит продукты на консоль
				Products[] product = new Products[ProductsElectronicList.Count];
				ProductsElectronicList.CopyTo(product);

				Green();
				for (int i = 0; i < product.Length; i++)
				{
					Console.WriteLine($"{product[i].Id}.{product[i].Name} {product[i].Price}");
				}

				Console.Write("Выберите продукт по номеру: ");
				Blue();
				int selectId = int.Parse(Console.ReadLine());
				Console.Clear();

				Green();
				for (int i = 0; i < ProductsElectronicList.Count; i++)
				{

					if (ProductsElectronicList[i].Id == selectId)
					{
						// чтобы добавить продукт в корзину первое введеное число будет командой,а второе число количеством

						Console.WriteLine("--------------------------------------");
						Console.WriteLine($"Продукт:{ProductsElectronicList[i].Name}\nОписание:{ProductsElectronicList[i].Description}" +
							$"\nКоличество:{ProductsElectronicList[i].Amount}\nЦена:{ProductsElectronicList[i].Price} рублей\n ");
						Yellow();
						Console.WriteLine("Команды:\n№1add [количество] - добавить товар в корзину\n№2back - вернуться к списку товаров");
						int select = int.Parse(Console.ReadLine());
						int value = 0;
						if (select == 1)
						{
							if (ProductsElectronicList[i].Amount != 0)
							{
								value = int.Parse(Console.ReadLine());
								ProductsElectronicList[i].Amount = -value;
								string userNameProduct = ProductsElectronicList[i].Name;
								decimal userPriceProduct = ProductsElectronicList[i].Price;

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

