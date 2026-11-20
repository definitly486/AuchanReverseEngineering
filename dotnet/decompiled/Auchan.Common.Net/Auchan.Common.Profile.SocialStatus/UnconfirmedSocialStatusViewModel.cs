using System;
using System.Reactive;
using System.Reactive.Subjects;
using System.Threading.Tasks;
using Auchan.Common.AdminTool;
using Auchan.Common.Analytics;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Extensions;
using Auchan.Common.UniversalLinks;

namespace Auchan.Common.Profile.SocialStatus;

public class UnconfirmedSocialStatusViewModel : ScreenViewModel
{
	private readonly Subject<Unit> _closeCommand = new Subject<Unit>();

	private readonly IUniversalLinksService _universalLinksService;

	public string ToolbarTitle => "Привилегии для карт АШАН с социальным статусом:";

	public string ButtonText => "Понятно";

	public string Content { get; }

	public string CloseText => "Закрыть";

	protected override string ScreenName => "social_status_not_confirmed";

	public IObservable<Unit> OnCloseCommand => _closeCommand.Debounce();

	public UnconfirmedSocialStatusViewModel(IAdminContext adminContext, IUniversalLinksService universalLinksService)
	{
		_universalLinksService = universalLinksService;
		string content = adminContext.AppConfig?.LoyaltyConfig?.SocialStatusUnconfirmedText ?? string.Empty;
		Content = HtmlConverter.WrapIntoHtml(content);
	}

	public void OnButtonClick()
	{
		_closeCommand.OnNext(Unit.Default);
	}

	public bool OverrideUrlHandlingIfNeccesary(string url)
	{
		if (_universalLinksService.ShouldHandleLink(url))
		{
			_universalLinksService.HandleLink(url);
			_closeCommand.OnNext(Unit.Default);
			return true;
		}
		return false;
	}

	protected override async Task OnResumed()
	{
		await base.OnResumed();
		AppAnalytics.AppMetrica.SocialStatusNotConfirmed();
	}
}
