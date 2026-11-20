using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Auchan.Common.Base;
using Auchan.Common.Common.Binding;
using Auchan.Common.Ecom.Search.FilterViewModels;
using Auchan.Common.Ecom.Search.Infrastructure;
using Auchan.Common.Ecom.Search.Models;
using Auchan.Common.Extensions;

namespace Auchan.Common.Ecom.Search;

public class SearchMultiCheckFilterViewModel : ScreenViewModel
{
	public class Parameter
	{
		public string FilterCode { get; set; }

		public Parameter(string filterCode)
		{
			FilterCode = filterCode;
		}
	}

	public class MultiCheckItemViewModel
	{
		public SearchFilterMultiItem Option { get; set; }

		public string Title => Option.Name;

		public string Count => $"{Option.Counter}";

		public MultiCheckItemViewModel(SearchFilterMultiItem option)
		{
			Option = option;
		}
	}

	private readonly Parameter _parameter;

	private readonly MultiCheckFilterItemViewModel? _filter;

	private string _searchQuery = string.Empty;

	[CompilerGenerated]
	private List<MultiCheckItemViewModel> _003CAllOptions_003Ek__BackingField;

	[CompilerGenerated]
	private ObservableRangeCollection<MultiCheckItemViewModel> _003COptions_003Ek__BackingField;

	[CompilerGenerated]
	private ObservableRangeCollection<string> _003CSelectedItemCodes_003Ek__BackingField;

	[CompilerGenerated]
	private UICommand _003CCloseCommand_003Ek__BackingField;

	[CompilerGenerated]
	private UICommand<MultiCheckItemViewModel> _003CToggleOptionCommand_003Ek__BackingField;

	[CompilerGenerated]
	private UICommand _003CApplyCommand_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CNotFound_003Ek__BackingField;

	private List<MultiCheckItemViewModel> AllOptions
	{
		[CompilerGenerated]
		get
		{
			return _003CAllOptions_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!object.Equals(_003CAllOptions_003Ek__BackingField, value))
			{
				_003CAllOptions_003Ek__BackingField = value;
				RaisePropertyChanged("AllOptions");
			}
		}
	} = new List<MultiCheckItemViewModel>();

	public ObservableRangeCollection<MultiCheckItemViewModel> Options
	{
		[CompilerGenerated]
		get
		{
			return _003COptions_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003COptions_003Ek__BackingField, value))
			{
				_003COptions_003Ek__BackingField = value;
				RaisePropertyChanged("Options");
			}
		}
	} = new ObservableRangeCollection<MultiCheckItemViewModel>();

	public ObservableRangeCollection<string> SelectedItemCodes
	{
		[CompilerGenerated]
		get
		{
			return _003CSelectedItemCodes_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003CSelectedItemCodes_003Ek__BackingField, value))
			{
				_003CSelectedItemCodes_003Ek__BackingField = value;
				RaisePropertyChanged("SelectedItemCodes");
			}
		}
	} = new ObservableRangeCollection<string>();

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

	public UICommand ClearOptionsCommand { get; } = new UICommand();

	public UICommand<MultiCheckItemViewModel> ToggleOptionCommand
	{
		[CompilerGenerated]
		get
		{
			return _003CToggleOptionCommand_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003CToggleOptionCommand_003Ek__BackingField, value))
			{
				_003CToggleOptionCommand_003Ek__BackingField = value;
				RaisePropertyChanged("ToggleOptionCommand");
			}
		}
	} = new UICommand<MultiCheckItemViewModel>();

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

	public string SearchQuery
	{
		get
		{
			return _searchQuery;
		}
		set
		{
			if (string.Equals(_searchQuery, value, StringComparison.Ordinal))
			{
				return;
			}
			_searchQuery = value;
			if (string.IsNullOrWhiteSpace(_searchQuery))
			{
				Options.ReplaceRange(AllOptions);
			}
			else
			{
				Options.ReplaceRange(AllOptions.Where((MultiCheckItemViewModel o) => o.Title.ContainsIgnoreCase(_searchQuery)));
			}
			NotFound = !Options.Any();
			RaisePropertyChanged("SearchQuery");
		}
	}

	public string Title => _filter?.Filter?.Name ?? string.Empty;

	public string ApplyText => "Применить";

	public string ResetText => "Сбросить";

	public string SearchPlaceholder => "Поиск";

	public string NotFoundText => "По вашему запросу ничего не найдено";

	public bool NotFound
	{
		[CompilerGenerated]
		get
		{
			return _003CNotFound_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CNotFound_003Ek__BackingField != value)
			{
				_003CNotFound_003Ek__BackingField = value;
				RaisePropertyChanged("NotFound");
			}
		}
	}

	public SearchMultiCheckFilterViewModel(Parameter parameter, SearchProductsRepository searchRepository)
	{
		_parameter = parameter;
		_filter = searchRepository.CurrentSearchFiltersCopy.FirstOrDefault((BaseFilterItemViewModel f) => f.Code == _parameter.FilterCode) as MultiCheckFilterItemViewModel;
		if (_filter != null)
		{
			SelectedItemCodes.AddRange(_filter.SelectedItems.Select((SearchFilterMultiItem i) => i.Code));
			SearchQuery = string.Empty;
			AllOptions.AddRange(_filter.Filter.Items.Select((SearchFilterMultiItem item) => new MultiCheckItemViewModel(item)));
			Options.ReplaceRange(AllOptions);
			ClearOptionsCommand.Subscribe(delegate
			{
				ClearOptions();
			}).AddTo(base.CloseDisposable);
			ToggleOptionCommand.Subscribe(delegate(MultiCheckItemViewModel option)
			{
				ToggleOption(option.Option);
			}).AddTo(base.CloseDisposable);
			ApplyCommand.Subscribe(delegate
			{
				_filter.SetSelectedCodes(SelectedItemCodes);
				CloseCommand.Trigger();
			}).AddTo(base.CloseDisposable);
		}
	}

	protected override Task Start()
	{
		if (_filter == null)
		{
			CloseCommand.Trigger();
		}
		return base.Start();
	}

	private void ToggleOption(SearchFilterMultiItem option)
	{
		if (SelectedItemCodes.Contains(option.Code))
		{
			SelectedItemCodes.Remove(option.Code);
		}
		else
		{
			SelectedItemCodes.Add(option.Code);
		}
	}

	private void ClearOptions()
	{
		SelectedItemCodes.Clear();
	}
}
