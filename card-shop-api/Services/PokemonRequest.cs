using card_shop_api.Models;
using card_shop_api.Services.Interfaces;
using Newtonsoft.Json;

namespace card_shop_api.Services
{
	public class PokemonRequest : IPokemonRequest
	{
		private readonly string apiUrl = "https://api.pokemontcg.io/v2/cards/?q=set.id:sv3";

		public  async Task<List<Card>> GetCards()
		{
			try
			{
				HttpClient httpClient = new HttpClient();

				HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

				if (response.IsSuccessStatusCode)
				{
					string jsonString = await response.Content.ReadAsStringAsync();

					PokemonResponse json = JsonConvert.DeserializeObject<PokemonResponse>(jsonString);

					List<PokemonCard> magicCardList =  json.data.ConvertAll(card => new PokemonCard(card));
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
