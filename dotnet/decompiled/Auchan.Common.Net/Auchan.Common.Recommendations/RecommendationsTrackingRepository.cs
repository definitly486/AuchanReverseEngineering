using System.Collections.Generic;
using System.Threading.Tasks;
using Auchan.Common.Analytics;
using Auchan.Common.Ecom.ProducModels.ViewModels;
using Auchan.Common.PersonalCabinet;

namespace Auchan.Common.Recommendations;

public class RecommendationsTrackingRepository
{
	private readonly IUserContext _userContext;

	private HashSet<string> _trackedBlocks = new HashSet<string>();

	private HashSet<string> _trackedProductDetails = new HashSet<string>();

	public RecommendationsTrackingRepository(IUserContext userContext)
	{
		_userContext = userContext;
		_userContext.AfterLoggedOut += delegate
		{
			_trackedBlocks.Clear();
			_trackedProductDetails.Clear();
			return Task.CompletedTask;
		};
	}

	public void RecommendationBlockViewed(string blockId)
	{
		if (!_trackedBlocks.Contains(blockId))
		{
			AppAnalytics.RocketRetail.RecommendationBlockViewed(blockId);
			_trackedBlocks.Add(blockId);
		}
	}

	public void RecommendationTap(ProductItemViewModel itemViewModel)
	{
		if (!itemViewModel.RecomAnalytics.IsEmpty)
		{
			string transationId = GetTransationId(itemViewModel);
			if (!_trackedProductDetails.Contains(transationId))
			{
				AppAnalytics.RocketRetail.RecommendationTap(itemViewModel);
				_trackedProductDetails.Add(transationId);
			}
		}
	}

	public void AddedToCart(ProductItemViewModel itemViewModel)
	{
		if (!itemViewModel.RecomAnalytics.IsEmpty)
		{
			AppAnalytics.RocketRetail.RecommendationAddedToBasket(itemViewModel);
		}
	}

	private string GetTransationId(ProductItemViewModel itemViewModel)
	{
		return itemViewModel.Product.Code + itemViewModel.RecomAnalytics.BlockId;
	}
}
