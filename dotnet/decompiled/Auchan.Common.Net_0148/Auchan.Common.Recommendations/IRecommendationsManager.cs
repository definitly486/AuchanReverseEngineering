using Auchan.Common.Base;
using Auchan.Common.Recommendations.ViewModels;

namespace Auchan.Common.Recommendations;

public interface IRecommendationsManager
{
	void RefreshRecommendations();

	void SaveCurrentRecommendations(RecommendationsViewModel recommendationsViewModel, ScreenViewModel screenViewModel);
}
