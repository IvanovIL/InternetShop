using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Channels;
using System.Threading.Tasks;
using InternetShop.Exception;
using static InternetShop.Models.Color;

namespace InternetShop.RegistrAndAuthorizat
{
	internal class Registration
	{
		/// <summary>
		/// Создание пароля и логина
		/// </summary>

		public Registration()
		{
			Yellow();
			Console.WriteLine("======================================");
			Console.WriteLine("Создание логина\n" +
				"(Требования к созданию логина:\nОн должен быть не больше 10 символов," +
				"\nне содержать пробелы, содержать хотя бы одну цифру");
			Console.WriteLine("======================================");
			Blue();
			string login = Console.ReadLine();
			examinationLogin(login);
			Console.Clear();

			Yellow();
			Console.WriteLine("======================================");
			Console.WriteLine("Создание пароля\n" +
				"(Требования к созданию пароля:\nОн должен быть не больше 10 символов," +
				"\nне содержать пробелы, содержать хотя бы одну цифру" +
				"\nи включать в себя хотя бы один из символов(!?#*-+=$%)");
			Console.WriteLine("======================================");
			Blue();
			string password = Console.ReadLine();
			examinationPassword(password);

			/// <summary>
			/// Сохранение пароля/логина.имени пользователя в текстовый документ
			/// <summary>


			using (StreamWriter writer = new StreamWriter(@"C:\Users\Admin\source\repos\InternetShop\Login.txt"))
			{
				writer.WriteLine(login);
				writer.Close();
			}
			using (StreamWriter writer = new StreamWriter(@"C:\Users\Admin\source\repos\InternetShop\Password.txt"))
			{
				writer.WriteLine(password);
				writer.Close();
			}

			Green();
			Console.Write("Введите имя: ");
			Blue();
			string Name = Console.ReadLine();

			using (StreamWriter writer = new StreamWriter(@"C:\Users\Admin\source\repos\InternetShop\Name.txt"))
			{
				writer.WriteLine(Name);
				writer.Close();
			}

			Green();
			Console.WriteLine($"Поздравляю {Name} вы успешно зарегистрировались!");
			Console.ReadLine();

			Console.Clear();
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
					Red();
					throw new LogPasException("Логин не должнен содержать пробелы!");
				}

				string[] loginSpace = login.Split(' ');

				if (login == string.Empty)
				{
					Red();
					throw new LogPasException("Введите логин!");

				}
				else if (login.Contains('\n'))
				{
					Red();
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
					Red();
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
					Red();
					throw new LogPasException("Логин должен содержать хотя бы одну букву!");
				}


			}
			catch (LogPasException exception)
			{
				Console.WriteLine(exception.Message);

				Registration registration = new Registration();
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
					Red();
					throw new LogPasException("Пароль не должне содержать пробелы!");
				}

				string[] passwordSpace = password.Split(' ');

				if (passwordSpace.Length == 0)
				{
					Red();
					throw new LogPasException("Введите пароль!");
				}
				else if (password.Contains('\n'))
				{
					Red();
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
					Red();
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
					Red();
					throw new LogPasException("Пароль должен содержать хотя бы одну букву!");
				}

				ContainsSymbol symbol = new ContainsSymbol(password);

			}
			catch (LogPasException exception)
			{

				Console.WriteLine(exception.Message);


				Registration registration = new Registration();
			}
		}




	}
}
