using System.Runtime.CompilerServices;
using Auchan.Common.Analytics.YandexAppMetrica.DataStores;
using Auchan.Common.Base;
using Auchan.Common.Ecom.Cart.ViewModels;
using Auchan.Common.Recommendations.ViewModels;

namespace Auchan.Common.Recommendations;

public class RecommendationsManager : IRecommendationsManager
{
	private readonly ScreenDataStore _screenDataStore;

	private readonly ConditionalWeakTable<ScreenViewModel, RecommendationsViewModel> _savedRecommendations = new ConditionalWeakTable<ScreenViewModel, RecommendationsViewModel>();

	public RecommendationsManager(ScreenDataStore screenDataStore)
	{
		_screenDataStore = screenDataStore;
	}

	public void RefreshRecommendations()
	{
		if (!(_screenDataStore.GetCurrentScreenViewModelType() is ScreenViewModel screenViewModel))
		{
			return;
		}
		RecommendationsViewModel value;
		lock (_savedRecommendations)
		{
			if (!_savedRecommendations.TryGetValue(screenViewModel, out value))
			{
				return;
			}
		}
		if (screenViewModel?.GetType() != typeof(CartScreenViewModel) && value != null)
		{
			value?.Reload();
		}
	}

	public void SaveCurrentRecommendations(RecommendationsViewModel recommendationsViewModel, ScreenViewModel screenViewModel)
	{
		lock (_savedRecommendations)
		{
			_savedRecommendations.AddOrUpdate(screenViewModel, recommendationsViewModel);
		}
	}
}
