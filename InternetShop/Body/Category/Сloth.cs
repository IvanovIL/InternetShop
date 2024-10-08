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
			List<Products> ProductsClothList = new List<Products>();
			//{
			//	new Products
			//	{

			//		Id = 1,
			//		Name = "Пальто",
			//		Description = "Черное зимнее пальто. Хорошо защищает от холода и снега.",
			//		Amount = 12,
			//		Price = 6999m,
			//		generalId = 2
			//	},
			//new Products
			//{
			//	Id = 2,
			//	Name = "Кепка",
			//	Description = "Белая тонкая летняя кепка.",
			//	Amount = 45,
			//	Price = 700m,
			//	generalId = 2
			//},
			//new Products
			//{
			//	Id = 3,
			//	Name = "Ботинки",
			//	Description = "Зимние ботинки, утепленные с боковой молнией. Синего цвета.",
			//	Amount = 28,
			//	Price = 2000m,
			//	generalId = 2
			//}
			//};
			try
			{

				//достает из json список товаров
				var jsonFileCloths = File.ReadAllText(@"C:\Users\Admin\source\repos\InternetShop\Cloth.json");
				ProductsClothList = JsonConvert.DeserializeObject<List<Products>>(jsonFileCloths);

				// Выводит продукты на консоль
				Green();
				for (int i = 0; i < ProductsClothList.Count; i++)
				{
					Console.WriteLine($"{ProductsClothList[i].Id}.{ProductsClothList[i].Name} {ProductsClothList[i].Price} рублей");
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
								// вычитает из общего товара количество заказного товара пользователя
								value = int.Parse(Console.ReadLine());
								ProductsClothList[i].Amount -= value;
								// сохраняет товар в json файл
								var jsonFileCloth = JsonConvert.SerializeObject(ProductsClothList);
								File.WriteAllText(@"C:\Users\Admin\source\repos\InternetShop\Cloth.json", jsonFileCloth);
								// передает товар в корзину
								Cart cart = new Cart(ProductsClothList[i].Name, ProductsClothList[i].Price, value, ProductsClothList[i].categoryId);
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
