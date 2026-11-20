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
using Auchan.Common.Ecom.Cart;
using Auchan.Common.Ecom.Cart.ViewModels;

namespace Auchan.Android.Ecom.Cart;

internal sealed class SharedCartFragment : BaseBottomSheetDialogFragment<SharedCartViewModel>
{
	private sealed class Controls(View view)
	{
		public View View => view;

		public TextView Title { get; } = view.RequireViewById<TextView>(2131298646);

		public View Close { get; } = view.RequireViewById<View>(2131296789);

		public RecyclerView RecyclerView { get; } = view.RequireViewById<RecyclerView>(2131298187);

		public TextView CountTitle { get; } = view.RequireViewById<TextView>(2131296856);

		public TextView Count { get; } = view.RequireViewById<TextView>(2131296852);

		public TextView Total { get; } = view.RequireViewById<TextView>(2131298720);

		public TextView AddToCart { get; } = view.RequireViewById<TextView>(2131296347);

		public TextView Cancel { get; } = view.RequireViewById<TextView>(2131296612);
	}

	private sealed class ItemControls(CachingViewHolder holder)
	{
		public View View => holder.ItemView;

		public ImageView Image { get; } = holder.RequireCachedView<ImageView>(2131297319);

		public TextView Title { get; } = holder.RequireCachedView<TextView>(2131296685);

		public TextView PricePerItem { get; } = holder.RequireCachedView<TextView>(2131296686);

		public TextView Count { get; } = holder.RequireCachedView<TextView>(2131297401);

		public TextView Price { get; } = holder.RequireCachedView<TextView>(2131296684);

		public TextView OldPrice { get; } = holder.RequireCachedView<TextView>(2131297737);

		public View OldPriceCrossingLine { get; } = holder.RequireCachedView<View>(2131297735);

		public View Separator { get; } = holder.RequireCachedView<View>(2131298353);
	}

	private sealed class ItemHeaderUnavialableItemsControls(CachingViewHolder holder)
	{
		public View View => holder.ItemView;

		public View Container { get; } = holder.RequireCachedView<View>(2131298776);

		public TextView Title { get; } = holder.RequireCachedView<TextView>(2131298777);
	}

	public override int Theme => 2131951914;

	protected override int LayoutId => 2131493492;

	protected override bool FullScreen => true;

	public SharedCartFragment(Func<BrokerToken, SharedCartViewModel> newViewModel)
		: base((Func<Fragment, SharedCartViewModel>)((Fragment thisFragment) => newViewModel(thisFragment.RequireNavToken())))
	{
	}

	public override void OnViewCreated(View view, Bundle? savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		Controls controls = new Controls(view);
		controls.Title.Text = base.ViewModel.TitleText;
		controls.CountTitle.Text = base.ViewModel.CountText;
		controls.AddToCart.Text = base.ViewModel.AddToCartText;
		controls.Cancel.Text = base.ViewModel.CancelText;
		ObservableRecyclerAdapter<SharedCartProductItemViewModel, CachingViewHolder> observableRecyclerAdapter = new ObservableRecyclerAdapter<SharedCartProductItemViewModel, CachingViewHolder>
		{
			DataSource = base.ViewModel.Available,
			CellLayoutId = 2131493340,
			BindViewHolderDelegate = OnBindItem,
			ClickCallback = delegate(CachingViewHolder h, SharedCartProductItemViewModel m, int p)
			{
				base.ViewModel.OnItemSelected(m);
			}
		};
		ObservableRecyclerAdapter<SharedCartViewModel, CachingViewHolder> observableRecyclerAdapter2 = new ObservableRecyclerAdapter<SharedCartViewModel, CachingViewHolder>
		{
			DataSource = new global::_003C_003Ez__ReadOnlySingleElementList<SharedCartViewModel>(base.ViewModel),
			CellLayoutId = 2131493341,
			BindViewHolderDelegate = OnBindUnavailableTitle
		};
		ObservableRecyclerAdapter<SharedCartProductItemViewModel, CachingViewHolder> observableRecyclerAdapter3 = new ObservableRecyclerAdapter<SharedCartProductItemViewModel, CachingViewHolder>
		{
			DataSource = base.ViewModel.Unavailable,
			CellLayoutId = 2131493340,
			BindViewHolderDelegate = OnBindItem,
			ClickCallback = delegate(CachingViewHolder h, SharedCartProductItemViewModel m, int p)
			{
				base.ViewModel.OnItemSelected(m);
			}
		};
		controls.RecyclerView.SetAdapter(new ConcatAdapter(observableRecyclerAdapter, observableRecyclerAdapter2, observableRecyclerAdapter3));
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[2]
		{
			(delegate
			{
				controls.Count.Text = base.ViewModel.Count;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Count")),
			(delegate
			{
				controls.Total.Text = base.ViewModel.TotalPrice;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("TotalPrice"))
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.BindEvents(controls.Close.OnClick(base.ViewModel.Dismiss), controls.Cancel.OnClick(base.ViewModel.Dismiss), controls.AddToCart.OnClick(base.ViewModel.AddToCart)).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.DismissCommand.SafeSubscribe(delegate
		{
			Dismiss();
		}, ViewLifecycleOwner);
	}

	private void OnBindUnavailableTitle(CachingViewHolder holder, SharedCartViewModel model, int position, CompositeDisposable disposable)
	{
		ItemHeaderUnavialableItemsControls itemHeaderUnavialableItemsControls = new ItemHeaderUnavialableItemsControls(holder);
		itemHeaderUnavialableItemsControls.Title.Text = model.UnavailableItemsTitle;
		itemHeaderUnavialableItemsControls.Container.Visibility = model.IsUnavailableVisibility.ToVisibility();
	}

	private void OnBindItem(CachingViewHolder holder, SharedCartProductItemViewModel vm, int position, CompositeDisposable disposable)
	{
		ItemControls itemControls = new ItemControls(holder);
		itemControls.Title.Text = vm.TitleText;
		itemControls.Image.FromUrlAnimated(vm.ImageUrl);
		itemControls.Image.Alpha = (vm.IsAvailable ? 1f : 0.5f);
		itemControls.Price.Text = vm.PriceText;
		itemControls.PricePerItem.Text = vm.PricePerItemText;
		itemControls.Price.Visibility = vm.IsAvailable.ToVisibility();
		itemControls.Count.Text = vm.CountText;
		TextView oldPrice = itemControls.OldPrice;
		ViewStates visibility = (itemControls.OldPriceCrossingLine.Visibility = vm.OldPriceVisible.ToVisibility());
		oldPrice.Visibility = visibility;
		itemControls.OldPrice.Text = vm.OldPriceText;
		itemControls.Separator.Visibility = vm.IsSeparatorVisible.ToInvisibleVisibility();
	}
}
