namespace card_shop_api.Services.Interfaces
{
	public class MagicResponse
	{		
		public int total_cards { get; set; }
		public bool has_more { get; set; }
		public string next_page { get; set; }
		public List<MagicCardResponse> data { get; set; }
	}

	public class MagicCardResponse
	{
		public string id { get; set; }
		public string name { get; set; }
		public MagicImageUrls image_uris { get; set; }
		public MagicPrices prices { get; set; }
	}

	public class MagicImageUrls
	{
		public string normal { get; set; }
	}

	public class MagicPrices
	{
		public string usd { get; set; }
	}

}

