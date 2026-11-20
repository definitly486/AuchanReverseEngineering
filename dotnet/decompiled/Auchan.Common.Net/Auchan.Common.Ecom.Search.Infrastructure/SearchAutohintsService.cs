using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.AdminTool;
using Auchan.Common.AdminTool.Models;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Ecom.Search.Models;
using Auchan.Common.Extensions;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Ecom.Search.Infrastructure;

public sealed class SearchAutohintsService
{
	private CancellationTokenSource _updateAutohintsCancellation = new CancellationTokenSource();

	private int _pendingRequests;

	private readonly SearchProductsService _searchProductsService;

	private readonly IEcomContext _ecomContext;

	private readonly IAdminContext _adminContext;

	public ObservableRangeCollection<SearchAutofillItemViewModel> Autofills { get; } = new ObservableRangeCollection<SearchAutofillItemViewModel>();

	public ObservableRangeCollection<SearchTextRecomItemViewModel> PopularRecoms { get; } = new ObservableRangeCollection<SearchTextRecomItemViewModel>();

	public ObservableRangeCollection<SearchCategoryRecomItemViewModel> CategoryRecoms { get; } = new ObservableRangeCollection<SearchCategoryRecomItemViewModel>();

	public bool AutohintsAvailable { get; private set; }

	public bool PopularRecomsAvailable { get; private set; }

	public bool CategoryRecomsAvailable { get; private set; }

	public SearchAutohintsService(SearchProductsService searchProductsService, IEcomContext ecomContext, IAdminContext adminContext)
	{
		_searchProductsService = searchProductsService;
		_ecomContext = ecomContext;
		_adminContext = adminContext;
	}

	public void ResetState()
	{
		Autofills.Clear();
		PopularRecoms.Clear();
		CategoryRecoms.Clear();
	}

	public async Task UpdateAutohints(string searchQuery)
	{
		AppConfig appConfig = _adminContext.AppConfig;
		if (appConfig == null || !appConfig.AutohintsEnabled)
		{
			return;
		}
		YieldAwaitable.YieldAwaiter awaiter = Task.Yield().GetAwaiter();
		_ = awaiter.IsCompleted;
		await awaiter;
		YieldAwaitable.YieldAwaiter yieldAwaiter = default(YieldAwaitable.YieldAwaiter);
		awaiter = yieldAwaiter;
		int num = -1;
		awaiter.GetResult();
		CancellationTokenSource cts = new CancellationTokenSource();
		CancellationTokenSource cancellationTokenSource = Interlocked.Exchange(ref _updateAutohintsCancellation, cts);
		try
		{
			cancellationTokenSource.Cancel();
		}
		finally
		{
			if (num < 0)
			{
				((IDisposable)cancellationTokenSource)?.Dispose();
			}
		}
		Interlocked.Increment(ref _pendingRequests);
		Result<SearchAutohintsResult, DomainError> result = await Task.Run(() => AutohintsBySearchQuery(searchQuery, cts.Token));
		Interlocked.Decrement(ref _pendingRequests);
		if (result.IsSuccess)
		{
			SearchAutohintsResult value = result.Value;
			Autofills.ReplaceRange(from f in value.Autofills.TakeSafe(5)
				select new SearchAutofillItemViewModel(f));
			PopularRecoms.ReplaceRange(from f in value.Populars.TakeSafe(3)
				select new SearchTextRecomItemViewModel(f));
			if (string.IsNullOrEmpty(searchQuery))
			{
				CategoryRecoms.Clear();
			}
			else
			{
				CategoryRecoms.ReplaceRange(from f in value.Categories.TakeSafe(2)
					select new SearchCategoryRecomItemViewModel(value, searchQuery, f));
			}
			AutohintsAvailable = Autofills.Count > 0;
			PopularRecomsAvailable = PopularRecoms.Count > 0;
			CategoryRecomsAvailable = CategoryRecoms.Count > 0;
		}
		if (result.IsFailure && _pendingRequests == 0)
		{
			ResetState();
		}
	}

	private async Task<Result<SearchAutohintsResult, DomainError>> AutohintsBySearchQuery(string query, CancellationToken cancellationToken = default(CancellationToken))
	{
		SearchProductsService searchProductsService = _searchProductsService;
		Result<SearchAutohintsResult, DomainError> result = await searchProductsService.AutohintsBySearchQuery(query, (await _ecomContext.GetActiveStoreAsync()).Id, cancellationToken);
		if (result.IsFailure)
		{
			return Result.Failure<SearchAutohintsResult, DomainError>(result.Error);
		}
		return Result.Success<SearchAutohintsResult, DomainError>(result.Value);
	}
}
