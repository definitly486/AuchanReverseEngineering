using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Cache;
using Auchan.Common.Ecom.Address.Models;
using Auchan.Common.Ecom.ProducModels;
using Auchan.Common.Recommendations.API;
using CSharpFunctionalExtensions;
using DryIoc;

namespace Auchan.Common.Recommendations.Models;

public sealed class NoveltyAlgorithm : AbstractAlgorithm<AlgorithmArgument>
{
	private const string CACHE_KEY_PREFIX = "32F0EE4B-7B97-4521-AAAA-0E3104D70152-";

	private readonly LatestByCategoryPathAlgorithm _latestByCategoryPath;

	private readonly LatestInInterestedCategoriesAlgorithm _latestInInterestedCategories;

	private string _blockId = "";

	public override string Name => "NoveltyAlgorithm";

	public override string BlockId => _blockId;

	public NoveltyAlgorithm(IResolver resolver, ICache cache, AlgorithmArgument argument)
		: base((IGenericCache)cache, argument)
	{
		_latestByCategoryPath = resolver.Resolve<LatestByCategoryPathAlgorithm>(new object[1]
		{
			new AlgorithmArgument
			{
				BlockId = "latest_items_rr",
				Title = ""
			}
		});
		_latestInInterestedCategories = resolver.Resolve<LatestInInterestedCategoriesAlgorithm>(new object[1]
		{
			new AlgorithmArgument
			{
				BlockId = "latest_items_personalized",
				Title = ""
			}
		});
	}

	public static NoveltyAlgorithm Create(IResolver resolver, AlgorithmArgument argument)
	{
		return resolver.Resolve<NoveltyAlgorithm>(new object[1] { argument });
	}

	public override string? GetCacheKey(Store activeStore)
	{
		return "32F0EE4B-7B97-4521-AAAA-0E3104D70152-" + activeStore.Id;
	}

	public override async Task<Result<RecommendationList, DomainError>> MapRequest(IRecommendationApiService apiService, CancellationToken token)
	{
		Result<RecommendationList, DomainError> result = await _latestInInterestedCategories.MapRequest(apiService, token);
		if (result.TryGetValue(out var value) && value.Items.Count > 20)
		{
			_blockId = _latestInInterestedCategories.BlockId;
			return result;
		}
		result = await _latestByCategoryPath.MapRequest(apiService, token);
		_blockId = _latestByCategoryPath.BlockId;
		return result;
	}

	public override IReadOnlyList<Product> MapProducts(IReadOnlyList<Product> products)
	{
		return products.Where((Product i) => i.IsNew).ToImmutableList();
	}
}
