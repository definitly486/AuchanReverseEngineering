using System;
using Auchan.Common.Ecom.CtmShelves;

namespace Auchan.Common.Recommendations;

internal sealed class RecommendationAnalyticsActionsFactory : IRecommendationAnalyticsActionsFactory
{
	private readonly Func<GenericRecommendationAnalyticsActions> _genericFactory;

	private readonly Func<HorizontalAnalyticsActions> _horizontalFactory;

	private readonly Func<PopularAnalyticsActions> _popularFactory;

	private readonly Func<ProductPlacementsAnalyticsActions> _productPlacementsFactory;

	private readonly Func<CtmShelfAnalyticsActions> _ctmShelfAnalyticsActionsFactory;

	public RecommendationAnalyticsActionsFactory(Func<GenericRecommendationAnalyticsActions> genericFactory, Func<HorizontalAnalyticsActions> horizontalFactory, Func<PopularAnalyticsActions> popularFactory, Func<ProductPlacementsAnalyticsActions> productPlacementsFactory, Func<CtmShelfAnalyticsActions> ctmShelfAnalyticsActionsFactory)
	{
		_genericFactory = genericFactory;
		_horizontalFactory = horizontalFactory;
		_popularFactory = popularFactory;
		_productPlacementsFactory = productPlacementsFactory;
		_ctmShelfAnalyticsActionsFactory = ctmShelfAnalyticsActionsFactory;
	}

	public GenericRecommendationAnalyticsActions GetGenericRecommendationAnalyticsActions()
	{
		return _genericFactory();
	}

	public HorizontalAnalyticsActions GetHorizontalAnalyticsActions()
	{
		return _horizontalFactory();
	}

	public PopularAnalyticsActions GetPopularAnalyticsActions()
	{
		return _popularFactory();
	}

	public ProductPlacementsAnalyticsActions GetProductPlacementsAnalyticsActions()
	{
		return _productPlacementsFactory();
	}

	public IRecommendationAnalyticsActions Get(RecomendationAnalyticActionsTag tag)
	{
		return tag switch
		{
			RecomendationAnalyticActionsTag.Popular => _popularFactory(), 
			RecomendationAnalyticActionsTag.HorizontalShelf => _horizontalFactory(), 
			RecomendationAnalyticActionsTag.ProductPlacements => _productPlacementsFactory(), 
			RecomendationAnalyticActionsTag.CtmShelf => _ctmShelfAnalyticsActionsFactory(), 
			_ => _genericFactory(), 
		};
	}
}
