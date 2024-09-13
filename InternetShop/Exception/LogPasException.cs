using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetShop.Exception
{
    /// <summary>
    /// класс собственного исключения для текста ошибки при создании и вводе пароля/логина
    /// </summary>

    internal class LogPasException : IOException
    {
        private string message;
        public LogPasException(string message) : base(message)
        {
            message = this.message;
        }
    }
}
