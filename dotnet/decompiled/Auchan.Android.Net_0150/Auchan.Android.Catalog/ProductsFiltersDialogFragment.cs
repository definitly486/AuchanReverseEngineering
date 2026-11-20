using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.Widget;
using AndroidX.Fragment.App;
using AndroidX.RecyclerView.Widget;
using Auchan.Android.Base;
using Auchan.Android.Common.UiUtils;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Ecom.Products.ViewModels;
using Auchan.Common.Extensions;

namespace Auchan.Android.Catalog;

internal class ProductsFiltersDialogFragment : BaseBottomSheetDialogFragment<ProductsFilterViewModel>
{
	public override int Theme => 2131951914;

	protected override int LayoutId => 2131493004;

	public ProductsFiltersDialogFragment(Func<BrokerToken, ProductsFilterViewModel> newViewModel)
		: base((Func<Fragment, ProductsFilterViewModel>)((Fragment thisFragment) => newViewModel(thisFragment.RequireNavToken())))
	{
	}

	public override void OnCreate(Bundle savedInstanceState)
	{
		base.OnCreate(savedInstanceState);
		base.ViewModel.CloseDialogCommand.SafeSubscribe(delegate
		{
			Dismiss();
		}, this);
	}

	public override void OnViewCreated(View view, Bundle savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		View view2 = view.RequireViewById<View>(2131296904);
		TextView textView = view2.RequireViewById<TextView>(2131298655);
		TextView textView2 = view2.RequireViewById<TextView>(2131296795);
		RecyclerView recyclerView = view2.RequireViewById<RecyclerView>(2131297166);
		Button button = view2.RequireViewById<Button>(2131296454);
		TextView textView3 = view2.RequireViewById<TextView>(2131296783);
		textView.Text = base.ViewModel.Title;
		button.Text = base.ViewModel.ApplyButtonTitle;
		textView2.Text = base.ViewModel.CloseButtonTitle;
		textView3.Text = base.ViewModel.ClearButtonTitle;
		ObservableRecyclerAdapter<ProductsFilterItemViewModel, CachingViewHolder> adapter = new ObservableRecyclerAdapter<ProductsFilterItemViewModel, CachingViewHolder>
		{
			CellLayoutId = 2131493224,
			BindViewHolderDelegate = BindFilterOption,
			DataSource = base.ViewModel.FilterOptions
		};
		recyclerView.SetAdapter(adapter);
		textView3.SetOnClickListener(new ViewOnClickListener(base.ViewModel.ClearButtonClick).AutoDisposeOnDestroy(ViewLifecycleOwner));
		textView2.SetOnClickListener(new ViewOnClickListener(base.ViewModel.CloseButtonClick).AutoDisposeOnDestroy(ViewLifecycleOwner));
		button.SetOnClickListener(new ViewOnClickListener(base.ViewModel.ApplyButtonClick).AutoDisposeOnDestroy(ViewLifecycleOwner));
	}

	private void BindFilterOption(CachingViewHolder vh, ProductsFilterItemViewModel item, int index, CompositeDisposable disposable)
	{
		AppCompatCheckBox checkbox = vh.RequireCachedView<AppCompatCheckBox>(2131296768);
		TextView textView = vh.RequireCachedView<TextView>(2131297385);
		checkbox.Text = item.Title;
		textView.Text = item.Count.ToString();
		item.BindProperties(new global::_003C_003Ez__ReadOnlySingleElementList<(Action, IReadOnlyList<string>)>((delegate
		{
			checkbox.Checked = item.Selected;
		}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Selected")))).AddTo(disposable);
		vh.ItemView.SetOnClickListener(new ViewOnClickListener((Action)delegate
		{
			item.Selected = checkbox.Checked;
		}).AddTo(disposable));
		checkbox.SetOnClickListener(new ViewOnClickListener((Action)delegate
		{
			item.Selected = checkbox.Checked;
		}).AddTo(disposable));
	}
}
