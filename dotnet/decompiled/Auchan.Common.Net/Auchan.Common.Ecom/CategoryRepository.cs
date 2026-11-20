using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Base;
using Auchan.Common.Base.Errors;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Base.Errors.Service;
using Auchan.Common.Ecom.DTO;
using Auchan.Common.Extensions;
using Auchan.Common.Networking;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Ecom;

public class CategoryRepository : ICategoryRepository
{
	private record struct CacheKey(bool PromoOnly, bool ActiveOnly, bool cachbackOnly, bool showHidden);

	private readonly Dictionary<CacheKey, IReadOnlyList<Category>> _cachedCategories = new Dictionary<CacheKey, IReadOnlyList<Category>>();

	private readonly IEcomApi _api;

	private readonly IEcomContext _ecomContext;

	private readonly IRequestExecutor _requestExecutor;

	public CategoryRepository(IEcomApi api, IEcomContext ecomContext, IRequestExecutor requestExecutor)
	{
		_api = api;
		_ecomContext = ecomContext;
		_requestExecutor = requestExecutor;
		_ecomContext.OnPropertyChanged("ActiveStore", delegate
		{
			lock (_cachedCategories)
			{
				_cachedCategories.Clear();
			}
		});
	}

	public async Task<Result<Brand, DomainError>> Brand(string brandName)
	{
		return (await _requestExecutor.Execute((CancellationToken t) => _api.Brand(_ecomContext.ActiveStore.Id, brandName, t))).Map((BrandResponseDto dto) => dto.Map(), (ServiceError err) => err.ToBaseDomainError());
	}

	public async Task<Result<List<Category>, DomainError>> TopCategories(bool promoOnly = false, bool activeOnly = false, bool cashbackOnly = false, bool showHidden = false)
	{
		return (await _requestExecutor.Execute((CancellationToken t) => _api.TopCategories(_ecomContext.ActiveStore.Id, promoOnly ? "1" : null, activeOnly ? "1" : null, showHidden ? "1" : null, cashbackOnly ? "1" : null, t))).Ensure((IReadOnlyList<CategoryDto> dto) => dto.Count != 0, new ApiContractError()).Map((IReadOnlyList<CategoryDto> dto) => dto.Select((CategoryDto categoryDto) => categoryDto.Map()).ToList(), (ServiceError err) => err.ToBaseDomainError());
	}

	public async Task<Result<IReadOnlyList<Category>, DomainError>> GetCachedTopCategories(bool promoOnly = false, bool activeOnly = false, bool cashbackOnly = false, bool showHidden = false)
	{
		YieldAwaitable.YieldAwaiter awaiter = Task.Yield().GetAwaiter();
		_ = awaiter.IsCompleted;
		await awaiter;
		YieldAwaitable.YieldAwaiter yieldAwaiter = default(YieldAwaitable.YieldAwaiter);
		awaiter = yieldAwaiter;
		int num = -1;
		awaiter.GetResult();
		CacheKey cacheKey = new CacheKey(promoOnly, activeOnly, cashbackOnly, showHidden);
		Dictionary<CacheKey, IReadOnlyList<Category>> cachedCategories = _cachedCategories;
		bool lockTaken = false;
		IReadOnlyList<Category> value;
		try
		{
			Monitor.Enter(cachedCategories, ref lockTaken);
			if (_cachedCategories.TryGetValue(cacheKey, out value))
			{
				return Result.Success<IReadOnlyList<Category>, DomainError>(value);
			}
		}
		finally
		{
			if (num < 0 && lockTaken)
			{
				Monitor.Exit(cachedCategories);
			}
		}
		int storeId = _ecomContext.ActiveStore.Id;
		Result<IReadOnlyList<Category>, DomainError> result = (await _requestExecutor.Execute((CancellationToken t) => _api.TopCategories(storeId, promoOnly ? "1" : null, activeOnly ? "1" : null, showHidden ? "1" : null, cashbackOnly ? "1" : null, t))).Ensure((IReadOnlyList<CategoryDto> dto) => dto.Count != 0, new ApiContractError()).Map((Func<IReadOnlyList<CategoryDto>, IReadOnlyList<Category>>)((IReadOnlyList<CategoryDto> dto) => dto.Select((CategoryDto categoryDto) => categoryDto.Map()).ToImmutableList()), (Func<ServiceError, DomainError>)((ServiceError err) => err.ToBaseDomainError()));
		if (storeId == _ecomContext.ActiveStore.Id && result.TryGetValue(out value))
		{
			cachedCategories = _cachedCategories;
			lockTaken = false;
			try
			{
				Monitor.Enter(cachedCategories, ref lockTaken);
				_cachedCategories[cacheKey] = value;
			}
			finally
			{
				if (num < 0 && lockTaken)
				{
					Monitor.Exit(cachedCategories);
				}
			}
		}
		return result;
	}

	public async Task<Result<List<Category>, DomainError>> GetCategoriesTree(string code, bool showHidden = false)
	{
		return (await _requestExecutor.Execute((CancellationToken t) => _api.Categories(_ecomContext.ActiveStore.Id, code, showHidden ? "1" : null, "1", t))).Ensure((List<CategoryDto> dto) => dto != null && dto.Count > 0, new ApiContractError()).Map((List<CategoryDto> dto) => dto.Select((CategoryDto categoryDto) => categoryDto.Map()).ToList(), (ServiceError err) => err.ToBaseDomainError());
	}

	public async Task<Result<List<Category>, DomainError>> GetSubCategories(string code)
	{
		return (await _requestExecutor.Execute((CancellationToken t) => _api.CategoriesPreview(_ecomContext.ActiveStore.Id, code, t))).Ensure((CategoriesPreviewDto dto) => dto != null && dto.SubCategories.Count > 0, new ApiContractError()).Map((CategoriesPreviewDto dto) => dto.SubCategories.Select((CategoriesPreviewItemDto categoryDto) => categoryDto.Category.Map()).ToList(), (ServiceError err) => err.ToBaseDomainError());
	}

	public async Task<Result<List<Category>, DomainError>> GetSubCategoriesSecondLevel(string code, bool isShowHidden = false)
	{
		return (await _requestExecutor.Execute((CancellationToken t) => _api.Categories(_ecomContext.ActiveStore.Id, code, isShowHidden ? "1" : null, "1", t))).Ensure((List<CategoryDto> dto) => dto != null && dto.Count > 0, new ApiContractError()).Map((List<CategoryDto> dto) => dto.Select((CategoryDto categoryDto) => categoryDto.Map()).ToList(), (ServiceError err) => err.ToBaseDomainError());
	}
}
