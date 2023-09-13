using card_shop_api.Enums;

namespace card_shop_api.Models
{
	public class Card
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public string Image {  get; set; }
		public string? Type { get; set; }
		public TCGTypes TCG { get; set; }

	}
}

