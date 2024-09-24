using InternetShop.RegistrAndAuthorizat;
using static InternetShop.Models.Color;
using static InternetShop.Body.Category.Electronic;
using static InternetShop.Body.Category.Book;
using static InternetShop.Body.Category.Сloth;

namespace InternetShop
{
    internal class Program
    {
        private static int value = 0;
		private static bool run = true;
		private static string name_;
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
					name_ = Name;
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
					choiceCloth();
					break;
				case "3":
					choiceBook();
					break;
				case "0":
					personalAccount account = new personalAccount(name_,value);
					break;
				default:
					Console.WriteLine("У нас нет такой категории товаров");
					break;
			}

		}


	}
}

