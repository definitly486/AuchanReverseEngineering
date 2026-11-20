using Auchan.Common.Profile.UserCards;

namespace Auchan.Android.Profile.UserCards;

public static class UserCardsConverter
{
	public static int FromSchemeToResourceId(CardSchemeType scheme)
	{
		switch (scheme)
		{
		case CardSchemeType.VISA:
		case CardSchemeType.PLUS:
			return 2131231406;
		case CardSchemeType.MCRD:
		case CardSchemeType.ECRD:
		case CardSchemeType.CIRR:
		case CardSchemeType.MAES:
		case CardSchemeType.CIMA:
			return 2131231238;
		case CardSchemeType.MIRC:
			return 2131231242;
		default:
			return 0;
		}
	}
}
