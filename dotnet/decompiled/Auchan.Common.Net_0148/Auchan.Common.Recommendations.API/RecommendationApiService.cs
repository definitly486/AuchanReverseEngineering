using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Recommendations.API.DTO;
using Auchan.Common.Recommendations.Models;
using CSharpFunctionalExtensions;
using Newtonsoft.Json;

namespace Auchan.Common.Recommendations.API;

internal sealed class RecommendationApiService : IRecommendationApiService
{
	private readonly IRecommendationApi _api;

	private readonly IProductPlacementsApi _productPlacementsApi;

	private readonly IRecommendationRequestExecutor _requestExecutor;

	public RecommendationApiService(IRecommendationApi api, IProductPlacementsApi productPlacementsApi, IRecommendationRequestExecutor requestExecutor)
	{
		_api = api;
		_productPlacementsApi = productPlacementsApi;
		_requestExecutor = requestExecutor;
	}

	public Task<Result<RecommendationList, DomainError>> Personal(string blockId, RecomendationAnalyticActionsTag actionsTag, CancellationToken token = default(CancellationToken))
	{
		return Request(3, blockId, actionsTag, (CancellationToken ct) => _api.PersonalRecommendations(ct), token);
	}

	public Task<Result<RecommendationList, DomainError>> LatestByCategoryPath(string blockId, RecomendationAnalyticActionsTag actionsTag, CancellationToken token = default(CancellationToken))
	{
		IReadOnlyList<string> categoryPaths = new global::_003C_003Ez__ReadOnlyArray<string>(new string[16]
		{
			"Вода, соки, напитки", "Молочныепродукты, сыр, яйц", "Сыр", "Птица, мясо", "Колбасные изделия", "Овощи, фрукты, орехи", "Рыба, икра, морепродукты", "Товары Ашан", "Хлеб и выпечка", "Бакалея",
			"Сладости", "Чай, кофе", "Все для детей", "Чипсы, снеки, сухофрукты", "Готовая еда", "Замороженные продукты"
		});
		return Request(3, blockId, actionsTag, (CancellationToken ct) => _api.LatestByCategoryPath(categoryPaths, ct), token);
	}

	public Task<Result<RecommendationList, DomainError>> LatestInInterestedCategories(string blockId, RecomendationAnalyticActionsTag actionsTag, CancellationToken token = default(CancellationToken))
	{
		return Request(3, blockId, actionsTag, (CancellationToken ct) => _api.LatestInInterestedCategories(ct), token);
	}

	public Task<Result<RecommendationList, DomainError>> PersonalViewed(string blockId, RecomendationAnalyticActionsTag actionsTag, CancellationToken token = default(CancellationToken))
	{
		return Request(3, blockId, actionsTag, (CancellationToken ct) => _api.PersonalViewed(ct), token);
	}

	public Task<Result<RecommendationList, DomainError>> PersonalOrdered(string blockId, RecomendationAnalyticActionsTag actionsTag, CancellationToken token = default(CancellationToken))
	{
		return Request(3, blockId, actionsTag, (CancellationToken ct) => _api.PersonalOrdered(ct), token);
	}

	public Task<Result<RecommendationList, DomainError>> Related(IReadOnlyList<string> productIds, string blockId, RecomendationAnalyticActionsTag actionsTag, CancellationToken token = default(CancellationToken))
	{
		return Request(blockId, actionsTag, (CancellationToken ct) => _api.Related(productIds, ct), token);
	}

	public Task<Result<RecommendationList, DomainError>> CrossSellForLargeBaskets(IReadOnlyList<string> productIds, string blockId, RecomendationAnalyticActionsTag actionsTag, CancellationToken token = default(CancellationToken))
	{
		return Request(blockId, actionsTag, (CancellationToken ct) => _api.CrossSellForLargeBaskets(productIds, ct), token);
	}

	public Task<Result<RecommendationList, DomainError>> Alternatives(IReadOnlyList<string> productIds, string blockId, RecomendationAnalyticActionsTag actionsTag, CancellationToken token = default(CancellationToken))
	{
		return Request(blockId, actionsTag, (CancellationToken ct) => _api.Alternatives(productIds, ct), token);
	}

	public Task<Result<RecommendationList, DomainError>> AnalogsOutOfStockProducts(IReadOnlyList<string> productIds, string blockId, RecomendationAnalyticActionsTag actionsTag, CancellationToken token = default(CancellationToken))
	{
		return Request(blockId, actionsTag, (CancellationToken ct) => _api.AnalogsOutOfStockProducts(productIds, ct), token);
	}

	public Task<Result<RecommendationList, DomainError>> SortItemsInCategory(string blockId, RecomendationAnalyticActionsTag actionsTag, CancellationToken token = default(CancellationToken))
	{
		return Request(3, blockId, actionsTag, (CancellationToken ct) => _api.SortItemsInCategory("0"), token);
	}

	public Task<Result<RecommendationList, DomainError>> PopularInInterestedCategories(string blockId, RecomendationAnalyticActionsTag actionsTag, CancellationToken token = default(CancellationToken))
	{
		return Request(3, blockId, actionsTag, (CancellationToken ct) => _api.PopularInInterestedCategories(), token);
	}

	public Task<Result<RecommendationList, DomainError>> Search(string searchPhrase, string blockId, RecomendationAnalyticActionsTag actionsTag, CancellationToken token = default(CancellationToken))
	{
		return Request(3, blockId, actionsTag, (CancellationToken ct) => _api.Search(searchPhrase, ct), token);
	}

	public Task<Result<RecommendationList, DomainError>> PopularInCategory(IReadOnlyList<string> categoryIds, string blockId, RecomendationAnalyticActionsTag actionsTag, CancellationToken token = default(CancellationToken))
	{
		return Request(blockId, actionsTag, (CancellationToken ct) => _api.PopularInCategory(categoryIds, ct), token);
	}

	public Task<Result<RecommendationList, DomainError>> PopularInCategoryByPath(IReadOnlyList<string> categoryPaths, string blockId, RecomendationAnalyticActionsTag actionsTag, CancellationToken token = default(CancellationToken))
	{
		return Request(blockId, actionsTag, (CancellationToken ct) => _api.PopularInCategoryByPath(categoryPaths, ct), token);
	}

	public Task<Result<RecommendationList, DomainError>> SaleByPopularInCategoryByPath(IReadOnlyList<string> categoryPaths, string blockId, RecomendationAnalyticActionsTag actionsTag, CancellationToken token = default(CancellationToken))
	{
		return Request(blockId, actionsTag, (CancellationToken ct) => _api.SaleByPopularInCategoryByPath(categoryPaths, ct), token);
	}

	public Task<Result<RecommendationList, DomainError>> PersonalCompositeForCategoryByCategoryPath(string categoryPath, string blockId, RecomendationAnalyticActionsTag actionsTag, CancellationToken token = default(CancellationToken))
	{
		return Request(blockId, actionsTag, (CancellationToken ct) => _api.PersonalCompositeForCategoryByCategoryPath(categoryPath, ct), token);
	}

	public Task<Result<RecommendationList, DomainError>> PopularByInterestedPropertiesByCategoryPath(string categoryPath, string blockId, RecomendationAnalyticActionsTag actionsTag, CancellationToken token = default(CancellationToken))
	{
		return Request(blockId, actionsTag, (CancellationToken ct) => _api.PopularByInterestedPropertiesByCategoryPath(categoryPath, ct), token);
	}

	private Task<Result<RecommendationList, DomainError>> Request(string blockId, RecomendationAnalyticActionsTag actionsTag, Func<CancellationToken, Task<HttpResponseMessage>> requestFactory, CancellationToken token)
	{
		return Request(15, blockId, actionsTag, requestFactory, token);
	}

	private Task<Result<RecommendationList, DomainError>> Request(int timeoutInSeconds, string blockId, RecomendationAnalyticActionsTag actionsTag, Func<CancellationToken, Task<HttpResponseMessage>> requestFactory, CancellationToken token)
	{
		return _requestExecutor.Execute(timeoutInSeconds, blockId, actionsTag, FromRecommendationResponse, requestFactory, token);
	}

	private static IReadOnlyList<RecommendationList.Item>? FromRecommendationResponse(JsonReader from, string blockId, RecomendationAnalyticActionsTag actionsTag)
	{
		RecommendationResponse recommendationResponse = JsonSerializer.Create().Deserialize<RecommendationResponse>(from);
		if (recommendationResponse?.Recommendations == null || recommendationResponse.Recommendations.Count <= 0)
		{
			return null;
		}
		return recommendationResponse.Recommendations?.Select((RecommendationItem i) => new RecommendationList.Item
		{
			GimaId = i.GimaId,
			AnalyticsInfo = new RecommendationAnalyticsInfo
			{
				BlockId = blockId,
				ActionsTag = actionsTag
			}
		}).ToImmutableList() ?? ImmutableList.Create(default(ReadOnlySpan<RecommendationList.Item>));
	}

	public Task<Result<RecommendationList, DomainError>> GetAnyPlacementsAsync(PlacementId placementId, string blockId, RecomendationAnalyticActionsTag actionsTag, CancellationToken token = default(CancellationToken))
	{
		return RequestPlacement(blockId, actionsTag, (CancellationToken ct) => _productPlacementsApi.GetAnyPlacementsAsync(placementId, ct), token);
	}

	public Task<Result<RecommendationList, DomainError>> GetProductGroupPlacementsAsync(PlacementId placementId, string blockId, RecomendationAnalyticActionsTag actionsTag, IReadOnlyList<long> allProductsInCartGimaIds, CancellationToken token = default(CancellationToken))
	{
		return RequestPlacement(blockId, actionsTag, (CancellationToken ct) => _productPlacementsApi.GetProductGroupPlacementsAsync(placementId, allProductsInCartGimaIds, ct), token);
	}

	public Task<Result<RecommendationList, DomainError>> GetCategoryPlacementsAsync(PlacementId placementId, string blockId, RecomendationAnalyticActionsTag actionsTag, string categoryPath, CancellationToken token = default(CancellationToken))
	{
		return RequestPlacement(blockId, actionsTag, (CancellationToken ct) => _productPlacementsApi.GetCategoryPlacementsAsync(placementId, categoryPath, ct), token);
	}

	public Task<Result<RecommendationList, DomainError>> GetProductPlacementsAsync(PlacementId placementId, string blockId, RecomendationAnalyticActionsTag actionsTag, long productGimaId, CancellationToken token = default(CancellationToken))
	{
		return RequestPlacement(blockId, actionsTag, (CancellationToken ct) => _productPlacementsApi.GetProductPlacementsAsync(placementId, productGimaId, ct), token);
	}

	private Task<Result<RecommendationList, DomainError>> RequestPlacement(string blockId, RecomendationAnalyticActionsTag actionsTag, Func<CancellationToken, Task<HttpResponseMessage>> requestFactory, CancellationToken token)
	{
		return RequestPlacement(15, blockId, actionsTag, requestFactory, token);
	}

	private Task<Result<RecommendationList, DomainError>> RequestPlacement(int timeoutInSeconds, string blockId, RecomendationAnalyticActionsTag actionsTag, Func<CancellationToken, Task<HttpResponseMessage>> requestFactory, CancellationToken token)
	{
		return _requestExecutor.Execute(timeoutInSeconds, blockId, actionsTag, FromProductPlacementsResponseDto, requestFactory, token);
	}

	private static IReadOnlyList<RecommendationList.Item>? FromProductPlacementsResponseDto(JsonReader from, string blockId, RecomendationAnalyticActionsTag actionsTag)
	{
		ProductPlacementsResponseDto productPlacementsResponseDto = JsonSerializer.Create().Deserialize<ProductPlacementsResponseDto>(from);
		if (productPlacementsResponseDto == null || !productPlacementsResponseDto.Content.Any())
		{
			return null;
		}
		return productPlacementsResponseDto.Content.SelectMany((ProductPlacementsResponseDto.ContentDto content) => content.ProductIds, delegate(ProductPlacementsResponseDto.ContentDto content, int productId)
		{
			RecommendationList.Item obj = new RecommendationList.Item
			{
				AnalyticsInfo = new RecommendationAnalyticsInfo
				{
					BlockId = blockId,
					ProductPlacementContentId = content.Id,
					ActionsTag = actionsTag
				}
			};
			int num = productId;
			obj.GimaId = num.ToString();
			return obj;
		}).ToImmutableList();
	}
}
