using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Disposables;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AsyncAwaitBestPractices;
using Auchan.Common.Base;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Common.Binding;
using Auchan.Common.Ecom.Search.FilterViewModels;
using Auchan.Common.Ecom.Search.Infrastructure;
using Auchan.Common.Ecom.Search.Models;
using Auchan.Common.Extensions;
using Auchan.Common.Helpers;
using CSharpFunctionalExtensions;
using EBind;

namespace Auchan.Common.Ecom.Search;

public class SearchFiltersViewModel : ScreenViewModel
{
	private readonly SearchProductsRepository _searchRepository;

	private readonly SearchProductsManager _searchManager;

	private CompositeDisposable? _filtersDisposable;

	private volatile bool _pendingRequests = true;

	[CompilerGenerated]
	private string _003CApplyText_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CApplyAvailable_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CIsWaitingForResponse_003Ek__BackingField;

	[CompilerGenerated]
	private ObservableRangeCollection<SelectedFilterItemViewModel> _003CSelectedFilters_003Ek__BackingField;

	[CompilerGenerated]
	private ObservableRangeCollection<BaseFilterItemViewModel> _003CFilters_003Ek__BackingField;

	[CompilerGenerated]
	private UICommand _003CApplyFiltersCommand_003Ek__BackingField;

	[CompilerGenerated]
	private UICommand _003CCloseCommand_003Ek__BackingField;

	[CompilerGenerated]
	private UICommand<SelectedFilterItemViewModel> _003CSelectedFilterSelectedCommand_003Ek__BackingField;

	[CompilerGenerated]
	private UICommand<SearchMultiCheckFilterViewModel.Parameter, MultiCheckFilterItemViewModel> _003COpenMultiCheckCommand_003Ek__BackingField;

	[CompilerGenerated]
	private UICommand<SearchRadioFilterViewModel.Parameter, RadioFilterItemViewModel> _003COpenRadioCheckCommand_003Ek__BackingField;

	[CompilerGenerated]
	private UICommand _003CLoadProductCountCommand_003Ek__BackingField;

	public string Title => "Фильтр";

	public string ApplyText
	{
		[CompilerGenerated]
		get
		{
			return _003CApplyText_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CApplyText_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CApplyText_003Ek__BackingField = value;
				RaisePropertyChanged("ApplyText");
			}
		}
	} = "Применить";

	public bool ApplyAvailable
	{
		[CompilerGenerated]
		get
		{
			return _003CApplyAvailable_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CApplyAvailable_003Ek__BackingField != value)
			{
				_003CApplyAvailable_003Ek__BackingField = value;
				RaisePropertyChanged("ApplyAvailable");
			}
		}
	}

	public bool IsWaitingForResponse
	{
		[CompilerGenerated]
		get
		{
			return _003CIsWaitingForResponse_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CIsWaitingForResponse_003Ek__BackingField != value)
			{
				_003CIsWaitingForResponse_003Ek__BackingField = value;
				RaisePropertyChanged("IsWaitingForResponse");
			}
		}
	}

	public ObservableRangeCollection<SelectedFilterItemViewModel> SelectedFilters
	{
		[CompilerGenerated]
		get
		{
			return _003CSelectedFilters_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003CSelectedFilters_003Ek__BackingField, value))
			{
				_003CSelectedFilters_003Ek__BackingField = value;
				RaisePropertyChanged("SelectedFilters");
			}
		}
	} = new ObservableRangeCollection<SelectedFilterItemViewModel>();

	public ObservableRangeCollection<BaseFilterItemViewModel> Filters
	{
		[CompilerGenerated]
		get
		{
			return _003CFilters_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003CFilters_003Ek__BackingField, value))
			{
				_003CFilters_003Ek__BackingField = value;
				RaisePropertyChanged("Filters");
			}
		}
	} = new ObservableRangeCollection<BaseFilterItemViewModel>();

	public UICommand ApplyFiltersCommand
	{
		[CompilerGenerated]
		get
		{
			return _003CApplyFiltersCommand_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003CApplyFiltersCommand_003Ek__BackingField, value))
			{
				_003CApplyFiltersCommand_003Ek__BackingField = value;
				RaisePropertyChanged("ApplyFiltersCommand");
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

	public UICommand<SelectedFilterItemViewModel> SelectedFilterSelectedCommand
	{
		[CompilerGenerated]
		get
		{
			return _003CSelectedFilterSelectedCommand_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003CSelectedFilterSelectedCommand_003Ek__BackingField, value))
			{
				_003CSelectedFilterSelectedCommand_003Ek__BackingField = value;
				RaisePropertyChanged("SelectedFilterSelectedCommand");
			}
		}
	} = new UICommand<SelectedFilterItemViewModel>();

	public UICommand<SearchMultiCheckFilterViewModel.Parameter, MultiCheckFilterItemViewModel> OpenMultiCheckCommand
	{
		[CompilerGenerated]
		get
		{
			return _003COpenMultiCheckCommand_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003COpenMultiCheckCommand_003Ek__BackingField, value))
			{
				_003COpenMultiCheckCommand_003Ek__BackingField = value;
				RaisePropertyChanged("OpenMultiCheckCommand");
			}
		}
	} = new UICommand<SearchMultiCheckFilterViewModel.Parameter, MultiCheckFilterItemViewModel>((MultiCheckFilterItemViewModel filter) => new SearchMultiCheckFilterViewModel.Parameter(filter.Code));

	public UICommand<SearchRadioFilterViewModel.Parameter, RadioFilterItemViewModel> OpenRadioCheckCommand
	{
		[CompilerGenerated]
		get
		{
			return _003COpenRadioCheckCommand_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003COpenRadioCheckCommand_003Ek__BackingField, value))
			{
				_003COpenRadioCheckCommand_003Ek__BackingField = value;
				RaisePropertyChanged("OpenRadioCheckCommand");
			}
		}
	} = new UICommand<SearchRadioFilterViewModel.Parameter, RadioFilterItemViewModel>((RadioFilterItemViewModel filter) => new SearchRadioFilterViewModel.Parameter(filter.Code));

	private UICommand LoadProductCountCommand
	{
		[CompilerGenerated]
		get
		{
			return _003CLoadProductCountCommand_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!object.Equals(_003CLoadProductCountCommand_003Ek__BackingField, value))
			{
				_003CLoadProductCountCommand_003Ek__BackingField = value;
				RaisePropertyChanged("LoadProductCountCommand");
			}
		}
	} = new UICommand();

	public SearchFiltersViewModel(SearchProductsRepository repository, SearchProductsManager manager)
	{
		_searchRepository = repository;
		_searchManager = manager;
	}

	protected override async Task Start()
	{
		await base.Start();
		RxTaskExtensions.StartWithDefault(_searchRepository.GetSearchFiltersCopy().CollectionChangedAsObservable()).Subscribe(delegate
		{
			_filtersDisposable?.Dispose();
			_filtersDisposable = new CompositeDisposable();
			Filters.ReplaceRange(_searchRepository.CurrentSearchFiltersCopy);
			Filters.SelectNotNull((BaseFilterItemViewModel f) => f as MultiCheckFilterItemViewModel).ForEach(delegate(MultiCheckFilterItemViewModel ivm)
			{
				ivm.OpenMulticheckCommand.Subscribe(delegate
				{
					OpenMultiCheckCommand.Trigger(ivm);
				}).AddTo(_filtersDisposable);
			});
			Filters.SelectNotNull((BaseFilterItemViewModel f) => f as RadioFilterItemViewModel).ForEach(delegate(RadioFilterItemViewModel ivm)
			{
				ivm.OpenRadioCommand.Subscribe(delegate
				{
					OpenRadioCheckCommand.Trigger(ivm);
				}).AddTo(_filtersDisposable);
			});
			UpdateFilters(updateCount: false);
		}).AddTo(base.CloseDisposable);
		((IObservable<Unit>)ApplyFiltersCommand).PerformDebouncingTask((Func<Unit, Task>)delegate
		{
			if (!ApplyAvailable)
			{
				return Task.CompletedTask;
			}
			Filters.ForEach(delegate(BaseFilterItemViewModel f)
			{
				Tuple<string, object> selectedFilter = f.GetSelectedFilter();
				BaseFilterItemViewModel baseFilterItemViewModel = _searchRepository.CurrentSearchFilters.FirstOrDefault((BaseFilterItemViewModel x) => x.Filter.Code == f.Code);
				if (selectedFilter == null)
				{
					baseFilterItemViewModel?.ResetFilter();
				}
				else
				{
					baseFilterItemViewModel?.SetSelectedFilter(selectedFilter);
				}
			});
			_searchManager.ProductsBySearchQuery().SafeFireAndForget((Action<Exception>)null, false);
			CloseCommand.Trigger();
			return Task.CompletedTask;
		}, (IScheduler?)null).Subscribe().AddTo(base.CloseDisposable);
		SelectedFilterSelectedCommand.PerformDebouncingTask(delegate(SelectedFilterItemViewModel ivm)
		{
			if (ivm.IsDeleteAll)
			{
				_searchRepository.CurrentSearchFiltersCopy.ForEach(delegate(BaseFilterItemViewModel f)
				{
					f.ResetFilter();
				});
				Filters.ForEach(delegate(BaseFilterItemViewModel f)
				{
					f.ResetFilter();
				});
				UpdateFilters();
			}
			else
			{
				_searchRepository.CurrentSearchFiltersCopy.FirstOrDefault((BaseFilterItemViewModel f) => f.Code == ivm.Filter?.Code)?.ResetFilter();
				ivm.Filter?.ResetFilter(raiseFilterChanged: true);
			}
			return Task.CompletedTask;
		}).Subscribe().AddTo(base.CloseDisposable);
		LoadProductCountCommand.PerformDebouncingTask(LoadProductCount).Subscribe().AddTo(base.CloseDisposable);
		_searchRepository.FilterChanged += new DisposableDelegate<EventHandler<BaseFilterItemViewModel>>(delegate
		{
			UpdateFilters();
		}, delegate(EventHandler<BaseFilterItemViewModel> d)
		{
			_searchRepository.FilterChanged -= d;
		}).AddTo(base.CloseDisposable);
		UpdateApplyButton(_searchRepository.SearchResult.Count);
	}

	private void UpdateFilters(bool updateCount = true)
	{
		SelectedFilters.ReplaceRange(from filter in Filters
			where filter.GetSelectedFilter() != null
			select new SelectedFilterItemViewModel(filter) into filter
			orderby (int)filter.Filter.Filter.Type, filter.Filter.Filter.Sort
			select filter);
		if (SelectedFilters.Count > 0)
		{
			SelectedFilters.Add(new SelectedFilterItemViewModel(null));
		}
		if (updateCount)
		{
			_pendingRequests = true;
			LoadProductCountCommand.Trigger();
		}
	}

	private async Task LoadProductCount()
	{
		Result<SearchResult, DomainError> result = default(Result<SearchResult, DomainError>);
		ApplyAvailable = false;
		IsWaitingForResponse = true;
		while (_pendingRequests)
		{
			_pendingRequests = false;
			result = await _searchManager.ProductCountBySearchQuery(_searchRepository.CurrentSearchQuery, _searchRepository.CurrentSearchFiltersCopy);
		}
		IsWaitingForResponse = false;
		Result<int, DomainError> result2 = _searchManager.ProductCountBySearchResult(result);
		if (result2.IsFailure)
		{
			ApplyText = "Показать товары";
			ApplyAvailable = true;
		}
		else
		{
			UpdateApplyButton(result2.Value);
		}
		UpdateFilters(updateCount: false);
	}

	private void UpdateApplyButton(int count)
	{
		ApplyText = ((count < 1) ? "Товары не найдены" : ("Показать " + ((count > 1000) ? "1000+" : count.ToString()) + " товар" + GrammarHelper.DeclineNoun(count)));
		ApplyAvailable = count > 0;
	}
}
