using System;
using System.Threading.Tasks;
using Auchan.Common.Common;
using Auchan.Common.UniversalLinks;
using DryIoc;

namespace Auchan.Common.Ecom.Onboardings.Models;

internal sealed class WebViewUrlAction : IOnboardingAction
{
	private readonly string _url;

	private readonly Lazy<IUniversalLinksService> _universalLinksService;

	public string Text { get; }

	public WebViewUrlAction(IResolver resolver, string? text, string url)
	{
		_url = url;
		_universalLinksService = resolver.Resolve<Lazy<IUniversalLinksService>>();
		Text = text ?? "";
	}

	public async Task ActivateAsync(ShowAt showAt, IOnboardingActionSupport actionSupport)
	{
		if (showAt != ShowAt.BeforeAuth)
		{
			if (_universalLinksService.Value.ShouldHandlePromoLink(_url))
			{
				await _universalLinksService.Value.HandleLink(_url);
				return;
			}
			actionSupport.WebCommand.Trigger(new WebViewModel.Parameter
			{
				Url = _url
			});
		}
	}
}
