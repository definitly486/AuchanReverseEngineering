using System;
using System.Threading.Tasks;

namespace Microsoft.Maui.ApplicationModel;

public static class Browser
{
	private static IBrowser? defaultImplementation;

	public static IBrowser Default => defaultImplementation ?? (defaultImplementation = new BrowserImplementation());

	public static Task<bool> OpenAsync(string uri)
	{
		return Default.OpenAsync(uri);
	}

	public static Task<bool> OpenAsync(string uri, BrowserLaunchOptions options)
	{
		return Default.OpenAsync(uri, options);
	}

	public static Task<bool> OpenAsync(Uri uri)
	{
		return Default.OpenAsync(uri);
	}
}
