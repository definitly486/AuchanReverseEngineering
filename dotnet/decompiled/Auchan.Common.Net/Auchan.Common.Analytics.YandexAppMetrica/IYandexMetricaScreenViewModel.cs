using Auchan.Common.Base;

namespace Auchan.Common.Analytics.YandexAppMetrica;

public interface IYandexMetricaScreenViewModel : IScreenViewModel
{
	string ScreenNameForBaseEvents { get; }

	string ScreenName { get; }

	string SearchQuery => "";
}
