using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace Auchan.Common.UniversalLinks;

public interface IUniversalLinksService
{
	const string ACTIVATE_TAB_PARAMETER = "activate_tab";

	const string MLINK_DEEPLINK_HOST = "mlink.auchan.ru";

	const string DEEPLINK_HOST = "auchan.ru";

	const string WWW_DEEPLINK_HOST = "www.auchan.ru";

	const string APPMETRICA_DEEPLINK_HOST = "4431094.redirect.appmetrica.yandex.com";

	const string AUCHAN_SCHEME = "auchan";

	const string VK_ID = "54269263";

	const string VK_AUTH_SCHEME = "vk54269263";

	const string VK_AUTH_HOST = "vk.com";

	bool IsPreloadingSharedCart { get; set; }

	bool IsNavigating { get; }

	TaskCompletionSource? NavigationTaskSource { get; }

	static string ActivateCatalogLink => "auchan://categories?activate_tab=Catalog";

	static string ActivateHomeLink => "auchan://home?activate_tab=Home";

	static string ActivateCartLink => $"{"auchan"}://cart?{"activate_tab"}={2}";

	event EventHandler<UniversalLinkServiceLinkEvent> WeakOnLinkReceived;

	Task HandleLink(string link);

	Task HandleLinkOnStart(string link, UniversalLinkSource source = UniversalLinkSource.Unknown);

	bool ShouldHandleLink(string link);

	bool ShouldHandlePromoLink(string link);

	bool ShouldOpenInBrowser(string link);

	[return: NotNullIfNotNull("uri")]
	string? ConvertToProductionLink(string? uri);
}
