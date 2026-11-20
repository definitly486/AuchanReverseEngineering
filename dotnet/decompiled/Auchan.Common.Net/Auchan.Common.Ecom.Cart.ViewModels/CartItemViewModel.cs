using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Common.Binding;
using Auchan.Common.Ecom.Badges;
using Auchan.Common.Ecom.Cart.Managers;
using Auchan.Common.Ecom.Cart.Models;
using Auchan.Common.Ecom.DTO;
using Auchan.Common.Ecom.ProducModels;
using Auchan.Common.Ecom.ProducModels.ViewModels;
using Auchan.Common.Ecom.Products;
using Auchan.Common.Extensions;
using Auchan.Common.Profile;
using Microsoft.Maui.Devices;

namespace Auchan.Common.Ecom.Cart.ViewModels;

public sealed class CartItemViewModel : BaseItemViewModel, IAdultsOnlyItemViewModel, INotifyPropertyChanged, IBindable, IPromoDiscountUsecaseSupport, ICartItemViewModel, IIdentifiable
{
	public enum CommentVisualState
	{
		Default,
		Input,
		InProgress
	}

	public const int CommentInputMaxLenght = 255;

	private Guid _pendingRequestId;

	private bool _initCompleted;

	private readonly Cart _cart;

	private readonly IEcomContext _ecomContext;

	private readonly Lazy<IPromoDiscountUsecase> _promoDiscountUsecase;

	private IDisposable? _hintPopupDismissHandle;

	[CompilerGenerated]
	private decimal _003CQtyValue_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CShowRealPrice_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CManualInputQty_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CComment_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CCommentInput_003Ek__BackingField;

	[CompilerGenerated]
	private CommentVisualState _003CCommentState_003Ek__BackingField;

	[CompilerGenerated]
	private ProductOffer _003CProductOffer_003Ek__BackingField;

	[CompilerGenerated]
	private BadgesListModel _003CBadges_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CIsSelected_003Ek__BackingField;

	public decimal QtyValue
	{
		[CompilerGenerated]
		get
		{
			return _003CQtyValue_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!decimal.Equals(_003CQtyValue_003Ek__BackingField, value))
			{
				_003CQtyValue_003Ek__BackingField = value;
				RaisePropertyChanged("TotalPrice");
				RaisePropertyChanged("Qty");
				RaisePropertyChanged("QtyValue");
			}
		}
	}

	public decimal BasketStep => ProductOffer.BasketStep;

	public string? GimaId => ProductOffer.GimaId;

	public string Title => ProductOffer.Name ?? "";

	public string? ImageUrl => ProductOffer.SelectedModifications.FirstOrDefault((SelectedModification c) => !string.IsNullOrEmpty(c.Value?.PreviewImageUrl))?.Value.PreviewImageUrl ?? ProductOffer.ImageUrl;

	public bool ShouldBlur
	{
		get
		{
			if (_ecomContext.AgeGateAgreement != AgreeState.Yes)
			{
				return ProductOffer.IsAdult;
			}
			return false;
		}
	}

	public string AdultsOnlyText => "Для лиц\nстарше 18 лет";

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

	public string TotalPrice => $"{ProductOffer.GetSubTotal(ShowRealPrice, QtyValue):C2}";

	public string ItemPrice => ProductsConverter.FromProductOfferToPricePerUnit(ProductOffer);

	public string OldPrice
	{
		get
		{
			decimal? oldPrice = ProductOffer.OldPrice;
			if (!((oldPrice.GetValueOrDefault() > default(decimal)) & oldPrice.HasValue))
			{
				return string.Empty;
			}
			return $"{ProductOffer.OldPrice:F2}";
		}
	}

	public bool IsOldPriceVisible
	{
		get
		{
			decimal? oldPrice = ProductOffer.OldPrice;
			return (oldPrice.GetValueOrDefault() > default(decimal)) & oldPrice.HasValue;
		}
	}

	public bool IsSaleActive
	{
		get
		{
			if (ProductOffer.Discount != null)
			{
				return ProductOffer.OldPrice.HasValue;
			}
			return false;
		}
	}

	public string DiscountEndDate
	{
		get
		{
			if (!IsSaleActive)
			{
				return "";
			}
			return "до " + ProductOffer.Discount.EndDate.ToString("dd/MM");
		}
	}

	public bool IsDelayedCashbackBadgeVisible => Badges.VisibleItems.Any((BadgeItemViewModel b) => b.Item.BadgeType == BadgeType.DelayedCashback);

	public string Qty => ProductsConverter.FromProductToQty(QtyValue, ProductOffer.UnitType);

	public bool IsAdult => ProductOffer.IsAdult;

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
	}

	public UICommand SaveCommentCommand { get; } = new UICommand();

	public string Comment
	{
		[CompilerGenerated]
		get
		{
			return _003CComment_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CComment_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CComment_003Ek__BackingField = value;
				RaisePropertyChanged("Comment");
			}
		}
	}

	public string CommentInput
	{
		[CompilerGenerated]
		get
		{
			return _003CCommentInput_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(_003CCommentInput_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CCommentInput_003Ek__BackingField = value;
				RaisePropertyChanged("CommentInput");
			}
		}
	} = string.Empty;

	public bool IsCommentAvailable => ProductOffer.UnitType != ProductUnitType.Unit;

	public CommentVisualState CommentState
	{
		[CompilerGenerated]
		get
		{
			return _003CCommentState_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CCommentState_003Ek__BackingField != value)
			{
				_003CCommentState_003Ek__BackingField = value;
				RaisePropertyChanged("CommentState");
			}
		}
	}

	public string CheckboxTitle => "Указать в штуках";

	public string ByLoyaltyProgramText => "по карте Ашан";

	public bool IncreaseEnabled => _cart.CanBeAdded(ProductOffer);

	public string Code => ProductOffer.Code;

	public IReadOnlyList<SelectedModification> ProductSelectedModifications => ProductOffer.SelectedModifications;

	public ProductOffer ProductOffer
	{
		[CompilerGenerated]
		get
		{
			return _003CProductOffer_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			ProductOffer productOffer = ProductOffer;
			_003CProductOffer_003Ek__BackingField = value;
			RaisePropertyChanged("BasketStep");
			RaisePropertyChanged("GimaId");
			RaisePropertyChanged("Title");
			RaisePropertyChanged("ImageUrl");
			RaisePropertyChanged("ShouldBlur");
			RaisePropertyChanged("TotalPrice");
			RaisePropertyChanged("ItemPrice");
			RaisePropertyChanged("OldPrice");
			RaisePropertyChanged("IsOldPriceVisible");
			RaisePropertyChanged("IsSaleActive");
			RaisePropertyChanged("DiscountEndDate");
			RaisePropertyChanged("Qty");
			RaisePropertyChanged("IsAdult");
			RaisePropertyChanged("IsCommentAvailable");
			RaisePropertyChanged("IncreaseEnabled");
			RaisePropertyChanged("Code");
			RaisePropertyChanged("ProductSelectedModifications");
			RaisePropertyChanged("IsLoyaltyProgramDiscount");
			RaisePropertyChanged("IsMarkedProduct");
			ProductOffer productOffer2 = ProductOffer;
			OnProductOfferChanged(productOffer, productOffer2);
			RaisePropertyChanged("ProductOffer");
		}
	}

	public bool IsLoyaltyProgramDiscount => ProductOffer.Discount?.IsLoyaltyProgramDiscount ?? false;

	public BadgesListModel Badges
	{
		[CompilerGenerated]
		get
		{
			return _003CBadges_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!(_003CBadges_003Ek__BackingField == value))
			{
				_003CBadges_003Ek__BackingField = value;
				RaisePropertyChanged("IsDelayedCashbackBadgeVisible");
				RaisePropertyChanged("IsBadgesVisible");
				RaisePropertyChanged("Badges");
			}
		}
	}

	public bool IsBadgesVisible => Badges.VisibleItems.Count > 0;

	public FavoritesButtonViewModel FavoritesButtonViewModel { get; }

	public bool IsSelected
	{
		[CompilerGenerated]
		get
		{
			return _003CIsSelected_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (_003CIsSelected_003Ek__BackingField != value)
			{
				_003CIsSelected_003Ek__BackingField = value;
				RaisePropertyChanged("IsSelected");
			}
		}
	}

	public bool IsMarkedProduct
	{
		get
		{
			if (ProductOffer.IsMarkedProduct)
			{
				return Parent.IsTooManyMarkedGoodsVisible;
			}
			return false;
		}
	}

	public string MarkedProductText => "Маркированный товар";

	public UICommand<LinkedText> ShowPromoTooltipCommand { get; } = new UICommand<LinkedText>();

	public UICommand GotoTooltipLinkCommand { get; } = new UICommand();

	public ICartScreenViewModel Parent { get; }

	public CartItemViewModel(ProductOffer model, ICartScreenViewModel parent, Cart cart, IEcomContext ecomContext, Lazy<IPromoDiscountUsecase> promoDiscountUsecase, Func<Product, FavoritesButtonViewModel> favoritesButtonViewModelFactory)
	{
		ProductOffer = model;
		QtyValue = ProductOffer.Qty;
		Parent = parent;
		_cart = cart;
		_ecomContext = ecomContext;
		_promoDiscountUsecase = promoDiscountUsecase;
		Badges = new BadgesListModel(ProductOffer.Badges);
		FavoritesButtonViewModel = favoritesButtonViewModelFactory(model.Map());
		ManualInputQty = ProductsConverter.FromProductToQty(model.Qty, model.UnitType);
		string? obj = model.Comment ?? string.Empty;
		string commentInput = obj;
		Comment = obj;
		CommentInput = commentInput;
		if (IsCommentAvailable && Comment != string.Empty)
		{
			CommentState = CommentVisualState.Input;
		}
		IsSelected = model.IsSelected;
		cart.OnItemChangedByUser(delegate(object? o, OfferUpdatedEventArgs e)
		{
			OnItemChangedByUser(e);
		}).AddTo(base.Disposables);
		cart.OnItemChangeReceived(delegate(object? o, ItemChangedEventArgs e)
		{
			OnItemChangeReceived(e);
		}).AddTo(base.Disposables);
		cart.OnItemReceivedOnCartUpdate(delegate(object? o, OfferUpdatedEventArgs e)
		{
			OnItemReceivedOnCartUpdate(e);
		}).AddTo(base.Disposables);
		SaveCommentCommand.PerformDebouncingTask(SaveCommentAsync).Subscribe().AddTo(base.Disposables);
		_initCompleted = true;
	}

	private void OnItemChangedByUser(OfferUpdatedEventArgs e)
	{
		if (e.Offer.GetKey() == ProductOffer.GetKey())
		{
			IsSelected = e.Offer.IsSelected;
		}
	}

	private void OnItemReceivedOnCartUpdate(OfferUpdatedEventArgs e)
	{
		if (e.Offer.GetKey() == ProductOffer.GetKey())
		{
			ProductOffer = e.Offer;
			IsSelected = e.Offer.IsSelected;
			QtyValue = e.Offer.Qty;
			ShowRealPrice = true;
		}
	}

	private void OnItemChangeReceived(ItemChangedEventArgs e)
	{
		if (e.RequestId == _pendingRequestId)
		{
			switch (e.EventType)
			{
			default:
				return;
			case ItemChangedEventType.Remove:
				OnItemDeleted();
				return;
			case ItemChangedEventType.Change:
				ProductOffer = e.Offer;
				IsSelected = e.Offer.IsSelected;
				QtyValue = e.Offer.Qty;
				ShowRealPrice = true;
				break;
			case ItemChangedEventType.Add:
				break;
			}
			_promoDiscountUsecase.Value.ProcessOfferChange(e.Change, this, base.Disposables);
		}
	}

	public void OpenCommentInput()
	{
		CommentState = CommentVisualState.Input;
	}

	public void DeleteComment()
	{
		if (string.IsNullOrEmpty(Comment))
		{
			ResetCommentChanges();
			return;
		}
		CommentInput = string.Empty;
		SaveCommentCommand.Trigger();
	}

	public void ResetCommentChanges()
	{
		if (string.IsNullOrEmpty(CommentInput) || !string.Equals(CommentInput, Comment, StringComparison.Ordinal))
		{
			CommentInput = Comment;
			RaisePropertyChanged("Comment");
			if (string.IsNullOrEmpty(CommentInput))
			{
				CommentState = CommentVisualState.Default;
			}
		}
	}

	private async Task SaveCommentAsync()
	{
		bool flag = string.IsNullOrEmpty(CommentInput);
		if (string.Equals(CommentInput, Comment, StringComparison.Ordinal))
		{
			if (flag)
			{
				CommentState = CommentVisualState.Default;
			}
			return;
		}
		if (!flag && string.IsNullOrWhiteSpace(CommentInput))
		{
			ResetCommentChanges();
			return;
		}
		CommentState = CommentVisualState.InProgress;
		string oldComment = Comment;
		Comment = CommentInput;
		if (!(await _cart.AddCommentToItem(ProductOffer, Comment)))
		{
			Comment = oldComment;
		}
		CommentState = ((!string.IsNullOrEmpty(Comment)) ? CommentVisualState.Input : CommentVisualState.Default);
	}

	public void OnIncrease()
	{
		QtyValue += ProductOffer.BasketStep;
		if (QtyValue > ProductOffer.LastKnownStock)
		{
			QtyValue = ProductOffer.LastKnownStock;
			Vibration.Vibrate();
		}
		if (QtyValue != ProductOffer.Qty)
		{
			ChangeQty();
		}
		RaisePropertyChanged("IncreaseEnabled");
	}

	public void OnDecrease()
	{
		if (QtyValue < 2m * BasketStep)
		{
			Parent.OpenDeleteItemDialogCommand.Trigger(this);
			return;
		}
		QtyValue = Math.Max(QtyValue - ProductOffer.BasketStep, 0m);
		if (QtyValue < ProductOffer.BasketStep)
		{
			QtyValue = 0m;
		}
		if (QtyValue != ProductOffer.Qty)
		{
			ChangeQty();
		}
		RaisePropertyChanged("IncreaseEnabled");
	}

	private void ChangeQty()
	{
		ProductOffer exact = _cart.GetExact(ProductOffer);
		if (!(exact == null))
		{
			ShowRealPrice = false;
			Guid requestId = (_pendingRequestId = Guid.NewGuid());
			_cart.ChangeItemQty(exact, QtyValue, requestId);
		}
	}

	public async Task OnChangeQtyDoneButtonClick()
	{
		ProductOffer exact = _cart.GetExact(ProductOffer);
		if (exact == null)
		{
			return;
		}
		decimal num = ManualQtyHandler.NormalizeQtyIfNeeded(this, exact);
		if (num <= 0.0001m)
		{
			return;
		}
		if (Math.Abs(num - exact.Qty) < 0.0001m)
		{
			ManualInputQty = Qty;
			return;
		}
		Guid requestId = (_pendingRequestId = Guid.NewGuid());
		ShowRealPrice = false;
		QtyValue = num;
		if (Math.Abs(num) < 0.0001m)
		{
			_cart.RemoveItems(new global::_003C_003Ez__ReadOnlySingleElementList<ProductOffer>(exact), requestId);
			Parent.RefreshAdultInformers();
		}
		else
		{
			_cart.ChangeItemQty(exact, num, requestId);
			ManualInputQty = Qty;
		}
	}

	public void HintPopupShown(IDisposable? dismissHandle)
	{
		_hintPopupDismissHandle = dismissHandle;
	}

	public void OnItemDeleted()
	{
		_hintPopupDismissHandle?.Dispose();
		_hintPopupDismissHandle = null;
	}

	public async Task SetSelected(bool selected)
	{
		YieldAwaitable.YieldAwaiter awaiter = Task.Yield().GetAwaiter();
		_ = awaiter.IsCompleted;
		await awaiter;
		YieldAwaitable.YieldAwaiter yieldAwaiter = default(YieldAwaitable.YieldAwaiter);
		awaiter = yieldAwaiter;
		awaiter.GetResult();
		IsSelected = selected;
		Guid requestId = (_pendingRequestId = Guid.NewGuid());
		_cart.SetItemSelected(ProductOffer, selected, requestId);
	}

	private void OnProductOfferChanged(ProductOffer old, ProductOffer @new)
	{
		if (_initCompleted)
		{
			Badges = new BadgesListModel(@new.Badges);
		}
	}

	string IIdentifiable.GetId()
	{
		return $"offer:{ProductOffer.GetKey().GetHashCode()}";
	}
}
