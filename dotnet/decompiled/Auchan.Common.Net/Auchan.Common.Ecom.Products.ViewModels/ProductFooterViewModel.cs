using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using AsyncAwaitBestPractices;
using Auchan.Common.Analytics;
using Auchan.Common.Analytics.YandexAppMetrica;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Common.Binding;
using Auchan.Common.Ecom.Cart;
using Auchan.Common.Ecom.Cart.Managers;
using Auchan.Common.Ecom.Cart.Models;
using Auchan.Common.Ecom.Extensions;
using Auchan.Common.Ecom.ProducModels;
using Auchan.Common.Extensions;
using Auchan.Common.Managers.Dialogs;
using Auchan.Common.PersonalCabinet;
using Auchan.Common.PersonalCabinet.Authorization.Managers;
using Auchan.Common.Profile.WaitList;

namespace Auchan.Common.Ecom.Products.ViewModels;

public sealed class ProductFooterViewModel : ElementViewModel, IPromoDiscountUsecaseSupport
{
	public interface IModificationsSource
	{
		IReadOnlyList<SelectedModification> SelectedModifications { get; }

		bool IsSelectionComplete { get; }

		bool DimAddToCartUntilSelectionComplete { get; }

		void OnIncompleteSelection();
	}

	public class Parameter
	{
		public bool IsForPriceChecker { get; init; }

		public IReadOnlyList<string>? Breadcrumbs { get; init; }

		public string? CtmShelfBlockId { get; init; }
	}

	private readonly Parameter _parameter;

	private readonly Auchan.Common.Ecom.Cart.Cart _cart;

	private readonly IUserContext _userContext;

	private readonly ILoginManager _loginManager;

	private readonly IEcomContext _ecomContext;

	private readonly IInfoMessageService _infoMessageService;

	private readonly IAgeGateDialog _ageGateDialog;

	private readonly CheckProductUseCase _checkUseCase;

	private readonly AppMetrica _appMetrica;

	private readonly Lazy<IPromoDiscountUsecase> _promoDiscountUsecase;

	private readonly Subject<AttributedText?> _showTooltip = new Subject<AttributedText>();

	private CancellationTokenSource? _changeQtyTimerToken;

	private Guid _requestId;

	private bool _isInCartBeforehand;

	private ProductOffer? _inCart;

	[CompilerGenerated]
	private Product? _003CProduct_003Ek__BackingField;

	[CompilerGenerated]
	private IModificationsSource? _003CModifications_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CShowRealPrice_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CIsChangeQtyVisible_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CManualInputQty_003Ek__BackingField;

	public Product? Product
	{
		[CompilerGenerated]
		get
		{
			return _003CProduct_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003CProduct_003Ek__BackingField, value))
			{
				_003CProduct_003Ek__BackingField = value;
				RaisePropertyChanged("ProductTitle");
				RaisePropertyChanged("Price");
				RaisePropertyChanged("OldPrice");
				RaisePropertyChanged("DiscountValue");
				RaisePropertyChanged("IsSaleActive");
				RaisePropertyChanged("IsDiscountBadgeVisible");
				RaisePropertyChanged("ProductInStock");
				RaisePropertyChanged("CanAddToCart");
				RaisePropertyChanged("IsAddToCartButtonHighlighted");
				RaisePropertyChanged("TotalPrice");
				RaisePropertyChanged("ItemsInCartCountPresentation");
				RaisePropertyChanged("Product");
			}
		}
	}

	private IModificationsSource? Modifications
	{
		[CompilerGenerated]
		get
		{
			return _003CModifications_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!object.Equals(_003CModifications_003Ek__BackingField, value))
			{
				_003CModifications_003Ek__BackingField = value;
				RaisePropertyChanged("CanAddToCart");
				RaisePropertyChanged("IsAddToCartButtonHighlighted");
				RaisePropertyChanged("IsAllModificationsSelected");
				RaisePropertyChanged("DimAddToCartUntilSelectionComplete");
				RaisePropertyChanged("Modifications");
			}
		}
	}

	public SubscribeProductButtonViewModel WaitListButtonViewModel { get; }

	public bool IsForPriceCheckerCase => _parameter.IsForPriceChecker;

	public string? ProductTitle => Product?.Title;

	public string? Price => $"{Product?.Price?.Value:C2}";

	public string? OldPrice
	{
		get
		{
			Product? product = Product;
			if (product == null || !product.InStock)
			{
				return string.Empty;
			}
			return $"{Product.OldPrice?.Value:F2}";
		}
	}

	public string? DiscountValue
	{
		get
		{
			Product? product = Product;
			if (product == null || !product.InStock || !(Product.Discount != null))
			{
				return string.Empty;
			}
			return $"-{Product.Discount.ValueInPercent}";
		}
	}

	public bool IsSaleActive
	{
		get
		{
			Product? product = Product;
			if (product != null && product.IsSaleActive)
			{
				return Product?.InStock ?? false;
			}
			return false;
		}
	}

	public bool IsDiscountBadgeVisible
	{
		get
		{
			if (IsSaleActive)
			{
				return !IsForPriceCheckerCase;
			}
			return false;
		}
	}

	public bool ProductInStock => Product?.InStock ?? false;

	public string ToCartText => "В корзину";

	public string NotifyWhenGoodsArriveText => "Сообщим о поступлении товара";

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
				RaisePropertyChanged("TotalPrice");
				RaisePropertyChanged("ShowRealPrice");
			}
		}
	} = true;

	public string TotalPrice => $"{(IsForPriceCheckerCase ? new decimal?((Product?.Price?.Value).GetValueOrDefault()) : InCart?.GetSubTotal(ShowRealPrice)):C2}";

	public string EconomyText => "Экономия";

	public string EconomyAmountText
	{
		get
		{
			ProductOffer? inCart = InCart;
			if ((object)inCart != null)
			{
				decimal? totalDiscount = inCart.TotalDiscount;
				if ((totalDiscount.GetValueOrDefault() > default(decimal)) & totalDiscount.HasValue)
				{
					return $"{(InCart?.TotalDiscount).GetValueOrDefault():C2}";
				}
			}
			return string.Empty;
		}
	}

	public bool EconomyVisible
	{
		get
		{
			if (!IsForPriceCheckerCase)
			{
				return !string.IsNullOrWhiteSpace(EconomyAmountText);
			}
			return false;
		}
	}

	public bool IsCostAndEconomyVisible
	{
		get
		{
			if (!IsForPriceCheckerCase)
			{
				return CanRemove;
			}
			return false;
		}
	}

	public bool CanAddToCart
	{
		get
		{
			if (ProductInStock)
			{
				return _cart.CanBeAdded(InCart ?? CreateOffer());
			}
			return false;
		}
	}

	public bool CanRemove => ItemsInCartCount > 0m;

	public bool IsAddToCartButtonHighlighted
	{
		get
		{
			if (CanAddToCart)
			{
				if (!IsAllModificationsSelected)
				{
					return !DimAddToCartUntilSelectionComplete;
				}
				return true;
			}
			return false;
		}
	}

	public string ItemsInCartCountPresentation => ProductsConverter.FromProductToQty(ItemsInCartCount, (Product?.Price?.UnitType).GetValueOrDefault());

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

	public AttributedText NoMoreGoods => new AttributedText("Товар закончился!");

	public IObservable<AttributedText?> ShowTooltipCommand => _showTooltip;

	public UICommand<LinkedText> ShowPromoTooltipCommand { get; } = new UICommand<LinkedText>();

	public UICommand GotoTooltipLinkCommand { get; } = new UICommand();

	public UICommand ShowQtyDialogCommand { get; } = new UICommand();

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

	private decimal ItemsInCartCount => InCart?.Qty ?? 0m;

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
				RaisePropertyChanged("TotalPrice");
				RaisePropertyChanged("EconomyAmountText");
				RaisePropertyChanged("EconomyVisible");
				RaisePropertyChanged("CanAddToCart");
				RaisePropertyChanged("IsAddToCartButtonHighlighted");
				RaisePropertyChanged("ItemsInCartCount");
				RaisePropertyChanged("CanRemove");
				RaisePropertyChanged("IsCostAndEconomyVisible");
				RaisePropertyChanged("ItemsInCartCountPresentation");
				RaisePropertyChanged("InCart");
			}
		}
	}

	private bool IsAllModificationsSelected => Modifications?.IsSelectionComplete ?? true;

	private bool DimAddToCartUntilSelectionComplete => Modifications?.DimAddToCartUntilSelectionComplete ?? false;

	public ProductFooterViewModel(Parameter parameter, Auchan.Common.Ecom.Cart.Cart cart, IUserContext userContext, ILoginManager loginManager, IEcomContext ecomContext, IInfoMessageService infoMessageService, IAgeGateDialog ageGateDialog, CheckProductUseCase checkUseCase, AppMetrica appMetrica, Lazy<IPromoDiscountUsecase> promoDiscountUsecase, SubscribeProductButtonViewModel waitListButtonViewModel)
	{
		_parameter = parameter;
		_cart = cart;
		_userContext = userContext;
		_loginManager = loginManager;
		_ecomContext = ecomContext;
		_infoMessageService = infoMessageService;
		_ageGateDialog = ageGateDialog;
		_checkUseCase = checkUseCase;
		_appMetrica = appMetrica;
		_promoDiscountUsecase = promoDiscountUsecase;
		WaitListButtonViewModel = waitListButtonViewModel.AddTo(base.Disposables);
		(from x in this.OnPropertyChanges((ProductFooterViewModel x) => x.IsChangeQtyVisible)
			where !x
			select x).Subscribe(delegate
		{
			_showTooltip.OnNext(null);
		}).AddTo(base.Disposables);
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
			OnItemChangeReceived(e).SafeFireAndForget((Action<Exception>)null, false);
		}).AddTo(base.Disposables);
	}

	public void Setup(Product product, IModificationsSource modifications)
	{
		Product = product;
		Modifications = modifications;
		InCart = _cart.GetExact(product, modifications.SelectedModifications);
		WaitListButtonViewModel.SetProduct(product);
		RaisePropertyChanged("CanAddToCart");
		RaisePropertyChanged("IsAddToCartButtonHighlighted");
	}

	public void AddToCart()
	{
		AddToCartAsync().SafeFireAndForget((Action<Exception>)null, false);
	}

	public void AddOneItemToCart()
	{
		AddOneItemToCartAsync().SafeFireAndForget((Action<Exception>)null, false);
	}

	public void RemoveOneItemFromCart()
	{
		RemoveOneItemFromCartAsync().SafeFireAndForget((Action<Exception>)null, false);
	}

	private async Task AddToCartAsync()
	{
		if (Product == null)
		{
			return;
		}
		AppAnalytics.Digenetica.ViewProduct(Product, _parameter.Breadcrumbs);
		if (!_userContext.Authorized)
		{
			_loginManager.LoginAsync(displayOnboardings: false).SafeFireAndForget((Action<Exception>)null, false);
			return;
		}
		bool flag = Product.IsAdult && _ecomContext.AgeGateAgreement != AgreeState.Yes;
		if (flag)
		{
			flag = await _ageGateDialog.ShowAgeGateDialogAsync() != AgreeState.Yes;
		}
		if (flag || IsChangeQtyVisible)
		{
			return;
		}
		if (ItemsInCartCount > 0m)
		{
			OnChangeQtySetVisible();
			return;
		}
		if (!string.IsNullOrEmpty(_parameter.CtmShelfBlockId))
		{
			_appMetrica.TrackCtmShelfMonetization("addToCartFromCard", _parameter.CtmShelfBlockId, Product);
		}
		await AddOneItemToCartAsync();
	}

	private async Task AddOneItemToCartAsync()
	{
		if (Product == null)
		{
			return;
		}
		if (!CanAddToCart)
		{
			_showTooltip.OnNext(NoMoreGoods);
			OnChangeQtySetVisible();
			return;
		}
		if (!IsAllModificationsSelected)
		{
			Modifications?.OnIncompleteSelection();
			return;
		}
		bool num = await _checkUseCase.CanAdd(Product, InCart ?? CreateOffer(), IsForPriceCheckerCase);
		OnChangeQtySetVisible();
		if (!num)
		{
			if (ItemsInCartCount == 0m)
			{
				SetChangeQtyInvisible();
			}
			return;
		}
		_isInCartBeforehand = ItemsInCartCount > 0m;
		_requestId = Guid.NewGuid();
		ShowRealPrice = false;
		Auchan.Common.Ecom.Cart.Cart cart = _cart;
		object product2;
		if (!(InCart != null))
		{
			Product? product = Product;
			IReadOnlyList<SelectedModification> modifications = Modifications?.SelectedModifications;
			product2 = product.CreateOffer(null, modifications);
		}
		else
		{
			product2 = InCart with
			{
				Qty = 0m
			};
		}
		cart.AddItem((ProductOffer)product2, _requestId);
	}

	private async Task RemoveOneItemFromCartAsync()
	{
		ProductOffer productOffer = InCart ?? _cart.GetExact(CreateOffer());
		if (productOffer != null)
		{
			_requestId = Guid.NewGuid();
			_isInCartBeforehand = false;
			ShowRealPrice = false;
			if (ItemsInCartCount > productOffer.BasketStep)
			{
				OnChangeQtySetVisible();
				_cart.DecrementItemQty(productOffer, Product?.BasketStep ?? productOffer.BasketStep, _requestId);
			}
			else
			{
				IsChangeQtyVisible = false;
				_cart.RemoveItems(new global::_003C_003Ez__ReadOnlySingleElementList<ProductOffer>(productOffer), _requestId);
				InCart = null;
			}
		}
	}

	public void OnQtyEnteredManually(string newQtyWithAlias)
	{
		ProductOffer productOffer = InCart ?? _cart.GetExact(CreateOffer());
		if (!(productOffer == null))
		{
			ManualInputQty = ManualQtyHandler.OnQtyEnteredManually(productOffer, ManualInputQty, newQtyWithAlias);
		}
	}

	public void OnClearQtyInput()
	{
		ProductOffer productOffer = InCart ?? _cart.GetExact(CreateOffer());
		if (!(productOffer == null))
		{
			ManualInputQty = ManualQtyHandler.OnQtyEnteredManually(productOffer, string.Empty, string.Empty);
		}
	}

	public async Task OnChangeQtyDoneButtonClick()
	{
		if (Product == null)
		{
			return;
		}
		ProductOffer productOffer = InCart ?? _cart.GetExact(CreateOffer());
		if (productOffer == null)
		{
			return;
		}
		decimal num = ManualQtyHandler.NormalizeQtyIfNeeded(ManualInputQty, productOffer);
		_ = productOffer.Qty;
		if (num <= 0.0001m)
		{
			return;
		}
		if (Math.Abs(num - productOffer.Qty) < 0.0001m)
		{
			ManualInputQty = productOffer.Qty.ToString();
			return;
		}
		_requestId = Guid.NewGuid();
		ShowRealPrice = false;
		if (Math.Abs(num) < 0.0001m)
		{
			_cart.RemoveItems(new global::_003C_003Ez__ReadOnlySingleElementList<ProductOffer>(productOffer), _requestId);
		}
		else
		{
			_cart.ChangeItemQty(productOffer, num, _requestId);
		}
		ManualInputQty = productOffer.Qty.ToString();
	}

	public void NotifyModificationsChanged()
	{
		InCart = _cart.GetExact(Product, Modifications?.SelectedModifications ?? Array.Empty<SelectedModification>());
		RaisePropertyChanged("IsAddToCartButtonHighlighted");
	}

	private void OnChangeQtySetVisible()
	{
		IsChangeQtyVisible = true;
		_changeQtyTimerToken?.Cancel();
		_changeQtyTimerToken = new CancellationTokenSource();
		OnChangeQtySetVisibleAsync(_changeQtyTimerToken.Token).SafeFireAndForget((Action<Exception>)null, false);
	}

	private void SetChangeQtyInvisible()
	{
		_changeQtyTimerToken?.Cancel();
		IsChangeQtyVisible = false;
	}

	private async Task OnChangeQtySetVisibleAsync(CancellationToken token)
	{
		await Task.Delay(3000);
		if (!token.IsCancellationRequested)
		{
			IsChangeQtyVisible = false;
		}
	}

	private async Task OnItemChangeReceived(ItemChangedEventArgs e)
	{
		if (Product == null || Modifications == null)
		{
			return;
		}
		if (e.RequestId == _requestId)
		{
			if (e.Offer.IsMatch(Product, Modifications.SelectedModifications))
			{
				InCart = e.Offer;
			}
			ShowRealPrice = true;
			if (IsForPriceCheckerCase)
			{
				if (e.EventType == ItemChangedEventType.Add)
				{
					_infoMessageService.ShowSnackbar("Товар добавлен в корзину для магазина " + _ecomContext.ActiveStore.Name, SnackbarStyle.Success);
				}
				return;
			}
			ProductOffer productOffer = InCart ?? CreateOffer();
			if (!_isInCartBeforehand && productOffer.InCombo)
			{
				_promoDiscountUsecase.Value.ProcessComboSuggection(productOffer, this, base.Disposables).SafeFireAndForget((Action<Exception>)null, false);
			}
			else
			{
				_promoDiscountUsecase.Value.ProcessOfferChange(e.Change, this, base.Disposables);
			}
		}
		else if (e.Offer.IsMatch(Product, Modifications.SelectedModifications))
		{
			InCart = e.Offer;
			ShowRealPrice = true;
		}
	}

	private void OnItemUpdated(OfferUpdatedEventArgs args)
	{
		if (Product != null && Modifications != null)
		{
			if (args.Offer.IsMatch(Product, Modifications.SelectedModifications))
			{
				InCart = args.Offer;
			}
			RaisePropertyChanged("CanAddToCart");
		}
	}

	private ProductOffer CreateOffer()
	{
		if (Product == null)
		{
			throw new InvalidOperationException("product is not set");
		}
		return Product.CreateOffer(ItemsInCartCount, Modifications?.SelectedModifications);
	}
}
