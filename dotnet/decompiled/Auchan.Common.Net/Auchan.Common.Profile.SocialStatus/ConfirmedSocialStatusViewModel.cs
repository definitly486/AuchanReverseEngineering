using System;
using System.Reactive;
using System.Reactive.Subjects;
using System.Threading.Tasks;
using System.Web;
using Auchan.Common.AdminTool;
using Auchan.Common.Analytics;
using Auchan.Common.Base;
using Auchan.Common.Extensions;
using Auchan.Common.Navigation;
using Auchan.Common.PersonalCabinet;

namespace Auchan.Common.Profile.SocialStatus;

public class ConfirmedSocialStatusViewModel : ScreenViewModel
{
	private readonly Subject<Unit> _closeCommand = new Subject<Unit>();

	private readonly IUserContext _userContext;

	private readonly UrlNavigationHandler _urlNavigationHandler;

	public string Title => "У вас уже подтверждён социальный статус карты АШАН";

	public string Message { get; }

	public string ToolbarTitle => "Привет, " + (_userContext.Profile?.FirstName ?? "пользователь") + "!";

	public string ButtonText => "Понятно";

	protected override string ScreenName => "social_status_confirmed";

	public IObservable<Unit> OnCloseCommand => _closeCommand.Debounce();

	public ConfirmedSocialStatusViewModel(IUserContext userContext, IAdminContext adminContext, UrlNavigationHandler urlNavigationHandler)
	{
		_userContext = userContext;
		_urlNavigationHandler = urlNavigationHandler;
		Message = HttpUtility.HtmlDecode(adminContext.AppConfig?.LoyaltyConfig?.SocialStatusConfirmedText ?? string.Empty);
	}

	public void OnButtonCLick()
	{
		_closeCommand.OnNext(Unit.Default);
	}

	public void HandleLink(string url)
	{
		if (_urlNavigationHandler.HandleUrl(url))
		{
			_closeCommand.OnNext(Unit.Default);
		}
	}

	protected override async Task OnResumed()
	{
		await base.OnResumed();
		AppAnalytics.AppMetrica.SocialStatusConfirmed();
	}
}
