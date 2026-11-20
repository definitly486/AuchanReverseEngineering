using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Disposables;
using System.Threading.Tasks;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using AndroidX.ConstraintLayout.Widget;
using AndroidX.Core.Content.Resources;
using AndroidX.Core.Text;
using AndroidX.Core.Widget;
using AndroidX.Fragment.App;
using AndroidX.RecyclerView.Widget;
using AsyncAwaitBestPractices;
using Auchan.Android.Base;
using Auchan.Android.Catalog;
using Auchan.Android.Common.ImagePreview;
using Auchan.Android.Common.UiUtils;
using Auchan.Android.Controls.ZoomableImageSlider;
using Auchan.Android.Drive;
using Auchan.Android.Ecom.Cart;
using Auchan.Android.Extensions;
using Auchan.Android.LoyaltyProgram;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Common.ImagePreview;
using Auchan.Common.Drive;
using Auchan.Common.Ecom.Cart.ViewModels;
using Auchan.Common.Ecom.Products.ViewModels;
using Auchan.Common.Extensions;
using Auchan.Common.Profile.Orders;
using Google.Android.Material.BottomNavigation;
using Google.Android.Material.Button;
using Java.Lang;
using Microsoft.Maui.ApplicationModel;
using VisibilitySwitch;

namespace Auchan.Android.Profile.Orders;

internal class OrderDetailsFragment : BaseToolbarFragment<OrderDetailsViewModel>
{
	private readonly FragmentFactory _fragmentFactory;

	protected override int LayoutId => 2131493071;

	public OrderDetailsFragment(FragmentFactory fragmentFactory, Func<OrderDetailsViewModel.Parameter, OrderDetailsViewModel> newViewModel)
		: base((Func<Fragment, OrderDetailsViewModel>)((Fragment thisFragment) => newViewModel(thisFragment.RequireNavParam<OrderDetailsViewModel.Parameter>())))
	{
		_fragmentFactory = fragmentFactory;
	}

	protected override bool HasNavigationButton()
	{
		return true;
	}

	public override void OnViewCreated(View view, Bundle? savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		LinearLayout linearLayout = view.RequireViewById<LinearLayout>(2131296904);
		FrameLayout frameLayout = view.RequireViewById<FrameLayout>(2131298079);
		ConstraintLayout constraintLayout = view.RequireViewById<ConstraintLayout>(2131297111);
		TextView title = view.RequireViewById<TextView>(2131298646);
		ImageButton imageButton = view.RequireViewById<ImageButton>(2131296849);
		TextView subtitle = view.RequireViewById<TextView>(2131298559);
		View selfPickupPointView = linearLayout.RequireViewById<View>(2131298347);
		selfPickupPointView.RequireViewById<TextView>(2131298346).Text = base.ViewModel.SelfPickupPointTitle;
		TextView errorTitle = constraintLayout.RequireViewById<TextView>(2131298646);
		TextView errorMessage = constraintLayout.RequireViewById<TextView>(2131297563);
		Button button = constraintLayout.RequireViewById<Button>(2131296325);
		Button button2 = constraintLayout.RequireViewById<Button>(2131298371);
		button.Text = base.ViewModel.ErrorButtonText;
		Button repeatButton = linearLayout.RequireViewById<Button>(2131297805);
		repeatButton.Text = base.ViewModel.RepeatButtonText;
		Button cancelButton = linearLayout.RequireViewById<Button>(2131297801);
		cancelButton.Text = base.ViewModel.CancelButtonText;
		Button readyToReceiveButton = linearLayout.RequireViewById<Button>(2131298155);
		MaterialButton payButton = linearLayout.RequireViewById<MaterialButton>(2131297803);
		payButton.Text = base.ViewModel.PayButtonText;
		ViewGroup pointsPaymentLayout = linearLayout.RequireViewById<ViewGroup>(2131297944);
		TextView textView = pointsPaymentLayout.RequireViewById<TextView>(2131297945);
		TextView pointsPaymentValue = pointsPaymentLayout.RequireViewById<TextView>(2131297946);
		ViewGroup stampsPaymentLayout = linearLayout.RequireViewById<ViewGroup>(2131298451);
		TextView textView2 = stampsPaymentLayout.RequireViewById<TextView>(2131298452);
		TextView stampsPaymentValue = stampsPaymentLayout.RequireViewById<TextView>(2131298453);
		TextView statusTextView = linearLayout.RequireViewById<TextView>(2131298479);
		TextView addressTextView = linearLayout.RequireViewById<TextView>(2131296394);
		LinearLayout view2 = linearLayout.RequireViewById<LinearLayout>(2131298078);
		TextView textView3 = view.RequireViewById<TextView>(2131297762);
		TextView textView4 = view.RequireViewById<TextView>(2131297776);
		TextView paymentTypeTextView = view.RequireViewById<TextView>(2131297777);
		View commentBlockView = view.RequireViewById<View>(2131297770);
		TextView textView5 = view.RequireViewById<TextView>(2131297772);
		TextView commentContentTextView = view.RequireViewById<TextView>(2131297771);
		TextView textView6 = view.RequireViewById<TextView>(2131297775);
		LinearLayout auchanDriveMapContainer = view.RequireViewById<LinearLayout>(2131296465);
		TextView textView7 = auchanDriveMapContainer.RequireViewById<TextView>(2131296928);
		TextView textView8 = auchanDriveMapContainer.RequireViewById<TextView>(2131298177);
		TextView recipientBlockText = auchanDriveMapContainer.RequireViewById<TextView>(2131298176);
		View mapContainer = auchanDriveMapContainer.RequireViewById<View>(2131297516);
		TextView textView9 = auchanDriveMapContainer.RequireViewById<TextView>(2131297518);
		ImageView mapImage = auchanDriveMapContainer.RequireViewById<ImageView>(2131298175);
		TextView textView10 = view.RequireViewById<TextView>(2131297798);
		TextView weightTextView = view.RequireViewById<TextView>(2131297799);
		TextView qtyPriceSumLabel = view.RequireViewById<TextView>(2131297785);
		TextView qtyPriceSumTextView = view.RequireViewById<TextView>(2131297786);
		ConstraintLayout pickingPriceContainer = view.RequireViewById<ConstraintLayout>(2131297778);
		TextView textView11 = view.RequireViewById<TextView>(2131297779);
		TextView pickingPriceText = view.RequireViewById<TextView>(2131297780);
		ConstraintLayout surgeAmountContainer = view.RequireViewById<ConstraintLayout>(2131297795);
		TextView textView12 = view.RequireViewById<TextView>(2131297796);
		TextView surgeAmountText = view.RequireViewById<TextView>(2131297797);
		TextView deliveryPriceLabel = view.RequireViewById<TextView>(2131297781);
		TextView deliveryPriceTextView = view.RequireViewById<TextView>(2131297782);
		View dateLayout = view.RequireViewById<View>(2131296889);
		TextView dateTitle = view.RequireViewById<TextView>(2131296892);
		TextView dateText = view.RequireViewById<TextView>(2131296890);
		View addressLayout = view.RequireViewById<View>(2131296390);
		TextView addressTitle = view.RequireViewById<TextView>(2131296395);
		TextView addressText = view.RequireViewById<TextView>(2131296393);
		TextView textView13 = view.RequireViewById<TextView>(2131297783);
		TextView generalPriceTextView = view.RequireViewById<TextView>(2131297784);
		TextView textView14 = view.RequireViewById<TextView>(2131297792);
		TextView orderQtyTextView = view.RequireViewById<TextView>(2131297793);
		View orderChangedBg = view.RequireViewById<View>(2131296748);
		TextView textView15 = view.RequireViewById<TextView>(2131296749);
		AddToOrderButtonControls addToOrderButtonControls = new AddToOrderButtonControls(view.RequireViewById<View>(2131296350));
		TextView callToCourierButton = view.RequireViewById<TextView>(2131296604);
		ImageView selfPickupPointImage = view.RequireViewById<ImageView>(2131298344);
		TextView selfPickupPointDescription = view.RequireViewById<TextView>(2131298343);
		textView.Text = base.ViewModel.PointsPaymentTitle;
		textView2.Text = base.ViewModel.StampsPaymentTitle;
		OneTwoImages oneTwoImages = new OneTwoImages();
		oneTwoImages.FindAllViewsById(view);
		textView3.Text = base.ViewModel.OrdersInfoBlockTitle;
		textView7.Text = base.ViewModel.AuchanDriveBlockTitle;
		textView8.Text = base.ViewModel.AuchanDriveRecipientBlockTitle;
		textView9.Text = base.ViewModel.AuchanDriveMapBlockTitle;
		textView4.Text = base.ViewModel.PaymentTypeLabel;
		textView5.Text = base.ViewModel.CommentTitleText;
		textView6.Text = base.ViewModel.GeneralLabel;
		textView10.Text = base.ViewModel.WeightLabel;
		textView13.Text = base.ViewModel.GeneralPriceLabel;
		textView14.Text = base.ViewModel.OrderQtyLabel;
		textView15.Text = base.ViewModel.OrderChangedText;
		textView11.Text = base.ViewModel.PickingPriceLabel;
		textView12.Text = base.ViewModel.SurgeAmountLabel;
		callToCourierButton.Text = base.ViewModel.CallToCourier.Text;
		bool setupCompleted = false;
		base.ViewModel.OnPropertyChanges((OrderDetailsViewModel x) => x.NeedShowSelfPickupPoint).SafeSubscribe(delegate
		{
			if (!setupCompleted)
			{
				setupCompleted = true;
				oneTwoImages.Setup(base.ViewModel, base.ViewModel.PickupPointImages, ViewLifecycleOwner, delegate(int i)
				{
					ZoomableImageSliderFragment zoomableImageSliderFragment = _fragmentFactory.Instantiate<ZoomableImageSliderFragment>();
					zoomableImageSliderFragment.ImageItemViewModels.AddRange(base.ViewModel.PickupPointImages.Select((string x) => new ImageItemViewModel(x)));
					zoomableImageSliderFragment.CurrentIndex = i;
					zoomableImageSliderFragment.Show(base.ChildFragmentManager, null);
				});
			}
		}, ViewLifecycleOwner);
		base.ViewModel.NavigateToProductCommand.SafeSubscribe(NavigateToProduct, ViewLifecycleOwner);
		base.ViewModel.RepeatOrderService.NavigateToStaticProductListCommand.SafeSubscribe(GoToStaticList, ViewLifecycleOwner);
		base.ViewModel.RepeatOrderService.ShowRepeatAdultProductWarningCommand.SafeSubscribe(delegate
		{
			ShowAdultWarning().SafeFireAndForget((Action<System.Exception>)null, false);
		}, ViewLifecycleOwner);
		base.ViewModel.RepeatOrderService.NavigateToCartCommand.SafeSubscribe(delegate
		{
			NavigateToTab(2131297640);
		}, ViewLifecycleOwner);
		base.ViewModel.RepeatOrderService.NavigateToRepeatPreviousOrderPopup.SafeSubscribe(delegate(BrokerToken p)
		{
			Show<RepeatOrderPopupFragment, BrokerToken>(p);
		}, ViewLifecycleOwner);
		base.ViewModel.OpenIsArrivedDialogCommand.PerformDebouncingTask(OpenIsArrivedDialog).Subscribe().AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.OpenGetOrderDialog.SafeSubscribe(OpenIssuingZonePopup, ViewLifecycleOwner);
		base.ViewModel.OpenPaymentCommand.SafeSubscribe(OpenPayment, ViewLifecycleOwner);
		ConfigureProductsRecycler(view);
		VisibilitySwitch<VisualState> visibilitySwitch = new VisibilitySwitch<VisualState>(VisualState.Empty)
		{
			{
				VisualState.Default,
				linearLayout
			},
			{
				VisualState.InProgress,
				frameLayout
			},
			{
				VisualState.Error,
				constraintLayout
			}
		};
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[47]
		{
			(delegate
			{
				title.Text = base.ViewModel.Title;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Title")),
			(delegate
			{
				subtitle.Text = base.ViewModel.Subtitle;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Subtitle")),
			(delegate
			{
				pointsPaymentLayout.Visibility = base.ViewModel.PointsPaymentVisible.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("PointsPaymentVisible")),
			(delegate
			{
				pointsPaymentValue.Text = base.ViewModel.PointsPaymentValue;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("PointsPaymentValue")),
			(delegate
			{
				stampsPaymentLayout.Visibility = base.ViewModel.StampsPaymentVisible.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("StampsPaymentVisible")),
			(delegate
			{
				stampsPaymentValue.Text = base.ViewModel.StampsPaymentValue;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("StampsPaymentValue")),
			(delegate
			{
				cancelButton.Visibility = base.ViewModel.IsCancelButtonVisible.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsCancelButtonVisible")),
			(delegate
			{
				readyToReceiveButton.Text = base.ViewModel.ReadyToReceiveButtonText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ReadyToReceiveButtonText")),
			(delegate
			{
				payButton.Visibility = base.ViewModel.PaymentAvailable.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("PaymentAvailable")),
			(delegate
			{
				repeatButton.Visibility = base.ViewModel.RepeatButtonVisible.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("RepeatButtonVisible")),
			(delegate
			{
				readyToReceiveButton.Visibility = base.ViewModel.IsReadyToReceive.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsReadyToReceive")),
			(delegate
			{
				errorTitle.Text = base.ViewModel.ErrorTitle;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ErrorTitle")),
			(delegate
			{
				errorMessage.Text = base.ViewModel.ErrorMessage;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ErrorMessage")),
			(delegate
			{
				selfPickupPointView.Visibility = base.ViewModel.NeedShowSelfPickupPoint.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("NeedShowSelfPickupPoint")),
			(delegate
			{
				statusTextView.Text = base.ViewModel.StatusText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("StatusText")),
			(delegate
			{
				addressTextView.Text = base.ViewModel.AddressText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("AddressText")),
			(delegate
			{
				addressTextView.Visibility = base.ViewModel.IsInActiveState.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsInActiveState")),
			(delegate
			{
				recipientBlockText.Text = base.ViewModel.UserName;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("UserName")),
			(delegate
			{
				auchanDriveMapContainer.Visibility = base.ViewModel.IsAuchanDriveOrder.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsAuchanDriveOrder")),
			(delegate
			{
				paymentTypeTextView.Text = base.ViewModel.PaymentTypeText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("PaymentTypeText")),
			(delegate
			{
				commentBlockView.Visibility = base.ViewModel.IsCommentVisible.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsCommentVisible")),
			(delegate
			{
				commentContentTextView.Text = base.ViewModel.CommentContent;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("CommentContent")),
			(delegate
			{
				weightTextView.Text = base.ViewModel.WeightText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("WeightText")),
			(delegate
			{
				qtyPriceSumLabel.Text = base.ViewModel.QtyPriceSumLabel;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("QtyPriceSumLabel")),
			(delegate
			{
				qtyPriceSumTextView.Text = base.ViewModel.QtyPriceSumText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("QtyPriceSumText")),
			(delegate
			{
				pickingPriceText.Text = base.ViewModel.PickingPriceText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("PickingPriceText")),
			(delegate
			{
				pickingPriceContainer.Visibility = base.ViewModel.PickingPriceVisible.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("PickingPriceVisible")),
			(delegate
			{
				surgeAmountText.Text = base.ViewModel.SurgeAmountText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("SurgeAmountText")),
			(delegate
			{
				surgeAmountContainer.Visibility = base.ViewModel.SurgeAmountVisible.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("SurgeAmountVisible")),
			(delegate
			{
				deliveryPriceLabel.Text = base.ViewModel.DeliveryPriceTitle;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("DeliveryPriceTitle")),
			(delegate
			{
				deliveryPriceTextView.Text = base.ViewModel.DeliveryPriceText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("DeliveryPriceText")),
			(delegate
			{
				generalPriceTextView.Text = base.ViewModel.GeneralPriceText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("GeneralPriceText")),
			(delegate
			{
				orderQtyTextView.Text = base.ViewModel.OrderQtyText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("OrderQtyText")),
			(delegate
			{
				orderChangedBg.Visibility = base.ViewModel.IsOrderChanged.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsOrderChanged")),
			(delegate
			{
				dateTitle.Text = base.ViewModel.DeliveryDateTitle;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("DeliveryDateTitle")),
			(delegate
			{
				dateText.Text = base.ViewModel.DeliveryDateText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("DeliveryDateText")),
			(delegate
			{
				dateLayout.Visibility = base.ViewModel.IsInFinalState.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsInFinalState")),
			(delegate
			{
				addressTitle.Text = base.ViewModel.DeliveryMethodTitle;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("DeliveryMethodTitle")),
			(delegate
			{
				addressText.Text = base.ViewModel.ShortAddressText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ShortAddressText")),
			(delegate
			{
				addressLayout.Visibility = base.ViewModel.IsInFinalState.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsInFinalState")),
			(delegate
			{
				selfPickupPointImage.Visibility = base.ViewModel.IsShopImageVisible.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsShopImageVisible")),
			(delegate
			{
				mapContainer.Visibility = base.ViewModel.IsShopImageVisible.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsShopImageVisible")),
			(delegate
			{
				selfPickupPointDescription.Text = base.ViewModel.Description;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Description")),
			(delegate
			{
				selfPickupPointDescription.Visibility = base.ViewModel.IsDescriptionVisible.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsDescriptionVisible")),
			(delegate
			{
				visibilitySwitch.SwitchState(base.ViewModel.State);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("State")),
			(delegate
			{
				SetImage(selfPickupPointImage, base.ViewModel.ShopImage);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ShopImage")),
			(delegate
			{
				SetImage(mapImage, base.ViewModel.ShopImage);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ShopImage"))
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.CallToCourier.BindProperties(new global::_003C_003Ez__ReadOnlySingleElementList<(Action, IReadOnlyList<string>)>((delegate
		{
			callToCourierButton.Visibility = base.ViewModel.CallToCourier.IsVisible.ToVisibility();
		}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsVisible")))).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.BindEvents(((View)mapImage).OnClick((Action)delegate
		{
			NavigateToMap(base.ViewModel.AuchanDriveMapBlockTitle, base.ViewModel.ShopImage);
		}), readyToReceiveButton.OnClick(base.ViewModel.TapOnReadyButton), title.OnClick(base.ViewModel.CopyOrderNumber), imageButton.OnClick(base.ViewModel.CopyOrderNumber), ((View)button).OnClick((Action)delegate
		{
			base.ViewModel.LoadOrder().SafeFireAndForget((Action<System.Exception>)null, false);
		}), ((View)button2).OnClick((Action)delegate
		{
			Show<LoyaltyCardPdf417PortraitFragment>();
		}), ((View)repeatButton).OnClick((Action)delegate
		{
			base.ViewModel.RepeatOrder().SafeFireAndForget((Action<System.Exception>)null, false);
		}), ((View)cancelButton).OnClick((Action)delegate
		{
			base.ViewModel.CancelOrder().SafeFireAndForget((Action<System.Exception>)null, false);
		}), payButton.OnClick(base.ViewModel.PayCommand.Trigger), ((View)callToCourierButton).OnClick((Action)delegate
		{
			base.ViewModel.CallToCourier.Command.Trigger();
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		new OrderProgressBarControls(view2, base.Resources, showText: true).Bind(base.ViewModel.OrderProgress, ViewLifecycleOwner);
		addToOrderButtonControls.Setup(base.ViewModel.AddToOrderButtonItemViewModel).AutoDisposeOnDestroy(ViewLifecycleOwner);
	}

	private void SetImage(ImageView to, string? imageUrl)
	{
		if (imageUrl != null)
		{
			to.FromUrl(imageUrl);
		}
	}

	private void ConfigureScroll(View view)
	{
		view.RequireViewById<NestedScrollView>(2131297794).FullScroll(33);
	}

	private void ConfigureProductsRecycler(View view)
	{
		RecyclerView productsRecyclerView = view.RequireViewById<RecyclerView>(2131297804);
		ObservableRecyclerAdapter<OrderDetailProductItemViewModel, CachingViewHolder> adapter = new ObservableRecyclerAdapter<OrderDetailProductItemViewModel, CachingViewHolder>
		{
			CellLayoutId = 2131493267,
			DataSource = base.ViewModel.Products,
			BindViewHolderDelegate = OnBindProduct,
			ClickCallback = OnProductClick
		};
		productsRecyclerView.SetAdapter(adapter);
		productsRecyclerView.AddItemDecoration(GetItemDecoration());
		FlexibleDividerItemDecoration GetItemDecoration()
		{
			Drawable defaultDividerDrawable = ResourcesCompat.GetDrawable(base.Activity.Resources, 2131230888, base.Activity.Theme);
			View replacedProductDividerView = global::Android.Views.LayoutInflater.From(view.Context)?.Inflate(2131493181, productsRecyclerView, attachToRoot: false);
			return new FlexibleDividerItemDecoration((int position) => (!base.ViewModel.Products[position].IsReplaced) ? ((Java.Lang.Object)defaultDividerDrawable) : ((Java.Lang.Object)replacedProductDividerView));
		}
	}

	private void OnProductClick(CachingViewHolder vh, OrderDetailProductItemViewModel vm, int position)
	{
		base.ViewModel.OnClick(vm);
	}

	private void OnBindProduct(CachingViewHolder viewHolder, OrderDetailProductItemViewModel item, int position, CompositeDisposable disposable)
	{
		ImageView imageView = viewHolder.RequireCachedView<ImageView>(2131297787);
		TextView textView = viewHolder.RequireCachedView<TextView>(2131297788);
		TextView textView2 = viewHolder.RequireCachedView<TextView>(2131297789);
		TextView textView3 = viewHolder.RequireCachedView<TextView>(2131297790);
		TextView textView4 = viewHolder.RequireCachedView<TextView>(2131297791);
		RecyclerView recyclerView = viewHolder.RequireCachedView<RecyclerView>(2131297585);
		ObservableRecyclerAdapter<ListItemModificationValueViewModel, CachingViewHolder> adapter = new ObservableRecyclerAdapter<ListItemModificationValueViewModel, CachingViewHolder>
		{
			CellLayoutId = 2131493220,
			DataSource = item.SelectedModifications,
			BindViewHolderDelegate = OnBindModification
		};
		PrepareForReuse(viewHolder.ItemView, textView4);
		recyclerView.SetLayoutManager(new LinearLayoutManager(base.Activity, 1, reverseLayout: false));
		recyclerView.SetAdapter(adapter);
		if (!string.IsNullOrEmpty(item.ImagePath))
		{
			imageView.FromUrl(item.ImagePath);
		}
		textView.Text = item.NameText;
		textView2.Text = item.PriceText;
		textView3.Text = item.PricePerItemText;
		textView4.TextFormatted = HtmlCompat.FromHtml(item.QtyText, 0);
		if (item.IsCanceled)
		{
			SetViewCanceled(viewHolder.ItemView, textView4);
		}
		if (item.IsReplaced)
		{
			SetViewTranslucent(viewHolder.ItemView);
		}
	}

	private static void SetViewCanceled(View view, TextView viewForForbiddenIcon)
	{
		SetViewTranslucent(view);
		ReplaceTextWithForbiddenIcon(viewForForbiddenIcon);
		static void ReplaceTextWithForbiddenIcon(TextView textView)
		{
			textView.Text = string.Empty;
			textView.Background = textView.Context?.GetDrawable(2131231180);
		}
	}

	private static void PrepareForReuse(View view, TextView qtyTextView)
	{
		SetAlphaForViewAndSubviews(view, 1f);
		qtyTextView.Background = null;
	}

	private static void SetViewTranslucent(View view)
	{
		SetAlphaForViewAndSubviews(view, 0.7f);
	}

	private static void SetAlphaForViewAndSubviews(View view, float alpha)
	{
		view.Alpha = alpha;
		if (view is ViewGroup viewGroup)
		{
			for (int i = 0; i < viewGroup.ChildCount; i++)
			{
				SetAlphaForViewAndSubviews(viewGroup.GetChildAt(i), alpha);
			}
		}
	}

	private void OnBindModification(CachingViewHolder vh, ListItemModificationValueViewModel vm, int pos, CompositeDisposable disposable)
	{
		TextView textView = vh.RequireCachedView<TextView>(2131297434);
		TextView textView2 = vh.RequireCachedView<TextView>(2131297435);
		textView.Text = vm.Name;
		textView2.Text = vm.Value;
	}

	private void NavigateToMap(string title, string url)
	{
		NavigateTo<ImagePreviewFragment, ImagePreviewViewModel.Parameter>(new ImagePreviewViewModel.Parameter(title, url));
	}

	private void NavigateToProduct(ProductDetailsViewModel.Parameter parameter)
	{
		NavigateTo<ProductDetailsFragment, ProductDetailsViewModel.Parameter>(parameter);
	}

	private void NavigateToTab(int resourceId)
	{
		BottomNavigationView bottomNavigationView = base.Activity.RequireViewById<BottomNavigationView>(2131296565);
		if (bottomNavigationView != null)
		{
			bottomNavigationView.SelectedItemId = resourceId;
		}
	}

	private void OpenIssuingZonePopup(IssuingAreaViewModel.Parameter parameter)
	{
		if (!(Platform.CurrentActivity is AppCompatActivity appCompatActivity))
		{
			return;
		}
		IssuingAreaPopupFragment issuingAreaPopupFragment = _fragmentFactory.Instantiate<IssuingAreaPopupFragment>();
		issuingAreaPopupFragment.Arguments = parameter.ToNavBundle();
		issuingAreaPopupFragment.Show(appCompatActivity.SupportFragmentManager, null);
		issuingAreaPopupFragment.NavigateToOrders = delegate
		{
			if (base.ParentFragmentManager.BackStackEntryCount == 1)
			{
				OpenOrders(Unit.Default);
			}
			else
			{
				base.ParentFragmentManager.PopBackStack();
			}
		};
	}

	private void OpenOrders(Unit obj)
	{
		base.ParentFragmentManager.BeginTransaction().Hide(this).Add<OrdersFragment>(this)
			.AddToBackStack(null)
			.Commit();
	}

	private async Task OpenIsArrivedDialog(AskIsPersonArrivedViewModel.Parameter parameter)
	{
		if (await ShowAutoDialog(parameter) == AgreeState.Yes && Platform.CurrentActivity is AppCompatActivity appCompatActivity)
		{
			_fragmentFactory.Instantiate<AlreadyBringingPopupFragment>().Show(appCompatActivity.SupportFragmentManager, null);
		}
		base.ViewModel.ReloadOrder();
	}

	private Task<AgreeState> ShowAutoDialog(AskIsPersonArrivedViewModel.Parameter parameter)
	{
		if (Platform.CurrentActivity is AppCompatActivity appCompatActivity)
		{
			AskIsPersonArrivedFragment askIsPersonArrivedFragment = _fragmentFactory.Instantiate<AskIsPersonArrivedFragment>();
			askIsPersonArrivedFragment.Arguments = parameter.ToNavBundle();
			askIsPersonArrivedFragment.Show(appCompatActivity.SupportFragmentManager, null);
			return askIsPersonArrivedFragment.Execute();
		}
		return Task.FromResult(AgreeState.None);
	}

	private void OpenPayment(CheckoutWebViewModel.Parameter parameter)
	{
		base.ParentFragmentManager.BeginTransaction().AddToBackStack(null).Hide(this)
			.Add<CheckoutWebViewFragment>(this, parameter.ToNavBundle())
			.Commit();
	}

	private void GoToStaticList(BrokerToken arg)
	{
		base.ParentFragmentManager.BeginTransaction().Hide(this).Add<StaticProductListFragment>(this, arg.ToNavBundle())
			.AddToBackStack(null)
			.Commit();
	}

	private async Task ShowAdultWarning()
	{
		FragmentManager supportFragmentManager = RequireActivity().SupportFragmentManager;
		RepeatAdultProductWarningPopupFragment repeatAdultProductWarningPopupFragment = _fragmentFactory.Instantiate<RepeatAdultProductWarningPopupFragment>();
		repeatAdultProductWarningPopupFragment.Show(supportFragmentManager, null);
		if (await repeatAdultProductWarningPopupFragment.Execute())
		{
			await base.ViewModel.RepeatOrderService.ShowAddressSelection();
		}
	}
}
