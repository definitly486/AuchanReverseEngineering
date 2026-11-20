using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using Auchan.Common.Ecom.ProducModels;
using Auchan.Common.Ecom.Search.FilterViewModels;
using Auchan.Common.Ecom.Search.Models;
using Auchan.Common.Extensions;
using Auchan.Common.Net;
using Newtonsoft.Json.Linq;

namespace Auchan.Common.Ecom.Search.Infrastructure;

public class SearchProductsRepository : INotifyPropertyChanged
{
	[CompilerGenerated]
	private string _003CCurrentSearchQuery_003Ek__BackingField;

	[CompilerGenerated]
	private SearchVisualState _003CCurrentSearchState_003Ek__BackingField;

	[CompilerGenerated]
	private SearchResult _003CSearchResult_003Ek__BackingField;

	[CompilerGenerated]
	private ObservableRangeCollection<Product> _003CCurrentSearchResults_003Ek__BackingField;

	[CompilerGenerated]
	private ObservableRangeCollection<BaseFilterItemViewModel> _003CCurrentSearchFilters_003Ek__BackingField;

	[CompilerGenerated]
	private ObservableRangeCollection<BaseFilterItemViewModel> _003CCurrentSearchFiltersCopy_003Ek__BackingField;

	[CompilerGenerated]
	private ObservableRangeCollection<SortItemViewModel> _003CCurrentSearchSorts_003Ek__BackingField;

	public string CurrentSearchQuery
	{
		[CompilerGenerated]
		get
		{
			return _003CCurrentSearchQuery_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CCurrentSearchQuery_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CCurrentSearchQuery_003Ek__BackingField = value;
				_003C_003EOnPropertyChanged(_003C_003EPropertyChangedEventArgs.CurrentSearchQuery);
			}
		}
	} = string.Empty;

	public SearchVisualState CurrentSearchState
	{
		[CompilerGenerated]
		get
		{
			return _003CCurrentSearchState_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CCurrentSearchState_003Ek__BackingField != value)
			{
				_003CCurrentSearchState_003Ek__BackingField = value;
				_003C_003EOnPropertyChanged(_003C_003EPropertyChangedEventArgs.CurrentSearchState);
			}
		}
	}

	public SearchResult SearchResult
	{
		[CompilerGenerated]
		get
		{
			return _003CSearchResult_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003CSearchResult_003Ek__BackingField, value))
			{
				_003CSearchResult_003Ek__BackingField = value;
				_003C_003EOnPropertyChanged(_003C_003EPropertyChangedEventArgs.SearchResult);
			}
		}
	} = new SearchResult();

	public ObservableRangeCollection<Product> CurrentSearchResults
	{
		[CompilerGenerated]
		get
		{
			return _003CCurrentSearchResults_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003CCurrentSearchResults_003Ek__BackingField, value))
			{
				_003CCurrentSearchResults_003Ek__BackingField = value;
				_003C_003EOnPropertyChanged(_003C_003EPropertyChangedEventArgs.CurrentSearchResults);
			}
		}
	} = new ObservableRangeCollection<Product>();

	public ObservableRangeCollection<BaseFilterItemViewModel> CurrentSearchFilters
	{
		[CompilerGenerated]
		get
		{
			return _003CCurrentSearchFilters_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003CCurrentSearchFilters_003Ek__BackingField, value))
			{
				_003CCurrentSearchFilters_003Ek__BackingField = value;
				_003C_003EOnPropertyChanged(_003C_003EPropertyChangedEventArgs.CurrentSearchFilters);
			}
		}
	} = new ObservableRangeCollection<BaseFilterItemViewModel>();

	public ObservableRangeCollection<BaseFilterItemViewModel> CurrentSearchFiltersCopy
	{
		[CompilerGenerated]
		get
		{
			return _003CCurrentSearchFiltersCopy_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003CCurrentSearchFiltersCopy_003Ek__BackingField, value))
			{
				_003CCurrentSearchFiltersCopy_003Ek__BackingField = value;
				_003C_003EOnPropertyChanged(_003C_003EPropertyChangedEventArgs.CurrentSearchFiltersCopy);
			}
		}
	} = new ObservableRangeCollection<BaseFilterItemViewModel>();

	public ObservableRangeCollection<SortItemViewModel> CurrentSearchSorts
	{
		[CompilerGenerated]
		get
		{
			return _003CCurrentSearchSorts_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003CCurrentSearchSorts_003Ek__BackingField, value))
			{
				_003CCurrentSearchSorts_003Ek__BackingField = value;
				_003C_003EOnPropertyChanged(_003C_003EPropertyChangedEventArgs.CurrentSearchSorts);
			}
		}
	} = new ObservableRangeCollection<SortItemViewModel>
	{
		new SortItemViewModel("По популярности", "default", isSelected: true),
		new SortItemViewModel("По рейтингу", "ratingdesc"),
		new SortItemViewModel("Сначала дешевле", "priceasc"),
		new SortItemViewModel("Сначала дороже", "pricedesc"),
		new SortItemViewModel("По размеру скидки", "discountPercent"),
		new SortItemViewModel("По размеру кэшбэка", "cashbackValue"),
		new SortItemViewModel("Сначала новинки", "isNew")
	};

	public event PropertyChangedEventHandler? PropertyChanged;

	public event EventHandler<BaseFilterItemViewModel>? FilterChanged;

	public void SetSearchResults(IReadOnlyList<Product> products)
	{
		CurrentSearchResults.ReplaceRange(products);
	}

	public void ClearSearchResults()
	{
		CurrentSearchResults.Clear();
		SearchResult = new SearchResult();
	}

	public void SetSearchResult(SearchResult result, ObservableRangeCollection<BaseFilterItemViewModel>? targetFilters = null)
	{
		if (targetFilters == null)
		{
			targetFilters = CurrentSearchFilters;
		}
		IReadOnlyList<SearchFilter> filters = result.Filters;
		SearchResult = result;
		if (filters.Count == targetFilters.Count && targetFilters.All((BaseFilterItemViewModel tf) => filters.Any((SearchFilter f) => f.Code == tf.Code)))
		{
			filters.ForEach(delegate(SearchFilter f)
			{
				targetFilters.FirstOrDefault((BaseFilterItemViewModel tf) => tf.Code == f.Code)?.SetFilter(f);
			});
			if (targetFilters.Count > 0)
			{
				OnFilterChanged(targetFilters.First());
			}
			return;
		}
		IOrderedEnumerable<BaseFilterItemViewModel> collection = from f in filters.SelectNotNull((SearchFilter f) => f.Type switch
			{
				SearchFilterType.Range => new RangeFilterItemViewModel(this, f), 
				SearchFilterType.Radio => new RadioFilterItemViewModel(this, f), 
				SearchFilterType.Check => new CheckFilterItemViewModel(this, f), 
				SearchFilterType.MultiCheck => new MultiCheckFilterItemViewModel(this, f), 
				_ => null, 
			}).Select(delegate(BaseFilterItemViewModel newFilter)
			{
				Tuple<string, object> tuple = targetFilters.FirstOrDefault((BaseFilterItemViewModel f) => f.Code == newFilter.Code)?.GetSelectedFilter();
				if (tuple != null)
				{
					newFilter.SetSelectedFilter(tuple);
				}
				return newFilter;
			})
			orderby (int)f.Filter.Type, f.Filter.Sort
			select f;
		targetFilters.ReplaceRange(collection);
	}

	public void RestoreSearchFilters(IReadOnlyDictionary<string, object> selectedFilters, ObservableRangeCollection<BaseFilterItemViewModel>? targetFilters = null)
	{
		if (targetFilters == null)
		{
			targetFilters = CurrentSearchFilters;
		}
		foreach (KeyValuePair<string, object> selectedFilter in selectedFilters)
		{
			BaseFilterItemViewModel baseFilterItemViewModel = targetFilters.FirstOrDefault((BaseFilterItemViewModel f) => f.Code == selectedFilter.Key);
			if (baseFilterItemViewModel == null)
			{
				continue;
			}
			switch (baseFilterItemViewModel.Filter.Type)
			{
			case SearchFilterType.Check:
				baseFilterItemViewModel.SetSelectedFilter(Tuple.Create(selectedFilter.Key, selectedFilter.Value));
				break;
			case SearchFilterType.Range:
			{
				string? s = (selectedFilter.Value as JArray)?.FirstOrDefault()?.ToObject<string>();
				string s2 = (selectedFilter.Value as JArray)?.LastOrDefault()?.ToObject<string>();
				if (int.TryParse(s, out var result) && int.TryParse(s2, out var result2))
				{
					baseFilterItemViewModel.SetSelectedFilter(Tuple.Create(selectedFilter.Key, (object)new int[2] { result, result2 }));
				}
				break;
			}
			case SearchFilterType.MultiCheck:
			{
				object value = selectedFilter.Value;
				if (!(value is JArray jArray))
				{
					if (value is string text)
					{
						baseFilterItemViewModel.SetSelectedFilter(Tuple.Create(selectedFilter.Key, (object)new string[1] { text }));
					}
				}
				else
				{
					object item2 = jArray.ToObject<string[]>();
					baseFilterItemViewModel.SetSelectedFilter(Tuple.Create(selectedFilter.Key, item2));
				}
				break;
			}
			case SearchFilterType.Radio:
			{
				object item = (selectedFilter.Value as JArray)?.ToObject<string[]>();
				baseFilterItemViewModel.SetSelectedFilter(Tuple.Create(selectedFilter.Key, item));
				break;
			}
			}
		}
	}

	public void ClearSearchFilters()
	{
		CurrentSearchFilters.Clear();
		CurrentSearchFiltersCopy.Clear();
	}

	public void ResetSearchSort()
	{
		CurrentSearchSorts.ForEach(delegate(SortItemViewModel s)
		{
			s.IsSelected = s.Value == "default";
		});
	}

	public ObservableRangeCollection<BaseFilterItemViewModel> GetSearchFiltersCopy()
	{
		CurrentSearchFiltersCopy.ReplaceRange(CurrentSearchFilters.Select((BaseFilterItemViewModel f) => f.Copy()));
		return CurrentSearchFiltersCopy;
	}

	public void SetSearchQuery(string query)
	{
		CurrentSearchQuery = query;
	}

	public void SetSearchState(SearchVisualState state)
	{
		CurrentSearchState = state;
	}

	public void OnFilterChanged(BaseFilterItemViewModel filter)
	{
		this.FilterChanged?.Invoke(this, filter);
	}

	[GeneratedCode("PropertyChanged.Fody", "4.1.0.0")]
	[DebuggerNonUserCode]
	protected void _003C_003EOnPropertyChanged(PropertyChangedEventArgs eventArgs)
	{
		this.PropertyChanged?.Invoke(this, eventArgs);
	}
}
