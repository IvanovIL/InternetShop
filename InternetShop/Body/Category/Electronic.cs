using InternetShop.Exception;
using InternetShop.Models;
using Newtonsoft.Json;
using System.Linq;
using static InternetShop.Models.Color;
using static InternetShop.Program;


namespace InternetShop.Body.Category
{
	/// <summary>
	/// Просмотр товаров электроники,а также добавление их в коризну
	/// </summary>
	internal class Electronic : Products
	{


		public static void choiceProduct()
		{
			List<Products> ProductsElectronicList = new List<Products>();
			//{
			//	new Products
			//	{

			//		Id = 1,
			//		Name = "телевизор samsung",
			//		Description = "телевизор от производителей samsung, " +
			//		"43-дюймовым экраном и 4k-разрешением.\nподдержка hdr улучшает качество цветопередачи, делает изображение более красочным.",
			//		Amount = 20,
			//		Price = 9999.90m,
			//		generalId = 1
			//	},
			//new Products
			//{
			//	Id = 2,
			//	Name = "планшет huawie",
			//	Description = "планшет от производителей huawie, черного цвета имеет диагональ экрана 11" +
			//	" и использует android 13.x,\nчто раскрывает огромный потенциал устройства. " +
			//	"благодаря процессору qualcomm snapdragon 870 с 8-ядерной архитектурой аппарат справляется с любыми задачами.",
			//	Amount = 15,
			//	Price = 6000.50m,
			//	generalId = 1
			//},
			//new Products
			//{
			//	Id = 3,
			//	Name = "смартфон redmi",
			//	Description = "смартфон от производителей redmi, обладает 6.5-дюймовым super amoled-дисплеем, " +
			//	"\nкоторый отображает глубокий черный цвет и гарантирует своевременную смену кадров.",
			//	Amount = 30,
			//	Price = 4000m,
			//	generalId=1
			//}
			//};


			try
			{
				///достает из json список товаров
				var jsonFileElectr = File.ReadAllText(@"C:\Users\Admin\source\repos\InternetShop\Electronic.json");
				ProductsElectronicList = JsonConvert.DeserializeObject<List<Products>>(jsonFileElectr);
				// Выводит продукты на консоль
				Green();
				for (int i = 0; i < ProductsElectronicList.Count; i++)
				{
					Console.WriteLine($"{ProductsElectronicList[i].Id}.{ProductsElectronicList[i].Name} {ProductsElectronicList[i].Price}");
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
								// вычитает из общего товара количество заказного товара пользователя
								value = int.Parse(Console.ReadLine());
								ProductsElectronicList[i].Amount -= value;
								// сохраняет товар в json файл
								var jsonFileElectronic = JsonConvert.SerializeObject(ProductsElectronicList);
								File.WriteAllText(@"C:\Users\Admin\source\repos\InternetShop\Electronic.json", jsonFileElectronic);

								// передает товар в корзину
								Cart cart = new Cart(ProductsElectronicList[i].Name, ProductsElectronicList[i].Price, value,
									ProductsElectronicList[i].categoryId);
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

