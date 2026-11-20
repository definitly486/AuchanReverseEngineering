using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reactive.Disposables;
using Android.Animation;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Runtime;
using Android.Text;
using Android.Util;
using Android.Views;
using Android.Views.Animations;
using Android.Views.InputMethods;
using Android.Widget;
using AndroidX.AppCompat.App;
using AndroidX.AppCompat.Widget;
using AndroidX.ConstraintLayout.Widget;
using AndroidX.Core.Content;
using AndroidX.Core.Widget;
using AndroidX.Fragment.App;
using AndroidX.RecyclerView.Widget;
using AndroidX.ViewPager2.Widget;
using AsyncAwaitBestPractices;
using Auchan.Android.Base;
using Auchan.Android.Common.UiUtils;
using Auchan.Android.Controls;
using Auchan.Android.Controls.Badges;
using Auchan.Android.Ecom.Product;
using Auchan.Android.Extensions;
using Auchan.Common.Analytics.YandexAppMetrica;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Common.Binding;
using Auchan.Common.DependencyInjection;
using Auchan.Common.Ecom.ProducModels;
using Auchan.Common.Ecom.ProducModels.ViewModels;
using Auchan.Common.Ecom.Products.ViewModels;
using Auchan.Common.Extensions;
using Auchan.Common.Profile;
using Bumptech.Glide.Load;
using DryIoc;
using EBind;
using Google.Android.Material.TextField;
using JP.Wasabeef.Glide.Transformations;
using Me.Relex.CircleIndicatorLib;

namespace Auchan.Android.Catalog;

internal sealed class ProductItemViewHolder : CachingViewHolder
{
	public const int CardHeightDp = 288;

	private const int GridSideMarginsDp = 50;

	private const int HorizontalCardNarrowingDp = 16;

	private const int CounterButtonSizeDp = 40;

	private const int PriceRowHeightDp = 20;

	private const int PriceFromRowHeightDp = 14;

	private const int OutOfStockPlateHeightDp = 40;

	private const int OutOfStockLineHeightDp = 14;

	private bool _outOfStockOnPlate;

	private bool _replacementButtonVisible;

	private const long CounterAnimationDurationMs = 120L;

	private readonly ImageView _favoriteButton;

	private readonly ViewPager2 _imagesPager;

	private readonly CircleIndicator _imagesIndicator;

	private readonly ObservableRecyclerAdapter<string, CachingViewHolder> _imagesAdapter;

	private readonly LinearLayout _ratingLayout;

	private readonly ImageView _starImageView;

	private readonly TextView _ratingTextView;

	private readonly ImageView _cloudImageView;

	private readonly TextView _reviewCountTextView;

	private readonly TextView _titleLabel;

	private readonly TextView _packageLabel;

	private readonly ConstraintLayout _outOfStockStateView;

	private readonly TextView _oldPriceLabel;

	private readonly View _oldPriceCrossingLine;

	private readonly TextView _priceLabel;

	private readonly View _priceBlock;

	private readonly View _actionClickableView;

	private readonly View _addingStateView;

	private readonly View _counterMiddle;

	private readonly AppCompatImageButton _increaseButton;

	private readonly TextView _countLabel;

	private readonly LinearLayout _promoLayout;

	private readonly AppCompatImageButton _decreaseButton;

	private readonly TextView _outOfStockLabel;

	private readonly TextView _availableInShopLabel;

	private readonly BadgesView _badgesView;

	private readonly TextView _discountPrefix;

	private readonly TextView _discountEndDate;

	private readonly TextView _discountByLoyaltyProgram;

	private readonly View _priceView;

	private readonly TextView _priceSubTotal;

	private readonly AdultsOnlyControls _adultsOnlyControls;

	private FragmentManager? _fragmentManager;

	private readonly HighlightedTextView _hintLabel;

	private readonly ImageView _topSubscribeButton;

	private readonly AppCompatButton _bottomSubscribeButton;

	private readonly AppCompatButton _findReplacementButton;

	private ProductItemViewModel? _boundViewModel;

	private ValueAnimator? _counterAnimator;

	private bool _cartStateApplied;

	private bool _collapseAddButton;

	private bool _isCounterShown;

	private bool _isAddButtonShown;

	public static int GetHorizontalCardWidthPx(Context context)
	{
		return (context.Resources.DisplayMetrics.WidthPixels - Converter.DpToPx(50f)) / 2 - Converter.DpToPx(16f);
	}

	public ProductItemViewHolder(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	public ProductItemViewHolder(View itemView)
		: base(itemView)
	{
		_favoriteButton = itemView.RequireViewById<ImageView>(2131297148);
		_topSubscribeButton = itemView.RequireViewById<ImageView>(2131298558);
		_bottomSubscribeButton = itemView.RequireViewById<AppCompatButton>(2131298556);
		_findReplacementButton = itemView.RequireViewById<AppCompatButton>(2131297178);
		_imagesPager = itemView.RequireViewById<ViewPager2>(2131298013);
		_imagesIndicator = itemView.RequireViewById<CircleIndicator>(2131298014);
		_imagesAdapter = new ObservableRecyclerAdapter<string, CachingViewHolder>
		{
			CellLayoutId = 2131493289,
			BindViewHolderDelegate = BindImagePage,
			ClickCallback = delegate
			{
				base.ItemView.PerformClick();
			}
		};
		_imagesPager.Adapter = _imagesAdapter;
		_imagesPager.OffscreenPageLimit = 1;
		_imagesPager.RegisterOnPageChangeCallback(new ViewPager2OnPageChangeCallback(OnImagePageSelected));
		(_imagesPager.GetChildAt(0) as RecyclerView)?.AddOnItemTouchListener(new HorizontalSwipeTouchListener(() => _imagesPager.UserInputEnabled));
		_ratingLayout = itemView.RequireViewById<LinearLayout>(2131298146);
		_starImageView = _ratingLayout.RequireViewById<ImageView>(2131298463);
		_ratingTextView = _ratingLayout.RequireViewById<TextView>(2131298147);
		_cloudImageView = _ratingLayout.RequireViewById<ImageView>(2131296799);
		_reviewCountTextView = _ratingLayout.RequireViewById<TextView>(2131298231);
		_hintLabel = itemView.RequireViewById<HighlightedTextView>(2131297281);
		_priceSubTotal = itemView.RequireViewById<TextView>(2131297991);
		_titleLabel = itemView.RequireViewById<TextView>(2131298655);
		_packageLabel = itemView.RequireViewById<TextView>(2131297836);
		_priceView = itemView.RequireViewById<ConstraintLayout>(2131297992);
		_promoLayout = _priceView.RequireViewById<LinearLayout>(2131298089);
		_priceBlock = _priceView.RequireViewById<View>(2131297984);
		_oldPriceLabel = _priceView.RequireViewById<TextView>(2131297737);
		_oldPriceCrossingLine = _priceView.RequireViewById<View>(2131297735);
		_priceLabel = _priceView.RequireViewById<TextView>(2131297988);
		_actionClickableView = _priceView.RequireViewById<View>(2131296326);
		_addingStateView = _priceView.RequireViewById<View>(2131296371);
		_counterMiddle = _addingStateView.RequireViewById<View>(2131296861);
		_increaseButton = _addingStateView.RequireViewById<AppCompatImageButton>(2131297336);
		_countLabel = _addingStateView.RequireViewById<TextView>(2131296857);
		_decreaseButton = _addingStateView.RequireViewById<AppCompatImageButton>(2131296903);
		_outOfStockStateView = itemView.RequireViewById<ConstraintLayout>(2131297830);
		_outOfStockLabel = _outOfStockStateView.RequireViewById<TextView>(2131297828);
		_availableInShopLabel = _outOfStockStateView.RequireViewById<TextView>(2131296480);
		_badgesView = itemView.RequireViewById<BadgesView>(2131296504);
		_discountPrefix = _promoLayout.RequireViewById<TextView>(2131296999);
		_discountEndDate = _promoLayout.RequireViewById<TextView>(2131296996);
		_discountByLoyaltyProgram = _promoLayout.RequireViewById<TextView>(2131296995);
		_adultsOnlyControls = new AdultsOnlyControls(itemView.RequireViewById<View>(2131296411));
		_hintLabel.DismissImmediate();
	}

	public void BindData(IYandexMetricaScreenViewModel screenViewModel, ProductItemViewModel productItemViewModel, CompositeDisposable disposable, UICommand<ProductItemViewModel> showQtyDialogCommand, bool showPackageLabel = false, bool allowImagePaging = true)
	{
		productItemViewModel.ProductWasViewed(screenViewModel);
		_hintLabel.DismissImmediate();
		_boundViewModel = productItemViewModel;
		_cartStateApplied = false;
		_collapseAddButton = productItemViewModel.IsRegionGoodsAvailable;
		_priceView.UpdateLayoutParams(delegate(ViewGroup.MarginLayoutParams lp)
		{
			lp.BottomMargin = (_collapseAddButton ? Converter.DpToPx(6f) : 0);
		});
		_ratingLayout.Visibility = ViewStates.Visible;
		_starImageView.SetImageResource(productItemViewModel.HasRating ? 2131231374 : 2131231377);
		_ratingTextView.Text = productItemViewModel.Rating;
		_ratingTextView.SetTextColor(ColorStateList.ValueOf(new global::Android.Graphics.Color(ContextCompat.GetColor(_ratingTextView.Context, productItemViewModel.HasRating ? 2131099872 : 2131100604))));
		_cloudImageView.Visibility = productItemViewModel.HasRating.ToVisibility();
		_reviewCountTextView.Visibility = productItemViewModel.HasRating.ToVisibility();
		_reviewCountTextView.Text = productItemViewModel.ReviewsCount;
		_priceView.Visibility = productItemViewModel.IsPriceAndActionsVisible.ToVisibility();
		if (productItemViewModel.IsRegionGoodsAvailable)
		{
			ConstraintLayout outOfStockStateView = _outOfStockStateView;
			ViewStates visibility = (_outOfStockLabel.Visibility = (!productItemViewModel.InStock && !productItemViewModel.ReceivingMethodNotSelected).ToVisibility());
			outOfStockStateView.Visibility = visibility;
			_availableInShopLabel.Visibility = productItemViewModel.InStockOtherShops.ToVisibility();
			_outOfStockLabel.Text = (productItemViewModel.InStockOtherShops ? productItemViewModel.NotInThisShopText : productItemViewModel.OutOfStockText);
			SetOutOfStockPlate(productItemViewModel.InStockOtherShops);
			_bottomSubscribeButton.Visibility = ViewStates.Gone;
		}
		else
		{
			_outOfStockStateView.Visibility = ViewStates.Gone;
			_outOfStockLabel.Visibility = ViewStates.Gone;
			_availableInShopLabel.Visibility = ViewStates.Gone;
			SetOutOfStockPlate(onPlate: false);
			_bottomSubscribeButton.Visibility = (!productItemViewModel.ReceivingMethodNotSelected && !productItemViewModel.InStock).ToVisibility();
		}
		_hintLabel.AttributedText = productItemViewModel.NoMoreGoods;
		_titleLabel.Text = productItemViewModel.Name;
		_packageLabel.Text = productItemViewModel.GetPackageAndUnitText(showPackageLabel);
		_packageLabel.Visibility = (!string.IsNullOrEmpty(_packageLabel.Text) && !productItemViewModel.IsPackageLineHidden).ToVisibility();
		SetPrice(productItemViewModel);
		SetOutOfStock(productItemViewModel);
		SetImages(productItemViewModel, allowImagePaging);
		productItemViewModel.BindProperty(delegate
		{
			SetImages(productItemViewModel, allowImagePaging);
		}, "ImageUrl", "ShouldBlur").AddTo(disposable);
		productItemViewModel.FavoritesButtonViewModel.OnPropertyChanges((FavoritesButtonViewModel vm) => vm.ProductInFavorites).StartWithDefault().SafeSubscribe(delegate
		{
			_favoriteButton.SetBackgroundResource(productItemViewModel.FavoritesButtonViewModel.ProductInFavorites ? 2131231168 : 2131231167);
		}, disposable);
		productItemViewModel.SubscribeProductButtonViewModel.ShowPopupCommand.SafeSubscribe(delegate
		{
			WaitListButtonTopPopup.Show(_topSubscribeButton);
		}, disposable);
		productItemViewModel.SubscribeProductButtonViewModel.BindProperties(new global::_003C_003Ez__ReadOnlySingleElementList<(Action, IReadOnlyList<string>)>((delegate
		{
			_topSubscribeButton.SetBackgroundResource(productItemViewModel.SubscribeProductButtonViewModel.ProductInWaitList ? 2131231402 : 2131231386);
		}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ProductInWaitList")))).AddTo(disposable);
		_findReplacementButton.Text = productItemViewModel.ReplacementButtonText;
		ApplyCartState(productItemViewModel, animate: false);
		productItemViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[9]
		{
			(delegate
			{
				_topSubscribeButton.Visibility = productItemViewModel.IsSubscribeTopButtonVisible.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsSubscribeTopButtonVisible")),
			(delegate
			{
				SetReplacementButtonVisibility(productItemViewModel.IsReplacementButtonVisible);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsReplacementButtonVisible")),
			(delegate
			{
				_bottomSubscribeButton.Text = productItemViewModel.SubscribeBottomButtonText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("SubscribeBottomButtonText")),
			(delegate
			{
				_countLabel.Text = productItemViewModel.ItemsInCartCountPresentation;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ItemsInCartCountPresentation")),
			(delegate
			{
				_priceSubTotal.Text = productItemViewModel.SubTotalPrice;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("SubTotalPrice")),
			(delegate
			{
				_increaseButton.Selected = !productItemViewModel.CanAdd;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("CanAdd")),
			(delegate
			{
				_decreaseButton.Selected = !productItemViewModel.CanRemove;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("CanRemove")),
			(delegate
			{
				SetShadow(!productItemViewModel.InStock && !productItemViewModel.ReceivingMethodNotSelected);
			}, new global::_003C_003Ez__ReadOnlyArray<string>(new string[2] { "ReceivingMethodNotSelected", "InStock" })),
			(delegate
			{
				ApplyCartState(productItemViewModel, animate: true);
				OnItemsInCartCountChanged(productItemViewModel.ItemsInCartCount, productItemViewModel.IsChangeQtyVisible);
			}, new global::_003C_003Ez__ReadOnlyArray<string>(new string[4] { "IsChangeQtyVisible", "ItemsInCartCount", "InStock", "ReceivingMethodNotSelected" }))
		})).AddTo(disposable);
		productItemViewModel.BindEvents(((View)_topSubscribeButton).OnClick((Action)delegate
		{
			productItemViewModel.SubscribeProductButtonViewModel.OnButtonClicked();
		}), ((View)_bottomSubscribeButton).OnClick((Action)delegate
		{
			productItemViewModel.SubscribeProductButtonViewModel.OnButtonClicked();
		}), _actionClickableView.OnClick((Action)delegate
		{
			productItemViewModel.AddToCart().SafeFireAndForget((Action<Exception>)null, false);
		}), ((View)_increaseButton).OnClick((Action)delegate
		{
			OnIncreaseButtonClicked(productItemViewModel);
		}), ((View)_decreaseButton).OnClick((Action)delegate
		{
			OnDecreaseButtonClicked(productItemViewModel);
		}), _addingStateView.OnClick((Action)delegate
		{
			showQtyDialogCommand.Trigger(productItemViewModel);
		}), ((View)_availableInShopLabel).OnClick((Action)delegate
		{
			OpenAvailableShopsPopup(new AvailableShopsPopupViewModel.Parameter(productItemViewModel));
		}), ((View)_favoriteButton).OnClick((Action)delegate
		{
			if (productItemViewModel.FavoritesButtonViewModel.OnHeartClicked())
			{
				productItemViewModel.RecomAnalyticActions.OnAddedToFavorites(productItemViewModel);
			}
		}), ((View)_findReplacementButton).OnClick((Action)delegate
		{
			productItemViewModel.ShowReplacement();
		})).AddTo(disposable);
		Disposable.Create(CancelCounterAnimation).AddTo(disposable);
		productItemViewModel.ShowPromoTooltipCommand.SafeSubscribe(delegate(LinkedText t)
		{
			IYandexMetricaScreenViewModel viewModel = screenViewModel;
			View addingStateView = _addingStateView;
			System.Drawing.Size sizeInDp = _addingStateView.GetSizeInDp();
			sizeInDp.Height = 0;
			HintPopup.Show(viewModel, t, addingStateView, default(System.Drawing.Point), atTop: true, checkAnchorVisibility: true, sizeInDp, default(System.Drawing.Size), delegate
			{
				productItemViewModel.GotoTooltipLinkCommand.Trigger();
			});
		}, disposable);
		_adultsOnlyControls.Setup(productItemViewModel, disposable);
		_promoLayout.Visibility = (productItemViewModel.SaleAndInStock && !productItemViewModel.ReceivingMethodNotSelected).ToVisibility();
		_discountByLoyaltyProgram.Text = productItemViewModel.ByLoyaltyProgramText;
		_discountPrefix.Text = productItemViewModel.DiscountPrefixText;
		_discountEndDate.Text = productItemViewModel.DiscountEndDate;
		_badgesView.SetBadges(productItemViewModel.Badges, smallStamps: true);
		_badgesView.LayoutChange += new DisposableDelegate<EventHandler<View.LayoutChangeEventArgs>>(delegate(object? s, View.LayoutChangeEventArgs e)
		{
			if (_favoriteButton != null && e.Right > _favoriteButton.Left - 3)
			{
				_badgesView.RemoveLastBadge();
			}
		}, delegate(EventHandler<View.LayoutChangeEventArgs> h)
		{
			_badgesView.LayoutChange -= h;
		}).AddTo(disposable);
	}

	public void AddFragmentManager(FragmentManager fragmentManager)
	{
		_fragmentManager = fragmentManager;
	}

	private void SetImages(ProductItemViewModel productItemViewModel, bool allowImagePaging)
	{
		IReadOnlyList<string> readOnlyList = productItemViewModel.CardImageUrls;
		bool flag = allowImagePaging && readOnlyList.Count > 1;
		if (!flag && readOnlyList.Count > 1)
		{
			readOnlyList = new global::_003C_003Ez__ReadOnlySingleElementList<string>(readOnlyList[0]);
		}
		_imagesPager.UserInputEnabled = flag;
		_imagesAdapter.DataSource = readOnlyList;
		_imagesPager.SetCurrentItem(0, smoothScroll: false);
		if (flag)
		{
			_imagesIndicator.CreateIndicators(productItemViewModel.ImagePagerDotsCount, 0);
			_imagesIndicator.Visibility = ViewStates.Visible;
		}
		else
		{
			_imagesIndicator.Visibility = ViewStates.Gone;
		}
	}

	private void BindImagePage(CachingViewHolder holder, string url, int position, CompositeDisposable disposables)
	{
		ImageView imageView = holder.FindCachedView<ImageView>(2131296656);
		ZoomableImageView zoomableImageView = holder.FindCachedView<ZoomableImageView>(2131296670);
		ProductItemViewModel boundViewModel = _boundViewModel;
		if (boundViewModel != null)
		{
			imageView.FromUrlAnimated(url, (!boundViewModel.ShouldBlur) ? Array.Empty<ITransformation>() : new ITransformation[1]
			{
				new BlurTransformation(25, 1)
			});
			if (boundViewModel.IsZoomAllowed)
			{
				zoomableImageView.Setup(imageView, this, boundViewModel, disposables, url);
			}
		}
	}

	private void OnImagePageSelected(int position)
	{
		ProductItemViewModel boundViewModel = _boundViewModel;
		if (boundViewModel != null && _imagesIndicator.Visibility == ViewStates.Visible)
		{
			_imagesIndicator.AnimatePageSelected(boundViewModel.GetImagePagerDotIndex(position));
		}
	}

	private void SetShadow(bool enabled)
	{
		_imagesPager.Alpha = (enabled ? 0.5f : 1f);
		_titleLabel.SetTextColor(ColorStateList.ValueOf(new global::Android.Graphics.Color(ContextCompat.GetColor(_titleLabel.Context, enabled ? 2131100604 : 2131099872))));
		_topSubscribeButton.Alpha = 1f;
		_topSubscribeButton.ImageAlpha = 255;
	}

	private void OnItemsInCartCountChanged(decimal itemsInCartCount, bool viewModelActionLock)
	{
		if (viewModelActionLock)
		{
			_hintLabel.ShowFor(TimeSpan.FromSeconds(3L));
		}
	}

	private void OpenAvailableShopsPopup(AvailableShopsPopupViewModel.Parameter parameter)
	{
		AvailableShopsPopupFragment availableShopsPopupFragment = DI.ResolverBecauseConstructorInjectionIsNotPossible.Resolve<FragmentFactory>().Instantiate<AvailableShopsPopupFragment>();
		availableShopsPopupFragment.Arguments = parameter.ToNavBundle();
		availableShopsPopupFragment.Show(_fragmentManager, null);
	}

	private void SetOutOfStock(ProductItemViewModel productItemViewModel)
	{
		if (!productItemViewModel.InStock && !productItemViewModel.ReceivingMethodNotSelected)
		{
			if (productItemViewModel.InStockOtherShops)
			{
				_availableInShopLabel.Text = productItemViewModel.AvailableInShopText;
				_availableInShopLabel.ChangeColorOfPartTextView(productItemViewModel.AvailableInShopText, 6, productItemViewModel.AvailableInShopText.Length, 2131099854);
			}
			_priceLabel.SetTextColor(ColorStateList.ValueOf(new global::Android.Graphics.Color(ContextCompat.GetColor(_outOfStockLabel.Context, productItemViewModel.IsRegionGoodsAvailable ? 2131100604 : 2131099706))));
			TextViewCompat.SetAutoSizeTextTypeWithDefaults(_priceLabel, 0);
			_priceLabel.SetTextSize(ComplexUnitType.Sp, 12f);
			_priceLabel.SetTypeface(Typeface.Create("sans-serif-medium", TypefaceStyle.Normal), TypefaceStyle.Normal);
			_priceLabel.UpdateLayoutParams(delegate(ViewGroup.LayoutParams lp)
			{
				lp.Height = Converter.DpToPx(14f);
			});
			_outOfStockLabel.SetTextSize(ComplexUnitType.Sp, 10f);
			_outOfStockLabel.SetTypeface(Typeface.Create(productItemViewModel.InStockOtherShops ? "sans-serif" : "sans-serif-medium", TypefaceStyle.Normal), TypefaceStyle.Normal);
		}
		else
		{
			_priceLabel.SetTextColor(ColorStateList.ValueOf(new global::Android.Graphics.Color(ContextCompat.GetColor(_outOfStockLabel.Context, 2131099706))));
			TextViewCompat.SetAutoSizeTextTypeUniformWithConfiguration(_priceLabel, 11, 16, 1, 2);
			_priceLabel.SetTextSize(ComplexUnitType.Sp, 16f);
			_priceLabel.SetTypeface(Typeface.Create("sans-serif-medium", TypefaceStyle.Normal), TypefaceStyle.Normal);
			_priceLabel.UpdateLayoutParams(delegate(ViewGroup.LayoutParams lp)
			{
				lp.Height = Converter.DpToPx(20f);
			});
			_outOfStockLabel.SetTextSize(ComplexUnitType.Sp, 10f);
			_outOfStockLabel.SetTypeface(Typeface.Create("sans-serif-medium", TypefaceStyle.Normal), TypefaceStyle.Normal);
		}
	}

	private void SetPrice(ProductItemViewModel productItemViewModel)
	{
		_oldPriceLabel.Text = productItemViewModel.OldPrice;
		_priceLabel.Text = productItemViewModel.Price;
		_priceLabel.Visibility = (productItemViewModel.PriceLabelInvisible ? ViewStates.Gone : ViewStates.Visible);
		_discountByLoyaltyProgram.Visibility = productItemViewModel.LoyaltySaleAndInStock.ToVisibility();
		_discountPrefix.Visibility = (productItemViewModel.SaleAndInStock && !productItemViewModel.LoyaltySaleAndInStock).ToVisibility();
		_discountEndDate.Visibility = productItemViewModel.SaleAndInStock.ToVisibility();
		SetOldPriceVisibility(productItemViewModel.SaleAndInStock.ToVisibility());
		if (!productItemViewModel.ReceivingMethodNotSelected)
		{
			return;
		}
		_discountPrefix.Visibility = ViewStates.Gone;
		_discountEndDate.Visibility = ViewStates.Gone;
		_discountByLoyaltyProgram.Visibility = ViewStates.Gone;
		Stock stock = productItemViewModel.Product.Stock;
		if ((object)stock != null && stock.PriceFrom.HasValue)
		{
			IReadOnlyList<AvailableShop> shops = stock.Shops;
			if (shops != null && shops.Count > 2)
			{
				SetOldPriceVisibility(ViewStates.Gone);
			}
		}
	}

	private ViewStates AddButtonVisibility(bool showAddButton)
	{
		if (showAddButton)
		{
			return ViewStates.Visible;
		}
		if (!_collapseAddButton)
		{
			return ViewStates.Invisible;
		}
		return ViewStates.Gone;
	}

	private void SetReplacementButtonVisibility(bool visible)
	{
		_findReplacementButton.Visibility = visible.ToVisibility();
		_replacementButtonVisible = visible;
		UpdateOutOfStockRowHeight();
	}

	private void SetOutOfStockPlate(bool onPlate)
	{
		_outOfStockStateView.SetBackgroundResource(onPlate ? 2131230925 : 0);
		GravityFlags gravity = (onPlate ? GravityFlags.Center : GravityFlags.Start);
		_outOfStockLabel.Gravity = gravity;
		_availableInShopLabel.Gravity = gravity;
		_outOfStockOnPlate = onPlate;
		UpdateOutOfStockRowHeight();
	}

	private void UpdateOutOfStockRowHeight()
	{
		bool singleLine = _replacementButtonVisible && !_outOfStockOnPlate;
		_outOfStockStateView.UpdateLayoutParams(delegate(ViewGroup.LayoutParams lp)
		{
			lp.Height = Converter.DpToPx(singleLine ? 14 : 40);
		});
	}

	private void SetOldPriceVisibility(ViewStates visibility)
	{
		_oldPriceLabel.Visibility = visibility;
		_oldPriceCrossingLine.Visibility = visibility;
	}

	private void ApplyCartState(ProductItemViewModel productItemViewModel, bool animate)
	{
		bool flag = productItemViewModel.ItemsInCartCount > 0m;
		bool inStock = productItemViewModel.InStock;
		bool showCounter;
		bool showAddButton;
		if (!inStock && productItemViewModel.ReceivingMethodNotSelected)
		{
			showCounter = false;
			showAddButton = true;
		}
		else
		{
			showCounter = flag && inStock;
			showAddButton = !flag && inStock;
		}
		SetCartState(showCounter, showAddButton, animate);
	}

	private void SetCartState(bool showCounter, bool showAddButton, bool animate)
	{
		bool num = !_cartStateApplied || showCounter != _isCounterShown || showAddButton != _isAddButtonShown;
		_isCounterShown = showCounter;
		_isAddButtonShown = showAddButton;
		_cartStateApplied = true;
		if (!num)
		{
			return;
		}
		CancelCounterAnimation();
		int num2 = Converter.DpToPx(40f);
		int width = _priceView.Width;
		if (!animate || !base.ItemView.IsAttachedToWindow || width <= 0)
		{
			SetViewWidth(_addingStateView, (!showCounter) ? num2 : 0);
			_addingStateView.Alpha = 1f;
			_addingStateView.Visibility = showCounter.ToVisibility();
			SetCounterContentAlpha(1f);
			_actionClickableView.Alpha = 1f;
			_actionClickableView.Visibility = AddButtonVisibility(showAddButton);
			_priceBlock.Alpha = (showCounter ? 0f : 1f);
			return;
		}
		_addingStateView.Visibility = ViewStates.Visible;
		_addingStateView.Alpha = 1f;
		_actionClickableView.Visibility = ViewStates.Visible;
		_actionClickableView.Alpha = 1f;
		int num3 = (showCounter ? num2 : Math.Max(_addingStateView.Width, num2));
		int num4 = (showCounter ? width : num2);
		if (showCounter)
		{
			SetViewWidth(_addingStateView, num3);
			SetCounterContentAlpha(0f);
		}
		ValueAnimator animator = ValueAnimator.OfInt(num3, num4);
		animator.SetDuration(120L);
		animator.SetInterpolator(new DecelerateInterpolator());
		animator.Update += delegate(object? _, ValueAnimator.AnimatorUpdateEventArgs e)
		{
			SetViewWidth(_addingStateView, (int)e.Animation.AnimatedValue);
		};
		animator.AnimationEnd += delegate
		{
			if (_counterAnimator == animator)
			{
				_counterAnimator = null;
				if (showCounter)
				{
					SetViewWidth(_addingStateView, 0);
				}
				else
				{
					_addingStateView.Visibility = ViewStates.Gone;
				}
				_actionClickableView.Visibility = AddButtonVisibility(showAddButton);
			}
		};
		_counterAnimator = animator;
		float value = (showCounter ? 1f : 0f);
		_decreaseButton.Animate().Alpha(value).SetDuration(120L)
			.Start();
		_counterMiddle.Animate().Alpha(value).SetDuration(120L)
			.Start();
		_priceBlock.Animate().Alpha(showCounter ? 0f : 1f).SetDuration(120L)
			.Start();
		animator.Start();
	}

	private void SetCounterContentAlpha(float alpha)
	{
		_decreaseButton.Alpha = alpha;
		_counterMiddle.Alpha = alpha;
	}

	private void CancelCounterAnimation()
	{
		ValueAnimator? counterAnimator = _counterAnimator;
		_counterAnimator = null;
		counterAnimator?.Cancel();
		_addingStateView.Animate()?.Cancel();
		_actionClickableView.Animate()?.Cancel();
		_priceBlock.Animate()?.Cancel();
		_decreaseButton.Animate()?.Cancel();
		_counterMiddle.Animate()?.Cancel();
	}

	private static void SetViewWidth(View view, int width)
	{
		ViewGroup.LayoutParams layoutParameters = view.LayoutParameters;
		if (layoutParameters.Width != width)
		{
			layoutParameters.Width = width;
			view.LayoutParameters = layoutParameters;
		}
	}

	private void OnIncreaseButtonClicked(ProductItemViewModel vm)
	{
		if (vm.CanAdd)
		{
			vm.AddOneItemToCart();
		}
		else
		{
			_hintLabel.ShowFor(TimeSpan.FromSeconds(3L));
		}
	}

	private void OnDecreaseButtonClicked(ProductItemViewModel vm)
	{
		if (vm.CanRemove)
		{
			vm.RemoveOneItemFromCart();
		}
	}

	public static void ShowQtyInputDialog(ProductItemViewModel vm, LayoutInflater layoutInflater, Context ontext)
	{
		vm.RecomAnalyticActions.OnQtyChangePopupShown(vm);
		View view = layoutInflater.Inflate(2131492969, null) ?? throw new InvalidOperationException($"can't inflate resource {2131492969}");
		TextInputEditText input = view.RequireViewById<TextInputEditText>(2131298129);
		vm.OnClearQtyInput(vm);
		input.Text = vm.ManualInputQty;
		input.TextChanged += OnTextChanged;
		IDisposable fsd = vm.FullScreenDialogState.Value.SetVisible();
		DialogInterfaceOnDismissListener dialogInterfaceOnDismissListener = new DialogInterfaceOnDismissListener(delegate
		{
			fsd.Dispose();
			input.TextChanged -= OnTextChanged;
		});
		AlertDialog alertDialog = new AlertDialog.Builder(ontext).SetTitle(vm.QtyDialogTitle).SetMessage(vm.Name).SetPositiveButton(vm.QtyDialogDone, async delegate
		{
			await vm.OnChangeQtyDoneButtonClick(vm);
		})
			.SetNegativeButton(vm.QtyDialogClose, delegate
			{
			})
			.SetView(view)
			.SetOnDismissListener(dialogInterfaceOnDismissListener)
			.SetOnCancelListener(dialogInterfaceOnDismissListener)
			.Create();
		alertDialog.SetCanceledOnTouchOutside(cancel: true);
		alertDialog.Window.SetSoftInputMode(SoftInput.StateVisible);
		alertDialog.ShowCentered();
		input.RequestFocus();
		input.PostDelayed(delegate
		{
			(ontext.GetSystemService("input_method") as InputMethodManager)?.ShowSoftInput(input, ShowFlags.Implicit);
		}, 200L);
		void OnTextChanged(object? sender, TextChangedEventArgs e)
		{
			if (!(input.Text == vm.ManualInputQty))
			{
				vm.OnQtyEnteredManually(vm, input.Text);
				input.Text = vm.ManualInputQty;
				input.SetSelection(input.Text.Length);
			}
		}
	}
}
