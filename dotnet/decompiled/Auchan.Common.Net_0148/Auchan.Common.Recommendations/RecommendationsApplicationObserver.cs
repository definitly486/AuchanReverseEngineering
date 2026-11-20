using Auchan.Common.Common;

namespace Auchan.Common.Recommendations;

public class RecommendationsApplicationObserver : IApplicationStateObserver
{
	private readonly IRecommendationsManager _recommendationsManager;

	private bool _inBackground;

	public RecommendationsApplicationObserver(IRecommendationsManager recommendationsManager)
	{
		_recommendationsManager = recommendationsManager;
	}

	public void OnResumed()
	{
		if (_inBackground)
		{
			_recommendationsManager.RefreshRecommendations();
			_inBackground = false;
		}
	}

	public void OnPaused()
	{
		_inBackground = true;
	}
}
