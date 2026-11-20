using System;
using System.Reactive.Disposables;
using Android.Graphics;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.Fragment.App;
using AndroidX.RecyclerView.Widget;
using Auchan.Android.Base;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.Ecom.ProducModels;
using Auchan.Common.Ecom.Products.ViewModels;

namespace Auchan.Android.Catalog;

internal sealed class AvailableShopsPopupFragment : BaseBottomSheetDialogFragment<AvailableShopsPopupViewModel>
{
	public override int Theme => 2131951914;

	protected override int LayoutId => 2131493451;

	protected override bool FullScreen => true;

	public AvailableShopsPopupFragment(Func<AvailableShopsPopupViewModel.Parameter, AvailableShopsPopupViewModel> newViewModel)
		: base((Func<Fragment, AvailableShopsPopupViewModel>)((Fragment thisFragment) => newViewModel(thisFragment.RequireNavParam<AvailableShopsPopupViewModel.Parameter>())))
	{
	}

	public override void OnCreate(Bundle? savedInstanceState)
	{
		base.OnCreate(savedInstanceState);
		base.ViewModel.CloseCommand.SafeSubscribe(delegate
		{
			Dismiss();
		}, this);
	}

	public override void OnViewCreated(View view, Bundle? savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		TextView textView = view.RequireViewById<TextView>(2131298659);
		View view2 = view.RequireViewById<View>(2131296795);
		view.RequireViewById<RecyclerView>(2131296483).SetAdapter(new ObservableRecyclerAdapter<AvailableShop, CachingViewHolder>
		{
			CellLayoutId = 2131493284,
			DataSource = base.ViewModel.AvailableShops,
			BindViewHolderDelegate = OnBindAvailableShops
		});
		textView.Text = base.ViewModel.Title;
		base.ViewModel.BindEvents(view2.OnClick(base.ViewModel.CloseCommand.Trigger)).AutoDisposeOnDestroy(ViewLifecycleOwner);
	}

	private void OnBindAvailableShops(CachingViewHolder holder, AvailableShop availableShop, int position, CompositeDisposable disposable)
	{
		TextView textView = holder.RequireCachedView<TextView>(2131298528);
		textView.Text = availableShop.Name;
		textView.Visibility = (string.IsNullOrEmpty(availableShop.Name) ? ViewStates.Gone : ViewStates.Visible);
		TextView textView2 = holder.RequireCachedView<TextView>(2131298523);
		textView2.Text = availableShop.AddressString;
		textView2.Visibility = (string.IsNullOrEmpty(availableShop.AddressString) ? ViewStates.Gone : ViewStates.Visible);
		TextView textView3 = holder.RequireCachedView<TextView>(2131298532);
		ImageView imageView = holder.RequireCachedView<ImageView>(2131298533);
		textView3.Text = availableShop.Working;
		ViewStates visibility = (imageView.Visibility = (string.IsNullOrEmpty(availableShop.Working) ? ViewStates.Gone : ViewStates.Visible));
		textView3.Visibility = visibility;
		TextView textView4 = holder.RequireCachedView<TextView>(2131298130);
		textView4.Text = availableShop.QtyText;
		textView4.Visibility = (string.IsNullOrEmpty(availableShop.QtyText) ? ViewStates.Gone : ViewStates.Visible);
		if (availableShop.IsLessOrEqualTwo)
		{
			textView4.SetTextColor(Color.ParseColor("#F06400"));
		}
		else
		{
			textView4.SetTextColor(Color.ParseColor("#00854D"));
		}
	}
}
