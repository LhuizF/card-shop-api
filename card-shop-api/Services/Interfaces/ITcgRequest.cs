using card_shop_api.Models;

namespace card_shop_api.Services.Interfaces
{
	public interface ITcgRequest
	{
		Task<List<Card>> GetCards();
	}
}
