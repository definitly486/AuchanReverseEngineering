using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.Fragment.App;
using AndroidX.RecyclerView.Widget;
using Auchan.Android.Base;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Ecom.Products.ViewModels;
using Auchan.Common.Extensions;

namespace Auchan.Android.Catalog;

internal class ProductsOrderDialogFragment : BaseBottomSheetDialogFragment<ProductsOrderViewModel>
{
	public override int Theme => 2131951914;

	protected override int LayoutId => 2131493005;

	public ProductsOrderDialogFragment(Func<BrokerToken, ProductsOrderViewModel> newViewModel)
		: base((Func<Fragment, ProductsOrderViewModel>)((Fragment thisFragment) => newViewModel(thisFragment.RequireNavToken())))
	{
	}

	public override void OnCreate(Bundle? savedInstanceState)
	{
		base.OnCreate(savedInstanceState);
		base.ViewModel.CloseDialogCommand.SafeSubscribe(delegate
		{
			Dismiss();
		}, this);
	}

	public override void OnViewCreated(View view, Bundle? savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		TextView textView = view.RequireViewById<TextView>(2131298646);
		ImageView imageView = view.RequireViewById<ImageView>(2131296795);
		RecyclerView recyclerView = view.RequireViewById<RecyclerView>(2131298188);
		Button button = view.RequireViewById<Button>(2131296454);
		textView.Text = base.ViewModel.Title;
		button.Text = base.ViewModel.ApplyButtonTitle;
		ObservableRecyclerAdapter<string, CachingViewHolder> adapter = new ObservableRecyclerAdapter<string, CachingViewHolder>
		{
			CellLayoutId = 2131493225,
			BindViewHolderDelegate = BindOrderOption,
			DataSource = base.ViewModel.OrderOptions
		};
		recyclerView.SetLayoutManager(new LinearLayoutManager(Context));
		recyclerView.SetAdapter(adapter);
		base.ViewModel.BindEvents(button.OnClick(base.ViewModel.ApplyButtonClick), imageView.OnClick(base.ViewModel.CloseButtonClick)).AutoDisposeOnDestroy(ViewLifecycleOwner);
	}

	private void BindOrderOption(CachingViewHolder vh, string item, int index, CompositeDisposable disposable)
	{
		CheckBox checkbox = vh.RequireCachedView<CheckBox>(2131296768);
		checkbox.Text = item;
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlySingleElementList<(Action, IReadOnlyList<string>)>((delegate
		{
			checkbox.Checked = item == base.ViewModel.SelectedValue;
		}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("SelectedValue")))).AddTo(disposable);
		base.ViewModel.BindEvents(vh.ItemView.OnClick((Action)delegate
		{
			base.ViewModel.SelectedValue = item;
		})).AddTo(disposable);
	}
}
