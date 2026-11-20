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

public class SearchRadioFilterViewModel : ScreenViewModel
{
	public class Parameter
	{
		public string FilterCode { get; set; }

		public Parameter(string filterCode)
		{
			FilterCode = filterCode;
		}
	}

	public class RadioItemViewModel
	{
		public SearchFilterMultiItem Option { get; set; }

		public string Title => Option.Name;

		public string Count => $"{Option.Counter}";

		public RadioItemViewModel(SearchFilterMultiItem option)
		{
			Option = option;
		}
	}

	private readonly Parameter _parameter;

	private readonly RadioFilterItemViewModel? _filter;

	private string _searchQuery = string.Empty;

	[CompilerGenerated]
	private List<RadioItemViewModel> _003CAllOptions_003Ek__BackingField;

	[CompilerGenerated]
	private ObservableRangeCollection<RadioItemViewModel> _003COptions_003Ek__BackingField;

	[CompilerGenerated]
	private UICommand _003CCloseCommand_003Ek__BackingField;

	[CompilerGenerated]
	private UICommand<RadioItemViewModel> _003CToggleOptionCommand_003Ek__BackingField;

	[CompilerGenerated]
	private UICommand _003CApplyCommand_003Ek__BackingField;

	[CompilerGenerated]
	private UICommand _003CClearOptionCommand_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CNotFound_003Ek__BackingField;

	[CompilerGenerated]
	private string? _003CSelectedItemCode_003Ek__BackingField;

	private List<RadioItemViewModel> AllOptions
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
	} = new List<RadioItemViewModel>();

	public ObservableRangeCollection<RadioItemViewModel> Options
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
	} = new ObservableRangeCollection<RadioItemViewModel>();

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

	public UICommand<RadioItemViewModel> ToggleOptionCommand
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
	} = new UICommand<RadioItemViewModel>();

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

	public UICommand ClearOptionCommand
	{
		[CompilerGenerated]
		get
		{
			return _003CClearOptionCommand_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003CClearOptionCommand_003Ek__BackingField, value))
			{
				_003CClearOptionCommand_003Ek__BackingField = value;
				RaisePropertyChanged("ClearOptionCommand");
			}
		}
	} = new UICommand();

	public string Title => _filter?.Filter?.Name ?? string.Empty;

	public string ApplyText => "Применить";

	public string ResetText => "Сбросить";

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

	public string? SelectedItemCode
	{
		[CompilerGenerated]
		get
		{
			return _003CSelectedItemCode_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CSelectedItemCode_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CSelectedItemCode_003Ek__BackingField = value;
				RaisePropertyChanged("SelectedItemCode");
			}
		}
	}

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
				Options.ReplaceRange(AllOptions.Where((RadioItemViewModel o) => o.Title.ContainsIgnoreCase(_searchQuery)));
			}
			NotFound = !Options.Any();
			RaisePropertyChanged("SearchQuery");
		}
	}

	public SearchRadioFilterViewModel(Parameter parameter, SearchProductsRepository searchRepository)
	{
		_parameter = parameter;
		_filter = searchRepository.CurrentSearchFiltersCopy.FirstOrDefault((BaseFilterItemViewModel f) => f.Code == _parameter.FilterCode) as RadioFilterItemViewModel;
		if (_filter == null)
		{
			return;
		}
		SelectedItemCode = _filter.SelectedItem?.Code;
		SearchQuery = string.Empty;
		AllOptions.AddRange(_filter.Filter.Items.Select((SearchFilterMultiItem item) => new RadioItemViewModel(item)));
		Options.ReplaceRange(AllOptions);
		ToggleOptionCommand.Subscribe(delegate(RadioItemViewModel option)
		{
			ToggleOption(option.Option);
		}).AddTo(base.CloseDisposable);
		ClearOptionCommand.Subscribe(delegate
		{
			SelectedItemCode = _parameter.FilterCode;
		}).AddTo(base.CloseDisposable);
		ApplyCommand.Subscribe(delegate
		{
			_filter.SelectedItem = _filter.Filter.Items.FirstOrDefault((SearchFilterMultiItem f) => f.Code == SelectedItemCode);
			CloseCommand.Trigger();
		});
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
		SelectedItemCode = option.Code;
	}
}
