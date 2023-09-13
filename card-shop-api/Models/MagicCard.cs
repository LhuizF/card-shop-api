using card_shop_api.Enums;
using card_shop_api.Services.Interfaces;

namespace card_shop_api.Models
{
	public class MagicCard : Card
	{
		public MagicCard(MagicCardResponse magicCard)
		{
			Id = magicCard.id;
			Name = magicCard.name;
			Image = magicCard.image_uris.normal;
			TCG = TCGTypes.Magic;
		}
	}
}
