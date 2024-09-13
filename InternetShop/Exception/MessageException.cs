using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace InternetShop.Exception
{
	
	public class MessageException : IOException
	{ 
		private readonly string message;
		public MessageException(string message) : base(message)
		{
			this.message = message;
		}
	}
}
