using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using AsyncAwaitBestPractices;
using Auchan.Common.Analytics;
using Auchan.Common.Analytics.YandexAppMetrica;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Common.Binding;
using Auchan.Common.Ecom.Badges;
using Auchan.Common.Ecom.Cart;
using Auchan.Common.Ecom.Cart.Managers;
using Auchan.Common.Ecom.Cart.Models;
using Auchan.Common.Ecom.Extensions;
using Auchan.Common.Ecom.Products;
using Auchan.Common.Ecom.Products.ViewModels;
using Auchan.Common.Extensions;
using Auchan.Common.Managers.Dialogs;
using Auchan.Common.PersonalCabinet;
using Auchan.Common.PersonalCabinet.Authorization.Managers;
using Auchan.Common.Profile;
using Auchan.Common.Profile.WaitList;
using Auchan.Common.Recommendations;
using Auchan.Common.Recommendations.Models;

namespace Auchan.Common.Ecom.ProducModels.ViewModels;

public class ProductItemViewModel : BaseItemViewModel, IAdultsOnlyItemViewModel, INotifyPropertyChanged, IBindable, IWithImageUrl, IPromoDiscountUsecaseSupport, IIdentifiable
{
	public enum ProductItemType
	{
		Common,
		Favorite,
		WaitList
	}

	private CancellationTokenSource? _changeQtyTimerToken;

	private Guid _requestId;

	private bool _isInCartBeforehand;

	private ProductOffer? _inCart;

	private readonly ProductOffer _searchTerm;

	private readonly Auchan.Common.Ecom.Cart.Cart _cart;

	private readonly CheckProductUseCase _checkUseCase;

	private readonly IModificationsDialogService _modificationsDialogService;

	private readonly IUserContext _userContext;

	private readonly ILoginManager _loginManager;

	private readonly IEcomTracker _ecomTracker;

	private readonly IEcomContext _ecomContext;

	private readonly Lazy<IPromoDiscountUsecase> _promoDiscountUsecase;

	private readonly Lazy<IAgeGateDialog> _ageGateDialog;

	[CompilerGenerated]
	private IReadOnlyList<string> _003CBreadcrumbs_003Ek__BackingField;

	[CompilerGenerated]
	private readonly ProductItemType _003CItemType_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CShowRealPrice_003Ek__BackingField;

	public const int MaxImagePagerDots = 5;

	[CompilerGenerated]
	private bool _003CIsChangeQtyVisible_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CManualInputQty_003Ek__BackingField;

	[CompilerGenerated]
	private UICommand<AvailableShopsPopupViewModel.Parameter> _003COpenAvailableShopsCommand_003Ek__BackingField;

	public virtual RecommendationAnalyticsInfo RecomAnalytics => RecommendationAnalyticsInfo.Empty;

	public virtual IRecommendationAnalyticsActions RecomAnalyticActions => NoRecommendationAnalyticsActions.Instance;

	public FavoritesButtonViewModel FavoritesButtonViewModel { get; }

	public UICommand<ProductItemViewModel>? ShowReplacementCommand { get; }

	public SubscribeProductButtonViewModel SubscribeProductButtonViewModel { get; }

	public Product Product { get; }

	public Lazy<IFullScreenDialogState> FullScreenDialogState { get; }

	public ProductOffer? InCart
	{
		get
		{
			return _inCart;
		}
		private set
		{
			if (!(_inCart == value))
			{
				_inCart = ((value == null || value.Qty == 0m) ? null : value);
				RaisePropertyChanged("SubTotalPrice");
				RaisePropertyChanged("ItemsInCartCount");
				RaisePropertyChanged("ItemsInCartCountPresentation");
				RaisePropertyChanged("CanAdd");
				RaisePropertyChanged("CanRemove");
				RaisePropertyChanged("InCart");
			}
		}
	}

	public IReadOnlyList<string> Breadcrumbs
	{
		[CompilerGenerated]
		get
		{
			return _003CBreadcrumbs_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!object.Equals(_003CBreadcrumbs_003Ek__BackingField, value))
			{
				_003CBreadcrumbs_003Ek__BackingField = value;
				RaisePropertyChanged("Breadcrumbs");
			}
		}
	} = Array.Empty<string>();

	public BadgesListModel Badges { get; }

	public string? Name => Product.Name ?? Product.Title;

	public bool IsSaleActive
	{
		get
		{
			if (Product.Discount != null)
			{
				return Product.OldPrice != null;
			}
			return false;
		}
	}

	public bool SaleAndInStock
	{
		get
		{
			if (IsSaleActive)
			{
				return InStock;
			}
			return false;
		}
	}

	public bool LoyaltySaleAndInStock
	{
		get
		{
			if (SaleAndInStock)
			{
				return Product.Discount?.IsLoyaltyProgramDiscount ?? false;
			}
			return false;
		}
	}

	public string Price => CalculatePrice();

	public bool IsPriceAndActionsVisible
	{
		get
		{
			if (!InStock && !ReceivingMethodNotSelected)
			{
				return InStockOtherShops;
			}
			return true;
		}
	}

	public bool HasRating
	{
		get
		{
			if (Product.Rate != null)
			{
				return Product.Rate.ReviewsCount > 0;
			}
			return false;
		}
	}

	public string Rating
	{
		get
		{
			if (!HasRating)
			{
				return "Нет отзывов";
			}
			return $"{Product.Rate?.Rating:0.#}";
		}
	}

	public string ReviewsCount => $"{Product.Rate?.ReviewsCount}";

	public string Code => Product.Code ?? string.Empty;

	public ProductItemType ItemType
	{
		[CompilerGenerated]
		get
		{
			return _003CItemType_003Ek__BackingField;
		}
		[CompilerGenerated]
		init
		{
			if (_003CItemType_003Ek__BackingField != value)
			{
				_003CItemType_003Ek__BackingField = value;
				RaisePropertyChanged("InStockOtherShops");
				RaisePropertyChanged("IsPriceAndActionsVisible");
				RaisePropertyChanged("IsPackageLineHidden");
				RaisePropertyChanged("HasSubscribeInfoPopup");
				RaisePropertyChanged("SubscribeBottomButtonText");
				RaisePropertyChanged("IsRegionGoodsAvailable");
				RaisePropertyChanged("IsSubscribeTopButtonVisible");
				RaisePropertyChanged("IsReplacementButtonVisible");
				RaisePropertyChanged("IsUnitTypeVisible");
				RaisePropertyChanged("PriceLabelInvisible");
				RaisePropertyChanged("ItemType");
			}
		}
	}

	private bool ShowRealPrice
	{
		[CompilerGenerated]
		get
		{
			return _003CShowRealPrice_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (_003CShowRealPrice_003Ek__BackingField != value)
			{
				_003CShowRealPrice_003Ek__BackingField = value;
				RaisePropertyChanged("SubTotalPrice");
				RaisePropertyChanged("ShowRealPrice");
			}
		}
	} = true;

	public string SubTotalPrice => $"{InCart?.GetSubTotal(ShowRealPrice):C2}";

	public bool IsUnitTypeShownAtRecomendations
	{
		get
		{
			Price? price = Product.Price;
			if ((object)price == null)
			{
				return false;
			}
			_ = price.UnitType;
			return true;
		}
	}

	public string ItemsInCartCountPresentation => ProductsConverter.FromProductToQty(ItemsInCartCount, Product.Price?.UnitType ?? ProductUnitType.Unit, addDot: true);

	public string PerUnitAlias => "Цена за " + (Product.Price?.UnitType ?? ProductUnitType.Unit).ToPerUnitString();

	public string OldPrice => $"{Product.OldPrice?.Value:F2}";

	public string DiscountEndDate
	{
		get
		{
			if (!(Product.Discount != null))
			{
				return string.Empty;
			}
			return "до " + Product.Discount.EndDate.ToString("dd/MM");
		}
	}

	public string DiscountPrefixText => "скидка";

	public string ByLoyaltyProgramText => "по карте Ашан";

	public string ImageUrl => Product.ImageUrl ?? Product.MediaUrls.FirstOrDefault() ?? "";

	public IReadOnlyList<string> CardImageUrls
	{
		get
		{
			List<string> list = new List<string>();
			if (!string.IsNullOrWhiteSpace(ImageUrl))
			{
				list.Add(ImageUrl);
			}
			foreach (string item in Product.MediaUrls ?? Array.Empty<string>())
			{
				if (!string.IsNullOrWhiteSpace(item) && !list.Contains(item))
				{
					list.Add(item);
				}
			}
			return list;
		}
	}

	public bool HasSeveralImages => CardImageUrls.Count > 1;

	public int ImagePagerDotsCount => Math.Min(CardImageUrls.Count, 5);

	public bool ShouldBlur
	{
		get
		{
			if (_ecomContext.AgeGateAgreement != AgreeState.Yes)
			{
				return Product.IsAdult;
			}
			return false;
		}
	}

	public decimal ItemsInCartCount => InCart?.Qty ?? 0m;

	public bool CanAdd => _cart.CanBeAdded(InCart ?? CreateProductOffer());

	public bool CanRemove => ItemsInCartCount > 0m;

	public UICommand<LinkedText> ShowPromoTooltipCommand { get; } = new UICommand<LinkedText>();

	public UICommand GotoTooltipLinkCommand { get; } = new UICommand();

	public bool IsChangeQtyVisible
	{
		[CompilerGenerated]
		get
		{
			return _003CIsChangeQtyVisible_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CIsChangeQtyVisible_003Ek__BackingField != value)
			{
				_003CIsChangeQtyVisible_003Ek__BackingField = value;
				RaisePropertyChanged("IsChangeQtyVisible");
			}
		}
	}

	public bool InStockOtherShops
	{
		get
		{
			if (ItemType != ProductItemType.WaitList && !InStock)
			{
				Stock? stock = Product.Stock;
				if ((object)stock != null && stock.Shops?.Count > 0)
				{
					return !ReceivingMethodNotSelected;
				}
			}
			return false;
		}
	}

	public bool InStock
	{
		get
		{
			Stock? stock = Product.Stock;
			if ((object)stock == null)
			{
				return false;
			}
			return stock.Qty > default(decimal);
		}
	}

	public bool IsZoomAllowed
	{
		get
		{
			if (InStock)
			{
				return !ShouldBlur;
			}
			return false;
		}
	}

	public bool ReceivingMethodNotSelected => _ecomContext.ReceivingMethodNotSelected;

	public string OutOfStockText => "Нет в наличии";

	public string NotInThisShopText => "Нет в этом магазине";

	public string AvailableInShopText
	{
		get
		{
			string obj = $"Есть в {Product.Stock?.Shops?.Count} ";
			Stock? stock = Product.Stock;
			return obj + (((object)stock != null && stock.Shops?.Count % 10 == 1) ? "магазине" : "магазинах");
		}
	}

	public string QtyDialogTitle => "Количество товара";

	public string QtyDialogClose => "Закрыть";

	public string QtyDialogDone => "Готово";

	public string ManualInputQty
	{
		[CompilerGenerated]
		get
		{
			return _003CManualInputQty_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(_003CManualInputQty_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CManualInputQty_003Ek__BackingField = value;
				RaisePropertyChanged("ManualInputQty");
			}
		}
	} = string.Empty;

	public AttributedText NoMoreGoods => new AttributedText("Товар закончился!");

	public UICommand<AvailableShopsPopupViewModel.Parameter> OpenAvailableShopsCommand
	{
		[CompilerGenerated]
		get
		{
			return _003COpenAvailableShopsCommand_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!object.Equals(_003COpenAvailableShopsCommand_003Ek__BackingField, value))
			{
				_003COpenAvailableShopsCommand_003Ek__BackingField = value;
				RaisePropertyChanged("OpenAvailableShopsCommand");
			}
		}
	} = new UICommand<AvailableShopsPopupViewModel.Parameter>();

	public bool HasSubscribeInfoPopup => ItemType != ProductItemType.WaitList;

	public bool IsRegionGoodsAvailable
	{
		get
		{
			if (ItemType != ProductItemType.WaitList && !InStock)
			{
				return !ReceivingMethodNotSelected;
			}
			return false;
		}
	}

	public bool IsPackageLineHidden
	{
		get
		{
			if (ItemType == ProductItemType.Common && IsRegionGoodsAvailable)
			{
				return !InStockOtherShops;
			}
			return false;
		}
	}

	public string SubscribeBottomButtonText
	{
		get
		{
			if (HasSubscribeInfoPopup)
			{
				if (!SubscribeProductButtonViewModel.ProductInWaitList)
				{
					return "В лист ожидания";
				}
				return "Отписаться";
			}
			return "Отписаться";
		}
	}

	public bool IsSubscribeTopButtonVisible
	{
		get
		{
			if (ItemType == ProductItemType.WaitList)
			{
				if (SubscribeProductButtonViewModel.ProductInWaitList)
				{
					return InStock;
				}
				return false;
			}
			if (!SubscribeProductButtonViewModel.ProductInWaitList)
			{
				return !InStock;
			}
			return true;
		}
	}

	public bool IsReplacementButtonVisible
	{
		get
		{
			if (ItemType == ProductItemType.Favorite && !InStock)
			{
				return !ReceivingMethodNotSelected;
			}
			return false;
		}
	}

	public bool IsUnitTypeVisible
	{
		get
		{
			if (ItemType == ProductItemType.Common)
			{
				return IsUnitTypeShownAtRecomendations;
			}
			if (InStock)
			{
				return IsUnitTypeShownAtRecomendations;
			}
			return false;
		}
	}

	public bool PriceLabelInvisible
	{
		get
		{
			if (ItemType != ProductItemType.Common)
			{
				return !InStock;
			}
			return false;
		}
	}

	public string ReplacementButtonText => "Найти замену";

	public string? PackageDisplay => Product.PackageDisplay;

	public ProductItemViewModel(Product product, Auchan.Common.Ecom.Cart.Cart cart, ICollection<IDisposable> closeDisposable, CheckProductUseCase checkUseCase, IModificationsDialogService modificationsDialogService, IUserContext userContext, ILoginManager loginManager, Func<Product, FavoritesButtonViewModel> favoritesButtonViewModelFactory, SubscribeProductButtonViewModel subscribeProductButtonViewModel, IEcomTracker ecomTracker, IEcomContext ecomContext, Lazy<IFullScreenDialogState> fullScreenDialogState, Lazy<IPromoDiscountUsecase> promoDiscountUsecase, Lazy<IAgeGateDialog> ageGateDialog, ProductItemType itemType = ProductItemType.Common, UICommand<ProductItemViewModel>? showReplacementCommand = null)
	{
		base.Disposables.AddTo(closeDisposable);
		Product = product;
		Badges = new BadgesListModel(product.Badges);
		InCart = cart.GetExact(product);
		_searchTerm = InCart ?? product.CreateOffer();
		_cart = cart;
		_checkUseCase = checkUseCase;
		_modificationsDialogService = modificationsDialogService;
		_userContext = userContext;
		_loginManager = loginManager;
		_ecomTracker = ecomTracker;
		_ecomContext = ecomContext;
		FullScreenDialogState = fullScreenDialogState;
		_promoDiscountUsecase = promoDiscountUsecase;
		_ageGateDialog = ageGateDialog;
		ShowReplacementCommand = showReplacementCommand;
		ItemType = itemType;
		FavoritesButtonViewModel = favoritesButtonViewModelFactory(Product).AddTo(base.Disposables);
		SubscribeProductButtonViewModel = subscribeProductButtonViewModel.SetProduct(Product).AddTo(base.Disposables);
		_cart.OnItemChangedByUser(delegate(object? o, OfferUpdatedEventArgs e)
		{
			OnItemUpdated(e);
		}).AddTo(base.Disposables);
		_cart.OnItemReceivedOnCartUpdate(delegate(object? o, OfferUpdatedEventArgs e)
		{
			OnItemUpdated(e);
		}).AddTo(base.Disposables);
		_cart.OnItemChangeReceived(delegate(object? o, ItemChangedEventArgs e)
		{
			OnItemChangeReceived(e);
		}).AddTo(base.Disposables);
		SubscribeProductButtonViewModel.OnPropertyChanges((SubscribeProductButtonViewModel x) => x.ProductInWaitList).Subscribe(delegate
		{
			RaisePropertyChanged("SubscribeBottomButtonText");
			RaisePropertyChanged("IsSubscribeTopButtonVisible");
		}).AddTo(base.Disposables);
		_ecomContext.OnPropertyChanges((IEcomContext x) => x.AgeGateAgreement).Subscribe(delegate
		{
			RaisePropertyChanged("ShouldBlur");
		}).AddTo(closeDisposable);
	}

	public int GetImagePagerDotIndex(int imageIndex)
	{
		int count = CardImageUrls.Count;
		int imagePagerDotsCount = ImagePagerDotsCount;
		if (count <= 1 || imagePagerDotsCount <= 1)
		{
			return 0;
		}
		imageIndex = Math.Clamp(imageIndex, 0, count - 1);
		if (count <= imagePagerDotsCount)
		{
			return imageIndex;
		}
		return (int)Math.Round((double)(imageIndex * (imagePagerDotsCount - 1)) / (double)(count - 1));
	}

	public string GetPackageAndUnitText(bool includePackage)
	{
		List<string> list = new List<string>(2);
		if (includePackage && !string.IsNullOrWhiteSpace(PackageDisplay))
		{
			list.Add(PackageDisplay);
		}
		if (IsUnitTypeVisible)
		{
			list.Add("цена за " + (Product.Price?.UnitType ?? ProductUnitType.Unit).ToPerUnitString());
		}
		return string.Join(" · ", list);
	}

	public async Task AddToCart()
	{
		AppAnalytics.Digenetica.ViewProduct(Product, Breadcrumbs);
		if (!_userContext.Authorized)
		{
			_loginManager.LoginAsync(displayOnboardings: false).SafeFireAndForget((Action<Exception>)null, false);
			return;
		}
		bool flag = Product.IsAdult && _ecomContext.AgeGateAgreement != AgreeState.Yes;
		if (flag)
		{
			flag = await _ageGateDialog.Value.ShowAgeGateDialogAsync() != AgreeState.Yes;
		}
		if (!flag)
		{
			if (ItemsInCartCount > 0m)
			{
				OnChangeQtySetVisible();
			}
			else
			{
				AddOneItemToCart();
			}
		}
	}

	public void ProductWasViewed(IYandexMetricaScreenViewModel screenViewModel)
	{
		Task.Run(delegate
		{
			_ecomTracker.ViewProductCellInListing(Product, screenViewModel);
		}).SafeFireAndForget((Action<Exception>)null, false);
		RecomAnalyticActions.OnProductCardShown(this);
	}

	public void OnQtyEnteredManually(ProductItemViewModel itemViewModel, string newQtyWithAlias)
	{
		ProductOffer productOffer = InCart ?? _cart.GetExact(itemViewModel.CreateProductOffer()) ?? itemViewModel.CreateProductOffer();
		itemViewModel.ManualInputQty = ManualQtyHandler.OnQtyEnteredManually(productOffer, itemViewModel, newQtyWithAlias);
	}

	public void OnClearQtyInput(ProductItemViewModel itemViewModel)
	{
		ProductOffer productOffer = InCart ?? _cart.GetExact(itemViewModel.CreateProductOffer());
		if (productOffer != null)
		{
			itemViewModel.ManualInputQty = ManualQtyHandler.OnQtyEnteredManually(productOffer, string.Empty, string.Empty);
		}
	}

	public async Task OnChangeQtyDoneButtonClick(ProductItemViewModel cartItemViewModel)
	{
		ProductOffer productOffer = InCart ?? _cart.GetExact(cartItemViewModel.CreateProductOffer());
		decimal num = ManualQtyHandler.NormalizeQtyIfNeeded(cartItemViewModel, productOffer);
		if (!(num <= 0.0001m))
		{
			ShowRealPrice = false;
			_requestId = Guid.NewGuid();
			if (Math.Abs(num) < 0.0001m)
			{
				_cart.RemoveItems(new global::_003C_003Ez__ReadOnlySingleElementList<ProductOffer>(productOffer), _requestId);
			}
			else
			{
				_cart.ChangeItemQty(productOffer, num, _requestId);
			}
			cartItemViewModel.ManualInputQty = cartItemViewModel.ItemsInCartCount.ToString();
		}
	}

	public void AddOneItemToCart()
	{
		AddOneItemToCartAsync().SafeFireAndForget((Action<Exception>)null, false);
	}

	private async Task<bool> AddOneItemToCartAsync()
	{
		if (Product.Modifications.IsNotNullOrEmpty())
		{
			_modificationsDialogService.ShowModificationsPopup(Product);
			return false;
		}
		if (!(await _checkUseCase.CanAdd(Product, _searchTerm)))
		{
			return false;
		}
		if (Product.LastKnownStock <= ItemsInCartCount + Product.BasketStep)
		{
			OnChangeQtySetVisible();
		}
		ShowRealPrice = false;
		_isInCartBeforehand = ItemsInCartCount > 0m;
		_requestId = Guid.NewGuid();
		_cart.AddItem((InCart != null) ? InCart with
		{
			Qty = 0m
		} : Product.CreateOffer(), _requestId);
		return true;
	}

	private void OnItemChangeReceived(ItemChangedEventArgs args)
	{
		if (args.RequestId == _requestId)
		{
			ProcessRemoteChanges(args);
		}
		else if (args.Offer.IsMatch(Product, Array.Empty<SelectedModification>()))
		{
			ShowRealPrice = true;
			InCart = args.Offer;
		}
	}

	protected virtual void ProcessRemoteChanges(ItemChangedEventArgs args)
	{
		InCart = args.Offer;
		ShowRealPrice = true;
		if (args.EventType == ItemChangedEventType.Add && !_isInCartBeforehand && Product.InCombo)
		{
			_promoDiscountUsecase.Value.ProcessComboSuggection(_searchTerm, this, base.Disposables).SafeFireAndForget((Action<Exception>)null, false);
		}
		else
		{
			_promoDiscountUsecase.Value.ProcessOfferChange(args.Change, this, base.Disposables);
		}
	}

	public void RemoveOneItemFromCart()
	{
		RemoveOneItemFromCartAsync().SafeFireAndForget((Action<Exception>)null, false);
	}

	private async Task RemoveOneItemFromCartAsync()
	{
		ProductOffer productOffer = _cart.Items.FirstOrDefault((ProductOffer i) => i.GimaId == Product.GimaId);
		if (productOffer != null)
		{
			ShowRealPrice = false;
			_requestId = Guid.NewGuid();
			_isInCartBeforehand = false;
			IsChangeQtyVisible = false;
			if (ItemsInCartCount > productOffer.BasketStep)
			{
				_cart.DecrementItemQty(productOffer, Product.BasketStep, _requestId);
			}
			else
			{
				_cart.RemoveItems(new global::_003C_003Ez__ReadOnlySingleElementList<ProductOffer>(productOffer), _requestId);
			}
		}
	}

	private void OnItemUpdated(OfferUpdatedEventArgs args)
	{
		if (args.Offer.IsMatch(Product, Array.Empty<SelectedModification>()))
		{
			InCart = args.Offer;
		}
		RaisePropertyChanged("CanAdd");
	}

	private void OnChangeQtySetVisible()
	{
		IsChangeQtyVisible = true;
		_changeQtyTimerToken?.Cancel();
		_changeQtyTimerToken = new CancellationTokenSource();
		OnChangeQtySetVisibleAsync(_changeQtyTimerToken.Token).SafeFireAndForget((Action<Exception>)null, false);
	}

	private async Task OnChangeQtySetVisibleAsync(CancellationToken token)
	{
		await Task.Delay(3000);
		if (!token.IsCancellationRequested)
		{
			IsChangeQtyVisible = false;
		}
	}

	private string CalculatePrice()
	{
		if (!_ecomContext.ReceivingMethodNotSelected)
		{
			Stock? stock = Product.Stock;
			if ((object)stock == null || !(stock.Qty > default(decimal)))
			{
				Stock? stock2 = Product.Stock;
				if ((object)stock2 == null || !stock2.PriceFrom.HasValue)
				{
					Stock? stock3 = Product.Stock;
					if ((object)stock3 == null || stock3.Shops?.Any() != true)
					{
						return "";
					}
					return $"от {Product.Price?.Value:C2}";
				}
				return $"от {Product.Stock?.PriceFrom:C2}";
			}
			return $"{Product.Price?.Value ?? 1m:C2}";
		}
		Stock? stock4 = Product.Stock;
		if ((object)stock4 != null && stock4.PriceFrom.HasValue)
		{
			Stock? stock5 = Product.Stock;
			if ((object)stock5 != null && stock5.Shops?.Count == 2)
			{
				return $"{Product.Stock?.PriceFrom:C2}";
			}
			return $"от {Product.Stock?.PriceFrom:C2}";
		}
		return $"{Product?.Price?.Value ?? 1m:C2}";
	}

	public void ShowReplacement()
	{
		ShowReplacementCommand?.Trigger(this);
	}

	public ProductOffer CreateProductOffer()
	{
		return Product.CreateOffer(ItemsInCartCount);
	}

	string IIdentifiable.GetId()
	{
		return $"product:{(InCart ?? CreateProductOffer()).GetKey().GetHashCode()}";
	}
}
