using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reactive.Subjects;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using AsyncAwaitBestPractices;
using Auchan.Common.Analytics.YandexAppMetrica;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Common.Binding;
using Auchan.Common.Ecom.Cart;
using Auchan.Common.Ecom.Cart.Models;
using Auchan.Common.Ecom.Extensions;
using Auchan.Common.Ecom.ProducModels;
using Auchan.Common.Extensions;
using Auchan.Common.Profile;

namespace Auchan.Common.Ecom.Products.Modifications;

public class PopupModificationsViewModel : ScreenViewModel, IModificationsViewModel, IBindable, INotifyPropertyChanged, IYandexMetricaScreenViewModel, IScreenViewModel, IPromoDiscountUsecaseSupport
{
	public class Parameter
	{
		public Product Product { get; }

		public Parameter(Product product)
		{
			Product = product;
		}
	}

	private Guid _requestId;

	private bool _isInCartBeforehand;

	private readonly Auchan.Common.Ecom.Cart.Cart _cart;

	private readonly IDictionary<string, SelectedModification> _selectedModifications = new Dictionary<string, SelectedModification>();

	private readonly CheckProductUseCase _checkUseCase;

	private readonly Lazy<IPromoDiscountUsecase> _promoDiscountUsecase;

	private readonly Subject<AttributedText?> _showTooltip = new Subject<AttributedText>();

	private CancellationTokenSource? _changeQtyTimerToken;

	[CompilerGenerated]
	private ProductOffer? _003CInCart_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CIsQtyCartVisible_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CIsWarningVisible_003Ek__BackingField;

	[CompilerGenerated]
	private FavoritesButtonViewModel _003CFavoritesButtonViewModel_003Ek__BackingField;

	public Product Product { get; }

	public ProductOffer? InCart
	{
		[CompilerGenerated]
		get
		{
			return _003CInCart_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!(_003CInCart_003Ek__BackingField == value))
			{
				_003CInCart_003Ek__BackingField = value;
				RaisePropertyChanged("ItemsInCartCount");
				RaisePropertyChanged("CartButtonText");
				RaisePropertyChanged("QtyCartText");
				RaisePropertyChanged("CanRemove");
				RaisePropertyChanged("ProductOffer");
				RaisePropertyChanged("TotalPrice");
				RaisePropertyChanged("InCart");
			}
		}
	}

	public string BackButtonText => "Свернуть";

	public string WarningMessage => "Выберите цвет и укажите размер для добавления в корзину!";

	public string CartButtonText
	{
		get
		{
			if (!(ItemsInCartCount > 0m))
			{
				return "В корзину";
			}
			return "В корзине " + ProductsConverter.FromProductToQty(ItemsInCartCount, Product.Price?.UnitType ?? ProductUnitType.Unit, addDot: true);
		}
	}

	public string ToCartText => "В корзину";

	public string ProductName => Product.Title ?? string.Empty;

	public string ProductPrice => $"{Product.Price?.Value ?? 0m:C2}";

	public string ProductQty => GenerateQty(Product.Stock?.Qty ?? 0m);

	public string PerUnitAlias => (Product.Price?.UnitType ?? ProductUnitType.Unit).ToPerUnitString() + ".";

	public bool ProductInStock => Product.InStock;

	public string PreviewPath => Product.ImageUrl ?? Product.MediaUrls?.FirstOrDefault() ?? string.Empty;

	public string QtyCartText => GenerateQty(ItemsInCartCount);

	public bool IsQtyCartVisible
	{
		[CompilerGenerated]
		get
		{
			return _003CIsQtyCartVisible_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CIsQtyCartVisible_003Ek__BackingField != value)
			{
				bool isQtyCartVisible = IsQtyCartVisible;
				_003CIsQtyCartVisible_003Ek__BackingField = value;
				bool isQtyCartVisible2 = IsQtyCartVisible;
				OnIsQtyCartVisibleChanged(isQtyCartVisible, isQtyCartVisible2);
				RaisePropertyChanged("IsQtyCartVisible");
			}
		}
	}

	private decimal ItemsInCartCount => InCart?.Qty ?? 0m;

	public bool CanAddToCart
	{
		get
		{
			Auchan.Common.Ecom.Cart.Cart cart = _cart;
			Product product = Product;
			IReadOnlyList<SelectedModification> selectedModifications = SelectedModifications;
			return cart.CanBeAdded(product.CreateOffer(null, selectedModifications));
		}
	}

	public bool CanRemove => ItemsInCartCount > 0m;

	public bool IsWarningVisible
	{
		[CompilerGenerated]
		get
		{
			return _003CIsWarningVisible_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CIsWarningVisible_003Ek__BackingField != value)
			{
				_003CIsWarningVisible_003Ek__BackingField = value;
				RaisePropertyChanged("IsWarningVisible");
			}
		}
	}

	public IReadOnlyList<ProductModificationItemViewModel> Modifications { get; }

	IReadOnlyList<IModificationItemViewModel> IModificationsViewModel.Modifications => Modifications;

	private IReadOnlyList<SelectedModification> SelectedModifications
	{
		get
		{
			List<SelectedModification> list = new List<SelectedModification>();
			list.AddRange(_selectedModifications.Select<KeyValuePair<string, SelectedModification>, SelectedModification>((KeyValuePair<string, SelectedModification> c) => c.Value));
			return new _003C_003Ez__ReadOnlyList<SelectedModification>(list);
		}
	}

	public IObservable<AttributedText?> ShowTooltipCommand => _showTooltip;

	public string TotalPrice => $"{InCart?.Price:C2}";

	public AttributedText NoMoreGoods => new AttributedText("Товар закончился!");

	public FavoritesButtonViewModel FavoritesButtonViewModel
	{
		[CompilerGenerated]
		get
		{
			return _003CFavoritesButtonViewModel_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003CFavoritesButtonViewModel_003Ek__BackingField, value))
			{
				_003CFavoritesButtonViewModel_003Ek__BackingField = value;
				RaisePropertyChanged("FavoritesButtonViewModel");
			}
		}
	}

	public bool IsAddToCartButtonHighlighted
	{
		get
		{
			if (CanAddToCart)
			{
				return IsAllModificationsSelected;
			}
			return false;
		}
	}

	public UICommand<LinkedText> ShowPromoTooltipCommand { get; } = new UICommand<LinkedText>();

	public UICommand GotoTooltipLinkCommand { get; } = new UICommand();

	private ProductOffer ProductOffer => Product.CreateOffer(ItemsInCartCount, _selectedModifications.Select<KeyValuePair<string, SelectedModification>, SelectedModification>((KeyValuePair<string, SelectedModification> c) => c.Value).ToList());

	private bool IsAllModificationsSelected => _selectedModifications.Count == Modifications.Count;

	public string ScreenNameForBaseEvents => "";

	string IYandexMetricaScreenViewModel.ScreenName => "Item_" + Product.Title;

	public PopupModificationsViewModel(Parameter parameter, Auchan.Common.Ecom.Cart.Cart cart, Func<ProductModification, ICollection<IDisposable>, ProductModificationItemViewModel> viewModelFactory, Func<Product, FavoritesButtonViewModel> favoritesButtonViewModelFactory, CheckProductUseCase checkUseCase, Lazy<IPromoDiscountUsecase> promoDiscountUsecase)
	{
		PopupModificationsViewModel popupModificationsViewModel = this;
		_cart = cart;
		_checkUseCase = checkUseCase;
		_promoDiscountUsecase = promoDiscountUsecase;
		Product = parameter.Product;
		InCart = _cart.GetExact(Product, SelectedModifications);
		List<ProductModificationItemViewModel> list = new List<ProductModificationItemViewModel>();
		list.AddRange(Product.Modifications.Select((ProductModification x) => viewModelFactory(x, popupModificationsViewModel.CloseDisposable)));
		Modifications = new _003C_003Ez__ReadOnlyList<ProductModificationItemViewModel>(list);
		FavoritesButtonViewModel = favoritesButtonViewModelFactory(Product);
		_cart.OnItemChangeReceived(delegate(object? o, ItemChangedEventArgs e)
		{
			popupModificationsViewModel.OnItemChangeReceived(e);
		}).AddTo(base.CloseDisposable);
		_cart.OnItemChangedByUser(delegate(object? o, OfferUpdatedEventArgs e)
		{
			popupModificationsViewModel.OnItemChangedByUser(e);
		}).AddTo(base.CloseDisposable);
	}

	public void AddOneItemToCart()
	{
		AddOneItemToCartAsync().SafeFireAndForget((Action<Exception>)null, false);
	}

	public void RemoveOneItemFromCart()
	{
		RemoveOneItemFromCartAsync().SafeFireAndForget((Action<Exception>)null, false);
	}

	private async Task AddOneItemToCartAsync()
	{
		if (!CanAddToCart)
		{
			_showTooltip.OnNext(NoMoreGoods);
			OnChangeQtySetVisible();
			return;
		}
		if (!IsAllModificationsSelected)
		{
			IsWarningVisible = true;
			return;
		}
		bool num = await _checkUseCase.CanAdd(Product, ProductOffer);
		OnChangeQtySetVisible();
		if (num)
		{
			_isInCartBeforehand = ItemsInCartCount > 0m;
			Guid requestId = (_requestId = Guid.NewGuid());
			Auchan.Common.Ecom.Cart.Cart cart = _cart;
			Product product = Product;
			IReadOnlyList<SelectedModification> selectedModifications = SelectedModifications;
			cart.AddItem(product.CreateOffer(null, selectedModifications), requestId);
		}
	}

	private async Task RemoveOneItemFromCartAsync()
	{
		ProductOffer inCart = InCart;
		if (inCart != null)
		{
			_isInCartBeforehand = false;
			Guid requestId = (_requestId = Guid.NewGuid());
			if (inCart.Qty > inCart.BasketStep)
			{
				OnChangeQtySetVisible();
				_cart.DecrementItemQty(inCart, Product.BasketStep, requestId);
			}
			else
			{
				IsQtyCartVisible = false;
				_cart.RemoveItems(new global::_003C_003Ez__ReadOnlySingleElementList<ProductOffer>(inCart), requestId);
			}
		}
	}

	public void WriteSelected(IModificationItemViewModel vmMod, ModificationValueViewModel vmVal)
	{
		ProductModification modification = vmMod.Modification;
		ProductModificationValue value = vmVal.Value;
		if (!(value == null))
		{
			if (_selectedModifications.ContainsKey(modification.Code))
			{
				_selectedModifications.Remove(modification.Code);
			}
			SelectedModification value2 = new SelectedModification
			{
				Code = modification.Code,
				Name = modification.Name,
				Value = value
			};
			_selectedModifications.Add(modification.Code, value2);
			RaisePropertyChanged("IsAddToCartButtonHighlighted");
			if (IsAllModificationsSelected)
			{
				IsWarningVisible = false;
				InCart = _cart.GetExact(Product, SelectedModifications);
			}
		}
	}

	private void OnChangeQtySetVisible()
	{
		IsQtyCartVisible = true;
		_changeQtyTimerToken?.Cancel();
		_changeQtyTimerToken = new CancellationTokenSource();
		OnChangeQtySetVisibleAsync(_changeQtyTimerToken.Token).SafeFireAndForget((Action<Exception>)null, false);
	}

	private async Task OnChangeQtySetVisibleAsync(CancellationToken token)
	{
		await Task.Delay(3000);
		if (!token.IsCancellationRequested)
		{
			IsQtyCartVisible = false;
		}
	}

	private string GenerateQty(decimal count)
	{
		return ProductsConverter.FromProductToQty(count, Product.Price?.UnitType ?? ProductUnitType.Unit, addDot: true);
	}

	private void OnItemChangeReceived(ItemChangedEventArgs e)
	{
		if (_requestId == e.RequestId)
		{
			InCart = e.Offer;
			Product product = Product;
			IReadOnlyList<SelectedModification> selectedModifications = SelectedModifications;
			ProductOffer productOffer = product.CreateOffer(null, selectedModifications);
			if (!_isInCartBeforehand && productOffer.InCombo)
			{
				_promoDiscountUsecase.Value.ProcessComboSuggection(productOffer, this, base.CloseDisposable).SafeFireAndForget((Action<Exception>)null, false);
			}
			else
			{
				_promoDiscountUsecase.Value.ProcessOfferChange(e.Change, this, base.CloseDisposable);
			}
		}
	}

	private void OnItemChangedByUser(OfferUpdatedEventArgs e)
	{
		if (_requestId == e.RequestId)
		{
			InCart = e.Offer;
		}
	}

	private void OnIsQtyCartVisibleChanged(bool old, bool @new)
	{
		if (!@new)
		{
			_showTooltip.OnNext(null);
		}
	}
}
