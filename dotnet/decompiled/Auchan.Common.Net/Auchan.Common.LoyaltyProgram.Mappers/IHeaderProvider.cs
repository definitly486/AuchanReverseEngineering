using System.Collections.Generic;

namespace Auchan.Common.LoyaltyProgram.Mappers;

internal interface IHeaderProvider
{
	IDictionary<string, string> GetHeaders(string url);

	bool IsValidHeaders(IDictionary<string, string>? headers);
}
