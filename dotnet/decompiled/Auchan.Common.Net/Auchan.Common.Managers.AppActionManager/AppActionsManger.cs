using System;
using System.Threading.Tasks;
using Auchan.Common.Common;
using Auchan.Common.PersonalCabinet;
using Auchan.Common.UniversalLinks;
using Microsoft.Maui.ApplicationModel;

namespace Auchan.Common.Managers.AppActionManager;

public sealed class AppActionsManger : IApplicationStateObserver
{
	private const string ACTION_CART = "cart_action_id";

	private const string ACTION_FAVORITES = "favorites_action_id";

	private const string ACTION_SEARCH = "search_action_id";

	private const string ACTIVATE_TAB = "activate_tab";

	private readonly IAppActions _appActions;

	private readonly Lazy<IAppActionIconProvider> _appActionIconProvider;

	private readonly IUserContext _userContext;

	private readonly Lazy<IUniversalLinksService> _linksService;

	public AppActionsManger(IAppActions appActions, Lazy<IAppActionIconProvider> appActionIconProvider, IUserContext userContext, Lazy<IUniversalLinksService> linksService)
	{
		_appActions = appActions;
		_appActionIconProvider = appActionIconProvider;
		_userContext = userContext;
		_linksService = linksService;
		_appActions.AppActionActivated += OnAppActionActivated;
		_userContext.AfterLoggedIn += OnAfterLoggedIn;
		_userContext.AfterLoggedOut += OnAfterLoggedOut;
	}

	public void Start()
	{
		UpdateActionsList();
	}

	private void UpdateActionsList()
	{
		MainThread.BeginInvokeOnMainThread(delegate
		{
			if (_appActions.IsSupported)
			{
				if (_userContext.Authorized)
				{
					_appActions.SetAsync(new global::_003C_003Ez__ReadOnlyArray<AppAction>(new AppAction[3]
					{
						new AppAction("search_action_id", "Поиск", null, _appActionIconProvider.Value.Search),
						new AppAction("favorites_action_id", "Избранное", null, _appActionIconProvider.Value.Favorites),
						new AppAction("cart_action_id", "Корзина", null, _appActionIconProvider.Value.Cart)
					}));
				}
				else
				{
					_appActions.SetAsync(Array.Empty<AppAction>());
				}
			}
		});
	}

	private void OnAppActionActivated(object? sender, AppActionEventArgs e)
	{
		string text = e.AppAction.Id switch
		{
			"search_action_id" => $"auchan://search?{"activate_tab"}={0}", 
			"favorites_action_id" => $"auchan://favorites?{"activate_tab"}={0}", 
			"cart_action_id" => IUniversalLinksService.ActivateCartLink, 
			_ => null, 
		};
		if (text != null && _linksService.Value.ShouldHandleLink(text))
		{
			_linksService.Value.HandleLinkOnStart(text);
		}
	}

	private Task OnAfterLoggedIn()
	{
		UpdateActionsList();
		return Task.CompletedTask;
	}

	private Task OnAfterLoggedOut()
	{
		UpdateActionsList();
		return Task.CompletedTask;
	}
}
