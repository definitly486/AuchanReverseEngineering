using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Common.Binding;
using Auchan.Common.Ecom.Address.Models;
using Auchan.Common.Extensions;

namespace Auchan.Common.Ecom.AddressStoreSelection.ViewModels;

public class RegionSelectorViewModel : ScreenViewModel<RegionSelectorViewModel.Parameter>
{
	public sealed class Parameter : BrokeredParameter<City?>
	{
		public required IEnumerable<City> Regions { get; init; }

		public required City Preselected { get; init; }

		public Parameter()
			: base(default(CancellationToken))
		{
		}
	}

	private City? _result;

	[CompilerGenerated]
	private City _003CSelectedRegion_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CSearchQuery_003Ek__BackingField;

	public string Title => "Выберите регион";

	public string SaveButtonText => "Сохранить";

	public string SearchPlaceholder => "Поиск";

	public IReadOnlyList<SelectionItemViewModel<City>> Regions { get; }

	public ObservableRangeCollection<SelectionItemViewModel<City>> FilteredRegions { get; }

	public string NotFoundText => "По вашему запросу ничего не найдено";

	public bool NotFound => !FilteredRegions.Any();

	public City SelectedRegion
	{
		[CompilerGenerated]
		get
		{
			return _003CSelectedRegion_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!object.Equals(_003CSelectedRegion_003Ek__BackingField, value))
			{
				_003CSelectedRegion_003Ek__BackingField = value;
				OnSelectedRegionChanged();
				RaisePropertyChanged("SelectedRegion");
			}
		}
	}

	public UICommand CloseCommand { get; } = new UICommand();

	public string SearchQuery
	{
		[CompilerGenerated]
		get
		{
			return _003CSearchQuery_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(_003CSearchQuery_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CSearchQuery_003Ek__BackingField = value;
				OnSearchQueryChanged();
				RaisePropertyChanged("SearchQuery");
			}
		}
	} = "";

	public RegionSelectorViewModel(BrokerToken token)
		: base(token)
	{
		Regions = base.Argument.Regions.Select((City i) => new SelectionItemViewModel<City>(i, selected: false)).ToImmutableList();
		FilteredRegions = new ObservableRangeCollection<SelectionItemViewModel<City>>(Regions);
		SelectedRegion = base.Argument.Preselected;
	}

	private void OnSelectedRegionChanged()
	{
		foreach (SelectionItemViewModel<City> region in Regions)
		{
			region.Selected = region.Item == SelectedRegion;
		}
	}

	public void Save()
	{
		_result = SelectedRegion;
		CloseCommand.Trigger();
	}

	public void Close()
	{
		CloseCommand.Trigger();
	}

	public override void Dispose()
	{
		base.Dispose();
		base.Argument.TaskCompletionSource.TrySetResult(_result);
	}

	private void OnSearchQueryChanged()
	{
		FilteredRegions.Clear();
		if (string.IsNullOrWhiteSpace(SearchQuery))
		{
			FilteredRegions.ReplaceRange(Regions);
		}
		else
		{
			FilteredRegions.ReplaceRange(Regions.Where((SelectionItemViewModel<City> o) => o.Item.Name.ContainsIgnoreCase(SearchQuery)));
		}
		RaisePropertyChanged("NotFound");
	}
}
