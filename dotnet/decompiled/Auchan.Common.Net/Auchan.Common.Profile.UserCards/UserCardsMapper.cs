using System.Collections.Generic;
using System.Linq;
using Auchan.Common.Profile.UserCards.DTO;

namespace Auchan.Common.Profile.UserCards;

public static class UserCardsMapper
{
	public static List<CardModel> ToModel(this TokenListResponseDto dto)
	{
		if (dto.Cards == null)
		{
			return new List<CardModel>();
		}
		return dto.Cards.Select((CardDto x) => new CardModel(x.Id, x.Pan, x.Scheme)).ToList();
	}
}
