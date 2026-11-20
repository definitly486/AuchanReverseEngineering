using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using Android.Graphics;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.ConstraintLayout.Widget;
using AndroidX.Core.Content;
using AndroidX.Fragment.App;
using AndroidX.RecyclerView.Widget;
using Auchan.Android.Base;
using Auchan.Android.Catalog;
using Auchan.Android.Controls;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.Ecom.Products.ViewModels;
using Auchan.Common.LoyaltyProgram.Models;
using Auchan.Common.LoyaltyProgram.ViewModels.MyPurchase;
using Google.Android.Material.Card;
using VisibilitySwitch;

namespace Auchan.Android.LoyaltyProgram;

internal sealed class PurchaseDetailsFragment : BaseToolbarFragment<PurchaseDetailsViewModel>
{
	private sealed class Controls(View view)
	{
		public sealed class DefaultViewControls(View view)
		{
			public View View => view;

			public TextView StoreName { get; } = view.RequireViewById<TextView>(2131298520);

			public TextView StoreAddress { get; } = view.RequireViewById<TextView>(2131298488);

			public SumDetailsSectionViewControls SumDetailsSection { get; } = new SumDetailsSectionViewControls(view.RequireViewById<View>(2131298571));

			public TextView OrderQtyLabel { get; } = view.RequireViewById<TextView>(2131297792);

			public TextView DeliveryDateLabel { get; } = view.RequireViewById<TextView>(2131297773);

			public TextView DeliveryDateTextView { get; } = view.RequireViewById<TextView>(2131297774);
		}

		public View View => view;

		public DefaultViewControls Default { get; } = new DefaultViewControls(view.RequireViewById<LinearLayout>(2131296911));

		public View Progress { get; } = view.RequireViewById<FrameLayout>(2131298077);

		public ErrorLayoutComarchControls Error { get; } = new ErrorLayoutComarchControls(view.RequireViewById<ConstraintLayout>(2131297111));
	}

	protected override int LayoutId => 2131493485;

	protected override bool HasNavigationButton()
	{
		return true;
	}

	public PurchaseDetailsFragment(Func<PurchaseDetailsViewModel.Parameter, PurchaseDetailsViewModel> newViewModel)
		: base((Func<Fragment, PurchaseDetailsViewModel>)((Fragment thisFragment) => newViewModel(thisFragment.RequireNavParam<PurchaseDetailsViewModel.Parameter>())))
	{
	}

	public override void OnViewCreated(View view, Bundle? savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		Controls controls = new Controls(view);
		controls.Default.SumDetailsSection.Setup(base.ViewModel, ViewLifecycleOwner);
		VisibilitySwitch<PurchaseDetailsViewModel.VisualState> viewSwitch = new VisibilitySwitch<PurchaseDetailsViewModel.VisualState>(base.ViewModel.State)
		{
			{
				PurchaseDetailsViewModel.VisualState.Default,
				controls.Default.View
			},
			{
				PurchaseDetailsViewModel.VisualState.InProgress,
				controls.Progress
			},
			{
				PurchaseDetailsViewModel.VisualState.Error,
				controls.Error.View
			}
		};
		controls.Error.Title.SetLinkedHtml(base.ViewModel.ConnectionErrorText, base.ViewModel.HandleLink).AutoDisposeAllOnDestroy(ViewLifecycleOwner);
		controls.Error.Description.AddScrollBehaviour();
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[9]
		{
			(delegate
			{
				controls.Error.Title.Text = base.ViewModel.Title;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Title")),
			(delegate
			{
				controls.Error.Image.FromUrlWithPlaceholder(base.ViewModel.ConnectionErrorImage, 2131231054);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ConnectionErrorImage")),
			(delegate
			{
				SetStoreInfo(controls, base.ViewModel.HasStoreInfo);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("HasStoreInfo")),
			(delegate
			{
				base.ToolbarTitle = base.ViewModel.Title;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Title")),
			(delegate
			{
				controls.Default.OrderQtyLabel.Text = base.ViewModel.ProductCount;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ProductCount")),
			(delegate
			{
				controls.Default.DeliveryDateLabel.Text = base.ViewModel.ReceiveDateTimeTitle;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ReceiveDateTimeTitle")),
			(delegate
			{
				controls.Default.OrderQtyLabel.Text = base.ViewModel.ProductCount;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ProductCount")),
			(delegate
			{
				controls.Default.DeliveryDateTextView.Text = base.ViewModel.ReceiveDateTime;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ReceiveDateTime")),
			(delegate
			{
				viewSwitch.State = base.ViewModel.State;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("State"))
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.LoyaltyProducts.SafeSubscribeToCollectionChanged(delegate
		{
			controls.Default.OrderQtyLabel.Text = base.ViewModel.ProductCount;
			ConfigureAdapter(controls.Default.View);
		}, ViewLifecycleOwner);
		base.ViewModel.OpenDelayedPointsInfoCommand.SafeSubscribe(delegate
		{
			Show<DelayedPointsInformerFragment>();
		}, ViewLifecycleOwner);
		base.ViewModel.NavigateToProductDetailsCommand.SafeSubscribe(delegate(ProductDetailsViewModel.Parameter p)
		{
			NavigateTo<ProductDetailsFragment, ProductDetailsViewModel.Parameter>(p);
		}, ViewLifecycleOwner);
	}

	private void SetStoreInfo(Controls controls, bool hasStoreInfo)
	{
		if (hasStoreInfo)
		{
			controls.Default.StoreName.Text = base.ViewModel.StoreAddressTitle;
			controls.Default.StoreAddress.Text = base.ViewModel.StoreAddress;
			TextView storeName = controls.Default.StoreName;
			ViewStates visibility = (controls.Default.StoreAddress.Visibility = ViewStates.Visible);
			storeName.Visibility = visibility;
		}
	}

	private void ConfigureAdapter(View view)
	{
		RecyclerView recyclerView = view.RequireViewById<RecyclerView>(2131297804);
		ObservableRecyclerAdapter<LoyaltyProductViewModel, CachingViewHolder> adapter = new ObservableRecyclerAdapter<LoyaltyProductViewModel, CachingViewHolder>
		{
			ClickCallback = delegate(CachingViewHolder holder, LoyaltyProductViewModel model, int pos)
			{
				base.ViewModel.ProductSelected(model);
			},
			CellLayoutId = 2131493309,
			DataSource = base.ViewModel.LoyaltyProducts,
			BindViewHolderDelegate = OnBindProduct
		};
		recyclerView.SetAdapter(adapter);
	}

	private void OnBindProduct(CachingViewHolder viewHolder, LoyaltyProductViewModel item, int position, CompositeDisposable disposable)
	{
		ImageView imageView = viewHolder.RequireCachedView<ImageView>(2131297787);
		TextView textView = viewHolder.RequireCachedView<TextView>(2131297788);
		TextView textView2 = viewHolder.RequireCachedView<TextView>(2131297789);
		MaterialCardView materialCardView = viewHolder.RequireCachedView<MaterialCardView>(2131298115);
		TextView textView3 = viewHolder.RequireCachedView<TextView>(2131298117);
		MaterialCardView materialCardView2 = viewHolder.RequireCachedView<MaterialCardView>(2131298118);
		TextView textView4 = viewHolder.RequireCachedView<TextView>(2131298119);
		TextView textView5 = viewHolder.RequireCachedView<TextView>(2131297791);
		View view = viewHolder.RequireCachedView<View>(2131297392);
		View view2 = viewHolder.RequireCachedView<View>(2131297133);
		TextView textView6 = viewHolder.RequireCachedView<TextView>(2131297134);
		if (item.HasImage)
		{
			imageView.FromUrl(item.ImageUrl);
		}
		textView.Text = item.Name;
		textView2.Text = item.Price;
		materialCardView.Visibility = item.HasPoints.ToVisibility();
		textView3.Text = item.Points;
		textView3.SetTextColor(new Color(ContextCompat.GetColor(Context, item.NegativePoints ? 2131100571 : 2131099706)));
		view2.Visibility = item.HasExpressPoints.ToVisibility();
		textView6.Text = item.ExpressPoints;
		textView6.SetTextColor(new Color(ContextCompat.GetColor(Context, item.NegativeExpressPoints ? 2131100571 : 2131099706)));
		materialCardView2.Visibility = item.HasStamps.ToVisibility();
		textView4.Text = item.Stamps;
		textView4.SetTextColor(new Color(ContextCompat.GetColor(Context, item.NegativeStamps ? 2131100571 : 2131099706)));
		textView5.Text = item.UnitPriceAndQuantity;
		bool flag = position == base.ViewModel.LoyaltyProducts.Count - 1;
		view.Visibility = (!flag).ToVisibility();
	}
}
