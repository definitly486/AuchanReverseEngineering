using Auchan.Common.Managers.AppActionManager;

namespace Auchan.Android.Managers.AppActionManager;

internal sealed class AppActionIconProvider : IAppActionIconProvider
{
	public string Cart => "app_action_cart";

	public string Favorites => "app_action_favorites";

	public string Search => "app_action_search";
}
