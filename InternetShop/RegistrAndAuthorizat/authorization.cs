using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static InternetShop.Models.Color;
using InternetShop.Exception;
namespace InternetShop
{
    internal class authorization
    {
        /// <summary>
        /// ввод пароля и логина ,а также проверка их на правильность с их сохраненными версиями
        /// </summary>
        
        public authorization() 
        {
            try
            {
                string password;
                string login;

                using (StreamReader reader = new StreamReader(@"C:\Users\Admin\source\repos\InternetShop\Login.txt"))
                {
                    login = reader.ReadLine();
                }

                using (StreamReader reader = new StreamReader(@"C:\Users\Admin\source\repos\InternetShop\Password.txt"))
                {
                    password = reader.ReadLine();
                }
                Yellow();
                Console.Write("Введите логин: ");
                Blue();
                string userLogin = Console.ReadLine();

                if (userLogin == login)
                {
                    Green();
                    Console.WriteLine("Логин верный");
                }
                else
                {
                    Red();
                    throw new LogPasException("Логин не верный!, введите правильный логин");
                }

                Yellow();
                Console.WriteLine("Введите пароль: ");

                Blue();
                string userPassword = Console.ReadLine();

                if (userPassword == password)
                {
                    Green();
                    Console.WriteLine("Логин верный");
                }
                else
                {
                    Red();
                    throw new LogPasException("Пароль не верный!, введите правильный пароль");
                }
            }

			catch(LogPasException exception)

			{
				Console.WriteLine(exception.Message);
                authorization authorization = new authorization();
			}
        }
    }
}
