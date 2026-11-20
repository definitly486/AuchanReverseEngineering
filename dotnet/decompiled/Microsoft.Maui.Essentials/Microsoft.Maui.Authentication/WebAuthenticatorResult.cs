using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Microsoft.Maui.ApplicationModel;

namespace Microsoft.Maui.Authentication;

public class WebAuthenticatorResult
{
	[CompilerGenerated]
	private readonly Uri _003CCallbackUri_003Ek__BackingField;

	[CompilerGenerated]
	private DateTimeOffset _003CTimestamp_003Ek__BackingField = new DateTimeOffset(DateTime.UtcNow);

	public Dictionary<string, string> Properties { get; } = new Dictionary<string, string>(StringComparer.Ordinal);

	public WebAuthenticatorResult(Uri uri, IWebAuthenticatorResponseDecoder responseDecoder)
	{
		_003CCallbackUri_003Ek__BackingField = uri;
		IDictionary<string, string> dictionary = responseDecoder?.DecodeResponse(uri) ?? WebUtils.ParseQueryString(uri);
		foreach (KeyValuePair<string, string> item in dictionary)
		{
			Properties[item.Key] = item.Value;
		}
	}
}
