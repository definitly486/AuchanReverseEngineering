using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AsyncAwaitBestPractices;
using Auchan.Common.Base;
using Auchan.Common.Common.Binding;
using Auchan.Common.Ecom.Search.Infrastructure;
using Auchan.Common.Extensions;

namespace Auchan.Common.Ecom.Search;

public class SearchSortsViewModel : ScreenViewModel
{
	private readonly SearchProductsRepository _searchRepository;

	private readonly SearchProductsManager _searchManager;

	[CompilerGenerated]
	private ObservableRangeCollection<SortItemViewModel> _003CSorts_003Ek__BackingField;

	[CompilerGenerated]
	private SortItemViewModel _003CSelectedSort_003Ek__BackingField;

	[CompilerGenerated]
	private UICommand _003CCloseCommand_003Ek__BackingField;

	[CompilerGenerated]
	private UICommand _003CApplyCommand_003Ek__BackingField;

	[CompilerGenerated]
	private UICommand<SortItemViewModel> _003CSelectSortCommand_003Ek__BackingField;

	public string Title => "Сортировка";

	public string ApplyText => "Применить";

	public ObservableRangeCollection<SortItemViewModel> Sorts
	{
		[CompilerGenerated]
		get
		{
			return _003CSorts_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003CSorts_003Ek__BackingField, value))
			{
				_003CSorts_003Ek__BackingField = value;
				RaisePropertyChanged("Sorts");
			}
		}
	} = new ObservableRangeCollection<SortItemViewModel>();

	public SortItemViewModel SelectedSort
	{
		[CompilerGenerated]
		get
		{
			return _003CSelectedSort_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003CSelectedSort_003Ek__BackingField, value))
			{
				_003CSelectedSort_003Ek__BackingField = value;
				RaisePropertyChanged("SelectedSort");
			}
		}
	}

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

	public UICommand ApplyCommand
	{
		[CompilerGenerated]
		get
		{
			return _003CApplyCommand_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003CApplyCommand_003Ek__BackingField, value))
			{
				_003CApplyCommand_003Ek__BackingField = value;
				RaisePropertyChanged("ApplyCommand");
			}
		}
	} = new UICommand();

	public UICommand<SortItemViewModel> SelectSortCommand
	{
		[CompilerGenerated]
		get
		{
			return _003CSelectSortCommand_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003CSelectSortCommand_003Ek__BackingField, value))
			{
				_003CSelectSortCommand_003Ek__BackingField = value;
				RaisePropertyChanged("SelectSortCommand");
			}
		}
	} = new UICommand<SortItemViewModel>();

	public SearchSortsViewModel(SearchProductsRepository repository, SearchProductsManager manager)
	{
		_searchRepository = repository;
		_searchManager = manager;
		SelectedSort = _searchRepository.CurrentSearchSorts.First((SortItemViewModel s) => s.IsSelected);
	}

	protected override async Task Start()
	{
		await base.Start();
		RxTaskExtensions.StartWithDefault(_searchRepository.CurrentSearchSorts.CollectionChangedAsObservable()).Subscribe(delegate
		{
			Sorts.ReplaceRange(_searchRepository.CurrentSearchSorts);
			SelectedSort = _searchRepository.CurrentSearchSorts.FirstOrDefault((SortItemViewModel s) => s.IsSelected) ?? SelectedSort;
		}).AddTo(base.CloseDisposable);
		SelectSortCommand.PerformDebouncingTask(delegate(SortItemViewModel ivm)
		{
			SelectedSort = ivm;
			return Task.CompletedTask;
		}).Subscribe().AddTo(base.CloseDisposable);
		ApplyCommand.Subscribe(delegate
		{
			SortItemViewModel sortItemViewModel = _searchRepository.CurrentSearchSorts.FirstOrDefault((SortItemViewModel s) => s.IsSelected);
			if (sortItemViewModel != null && sortItemViewModel.Value == SelectedSort.Value)
			{
				CloseCommand.Trigger();
			}
			else
			{
				_searchRepository.CurrentSearchSorts.ForEach(delegate(SortItemViewModel s)
				{
					s.IsSelected = s.Value == SelectedSort.Value;
				});
				_searchManager.ProductsBySearchQuery().SafeFireAndForget((Action<Exception>)null, false);
				CloseCommand.Trigger();
			}
		}).AddTo(base.CloseDisposable);
	}
}
