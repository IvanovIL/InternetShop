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
			List<Products> ProductsBooksList = new List<Products>();
			//{
			//	new Products
			//	{

			//		Id = 1,
			//		Name = "Стихи А.С.Пушкин",
			//		Description = "Сборник стихов поэта А.С.Пушкина на 250 стр. Бумажный вариант с твердой обложкой.",
			//		Amount = 20,
			//		Price = 500m,
			//		categoryId = 3
			//	},
			//new Products
			//{
			//	Id = 2,
			//	Name = "Сборник рассказов Стругацких",
			//	Description = "Сборник рассказов Аркадий и Борис Стругацких на 870 стр. Мягкая обложка.",
			//	Amount = 15,
			//	Price = 1500m,
			//	categoryId = 3
			//},
			//new Products
			//{
			//	Id = 3,
			//	Name = "Сказки для детей",
			//	Description = "Сборник сказок для детей. 380 стр. Мягкая обложка.",
			//	Amount = 30,
			//	Price = 1000.50m,
			//	categoryId = 3
			//}
			//};
			try
			{

				//достает из json список товаров
				var jsonFileBook = File.ReadAllText(@"C:\Users\Admin\source\repos\InternetShop\Book.json");
				ProductsBooksList = JsonConvert.DeserializeObject<List<Products>>(jsonFileBook);

				// Выводит продукты на консоль
				Green();
				for (int i = 0; i < ProductsBooksList.Count; i++)
				{
					Console.WriteLine($"{ProductsBooksList[i].Id}.{ProductsBooksList[i].Name} {ProductsBooksList[i].Price} рублей");
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
								// вычитает из общего товара количество заказного товара пользователя
								value = int.Parse(Console.ReadLine());
								ProductsBooksList[i].Amount -= value;
								// сохраняет товар в json файл
								var jsonFileBooks = JsonConvert.SerializeObject(ProductsBooksList);
								File.WriteAllText(@"C:\Users\Admin\source\repos\InternetShop\Book.json", jsonFileBooks);

							
								// передает товар в корзину
								Cart cart = new Cart(ProductsBooksList[i].Name, ProductsBooksList[i].Price, value, ProductsBooksList[i].categoryId);
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
