using card_shop_api.Models;
using card_shop_api.Services.Interfaces;
using Newtonsoft.Json;

namespace card_shop_api.Services
{
	public class MagicRequest : IMagicRequest
	{
		private readonly string apiUrl = "https://api.scryfall.com/cards/search?order=set&q=set%3Aafr";

		public async Task<List<T>> GetCards<T>()
		{
			try
			{
				HttpClient httpClient = new HttpClient();
				httpClient.DefaultRequestHeaders.Add("Accept-Language", "pt-br");

				HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

				if (response.IsSuccessStatusCode)
				{
					string jsonString = await response.Content.ReadAsStringAsync();

					MagicResponse json = JsonConvert.DeserializeObject<MagicResponse>(jsonString);

					List<MagicCard> magicCardList =  json.data.ConvertAll(card => new MagicCard(card));
					List<T> cardList = magicCardList.Cast<T>().ToList();
					return cardList;
				}

				return new List<T> { };

			}
			catch (Exception ex)
			{
				Console.WriteLine($"Ocorreu um erro: {ex.Message}");
				throw new Exception("ERRO");
			}
		}
	}
}
