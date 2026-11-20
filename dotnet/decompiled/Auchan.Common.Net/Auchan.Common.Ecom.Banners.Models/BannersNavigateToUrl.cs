using System;
using AsyncAwaitBestPractices;
using Auchan.Common.Common;
using Auchan.Common.Extensions;
using Auchan.Common.UniversalLinks;
using DryIoc;
using Microsoft.Maui.ApplicationModel;

namespace Auchan.Common.Ecom.Banners.Models;

internal sealed class BannersNavigateToUrl : IBannerNavigateTo
{
	private readonly string _title;

	private readonly Uri _uri;

	private readonly Lazy<IUniversalLinksService> _universalLinksService;

	public BannersNavigateToUrl(string title, Uri uri, Lazy<IUniversalLinksService> universalLinksService)
	{
		_title = title;
		_uri = uri;
		_universalLinksService = universalLinksService;
	}

	public static IBannerNavigateTo Resolve(string title, Uri uri, IResolver resolver)
	{
		return resolver.Resolve<BannersNavigateToUrl>(new object[2] { title, uri });
	}

	public void Activate(IBannerNavigationSupport viewModel)
	{
		if (_universalLinksService.Value.ShouldHandleLink(_uri.ToString()))
		{
			_universalLinksService.Value.HandleLink(_uri.ToString());
		}
		else if (_uri.ShouldOpenInWebView())
		{
			WebViewModel.Parameter subject = new WebViewModel.Parameter
			{
				Title = _title,
				Content = null,
				Url = _uri.ToString()
			};
			viewModel.OpenWebViewCommand.Trigger(subject);
		}
		else
		{
			Browser.OpenAsync(_uri).SafeFireAndForget((Action<Exception>)null, false);
		}
	}
}
