using card_shop_api.Models;
using card_shop_api.Services.Interfaces;
using Newtonsoft.Json;

namespace card_shop_api.Services
{
	public class MagicRequest : ITcgRequest
	{
		private readonly string apiUrl = "https://api.scryfall.com/cards/search?order=set&q=set%3Aafr";

		async	Task<List<Card>> ITcgRequest.GetCards()
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
					List<Card> cardList = magicCardList.Cast<Card>().ToList();
					return cardList;
				}

				return new List<Card> { };

			}
			catch (Exception ex)
			{
				Console.WriteLine($"Ocorreu um erro: {ex.Message}");
				throw new Exception("ERRO");
			}
		}
	}
}
