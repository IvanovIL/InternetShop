namespace InternetShop
{
    internal class Program
    {
        public static bool run = true;
        static void Main(string[] args)
        {
            
            while (run)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("======================================");
                Console.WriteLine("Консольный Магазин");
                Console.Write("======================================");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\n1. Войти\n2. Регистрация\n3. Выйти из программы\n\nВыберите команду: ");
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
                    break;
                case "2":
                    Registration registration = new Registration();
                    break;
                case "3":
                    run= false;
                    break;
                default:
                    Console.WriteLine("Неизвестная команда!");
                    break;

            }
        }
    }
}
