using Auchan.Common.Common;
using Auchan.Common.Extensions;
using Auchan.Common.Recommendations.API;
using Auchan.Common.Recommendations.Models;
using Auchan.Common.Recommendations.ViewModels;
using DryIoc;

namespace Auchan.Common.Recommendations;

internal static class RecommendationDependencyRegistry
{
	public static void Register(IRegistrator registrator)
	{
		registrator.Register<RecomProductItemViewModel>();
		registrator.Register<RocketRetailRequestInterceptor>();
		registrator.Register<ProductRequestInterceptor>();
		registrator.Register<ProductPlacementsRequestInterceptor>();
		registrator.RegisterMany<TrackingUrlProvider>();
		registrator.RegisterMany<ProductPostUrlProvider>();
		registrator.RegisterMany<RecommendationsUrlProvider>();
		registrator.RegisterMany<ProductPlacementUrlProvider>();
		registrator.AddRefitClient<ITrackingApi, RocketRetailRequestInterceptor>();
		registrator.AddRefitClient<IProductPostApi, RocketRetailRequestInterceptor>();
		registrator.AddRefitClient<IRecommendationApi, ProductRequestInterceptor>();
		registrator.AddRefitClient<IProductPlacementsApi, ProductPlacementsRequestInterceptor>();
		registrator.Register<IRecommendationApiService, RecommendationApiService>(Reuse.Singleton);
		registrator.Register<IProductPostApiService, ProductPostApiService>(Reuse.Singleton);
		registrator.Register<ITrackingApiService, TrackingApiService>(Reuse.Singleton);
		registrator.Register<IRecommendationRequestExecutor, RecommendationRequestExecutor>(Reuse.Singleton);
		registrator.Register<IRecommendationService, RecommendationService>(Reuse.Singleton);
		registrator.Register<IRecommendationsRepository, RecommendationsRepository>(Reuse.Singleton);
		registrator.Register<IProductPostService, ProductPostService>(Reuse.Singleton);
		registrator.Register<ITrackingService, TrackingService>(Reuse.Singleton);
		registrator.Register<IRecommendationsManager, RecommendationsManager>(Reuse.Singleton);
		registrator.Register<IApplicationStateObserver, RecommendationsApplicationObserver>(Reuse.Singleton);
		registrator.Register<RecommendationsApplicationObserver>(Reuse.Singleton);
		registrator.Register<RecommendationsTrackingRepository>(Reuse.Singleton);
		registrator.Register<IRecommendationsGimaIdCache, RecommendationsGimaIdCache>(Reuse.Singleton);
		registrator.Register<IRecommendationAnalyticsActionsFactory, RecommendationAnalyticsActionsFactory>(Reuse.Singleton);
		registrator.Register<GenericRecommendationAnalyticsActions>(Reuse.Singleton);
		registrator.Register<PopularAnalyticsActions>(Reuse.Singleton);
		registrator.Register<HorizontalAnalyticsActions>(Reuse.Singleton);
		registrator.Register<ProductPlacementsAnalyticsActions>(Reuse.Singleton);
		registrator.Register<RecommendationBuilder>();
		registrator.Register<PopularEndlessAlgorithm>();
		registrator.Register<PersonalViewedEndlessAlgorithm>();
		registrator.Register<RelatedWithPopularityPenaltyAlgorithm>();
		registrator.Register<RelatedAlgorithm>();
		registrator.Register<AlternativesAlgorithm>();
		registrator.Register<AnalogsOutOfStockProductsAlgorithm>();
		registrator.Register<PopularInCategoryByPathAlgorithm>();
		registrator.Register<SaleByPopularInCategoryByPathAlgorithm>();
		registrator.Register<SearchAlgorithm>();
		registrator.Register<PersonalAlgorithm>();
		registrator.Register<LatestByCategoryPathAlgorithm>();
		registrator.Register<LatestInInterestedCategoriesAlgorithm>();
		registrator.Register<NoveltyAlgorithm>();
		registrator.Register<PersonalOrderedAlgorithm>();
		registrator.Register<PersonalViewedAlgorithm>();
		registrator.Register<AnyPlacementAlgorithm>();
		registrator.Register<ProductGroupPlacementsAlgorithm>();
		registrator.Register<ProductPlacementsAndRelatedAlgorithm>();
		registrator.Register<ProductPlacementsAndCrossSellForLargeBasketsAlgorithm>();
		registrator.Register<CategoryPlacementsAndPopularsInCategoryAlgorithm>();
		registrator.Register<PersonalCompositeForCategoryByCategoryPathAlgorithm>();
		registrator.Register<PopularByInterestedPropertiesByCategoryAlgorithm>();
	}
}
