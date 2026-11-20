using System;
using Auchan.Common.Analytics.YandexAppMetrica;
using Auchan.Common.UniversalLinks;
using Microsoft.Maui.ApplicationModel;

namespace Auchan.Common.Ecom.CtmShelves.Models;

public sealed class CtmLink
{
	private readonly string? _link;

	private readonly IUniversalLinksService _universalLinksService;

	private readonly AppMetrica _appMetrica;

	public bool IsValid => !string.IsNullOrEmpty(_link);

	public CtmLink(string? link, IUniversalLinksService universalLinksService, AppMetrica appMetrica)
	{
		_link = universalLinksService.ConvertToProductionLink(link);
		_universalLinksService = universalLinksService;
		_appMetrica = appMetrica;
	}

	public void Activate(Shelf shelf)
	{
		if (string.IsNullOrEmpty(_link))
		{
			return;
		}
		_appMetrica.TrackCtmShelfMonetization("seeAll", shelf);
		if (_universalLinksService.ShouldHandleLink(_link))
		{
			_universalLinksService.HandleLink(_link);
			return;
		}
		try
		{
			Browser.OpenAsync(_link);
		}
		catch (Exception)
		{
		}
	}
}
