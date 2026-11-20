using Auchan.Common.PersonalCabinet.DomainModels;

namespace Auchan.Common.PersonalCabinet;

public class TokenModel
{
	public string Token { get; }

	public TokenLevel TokenLevel { get; }

	public TokenModel(string token, TokenLevel tokenLevel)
	{
		Token = token;
		TokenLevel = tokenLevel;
	}

	public static implicit operator string(TokenModel t)
	{
		return t.Token;
	}
}
