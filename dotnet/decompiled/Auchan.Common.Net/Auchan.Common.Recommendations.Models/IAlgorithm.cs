using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Cache;
using Auchan.Common.Ecom.Address.Models;
using Auchan.Common.Ecom.ProducModels;
using Auchan.Common.Recommendations.API;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Recommendations.Models;

public interface IAlgorithm
{
	string Name { get; }

	TimeSpan MaxCacheTime { get; }

	int ToSkip { get; set; }

	bool IsNeedToShowAllProducts { get; }

	IGenericCache Cache { get; }

	string BlockId { get; }

	AlgorithmArgument Argument { get; }

	string Title { get; }

	string? GetCacheKey(Store activeStore);

	Task<Result<RecommendationList, DomainError>> MapRequest(IRecommendationApiService apiService, CancellationToken token);

	IReadOnlyList<RecommendationList.Item> MapResponseItems(IReadOnlyList<RecommendationList.Item> items);

	IReadOnlyList<Product> MapProducts(IReadOnlyList<Product> products);

	bool TrySetLoadedAll();

	void AddProductsOffset(int offset);

	int GetPreviewCount(int productsCount);

	void Reset(Store activeStore);

	Task<Result<RecommendationList, DomainError>> GetProductIds(IRecommendationService recommendationService);
}
public interface IAlgorithm<T> : IAlgorithm where T : AlgorithmArgument
{
	new T Argument { get; }
}
