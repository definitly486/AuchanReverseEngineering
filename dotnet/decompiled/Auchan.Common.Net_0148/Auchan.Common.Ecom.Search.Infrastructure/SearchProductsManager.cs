using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using Auchan.Common.Analytics;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Common;
using Auchan.Common.Ecom.ProducModels;
using Auchan.Common.Ecom.Search.DTO;
using Auchan.Common.Ecom.Search.FilterViewModels;
using Auchan.Common.Ecom.Search.Models;
using Auchan.Common.Extensions;
using Auchan.Common.Logs;
using Auchan.Common.Managers.Dialogs;
using Auchan.Common.PersonalCabinet;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Ecom.Search.Infrastructure;

public class SearchProductsManager : IApplicationStateObserver
{
	private const string CATEGORY_CODE_KEY = "categoryCode";

	private readonly Lazy<SearchProductsRepository> _searchProductsRepository;

	private readonly Lazy<SearchProductsService> _searchProductsService;

	private readonly Lazy<SearchQueryHistoryRepository> _searchQueryHistoryRepository;

	private readonly Lazy<IEcomContext> _ecomContext;

	private readonly Lazy<IAgeGateDialog> _ageGateDialog;

	private readonly IUserContext _userContext;

	private readonly Lazy<ILogService> _logService;

	private readonly Lazy<SearchAutohintsService> _autohintsService;

	public event EventHandler? OnSearchReset;

	public SearchProductsManager(Lazy<SearchProductsRepository> searchProductsRepository, Lazy<SearchProductsService> searchProductsService, Lazy<IEcomContext> ecomContext, Lazy<IAgeGateDialog> ageGateDialog, Lazy<ICurrentStoreSelectDialog> currentStoreSelectDialog, Lazy<SearchQueryHistoryRepository> searchQueryHistoryRepository, IUserContext userContext, Lazy<ILogService> logService, Lazy<SearchAutohintsService> autohintsService)
	{
		_searchProductsRepository = searchProductsRepository;
		_searchProductsService = searchProductsService;
		_ecomContext = ecomContext;
		_ageGateDialog = ageGateDialog;
		_searchQueryHistoryRepository = searchQueryHistoryRepository;
		_userContext = userContext;
		_logService = logService;
		_autohintsService = autohintsService;
		_userContext.AfterLoggedIn += delegate
		{
			ResetSearchState();
			return _searchQueryHistoryRepository.Value.ClearSearchHistory();
		};
		_userContext.AfterLoggedOut += delegate
		{
			ResetSearchState();
			return _searchQueryHistoryRepository.Value.ClearSearchHistory();
		};
	}

	public Task<Result<SearchProducts, DomainError>> ProductsBySearchQuery()
	{
		return ProductsBySearchQuery(_searchProductsRepository.Value.CurrentSearchQuery, null, saveQuery: true, sendAnalytics: false);
	}

	public Task<Result<SearchProducts, DomainError>> ProductsBySearchQuery(string query)
	{
		return ProductsBySearchQuery(query, saveQuery: true);
	}

	public Task<Result<SearchProducts, DomainError>> ProductsBySearchQuery(string query, bool saveQuery)
	{
		return ProductsBySearchQuery(query, null, saveQuery, sendAnalytics: false);
	}

	public async Task<Result<SearchProducts, DomainError>> ProductsBySearchQuery(string query, string? categoryCode, bool saveQuery, bool sendAnalytics)
	{
		_searchProductsRepository.Value.SetSearchState(SearchVisualState.InProgress);
		_searchProductsRepository.Value.SetSearchQuery(query);
		if (saveQuery)
		{
			await _searchQueryHistoryRepository.Value.AddSearchQueryEntry(query);
		}
		SearchRequestDTO searchRequestDTO = new SearchRequestDTO();
		IEnumerable<Tuple<string, object>> source = _searchProductsRepository.Value.CurrentSearchFilters.SelectNotNull((BaseFilterItemViewModel filter) => filter.GetSelectedFilter());
		if (source.Any())
		{
			searchRequestDTO.Filters = source.ToDictionary((Tuple<string, object> filter) => filter.Item1, (Tuple<string, object> filter) => filter.Item2);
		}
		if (!string.IsNullOrEmpty(categoryCode))
		{
			if (searchRequestDTO.Filters == null)
			{
				searchRequestDTO.Filters = new Dictionary<string, object>();
			}
			if (!searchRequestDTO.Filters.ContainsKey("categoryCode"))
			{
				searchRequestDTO.Filters["categoryCode"] = categoryCode;
			}
		}
		searchRequestDTO.Sort = _searchProductsRepository.Value.CurrentSearchSorts.FirstOrDefault((SortItemViewModel s) => s.IsSelected)?.Value ?? "default";
		Result<SearchResult, DomainError> result = await _searchProductsService.Value.ProductsBySearchQuery(query, _ecomContext.Value.ActiveStore.Id, null, searchRequestDTO);
		if (result.IsFailure)
		{
			_searchProductsRepository.Value.SetSearchState(SearchVisualState.NotFound);
			_searchProductsRepository.Value.ClearSearchResults();
			_searchProductsRepository.Value.ClearSearchFilters();
			return Result.Failure<SearchProducts, DomainError>(result.Error);
		}
		ImmutableList<Product> items = result.Value?.Items?.SelectMany(delegate(KeyValuePair<string, CategoryWithProduct> item)
		{
			IEnumerable<Product> products = item.Value.Products;
			return products ?? Array.Empty<Product>();
		}).ToImmutableList();
		if (items.IsNullOrEmpty())
		{
			if (sendAnalytics && items != null && items.Count == 0)
			{
				AppAnalytics.Ecom.Search(query);
			}
			_searchProductsRepository.Value.SetSearchState(SearchVisualState.NotFound);
			_searchProductsRepository.Value.ClearSearchFilters();
			_searchProductsRepository.Value.ClearSearchResults();
			return Result.Failure<SearchProducts, DomainError>(new NoDataError());
		}
		if (sendAnalytics)
		{
			AppAnalytics.Ecom.Search(query, items.ToArray());
		}
		int num = items.Count((Product i) => i.IsAdult);
		double num2 = (double)num * 1.0 / (double)items.Count;
		_logService.Value.LogInfo("SearchProductsManager", $"доля 18+ в поиске {num2} = {num} / {items.Count}", LogType.UserAction, SystemType.MobileApp);
		if (num2 > 0.1 && _ecomContext.Value.AgeGateAgreement != AgreeState.Yes)
		{
			await _ageGateDialog.Value.ShowAgeGateDialogAsync();
		}
		_searchProductsRepository.Value.SetSearchState(SearchVisualState.Content);
		if (result.Value?.Filters?.IsNullOrEmpty() ?? true)
		{
			_searchProductsRepository.Value.ClearSearchFilters();
		}
		else
		{
			_searchProductsRepository.Value.SetSearchResult(result.Value);
			if (result.Value?.SelectedFilters != null)
			{
				_searchProductsRepository.Value.RestoreSearchFilters(result.Value.SelectedFilters);
			}
		}
		if (!string.IsNullOrWhiteSpace(result.Value?.Sort))
		{
			_searchProductsRepository.Value.CurrentSearchSorts.ForEach(delegate(SortItemViewModel s)
			{
				s.IsSelected = s.Value == result.Value.Sort;
			});
		}
		_searchProductsRepository.Value.SetSearchResults(items);
		return Result.Success<SearchProducts, DomainError>(new SearchProducts
		{
			Products = items
		});
	}

	public async Task<Result<SearchResult, DomainError>> ProductCountBySearchQuery(string query, IEnumerable<BaseFilterItemViewModel> filters)
	{
		SearchRequestDTO searchRequestDTO = new SearchRequestDTO();
		IEnumerable<Tuple<string, object>> source = filters.SelectNotNull((BaseFilterItemViewModel filter) => filter.GetSelectedFilter());
		if (source.Any())
		{
			searchRequestDTO.Filters = source.ToDictionary((Tuple<string, object> filter) => filter.Item1, (Tuple<string, object> filter) => filter.Item2);
		}
		searchRequestDTO.Sort = _searchProductsRepository.Value.CurrentSearchSorts.FirstOrDefault((SortItemViewModel s) => s.IsSelected)?.Value ?? "default";
		return await _searchProductsService.Value.ProductsBySearchQuery(query, _ecomContext.Value.ActiveStore.Id, null, searchRequestDTO);
	}

	public Result<int, DomainError> ProductCountBySearchResult(Result<SearchResult, DomainError> result)
	{
		if (result.IsFailure)
		{
			return Result.Failure<int, DomainError>(result.Error);
		}
		IReadOnlyList<SearchFilter>? filters = result.Value.Filters;
		if (filters != null && !filters.IsNullOrEmpty())
		{
			_searchProductsRepository.Value.SetSearchResult(result.Value, _searchProductsRepository.Value.CurrentSearchFiltersCopy);
			if (result.Value.SelectedFilters != null)
			{
				_searchProductsRepository.Value.RestoreSearchFilters(result.Value.SelectedFilters, _searchProductsRepository.Value.CurrentSearchFiltersCopy);
			}
		}
		return Result.Success<int, DomainError>(result.Value.Count);
	}

	public void ResetSearchState()
	{
		_searchProductsRepository.Value.SetSearchQuery(string.Empty);
		_searchProductsRepository.Value.SetSearchState(SearchVisualState.None);
		_searchProductsRepository.Value.ClearSearchResults();
		_searchProductsRepository.Value.ClearSearchFilters();
		_searchProductsRepository.Value.ResetSearchSort();
		_autohintsService.Value.ResetState();
		this.OnSearchReset?.Invoke(this, EventArgs.Empty);
	}
}
