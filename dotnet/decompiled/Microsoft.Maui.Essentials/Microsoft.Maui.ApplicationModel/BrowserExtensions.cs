using System;
using System.Threading.Tasks;

namespace Microsoft.Maui.ApplicationModel;

public static class BrowserExtensions
{
	public static Task<bool> OpenAsync(this IBrowser browser, string uri)
	{
		return browser.OpenAsync(new Uri(uri), new BrowserLaunchOptions());
	}

	public static Task<bool> OpenAsync(this IBrowser browser, string uri, BrowserLaunchOptions options)
	{
		return browser.OpenAsync(new Uri(uri), options);
	}

	public static Task<bool> OpenAsync(this IBrowser browser, Uri uri)
	{
		return browser.OpenAsync(uri, new BrowserLaunchOptions());
	}
}
