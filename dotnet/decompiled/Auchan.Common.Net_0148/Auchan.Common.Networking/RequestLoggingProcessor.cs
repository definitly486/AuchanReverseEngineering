using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Auchan.Common.Extensions;
using Auchan.Common.Logs;

namespace Auchan.Common.Networking;

public class RequestLoggingProcessor
{
	private class HttpMessage
	{
		public enum MessageType
		{
			Request,
			Response
		}

		public HttpContent? Content { get; }

		public HttpHeaders Headers { get; }

		public Uri RequestUri { get; }

		public HttpMethod Method { get; }

		public MessageType Type { get; }

		public HttpResponseMessage? Response { get; }

		public HttpMessage(HttpRequestMessage request)
		{
			Method = request.Method;
			RequestUri = request.RequestUri ?? throw new NullReferenceException("RequestUri");
			Headers = request.Headers;
			Content = request.Content;
			Type = MessageType.Request;
		}

		public HttpMessage(HttpResponseMessage response)
		{
			Method = response.RequestMessage?.Method ?? throw new NullReferenceException("RequestMessage");
			RequestUri = response.RequestMessage?.RequestUri ?? throw new NullReferenceException("RequestMessage");
			Headers = response.Headers;
			Content = response.Content;
			Type = MessageType.Response;
			Response = response;
		}
	}

	private static class HttpMessageConverter
	{
		private static readonly string[] s_textBasedContentTypes = new string[6] { "html", "text", "xml", "json", "txt", "x-www-form-urlencoded" };

		public static string GetMessageAsLogEventName(Guid id, HttpMessage message, HttpMessage.MessageType? specifiedType = null)
		{
			string pathAndQuery = message.RequestUri.PathAndQuery;
			return $"{specifiedType ?? message.Type} [{id}] {message.Method} {pathAndQuery}";
		}

		public static async Task<string> GetMessageAsString(HttpMessage message)
		{
			if (message.Content != null)
			{
				IEnumerable<string> second = await GetContent(message, message.Content);
				string obj = ((message.Response != null) ? $"{message.Response.StatusCode} {message.Response.StatusCode}\n" : "");
				IEnumerable<string> values = message.Content.Headers.Select<KeyValuePair<string, IEnumerable<string>>, string>((KeyValuePair<string, IEnumerable<string>> h) => h.Key + ": " + string.Join(", ", h.Value)).Concat(second);
				return obj + string.Join("\n", values);
			}
			return string.Empty;
		}

		private static async Task<IEnumerable<string>> GetContent(HttpMessage message, HttpContent content)
		{
			if (message.Content is StringContent || IsTextBasedContentType(message.Headers) || IsTextBasedContentType(content.Headers))
			{
				string str = await content.ReadAsStringAsync();
				return new string[2]
				{
					"Content:",
					string.Join("", Regex.Unescape(str))
				};
			}
			return Enumerable.Empty<string>();
			static bool IsTextBasedContentType(HttpHeaders headers)
			{
				if (headers.TryGetValues("Content-Type", out IEnumerable<string> values))
				{
					string toMatch = string.Join(" ", values ?? Array.Empty<string>());
					return s_textBasedContentTypes.Any((string t) => toMatch.ContainsIgnoreCase(t));
				}
				return false;
			}
		}
	}

	private readonly ILogService _logService;

	public RequestLoggingProcessor(ILogService logService)
	{
		_logService = logService;
	}

	public async Task<HttpResponseMessage> SendRequestWithLogging(Func<HttpRequestMessage, Task<HttpResponseMessage>> sendRequestFunc, HttpRequestMessage request)
	{
		Guid id = Guid.NewGuid();
		await Log(new HttpMessage(request), id, _logService);
		try
		{
			HttpResponseMessage response = await sendRequestFunc(request);
			await Log(new HttpMessage(response), id, _logService);
			return response;
		}
		catch (Exception ex)
		{
			_logService.LogError(HttpMessageConverter.GetMessageAsLogEventName(id, new HttpMessage(request), HttpMessage.MessageType.Response) ?? "", ex.ToString(), LogType.ApiRequest, SystemType.MobileApp);
			throw;
		}
	}

	private static async Task Log(HttpMessage message, Guid id, ILogService logService)
	{
		string messageAsLogEventName = HttpMessageConverter.GetMessageAsLogEventName(id, message);
		logService.LogInfo(messageAsLogEventName, await HttpMessageConverter.GetMessageAsString(message), LogType.ApiRequest, SystemType.MobileApp);
	}
}
