using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.Fragment.App;
using AndroidX.RecyclerView.Widget;
using Auchan.Android.Base;
using Auchan.Android.Catalog.Search.FilterItemViews;
using Auchan.Android.Common.UiUtils;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.DependencyInjection;
using Auchan.Common.Ecom.Search;
using Auchan.Common.Ecom.Search.FilterViewModels;
using Auchan.Common.Extensions;
using DryIoc;
using Google.Flexbox;

namespace Auchan.Android.Catalog.Search;

internal class SearchProductsFiltersFragment : BaseDialogFragment<SearchFiltersViewModel>
{
	private RecyclerView _filtersRecycler;

	private RecyclerView _selectedFiltersRecycler;

	public override int Theme => 2131951914;

	protected override int LayoutId => 2131493089;

	public SearchProductsFiltersFragment(Func<Fragment, SearchFiltersViewModel> newViewModel)
		: base(newViewModel)
	{
	}

	public override void OnViewCreated(View view, Bundle savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		TextView textView = view.RequireViewById<TextView>(2131298655);
		ImageView imageView = view.RequireViewById<ImageView>(2131296795);
		_selectedFiltersRecycler = view.RequireViewById<RecyclerView>(2131298338);
		_selectedFiltersRecycler.SetLayoutManager(new FlexboxLayoutManager(Context));
		ObservableRecyclerAdapter<SelectedFilterItemViewModel, CachingViewHolder> selectedFiltersAdapter = new ObservableRecyclerAdapter<SelectedFilterItemViewModel, CachingViewHolder>
		{
			CellLayoutId = 2131493338,
			DataSource = base.ViewModel.SelectedFilters,
			BindViewHolderDelegate = OnBindSelectedFilter
		};
		_selectedFiltersRecycler.AddItemDecoration(new GridSpacesItemDecoration2(8, 8));
		_selectedFiltersRecycler.SetAdapter(selectedFiltersAdapter);
		_filtersRecycler = view.RequireViewById<RecyclerView>(2131297173);
		_filtersRecycler.SetLayoutManager(new LinearLayoutManager(Context));
		ObservableRecyclerAdapter<BaseFilterItemViewModel, CachingViewHolder> filtersAdapter = new ObservableRecyclerAdapter<BaseFilterItemViewModel, CachingViewHolder>
		{
			GetItemViewTypeDelegate = (int position) => position,
			CreateViewHolderDelegate = OnCreateFilterView,
			DataSource = base.ViewModel.Filters,
			BindViewHolderDelegate = OnBindFilter
		};
		_filtersRecycler.SetAdapter(filtersAdapter);
		Button applyButton = view.RequireViewById<Button>(2131296454);
		textView.Text = base.ViewModel.Title;
		applyButton.SetOnClickListener(new ViewOnClickListener(base.ViewModel.ApplyFiltersCommand.Trigger).AutoDisposeOnDestroy(ViewLifecycleOwner));
		imageView.SetOnClickListener(new ViewOnClickListener(base.ViewModel.CloseCommand.Trigger).AutoDisposeOnDestroy(ViewLifecycleOwner));
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[4]
		{
			(delegate
			{
				selectedFiltersAdapter.DataSource = base.ViewModel.SelectedFilters;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("SelectedFilters")),
			(delegate
			{
				filtersAdapter.DataSource = base.ViewModel.Filters;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Filters")),
			(delegate
			{
				applyButton.Enabled = base.ViewModel.ApplyAvailable;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ApplyAvailable")),
			(delegate
			{
				applyButton.Text = base.ViewModel.ApplyText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ApplyText"))
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.CloseCommand.SafeSubscribe(delegate
		{
			Dismiss();
		}, ViewLifecycleOwner);
		base.ViewModel.OpenMultiCheckCommand.SafeSubscribe(OpenMulticheckFilter, ViewLifecycleOwner);
		base.ViewModel.OpenRadioCheckCommand.SafeSubscribe(OpenRadioFilter, ViewLifecycleOwner);
	}

	private void OnBindSelectedFilter(CachingViewHolder viewHolder, SelectedFilterItemViewModel itemViewModel, int index, CompositeDisposable disposables)
	{
		TextView textView = viewHolder.RequireCachedView<TextView>(2131298646);
		ImageView imageView = viewHolder.RequireCachedView<ImageView>(2131296783);
		textView.SetColorSpan(Context, itemViewModel.Text, itemViewModel.HightlightedText, 2131099706);
		if (itemViewModel.IsDeleteAll)
		{
			viewHolder.ItemView.SetBackgroundResource(2131230943);
			imageView.SetImageResource(2131231346);
		}
		else
		{
			viewHolder.ItemView.SetBackgroundResource(2131230942);
			imageView.SetImageResource(2131231345);
		}
		viewHolder.ItemView.SetOnClickListener(new ViewOnClickListener((Action)delegate
		{
			base.ViewModel.SelectedFilterSelectedCommand.Trigger(itemViewModel);
		}).AddTo(disposables));
	}

	private CachingViewHolder OnCreateFilterView(ViewGroup recyclerView, int position)
	{
		BaseFilterItemViewModel baseFilterItemViewModel = base.ViewModel.Filters.ElementAtOrDefault(position);
		if (baseFilterItemViewModel == null)
		{
			return null;
		}
		CachingViewHolder cachingViewHolder = null;
		switch (baseFilterItemViewModel.Filter.Type)
		{
		case SearchFilterType.Range:
			cachingViewHolder = new CachingViewHolder(new RangeFilterItemView(Context));
			break;
		case SearchFilterType.Check:
			cachingViewHolder = new CachingViewHolder(new CheckFilterItemView(Context));
			break;
		case SearchFilterType.Radio:
			cachingViewHolder = new CachingViewHolder(new RadioFilterItemView(Context));
			break;
		case SearchFilterType.MultiCheck:
			cachingViewHolder = new CachingViewHolder(new MulticheckFilterItemView(Context));
			break;
		}
		if (cachingViewHolder != null)
		{
			cachingViewHolder.ItemView.LayoutParameters = new ViewGroup.LayoutParams(recyclerView.LayoutParameters);
		}
		return cachingViewHolder;
	}

	private void OnBindFilter(CachingViewHolder viewHolder, BaseFilterItemViewModel itemViewModel, int index, CompositeDisposable disposables)
	{
		View itemView = viewHolder.ItemView;
		if (!(itemView is RangeFilterItemView rangeFilterItemView))
		{
			if (!(itemView is CheckFilterItemView checkFilterItemView))
			{
				if (!(itemView is RadioFilterItemView radioFilterItemView))
				{
					if (itemView is MulticheckFilterItemView multicheckFilterItemView && itemViewModel is MultiCheckFilterItemViewModel itemViewModel2)
					{
						multicheckFilterItemView.Bind(itemViewModel2, base.ViewModel, disposables);
					}
				}
				else if (itemViewModel is RadioFilterItemViewModel itemViewModel3)
				{
					radioFilterItemView.Bind(itemViewModel3, base.ViewModel, disposables);
				}
			}
			else if (itemViewModel is CheckFilterItemViewModel itemViewModel4)
			{
				checkFilterItemView.Bind(itemViewModel4, base.ViewModel, disposables);
			}
		}
		else if (itemViewModel is RangeFilterItemViewModel itemViewModel5)
		{
			rangeFilterItemView.Bind(itemViewModel5, base.ViewModel, disposables);
		}
	}

	private void OpenMulticheckFilter(SearchMultiCheckFilterViewModel.Parameter parameter)
	{
		SearchProductsFilterMulticheckFragment searchProductsFilterMulticheckFragment = DI.ResolverBecauseConstructorInjectionIsNotPossible.Resolve<FragmentFactory>().Instantiate<SearchProductsFilterMulticheckFragment>();
		searchProductsFilterMulticheckFragment.Arguments = parameter.ToNavBundle();
		searchProductsFilterMulticheckFragment.Show(base.ChildFragmentManager, null);
	}

	private void OpenRadioFilter(SearchRadioFilterViewModel.Parameter parameter)
	{
		SearchProductsFilterRadioFragment searchProductsFilterRadioFragment = DI.ResolverBecauseConstructorInjectionIsNotPossible.Resolve<FragmentFactory>().Instantiate<SearchProductsFilterRadioFragment>();
		searchProductsFilterRadioFragment.Arguments = parameter.ToNavBundle();
		searchProductsFilterRadioFragment.Show(base.ChildFragmentManager, null);
	}
}
