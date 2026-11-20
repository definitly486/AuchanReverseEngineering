using System;
using System.Drawing;
using System.Reactive.Disposables;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.Fragment.App;
using AndroidX.RecyclerView.Widget;
using Auchan.Android.Base;
using Auchan.Android.Controls;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Profile.Orders;
using Auchan.Common.Profile.Orders.Models;
using Google.Android.Material.Button;

namespace Auchan.Android.Profile.Orders;

internal sealed class AddProductsToOrderPopupFragment : BaseBottomSheetDialogFragment<AddProductsToOrderPopupViewModel>
{
	public override int Theme => 2131951914;

	protected override int LayoutId => 2131493440;

	public AddProductsToOrderPopupFragment(Func<BrokerToken, AddProductsToOrderPopupViewModel> newViewModel)
		: base((Func<Fragment, AddProductsToOrderPopupViewModel>)((Fragment thisFragment) => newViewModel(thisFragment.RequireNavToken())))
	{
	}

	public override void OnViewCreated(View view, Bundle? savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		TextView textView = view.RequireViewById<TextView>(2131298646);
		ImageView imageView = view.RequireViewById<ImageView>(2131296789);
		LinearLayout linearLayout = view.RequireViewById<LinearLayout>(2131297362);
		TextView textView2 = view.RequireViewById<TextView>(2131297363);
		TextView textView3 = view.RequireViewById<TextView>(2131296858);
		RecyclerView recyclerView = view.RequireViewById<RecyclerView>(2131298188);
		TextView textView4 = view.RequireViewById<TextView>(2131298040);
		TextView textView5 = view.RequireViewById<TextView>(2131297664);
		ImageView hintImage = view.RequireViewById<ImageView>(2131297280);
		MaterialButton materialButton = view.RequireViewById<MaterialButton>(2131296361);
		ObservableRecyclerAdapter<AdditionalOrderProductItem, CachingViewHolder> observableRecyclerAdapter = new ObservableRecyclerAdapter<AdditionalOrderProductItem, CachingViewHolder>
		{
			DataSource = base.ViewModel.AvailableItems,
			CellLayoutId = 2131493208,
			BindViewHolderDelegate = OnBindItem
		};
		ObservableRecyclerAdapter<AdditionalOrderProductItem, CachingViewHolder> observableRecyclerAdapter2 = new ObservableRecyclerAdapter<AdditionalOrderProductItem, CachingViewHolder>
		{
			DataSource = base.ViewModel.UnavailableItems,
			CellLayoutId = 2131493209,
			BindViewHolderDelegate = OnBindUnavailableItem
		};
		recyclerView.SetAdapter(new ConcatAdapter(observableRecyclerAdapter, observableRecyclerAdapter2));
		base.ViewModel.BindEvents(((View)imageView).OnClick((Action)delegate
		{
			base.ViewModel.CloseCommand.Trigger();
		}), ((View)materialButton).OnClick((Action)delegate
		{
			base.ViewModel.AddToOrder();
		}), ((View)hintImage).OnClick((Action)delegate
		{
			ShowHintOnInformerIcon(hintImage);
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		textView.Text = base.ViewModel.Title;
		textView2.Text = base.ViewModel.InfoText;
		linearLayout.Visibility = base.ViewModel.InfoVisible.ToVisibility();
		textView3.Text = base.ViewModel.ProductsCount;
		textView4.Text = base.ViewModel.ProductsSum;
		textView5.Text = base.ViewModel.NewOrderPriceLabel;
		materialButton.Text = base.ViewModel.ButtonText;
		base.ViewModel.CloseCommand.SafeSubscribe(delegate
		{
			Dismiss();
		}, ViewLifecycleOwner);
	}

	private void OnBindItem(CachingViewHolder holder, AdditionalOrderProductItem vm, int position, CompositeDisposable disposable)
	{
		ImageView imageView = holder.RequireCachedView<ImageView>(2131297394);
		TextView textView = holder.RequireCachedView<TextView>(2131297398);
		TextView textView2 = holder.RequireCachedView<TextView>(2131297397);
		TextView textView3 = holder.RequireCachedView<TextView>(2131297990);
		TextView textView4 = holder.RequireCachedView<TextView>(2131296481);
		View view = holder.RequireCachedView<View>(2131298353);
		imageView.FromUrl(vm.ImageUrl);
		textView.Text = vm.Title;
		textView2.Text = vm.PriceText;
		textView3.Text = vm.PricePerItemWithCount;
		textView4.Text = vm.AvailableQty;
		textView4.Visibility = vm.AvailableQtyVisible.ToVisibility();
		view.Visibility = vm.IsSeparatorVisible.ToInvisibleVisibility();
	}

	private void OnBindUnavailableItem(CachingViewHolder holder, AdditionalOrderProductItem vm, int position, CompositeDisposable disposable)
	{
		TextView textView = holder.RequireCachedView<TextView>(2131297273);
		ImageView imageView = holder.RequireCachedView<ImageView>(2131297394);
		TextView textView2 = holder.RequireCachedView<TextView>(2131297398);
		View view = holder.RequireCachedView<View>(2131298353);
		imageView.FromUrl(vm.ImageUrl);
		textView.Visibility = (position == 0).ToVisibility();
		textView.Text = base.ViewModel.UnavailableItemsTitle;
		textView2.Text = vm.Title;
		view.Visibility = vm.IsSeparatorVisible.ToInvisibleVisibility();
	}

	private void ShowHintOnInformerIcon(View view)
	{
		AddProductsToOrderPopupViewModel viewModel = base.ViewModel;
		string hintText = base.ViewModel.HintText;
		Point offsetDp = new Point(0, -4);
		Size paddingDp = new Size(20, 0);
		HintPopup.Show(viewModel, hintText, view, offsetDp, atTop: true, checkAnchorVisibility: false, default(Size), paddingDp);
	}
}
