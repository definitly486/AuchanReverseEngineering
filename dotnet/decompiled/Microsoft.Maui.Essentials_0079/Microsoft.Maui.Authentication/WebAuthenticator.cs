namespace Microsoft.Maui.Authentication;

public static class WebAuthenticator
{
	private static IWebAuthenticator? defaultImplementation;

	public static IWebAuthenticator Default => defaultImplementation ?? (defaultImplementation = new WebAuthenticatorImplementation());
}
