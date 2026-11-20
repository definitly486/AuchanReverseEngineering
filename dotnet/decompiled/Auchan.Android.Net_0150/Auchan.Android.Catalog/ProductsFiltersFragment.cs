using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using Android.Graphics;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.Core.Widget;
using AndroidX.Fragment.App;
using AndroidX.RecyclerView.Widget;
using Auchan.Android.Base;
using Auchan.Android.Catalog.FilterItemViews;
using Auchan.Android.Common.UiUtils;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.DependencyInjection;
using Auchan.Common.Ecom.ProducModels.Filters;
using Auchan.Common.Ecom.Products.ViewModels.Filters;
using Auchan.Common.Extensions;
using DryIoc;
using Google.Flexbox;

namespace Auchan.Android.Catalog;

internal sealed class ProductsFiltersFragment : BaseBottomSheetDialogFragment<ProductFiltersViewModel>
{
	private RecyclerView? _filtersRecycler;

	private NestedScrollView? _nestedScrollView;

	private RecyclerView? _selectedFiltersRecycler;

	protected override bool FullScreen => true;

	public override int Theme => 2131951914;

	protected override int LayoutId => 2131493078;

	public ProductsFiltersFragment(Func<BrokerToken, ProductFiltersViewModel> newViewModel)
		: base((Func<Fragment, ProductFiltersViewModel>)((Fragment thisFragment) => newViewModel(thisFragment.RequireNavToken())))
	{
	}

	public override void OnViewCreated(View view, Bundle? savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		TextView textView = view.RequireViewById<TextView>(2131298655);
		ImageView imageView = view.RequireViewById<ImageView>(2131296795);
		_nestedScrollView = view.RequireViewById<NestedScrollView>(2131297660);
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
		ObservableRecyclerAdapter<BaseProductFilterItemViewModel, CachingViewHolder> filtersAdapter = new ObservableRecyclerAdapter<BaseProductFilterItemViewModel, CachingViewHolder>
		{
			GetItemViewTypeDelegate = (int position) => position,
			CreateViewHolderDelegate = OnCreateFilterView,
			DataSource = base.ViewModel.Filters,
			BindViewHolderDelegate = OnBindFilter
		};
		_filtersRecycler.SetAdapter(filtersAdapter);
		Button applyButton = view.RequireViewById<Button>(2131296454);
		textView.Text = base.ViewModel.Title;
		((ViewGroup)view.Parent)?.SetBackgroundColor(Color.Transparent);
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[5]
		{
			(delegate
			{
				applyButton.Text = base.ViewModel.ApplyText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ApplyText")),
			(delegate
			{
				applyButton.Enabled = base.ViewModel.ApplyAvailable;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ApplyAvailable")),
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
				OnWaitingToResponseChanged(base.ViewModel.IsWaitingForResponse);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsWaitingForResponse"))
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.BindEvents(applyButton.OnClick(base.ViewModel.ApplyFiltersCommand.Trigger), imageView.OnClick(base.ViewModel.CloseCommand.Trigger)).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.CloseCommand.SafeSubscribe(delegate
		{
			Dismiss();
		}, ViewLifecycleOwner);
		base.ViewModel.OpenMultiCheckCommand.SafeSubscribe(OpenMulticheckFilter, ViewLifecycleOwner);
		base.ViewModel.OpenRadioCheckCommand.SafeSubscribe(OpenRadioFilter, ViewLifecycleOwner);
	}

	private void OnWaitingToResponseChanged(bool isWaitingForResponse)
	{
		if (!isWaitingForResponse)
		{
			_nestedScrollView?.SmoothScrollTo(0, 0);
		}
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
		viewHolder.ItemView.OnClick((Action)delegate
		{
			base.ViewModel.SelectedFilterSelectedCommand.Trigger(itemViewModel);
		}).AddTo(disposables);
	}

	private CachingViewHolder OnCreateFilterView(ViewGroup recyclerView, int position)
	{
		BaseProductFilterItemViewModel baseProductFilterItemViewModel = base.ViewModel.Filters.ElementAtOrDefault(position);
		if (baseProductFilterItemViewModel == null)
		{
			throw new InvalidOperationException($"not found filter at position {position}");
		}
		CachingViewHolder cachingViewHolder = baseProductFilterItemViewModel.Filter.Type switch
		{
			ProductFilterType.Range => new CachingViewHolder(new RangeFilterItemView(Context)), 
			ProductFilterType.Check => new CachingViewHolder(new CheckFilterItemView(Context)), 
			ProductFilterType.Radio => new CachingViewHolder(new RadioFilterItemView(Context)), 
			ProductFilterType.MultiCheck => new CachingViewHolder(new MulticheckFilterItemView(Context)), 
			_ => throw new InvalidOperationException($"got filter of unknown type {baseProductFilterItemViewModel.Filter.Type}"), 
		};
		cachingViewHolder.ItemView.LayoutParameters = new ViewGroup.LayoutParams(recyclerView.LayoutParameters);
		return cachingViewHolder;
	}

	private void OnBindFilter(CachingViewHolder viewHolder, BaseProductFilterItemViewModel itemViewModel, int index, CompositeDisposable disposables)
	{
		View itemView = viewHolder.ItemView;
		if (!(itemView is RangeFilterItemView rangeFilterItemView))
		{
			if (!(itemView is CheckFilterItemView checkFilterItemView))
			{
				if (!(itemView is RadioFilterItemView radioFilterItemView))
				{
					if (itemView is MulticheckFilterItemView multicheckFilterItemView && itemViewModel is ProductMultiCheckFilterItemViewModel itemViewModel2)
					{
						multicheckFilterItemView.Bind(itemViewModel2, base.ViewModel, disposables);
					}
				}
				else if (itemViewModel is ProductRadioFilterItemViewModel itemViewModel3)
				{
					radioFilterItemView.Bind(itemViewModel3, base.ViewModel, disposables);
				}
			}
			else if (itemViewModel is ProductCheckFilterItemViewModel itemViewModel4)
			{
				checkFilterItemView.Bind(itemViewModel4, base.ViewModel, disposables);
			}
		}
		else if (itemViewModel is ProductRangeFilterItemViewModel itemViewModel5)
		{
			rangeFilterItemView.Bind(itemViewModel5, base.ViewModel, disposables);
		}
	}

	private void OpenMulticheckFilter(BrokerToken parameter)
	{
		ProductsFilterMulticheckFragment productsFilterMulticheckFragment = DI.ResolverBecauseConstructorInjectionIsNotPossible.Resolve<FragmentFactory>().Instantiate<ProductsFilterMulticheckFragment>();
		productsFilterMulticheckFragment.Arguments = parameter.ToNavBundle();
		productsFilterMulticheckFragment.Show(base.ChildFragmentManager, null);
	}

	private void OpenRadioFilter(BrokerToken parameter)
	{
		ProductsFilterRadioFragment productsFilterRadioFragment = DI.ResolverBecauseConstructorInjectionIsNotPossible.Resolve<FragmentFactory>().Instantiate<ProductsFilterRadioFragment>();
		productsFilterRadioFragment.Arguments = parameter.ToNavBundle();
		productsFilterRadioFragment.Show(base.ChildFragmentManager, null);
	}
}
