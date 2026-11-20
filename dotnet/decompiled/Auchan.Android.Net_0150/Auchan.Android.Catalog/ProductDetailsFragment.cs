using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.Widget;
using AndroidX.ConstraintLayout.Widget;
using AndroidX.Core.Content;
using AndroidX.Core.Widget;
using AndroidX.Fragment.App;
using AndroidX.RecyclerView.Widget;
using AndroidX.ViewPager2.Widget;
using Auchan.Android.Base;
using Auchan.Android.Catalog.ProductDetails;
using Auchan.Android.Common.UiUtils;
using Auchan.Android.Controls;
using Auchan.Android.Controls.Badges;
using Auchan.Android.Controls.ZoomableImageSlider;
using Auchan.Android.DynamicFeedback;
using Auchan.Android.Ecom.Product;
using Auchan.Android.Extensions;
using Auchan.Android.InfoPages;
using Auchan.Android.LoyaltyProgram;
using Auchan.Android.Recommendations;
using Auchan.Android.Reviews;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Ecom.ProducModels;
using Auchan.Common.Ecom.ProducModels.ViewModels;
using Auchan.Common.Ecom.Products.Gluings;
using Auchan.Common.Ecom.Products.Modifications;
using Auchan.Common.Ecom.Products.ViewModels;
using Auchan.Common.Extensions;
using Auchan.Common.Helpers;
using Auchan.Common.InfoPages;
using Auchan.Common.Profile;
using Auchan.Common.Reviews;
using Auchan.Common.Reviews.Model;
using Me.Relex.CircleIndicatorLib;
using VisibilitySwitch;

namespace Auchan.Android.Catalog;

internal sealed class ProductDetailsFragment : BaseToolbarFragment<ProductDetailsViewModel>
{
	private const int ReviewRewardTooltipMaxWidthDp = 216;

	private readonly FragmentFactory _fragmentFactory;

	private readonly ProductFooterBinder _footerBinder;

	private RecyclerView _reviewsList;

	private CollapsableTextView? _descriptionLabel;

	private TextView? availableInShopLabel;

	private RecyclerView? _characteristicList;

	private TextView _allCharacteristicsButton;

	private RecyclerView? _availableShopsList;

	private View _availableShopsButton;

	private ImageView _favoriteButton;

	private ProductRateView _productRateView;

	private View _smallRateLayout;

	private ImageView _smallRateStarView;

	private TextView _smallRateRatingTextView;

	private TextView _smallRateReviewCountTextView;

	private ReviewRewardStickerView _reviewRewardSticker;

	private ImageView _chevronImageDown;

	private bool _favoritesBound;

	private bool _availableshopsclicked;

	private LinearLayout _outOfStockTopLayout;

	private ImageView _outOfStockCardImage;

	private TextView _outOfStockCardTitle;

	private TextView _outOfStockCardPrice;

	private ConstraintLayout _outOfStockCard;

	protected override int LayoutId => 2131493076;

	protected override bool HasNavigationButton()
	{
		return true;
	}

	public ProductDetailsFragment(Func<ProductDetailsViewModel.Parameter, ProductDetailsViewModel> newViewModel, FragmentFactory fragmentFactory, ProductFooterBinder footerBinder)
		: base((Func<Fragment, ProductDetailsViewModel>)((Fragment thisFragment) => newViewModel(thisFragment.RequireNavParam<ProductDetailsViewModel.Parameter>())))
	{
		_fragmentFactory = fragmentFactory;
		_footerBinder = footerBinder;
	}

	public override void OnCreate(Bundle savedInstanceState)
	{
		base.OnCreate(savedInstanceState);
		base.ViewModel.NavigateToCategoryCommand.SafeSubscribe(NavigateToCategory, this);
		base.ViewModel.NavigateToProductsByBrandCommand.SafeSubscribe(NavigateToProductsByBrand, this);
		base.ViewModel.CloseProductDetailsCommand.SafeSubscribe(delegate
		{
			base.ParentFragmentManager.PopBackStack();
		}, this);
		base.ViewModel.OpenInternalDocumentCommand.SafeSubscribe(delegate(InfoPageViewModel.Parameter p)
		{
			NavigateTo<InfoPageFragment, InfoPageViewModel.Parameter>(p);
		}, this);
	}

	public override void OnViewCreated(View view, Bundle savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		LinearLayout linearLayout = view.RequireViewById<LinearLayout>(2131296904);
		ConstraintLayout constraintLayout = view.RequireViewById<ConstraintLayout>(2131297111);
		FrameLayout frameLayout = view.RequireViewById<FrameLayout>(2131298079);
		ConstraintLayout constraintLayout2 = view.RequireViewById<ConstraintLayout>(2131297066);
		NestedScrollView scrollView = linearLayout.RequireViewById<NestedScrollView>(2131298303);
		RecommendationsView bottomRecommendationsView = scrollView.RequireViewById<RecommendationsView>(2131298181);
		View bottomRecommendationsDivider = scrollView.RequireViewById<View>(2131298183);
		_productRateView = scrollView.RequireViewById<ProductRateView>(2131298003);
		Button okButton = constraintLayout2.RequireViewById<Button>(2131297728);
		TextView emptyTitle = constraintLayout2.RequireViewById<TextView>(2131298646);
		TextView errorTitle = constraintLayout.RequireViewById<TextView>(2131298646);
		TextView errorMessage = constraintLayout.RequireViewById<TextView>(2131297563);
		AppCompatButton appCompatButton = constraintLayout.RequireViewById<AppCompatButton>(2131296325);
		Button showQrButton = constraintLayout.RequireViewById<Button>(2131298371);
		_favoriteButton = linearLayout.RequireViewById<ImageView>(2131297148);
		ImageView shareButton = view.RequireViewById<ImageView>(2131298359);
		TouchListenerViewGroup touchListenerViewGroup = scrollView.RequireViewById<TouchListenerViewGroup>(2131298016);
		ViewPager2 topBanners = touchListenerViewGroup.RequireViewById<ViewPager2>(2131298013);
		CircleIndicator topBannersIndicator = scrollView.RequireViewById<CircleIndicator>(2131298014);
		View topBannersIndicatorContainer = scrollView.RequireViewById<View>(2131298000);
		RecyclerView brandsAndCategories = scrollView.RequireViewById<RecyclerView>(2131296575);
		TextView titleLabel = scrollView.RequireViewById<TextView>(2131298655);
		View topOldPriceGroup = scrollView.RequireViewById<View>(2131297736);
		TextView topOldPriceLabel = scrollView.RequireViewById<TextView>(2131297737);
		TextView unitTypeLabel = scrollView.RequireViewById<TextView>(2131298783);
		TextView topPriceLabel = scrollView.RequireViewById<TextView>(2131297988);
		View stockLabelSpacing = scrollView.RequireViewById<View>(2131298485);
		TextView stockLabel = view.RequireViewById<TextView>(2131298484);
		TextView inSaleDateLabel = scrollView.RequireViewById<TextView>(2131297327);
		ProductDetailsNutrientsView nutrientsView = scrollView.RequireViewById<ProductDetailsNutrientsView>(2131297721);
		ViewGroup viewGroup = scrollView.RequireViewById<ViewGroup>(2131298006);
		TextView textView = scrollView.RequireViewById<TextView>(2131298008);
		ImageView productDetailsButtonIcon = scrollView.RequireViewById<ImageView>(2131298007);
		ViewGroup productDetailsLayout = scrollView.RequireViewById<ViewGroup>(2131298009);
		View productVerifiedCell = scrollView.RequireViewById<View>(2131298022);
		View productVerifiedBottomSpace = scrollView.RequireViewById<View>(2131298020);
		SnackView ageSnack = scrollView.RequireViewById<SnackView>(2131296416);
		SnackView pickupSnack = scrollView.RequireViewById<SnackView>(2131297900);
		SnackView isBadHabitSnack = scrollView.RequireViewById<SnackView>(2131297382);
		_descriptionLabel = scrollView.RequireViewById<CollapsableTextView>(2131296962);
		_characteristicList = scrollView.RequireViewById<RecyclerView>(2131296751);
		_allCharacteristicsButton = scrollView.RequireViewById<TextView>(2131296750);
		_availableShopsList = scrollView.RequireViewById<RecyclerView>(2131298363);
		_allCharacteristicsButton.Visibility = base.ViewModel.AllCharacteristicsButtonVisible.ToInvisibleVisibility();
		_availableShopsButton = scrollView.RequireViewById<ConstraintLayout>(2131296482);
		availableInShopLabel = _availableShopsButton.RequireViewById<TextView>(2131296479);
		_chevronImageDown = _availableShopsButton.RequireViewById<ImageView>(2131296776);
		ConstraintLayout footer = linearLayout.RequireViewById<ConstraintLayout>(2131297211);
		_footerBinder.Bind(base.ViewModel.Footer, footer, ViewLifecycleOwner, base.ViewModel);
		SnackView warningSnackView = linearLayout.RequireViewById<SnackView>(2131296558);
		warningSnackView.Text = base.ViewModel.WarningMessage;
		BadgesView badgesView = scrollView.RequireViewById<BadgesView>(2131296504);
		TextView discountByTextView = scrollView.RequireViewById<TextView>(2131296991);
		View delayedCashbackSnack = scrollView.RequireViewById<View>(2131296913);
		TextView delayedCashbackSnackText = delayedCashbackSnack.RequireViewById<TextView>(2131296914);
		View collectibleSnack = scrollView.RequireViewById<View>(2131296803);
		TextView collectibleSnackText = collectibleSnack.RequireViewById<TextView>(2131296804);
		warningSnackView.Text = base.ViewModel.WarningMessage;
		var (topBannersAdapter, _) = SetupBannerPager(topBanners, touchListenerViewGroup, topBannersIndicator);
		nutrientsView.Visibility = ViewStates.Gone;
		_reviewsList = scrollView.RequireViewById<RecyclerView>(2131298241);
		_smallRateLayout = scrollView.RequireViewById<View>(2131298390);
		_smallRateStarView = scrollView.RequireViewById<ImageView>(2131298391);
		_smallRateRatingTextView = scrollView.RequireViewById<TextView>(2131298388);
		_smallRateReviewCountTextView = scrollView.RequireViewById<TextView>(2131298389);
		_reviewRewardSticker = scrollView.RequireViewById<ReviewRewardStickerView>(2131298232);
		_outOfStockTopLayout = scrollView.RequireViewById<LinearLayout>(2131297829);
		_outOfStockCard = scrollView.RequireViewById<ConstraintLayout>(2131297824);
		_outOfStockCardImage = _outOfStockCard.RequireViewById<ImageView>(2131297825);
		_outOfStockCardTitle = _outOfStockCard.RequireViewById<TextView>(2131297827);
		_outOfStockCardPrice = _outOfStockCard.RequireViewById<TextView>(2131297826);
		RecommendationsView topRecommendations = _outOfStockTopLayout.RequireViewById<RecommendationsView>(2131298713);
		TextView feedbackButton = view.RequireViewById<TextView>(2131297149);
		feedbackButton.Text = base.ViewModel.FeedbackButtonTitle;
		ObservableRecyclerAdapter<CharacteristicItemViewModel, CachingViewHolder> adapter = new ObservableRecyclerAdapter<CharacteristicItemViewModel, CachingViewHolder>
		{
			CellLayoutId = 2131493291,
			BindViewHolderDelegate = OnBindCharacteristic
		};
		textView.Text = base.ViewModel.ProductDetailsText;
		_characteristicList.SetAdapter(adapter);
		_characteristicList.SetLayoutManager(new LinearLayoutManager(base.Activity, 1, reverseLayout: false));
		_productRateView.TitleText.Text = base.ViewModel.ReviewsTitle;
		_productRateView.ShowAllReviewsText.Text = base.ViewModel.ShowAllReviewsButtonTitle;
		_productRateView.AddReviewButton.Text = base.ViewModel.AddReviewButtonTitle;
		_productRateView.NoReviewsText.Text = base.ViewModel.NoReviewsText;
		ConfigureModifications(scrollView);
		ConfigureGluings(scrollView);
		base.ViewModel.OnPropertyChanges((ProductDetailsViewModel x) => x.ImageUrls).StartWith(base.ViewModel.ImageUrls).SafeSubscribe(delegate(IReadOnlyList<string> newBanners)
		{
			SyncBanners(newBanners, topBanners, topBannersAdapter, topBannersIndicator, topBannersIndicatorContainer);
		}, ViewLifecycleOwner);
		ageSnack.Text = base.ViewModel.AgeSnackInfoText;
		pickupSnack.Text = base.ViewModel.PickupSnackInfoText;
		isBadHabitSnack.Text = base.ViewModel.BadHabitSnackInfoText;
		VisibilitySwitch<ProductDetailsViewModel.VisualState> viewSwitch = new VisibilitySwitch<ProductDetailsViewModel.VisualState>(base.ViewModel.State)
		{
			{
				ProductDetailsViewModel.VisualState.Default,
				linearLayout
			},
			{
				ProductDetailsViewModel.VisualState.InProgress,
				frameLayout
			},
			{
				ProductDetailsViewModel.VisualState.Error,
				constraintLayout
			},
			{
				ProductDetailsViewModel.VisualState.Empty,
				constraintLayout2
			}
		};
		base.ViewModel.OnPropertyChanges((ProductDetailsViewModel x) => x.ProductInStock).StartWith(base.ViewModel.ProductInStock).SafeSubscribe(delegate(bool productInStock)
		{
			_outOfStockTopLayout.Visibility = (!productInStock).ToVisibility();
		}, ViewLifecycleOwner);
		base.ViewModel.OnPropertyChanges((ProductDetailsViewModel x) => x.Title).StartWith(base.ViewModel.Title).SafeSubscribe(delegate(string title)
		{
			_outOfStockCardTitle.Text = title;
			titleLabel.Text = title;
		}, ViewLifecycleOwner);
		ObservableRecyclerAdapter<ProductDetailsViewModel, CachingViewHolder> observableRecyclerAdapter = new ObservableRecyclerAdapter<ProductDetailsViewModel, CachingViewHolder>
		{
			CellLayoutId = 2131493293,
			BindViewHolderDelegate = OnBindBrandOrCategoryHeader,
			DataSource = new global::_003C_003Ez__ReadOnlySingleElementList<ProductDetailsViewModel>(base.ViewModel)
		};
		ObservableRecyclerAdapter<ProductDetailsViewModel.BrandOrCategory, CachingViewHolder> bacAdapter = new ObservableRecyclerAdapter<ProductDetailsViewModel.BrandOrCategory, CachingViewHolder>
		{
			CellLayoutId = 2131493292,
			BindViewHolderDelegate = OnBindBrandOrCategory,
			ClickCallback = delegate(CachingViewHolder h, ProductDetailsViewModel.BrandOrCategory i, int p)
			{
				base.ViewModel.BrandOrCategoryCommand.Trigger(i);
			}
		};
		brandsAndCategories.SetAdapter(new ConcatAdapter(observableRecyclerAdapter, bacAdapter));
		Action<bool> detailsDescriptionCollapse = delegate(bool isOpen)
		{
			if (!isOpen)
			{
				_descriptionLabel.Collapse();
			}
		};
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[50]
		{
			(delegate
			{
				viewSwitch.SwitchState(base.ViewModel.State);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("State")),
			(delegate
			{
				BindFavoriteButton(base.ViewModel.FavoritesButtonViewModel);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("FavoritesButtonViewModel")),
			(delegate
			{
				productDetailsLayout.Visibility = base.ViewModel.ProductDetailsOpen.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ProductDetailsOpen")),
			(delegate
			{
				View view2 = productVerifiedCell;
				ViewStates visibility = (productVerifiedBottomSpace.Visibility = base.ViewModel.IsProductVerifiedVisible.ToVisibility());
				view2.Visibility = visibility;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsProductVerifiedVisible")),
			(delegate
			{
				detailsDescriptionCollapse(base.ViewModel.ProductDetailsOpen);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ProductDetailsOpen")),
			(delegate
			{
				productDetailsButtonIcon.SetImageResource(base.ViewModel.ProductDetailsOpen ? 2131231112 : 2131231105);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ProductDetailsOpen")),
			(delegate
			{
				shareButton.Visibility = base.ViewModel.ShareAvailable.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ShareAvailable")),
			(delegate
			{
				topOldPriceLabel.Text = base.ViewModel.OldPrice;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("OldPrice")),
			(delegate
			{
				topOldPriceGroup.Visibility = base.ViewModel.TopOldPriceVisible.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("TopOldPriceVisible")),
			(delegate
			{
				topPriceLabel.Text = base.ViewModel.Price;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Price")),
			(delegate
			{
				topPriceLabel.Visibility = base.ViewModel.TopPriceVisible.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("TopPriceVisible")),
			(delegate
			{
				stockLabelSpacing.Visibility = (base.ViewModel.PriceVisible && !base.ViewModel.IsNotAvaliableInCurrentShopVisible).ToVisibility();
			}, new global::_003C_003Ez__ReadOnlyArray<string>(new string[2] { "PriceVisible", "IsNotAvaliableInCurrentShopVisible" })),
			(delegate
			{
				stockLabel.Text = base.ViewModel.StockInfo;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("StockInfo")),
			(delegate
			{
				stockLabel.Visibility = (!base.ViewModel.IsNotAvaliableInCurrentShopVisible).ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsNotAvaliableInCurrentShopVisible")),
			(delegate
			{
				ChangeAvailableShopsColor(base.ViewModel.AvailableShopsForPickup);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("AvailableShopsForPickup")),
			(delegate
			{
				ReceiveAvailableShopsList(base.ViewModel.AvailableShops);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("AvailableShops")),
			(delegate
			{
				OnIsBlockShopsAvailableChanged(base.ViewModel.IsBlockShopsAvailable);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsBlockShopsAvailable")),
			(delegate
			{
				UpdateStockAndPriceColors(base.ViewModel.ProductInStock, topPriceLabel, stockLabel);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ProductInStock")),
			(delegate
			{
				unitTypeLabel.Text = base.ViewModel.UnitTypeText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("UnitTypeText")),
			(delegate
			{
				unitTypeLabel.Visibility = base.ViewModel.UnitTypeInfoButtonVisible.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("UnitTypeInfoButtonVisible")),
			(delegate
			{
				discountByTextView.Text = base.ViewModel.DiscountBy;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("DiscountBy")),
			(delegate
			{
				discountByTextView.Visibility = base.ViewModel.IsSaleActive.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsSaleActive")),
			(delegate
			{
				inSaleDateLabel.Text = base.ViewModel.DiscountEndDate;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("DiscountEndDate")),
			(delegate
			{
				inSaleDateLabel.Visibility = base.ViewModel.IsSaleActive.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsSaleActive")),
			(delegate
			{
				bacAdapter.DataSource = base.ViewModel.BrandsAndCategories;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("BrandsAndCategories")),
			(delegate
			{
				brandsAndCategories.Visibility = base.ViewModel.IsBrandsAndCategoriesVisible.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsBrandsAndCategoriesVisible")),
			(delegate
			{
				ageSnack.Visibility = base.ViewModel.IsShowAdultSnack.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsShowAdultSnack")),
			(delegate
			{
				pickupSnack.Visibility = base.ViewModel.IsShowAdultSnack.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsShowAdultSnack")),
			(delegate
			{
				isBadHabitSnack.Visibility = base.ViewModel.IsShowAdultSnack.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsShowAdultSnack")),
			(delegate
			{
				warningSnackView.Visibility = base.ViewModel.IsWarningVisible.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsWarningVisible")),
			(delegate
			{
				OnDescriptionChanged(base.ViewModel.Description);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Description")),
			(delegate
			{
				adapter.DataSource = base.ViewModel.Characteristics;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Characteristics")),
			(delegate
			{
				_allCharacteristicsButton.Text = base.ViewModel.AllCharacteristicsString;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("AllCharacteristicsString")),
			(delegate
			{
				_allCharacteristicsButton.Visibility = (base.ViewModel.AllCharacteristicsButtonVisible && base.ViewModel.ProductDetailsOpen).ToInvisibleVisibility();
			}, new global::_003C_003Ez__ReadOnlyArray<string>(new string[2] { "AllCharacteristicsButtonVisible", "ProductDetailsOpen" })),
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
				okButton.Text = base.ViewModel.OkEmptyText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("OkEmptyText")),
			(delegate
			{
				emptyTitle.Text = base.ViewModel.EmptyOffersText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("EmptyOffersText")),
			(delegate
			{
				showQrButton.Visibility = base.ViewModel.IsAuthorized.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsAuthorized")),
			(delegate
			{
				badgesView.SetBadges(base.ViewModel.Badges);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Badges")),
			(delegate
			{
				ConfigureReviewViews(base.ViewModel.Rate, base.ViewModel.ReviewList);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ReviewList")),
			(delegate
			{
				_reviewRewardSticker.Setup(base.ViewModel.ReviewRewardSticker);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ReviewRewardSticker")),
			(delegate
			{
				delayedCashbackSnack.Visibility = base.ViewModel.IsDelayedCashbackTextVisible.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsDelayedCashbackTextVisible")),
			(delegate
			{
				delayedCashbackSnackText.AddLinkedText(base.ViewModel.DelayedCashbackText, new global::Android.Graphics.Color(ContextCompat.GetColor(Context, 2131100550)), underlineLinks: false);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("DelayedCashbackText")),
			(delegate
			{
				collectibleSnack.Visibility = base.ViewModel.ShouldDisplayStampsInformer.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ShouldDisplayStampsInformer")),
			(delegate
			{
				collectibleSnackText.AddLinkedText(base.ViewModel.StampsInformerText, new global::Android.Graphics.Color(ContextCompat.GetColor(Context, 2131100550)), underlineLinks: false);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("StampsInformerText")),
			(delegate
			{
				_outOfStockCardImage.FromUrl(base.ViewModel.ImageUrls.FirstOrDefault());
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ImageUrls")),
			(delegate
			{
				_outOfStockCardPrice.Text = base.ViewModel.Price;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Price")),
			(delegate
			{
				_outOfStockCardPrice.Visibility = base.ViewModel.PriceVisible.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("PriceVisible")),
			(delegate
			{
				feedbackButton.Visibility = base.ViewModel.IsForPriceCheckerCase.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsForPriceCheckerCase"))
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.BottomRecommendations.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[2]
		{
			(delegate
			{
				bottomRecommendationsView.Visibility = base.ViewModel.BottomRecommendations.HasItems.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("HasItems")),
			(delegate
			{
				bottomRecommendationsDivider.Visibility = base.ViewModel.BottomRecommendations.HasItems.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("HasItems"))
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.TopRecommendations.BindProperties(new global::_003C_003Ez__ReadOnlySingleElementList<(Action, IReadOnlyList<string>)>((delegate
		{
			topRecommendations.Visibility = base.ViewModel.TopRecommendations.HasItems.ToVisibility();
		}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("HasItems")))).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.BindEvents(viewGroup.OnClick(base.ViewModel.OnProductDetailsCommand.Trigger), productVerifiedCell.OnClick(ShowProductVerifiedPopup), shareButton.OnClick(base.ViewModel.ShareCommand.Trigger), _availableShopsButton.OnClick(AvailableShopsButtonClicked), okButton.OnClick(base.ViewModel.CloseProductDetailsCommand.Trigger), _smallRateLayout.OnClick((Action)delegate
		{
			base.ViewModel.NavigateToReviews();
		}), _reviewRewardSticker.OnClick(base.ViewModel.OnReviewRewardStickerTapped), _productRateView.RatingLayout.OnClick((Action)delegate
		{
			base.ViewModel.NavigateToReviews();
		}), _productRateView.AddReviewButton.OnClick(base.ViewModel.AddReviewCommand.Trigger), ((View)_productRateView.ShowAllReviewsButton).OnClick((Action)delegate
		{
			base.ViewModel.NavigateToReviews();
		}), _allCharacteristicsButton.OnClick(base.ViewModel.ShowAllCharacteristicsCommand.Trigger), appCompatButton.OnClick(base.ViewModel.Retry), ((View)showQrButton).OnClick((Action)delegate
		{
			Show<LoyaltyCardPdf417PortraitFragment>();
		}), ((View)_outOfStockCard).OnClick((Action)delegate
		{
			scrollView.SmoothScrollTo(0, _outOfStockTopLayout.Bottom);
		}), ((View)feedbackButton).OnClick((Action)delegate
		{
			base.ViewModel.FeedbackCommand.Trigger();
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		topRecommendations.SetupWithScrollView(base.ViewModel, base.ViewModel.TopRecommendations, ViewLifecycleOwner, scrollView);
		bottomRecommendationsView.SetupWithScrollView(base.ViewModel, base.ViewModel.BottomRecommendations, ViewLifecycleOwner, scrollView);
		base.ViewModel.BottomRecommendations.ShowQtyDialogCommand.SafeSubscribe(ShowQtyRecommendationsInputDialog, ViewLifecycleOwner);
		base.ViewModel.BottomRecommendations.ShowAllCommand.SafeSubscribe(GoToStaticList, ViewLifecycleOwner);
		base.ViewModel.BottomRecommendations.NavigateToProductCommand.SafeSubscribe(OpenProductDetails, ViewLifecycleOwner);
		base.ViewModel.NavigateToProductCommand.SafeSubscribe(OpenProductDetails, ViewLifecycleOwner);
		base.ViewModel.BottomRecommendations.OpenReviewsCommand.SafeSubscribe(delegate(ProductReviewsViewModel.Parameter p)
		{
			NavigateToReviews(p);
		}, ViewLifecycleOwner);
		base.ViewModel.TopRecommendations.ShowQtyDialogCommand.SafeSubscribe(ShowQtyRecommendationsInputDialog, ViewLifecycleOwner);
		base.ViewModel.TopRecommendations.ShowAllCommand.SafeSubscribe(GoToStaticList, ViewLifecycleOwner);
		base.ViewModel.TopRecommendations.NavigateToProductCommand.SafeSubscribe(OpenProductDetails, ViewLifecycleOwner);
		base.ViewModel.TopRecommendations.OpenReviewsCommand.SafeSubscribe(delegate(ProductReviewsViewModel.Parameter p)
		{
			NavigateToReviews(p);
		}, ViewLifecycleOwner);
		base.ViewModel.NavigateToAddReviewCommand.SafeSubscribe(delegate(BrokerToken x)
		{
			Show<AddReviewFragment, BrokerToken>(x);
		}, ViewLifecycleOwner);
		base.ViewModel.OpenReviewsCommand.SafeSubscribe(NavigateToReviews, ViewLifecycleOwner);
		base.ViewModel.ShowReviewRewardTooltipCommand.SafeSubscribe(delegate(string text)
		{
			HintPopup.Show(base.ViewModel, text, _reviewRewardSticker, default(System.Drawing.Point), atTop: true, checkAnchorVisibility: true, default(Size), default(Size), null, centerOnAnchor: true, useLightTheme: true, 216);
		}, ViewLifecycleOwner);
		base.ViewModel.ShowNutrientsCommand.SafeSubscribe(delegate(ProductDetailsNutrientsElementViewModel vm)
		{
			nutrientsView.Bind(vm, ViewLifecycleOwner);
		}, ViewLifecycleOwner);
		base.ViewModel.OpenMenuOptionsCommand.SafeSubscribe(delegate(BrokerToken p)
		{
			Show<ReportReviewFragment, BrokerToken>(p);
		}, ViewLifecycleOwner);
		base.ViewModel.NavigateToFeedback.SafeSubscribe(delegate
		{
			Intent intent = new Intent(Context, typeof(FeedbackActivity));
			intent.PutExtra("ForCase", 1);
			StartActivity(intent);
		}, ViewLifecycleOwner);
	}

	private void OnDescriptionChanged(string description)
	{
		if (string.IsNullOrWhiteSpace(description))
		{
			_descriptionLabel.Visibility = ViewStates.Gone;
			return;
		}
		_descriptionLabel.Visibility = ViewStates.Visible;
		_descriptionLabel.Setup(description, base.ViewModel.MoreDescriptionString, base.ViewModel.MaxDescriptionLinesCollapsed, base.Resources.DisplayMetrics.WidthPixels - Converter.DpToPx(40f));
	}

	private void OnBindBrandOrCategoryHeader(CachingViewHolder holder, ProductDetailsViewModel model, int position, CompositeDisposable disposable)
	{
	}

	private void OnBindBrandOrCategory(CachingViewHolder holder, ProductDetailsViewModel.BrandOrCategory category, int position, CompositeDisposable disposable)
	{
		holder.RequireCachedView<TextView>(2131298646).Text = category.Title;
	}

	private void NavigateToReviews(ProductReviewsViewModel.Parameter parameter)
	{
		base.ParentFragmentManager.BeginTransaction().Hide(this).Add<ProductReviewsFragment>(this, parameter.ToNavBundle())
			.AddToBackStack(null)
			.Commit();
	}

	private void SetupReviewsList(IReadOnlyList<Review> reviews)
	{
		ObservableRecyclerAdapter<Review, CachingViewHolder> adapter = new ObservableRecyclerAdapter<Review, CachingViewHolder>
		{
			CellLayoutId = 2131493183,
			DataSource = reviews.Take(30).ToList(),
			BindViewHolderDelegate = OnBindReviewInList,
			ClickCallback = OnReviewClicked
		};
		CustomSizeLinearLayoutManager customSizeLinearLayoutManager = new CustomSizeLinearLayoutManager(Context, 0, reverseLayout: false);
		float dpFactor = base.Resources.DisplayMetrics.Density;
		customSizeLinearLayoutManager.CellSizeFunc = delegate
		{
			int width = _reviewsList.Width;
			return new RecyclerView.LayoutParams((int)((reviews.Count > 1) ? ((float)width - 55f * dpFactor) : ((float)width - 32f * dpFactor)), (int)(358f * dpFactor));
		};
		_reviewsList.SetLayoutManager(customSizeLinearLayoutManager);
		_reviewsList.SetAdapter(adapter);
	}

	private void OnReviewClicked(CachingViewHolder vh, Review vm, int pos)
	{
		base.ViewModel.NavigateToReviews(vm);
	}

	private void OnBindReviewInList(CachingViewHolder holder, Review entry, int position, CompositeDisposable disposable)
	{
		ReviewView? reviewView = holder.FindCachedView<ReviewView>(2131298240);
		reviewView.ClearSubscriptions();
		reviewView.Setup(entry, delegate
		{
			base.ViewModel.NavigateToReviews(entry);
		}, ReviewViewMode.CompactPreviewCarousel, disposable);
		reviewView.OnThumbnailTappedEvent(OnThumbnailTapped).AutoDisposeOnDestroy(ViewLifecycleOwner);
		reviewView.MenuOptionsView.OnClick((Action)delegate
		{
			base.ViewModel.OnMenuOptionsCommand.Trigger(entry);
		});
	}

	private void ShowProductVerifiedPopup()
	{
		ProductVerifiedPopupViewModel.Parameter parameter = new ProductVerifiedPopupViewModel.Parameter
		{
			Certificates = base.ViewModel.ProductsCertificate
		};
		ProductVerifiedPopupFragment productVerifiedPopupFragment = _fragmentFactory.Instantiate<ProductVerifiedPopupFragment>();
		productVerifiedPopupFragment.Arguments = parameter.ToNavBundle();
		productVerifiedPopupFragment.Show(base.ChildFragmentManager, null);
	}

	private void OnThumbnailTapped(IReadOnlyList<string> urls, int index)
	{
		ZoomableImageSliderFragment zoomableImageSliderFragment = _fragmentFactory.Instantiate<ZoomableImageSliderFragment>();
		zoomableImageSliderFragment.ImageItemViewModels.AddRange(urls.Select((string x) => new ImageItemViewModel(x)));
		zoomableImageSliderFragment.CurrentIndex = index;
		zoomableImageSliderFragment.Show(base.ChildFragmentManager, null);
	}

	private void ReceiveAvailableShopsList(IReadOnlyList<AvailableShop> items)
	{
		if (items != null)
		{
			ObservableRecyclerAdapter<AvailableShop, CachingViewHolder> adapter = new ObservableRecyclerAdapter<AvailableShop, CachingViewHolder>
			{
				CellLayoutId = 2131493343,
				DataSource = base.ViewModel.AvailableShops,
				BindViewHolderDelegate = OnBindAvailableShops
			};
			_availableShopsList.SetAdapter(adapter);
		}
	}

	private void ChangeAvailableShopsColor(string availableShopsForPickup)
	{
		if (base.ViewModel.IsAvailableShopsForPickup)
		{
			availableInShopLabel.Text = availableShopsForPickup;
			availableInShopLabel.ChangeColorOfPartTextView(availableShopsForPickup, 26, availableShopsForPickup.Length, 2131099854);
		}
	}

	private void OnIsBlockShopsAvailableChanged(bool isBlockShopsAvailable)
	{
		_availableShopsButton.Visibility = isBlockShopsAvailable.ToVisibility();
		if (!isBlockShopsAvailable && _availableshopsclicked)
		{
			_availableshopsclicked = false;
			_chevronImageDown.Rotation = 0f;
			_availableShopsList.Visibility = ViewStates.Gone;
		}
	}

	private void AvailableShopsButtonClicked()
	{
		_availableShopsList.Visibility = (!_availableshopsclicked).ToVisibility();
		_availableshopsclicked = !_availableshopsclicked;
		_chevronImageDown.Animate().Rotation(180 * Convert.ToInt32(_availableshopsclicked));
	}

	private void UpdateStockAndPriceColors(bool productInStock, TextView priceLabel, TextView stockLabel)
	{
		stockLabel.SetTextColor(ContextCompat.GetColorStateList(Context, productInStock ? 2131099854 : 2131099706));
		priceLabel.SetTextColor(ContextCompat.GetColorStateList(Context, productInStock ? 2131099706 : 2131099704));
	}

	private void ConfigureGluings(View view)
	{
		RecyclerView recyclerView = view.RequireViewById<RecyclerView>(2131297243);
		ObservableRecyclerAdapter<ProductGluingRowViewModel, CachingViewHolder> adapter = new ObservableRecyclerAdapter<ProductGluingRowViewModel, CachingViewHolder>
		{
			CellLayoutId = 2131493295,
			BindViewHolderDelegate = OnBindGluingRow,
			DataSource = base.ViewModel.GluingRows
		};
		recyclerView.SetAdapter(adapter);
		recyclerView.SetLayoutManager(new LinearLayoutManager(Context, 1, reverseLayout: false));
	}

	private void OnBindGluingRow(CachingViewHolder vh, ProductGluingRowViewModel vm, int position, CompositeDisposable disposable)
	{
		BindGluingRow(vh, vm, disposable, 2131493255, delegate(CachingViewHolder itemVh, GluingValueViewModel itemVm, int _, CompositeDisposable itemDisposables)
		{
			OnBindGluingValueCell(itemVh, itemVm, itemDisposables);
		});
	}

	private void BindGluingRow(CachingViewHolder vh, ProductGluingRowViewModel vm, CompositeDisposable disposable, int cellLayoutId, Action<CachingViewHolder, GluingValueViewModel, int, CompositeDisposable> bindViewHolderDelegate)
	{
		TextView textView = vh.RequireCachedView<TextView>(2131297893);
		TextView textView2 = vh.RequireCachedView<TextView>(2131298339);
		RecyclerView recyclerView = vh.RequireCachedView<RecyclerView>(2131297585);
		ColorStateList textColors = textView2.TextColors;
		ObservableRecyclerAdapter<GluingValueViewModel, CachingViewHolder> adapter = new ObservableRecyclerAdapter<GluingValueViewModel, CachingViewHolder>
		{
			CellLayoutId = cellLayoutId,
			BindViewHolderDelegate = bindViewHolderDelegate,
			DataSource = vm.Values
		};
		recyclerView.SetAdapter(adapter);
		recyclerView.SetLayoutManager(new LinearLayoutManager(Context, 0, reverseLayout: false));
		textView.Text = vm.Title;
		textView2.Text = string.Empty;
		textView2.SetTextColor(textColors);
		GluingValueViewModel gluingValueViewModel = vm.Values.FirstOrDefault((GluingValueViewModel v) => v.State == GluingValueState.Selected);
		if (gluingValueViewModel != null)
		{
			int position = vm.Values.IndexOf(gluingValueViewModel);
			recyclerView.ScrollToPosition(position);
		}
	}

	private void OnBindGluingValueCell(CachingViewHolder vh, GluingValueViewModel vm, CompositeDisposable disposables)
	{
		View itemView = vh.ItemView;
		TextView textView = vh.RequireCachedView<TextView>(2131297583);
		View view = vh.RequireCachedView<View>(2131297584);
		textView.Text = vm.Value;
		view.Activated = vm.State == GluingValueState.Default;
		view.Selected = vm.State == GluingValueState.Selected;
		view.Hovered = vm.State == GluingValueState.GrayedOut;
		textView.SetTextColor(new global::Android.Graphics.Color(ContextCompat.GetColor(id: (vm.State == GluingValueState.GrayedOut) ? 2131099849 : 2131099872, context: Context)));
		itemView.OnClick((Action)delegate
		{
			base.ViewModel.GluingValueSelected(vm);
		}).AddTo(disposables);
	}

	private void ConfigureModifications(View view)
	{
		RecyclerView recyclerView = view.RequireViewById<RecyclerView>(2131297585);
		ObservableRecyclerAdapter<ProductModificationItemViewModel, CachingViewHolder> adapter = new ObservableRecyclerAdapter<ProductModificationItemViewModel, CachingViewHolder>
		{
			CellLayoutId = 2131493295,
			BindViewHolderDelegate = OnBindPicker,
			DataSource = base.ViewModel.Modifications
		};
		recyclerView.SetAdapter(adapter);
		recyclerView.SetLayoutManager(new LinearLayoutManager(Context, 1, reverseLayout: false));
	}

	private void OnBindPicker(CachingViewHolder vh, IModificationItemViewModel vm, int position, CompositeDisposable disposable)
	{
		switch (vm.Modification.ViewType)
		{
		case ModificationValueType.Enum:
			BindPicker(vh, vm, disposable, 2131493255, delegate(CachingViewHolder itemVh, ModificationValueViewModel itemVm, int _, CompositeDisposable itemDisposables)
			{
				OnBindEnumModification(vm, itemVh, itemVm, itemDisposables);
			});
			break;
		case ModificationValueType.Image_picker:
			BindPicker(vh, vm, disposable, 2131493256, delegate(CachingViewHolder itemVh, ModificationValueViewModel itemVm, int _, CompositeDisposable itemDisposables)
			{
				OnBindImageModification(vm, itemVh, itemVm, itemDisposables);
			});
			break;
		default:
			throw new ArgumentOutOfRangeException();
		}
	}

	private void BindPicker(CachingViewHolder vh, IModificationItemViewModel vm, CompositeDisposable disposable, int cellLayoutId, Action<CachingViewHolder, ModificationValueViewModel, int, CompositeDisposable> bindViewHolderDelegate)
	{
		TextView modificationNameTextView = vh.RequireCachedView<TextView>(2131297893);
		TextView modificationValueTextView = vh.RequireCachedView<TextView>(2131298339);
		RecyclerView recyclerView = vh.RequireCachedView<RecyclerView>(2131297585);
		ColorStateList originalValueColor = modificationValueTextView.TextColors;
		ObservableRecyclerAdapter<ModificationValueViewModel, CachingViewHolder> adapter = new ObservableRecyclerAdapter<ModificationValueViewModel, CachingViewHolder>
		{
			CellLayoutId = cellLayoutId,
			BindViewHolderDelegate = bindViewHolderDelegate,
			DataSource = vm.Values
		};
		recyclerView.SetAdapter(adapter);
		recyclerView.SetLayoutManager(new LinearLayoutManager(Context, 0, reverseLayout: false));
		vm.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[3]
		{
			(delegate
			{
				modificationNameTextView.Text = vm.ModificationTitle;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ModificationTitle")),
			(delegate
			{
				SetModificationValueText();
			}, new global::_003C_003Ez__ReadOnlyArray<string>(new string[3] { "IsValueSelected", "ModificationHint", "ModificationValue" })),
			(delegate
			{
				SetModificationValueColor();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsValueSelected"))
		})).AddTo(disposable);
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[2]
		{
			(delegate
			{
				SetModificationValueText();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsWarningVisible")),
			(delegate
			{
				SetModificationValueColor();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsWarningVisible"))
		})).AddTo(disposable);
		void SetModificationValueColor()
		{
			modificationValueTextView.SetTextColor((base.ViewModel.IsWarningVisible && !vm.IsValueSelected) ? ContextCompat.GetColorStateList(Context, 2131100557) : originalValueColor);
		}
		void SetModificationValueText()
		{
			modificationValueTextView.Text = ((base.ViewModel.IsWarningVisible && !vm.IsValueSelected) ? vm.ModificationHint : vm.ModificationValue);
		}
	}

	private void OnBindEnumModification(IModificationItemViewModel parentPickerVm, CachingViewHolder vh, ModificationValueViewModel vm, CompositeDisposable disposables)
	{
		View itemView = vh.ItemView;
		TextView textView = vh.RequireCachedView<TextView>(2131297583);
		View view = vh.RequireCachedView<View>(2131297584);
		textView.Text = vm.Text;
		view.Activated = true;
		BindModification(parentPickerVm, vm, itemView, view, disposables);
	}

	private void OnBindImageModification(IModificationItemViewModel parentPickerVm, CachingViewHolder vh, ModificationValueViewModel vm, CompositeDisposable disposables)
	{
		ImageView imageView = vh.RequireCachedView<ImageView>(2131297581);
		View card = vh.RequireCachedView<View>(2131297582);
		if (!string.IsNullOrEmpty(vm.Preview))
		{
			imageView.FromUrl(vm.Preview);
		}
		BindModification(parentPickerVm, vm, imageView, card, disposables);
	}

	private void BindModification(IModificationItemViewModel parentPickerVm, ModificationValueViewModel vm, View clickable, View card, CompositeDisposable disposables)
	{
		card.Activated = true;
		vm.BindProperties(new global::_003C_003Ez__ReadOnlySingleElementList<(Action, IReadOnlyList<string>)>((delegate
		{
			card.Selected = vm.Selected;
			card.Activated = !vm.Selected;
			card.Hovered = false;
			card.Invalidate();
		}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Selected")))).AddTo(disposables);
		vm.OnSelect.ObserveOn(MainThread.Scheduler).Subscribe(delegate(ModificationValueViewModel selected)
		{
			parentPickerVm.OnSelectValue(selected);
			base.ViewModel.WriteSelected(parentPickerVm, selected);
		}).AddTo(disposables);
		clickable.OnClick(vm.Tap).AddTo(disposables);
	}

	private (EndlessRecyclerAdapter<string> adapter, ViewPager2AutoScroller autoScroller) SetupBannerPager(ViewPager2 pager, TouchListenerViewGroup pagerTouchIntercepter, CircleIndicator bannersIndicator)
	{
		float num = (float)(base.Resources.DisplayMetrics.WidthPixels - pager.PaddingStart - pager.PaddingEnd) / 2.1612904f;
		pagerTouchIntercepter.LayoutParameters.Height = (int)num;
		pagerTouchIntercepter.RequestLayout();
		EndlessRecyclerAdapter<string> adapter = new EndlessRecyclerAdapter<string>
		{
			MinItemsForEndless = 3,
			CellLayoutId = 2131493299,
			BindViewHolderDelegate = OnBindBanner
		};
		pager.OffscreenPageLimit = 2;
		pager.SetPageTransformer(new MarginPageTransformer(Converter.DpToPx(10f)));
		pager.Adapter = adapter;
		ViewPager2AutoScroller viewPager2AutoScroller = new ViewPager2AutoScroller(pager)
		{
			Interval = TimeSpan.FromSeconds(2L),
			InterruptedDelay = TimeSpan.FromSeconds(3L),
			InitialPosition = (RecyclerView.Adapter _) => adapter.FirstItemAdapterPosition
		};
		viewPager2AutoScroller.AutoDisposeOnDestroy(ViewLifecycleOwner);
		pagerTouchIntercepter.AddTouchListener(viewPager2AutoScroller);
		pager.RegisterOnPageChangeCallback(new ViewPager2OnPageChangeCallback(delegate(int position)
		{
			int position2 = adapter.RealPosition(position);
			bannersIndicator.AnimatePageSelected(position2);
		}));
		return (adapter: adapter, autoScroller: viewPager2AutoScroller);
	}

	private void OnBindBanner(CachingViewHolder holder, string url, int position, CompositeDisposable disposable)
	{
		ImageView? imageView = holder.FindCachedView<ImageView>(2131298011);
		((View)imageView).OnClick((Action)delegate
		{
			ZoomableImageSliderFragment zoomableImageSliderFragment = _fragmentFactory.Instantiate<ZoomableImageSliderFragment>();
			zoomableImageSliderFragment.ImageItemViewModels.AddRange(base.ViewModel.ImageUrls.Select((string x) => new ImageItemViewModel(x)));
			zoomableImageSliderFragment.CurrentIndex = position;
			zoomableImageSliderFragment.Show(base.ChildFragmentManager, null);
		}).AddTo(disposable);
		imageView.FromUrl(url);
	}

	private static void SyncBanners(IReadOnlyList<string> newBanners, ViewPager2 pager, EndlessRecyclerAdapter<string> adapter, CircleIndicator indicator, View indicatorContainer)
	{
		adapter.DataSource = newBanners;
		pager.SetCurrentItem(adapter.FirstItemAdapterPosition, smoothScroll: false);
		if (adapter.DataSource.Count > 1)
		{
			indicator.CreateIndicators(adapter.DataSource.Count, 0);
		}
		indicatorContainer.Visibility = (newBanners.Count > 1).ToVisibility();
	}

	private void OnBindCharacteristic(CachingViewHolder holder, CharacteristicItemViewModel model, int position, CompositeDisposable disposable)
	{
		TextView? textView = holder.FindCachedView<TextView>(2131297413);
		TextView textView2 = holder.FindCachedView<TextView>(2131298795);
		ImageButton imageButton = holder.FindCachedView<ImageButton>(2131296849);
		textView.Text = model.Title;
		textView2.Text = model.Value;
		global::Android.Graphics.Color color = global::Android.Graphics.Color.Rgb(0, 133, 77);
		global::Android.Graphics.Color color2 = new global::Android.Graphics.Color(ContextCompat.GetColor(Context, 2131099706));
		textView2.SetTextColor(model.IsArticle ? color : color2);
		imageButton.Visibility = model.IsArticle.ToVisibility();
		if (model.IsArticle)
		{
			((View)imageButton).OnClick((Action)delegate
			{
				model.CopyNumber();
			}).AddTo(disposable);
			((View)textView2).OnClick((Action)delegate
			{
				model.CopyNumber();
			}).AddTo(disposable);
		}
	}

	private void OnBindAvailableShops(CachingViewHolder holder, AvailableShop availableShop, int position, CompositeDisposable disposable)
	{
		TextView textView = holder.FindCachedView<TextView>(2131298528);
		textView.SetText("АШАН " + availableShop.Name, TextView.BufferType.Normal);
		TextView textView2 = holder.FindCachedView<TextView>(2131298130);
		textView2.SetText(base.ViewModel.FromShopToQty(availableShop), TextView.BufferType.Normal);
		if (availableShop.AddressString.Contains(base.ViewModel.CurrentStoreAddress) || base.ViewModel.CurrentStoreAddress.Contains(availableShop.AddressString))
		{
			textView.SetTypeface(null, TypefaceStyle.Bold);
			textView2.SetTypeface(null, TypefaceStyle.Bold);
		}
		holder.FindCachedView<TextView>(2131298523).SetText(availableShop.AddressString, TextView.BufferType.Normal);
	}

	private void NavigateToProductsByBrand(ProductsViewModel.Parameter parameter)
	{
		NavigateTo<ProductsFragment, ProductsViewModel.Parameter>(parameter, null, add: true);
	}

	private void NavigateToCategory(BrokerToken parameter)
	{
		NavigateTo<CatalogProductsFragment, BrokerToken>(parameter, null, add: true);
	}

	private void GoToStaticList(BrokerToken arg)
	{
		base.ParentFragmentManager.BeginTransaction().Hide(this).Add<StaticProductListFragment>(this, arg.ToNavBundle())
			.AddToBackStack(null)
			.Commit();
	}

	private void OpenProductDetails(ProductDetailsViewModel.Parameter parameter)
	{
		if (parameter.ReplaceLastInBackStack)
		{
			FragmentManager parentFragmentManager = base.ParentFragmentManager;
			Fragment[] array = parentFragmentManager.Fragments.ToArray();
			Fragment fragment = array[Math.Max(array.IndexOf(this) - 1, 0)];
			parentFragmentManager.PopBackStack();
			parentFragmentManager.BeginTransaction().AddToBackStack(null).Hide(fragment)
				.Add<ProductDetailsFragment>(fragment, parameter.ToNavBundle())
				.Commit();
		}
		else
		{
			NavigateTo<ProductDetailsFragment, ProductDetailsViewModel.Parameter>(parameter, null, add: true);
		}
	}

	private void BindFavoriteButton(FavoritesButtonViewModel viewModel)
	{
		if (viewModel != null && !_favoritesBound)
		{
			_favoritesBound = true;
			viewModel.BindProperties(new global::_003C_003Ez__ReadOnlySingleElementList<(Action, IReadOnlyList<string>)>((delegate
			{
				SetFavoriteState(viewModel.ProductInFavorites);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ProductInFavorites")))).AutoDisposeOnDestroy(ViewLifecycleOwner);
			((View)_favoriteButton).OnClick((Action)delegate
			{
				base.ViewModel.FavoritesButtonViewModel.OnHeartClicked();
			}).AutoDisposeOnDestroy(ViewLifecycleOwner);
		}
	}

	private void ConfigureReviewViews(Rate rate, ReviewList reviewList)
	{
		IReadOnlyList<Review> source = reviewList?.Reviews ?? Array.Empty<Review>();
		int valueOrDefault = (rate?.ReviewsCount).GetValueOrDefault();
		double valueOrDefault2 = (rate?.Rating).GetValueOrDefault();
		_smallRateRatingTextView.Text = $"{valueOrDefault2:0.#}";
		_smallRateRatingTextView.Visibility = (valueOrDefault > 0).ToVisibility();
		_smallRateReviewCountTextView.Text = base.ViewModel.ReviewCountText;
		_smallRateStarView.SetImageResource((valueOrDefault2 > 0.0) ? 2131231374 : 2131231375);
		_smallRateReviewCountTextView.SetTextColor(ContextCompat.GetColorStateList(Context, 2131100604));
		_reviewsList.Visibility = (source.Any() && valueOrDefault > 0).ToVisibility();
		SetupReviewsList(source.ToList());
		_productRateView.Visibility = (valueOrDefault > 0 || base.ViewModel.ReviewingIsAllowed).ToVisibility();
		_productRateView.ReviewCountText.Text = base.ViewModel.ReviewCountText;
		_productRateView.RatingView.SetupReadOnly(valueOrDefault2, 16f, 2f);
		_productRateView.RatingText.Text = $"{valueOrDefault2:0.#}";
		_productRateView.ShowAllReviewsButton.Visibility = (valueOrDefault > 0 && source.Any()).ToVisibility();
		_productRateView.HasReviews = valueOrDefault > 0;
		_productRateView.AddReviewButton.Visibility = base.ViewModel.ReviewingIsAllowed.ToVisibility();
	}

	private void SetFavoriteState(bool isInfavorites)
	{
		_favoriteButton.SetBackgroundResource(isInfavorites ? 2131231168 : 2131231165);
	}

	private void ShowQtyRecommendationsInputDialog(ProductItemViewModel vm)
	{
		ProductItemViewHolder.ShowQtyInputDialog(vm, base.LayoutInflater, Context);
	}
}
