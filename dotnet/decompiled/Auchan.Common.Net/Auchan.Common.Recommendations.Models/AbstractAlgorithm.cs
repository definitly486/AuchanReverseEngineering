using System;
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

namespace Auchan.Common.Recommendations.Models;

public abstract class AbstractAlgorithm : IAlgorithm
{
	public abstract string Name { get; }

	public virtual string Title => Argument.Title;

	public int ToSkip { get; set; }

	public IGenericCache Cache { get; }

	public virtual TimeSpan MaxCacheTime => RecommendationConfiguration.MaxCacheTime;

	public AlgorithmArgument Argument { get; }

	public virtual bool IsNeedToShowAllProducts => false;

	public virtual string BlockId => Argument.BlockId;

	public AbstractAlgorithm(IGenericCache cache, AlgorithmArgument argument)
	{
		Cache = cache;
		Argument = argument;
	}

	public abstract string? GetCacheKey(Store activeStore);

	public abstract Task<Result<RecommendationList, DomainError>> MapRequest(IRecommendationApiService apiService, CancellationToken token);

	public virtual IReadOnlyList<RecommendationList.Item> MapResponseItems(IReadOnlyList<RecommendationList.Item> items)
	{
		return items.Skip(ToSkip).ToImmutableList();
	}

	public virtual IReadOnlyList<Product> MapProducts(IReadOnlyList<Product> products)
	{
		return products;
	}

	public virtual bool TrySetLoadedAll()
	{
		return true;
	}

	public virtual void AddProductsOffset(int offset)
	{
	}

	public virtual int GetPreviewCount(int productsCount)
	{
		return productsCount;
	}

	public virtual void Reset(Store activeStore)
	{
	}

	public virtual Task<Result<RecommendationList, DomainError>> GetProductIds(IRecommendationService recommendationService)
	{
		return recommendationService.Get(this);
	}
}
public abstract class AbstractAlgorithm<T> : AbstractAlgorithm, IAlgorithm<T>, IAlgorithm where T : AlgorithmArgument
{
	public new T Argument => (T)base.Argument;

	public AbstractAlgorithm(IGenericCache cache, T argument)
		: base(cache, argument)
	{
	}
}
