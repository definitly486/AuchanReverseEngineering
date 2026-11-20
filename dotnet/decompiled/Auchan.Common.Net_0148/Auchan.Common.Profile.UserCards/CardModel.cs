namespace Auchan.Common.Profile.UserCards;

public class CardModel
{
	public int Id { get; }

	public string Pan { get; }

	public CardSchemeType Scheme { get; }

	public CardModel(int id, string pan, CardSchemeType scheme)
	{
		Id = id;
		Pan = pan;
		Scheme = scheme;
	}
}
