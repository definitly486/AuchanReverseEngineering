using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Auchan.Common.Extensions;

public static class HttpExtensions
{
	public static async Task<string?> GetContentAsyncSafe(this HttpResponseMessage httpResponse, CancellationToken cancellationToken = default(CancellationToken))
	{
		try
		{
			return await httpResponse.Content.ReadAsStringAsync(cancellationToken);
		}
		catch (Exception)
		{
			return null;
		}
	}
}
