using System;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using Java.Net;

namespace Xamarin.Android.Net;

internal sealed class AuthModuleBasic : IAndroidAuthenticationModule
{
	[CompilerGenerated]
	private readonly bool _003CCanPreAuthenticate_003Ek__BackingField = true;

	public AuthenticationScheme Scheme { get; } = AuthenticationScheme.Basic;

	public string AuthenticationType { get; } = "Basic";

	public Authorization? Authenticate(string challenge, HttpURLConnection request, ICredentials credentials)
	{
		string text = challenge?.Trim();
		if (credentials == null || string.IsNullOrEmpty(text))
		{
			return null;
		}
		if (text != null && text.IndexOf("basic", StringComparison.OrdinalIgnoreCase) == -1)
		{
			return null;
		}
		return InternalAuthenticate(request, credentials);
	}

	private Authorization? InternalAuthenticate(HttpURLConnection request, ICredentials credentials)
	{
		if (request == null || credentials == null)
		{
			return null;
		}
		NetworkCredential credential = credentials.GetCredential(new Uri(request.URL?.ToString()), AuthenticationType.ToLowerInvariant());
		if (credential == null)
		{
			return null;
		}
		if (string.IsNullOrEmpty(credential.UserName))
		{
			return null;
		}
		string text = credential.Domain?.Trim();
		string text2 = string.Empty;
		if (!string.IsNullOrEmpty(text))
		{
			text2 = text + "\\";
		}
		text2 = text2 + credential.UserName + ":" + credential.Password;
		return new Authorization(AuthenticationType + " " + Convert.ToBase64String(Encoding.ASCII.GetBytes(text2)));
	}
}
