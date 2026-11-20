using System;
using Android.Content;

namespace Microsoft.Maui.Authentication;

public static class WebAuthenticatorExtensions
{
	private static IPlatformWebAuthenticatorCallback AsPlatformCallback(this IWebAuthenticator webAuthenticator)
	{
		if (!(webAuthenticator is IPlatformWebAuthenticatorCallback result))
		{
			throw new PlatformNotSupportedException("This implementation of IWebAuthenticator does not implement IPlatformWebAuthenticatorCallback.");
		}
		return result;
	}

	public static bool OnResume(this IWebAuthenticator webAuthenticator, Intent intent)
	{
		return webAuthenticator.AsPlatformCallback().OnResumeCallback(intent);
	}
}
