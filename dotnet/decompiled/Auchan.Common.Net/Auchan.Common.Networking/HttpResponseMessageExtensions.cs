using System;
using System.Collections.Generic;
using System.Net.Http;

namespace Auchan.Common.Networking;

internal static class HttpResponseMessageExtensions
{
	public static HttpResponseMessage Clone(this HttpResponseMessage message, HttpContent content)
	{
		HttpResponseMessage httpResponseMessage = new HttpResponseMessage(message.StatusCode);
		foreach (KeyValuePair<string, IEnumerable<string>> header in message.Content.Headers)
		{
			try
			{
				content.Headers.Add(header.Key, header.Value);
			}
			catch (Exception)
			{
			}
		}
		httpResponseMessage.Content = content;
		httpResponseMessage.ReasonPhrase = message.ReasonPhrase;
		httpResponseMessage.RequestMessage = message.RequestMessage;
		httpResponseMessage.Version = message.Version;
		foreach (KeyValuePair<string, IEnumerable<string>> header2 in message.Headers)
		{
			httpResponseMessage.Headers.Add(header2.Key, header2.Value);
		}
		return httpResponseMessage;
	}
}
