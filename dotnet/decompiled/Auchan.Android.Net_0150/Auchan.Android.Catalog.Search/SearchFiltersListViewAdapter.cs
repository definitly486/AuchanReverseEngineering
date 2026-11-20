using System.Collections.Generic;
using Android.Content;
using Android.Views;
using AndroidX.Lifecycle;
using Auchan.Android.Catalog.Search.FilterItemViews;
using Auchan.Android.Common;
using Auchan.Common.Ecom.Search;
using Auchan.Common.Ecom.Search.FilterViewModels;

namespace Auchan.Android.Catalog.Search;

public class SearchFiltersListViewAdapter : VariableItemsListViewAdapter<SearchFiltersViewModel, BaseFilterItemViewModel>
{
	public SearchFiltersListViewAdapter(Context context, SearchFiltersViewModel viewModel, ICollection<BaseFilterItemViewModel> itemViewModels, ILifecycleOwner viewLifecycleOwner)
		: base(context, viewModel, itemViewModels, viewLifecycleOwner)
	{
	}

	protected override View GetViewFromType(ViewGroup container, BaseFilterItemViewModel itemViewModel)
	{
		if (!(itemViewModel is CheckFilterItemViewModel viewModel))
		{
			if (!(itemViewModel is RangeFilterItemViewModel viewModel2))
			{
				if (!(itemViewModel is MultiCheckFilterItemViewModel viewModel3))
				{
					if (itemViewModel is RadioFilterItemViewModel viewModel4)
					{
						RadioFilterItemView radioFilterItemView = new RadioFilterItemView(_context);
						radioFilterItemView.Bind(viewModel4, _viewLifecycleOwner);
						return radioFilterItemView;
					}
					return new View(_context);
				}
				MulticheckFilterItemView multicheckFilterItemView = new MulticheckFilterItemView(_context);
				multicheckFilterItemView.Bind(viewModel3, _viewLifecycleOwner);
				return multicheckFilterItemView;
			}
			RangeFilterItemView rangeFilterItemView = new RangeFilterItemView(_context);
			rangeFilterItemView.Bind(viewModel2, _viewLifecycleOwner);
			return rangeFilterItemView;
		}
		CheckFilterItemView checkFilterItemView = new CheckFilterItemView(_context);
		checkFilterItemView.Bind(viewModel, _viewLifecycleOwner);
		return checkFilterItemView;
	}
}
