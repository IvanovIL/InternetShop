using Newtonsoft.Json;

namespace InternetShop.Body
{
	public class historyOrder
	{
		public historyOrder(string history)
		{
			List<string> History = new List<string>();
			var jsonHistoryOrd = File.ReadAllText(@"C:\Users\Admin\source\repos\InternetShop\HistoryOrder.json");
			History = JsonConvert.DeserializeObject<List<string>>(jsonHistoryOrd);

			for (int i = 0; i < History.Count; i++)
			{
				History.Add(history); 
				var jsonHistoryOrder = JsonConvert.SerializeObject(History);
				File.WriteAllText(@"C:\Users\Admin\source\repos\InternetShop\HistoryOrder.json", jsonHistoryOrder);
				break;
			}
		}

		public historyOrder()
		{
			List<string> History = new List<string>();
			var jsonHistoryOrd = File.ReadAllText(@"C:\Users\Admin\source\repos\InternetShop\HistoryOrder.json");
			History = JsonConvert.DeserializeObject<List<string>>(jsonHistoryOrd);
			for(int i = 0; i < History.Count; i++)
			{
				Console.WriteLine($"{History[i]}");
            }
			Console.ReadLine();	
		}


	}
}
