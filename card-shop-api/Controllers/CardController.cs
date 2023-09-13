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

		private readonly ITcgRequest _tcgRequest;

		public CardController(ITcgRequest tcgRequest)
		{
			_tcgRequest = tcgRequest;
		}

		[HttpGet]
		public async Task<ActionResult<List<Card>>> GetCard()
		{
			List<Card> cards = await _tcgRequest.GetCards();
			Console.WriteLine(cards.Count);
			return Ok(cards);
		}
	}
}
