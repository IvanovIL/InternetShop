using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetShop
{
    /// <summary>
    /// Проверяет содержит ли пароль символы из требований
    /// </summary>
    internal class ContainsSymbol
    {
        public ContainsSymbol(string password)
        {
            int value = 0;
            if (password.Contains('!'))
            {
                value++;
            }
            else if (password.Contains('?'))
            {
                value++;
            }
            else if(password.Contains('#'))
            {
                value++;
            }
           else if  (password.Contains('-'))
            {
                value++;
            }
            else if (password.Contains('+'))
            {
                value++;
            }
            else if (password.Contains('='))
            {
                value++;
               
            }
            else if (password.Contains('%'))
            {
                value++;
            }
            else if (password.Contains('$'))
            {
                value++;
            }
            
            if (value == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                throw new LogPasException("Пароль не содержит ни одни из символов(!?#*-+=$%)");
            }
        }
    }
}
