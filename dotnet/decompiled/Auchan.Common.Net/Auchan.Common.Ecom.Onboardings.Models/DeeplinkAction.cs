using System;
using System.Threading.Tasks;
using Auchan.Common.UniversalLinks;
using DryIoc;
using Microsoft.Maui.ApplicationModel;

namespace Auchan.Common.Ecom.Onboardings.Models;

internal sealed class DeeplinkAction : IOnboardingAction
{
	private readonly string _url;

	private readonly Lazy<IUniversalLinksService> _universalLinksService;

	public string Text { get; }

	public DeeplinkAction(IResolver resolver, string? text, string url)
	{
		_url = url;
		_universalLinksService = resolver.Resolve<Lazy<IUniversalLinksService>>();
		Text = text ?? "";
	}

	public async Task ActivateAsync(ShowAt showAt, IOnboardingActionSupport actionSupport)
	{
		if (showAt == ShowAt.BeforeAuth)
		{
			actionSupport.NextCommand.Trigger();
		}
		else if (_universalLinksService.Value.ShouldHandleLink(_url))
		{
			await _universalLinksService.Value.HandleLink(_url);
		}
		else
		{
			await Browser.OpenAsync(_url);
		}
	}
}
