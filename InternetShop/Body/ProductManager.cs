using InternetShop.Exception;
using InternetShop.Models;
using InternetShop.RegistrAndAuthorizat;
using Newtonsoft.Json;
using static InternetShop.Models.Color;

namespace InternetShop.Body
{
	public class ProductManager
	{
		/// <summary>
		/// Меню администратора по изменениям списка товаров
		/// </summary>
		public ProductManager()
		{
			try
			{
				Console.WriteLine("Команды:\n\n1 - Добавить товар\n2 - Удалить товар\n3 - Изменить информацию товара\n4 - Выйти");
				Console.Write("Выберите команду: ");
				string select = Console.ReadLine();

				switch (select)
				{
					case "1":
						Console.WriteLine("Выберите цифру в какой категорию в которую хотите создать новый товар находится продукт:" +
							"\n1 - Электроника\n2 - Одежда\n3 - Книги");
						int id = int.Parse(Console.ReadLine());
						if (id == 1)
						{
							AddProduct(id);
						}
						else if (id == 2)
						{
							AddProduct(id);
						}
						else if (id == 3)
						{
							AddProduct(id);
						}
						else
						{
							throw new MessageException("У нас нет такой категории");
						}
						break;
					case "2":
						Console.WriteLine("Выберите цифру в какой категории вы хотите удалить товар:" +
							"\n1 - Электроника\n2 - Одежда\n3 - Книги");
						int ID = int.Parse(Console.ReadLine());
						if (ID == 1)
						{
							DeleteProduct(ID);
						}
						else if (ID == 2)
						{
							DeleteProduct(ID);
						}
						else if (ID == 3)
						{
							DeleteProduct(ID);
						}
						else
						{
							throw new MessageException("У нас нет такой категории");
						}
						break;
					case "3":
						Console.WriteLine("Выберите цифру в какой категорию вы хотите изменить информацию о товаре:" +
							"\n1 - Электроника\n2 - Одежда\n3 - Книги");
						int Id = int.Parse(Console.ReadLine());
						if (Id == 1)
						{
							changeProduct(Id);
						}
						else if (Id == 2)
						{
							changeProduct(Id);
						}
						else if (Id == 3)
						{
							changeProduct(Id);
						}
						else
						{
							throw new MessageException("У нас нет такой категории");
						}
						break;
					case "4":
						string Name = File.ReadAllText(@"C:\Users\Admin\source\repos\InternetShop\Name.txt");
						int value = 0;
						personalAccount account = new personalAccount(Name,value);
						break;
					default:
						Console.WriteLine("Я не знаю такой команды");
						break;
				}
			}
			catch(MessageException)
			{
                Console.WriteLine();
            }
		}
		/// <summary>
		/// Добваление продукта
		/// </summary>

		public static void AddProduct(int id)
		{
			Console.Clear();
			List<Products> listProduct = new List<Products>();
			switch (id)
			{
				case 1:
					var jsonFileElectr = File.ReadAllText(@"C:\Users\Admin\source\repos\InternetShop\Electronic.json");
					listProduct = JsonConvert.DeserializeObject<List<Products>>(jsonFileElectr);
					break;
				case 2:
					var jsonFileCloths = File.ReadAllText(@"C:\Users\Admin\source\repos\InternetShop\Cloth.json");
					listProduct = JsonConvert.DeserializeObject<List<Products>>(jsonFileCloths);
					break;
				case 3:
					var jsonFileBook = File.ReadAllText(@"C:\Users\Admin\source\repos\InternetShop\Book.json");
					listProduct = JsonConvert.DeserializeObject<List<Products>>(jsonFileBook);
					break;
			}
			for (int i = 0; i < listProduct.Count; i++)
			{
                Console.WriteLine($"id продукта:{listProduct[i].Id}\nПродукт:{listProduct[i].Name}\nОписание:{listProduct[i].Description}" +
							$"\nКоличество:{listProduct[i].Amount}\nЦена:{listProduct[i].Price} рублей\n ");
            }

			Console.WriteLine("Введите id нового продукта(id продукта не должен совпадать с id из уже существующих продуктов): ");
			int idNewProduct = int.Parse(Console.ReadLine());

			Console.WriteLine("Введите имя нового продукта(имя продукта не должен совпадать с именем из уже существующих продуктов):");
			string nameNewProduct = Console.ReadLine();

			Console.WriteLine("Введите описание нового продукта:");
			string descriptionNewProduct = Console.ReadLine();

			Console.WriteLine("Введите количество нового продукта:");
			int amountNewProduct = int.Parse(Console.ReadLine());

			Console.WriteLine("Введите цену на новый продукта:");
			decimal priceNewProduct = decimal.Parse(Console.ReadLine());

			for (int i = 0; i < listProduct.Count; i++)
			{
				if(idNewProduct == listProduct.Count + 1)
				{
					listProduct.Add(
						new Products
						{
							Id = idNewProduct,
							Name = nameNewProduct,
							Description = descriptionNewProduct,
							Amount = amountNewProduct,
							Price = priceNewProduct,
							categoryId = listProduct[0].categoryId

						});
                    Console.WriteLine("Продукт успешно добавлен\nНажмите любую кнопку");
					Console.ReadLine();
				}
			}
			if (id == 1)
			{
				var jsonFileElectronic = JsonConvert.SerializeObject(listProduct);
				File.WriteAllText(@"C:\Users\Admin\source\repos\InternetShop\Electronic.json", jsonFileElectronic);
			}
			else if (id == 2)
			{
				var jsonFileCloth = JsonConvert.SerializeObject(listProduct);
				File.WriteAllText(@"C:\Users\Admin\source\repos\InternetShop\Cloth.json", jsonFileCloth);
			}
			else if (id == 3)
			{
				var jsonFileBooks = JsonConvert.SerializeObject(listProduct);
				File.WriteAllText(@"C:\Users\Admin\source\repos\InternetShop\Book.json", jsonFileBooks);
			}

		}
		/// <summary>
		/// Удаление продукта
		/// </summary>
		public static void DeleteProduct(int id)
		{
			Console.Clear();
			List<Products> listProduct = new List<Products>();
			switch (id)
			{
				case 1:

					var jsonFileElectr = File.ReadAllText(@"C:\Users\Admin\source\repos\InternetShop\Electronic.json");
					listProduct = JsonConvert.DeserializeObject<List<Products>>(jsonFileElectr);
					break;
				case 2:

					var jsonFileCloths = File.ReadAllText(@"C:\Users\Admin\source\repos\InternetShop\Cloth.json");
					listProduct = JsonConvert.DeserializeObject<List<Products>>(jsonFileCloths);
					break;
				case 3:

					var jsonFileBook = File.ReadAllText(@"C:\Users\Admin\source\repos\InternetShop\Book.json");
					listProduct = JsonConvert.DeserializeObject<List<Products>>(jsonFileBook);
					break;
			}

			for (int i = 0; i < listProduct.Count; i++)
			{
				Console.WriteLine($"id продукта:{listProduct[i].Id}\nПродукт:{listProduct[i].Name}\nОписание:{listProduct[i].Description}" +
							$"\nКоличество:{listProduct[i].Amount}\nЦена:{listProduct[i].Price} рублей\n ");
			}

			Console.WriteLine("Введите id продукта, который хотите удалить:");
			int idDeleteProduct = int.Parse(Console.ReadLine());


			for (int i = 0; i < listProduct.Count; i++)
			{
				if (idDeleteProduct == listProduct[i].Id)
				{
					listProduct.RemoveAt(i);
					Console.WriteLine("Продукт успешно удален\nНажмите любую кнопку");
					Console.ReadLine();
				}
			}
			if (id == 1)
			{
				var jsonFileElectronic = JsonConvert.SerializeObject(listProduct);
				File.WriteAllText(@"C:\Users\Admin\source\repos\InternetShop\Electronic.json", jsonFileElectronic);
			}
			else if (id == 2)
			{
				var jsonFileCloth = JsonConvert.SerializeObject(listProduct);
				File.WriteAllText(@"C:\Users\Admin\source\repos\InternetShop\Cloth.json", jsonFileCloth);
			}
			else if (id == 3)
			{
				var jsonFileBooks = JsonConvert.SerializeObject(listProduct);
				File.WriteAllText(@"C:\Users\Admin\source\repos\InternetShop\Book.json", jsonFileBooks);
			}
		}
		
		/// <summary>
		/// Ищменяет информацию о товаре
		/// </summary>
		public static void changeProduct(int id)
		{
			Console.Clear();
			Green();
			List<Products> listProduct = new List<Products>();
			int determinant = 0;
			switch (id)
			{
				case 1:
					var jsonFileElectr = File.ReadAllText(@"C:\Users\Admin\source\repos\InternetShop\Electronic.json");
					listProduct = JsonConvert.DeserializeObject<List<Products>>(jsonFileElectr);
					break;
				case 2:
					var jsonFileCloths = File.ReadAllText(@"C:\Users\Admin\source\repos\InternetShop\Cloth.json");
					listProduct = JsonConvert.DeserializeObject<List<Products>>(jsonFileCloths);
					break;
				case 3:
					var jsonFileBook = File.ReadAllText(@"C:\Users\Admin\source\repos\InternetShop\Book.json");
					listProduct = JsonConvert.DeserializeObject<List<Products>>(jsonFileBook);
					break;
			}

			for (int i = 0; i < listProduct.Count; i++)
			{
				Console.WriteLine($"id продукта:{listProduct[i].Id}\nПродукт:{listProduct[i].Name}\nОписание:{listProduct[i].Description}" +
							$"\nКоличество:{listProduct[i].Amount}\nЦена:{listProduct[i].Price} рублей\n ");
			}

            Console.Write("Выберите id товара у которого хотите изменить информацию:");
			Blue();
			int userId = int.Parse(Console.ReadLine());
			Default();
			for (int i =0; i< listProduct.Count;i++)
			{
				if (userId == listProduct[i].Id)
				{
					Console.WriteLine($"1 - {listProduct[i].Name}\n2 - {listProduct[i].Description}\n3 - {listProduct[i].Amount}\n4 - {listProduct[i].Price}");
                    Console.WriteLine("Какую информацию вы хотите изменить(введите номер или нажмите любую кнопку для выхода): ");
					string select = Console.ReadLine();
					if (select == "1")
					{
                        Console.WriteLine("Введите данные которые заменят текущую информацию: ");
						listProduct[i].Name = Console.ReadLine();
					}
					else if (select == "2")
					{
						Console.WriteLine("Введите данные которые заменят текущую информацию: ");
						listProduct[i].Description = Console.ReadLine();
					}
					else if (select == "3")
					{
						Console.WriteLine("Введите данные которые заменят текущую информацию: ");
						listProduct[i].Amount = int.Parse(Console.ReadLine());
					}
					else if (select == "4")
					{
						Console.WriteLine("Введите данные которые заменят текущую информацию: ");
						listProduct[i].Price = decimal.Parse(Console.ReadLine());
					}
					else 
					{
						personalAccount account = new personalAccount();
					}
				}
			}
			if (id == 1)
			{
				var jsonFileElectronic = JsonConvert.SerializeObject(listProduct);
				File.WriteAllText(@"C:\Users\Admin\source\repos\InternetShop\Electronic.json", jsonFileElectronic);
			}
			else if (id == 2)
			{
				var jsonFileCloth = JsonConvert.SerializeObject(listProduct);
				File.WriteAllText(@"C:\Users\Admin\source\repos\InternetShop\Cloth.json", jsonFileCloth);
			}
			else if (id == 3)
			{
				var jsonFileBooks = JsonConvert.SerializeObject(listProduct);
				File.WriteAllText(@"C:\Users\Admin\source\repos\InternetShop\Book.json", jsonFileBooks);
			}

		}
		
	}
}
