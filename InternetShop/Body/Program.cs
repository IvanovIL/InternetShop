using InternetShop.RegistrAndAuthorizat;
using static InternetShop.Models.Color;
using static InternetShop.Body.electronicCategory;
namespace InternetShop
{
    internal class Program
    {
        public static int value = 0;
		public static bool run = true;
		public static void Main(string[] args)
        {
            
			while (run)
			{
				Green();
				Console.WriteLine("======================================");
				Console.WriteLine("Консольный Магазин");
				Console.Write("======================================");
				Default();
				Console.Write("\n1. Войти\n2. Регистрация\n3. Выйти из программы\n\nВыберите команду: ");
				Blue();
				string select = Console.ReadLine();
				Choice(select);
			}

		}

        public static void Choice(string select)
        {
            switch (select)
            {
                case "1":
                    
                    authorization authorization = new authorization();
                    string Name = File.ReadAllText(@"C:\Users\Admin\source\repos\InternetShop\Name.txt");
                    personalAccount account = new personalAccount(Name , value);
                    break;
                case "2":
                    Registration registration = new Registration();
                    break;
                case "3":
                    run = false;
                    break;
                default:
                    Red();
                    Console.WriteLine("Неизвестная команда!");
                    break;

            }
        }
		public static void Menu()
		{
			Green();
			Console.WriteLine("Категории товаров:\n1. Электроника\n2. Одежда\n3. Книги\n");
			Console.Write("Введите номер категории для просмотра товаров или '0' для возврата в меню: ");
			Blue();
			string select = Console.ReadLine();

			switch (select)
			{
				case "1":
					choiceProduct();
					break;
				case "2":
					break;
				case "3":
					break;
				case "0":
					break;
				default:
					Console.WriteLine("У нас нет такой категории товаров");
					break;
			}

		}


	}
}

