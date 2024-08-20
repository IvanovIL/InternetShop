using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace InternetShop
{
    internal class Registration
    {

        public Registration()
        {

            Console.WriteLine("Создание логин:\n" +
                "(Требования к созданию логина:\nОн должен быть не больше 10 символов," +
                " не содержать пробелы, содержать хотя бы одну цифру: ");

            string login = Console.ReadLine();
            examinationLogin(login);

            Console.WriteLine("Создание пароль:\n" +
                "(Требования к созданию пароля:\nОн должен быть не больше 10 символов," +
                " не содержать пробелы, содержать хотя бы одну цифру" +
                " и включать в себя хотя бы один из символов(!?#*-+=$%): ");

            string password = Console.ReadLine();
            examinationPassword(password);

            /// <summary>
            /// Сохранение пароля в текстовый документ
            /// <summary>

            using (StreamWriter writer = new StreamWriter(@"C:\Users\Admin\source\repos\InternetShop\LogAndPass.txt"))
            {
                writer.WriteLine(login);
                writer.WriteLine(password);
                writer.Close();
            }
        }
        /// <summary>
        /// проверка на правильность требований логина и пароля
        /// <summary>

        public static void examinationLogin(string login)
        {
            try
            {
                int valueDigit = 0;
                int valueWord = 0;

                if (login.Contains(' '))
                {

                    throw new LogPasException("Логин не должне содержать пробелы!");
                }

                string[] loginSpace = login.Split(' ');

                if (loginSpace.Length == 0)
                {
                    throw new LogPasException("Введите логин!");
                }

                foreach (string digit in loginSpace)
                {

                    for (int i = 0; i < digit.Length; i++)
                    {
                        if (char.IsDigit(digit[i]))
                        {
                            valueDigit++;
                        }


                    }
                }
                if (valueDigit == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    throw new LogPasException("Логин должен содержать хотя бы одну цифру!");
                }

                foreach (string word in loginSpace)
                {

                    for (int i = 0; i < word.Length; i++)
                    {
                        if (char.IsLetter(word[i]))
                        {
                            valueWord++;
                        }


                    }
                }
                if (valueWord == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    throw new LogPasException("Логин должен содержать хотя бы одну букву!");
                }

                
            }
            catch (LogPasException exception)
            {
                Console.WriteLine(exception.Message);
            }

        }
        public static void examinationPassword(string password)
        {
            try
            {
                int valueDigit = 0;
                int valueWord = 0;

                if (password.Contains(' '))
                {

                    throw new LogPasException("Пароль не должне содержать пробелы!");
                }

                string[] passwordSpace = password.Split(' ');

                if (passwordSpace.Length == 0)
                {
                    throw new LogPasException("Введите пароль!");
                }

                foreach (string digit in passwordSpace)
                {

                    for (int i = 0; i < digit.Length; i++)
                    {
                        if (char.IsDigit(digit[i]))
                        {
                            valueDigit++;
                        }


                    }
                }
                if (valueDigit == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    throw new LogPasException("Пароль должен содержать хотя бы одну цифру!");
                }

                foreach (string word in passwordSpace)
                {

                    for (int i = 0; i < word.Length; i++)
                    {
                        if (char.IsLetter(word[i]))
                        {
                            valueWord++;
                        }


                    }
                }
                if (valueWord == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    throw new LogPasException("Пароль должен содержать хотя бы одну букву!");
                }

                ContainsSymbol symbol = new ContainsSymbol(password);
            }
            catch (LogPasException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }




    }
}
