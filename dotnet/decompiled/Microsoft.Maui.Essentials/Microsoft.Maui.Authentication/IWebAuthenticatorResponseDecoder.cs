using System;
using System.Collections.Generic;

namespace Microsoft.Maui.Authentication;

public interface IWebAuthenticatorResponseDecoder
{
	IDictionary<string, string>? DecodeResponse(Uri uri);
}
