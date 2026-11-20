using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Ecom;
using Auchan.Common.Ecom.Address.Models;
using Auchan.Common.Ecom.ProducModels;
using Auchan.Common.Ecom.Products;
using Auchan.Common.Extensions;
using Auchan.Common.Logs;
using Auchan.Common.Recommendations.Models;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Recommendations;

internal class RecommendationsRepository : IRecommendationsRepository
{
	private const string Tag = "RecommendationsRepository";

	private readonly IProductsRepository _productsRepository;

	private readonly IRecommendationService _recommendationService;

	private readonly ILogService _logService;

	private readonly IEcomContext _ecomContext;

	private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1);

	public RecommendationsRepository(IProductsRepository productsRepository, IRecommendationService recommendationService, ILogService logService, IEcomContext ecomContext)
	{
		_productsRepository = productsRepository;
		_recommendationService = recommendationService;
		_logService = logService;
		_ecomContext = ecomContext;
	}

	public async Task<Result<IReadOnlyList<ProductWithAnalyticsInfo>, DomainError>> Get(IAlgorithm algorithm, bool reload = true)
	{
		Store activeStore = await _ecomContext.GetActiveStoreAsync();
		string cacheKey = algorithm.GetCacheKey(activeStore);
		await _semaphore.WaitAsync();
		try
		{
			if (reload)
			{
				algorithm.Reset(activeStore);
			}
			if (string.IsNullOrWhiteSpace(cacheKey))
			{
				return await Request(algorithm);
			}
			ProductWithAnalyticsInfo[] array = await algorithm.Cache.TryGet<ProductWithAnalyticsInfo[]>(cacheKey);
			if (((IReadOnlyCollection<ProductWithAnalyticsInfo>?)(object)array).IsNotNullOrEmptyCollection())
			{
				if (algorithm is IAbstractEndlessAlgorithm abstractEndlessAlgorithm)
				{
					array = array.Skip(abstractEndlessAlgorithm.ProductsOffset).TakeSafe(25).ToArray();
					if (array.IsNullOrEmpty())
					{
						return await Request(algorithm);
					}
					algorithm.AddProductsOffset(25);
				}
				return (Result<IReadOnlyList<ProductWithAnalyticsInfo>, DomainError>)(IReadOnlyList<ProductWithAnalyticsInfo>)array;
			}
			return await Request(algorithm);
		}
		catch
		{
			throw;
		}
		finally
		{
			_semaphore.Release();
		}
	}

	public async Task<Result<(IAlgorithm From, IReadOnlyList<ProductWithAnalyticsInfo> Products), DomainError>> GetFirstAvailableAsync(IEnumerable<IAlgorithm> algorithms, bool reload = true)
	{
		Result<IReadOnlyList<ProductWithAnalyticsInfo>, DomainError> result = new UnknownError();
		foreach (IAlgorithm i in algorithms)
		{
			result = await Get(i, reload);
			if (result.TryGetError(out var error) && !(error is NoDataError))
			{
				string value = error.ToString();
				string description = $"Нет рекомендаций для отображения. Алгоритм - {i.Name}, блок - {i.BlockId}, причина - {value}";
				_logService.Log("RecommendationsRepository", description, LogLevel.Error, LogType.ApiRequest, SystemType.RocketRetail);
			}
			if (result.TryGetValue(out var value2) && value2.Count > 0)
			{
				return (i, value2);
			}
		}
		if (result.TryGetValue(out var value3))
		{
			return (algorithms.Last(), value3);
		}
		return result.Error;
	}

	public async Task<Result<IReadOnlyList<ProductWithAnalyticsInfo>, DomainError>> GetMore(IAlgorithm algorithm, ICollection<string>? loadedGimaIds)
	{
		string cacheKey = algorithm.GetCacheKey(await _ecomContext.GetActiveStoreAsync());
		await _semaphore.WaitAsync();
		try
		{
			if (string.IsNullOrWhiteSpace(cacheKey))
			{
				return await Request(algorithm, loadedGimaIds);
			}
			ProductWithAnalyticsInfo[] array = await algorithm.Cache.TryGet<ProductWithAnalyticsInfo[]>(cacheKey);
			if (((IReadOnlyCollection<ProductWithAnalyticsInfo>?)(object)array).IsNotNullOrEmptyCollection())
			{
				if (algorithm is IAbstractEndlessAlgorithm abstractEndlessAlgorithm)
				{
					array = array.Skip(abstractEndlessAlgorithm.ProductsOffset).TakeSafe(25).ToArray();
					if (array.IsNullOrEmpty())
					{
						return await Request(algorithm, loadedGimaIds);
					}
					algorithm.AddProductsOffset(25);
				}
				return (Result<IReadOnlyList<ProductWithAnalyticsInfo>, DomainError>)(IReadOnlyList<ProductWithAnalyticsInfo>)array;
			}
			return await Request(algorithm, loadedGimaIds);
		}
		catch
		{
			throw;
		}
		finally
		{
			_semaphore.Release();
		}
	}

	private async Task<Result<IReadOnlyList<ProductWithAnalyticsInfo>, DomainError>> Request(IAlgorithm algorithm, ICollection<string>? loadedGimaIds = null)
	{
		Result<RecommendationList, DomainError> result = await algorithm.GetProductIds(_recommendationService);
		if (result.IsFailure)
		{
			return result.Error;
		}
		RecommendationList response = result.Value;
		if (loadedGimaIds?.Any() ?? false)
		{
			response = response with
			{
				Items = response.Items.OrderByDescending((RecommendationList.Item r) => loadedGimaIds.Contains(r.GimaId)).ToImmutableList()
			};
		}
		IReadOnlyList<RecommendationList.Item> recommendations = algorithm.MapResponseItems(response.Items);
		if (recommendations.IsNullOrEmpty())
		{
			algorithm.TrySetLoadedAll();
			return (Result<IReadOnlyList<ProductWithAnalyticsInfo>, DomainError>)(IReadOnlyList<ProductWithAnalyticsInfo>)ImmutableList<ProductWithAnalyticsInfo>.Empty;
		}
		Result<IReadOnlyList<Product>, DomainError> result2 = await _productsRepository.GetProductsByGimaIdAsync(_ecomContext.ActiveStore.Id.ToString(), recommendations.Select((RecommendationList.Item r) => r.GimaId));
		if (result2.TryGetValue(out var value))
		{
			value = ((value != null) ? algorithm.MapProducts(value) : Array.Empty<Product>());
			int recommendationsCount = recommendations.Count;
			int productsCount = value.Count;
			algorithm.AddProductsOffset(recommendationsCount);
			if (productsCount == 0)
			{
				if (algorithm.TrySetLoadedAll())
				{
					return (Result<IReadOnlyList<ProductWithAnalyticsInfo>, DomainError>)(IReadOnlyList<ProductWithAnalyticsInfo>)ImmutableList<ProductWithAnalyticsInfo>.Empty;
				}
				return await Request(algorithm);
			}
			TimeSpan cacheTime = ((response.CacheTime > algorithm.MaxCacheTime) ? algorithm.MaxCacheTime : response.CacheTime);
			Dictionary<string, RecommendationAnalyticsInfo> lookup = new Dictionary<string, RecommendationAnalyticsInfo>(recommendations.Select((RecommendationList.Item i) => new KeyValuePair<string, RecommendationAnalyticsInfo>(i.GimaId, i.AnalyticsInfo)));
			IReadOnlyList<ProductWithAnalyticsInfo> productsWithIds = value.Select((Product i) => new ProductWithAnalyticsInfo
			{
				Product = i,
				Analytics = GetBlockIdByLookup(lookup, i)
			}).ToImmutableList();
			await CacheProductsIfNeccessary(algorithm, productsWithIds, response.HasCacheControl, cacheTime);
			if (recommendationsCount != productsCount)
			{
				Log($"[{algorithm.Name}]: Несоответствие (RR - {recommendationsCount}, Ecom - {productsCount})");
			}
			return Result.Success<IReadOnlyList<ProductWithAnalyticsInfo>, DomainError>(productsWithIds);
		}
		DomainError error = result2.Error;
		string message = error.Message;
		Log($"Ошибка при запросе рекомендаций ECom - '{message}' ({error.GetType().Name})", isError: true);
		return result2.Error;
	}

	private async Task CacheProductsIfNeccessary(IAlgorithm algorithm, IReadOnlyList<ProductWithAnalyticsInfo> products, bool hasCacheControl, TimeSpan cacheTime)
	{
		if (!(cacheTime <= TimeSpan.Zero))
		{
			string cacheKey = algorithm.GetCacheKey(await _ecomContext.GetActiveStoreAsync());
			if (hasCacheControl && !string.IsNullOrWhiteSpace(cacheKey))
			{
				IReadOnlyList<ProductWithAnalyticsInfo> readOnlyList = (await algorithm.Cache.TryGet<ProductWithAnalyticsInfo[]>(cacheKey))?.Concat(products)?.ToArray();
				products = readOnlyList ?? products;
				await algorithm.Cache.Save(cacheKey, products, cacheTime);
			}
		}
	}

	private void Log(string message, bool isError = false)
	{
		_logService.Log("RecommendationsRepository", message, isError ? LogLevel.Error : LogLevel.Info, LogType.ApiRequest, SystemType.RocketRetail);
	}

	private static RecommendationAnalyticsInfo GetBlockIdByLookup(IDictionary<string, RecommendationAnalyticsInfo> lookup, Product product)
	{
		if (!string.IsNullOrEmpty(product.GimaId) && lookup.TryGetValue(product.GimaId, out RecommendationAnalyticsInfo value))
		{
			return value;
		}
		return RecommendationAnalyticsInfo.Empty;
	}
}
