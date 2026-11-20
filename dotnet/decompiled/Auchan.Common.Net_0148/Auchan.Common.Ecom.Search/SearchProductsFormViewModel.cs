using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AsyncAwaitBestPractices;
using Auchan.Common.Analytics.YandexAppMetrica;
using Auchan.Common.Base;
using Auchan.Common.Common.Binding;
using Auchan.Common.Controls.AutoLayout;
using Auchan.Common.Ecom.Search.Infrastructure;
using Auchan.Common.Extensions;
using Auchan.Common.Helpers;
using Auchan.Common.Recommendations;
using Auchan.Common.Recommendations.Models;

namespace Auchan.Common.Ecom.Search;

public class SearchProductsFormViewModel : AutoLayoutScreenViewModel, IYandexMetricaScreenViewModel, IScreenViewModel
{
	public class Parameter
	{
		public string? Query { get; set; }

		public Parameter(string? query = null)
		{
			Query = query;
		}
	}

	public enum VisualState
	{
		Default,
		InProgress
	}

	private readonly Parameter _parameter;

	private readonly IEcomContext _ecomContext;

	private readonly SearchProductsManager _searchManager;

	private readonly SearchProductsRepository _searchRepository;

	private readonly SearchAutohintsService _autohintsService;

	private readonly SearchQueryHistoryRepository _historyRepository;

	private readonly Func<string, SearchFormHistoryItemViewModel> _searchHistoryItemFactory;

	private readonly Func<RecommendationBuilder> _recommendationBuilderFactory;

	[CompilerGenerated]
	private VisualState _003CState_003Ek__BackingField;

	private string _searchQuery = string.Empty;

	private bool _recommendationsViewed;

	public const int MinSearchQueryLength = 3;

	public const int MaxSearchQueryLength = 30;

	[CompilerGenerated]
	private UICommand _003CSearchCommand_003Ek__BackingField;

	[CompilerGenerated]
	private UICommand _003CClearCommand_003Ek__BackingField;

	[CompilerGenerated]
	private UICommand _003CCloseCommand_003Ek__BackingField;

	[CompilerGenerated]
	private UICommand _003CCloseFormCommand_003Ek__BackingField;

	[CompilerGenerated]
	private UICommand _003CCloseParentCommand_003Ek__BackingField;

	[CompilerGenerated]
	private UICommand _003CClearHistoryCommand_003Ek__BackingField;

	public VisualState State
	{
		[CompilerGenerated]
		get
		{
			return _003CState_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CState_003Ek__BackingField != value)
			{
				_003CState_003Ek__BackingField = value;
				RaisePropertyChanged("State");
			}
		}
	} = VisualState.InProgress;

	public string SearchPlaceholder => "Найти в АШАН";

	public string HistoryTitle => "Вы искали";

	public string RecommendationsTitle => "Часто ищут";

	public string CancelText => "Отменить";

	public string ClearText => "Очистить";

	public string ProgressTitle => "Ищем нужные товары…";

	public string SearchQuery
	{
		get
		{
			return _searchQuery;
		}
		set
		{
			if (!string.Equals(_searchQuery, value, StringComparison.Ordinal))
			{
				_searchQuery = value;
				RaisePropertyChanged("SearchQuery");
			}
		}
	}

	public bool AutofillsAvailable => Autofills.Count > 0;

	public ObservableRangeCollection<SearchAutofillItemViewModel> Autofills => _autohintsService.Autofills;

	public UICommand SearchCommand
	{
		[CompilerGenerated]
		get
		{
			return _003CSearchCommand_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003CSearchCommand_003Ek__BackingField, value))
			{
				_003CSearchCommand_003Ek__BackingField = value;
				RaisePropertyChanged("SearchCommand");
			}
		}
	} = new UICommand();

	public UICommand ClearCommand
	{
		[CompilerGenerated]
		get
		{
			return _003CClearCommand_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003CClearCommand_003Ek__BackingField, value))
			{
				_003CClearCommand_003Ek__BackingField = value;
				RaisePropertyChanged("ClearCommand");
			}
		}
	} = new UICommand();

	public UICommand CloseCommand
	{
		[CompilerGenerated]
		get
		{
			return _003CCloseCommand_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003CCloseCommand_003Ek__BackingField, value))
			{
				_003CCloseCommand_003Ek__BackingField = value;
				RaisePropertyChanged("CloseCommand");
			}
		}
	} = new UICommand();

	public UICommand CloseFormCommand
	{
		[CompilerGenerated]
		get
		{
			return _003CCloseFormCommand_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003CCloseFormCommand_003Ek__BackingField, value))
			{
				_003CCloseFormCommand_003Ek__BackingField = value;
				RaisePropertyChanged("CloseFormCommand");
			}
		}
	} = new UICommand();

	public UICommand CloseParentCommand
	{
		[CompilerGenerated]
		get
		{
			return _003CCloseParentCommand_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003CCloseParentCommand_003Ek__BackingField, value))
			{
				_003CCloseParentCommand_003Ek__BackingField = value;
				RaisePropertyChanged("CloseParentCommand");
			}
		}
	} = new UICommand();

	public UICommand ClearHistoryCommand
	{
		[CompilerGenerated]
		get
		{
			return _003CClearHistoryCommand_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003CClearHistoryCommand_003Ek__BackingField, value))
			{
				_003CClearHistoryCommand_003Ek__BackingField = value;
				RaisePropertyChanged("ClearHistoryCommand");
			}
		}
	} = new UICommand();

	public UICommand<SearchAutofillItemViewModel> SelectAutofillItemCommand { get; } = new UICommand<SearchAutofillItemViewModel>();

	public UICommand<SearchFormHistoryItemViewModel> SelectHistoryItemCommand { get; } = new UICommand<SearchFormHistoryItemViewModel>();

	public UICommand<SearchFormHistoryItemViewModel> ClearHistoryItemCommand { get; } = new UICommand<SearchFormHistoryItemViewModel>();

	public UICommand<SearchTextRecomItemViewModel> SelectRecomTextItemCommand { get; } = new UICommand<SearchTextRecomItemViewModel>();

	public UICommand<SearchCategoryRecomItemViewModel> SelectRecomCategoryItemCommand { get; } = new UICommand<SearchCategoryRecomItemViewModel>();

	public EndlessRecommendationsViewModel Recommendations { get; }

	string IYandexMetricaScreenViewModel.ScreenNameForBaseEvents => "Searchlist";

	string IYandexMetricaScreenViewModel.ScreenName => "Searchlist";

	public SearchProductsFormViewModel(Parameter parameter, IEcomContext ecomContext, SearchQueryHistoryRepository historyRepository, SearchProductsManager searchProductsManager, Func<string, SearchFormHistoryItemViewModel> searchHistoryItemFactory, Func<RecommendationBuilder> recommendationBuilderFactory, SearchProductsRepository searchProductsRepository, SearchAutohintsService autohintsService, EndlessRecommendationsViewModel recommendations)
	{
		_parameter = parameter;
		_ecomContext = ecomContext;
		_historyRepository = historyRepository;
		_searchManager = searchProductsManager;
		_searchHistoryItemFactory = searchHistoryItemFactory;
		_recommendationBuilderFactory = recommendationBuilderFactory;
		_searchRepository = searchProductsRepository;
		_autohintsService = autohintsService;
		Recommendations = recommendations.Setup(base.CloseDisposable, this, base.AutoLayout);
		SearchQuery = _parameter.Query ?? _searchRepository.CurrentSearchQuery;
	}

	protected override async Task Start()
	{
		State = VisualState.InProgress;
		await base.Start();
		LoadRecommendations().SafeFireAndForget((Action<Exception>)null, false);
		ObservableRangeCollection<string> history = await _historyRepository.GetSearchQueryHistory();
		history.CollectionChangedAsObservable().ObserveOn(MainThread.Scheduler).Subscribe(delegate
		{
			UpdateSearchSuggestions(history);
		})
			.AddTo(base.CloseDisposable);
		RxTaskExtensions.StartWithDefault(this.OnPropertyChanges((SearchProductsFormViewModel x) => x.SearchQuery).ObserveOn(MainThread.Scheduler)).PerformDebouncingTask((Func<string, Task>)async delegate
		{
			await _autohintsService.UpdateAutohints(SearchQuery);
			UpdateSearchSuggestions(history);
		}, (IScheduler?)null).Subscribe()
			.AddTo(base.CloseDisposable);
		SearchCommand.PerformDebouncingTask(Search).Subscribe().AddTo(base.CloseDisposable);
		SelectHistoryItemCommand.PerformDebouncingTask(HistoryItemSelected).Subscribe().AddTo(base.CloseDisposable);
		CloseCommand.ObserveOn(MainThread.Scheduler).Subscribe(delegate
		{
			if (string.IsNullOrWhiteSpace(_searchRepository.CurrentSearchQuery))
			{
				CloseParentCommand.Trigger();
			}
			else
			{
				CloseFormCommand.Trigger();
			}
		}).AddTo(base.CloseDisposable);
		ClearHistoryCommand.PerformDebouncingTask(ClearSearchHistory).Subscribe().AddTo(base.CloseDisposable);
		ClearHistoryItemCommand.PerformDebouncingTask(ClearSearchHistoryItem).Subscribe().AddTo(base.CloseDisposable);
		((IObservable<Unit>)ClearCommand).PerformDebouncingTask((Func<Unit, Task>)delegate
		{
			SearchQuery = string.Empty;
			return Task.CompletedTask;
		}, (IScheduler?)null).Subscribe().AddTo(base.CloseDisposable);
		SelectAutofillItemCommand.ObserveOn(MainThread.Scheduler).PerformDebouncingTask(AutofillItemSelected).Subscribe()
			.AddTo(base.CloseDisposable);
		SelectRecomTextItemCommand.PerformDebouncingTask(RecommendationItemSelected).Subscribe().AddTo(base.CloseDisposable);
		SelectRecomCategoryItemCommand.PerformDebouncingTask(RecommendationCategorySelected).Subscribe().AddTo(base.CloseDisposable);
		RxTaskExtensions.StartWithDefault(_autohintsService.Autofills.CollectionChangedAsObservable()).ObserveOn(MainThread.Scheduler).Subscribe(delegate
		{
			RaisePropertyChanged("AutofillsAvailable");
		})
			.AddTo(base.CloseDisposable);
		State = VisualState.Default;
	}

	private void UpdateSearchSuggestions(ObservableRangeCollection<string> history)
	{
		ImmutableArray<SearchFormHistoryItemViewModel> immutableArray = (from e in history.Select(_searchHistoryItemFactory)
			where e.Text.IndexOf(SearchQuery, StringComparison.OrdinalIgnoreCase) == 0
			select e).TakeSafe(3).ToImmutableArray();
		ImmutableArray<AutoLayoutViewModel.AutoLayoutElement> immutableArray2 = GetElementsToRemove("SearchFormHistoryHeader", "SearchFormHistoryItem").Concat(GetElementsToRemove("SearchFormPopularHeader", "SearchFormPopularItem")).Concat(GetElementsToRemove("SearchFormCategoryHeader", "SearchFormCategoryItem")).ToImmutableArray();
		ImmutableArray<AutoLayoutViewModel.AutoLayoutElement> immutableArray3 = GetElementsToAdd(immutableArray, "SearchFormHistoryHeader", "SearchFormHistoryItem", 1, 2).Concat(GetElementsToAdd(_autohintsService.PopularRecoms, "SearchFormPopularHeader", "SearchFormPopularItem", 3, 4)).Concat(GetElementsToAdd(_autohintsService.CategoryRecoms, "SearchFormCategoryHeader", "SearchFormCategoryItem", 5, 6)).ToImmutableArray();
		if (immutableArray2.Any())
		{
			base.AutoLayout.Elements.ReplaceRange(base.AutoLayout.Elements.IndexOf(immutableArray2.First()), immutableArray2.Count(), immutableArray3);
		}
		else
		{
			base.AutoLayout.InsertRange(immutableArray3);
		}
		static ImmutableArray<AutoLayoutViewModel.AutoLayoutElement> GetElementsToAdd(IEnumerable<object> vms, string headerType, string itemType, int headerOrder, int itemOrder)
		{
			IEnumerable<AutoLayoutViewModel.AutoLayoutElement> enumerable = vms.Select((object vm) => new AutoLayoutViewModel.AutoLayoutElement(itemType, vm, itemOrder));
			if (vms.Any())
			{
				enumerable = enumerable.Prepend(new AutoLayoutViewModel.AutoLayoutElement(headerType, new object(), headerOrder));
			}
			return enumerable.ToImmutableArray();
		}
		ImmutableArray<AutoLayoutViewModel.AutoLayoutElement> GetElementsToRemove(string headerType, string itemType)
		{
			return base.AutoLayout.Elements.Where((AutoLayoutViewModel.AutoLayoutElement e) => e.Type == headerType || e.Type == itemType).ToImmutableArray();
		}
	}

	private Task Search()
	{
		return Search(null);
	}

	private async Task Search(string? categoryCode)
	{
		State = VisualState.InProgress;
		_searchRepository.ClearSearchFilters();
		_searchRepository.ResetSearchSort();
		await _searchManager.ProductsBySearchQuery(SearchQuery, categoryCode, saveQuery: true, sendAnalytics: true);
		CloseCommand.Trigger();
	}

	private Task HistoryItemSelected(SearchFormHistoryItemViewModel item)
	{
		SearchQuery = item.Text;
		return Search();
	}

	private async Task ClearSearchHistory()
	{
		State = VisualState.InProgress;
		await _historyRepository.ClearSearchHistory();
		State = VisualState.Default;
	}

	private async Task ClearSearchHistoryItem(SearchFormHistoryItemViewModel item)
	{
		State = VisualState.InProgress;
		await _historyRepository.RemoveSearchHistoryItem(item.Text);
		State = VisualState.Default;
	}

	private Task AutofillItemSelected(SearchAutofillItemViewModel item)
	{
		SearchQuery = item.FullText;
		return Task.CompletedTask;
	}

	private Task RecommendationItemSelected(SearchTextRecomItemViewModel item)
	{
		SearchQuery = item.Title;
		return Search();
	}

	private Task RecommendationCategorySelected(SearchCategoryRecomItemViewModel item)
	{
		SearchQuery = item.Title;
		return Search(item.Code);
	}

	private async Task LoadRecommendations()
	{
		LoadRequest loadRequest = _recommendationBuilderFactory().AddPersonalViewedEndless("Вы смотрели", "SEARCH_PAGE_VIEWED").Build();
		await Recommendations.Load(loadRequest);
	}

	public void OnRecommendationsViewed()
	{
		if (!_recommendationsViewed)
		{
			_recommendationsViewed = true;
			Recommendations.Viewed();
		}
	}
}
