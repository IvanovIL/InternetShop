using InternetShop.Exception;
using InternetShop.Models;
using Newtonsoft.Json;
using System.Runtime.InteropServices;
using static InternetShop.Models.Color;
using static InternetShop.Program;

namespace InternetShop.Body
{
	internal class Cart
	{
		/// <summary>
		/// Добавление в корзину товаров
		/// </summary>

		public Cart(string NameProduct, decimal PriceProduct, int value , int GeneralId)
		{
			try
			{
				Green();
				string history = "Корзина";
				historyOrder History = new historyOrder(history);
				Console.WriteLine("======================================");
				Console.WriteLine("Добавленные товары в корзину: ");
				Console.WriteLine("======================================");
				Default();

				List<Product> list = new List<Product>();

				var CartLists = File.ReadAllText(@"C:\Users\Admin\source\repos\InternetShop\CartList.json");
				list = JsonConvert.DeserializeObject<List<Product>>(CartLists);
				// Добавляет товар если коризна пуста
				if (list.Count == 0)
				{

					list.Add(
						new Product()
						{
							Name = NameProduct,
							Price = PriceProduct,
							Amount = value,
							generalId = GeneralId
						});
					var CartList = JsonConvert.SerializeObject(list);
					File.WriteAllText(@"C:\Users\Admin\source\repos\InternetShop\CartList.json", CartList);
				}
				//Добавляет товар если в корзина не пуста
				else if (list.Count != 0)
				{
					list.Add(
						new Product
						{
							Name = NameProduct,
							Price = PriceProduct,
							Amount = value,
							generalId = GeneralId
						});
					var CartList = JsonConvert.SerializeObject(list);
					File.WriteAllText(@"C:\Users\Admin\source\repos\InternetShop\CartList.json", CartList);
				}

				for (int i = 0; i < list.Count; i++)
				{
					Console.WriteLine($"{i + 1}:{list[i].Name} {list[i].Price} * {list[i].Amount} = {list[i].Price * list[i].Amount}");
				}

				Console.Write("Команды:\n\nremove [номер] [количество] - удалить товар из корзины\ncheckout - оформить заказ" +
					"\nclear - очистить корзину\nback - вернуться в главное меню\n\nВведите команду:");
				string readLine = Console.ReadLine();

				menuCart(readLine);
			}
			catch (MessageException)
			{
				Console.WriteLine("Ошибка");
			}
		}

		public static void menuCart(string readLine)
		{
			try
			{
				List<Product> list = new List<Product>();
				var CartLists = File.ReadAllText(@"C:\Users\Admin\source\repos\InternetShop\CartList.json");
				list = JsonConvert.DeserializeObject<List<Product>>(CartLists);
				switch (readLine)
				{
					case "remove":
						//Удаляет товар из корзины
						Console.Write("Введите номер продукта: ");
						int removeElement = (int.Parse(Console.ReadLine()) - 1);
						Console.Write("Введите количество продукта: ");
						int removeValue = int.Parse(Console.ReadLine());
						for (int i = 0; i < list.Count; i++)
						{
							if (removeElement == i)
							{
								if (removeValue == list[i].Amount)
								{
									list.RemoveAt(i);
									addDeleteProduct(list[i].Name, removeValue, list[i].generalId);
								}
								else if (removeValue < list[i].Amount)
								{
									list[i].Amount -= removeValue;
									addDeleteProduct(list[i].Name, removeValue, list[i].generalId);
								}
								else
								{
									throw new MessageException("Не возможно удалить количество продукта превышающее в корзине");
								}
							}

							if (list.Count != 0)
							{
								Console.WriteLine($"{i + 1}:{list[i].Name} {list[i].Price} * {list[i].Amount}");
							}
							
							var CartList = JsonConvert.SerializeObject(list);
							File.WriteAllText(@"C:\Users\Admin\source\repos\InternetShop\CartList.json", CartList);

						}
						Console.ReadLine();
						break;
					case "checkout":
						decimal pricesProducts = 0;
						for (int i = 0; i< list.Count; i++)
						{
							pricesProducts += list[i].Price;
						}
                        Console.WriteLine($"Общая сумма: {pricesProducts} рублей\n нажмите 1 если хотите оплатить или 2 если хотите выйти:");
						string select = Console.ReadLine();
						if (select == "1")
						{
							Wallet wallet = new Wallet(pricesProducts);
						}
						else if (select == "2")
						{
							Cart cart = new Cart();
						}
						else
						{
							throw new MessageException("Ошибка: нет такой команды!");
                        }
                        break;
					case "clear":
						// Очищает корзину и сохраняет 
						list.Clear();
						for (int i = 0; i < list.Count; i++)
						{
							Console.WriteLine($"{i + 1}:{list[i].Name} {list[i].Price} * {list[i].Amount}");
						}
						var CartListClear = JsonConvert.SerializeObject(list);
						File.WriteAllText(@"C:\Users\Admin\source\repos\InternetShop\CartList.json", CartListClear);
						break;
					case "back":
						Menu();
						break;
					default:
                        Console.WriteLine("Я не знаю такой команды");
                        break;
				}
			}
			catch (MessageException)
			{
				Console.WriteLine("Ошибка");

			}
		}


		public Cart()
		{
			Green();
			Console.WriteLine("======================================");
			Console.WriteLine("Добавленные товары в корзину: ");
			Console.WriteLine("======================================");
			Default();

			List<Product> list = new List<Product>();

			var CartLists = File.ReadAllText(@"C:\Users\Admin\source\repos\InternetShop\CartList.json");
			list = JsonConvert.DeserializeObject<List<Product>>(CartLists);


			for (int i = 0; i < list.Count; i++)
			{
				Console.WriteLine($"{i + 1}:{list[i].Name} {list[i].Price} * {list[i].Amount} = {list[i].Price * list[i].Amount}");
			}

			Console.Write("Команды:\n\nremove [номер] [количество] - удалить товар из корзины\ncheckout - оформить заказ" +
				"\nclear - очистить корзину\nback - вернуться в главное меню\n\nВведите команду:");
			string readLine = Console.ReadLine();

			menuCart(readLine);
			Console.ReadLine();
		}

		public static void addDeleteProduct(string Name, int valueProduct, int generalId)
		{
			List<Products> list = new List<Products>();

			switch (generalId)
			{
				case 1:
					var jsonFileElectr = File.ReadAllText(@"C:\Users\Admin\source\repos\InternetShop\Electronic.json");
					list = JsonConvert.DeserializeObject<List<Products>>(jsonFileElectr);

					for (int i = 0; i < list.Count; ++i)
					{
						if (Name == list[i].Name)
						{
							list[i].Amount += valueProduct;
							break;
						}
					}
					var jsonFileElectronic = JsonConvert.SerializeObject(list);
					File.WriteAllText(@"C:\Users\Admin\source\repos\InternetShop\Electronic.json", jsonFileElectronic);
					break;
				case 2:
					var jsonFileCloths = File.ReadAllText(@"C:\Users\Admin\source\repos\InternetShop\Cloth.json");
					list = JsonConvert.DeserializeObject<List<Products>>(jsonFileCloths);

					for (int i = 0; i < list.Count; ++i)
					{
						if (Name == list[i].Name)
						{
							list[i].Amount += valueProduct;
							break;
						}
					}
					var jsonFileCloth = JsonConvert.SerializeObject(list);
					File.WriteAllText(@"C:\Users\Admin\source\repos\InternetShop\Cloth.json", jsonFileCloth);
					break;
				case 3:
					var jsonFileBook = File.ReadAllText(@"C:\Users\Admin\source\repos\InternetShop\Book.json");
					list = JsonConvert.DeserializeObject<List<Products>>(jsonFileBook);

					for (int i = 0; i < list.Count; ++i)
					{
						if (Name == list[i].Name)
						{
							list[i].Amount += valueProduct;
							break;
						}
					}
					var jsonFileBooks = JsonConvert.SerializeObject(list);
					File.WriteAllText(@"C:\Users\Admin\source\repos\InternetShop\Book.json", jsonFileBooks);
					break;
				default:
                    Console.WriteLine("Ошибка");
                    break;
			}
		}
	}
}
