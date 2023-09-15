namespace card_shop_api.Services.Interfaces
{
	public class PokemonResponse
	{
		public int page { get; set; }
		public bool pageSize { get; set; }
		public string count { get; set; }
		public int totalCount { get; set; }
		public List<PokemoCardResponse> data { get; set; }
	}

	public class PokemoCardResponse
	{
		public string id { get; set; }
		public string name { get; set; }
		public Images images { get; set; }
		public Cardmarket cardmarket { get; set; }
	}

	public class Images
	{
		public string small { get; set; }
	}

	public class Cardmarket
	{
		public PokemonPrices prices { get; set; }
	}
	public class PokemonPrices
	{
		public double trendPrice { get; set; }
	}

}

