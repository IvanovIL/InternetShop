using InternetShop.Models;
using Newtonsoft.Json;


namespace ConsoleShop.Body
{
	public class historyOrder
	{
		/// <summary>
		/// Оплаченные заказы пользователя
		/// </summary>
		public historyOrder()
		{
			List<Product> userOrder = new List<Product>();
			var historyOrder = File.ReadAllText(@"C:\Users\Admin\source\repos\InternetShop\HistoryOrder.json");
			userOrder = JsonConvert.DeserializeObject<List<Product>>(historyOrder);

			Console.WriteLine("Ваши заказы: ");
			for (int i = 0; i < userOrder.Count; i++)
			{
				Console.WriteLine($"{userOrder[i].Name} {userOrder[i].Amount} * {userOrder[i].Price} = {userOrder[i].Amount * userOrder[i].Price} рублей");
			}
		}
		public historyOrder(string name, int amount, decimal price)
		{
			List<Product> userOrder = new List<Product>();
			var historyOrder = File.ReadAllText(@"C:\Users\Admin\source\repos\InternetShop\HistoryOrder.json");
			userOrder = JsonConvert.DeserializeObject<List<Product>>(historyOrder);

			userOrder.Add(new Product
			{
				Name = name,
				Amount = amount,
				Price = price
			}
			);
			

			var historyOrders = JsonConvert.SerializeObject(userOrder);
			File.WriteAllText(@"C:\Users\Admin\source\repos\InternetShop\HistoryOrder.json", historyOrders);
		}
	}

	

}
