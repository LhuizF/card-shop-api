using card_shop_api.Models;
using card_shop_api.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace card_shop_api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CardController : ControllerBase
	{
		private readonly IMagicRequest _magicRequest;
		private readonly IPokemonRequest _pokemonRequest;

		public CardController(IMagicRequest magicRequest, IPokemonRequest pokemonRequest)
		{
			_magicRequest = magicRequest;
			_pokemonRequest = pokemonRequest;
		}

		[HttpGet("/magic")]
		public async Task<ActionResult<List<Card>>> GetMagicCards()
		{
			List<Card> cards = await _magicRequest.GetCards<Card>();
			Console.WriteLine(cards.Count);
			return Ok(cards);
		}

		[HttpGet("/pokemon")]
		public async Task<ActionResult<List<PokemonCard>>> GetPokemonCards()
		{
			List<PokemonCard> cards = await _pokemonRequest.GetCards<PokemonCard>();
			Console.WriteLine(cards.Count);
			return Ok(cards);
		}

		[HttpGet("/multi-card")]
		public async Task<ActionResult<MultiCard>> GetMiltiCards()
		{
			List<PokemonCard> pokemonCards = await _pokemonRequest.GetCards<PokemonCard>();
			List<MagicCard> magicCards = await _magicRequest.GetCards<MagicCard>();

			MultiCard multiCard = new MultiCard
			{
				pokemonCards = pokemonCards,
				magicCard = magicCards
			};

			return Ok(multiCard);
		}

	}
}
