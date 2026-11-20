using System;
using AsyncAwaitBestPractices;
using Auchan.Common.UniversalLinks;
using Microsoft.Maui.ApplicationModel;

namespace Auchan.Common.Navigation;

public class UrlNavigationHandler
{
	private readonly IUniversalLinksService _universalLinksService;

	private readonly BrowserLaunchOptions _browserLaunchOptions;

	public UrlNavigationHandler(IUniversalLinksService universalLinksService)
	{
		_universalLinksService = universalLinksService;
		_browserLaunchOptions = new BrowserLaunchOptions
		{
			LaunchMode = BrowserLaunchMode.External
		};
	}

	public bool HandleUrl(string url)
	{
		if (_universalLinksService.ShouldHandleLink(url))
		{
			_universalLinksService.HandleLink(url).SafeFireAndForget((Action<Exception>)null, false);
			return true;
		}
		Browser.OpenAsync(url, _browserLaunchOptions).SafeFireAndForget((Action<Exception>)null, false);
		return false;
	}
}
