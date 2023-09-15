using card_shop_api.Enums;
using card_shop_api.Services.Interfaces;

namespace card_shop_api.Models
{
	public class PokemonCard : Card
	{
		public PokemonCard(PokemoCardResponse pokemonCard)
		{
			Id = pokemonCard.id;
			Name = pokemonCard.name;
			Image = pokemonCard.images.small;
			Price = pokemonCard.cardmarket.prices.trendPrice.ToString();
			TCG = TCGTypes.Pokemon;
		}
	}
}
