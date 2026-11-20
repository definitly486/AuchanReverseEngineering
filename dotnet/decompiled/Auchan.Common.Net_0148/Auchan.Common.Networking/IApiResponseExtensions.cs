using System;
using System.Collections.Generic;
using System.Linq;
using Refit;

namespace Auchan.Common.Networking;

internal static class IApiResponseExtensions
{
	public static T GetVpnState<T>(this IApiResponse<T> @this) where T : IVpnStateDto
	{
		if (@this.Content != null)
		{
			T content = @this.Content;
			if (@this.Headers.TryGetValues("vpn", out IEnumerable<string> values) && int.TryParse(values.FirstOrDefault(), out var result))
			{
				content.VpnState = (VpnState)result;
			}
			return content;
		}
		if (@this.Error != null)
		{
			throw @this.Error;
		}
		throw new NotImplementedException("dead code");
	}
}
