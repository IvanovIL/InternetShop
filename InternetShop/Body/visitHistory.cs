using Newtonsoft.Json;

namespace InternetShop.Body
{
	public class visitHistory
	{
		public visitHistory(string history)
		{
			List<string> History = new List<string>();
			var visitHistory = File.ReadAllText(@"C:\Users\Admin\source\repos\InternetShop\visitHistory.json");
			History = JsonConvert.DeserializeObject<List<string>>(visitHistory);

			for (int i = -1; i < History.Count; i++)
			{
				if (History.Count < 10)
				{
					History.Add(history);
					var visHistory = JsonConvert.SerializeObject(History);
					File.WriteAllText(@"C:\Users\Admin\source\repos\InternetShop\visitHistory.json", visHistory);
					break;
					
				}
				else
				{
					History.Clear();
					var visHistory = JsonConvert.SerializeObject(History);
					File.WriteAllText(@"C:\Users\Admin\source\repos\InternetShop\visitHistory.json", visHistory);
					break;
				}
			}
		}

		public visitHistory()
		{
			List<string> History = new List<string>();
			var visitHistory = File.ReadAllText(@"C:\Users\Admin\source\repos\InternetShop\visitHistory.json");
			History = JsonConvert.DeserializeObject<List<string>>(visitHistory);
			for (int i = 0; i < History.Count; i++)
			{
				Console.WriteLine($"{History[i]}");
			}

			Console.ReadLine();
		}


	}
}
