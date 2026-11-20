using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Refit;

public class DefaultApiExceptionFactory(RefitSettings refitSettings)
{
	private static readonly Task<Exception?> NullTask = Task.FromResult<Exception>(null);

	public Task<Exception?> CreateAsync(HttpResponseMessage responseMessage)
	{
		if (responseMessage != null && !responseMessage.IsSuccessStatusCode)
		{
			return CreateExceptionAsync(responseMessage, refitSettings);
		}
		return NullTask;
	}

	private static async Task<Exception> CreateExceptionAsync(HttpResponseMessage responseMessage, RefitSettings refitSettings)
	{
		HttpRequestMessage? requestMessage = responseMessage.RequestMessage;
		HttpMethod method = requestMessage.Method;
		return await ApiException.Create(requestMessage, method, responseMessage, refitSettings).ConfigureAwait(continueOnCapturedContext: false);
	}
}
