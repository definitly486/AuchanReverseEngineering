using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Akavache.Sqlite3.Internal;
using AsyncAwaitBestPractices;
using Auchan.Common.Addresses;
using Auchan.Common.AdminTool;
using Auchan.Common.Analytics;
using Auchan.Common.Analytics.YandexAppMetrica;
using Auchan.Common.Base;
using Auchan.Common.Base.Errors;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Common;
using Auchan.Common.Common.Binding;
using Auchan.Common.Controls.AutoLayout;
using Auchan.Common.Ecom.Address;
using Auchan.Common.Ecom.Address.Models;
using Auchan.Common.Ecom.AddressStoreSelection;
using Auchan.Common.Ecom.Cart.Errors;
using Auchan.Common.Ecom.Cart.Managers;
using Auchan.Common.Ecom.Cart.Models;
using Auchan.Common.Ecom.Cart.StampsWithdraw;
using Auchan.Common.Ecom.Cart.StampsWithdrawViewModel;
using Auchan.Common.Ecom.Products;
using Auchan.Common.Ecom.Products.ViewModels;
using Auchan.Common.Extensions;
using Auchan.Common.Helpers;
using Auchan.Common.InfoPages;
using Auchan.Common.Logs;
using Auchan.Common.Managers.Dialogs;
using Auchan.Common.PersonalCabinet;
using Auchan.Common.Profile;
using Auchan.Common.Profile.Orders;
using Auchan.Common.Profile.Orders.Enums;
using Auchan.Common.Profile.Orders.Models;
using Auchan.Common.Profile.Orders.Services;
using Auchan.Common.Recommendations;
using Auchan.Common.Recommendations.API.DTO;
using Auchan.Common.Recommendations.Models;
using Auchan.Common.Recommendations.ViewModels;
using Auchan.Common.UniversalLinks;
using CSharpFunctionalExtensions;
using DryIoc;
using EBind;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.ApplicationModel.DataTransfer;

namespace Auchan.Common.Ecom.Cart.ViewModels;

public sealed class CartScreenViewModel : AutoLayoutScreenViewModel, IYandexMetricaScreenViewModel, IScreenViewModel, ICartScreenViewModel, IBindable, INotifyPropertyChanged
{
	private enum BlockOrder
	{
		ReceiveMethod,
		CartHeader,
		CartEmpty,
		CartItems,
		ReservedHeader,
		ReservedCartItems,
		UnavailableHeader,
		UnavailableCartItems,
		CartBottomBlock,
		Recommendations
	}

	public sealed class SharedCartParameter
	{
		public required string Token { get; init; }

		public required SharedCartModel Model { get; init; }
	}

	public enum ProgressState
	{
		RedLessThanStoreMinPrice,
		OrangeIncreasePriceForFreeDelivery,
		OrangeOverweight,
		GreenFreeDelivery
	}

	private const string SHARED_CART_ERROR_TEXT = "Что-то пошло не так.\nПовторите попытку позже.";

	private Func<Task> _retryAction = DoNothing;

	private readonly Cart _cart;

	private readonly IResolver _resolver;

	private readonly Lazy<IUniversalLinksService> _universalLinksService;

	private readonly Lazy<IOrderDetailsParameterFactory> _orderDetailsParameterFactory;

	private readonly Lazy<IActivationParametersStore> _activationParametersStore;

	private readonly Lazy<IInfoMessageService> _infoMessageService;

	private readonly Lazy<IAgeGateDialog> _ageGateDialog;

	private readonly Lazy<ICurrentStoreSelectDialog> _currentStoreSelectDialog;

	private readonly Lazy<AppMetrica> _appMetrica;

	private readonly Lazy<BottomNavigationViewModel.IRemoteControl> _bottomNavigationRemoteControl;

	private readonly IUserContext _userContext;

	private readonly IEcomContext _ecomContext;

	private readonly IAdminContext _adminContext;

	private readonly DefaultErrorTranslator _errorTranslator;

	private readonly ILogService _logService;

	private readonly IStoreService _storeService;

	private readonly RemoteCartService _remoteCartService;

	private readonly Favorites _favorites;

	private readonly IOrdersRepository _ordersRepository;

	private readonly IDataBroker _dataBroker;

	private readonly Func<RecommendationBuilder> _recommendationBuilderFactory;

	private readonly UICommand _retry = new UICommand();

	private readonly TaskQueue _loadRecommendationsQueue = new TaskQueue();

	private bool _recommendationsViewed;

	private TaskCompletionSource _cartUpdateCompletedSource = new TaskCompletionSource();

	private readonly AsyncLock _updateStoreLock = new AsyncLock();

	private readonly IRecommendationsRepository _recommendationRepository;

	private readonly Func<ProductOffer, ICartScreenViewModel, CartItemViewModel> _itemFactory;

	private readonly Func<ProductOffer, CartItemUnavailableViewModel> _unavailableItemFactory;

	private readonly CompositeDisposable _sectionsDisposable = new CompositeDisposable();

	private bool _updateRecomsOnResume = true;

	private bool _scrollToTopOnUpdate;

	private bool _needReopen;

	private int _updateLayoutRequest;

	private bool _onPaused;

	private bool _firstStart = true;

	private int _requestCounter;

	[CompilerGenerated]
	private bool _003CIsFirstScreenUpdateCompleted_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CIsInProgress_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CIsInErrorState_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CIsCartEmpty_003Ek__BackingField;

	[CompilerGenerated]
	private VisualState _003CRepeatOrderServiceState_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CIsCartRequestPending_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CErrorTitle_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CErrorMessage_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CIsWarningVisible_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CIsFavoritesAvailable_003Ek__BackingField;

	[CompilerGenerated]
	private OrderListModel? _003CLastCompletedOrder_003Ek__BackingField;

	[CompilerGenerated]
	private CartModel _003CCartModel_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CIsContainsOffersWithoutModifications_003Ek__BackingField;

	[CompilerGenerated]
	private IReadOnlyList<CartPreviousOrderItemViewModel> _003CPreviousOrdersToAdd_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CPreviousOrdersUpdateIsFailure_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CAppConfigIsCanAddGoodsToOrder_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CIsFreeDeliveryOverweight_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CIsOverweightWarningVisible_003Ek__BackingField;

	[CompilerGenerated]
	private Store _003CActiveStore_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CWarningMessage_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CWarningDescription_003Ek__BackingField;

	[CompilerGenerated]
	private decimal _003CItemCount_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CIsAddressValid_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CIsAdultInCart_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CIsAdultWarningVisible_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CIsExpanded_003Ek__BackingField;

	[CompilerGenerated]
	private ReceivingMethod _003CReceiveMode_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CReceiveAddress_003Ek__BackingField;

	[CompilerGenerated]
	private int _003CReceiveMethodProgress_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CReceiveMethodProgressText_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CReceiveMethodProgressDescription_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CReceiveMethodProgressTwoParts_003Ek__BackingField;

	[CompilerGenerated]
	private IReadOnlyList<DiscountItemViewModel> _003CDiscountItems_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CReceivingMethodPriceText_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CIsFreeDelivery_003Ek__BackingField;

	[CompilerGenerated]
	private UICommand _003CGoToSearchCommand_003Ek__BackingField;

	public UICommand<BrokerToken> GoToCheckoutCommand = new UICommand<BrokerToken>();

	public UICommand<CartItemViewModel> ShowQtyDialogCommand = new UICommand<CartItemViewModel>();

	[CompilerGenerated]
	private decimal _003CStoreFreeDeliveryPriceValue_003Ek__BackingField;

	[CompilerGenerated]
	private int _003CStoreMaxWeightValue_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CIsInLoyalty_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CSelfPickupHightlightViewId_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CCarPickupHightlightViewId_003Ek__BackingField;

	[CompilerGenerated]
	private int _003CGoodsSelected_003Ek__BackingField;

	[CompilerGenerated]
	private int _003CGoodsTotal_003Ek__BackingField;

	public UICommand ToggleAllGoodsSelectionCommand = new UICommand();

	private HashSet<string> EmptyViewTypes { get; } = new HashSet<string> { "TitleBlock", "CartEmptyContent", "RecommendationHorizontalBlock", "RecommendationTitle", "RecommendationProduct", "RecommendationProductStub", "RecommendationLoadMoreButton" };

	private HashSet<string> DefaultViewTypes { get; } = new HashSet<string> { "ReceiveMethodsSelectBlock", "CartHeader", "CartBottomContent", "RecommendationHorizontalBlock", "RecommendationTitle", "RecommendationProduct", "RecommendationProductStub", "RecommendationLoadMoreButton" };

	public string CartTitle => "Корзина";

	public string EmptyCartTitle => "Корзина";

	public string GoToCatalogButtonText => "Перейти в каталог";

	public string GoToFavoritesButtonText => "В избранное";

	public string RetryLastOrderButtonText => "Повторить прошлый заказ?";

	private bool IsFirstScreenUpdateCompleted
	{
		[CompilerGenerated]
		get
		{
			return _003CIsFirstScreenUpdateCompleted_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (_003CIsFirstScreenUpdateCompleted_003Ek__BackingField != value)
			{
				_003CIsFirstScreenUpdateCompleted_003Ek__BackingField = value;
				OnStateChanged();
				RaisePropertyChanged("State");
				RaisePropertyChanged("IsRemoveGoodsButtonVisible");
				RaisePropertyChanged("IsClearButtonAtUnavailableItemsVisible");
				RaisePropertyChanged("IsFirstScreenUpdateCompleted");
			}
		}
	}

	public bool IsInProgress
	{
		[CompilerGenerated]
		get
		{
			return _003CIsInProgress_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CIsInProgress_003Ek__BackingField != value)
			{
				_003CIsInProgress_003Ek__BackingField = value;
				OnStateChanged();
				RaisePropertyChanged("State");
				RaisePropertyChanged("IsRemoveGoodsButtonVisible");
				RaisePropertyChanged("IsClearButtonAtUnavailableItemsVisible");
				RaisePropertyChanged("IsInProgress");
			}
		}
	}

	public bool IsInErrorState
	{
		[CompilerGenerated]
		get
		{
			return _003CIsInErrorState_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CIsInErrorState_003Ek__BackingField != value)
			{
				_003CIsInErrorState_003Ek__BackingField = value;
				OnStateChanged();
				RaisePropertyChanged("State");
				RaisePropertyChanged("IsRemoveGoodsButtonVisible");
				RaisePropertyChanged("IsClearButtonAtUnavailableItemsVisible");
				RaisePropertyChanged("IsInErrorState");
			}
		}
	}

	public bool IsCartEmpty
	{
		[CompilerGenerated]
		get
		{
			return _003CIsCartEmpty_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CIsCartEmpty_003Ek__BackingField != value)
			{
				_003CIsCartEmpty_003Ek__BackingField = value;
				OnStateChanged();
				RaisePropertyChanged("State");
				RaisePropertyChanged("IsRemoveGoodsButtonVisible");
				RaisePropertyChanged("IsClearButtonAtUnavailableItemsVisible");
				RaisePropertyChanged("IsCartEmpty");
			}
		}
	}

	public VisualState RepeatOrderServiceState
	{
		[CompilerGenerated]
		get
		{
			return _003CRepeatOrderServiceState_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CRepeatOrderServiceState_003Ek__BackingField != value)
			{
				_003CRepeatOrderServiceState_003Ek__BackingField = value;
				OnStateChanged();
				RaisePropertyChanged("State");
				RaisePropertyChanged("IsRemoveGoodsButtonVisible");
				RaisePropertyChanged("IsClearButtonAtUnavailableItemsVisible");
				RaisePropertyChanged("RepeatOrderServiceState");
			}
		}
	} = VisualState.Default;

	public VisualState State
	{
		get
		{
			if (!IsInErrorState)
			{
				if (!IsCartEmpty)
				{
					if (!IsInProgress && IsFirstScreenUpdateCompleted)
					{
						return RepeatOrderServiceState;
					}
					return VisualState.InProgress;
				}
				return VisualState.Empty;
			}
			return VisualState.Error;
		}
	}

	public bool IsCartRequestPending
	{
		[CompilerGenerated]
		get
		{
			return _003CIsCartRequestPending_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CIsCartRequestPending_003Ek__BackingField != value)
			{
				_003CIsCartRequestPending_003Ek__BackingField = value;
				RaisePropertyChanged("IsGotoCheckoutButtonEnabled");
				RaisePropertyChanged("IsCartRequestPending");
			}
		}
	}

	public string ErrorTitle
	{
		[CompilerGenerated]
		get
		{
			return _003CErrorTitle_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CErrorTitle_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CErrorTitle_003Ek__BackingField = value;
				RaisePropertyChanged("ErrorTitle");
			}
		}
	} = "Упс! Что-то пошло не так.";

	public string ErrorMessage
	{
		[CompilerGenerated]
		get
		{
			return _003CErrorMessage_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CErrorMessage_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CErrorMessage_003Ek__BackingField = value;
				RaisePropertyChanged("ErrorMessage");
			}
		}
	} = "Небольшие технические проблемы,\nпопробуйте обновить экран.";

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

	public bool IsFavoritesAvailable
	{
		[CompilerGenerated]
		get
		{
			return _003CIsFavoritesAvailable_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CIsFavoritesAvailable_003Ek__BackingField != value)
			{
				_003CIsFavoritesAvailable_003Ek__BackingField = value;
				RaisePropertyChanged("IsFavoritesAvailable");
			}
		}
	}

	public bool IsLastCompletedOrderAvailable => LastCompletedOrder != null;

	public OrderListModel? LastCompletedOrder
	{
		[CompilerGenerated]
		get
		{
			return _003CLastCompletedOrder_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!(_003CLastCompletedOrder_003Ek__BackingField == value))
			{
				_003CLastCompletedOrder_003Ek__BackingField = value;
				RaisePropertyChanged("IsLastCompletedOrderAvailable");
				RaisePropertyChanged("LastCompletedOrder");
			}
		}
	}

	public CartModel CartModel
	{
		[CompilerGenerated]
		get
		{
			return _003CCartModel_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!(_003CCartModel_003Ek__BackingField == value))
			{
				_003CCartModel_003Ek__BackingField = value;
				RaisePropertyChanged("MarkingInfo");
				RaisePropertyChanged("IsTooManyMarkedGoodsVisible");
				RaisePropertyChanged("OrderButtonTitle");
				RaisePropertyChanged("IsGoCheckoutButtonContentVisible");
				RaisePropertyChanged("ExcessOfMarkedGoods");
				RaisePropertyChanged("MarkedGoodsText");
				RaisePropertyChanged("TooManyMarkedGoodsText");
				RaisePropertyChanged("RemoveMarkedGoodsButtonText");
				RaisePropertyChanged("SelectedItemCount");
				RaisePropertyChanged("CountAndWeightTitle");
				RaisePropertyChanged("NotEnoughToNextDeliveryThreshold");
				RaisePropertyChanged("NotEnoughDeliveryText");
				RaisePropertyChanged("NextDeliveryThreshold");
				RaisePropertyChanged("TotalItemsCount");
				RaisePropertyChanged("TotalItemsPriceText");
				RaisePropertyChanged("TotalItemsPriceValueIgnoreDiscount");
				RaisePropertyChanged("TotalItemsPrice");
				RaisePropertyChanged("TotalDiscountValue");
				RaisePropertyChanged("HasDiscount");
				RaisePropertyChanged("TotalDiscount");
				RaisePropertyChanged("TotalItemsWeightValue");
				RaisePropertyChanged("IsWeightValid");
				RaisePropertyChanged("OrderEnabled");
				RaisePropertyChanged("IsGotoCheckoutButtonEnabled");
				RaisePropertyChanged("OverweightWarningDescription");
				RaisePropertyChanged("TotalItemsWeight");
				RaisePropertyChanged("IsTotalItemWeightVisible");
				RaisePropertyChanged("TotalReservedItemsPriceValue");
				RaisePropertyChanged("TotalReservedOrderPrice");
				RaisePropertyChanged("TotalCartItemsPriceValue");
				RaisePropertyChanged("TotalInCartOrderPrice");
				RaisePropertyChanged("DeliveryPriceSummary");
				RaisePropertyChanged("DeliveryOverPriceSummary");
				RaisePropertyChanged("TotalOrderPriceValue");
				RaisePropertyChanged("PriceMoreThanMinStorePrice");
				RaisePropertyChanged("PickupHighlightAvailable");
				RaisePropertyChanged("PickupAvailable");
				RaisePropertyChanged("CarPickupAvailable");
				RaisePropertyChanged("TotalOrderPrice");
				RaisePropertyChanged("TotalPriceValue");
				RaisePropertyChanged("TotalPrice");
				RaisePropertyChanged("CurrentDeliveryPriceValue");
				RaisePropertyChanged("DeliverySumText");
				RaisePropertyChanged("DeliveryPrice");
				RaisePropertyChanged("PickingPrice");
				RaisePropertyChanged("PickingPriceText");
				RaisePropertyChanged("PickingPriceVisible");
				RaisePropertyChanged("CartModel");
			}
		}
	}

	public bool IsContainsOffersWithoutModifications
	{
		[CompilerGenerated]
		get
		{
			return _003CIsContainsOffersWithoutModifications_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CIsContainsOffersWithoutModifications_003Ek__BackingField != value)
			{
				_003CIsContainsOffersWithoutModifications_003Ek__BackingField = value;
				RaisePropertyChanged("IsPreviousOrdersVisible");
				RaisePropertyChanged("IsYouCanAddToPreviousOrderVisible");
				RaisePropertyChanged("IsContainsOffersWithoutModifications");
			}
		}
	}

	public bool IsPreviousOrdersVisible
	{
		get
		{
			if (PreviousOrdersToAdd.Any() && IsContainsOffersWithoutModifications)
			{
				return AppConfigIsCanAddGoodsToOrder;
			}
			return false;
		}
	}

	public bool IsPreviousOrdersPagerVisible => PreviousOrdersToAdd.Count > 1;

	public IReadOnlyList<CartPreviousOrderItemViewModel> PreviousOrdersToAdd
	{
		[CompilerGenerated]
		get
		{
			return _003CPreviousOrdersToAdd_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003CPreviousOrdersToAdd_003Ek__BackingField, value))
			{
				_003CPreviousOrdersToAdd_003Ek__BackingField = value;
				RaisePropertyChanged("IsPreviousOrdersVisible");
				RaisePropertyChanged("IsYouCanAddToPreviousOrderVisible");
				RaisePropertyChanged("IsPreviousOrdersPagerVisible");
				RaisePropertyChanged("PreviousOrdersToAdd");
			}
		}
	} = Array.Empty<CartPreviousOrderItemViewModel>();

	public UICommand<CartPreviousOrderItemViewModel> AddToOrderCommand { get; } = new UICommand<CartPreviousOrderItemViewModel>();

	public string YouCanAddToPreviousOrderText => "Если что-то забудете - оплаченный заказ можно будет дополнить до начала его сборки";

	public bool PreviousOrdersUpdateIsFailure
	{
		[CompilerGenerated]
		get
		{
			return _003CPreviousOrdersUpdateIsFailure_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CPreviousOrdersUpdateIsFailure_003Ek__BackingField != value)
			{
				_003CPreviousOrdersUpdateIsFailure_003Ek__BackingField = value;
				RaisePropertyChanged("IsYouCanAddToPreviousOrderVisible");
				RaisePropertyChanged("PreviousOrdersUpdateIsFailure");
			}
		}
	}

	public bool AppConfigIsCanAddGoodsToOrder
	{
		[CompilerGenerated]
		get
		{
			return _003CAppConfigIsCanAddGoodsToOrder_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CAppConfigIsCanAddGoodsToOrder_003Ek__BackingField != value)
			{
				_003CAppConfigIsCanAddGoodsToOrder_003Ek__BackingField = value;
				RaisePropertyChanged("IsPreviousOrdersVisible");
				RaisePropertyChanged("IsYouCanAddToPreviousOrderVisible");
				RaisePropertyChanged("AppConfigIsCanAddGoodsToOrder");
			}
		}
	}

	public bool IsYouCanAddToPreviousOrderVisible
	{
		get
		{
			if (AppConfigIsCanAddGoodsToOrder && !PreviousOrdersUpdateIsFailure && !IsPreviousOrdersVisible)
			{
				return IsContainsOffersWithoutModifications;
			}
			return false;
		}
	}

	public UICommand<BrokerToken> ShowAddProductsToOrderPopupCommand { get; } = new UICommand<BrokerToken>();

	public UICommand<BrokerToken> ShowSuccessAdditionalOrderPopupCommand { get; } = new UICommand<BrokerToken>();

	public UICommand<AddToOrderFailedViewModel.Parameter> ShowAddToOrderFailedCommand { get; } = new UICommand<AddToOrderFailedViewModel.Parameter>();

	public UICommand<OrderDetailsViewModel.Parameter> ShowOrderDetailCommand { get; } = new UICommand<OrderDetailsViewModel.Parameter>();

	public bool IsFreeDeliveryOverweight
	{
		[CompilerGenerated]
		get
		{
			return _003CIsFreeDeliveryOverweight_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CIsFreeDeliveryOverweight_003Ek__BackingField != value)
			{
				_003CIsFreeDeliveryOverweight_003Ek__BackingField = value;
				RaisePropertyChanged("IsReceiveMethodProgressDescriptionVisible");
				RaisePropertyChanged("IsFreeDeliveryOverweight");
			}
		}
	}

	public bool IsOverweightWarningVisible
	{
		[CompilerGenerated]
		get
		{
			return _003CIsOverweightWarningVisible_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CIsOverweightWarningVisible_003Ek__BackingField != value)
			{
				_003CIsOverweightWarningVisible_003Ek__BackingField = value;
				RaisePropertyChanged("IsOverweightWarningVisible");
			}
		}
	}

	public bool IsWeightValid
	{
		get
		{
			if (!(TotalItemsWeightValue <= (decimal)StoreMaxWeightValue))
			{
				return StoreMaxWeightValue == 0;
			}
			return true;
		}
	}

	public MarkingInfo MarkingInfo => CartModel.MarkingInfo;

	public bool IsTooManyMarkedGoodsVisible => MarkingInfo.LimitExcess;

	public int ExcessOfMarkedGoods => MarkingInfo.Excess;

	public string MarkedGoodsText => $" {ExcessOfMarkedGoods} " + GrammarHelper.DeclineNoun(ExcessOfMarkedGoods, new string[3] { "маркированный товар", "маркированных товара", "маркированных товаров" });

	public string TooManyMarkedGoodsText => "Слишком много маркированных товаров. Пожалуйста, уберите" + MarkedGoodsText + " из выбора или уменьшите их количество";

	public string RemoveMarkedGoodsButtonText => "Уберите" + MarkedGoodsText;

	public Store ActiveStore
	{
		[CompilerGenerated]
		get
		{
			return _003CActiveStore_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003CActiveStore_003Ek__BackingField, value))
			{
				_003CActiveStore_003Ek__BackingField = value;
				RaisePropertyChanged("StoreMinPriceValue");
				RaisePropertyChanged("PriceMoreThanMinStorePrice");
				RaisePropertyChanged("OrderEnabled");
				RaisePropertyChanged("OrderButtonTitle");
				RaisePropertyChanged("IsGotoCheckoutButtonEnabled");
				RaisePropertyChanged("IsGoCheckoutButtonContentVisible");
				RaisePropertyChanged("PickupHighlightAvailable");
				RaisePropertyChanged("MinOrderSumText");
				RaisePropertyChanged("ActiveStore");
			}
		}
	}

	public bool PriceMoreThanMinStorePrice => TotalOrderPriceValue > StoreMinPriceValue;

	public bool PickupHighlightAvailable
	{
		get
		{
			if (_ecomContext.ReceivingMethod == ReceivingMethod.Delivery && TotalOrderPriceValue < StoreMinPriceValue)
			{
				if (!PickupAvailable)
				{
					return CarPickupAvailable;
				}
				return true;
			}
			return false;
		}
	}

	public bool PickupAvailable
	{
		get
		{
			if (_ecomContext.ActiveStore.HasStorePickUp)
			{
				return TotalOrderPriceValue >= _ecomContext.ActiveStore.GetMinCost(ReceivingMethod.Pickup, _cart.HasAvailableAdultProducts);
			}
			return false;
		}
	}

	public bool CarPickupAvailable
	{
		get
		{
			if (_ecomContext.ActiveStore.HasCarPickup)
			{
				return TotalOrderPriceValue >= _ecomContext.ActiveStore.GetMinCost(ReceivingMethod.CarPickup, _cart.HasAvailableAdultProducts);
			}
			return false;
		}
	}

	public string OverweightWarningMessage => "Вес вашего заказа превышает максимальный.";

	public string OverweightWarningDescription => $"Максимальный вес заказа - {StoreMaxWeightValue:N0} кг\nВес вашего заказа - {TotalItemsWeightValue:N2} кг\n\nУберите {TotalItemsWeightValue - (decimal)StoreMaxWeightValue:N2} кг, чтобы оформить заказ";

	public string NotAvailableWarningMessage => GetItemsUnavailableWarningMessage(_cart.ItemsUnavailable.Count);

	public string NotAvailableWarningDescription => "Перейти к отсутствующим товарам";

	public string WarningMessage
	{
		[CompilerGenerated]
		get
		{
			return _003CWarningMessage_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CWarningMessage_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CWarningMessage_003Ek__BackingField = value;
				RaisePropertyChanged("WarningMessage");
			}
		}
	} = "";

	public string WarningDescription
	{
		[CompilerGenerated]
		get
		{
			return _003CWarningDescription_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CWarningDescription_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CWarningDescription_003Ek__BackingField = value;
				RaisePropertyChanged("WarningDescription");
			}
		}
	} = "";

	public string EmptyTitle => "В вашей корзине пусто";

	public string OrderButtonTitle
	{
		get
		{
			if (!IsTooManyMarkedGoodsVisible)
			{
				if (!OrderEnabled)
				{
					if (!IsWeightValid)
					{
						return "Заказ невозможен";
					}
					return $"Заказ от {StoreMinPriceValue} ₽";
				}
				return "";
			}
			return RemoveMarkedGoodsButtonText;
		}
	}

	public string GoToCheckoutTitle => "Оформить заказ";

	public string CountAndWeightTitle => $"{SelectedItemCount} {GrammarHelper.DeclineNoun(SelectedItemCount, new string[3] { "товар", "товара", "товаров" })} • {TotalItemsWeightValue:N2} кг";

	public bool OrderEnabled
	{
		get
		{
			if (IsWeightValid && (PriceMoreThanMinStorePrice || PickupHighlightAvailable))
			{
				return IsAddressValid;
			}
			return false;
		}
	}

	public bool IsGotoCheckoutButtonEnabled
	{
		get
		{
			if (OrderEnabled)
			{
				return !IsCartRequestPending;
			}
			return false;
		}
	}

	public bool IsGoCheckoutButtonContentVisible
	{
		get
		{
			if (OrderEnabled)
			{
				return !IsTooManyMarkedGoodsVisible;
			}
			return false;
		}
	}

	public UICommand<TooManyMarkedProductsPopupViewModel.Parameter> ShowTooManyMarkedGoodsPopup { get; } = new UICommand<TooManyMarkedProductsPopupViewModel.Parameter>();

	private string DeliverySumText => $"{ReceivingMethodPriceText} {CurrentDeliveryPriceValue:C0}";

	public string MinOrderSumText => $"Осталось добавить товаров на {StoreMinPriceValue:C0}";

	public string DeliveryHint => "Необходимо указать корректный адрес на главной странице";

	public int SelectedItemCount => CartModel.TotalCount;

	public decimal ItemCount
	{
		[CompilerGenerated]
		get
		{
			return _003CItemCount_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!decimal.Equals(_003CItemCount_003Ek__BackingField, value))
			{
				_003CItemCount_003Ek__BackingField = value;
				RaisePropertyChanged("IsItemCountAndClearVisible");
				RaisePropertyChanged("IsClearButtonAtUnavailableItemsVisible");
				RaisePropertyChanged("RemoveGoodsButtonText");
				RaisePropertyChanged("ItemCount");
			}
		}
	}

	public bool IsItemCountAndClearVisible => ItemCount > 0m;

	public bool IsClearButtonAtUnavailableItemsVisible
	{
		get
		{
			if (!IsItemCountAndClearVisible)
			{
				return IsRemoveGoodsButtonVisible;
			}
			return false;
		}
	}

	public bool IsUnavailableHeaderTopMarginVisible
	{
		get
		{
			if (!Items.Any())
			{
				return ItemsReserved.Any();
			}
			return true;
		}
	}

	private decimal NotEnoughToNextDeliveryThreshold => CartModel.NotEnoughToNextDeliveryThreshold;

	private decimal NextDeliveryThreshold => CartModel.NextDeliveryThreshold;

	public string NotEnoughDeliveryText
	{
		get
		{
			if (!(NextDeliveryThreshold == 0m))
			{
				return $"Ещё {NotEnoughToNextDeliveryThreshold:C0} до доставки за {NextDeliveryThreshold:C0}";
			}
			return $"Ещё {NotEnoughToNextDeliveryThreshold:C0} до бесплатной доставки";
		}
	}

	public bool IsAddressValid
	{
		[CompilerGenerated]
		get
		{
			return _003CIsAddressValid_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CIsAddressValid_003Ek__BackingField != value)
			{
				_003CIsAddressValid_003Ek__BackingField = value;
				RaisePropertyChanged("OrderEnabled");
				RaisePropertyChanged("OrderButtonTitle");
				RaisePropertyChanged("IsGotoCheckoutButtonEnabled");
				RaisePropertyChanged("IsGoCheckoutButtonContentVisible");
				RaisePropertyChanged("IsAddressValid");
			}
		}
	}

	public string ItemsUnavailableHeader => "Нет в наличии";

	public bool HasUnavailableItems => ItemsUnavailable.Count > 0;

	public string DeleteItemText => "Удалить";

	public string TotalHeaderText => "Итого";

	public bool IsRemoveGoodsButtonVisible => State == VisualState.Default;

	public bool IsRemoveGoodsButtonActive => GoodsSelected > 0;

	public string RemoveGoodsButtonText
	{
		get
		{
			if (!(ItemCount == 0m))
			{
				return "Удалить";
			}
			return "Очистить корзину";
		}
	}

	public string RemoveGoodsDialogTitle
	{
		get
		{
			if (!IsAllGoodsSelected)
			{
				return GrammarHelper.DeclineNoun(GoodsSelected, new string[3] { "Удалить товар", "Удалить товары", "Удалить товары" });
			}
			return "Очистить корзину";
		}
	}

	public string RemoveGoodsDialogText
	{
		get
		{
			if (!IsAllGoodsSelected)
			{
				return GrammarHelper.DeclineNoun(GoodsSelected, new string[3] { "Вы точно хотите удалить выбранный товар?", "Вы точно хотите удалить выбранные товары?", "Вы точно хотите удалить выбранные товары?" });
			}
			return "Вы действительно хотите удалить товары?";
		}
	}

	public string DeleteItemDialogTitle => "Удалить товар";

	public string DeleteItemDialogText => "Вы точно хотите удалить товар?";

	public string RemoveGoodsDialogPositiveText => "Да";

	public string RemoveGoodsDialogNegativeText => "Нет";

	public bool IsAdultInCart
	{
		[CompilerGenerated]
		get
		{
			return _003CIsAdultInCart_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CIsAdultInCart_003Ek__BackingField != value)
			{
				_003CIsAdultInCart_003Ek__BackingField = value;
				RaisePropertyChanged("IsAdultInCart");
			}
		}
	}

	public bool IsAdultWarningVisible
	{
		[CompilerGenerated]
		get
		{
			return _003CIsAdultWarningVisible_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CIsAdultWarningVisible_003Ek__BackingField != value)
			{
				_003CIsAdultWarningVisible_003Ek__BackingField = value;
				RaisePropertyChanged("IsAdultWarningVisible");
			}
		}
	}

	public string AdultInCartText => "В составе заказа присутствуют позиции, требующие подтверждения совершеннолетнего возраста. Для получения необходим документ, удостоверяющий личность.";

	public bool IsTotalItemPriceVisible
	{
		get
		{
			if (!Items.Any((CartItemViewModel i) => i.IsSelected))
			{
				return ItemsReserved.Any((CartItemViewModel i) => i.IsSelected);
			}
			return true;
		}
	}

	public bool CanExpand
	{
		get
		{
			if (Items.Any((CartItemViewModel i) => i.IsSelected))
			{
				return ItemsReserved.Any((CartItemViewModel i) => i.IsSelected);
			}
			return false;
		}
	}

	public bool IsExpanded
	{
		[CompilerGenerated]
		get
		{
			return _003CIsExpanded_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (_003CIsExpanded_003Ek__BackingField != value)
			{
				_003CIsExpanded_003Ek__BackingField = value;
				RaisePropertyChanged("IsExpanded");
			}
		}
	}

	public ReceivingMethod ReceiveMode
	{
		[CompilerGenerated]
		get
		{
			return _003CReceiveMode_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CReceiveMode_003Ek__BackingField != value)
			{
				_003CReceiveMode_003Ek__BackingField = value;
				RaisePropertyChanged("ReceiveMethodLabel");
				RaisePropertyChanged("IsDeliveryInfoIconVisible");
				RaisePropertyChanged("ReceiveMode");
			}
		}
	}

	public string ReceiveMethodLabel => ReceiveMethodConverter.FromReceiveModeToString(ReceiveMode);

	public string ReceiveAddress
	{
		[CompilerGenerated]
		get
		{
			return _003CReceiveAddress_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CReceiveAddress_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CReceiveAddress_003Ek__BackingField = value;
				RaisePropertyChanged("ReceiveAddress");
			}
		}
	} = string.Empty;

	public int ReceiveMethodProgress
	{
		[CompilerGenerated]
		get
		{
			return _003CReceiveMethodProgress_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CReceiveMethodProgress_003Ek__BackingField != value)
			{
				_003CReceiveMethodProgress_003Ek__BackingField = value;
				RaisePropertyChanged("ReceiveMethodProgress");
			}
		}
	}

	public string ReceiveMethodProgressText
	{
		[CompilerGenerated]
		get
		{
			return _003CReceiveMethodProgressText_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CReceiveMethodProgressText_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CReceiveMethodProgressText_003Ek__BackingField = value;
				RaisePropertyChanged("ReceiveMethodProgressText");
			}
		}
	} = string.Empty;

	public string ReceiveMethodProgressDescription
	{
		[CompilerGenerated]
		get
		{
			return _003CReceiveMethodProgressDescription_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CReceiveMethodProgressDescription_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CReceiveMethodProgressDescription_003Ek__BackingField = value;
				RaisePropertyChanged("IsReceiveMethodProgressDescriptionVisible");
				RaisePropertyChanged("ReceiveMethodProgressDescription");
			}
		}
	} = string.Empty;

	public bool IsReceiveMethodProgressDescriptionVisible
	{
		get
		{
			if (!string.IsNullOrEmpty(ReceiveMethodProgressDescription))
			{
				return !IsFreeDeliveryOverweight;
			}
			return false;
		}
	}

	public bool ReceiveMethodProgressTwoParts
	{
		[CompilerGenerated]
		get
		{
			return _003CReceiveMethodProgressTwoParts_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CReceiveMethodProgressTwoParts_003Ek__BackingField != value)
			{
				_003CReceiveMethodProgressTwoParts_003Ek__BackingField = value;
				RaisePropertyChanged("ReceiveMethodProgressTwoParts");
			}
		}
	}

	public ObservableRangeCollection<CartItemViewModel> Items { get; } = new ObservableRangeCollection<CartItemViewModel>();

	public ObservableRangeCollection<CartItemViewModel> ItemsReserved { get; } = new ObservableRangeCollection<CartItemViewModel>();

	public ObservableRangeCollection<CartItemUnavailableViewModel> ItemsUnavailable { get; } = new ObservableRangeCollection<CartItemUnavailableViewModel>();

	public IReadOnlyList<DiscountItemViewModel> DiscountItems
	{
		[CompilerGenerated]
		get
		{
			return _003CDiscountItems_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003CDiscountItems_003Ek__BackingField, value))
			{
				_003CDiscountItems_003Ek__BackingField = value;
				RaisePropertyChanged("HasDiscountItems");
				RaisePropertyChanged("DiscountItems");
			}
		}
	}

	public bool HasDiscountItems => DiscountItems.Any();

	public decimal TotalItemsCount => CartModel.TotalCount;

	public string TotalItemsPriceText
	{
		get
		{
			if (Items.Any((CartItemViewModel i) => i.IsSelected))
			{
				return $"Товары ({TotalItemsCount})";
			}
			return $"Резерв в магазине ({TotalItemsCount})";
		}
	}

	public string TotalItemsWeightText => "Вес заказа";

	public string TotalItemsPrice => $"{TotalItemsPriceValueIgnoreDiscount:C2}";

	public string TotalItemsWeight => $"{TotalItemsWeightValue:F1} кг";

	public bool IsTotalItemWeightVisible => TotalItemsWeightValue > 0m;

	public string ReceivingMethodPriceText
	{
		[CompilerGenerated]
		get
		{
			return _003CReceivingMethodPriceText_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CReceivingMethodPriceText_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CReceivingMethodPriceText_003Ek__BackingField = value;
				RaisePropertyChanged("DeliverySumText");
				RaisePropertyChanged("ReceivingMethodPriceText");
			}
		}
	}

	public bool HasDiscount => TotalDiscountValue > 0m;

	public string TotalDiscountTitle => "Экономия";

	public string TotalInCartTitle => "Товары в заказе";

	public string TotalReservedTitle => "Резерв в магазине";

	public string TotalDiscount => $"{TotalDiscountValue:C2}";

	public string DeliveryPrice
	{
		get
		{
			if (!IsFreeDelivery)
			{
				return $"{CurrentDeliveryPriceValue:C0}";
			}
			return "Бесплатно";
		}
	}

	public bool IsDeliveryInfoIconVisible
	{
		get
		{
			if (ReceiveMode.IsDelivery())
			{
				return !IsFreeDelivery;
			}
			return false;
		}
	}

	public bool IsFreeDelivery
	{
		[CompilerGenerated]
		get
		{
			return _003CIsFreeDelivery_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CIsFreeDelivery_003Ek__BackingField != value)
			{
				_003CIsFreeDelivery_003Ek__BackingField = value;
				RaisePropertyChanged("DeliveryPrice");
				RaisePropertyChanged("IsDeliveryInfoIconVisible");
				RaisePropertyChanged("IsFreeDelivery");
			}
		}
	}

	public string TotalOrderPriceText => "Сумма заказа";

	public string TotalOrderPrice => $"{TotalOrderPriceValue:C2}";

	public string TotalPriceText => "Общая стоимость";

	public string TotalPrice => $"{TotalPriceValue:C2}";

	public string TotalInCartOrderPrice => $"{TotalCartItemsPriceValue:C2}";

	public string TotalReservedOrderPrice => $"{TotalReservedItemsPriceValue:C2}";

	public string QtyDialogTitle => "Количество товара";

	public string QtyDialogClose => "Закрыть";

	public string QtyDialogDone => "Готово";

	public string ProgressCartTitle => "Проверяем наличие товаров...";

	public bool CartIsEmpty => _cart.IsEmpty;

	public UICommand<ProductDetailsViewModel.Parameter> NavigateToProductDetailsCommand { get; } = new UICommand<ProductDetailsViewModel.Parameter>();

	public UICommand GoToCatalogCommand { get; } = new UICommand();

	public UICommand GoToFavoritesCommand { get; } = new UICommand();

	public UICommand GoToSearchCommand
	{
		[CompilerGenerated]
		get
		{
			return _003CGoToSearchCommand_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!object.Equals(_003CGoToSearchCommand_003Ek__BackingField, value))
			{
				_003CGoToSearchCommand_003Ek__BackingField = value;
				RaisePropertyChanged("GoToSearchCommand");
			}
		}
	} = new UICommand();

	public UICommand<BrokerToken> OpenStampsNoConnectCommand { get; } = new UICommand<BrokerToken>();

	public UICommand<BrokerToken> OpenStampsProductsCommand { get; } = new UICommand<BrokerToken>();

	public UICommand OpenRemoveGoodsDialogCommand { get; } = new UICommand();

	public UICommand<BrokerToken> NavigateToStaticProductListCommand { get; } = new UICommand<BrokerToken>();

	public UICommand<CartItemUnavailableViewModel> ShowReplacementsCommand { get; } = new UICommand<CartItemUnavailableViewModel>();

	public UICommand<InfoPageViewModel.Parameter> OnLoyaltyPolicyCommand { get; } = new UICommand<InfoPageViewModel.Parameter>();

	public UICommand<InfoPageViewModel.Parameter> OnStampsPolicyCommand { get; } = new UICommand<InfoPageViewModel.Parameter>();

	public UICommand<DeliveryInfoPopupViewModel.Parameter> OpenDeliveryInfoCommand { get; } = new UICommand<DeliveryInfoPopupViewModel.Parameter>();

	public UICommand<AddressViewModel.Parameter> OpenAddressCheckCommand { get; } = new UICommand<AddressViewModel.Parameter>();

	public UICommand<CartItemViewModel> OpenDeleteItemDialogCommand { get; } = new UICommand<CartItemViewModel>();

	public UICommand<(BrokerToken, HighlightScreenViewModel.Parameter)> HighlightReceiveMethodsCommand { get; } = new UICommand<(BrokerToken, HighlightScreenViewModel.Parameter)>();

	private UICommand CloseHighlightReceiveMethodsCommand { get; } = new UICommand();

	public UICommand ShareCartCommand { get; } = new UICommand();

	public UICommand<BrokerToken> ShowSharedCartCommand { get; } = new UICommand<BrokerToken>();

	public UICommand<BrokerToken> ShowSharedCartIsObsoletedCommand { get; } = new UICommand<BrokerToken>();

	public UICommand<bool> UpdateGoToTopButton { get; } = new UICommand<bool>();

	public UICommand ScrollToTopCommand { get; } = new UICommand();

	private decimal TotalItemsPriceValueIgnoreDiscount => CartModel.Subtotal;

	private decimal TotalDiscountValue => CartModel.TotalDiscount;

	private decimal TotalItemsWeightValue => CartModel.TotalWeight;

	private decimal TotalReservedItemsPriceValue => CartModel.AdultSumValue;

	private decimal TotalCartItemsPriceValue => CartModel.NonAdultSumValue;

	private decimal StoreMinPriceValue => ActiveStore.GetMinCost(_ecomContext.ReceivingMethod, _cart.HasAvailableAdultProducts);

	private decimal StoreFreeDeliveryPriceValue
	{
		[CompilerGenerated]
		get
		{
			return _003CStoreFreeDeliveryPriceValue_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!decimal.Equals(_003CStoreFreeDeliveryPriceValue_003Ek__BackingField, value))
			{
				_003CStoreFreeDeliveryPriceValue_003Ek__BackingField = value;
				RaisePropertyChanged("StoreFreeDeliveryPriceValue");
			}
		}
	}

	private int StoreMaxWeightValue
	{
		[CompilerGenerated]
		get
		{
			return _003CStoreMaxWeightValue_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (_003CStoreMaxWeightValue_003Ek__BackingField != value)
			{
				_003CStoreMaxWeightValue_003Ek__BackingField = value;
				RaisePropertyChanged("IsWeightValid");
				RaisePropertyChanged("OrderButtonTitle");
				RaisePropertyChanged("OrderEnabled");
				RaisePropertyChanged("IsGotoCheckoutButtonEnabled");
				RaisePropertyChanged("IsGoCheckoutButtonContentVisible");
				RaisePropertyChanged("OverweightWarningDescription");
				RaisePropertyChanged("StoreMaxWeightValue");
			}
		}
	}

	private decimal DeliveryPriceSummary => CartModel.DeliveryPrice;

	private decimal DeliveryOverPriceSummary => CartModel.DeliveryOverPrice;

	private decimal TotalOrderPriceValue => CartModel.Total;

	private decimal TotalPriceValue => TotalOrderPriceValue + (decimal)CurrentDeliveryPriceValue + (decimal)PickingPrice;

	private int CurrentDeliveryPriceValue => (int)CartModel.DeliveryTotalPrice;

	public RecommendationsViewModel Recommendations { get; }

	public EndlessRecommendationsViewModel EndlessRecommendations { get; }

	public ReceiveMethodSelectElementViewModel ReceiveMethodViewModel { get; }

	public bool IsInLoyalty
	{
		[CompilerGenerated]
		get
		{
			return _003CIsInLoyalty_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CIsInLoyalty_003Ek__BackingField != value)
			{
				_003CIsInLoyalty_003Ek__BackingField = value;
				RaisePropertyChanged("IsDelayedCashbackTextVisible");
				RaisePropertyChanged("IsInLoyalty");
			}
		}
	}

	private bool StampsEnabled
	{
		get
		{
			if (!_adminContext.AppConfigIsNotNull)
			{
				return false;
			}
			return _adminContext.StampsConfig?.ShowStampsToCurrentUser == true;
		}
	}

	public LinkedText LoyaltyInformerText
	{
		get
		{
			if (!StampsEnabled)
			{
				return PointsInformerText;
			}
			return PointsAndStampsInformerText;
		}
	}

	private LinkedText PointsInformerText => new LinkedText("За данный заказ вам будут начислены баллы согласно правилам {0}", "программы лояльности", ShowLoyaltyRules);

	private LinkedText PointsAndStampsInformerText => new LinkedText("За данный заказ вам будут начислены баллы и марки согласно правилам {0}", "программы лояльности", ShowLoyaltyRules);

	public LinkedText DelayedCashbackText => new LinkedText("Баллы за этот товар станут активны через 14 дней после покупки в соответствии с правилами программы лояльности", "программы лояльности", delegate
	{
		OnLoyaltyPolicyCommand.Trigger(new InfoPageViewModel.Parameter(InfoType.LoyaltyPolicy));
	});

	public bool IsDelayedCashbackTextVisible
	{
		get
		{
			if (Items.ToImmutableArray().Any((CartItemViewModel item) => item.IsDelayedCashbackBadgeVisible) && !IsInLoyalty)
			{
				return !string.IsNullOrEmpty(DelayedCashbackText.Text);
			}
			return false;
		}
	}

	public string SelfPickupHightlightViewId
	{
		[CompilerGenerated]
		get
		{
			return _003CSelfPickupHightlightViewId_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(_003CSelfPickupHightlightViewId_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CSelfPickupHightlightViewId_003Ek__BackingField = value;
				RaisePropertyChanged("SelfPickupHightlightViewId");
			}
		}
	} = string.Empty;

	public string CarPickupHightlightViewId
	{
		[CompilerGenerated]
		get
		{
			return _003CCarPickupHightlightViewId_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(_003CCarPickupHightlightViewId_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CCarPickupHightlightViewId_003Ek__BackingField = value;
				RaisePropertyChanged("CarPickupHightlightViewId");
			}
		}
	} = string.Empty;

	string IYandexMetricaScreenViewModel.ScreenNameForBaseEvents => "Cart";

	string IYandexMetricaScreenViewModel.ScreenName => "Cart";

	public string PickingPriceTitle => "Сервисный сбор";

	public string PickingPriceText => $"{PickingPrice:C0}";

	public int PickingPrice => CartModel.PickingPrice;

	public bool PickingPriceVisible => PickingPrice != 0;

	public RepeatOrderService RepeatOrderService { get; }

	public bool IsAllGoodsSelected => GoodsSelected == GoodsTotal;

	public bool IsAnyGoodsSelected => GoodsSelected > 0;

	public int GoodsSelected
	{
		[CompilerGenerated]
		get
		{
			return _003CGoodsSelected_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CGoodsSelected_003Ek__BackingField != value)
			{
				_003CGoodsSelected_003Ek__BackingField = value;
				RaisePropertyChanged("IsRemoveGoodsButtonActive");
				RaisePropertyChanged("RemoveGoodsDialogTitle");
				RaisePropertyChanged("RemoveGoodsDialogText");
				RaisePropertyChanged("IsAllGoodsSelected");
				RaisePropertyChanged("IsAnyGoodsSelected");
				RaisePropertyChanged("GoodsSelectedText");
				RaisePropertyChanged("GoodsSelected");
			}
		}
	}

	public int GoodsTotal
	{
		[CompilerGenerated]
		get
		{
			return _003CGoodsTotal_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CGoodsTotal_003Ek__BackingField != value)
			{
				_003CGoodsTotal_003Ek__BackingField = value;
				RaisePropertyChanged("IsAllGoodsSelected");
				RaisePropertyChanged("RemoveGoodsDialogTitle");
				RaisePropertyChanged("RemoveGoodsDialogText");
				RaisePropertyChanged("GoodsSelectedText");
				RaisePropertyChanged("GoodsTotal");
			}
		}
	}

	public string GoodsSelectedText => $"Выбрано {GoodsSelected} из {GoodsTotal}";

	public CartScreenViewModel(Cart cart, IResolver resolver, Lazy<IUniversalLinksService> universalLinksService, Lazy<IOrderDetailsParameterFactory> orderDetailsParameterFactory, Lazy<IActivationParametersStore> activationParametersStore, Lazy<IInfoMessageService> infoMessageService, Lazy<IAgeGateDialog> ageGateDialog, Lazy<ICurrentStoreSelectDialog> currentStoreSelectDialog, Lazy<AppMetrica> appMetrica, Lazy<BottomNavigationViewModel.IRemoteControl> bottomNavigationRemoteControl, IUserContext userContext, IEcomContext ecomContext, IAdminContext adminContext, DefaultErrorTranslator errorTranslator, ILogService logService, IStoreService storeService, IRecommendationsRepository recommendationRepository, IDataBroker dataBroker, RecommendationsViewModel recommendations, Func<RecommendationBuilder> recommendationBuilderFactory, Func<ProductOffer, ICartScreenViewModel, CartItemViewModel> itemFactory, Func<ProductOffer, CartItemUnavailableViewModel> unavailableItemFactory, RemoteCartService remoteCartService, Func<ScreenViewModel, ReceiveMethodSelectElementViewModel> receiveMethodVMFactory, Favorites favorites, IOrdersRepository ordersRepository, EndlessRecommendationsViewModel endlessRecommendations, BottomNavigationViewModel bottomNavigationViewModel, IApplicationStateManager applicationStateManager, RepeatOrderService repeatOrderService)
	{
		CartScreenViewModel cartScreenViewModel = this;
		_cart = cart;
		_resolver = resolver;
		_universalLinksService = universalLinksService;
		_orderDetailsParameterFactory = orderDetailsParameterFactory;
		_activationParametersStore = activationParametersStore;
		_infoMessageService = infoMessageService;
		_ageGateDialog = ageGateDialog;
		_currentStoreSelectDialog = currentStoreSelectDialog;
		_appMetrica = appMetrica;
		_bottomNavigationRemoteControl = bottomNavigationRemoteControl;
		_userContext = userContext;
		_ecomContext = ecomContext;
		_adminContext = adminContext;
		_errorTranslator = errorTranslator;
		_logService = logService;
		_storeService = storeService;
		_dataBroker = dataBroker;
		_recommendationBuilderFactory = recommendationBuilderFactory;
		_recommendationRepository = recommendationRepository;
		_itemFactory = itemFactory;
		_unavailableItemFactory = unavailableItemFactory;
		_remoteCartService = remoteCartService;
		_favorites = favorites;
		_ordersRepository = ordersRepository;
		_dataBroker = dataBroker;
		CartModel = _cart.CartModel;
		RepeatOrderService = repeatOrderService;
		Recommendations = recommendations.Setup(base.CloseDisposable, this);
		EndlessRecommendations = endlessRecommendations.Setup(base.CloseDisposable, this, base.AutoLayout);
		base.ElementViewModels.Add(ReceiveMethodViewModel = receiveMethodVMFactory(this));
		ReceiveMethodViewModel.OnPropertyChanges((ReceiveMethodSelectElementViewModel x) => x.State).Subscribe(delegate(ReceiveMethodSelectElementViewModel.VisualState state)
		{
			if (state == ReceiveMethodSelectElementViewModel.VisualState.Default)
			{
				cartScreenViewModel.UpdateStoreProperties();
			}
		}).AddTo(base.CloseDisposable);
		ReceivingMethodPriceText = (string)((_ecomContext.ReceivingMethod switch
		{
			ReceivingMethod.ExpressDelivery => "Быстрая доставка", 
			ReceivingMethod.RegionDefault => "Доставка", 
			ReceivingMethod.Delivery => "Доставка", 
			ReceivingMethod.Pickup => "Самовывоз", 
			ReceivingMethod.CarPickup => "Авто", 
			_ => throw new NotImplementedException(), 
		}) ?? "");
		ReceiveMethodViewModel.OpenAddressSelectionCommand.PerformDebouncingTask(delegate(AddressViewModel.Parameter p)
		{
			cartScreenViewModel.OpenAddressCheckCommand.Trigger(p);
			return Task.CompletedTask;
		}).Subscribe().AddTo(base.CloseDisposable);
		ActiveStore = _ecomContext.ActiveStore;
		_ecomContext.OnPropertyChanges((IEcomContext x) => x.ActiveStore).Subscribe(delegate(Store x)
		{
			cartScreenViewModel.ActiveStore = x;
		}).AddTo(base.CloseDisposable);
		DiscountItems = new ObservableRangeCollection<DiscountItemViewModel>();
		RaisePropertyChanged("StoreMinPriceValue");
		ShowReplacementsCommand.PerformDebouncingTask(ShowReplacementFor).Subscribe().AddTo(base.CloseDisposable);
		applicationStateManager.OnResumedCallback += new DisposableDelegate<Action>(SetNeedUpdateRecoms, delegate(Action d)
		{
			applicationStateManager.OnResumedCallback -= d;
		}).AddTo(base.CloseDisposable);
		_userContext.BeforeLoggedOut += OnLogout;
		Disposable.Create(delegate
		{
			cartScreenViewModel._userContext.BeforeLoggedOut -= cartScreenViewModel.OnLogout;
		}).AddTo(base.CloseDisposable);
		_cart.OnRequestPending(delegate(int count)
		{
			cartScreenViewModel.IsCartRequestPending = count > 0;
		}).AddTo(base.CloseDisposable);
		_cart.OnSilentCartUpdateCompleted(delegate(object? o, SilentCartUpdateCompletedEventArgs e)
		{
			cartScreenViewModel.OnSilentCartUpdateCompleted(e);
		}).AddTo(base.CloseDisposable);
		_cart.OnAvailableItemsChanged(delegate(object? o, AvailableItemsChangedEventArgs e)
		{
			cartScreenViewModel.OnAvailableItemsChanged(e);
		}).AddTo(base.CloseDisposable);
	}

	protected override async Task Start()
	{
		await base.Start();
		UpdateAutoLayoutOnFirstStart().SafeFireAndForget((Action<Exception>)null, false);
		AddToOrderCommand.PerformDebouncingTask((CartPreviousOrderItemViewModel i) => OnAddToOrderCommand(i)).Subscribe().AddTo(base.CloseDisposable);
		ShareCartCommand.PerformDebouncingTask(OnShareCartCommandAsync).Subscribe().AddTo(base.CloseDisposable);
		base.AutoLayout.Elements.SubscribeToCollectionChanged(delegate
		{
			UpdateGoToTopButton.Trigger(base.AutoLayout.Elements.Any((AutoLayoutViewModel.AutoLayoutElement e) => e.Type == "RecommendationProduct"));
		}, base.CloseDisposable);
		_cart.OnCartChanged((Action)delegate
		{
			UpdateAutoLayoutAsync().SafeFireAndForget((Action<Exception>)null, false);
		}).AddTo(base.CloseDisposable);
		_retry.PerformTask(OnRetry).Subscribe().AddTo(base.CloseDisposable);
		_ecomContext.AfterAddressSet += new DisposableDelegate<Func<Task>>(() => UpdateStoreAndCartOnMethodChangeAsync(), delegate(Func<Task> d)
		{
			_ecomContext.AfterAddressSet -= d;
		}).AddTo(base.CloseDisposable);
		_ecomContext.OnPropertyChanges((IEcomContext x) => x.ReceivingMethod).PerformDebouncingTask(() => UpdateStoreAndCartOnMethodChangeAsync()).Subscribe()
			.AddTo(base.CloseDisposable);
		_ecomContext.OnPropertyChanges((IEcomContext x) => x.ActiveStore).PerformDebouncingTask(() => UpdateStoreAndCartOnMethodChangeAsync()).Subscribe()
			.AddTo(base.CloseDisposable);
		(from x in _ecomContext.OnPropertyChanges((IEcomContext x) => x.DeliveryAddress).StartWith(_ecomContext.DeliveryAddress)
			where !string.IsNullOrWhiteSpace(x?.AddressLine)
			select x).Subscribe(delegate(DeliveryAddress x)
		{
			if (_ecomContext.ReceivingMethod.IsDelivery())
			{
				ReceiveAddress = x.AddressLine;
			}
		}).AddTo(base.CloseDisposable);
		_cart.OnAllAdultDelete.ObserveOn(Auchan.Common.Helpers.MainThread.Scheduler).Subscribe(delegate
		{
			UpdateWarningMessage();
			RefreshCanExpandState();
		}).AddTo(base.CloseDisposable);
		Recommendations.Sections.SubscribeToCollectionChanged(delegate
		{
			OnRecommendationSectionsChanged(Recommendations.Sections, BlockOrder.Recommendations, _sectionsDisposable);
		}, base.CloseDisposable);
		RepeatOrderService.OnStateChanged += new DisposableDelegate<Action<VisualState>>(delegate(VisualState state)
		{
			RepeatOrderServiceState = state;
		}, delegate(Action<VisualState> h)
		{
			RepeatOrderService.OnStateChanged -= h;
		}).AddTo(base.CloseDisposable);
		RepeatOrderService.OnShowReplacement += new DisposableDelegate<Action>(delegate
		{
			_needReopen = true;
		}, delegate(Action h)
		{
			RepeatOrderService.OnShowReplacement -= h;
		}).AddTo(base.CloseDisposable);
		ToggleAllGoodsSelectionCommand.PerformDebouncingTask(OnToggleAllGoodsSelectionCommand).Subscribe().AddTo(base.CloseDisposable);
		Disposable.Create(delegate
		{
			_cartUpdateCompletedSource.TrySetCanceled();
		}).AddTo(base.CloseDisposable);
		async Task UpdateAutoLayoutOnFirstStart()
		{
			await UpdateAutoLayoutAsync();
			IsFirstScreenUpdateCompleted = true;
		}
	}

	private DeliveryInfoPopupViewModel.Parameter CreateShortDeliveryInfoParameter(ReceivingMethod receivingMethod)
	{
		return DeliveryInfoPopupViewModel.Parameter.For(_ecomContext.ActiveStore, receivingMethod, IsAdultInCart, TotalItemsWeightValue, TotalOrderPriceValue);
	}

	public void OnShortDeliveryInfoClicked()
	{
		if (ReceiveMode.IsDelivery() && !IsFreeDelivery)
		{
			OpenDeliveryInfoCommand.Trigger(CreateShortDeliveryInfoParameter(ReceiveMode));
		}
	}

	public void OnFullDeliveryInfoClicked()
	{
		if (ReceiveMode.IsDelivery() && !IsFreeDelivery)
		{
			OpenDeliveryInfoCommand.Trigger(DeliveryInfoPopupViewModel.Parameter.For(_ecomContext.ActiveStore, ReceiveMode, IsAdultInCart));
		}
	}

	protected override async Task OnPaused()
	{
		await base.OnPaused();
		_onPaused = true;
		TabBarVisible = true;
		_recommendationsViewed = false;
	}

	protected override async Task OnResumed()
	{
		_onPaused = false;
		await base.OnResumed();
		if (_adminContext.AppConfigIsNotNull)
		{
			IsExpanded = false;
			AppConfigIsCanAddGoodsToOrder = _adminContext.AppConfig.IsCanAddGoodsToOrder;
			CancellationToken cancellationToken = base.NavigationToken.GetValueOrDefault();
			if (_needReopen)
			{
				OpenRepeatPreviousOrderPopup().SafeFireAndForget((Action<Exception>)null, false);
			}
			_cart.SetCartScreenActive(isActive: true);
			Disposable.Create(delegate
			{
				_cart.SetCartScreenActive(isActive: false);
			}).AddTo(base.PauseDisposable);
			_cart.GenerateNewCartId();
			SendAnalyticsOnResume().SafeFireAndForget((Action<Exception>)null, false);
			UpdateOnResume(cancellationToken).SafeFireAndForget((Action<Exception>)null, false);
			await ReceiveMethodViewModel.LoadReceiveMethods();
			if (!cancellationToken.IsCancellationRequested)
			{
				ReceiveMethodViewModel.ShowExpressDeliveryHighlightIfNeeded();
			}
		}
		async Task UpdateOnResume(CancellationToken cancellationToken2)
		{
			YieldAwaitable.YieldAwaiter awaiter = Task.Yield().GetAwaiter();
			_ = awaiter.IsCompleted;
			await awaiter;
			YieldAwaitable.YieldAwaiter yieldAwaiter = default(YieldAwaitable.YieldAwaiter);
			awaiter = yieldAwaiter;
			awaiter.GetResult();
			Task task = _ecomContext.SyncReceiveMethodQueued();
			Task task2 = UpdateStoreAsync(_firstStart, cancellationToken2);
			Task<Result<CartModel, DomainError>> task3 = UpdateCartState(forCheckout: false, default(CancellationToken));
			_firstStart = false;
			await Task.WhenAll(task, task2, task3);
		}
	}

	private async Task UpdatePreviousOrdersToAddList()
	{
		if (_adminContext.AppConfigIsNotNull && _adminContext.AppConfig.IsCanAddGoodsToOrder)
		{
			YieldAwaitable.YieldAwaiter awaiter = Task.Yield().GetAwaiter();
			_ = awaiter.IsCompleted;
			await awaiter;
			YieldAwaitable.YieldAwaiter yieldAwaiter = default(YieldAwaitable.YieldAwaiter);
			awaiter = yieldAwaiter;
			awaiter.GetResult();
			Result<IReadOnlyList<OrderToAdditionModel>, DomainError> result = await _ordersRepository.GetOrdersAvailableToAdditionAsync();
			PreviousOrdersToAdd = (result.TryGetValue(out var value) ? value.Select((OrderToAdditionModel i) => new CartPreviousOrderItemViewModel(i)).ToImmutableList() : ImmutableList.Create(default(ReadOnlySpan<CartPreviousOrderItemViewModel>)));
			PreviousOrdersUpdateIsFailure = result.IsFailure;
		}
	}

	private async Task SendAnalyticsOnResume()
	{
		Interlocked.Exchange(ref _cartUpdateCompletedSource, new TaskCompletionSource()).TrySetCanceled();
		try
		{
			await _cartUpdateCompletedSource.Task;
			AppAnalytics.Ecom.OnResumedCartScreen(TotalPriceValue, TotalOrderPriceValue, _cart.CartId, _cart.Items.ToList());
		}
		catch (TaskCanceledException)
		{
		}
	}

	public void OnItemClick(CartItemViewModel item)
	{
		NavigateToProductDetailsCommand.Trigger(new ProductDetailsViewModel.Parameter(item.Code));
	}

	public void OnUnavailableItemClick(CartItemUnavailableViewModel item)
	{
		NavigateToProductDetailsCommand.Trigger(new ProductDetailsViewModel.Parameter(item.Code));
	}

	public void OnGoToCatalogClick()
	{
		AppAnalytics.Ecom.OnEmptyCartScreenToCatalogueClick();
		_logService.LogInfo("CartScreenViewModel", "Переход в каталог из корзины", LogType.UserAction, SystemType.MobileApp);
		GoToCatalogCommand.Trigger();
	}

	public async Task OnGoToOrderClickAsync()
	{
		if (LastCompletedOrder != null)
		{
			AppAnalytics.Ecom.OnEmptyCartScreenRepeatLastOrderClick();
			OpenRepeatPreviousOrderPopup().SafeFireAndForget((Action<Exception>)null, false);
		}
	}

	private async Task OpenRepeatPreviousOrderPopup()
	{
		_needReopen = false;
		await RepeatOrderService.OpenRepeatOrderPopup(LastCompletedOrder.Products, LastCompletedOrder.IsAdult);
	}

	public void OnGoToFavoritesClick()
	{
		if (IsFavoritesAvailable)
		{
			AppAnalytics.Ecom.OnEmptyCartScreenToFavoritesClick();
			GoToFavoritesCommand.Trigger();
		}
	}

	public void OnSearchButtonClick()
	{
		AppAnalytics.AppMetrica.TrackEvent("TapCartOnSearch");
		GoToSearchCommand.Trigger();
	}

	public async void OnGoToCheckoutClick()
	{
		_logService.LogInfo("CartScreenViewModel", "Нажата кнопка перехода на checkout", LogType.UserAction, SystemType.MobileApp);
		if (IsTooManyMarkedGoodsVisible)
		{
			ShowTooManyMarkedGoodsPopup.Trigger(new TooManyMarkedProductsPopupViewModel.Parameter
			{
				MarkingInfo = MarkingInfo
			});
			return;
		}
		AppAnalytics.AppMetrica.TrackEvent("cartScreenButtonCheckout");
		AppAnalytics.AppMetrica.TrackPartialOrderInitiated();
		AppAnalytics.AppMetrica.TrackItemsSavedForLater();
		if (PickupHighlightAvailable)
		{
			Dictionary<string, Action> dict = new Dictionary<string, Action>();
			ReceiveMethodViewModel.ReceiveMethods.Where((ReceiveMethodSelectElementViewModel.ReceiveMethodSelectElementItemViewModel rm) => rm.ReceiveMethod == ReceivingMethod.Pickup || rm.ReceiveMethod == ReceivingMethod.CarPickup).ForEach(delegate(ReceiveMethodSelectElementViewModel.ReceiveMethodSelectElementItemViewModel rmViewModel)
			{
				if (rmViewModel.ReceiveMethod == ReceivingMethod.Pickup)
				{
					dict[SelfPickupHightlightViewId] = delegate
					{
						ReceiveMethodViewModel.SelectReceiveMethodCommand.Trigger(rmViewModel);
					};
				}
				else if (rmViewModel.ReceiveMethod == ReceivingMethod.CarPickup)
				{
					dict[CarPickupHightlightViewId] = delegate
					{
						ReceiveMethodViewModel.SelectReceiveMethodCommand.Trigger(rmViewModel);
					};
				}
			});
			ReceiveMethodViewModel.ShowLastReceiveMethodCommand.Trigger();
			HighlightScreenViewModel.Parameter parameter = new HighlightScreenViewModel.Parameter
			{
				Title = "Ваш заказ можно забрать в\u00a0магазине самовывозом или\u00a0на авто",
				Description = $"Если нужна доставка, добавьте товары еще на {Math.Ceiling(StoreMinPriceValue - TotalOrderPriceValue):C0}",
				Views = dict,
				CloseCommand = CloseHighlightReceiveMethodsCommand
			};
			HighlightReceiveMethodsCommand.Trigger((_dataBroker.Push(parameter), parameter));
			return;
		}
		if (ReceiveMode == ReceivingMethod.Delivery && _ecomContext.DeliveryAddress == null)
		{
			AddressViewModel.Parameter subject = new AddressViewModel.Parameter();
			OpenAddressCheckCommand.Trigger(subject);
			return;
		}
		using (BeginRequest())
		{
			Result<CartModel, DomainError> result = await UpdateCartState(forCheckout: true, default(CancellationToken));
			if (result.IsSuccess && (State == VisualState.Default || State == VisualState.InProgress))
			{
				AgreeState agreeState = await AskUserAboutStampsAsync(result.Value.HasStampDiscount);
				if (agreeState == AgreeState.None)
				{
					TabBarVisible = true;
					return;
				}
				SetNeedUpdateRecoms();
				GoToCheckoutCommand.Trigger(_dataBroker.Push(new CheckoutViewModel.Parameter
				{
					DiscardStamps = (agreeState == AgreeState.Yes)
				}));
				await WaitForPause();
			}
		}
	}

	private async Task<AgreeState> AskUserAboutStampsAsync(bool cartHasStampDiscount)
	{
		if (!cartHasStampDiscount)
		{
			return AgreeState.No;
		}
		Result<StampDiscountModel, DomainError> result = await _remoteCartService.StampDiscount();
		if (result.IsSuccess)
		{
			if (result.Value == null)
			{
				return AgreeState.No;
			}
			if (result.Value.Products.Count == 0)
			{
				return AgreeState.No;
			}
			StampDiscountModel value = result.Value;
			StampsWithdrawProductsViewModel.Parameter parameter = new StampsWithdrawProductsViewModel.Parameter(value.Products, value.Stamps, value.CountDescription);
			OpenStampsProductsCommand.Trigger(_dataBroker.Push(parameter));
			return await parameter.WaitForResultAsync();
		}
		StampsLoyaltyNoConnectViewModel.Parameter parameter2 = new StampsLoyaltyNoConnectViewModel.Parameter();
		OpenStampsNoConnectCommand.Trigger(_dataBroker.Push(parameter2));
		return (await parameter2.WaitForResultAsync()) ? AgreeState.No : AgreeState.None;
	}

	private async Task OnShareCartCommandAsync()
	{
		if (!IsAnyGoodsSelected)
		{
			return;
		}
		if ((await InvokeRequest(() => _remoteCartService.ShareCart())).TryGetValue(out var sharedCartModel))
		{
			Task.Run(delegate
			{
				_appMetrica.Value.CreateSharedCartLink(linkCreated: true, sharedCartModel.Token);
			}).SafeFireAndForget((Action<Exception>)null, false);
			await Share.RequestAsync(new ShareTextRequest
			{
				Text = sharedCartModel.Payload,
				Title = sharedCartModel.Title
			});
		}
		else
		{
			_infoMessageService.Value.ShowSnackbar("Что-то пошло не так.\nПовторите попытку позже.");
			Task.Run(delegate
			{
				_appMetrica.Value.CreateSharedCartLink(linkCreated: false, null);
			}).SafeFireAndForget((Action<Exception>)null, false);
		}
	}

	public Task OnRemoveGoodsApprovedAsync()
	{
		if (IsAllGoodsSelected)
		{
			return ClearCart();
		}
		return RemoveSelectedGoods();
	}

	public void OnSwitchIsExpanded()
	{
		if (CanExpand)
		{
			IsExpanded = !IsExpanded;
		}
	}

	public async Task OnDeleteItem(CartItemViewModel item)
	{
		ProductOffer exact = _cart.GetExact(item.ProductOffer);
		_cart.RemoveItems(new global::_003C_003Ez__ReadOnlySingleElementList<ProductOffer>(exact), Guid.NewGuid());
		RefreshAdultInformers();
	}

	public async Task OnDeleteUnavailableItem(CartItemUnavailableViewModel item)
	{
		ProductOffer unavailableExact = _cart.GetUnavailableExact(item.ProductOffer);
		_cart.RemoveUnavailableItems(new global::_003C_003Ez__ReadOnlySingleElementList<ProductOffer>(unavailableExact), Guid.NewGuid());
		RefreshCanExpandState();
		UpdateWarningMessage();
	}

	public void OnQtyEnteredManually(CartItemViewModel cartItemViewModel, string newQtyWithAlias)
	{
		ProductOffer exact = _cart.GetExact(cartItemViewModel.ProductOffer);
		cartItemViewModel.ManualInputQty = ManualQtyHandler.OnQtyEnteredManually(exact, cartItemViewModel, newQtyWithAlias);
	}

	public void OnClearQtyInput(CartItemViewModel cartItemViewModel)
	{
		ProductOffer exact = _cart.GetExact(cartItemViewModel.ProductOffer);
		if (exact != null)
		{
			cartItemViewModel.ManualInputQty = ManualQtyHandler.OnQtyEnteredManually(exact, string.Empty, string.Empty);
		}
	}

	public void RefreshAdultInformers()
	{
		IsAdultInCart = _cart.HasAnyAdultProducts;
		IsAdultWarningVisible = _cart.IsAnyAdultProductSelected;
	}

	public void OnQtyLabelTap(CartItemViewModel item)
	{
		ShowQtyDialogCommand.Trigger(item);
	}

	public void OnRetryButtonClick()
	{
		_retry.Trigger();
	}

	private Task OnRetry(Unit arg)
	{
		return _retryAction();
	}

	private async Task UpdateAutoLayoutAsync()
	{
		if (!Microsoft.Maui.ApplicationModel.MainThread.IsMainThread)
		{
			throw new InvalidOperationException("should be called from main thread");
		}
		if (!_ecomContext.Initialized)
		{
			return;
		}
		int rid = Interlocked.Increment(ref _updateLayoutRequest);
		await Task.Delay(300);
		if (rid == _updateLayoutRequest)
		{
			IReadOnlyList<ProductOffer> items = _cart.Items;
			ObservableRangeCollection<CartItemViewModel> items2 = Items;
			List<ProductOffer> list = new List<ProductOffer>();
			list.AddRange(items.Where((ProductOffer i) => !i.IsAdult));
			bool flag = SetState(items2, new _003C_003Ez__ReadOnlyList<ProductOffer>(list), (ProductOffer o) => _itemFactory(o, this));
			ObservableRangeCollection<CartItemViewModel> itemsReserved = ItemsReserved;
			List<ProductOffer> list2 = new List<ProductOffer>();
			list2.AddRange(items.Where((ProductOffer i) => i.IsAdult));
			bool flag2 = SetState(itemsReserved, new _003C_003Ez__ReadOnlyList<ProductOffer>(list2), (ProductOffer o) => _itemFactory(o, this));
			bool flag3 = SetState(ItemsUnavailable, _cart.ItemsUnavailable, _unavailableItemFactory);
			ItemCount = _cart.TotalItemsQty;
			IsContainsOffersWithoutModifications = _cart.Items.Any((ProductOffer i) => !i.ContainsModifications);
			GoodsSelected = _cart.Items.Count((ProductOffer i) => i.IsSelected);
			GoodsTotal = _cart.Items.Count();
			RefreshCanExpandState();
			UpdateWarningMessage();
			UpdateReceiveMethodProgress();
			RaisePropertyChanged("ReceiveMethodProgress");
			RaisePropertyChanged("StoreMinPriceValue");
			RaisePropertyChanged("IsDelayedCashbackTextVisible");
			_cartUpdateCompletedSource.TrySetResult();
			if (_cart.IsEmpty)
			{
				UpdateEmptyAutoLayout();
			}
			else if (base.AutoLayout.Elements.Count == 0 || flag || flag2 || flag3)
			{
				UpdateDefaultAutoLayout();
			}
			if (_scrollToTopOnUpdate)
			{
				_scrollToTopOnUpdate = false;
				ScrollToTopCommand.Trigger();
			}
			RaisePropertyChanged("CartIsEmpty");
			await Task.Delay(50);
		}
	}

	private static bool SetState<T>(ObservableCollection<T> tgt, IReadOnlyList<ProductOffer> targetState, Func<ProductOffer, T> factory) where T : ICartItemViewModel
	{
		bool result = false;
		for (int i = 0; i < tgt.Count; i++)
		{
			T val = tgt[i];
			bool flag = false;
			for (int j = 0; j < targetState.Count; j++)
			{
				if (val.ProductOffer.GetKey().Equals(targetState[j].GetKey()))
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				val.OnItemDeleted();
				tgt.RemoveAt(i--);
				result = true;
			}
		}
		T val2;
		for (int k = 0; k < targetState.Count; k++)
		{
			ProductOffer productOffer = targetState[k];
			bool flag2 = false;
			for (int l = 0; l < tgt.Count; l++)
			{
				val2 = tgt[l];
				if (val2.ProductOffer.GetKey().Equals(productOffer.GetKey()))
				{
					flag2 = true;
					break;
				}
			}
			if (!flag2)
			{
				tgt.Insert(k, factory(productOffer));
				result = true;
			}
		}
		for (int m = 0; m < tgt.Count; m++)
		{
			T val3 = tgt[m];
			for (int n = 0; n < targetState.Count; n++)
			{
				if (m != n && targetState[n].GetKey().Equals(val3.ProductOffer.GetKey()))
				{
					ref T reference = ref val3;
					val2 = default(T);
					if (val2 == null)
					{
						val2 = reference;
						reference = ref val2;
					}
					ProductOffer productOffer2 = targetState[n];
					reference.ProductOffer = productOffer2;
					tgt.Move(m, n);
				}
			}
		}
		return result;
	}

	private void UpdateDefaultAutoLayout()
	{
		if (!Microsoft.Maui.ApplicationModel.MainThread.IsMainThread)
		{
			throw new InvalidOperationException("should be called from main thread");
		}
		if (base.AutoLayout.Elements.Any((AutoLayoutViewModel.AutoLayoutElement e) => e.Type == "CartEmptyContent"))
		{
			SetNeedUpdateRecoms();
			UpdateStoreAsync(forceRefresh: false, default(CancellationToken)).SafeFireAndForget((Action<Exception>)null, false);
		}
		List<AutoLayoutViewModel.AutoLayoutElement> list = new List<AutoLayoutViewModel.AutoLayoutElement>();
		if (!base.AutoLayout.Elements.Any((AutoLayoutViewModel.AutoLayoutElement e) => e.Type == "ReceiveMethodsSelectBlock"))
		{
			list.Add(AutoLayoutViewModel.AutoLayoutElement.New("ReceiveMethodsSelectBlock", ReceiveMethodViewModel, BlockOrder.ReceiveMethod));
		}
		if (!base.AutoLayout.Elements.Any((AutoLayoutViewModel.AutoLayoutElement e) => e.Type == "CartHeader"))
		{
			list.Add(AutoLayoutViewModel.AutoLayoutElement.New("CartHeader", "cartHeader", BlockOrder.CartHeader));
		}
		if (Items.Any())
		{
			list.AddRange(Items.Select((CartItemViewModel x) => AutoLayoutViewModel.AutoLayoutElement.New("CartItem", x, BlockOrder.CartItems)));
		}
		if (ItemsReserved.Any())
		{
			list.AddRange(ItemsReserved.Select((CartItemViewModel x) => AutoLayoutViewModel.AutoLayoutElement.New("CartItem", x, BlockOrder.ReservedCartItems)).Prepend(AutoLayoutViewModel.AutoLayoutElement.New("CartReservedHeader", "Резерв в магазине", BlockOrder.ReservedHeader)));
		}
		if (ItemsUnavailable.Any())
		{
			list.AddRange(ItemsUnavailable.Select((CartItemUnavailableViewModel x) => AutoLayoutViewModel.AutoLayoutElement.New("UnavailableCartItem", x, BlockOrder.UnavailableCartItems)).Prepend(AutoLayoutViewModel.AutoLayoutElement.New("CartUnavailableHeader", "Нет в наличии", BlockOrder.UnavailableHeader)));
		}
		if (!base.AutoLayout.Elements.Any((AutoLayoutViewModel.AutoLayoutElement e) => e.Type == "CartBottomContent"))
		{
			list.Add(AutoLayoutViewModel.AutoLayoutElement.New("CartBottomContent", "cartBottom", BlockOrder.CartBottomBlock));
		}
		ImmutableList<AutoLayoutViewModel.AutoLayoutElement> source = base.AutoLayout.Elements.Where((AutoLayoutViewModel.AutoLayoutElement e) => !DefaultViewTypes.Contains(e.Type)).ToImmutableList();
		if (source.Any())
		{
			base.AutoLayout.Elements.ReplaceRange(base.AutoLayout.Elements.IndexOf(source.First()), source.Count(), list);
		}
		else
		{
			base.AutoLayout.InsertRange(list);
		}
	}

	private void UpdateEmptyAutoLayout()
	{
		if (!Microsoft.Maui.ApplicationModel.MainThread.IsMainThread)
		{
			throw new InvalidOperationException("should be called from main thread");
		}
		if (base.AutoLayout.Elements.Any((AutoLayoutViewModel.AutoLayoutElement e) => e.Type != "CartEmptyContent"))
		{
			SetNeedUpdateRecoms();
			UpdateStoreAsync(forceRefresh: false, default(CancellationToken)).SafeFireAndForget((Action<Exception>)null, false);
		}
		List<AutoLayoutViewModel.AutoLayoutElement> list = new List<AutoLayoutViewModel.AutoLayoutElement>();
		if (!base.AutoLayout.Elements.Any((AutoLayoutViewModel.AutoLayoutElement e) => e.Type == "TitleBlock"))
		{
			list.Add(AutoLayoutViewModel.AutoLayoutElement.New("TitleBlock", "Корзина", BlockOrder.CartHeader));
		}
		if (!base.AutoLayout.Elements.Any((AutoLayoutViewModel.AutoLayoutElement e) => e.Type == "CartEmptyContent"))
		{
			list.Add(AutoLayoutViewModel.AutoLayoutElement.New("CartEmptyContent", "Корзина", BlockOrder.CartEmpty));
		}
		ImmutableArray<AutoLayoutViewModel.AutoLayoutElement> immutableArray = base.AutoLayout.Elements.Where((AutoLayoutViewModel.AutoLayoutElement e) => !EmptyViewTypes.Contains(e.Type)).ToImmutableArray();
		if (immutableArray.Any())
		{
			base.AutoLayout.Elements.ReplaceRange(base.AutoLayout.Elements.IndexOf(immutableArray.First()), immutableArray.Count(), list);
		}
		else
		{
			base.AutoLayout.InsertRange(list);
		}
	}

	private void RefreshCanExpandState()
	{
		if (!CanExpand)
		{
			IsExpanded = false;
		}
		RaisePropertyChanged("CanExpand");
		RaisePropertyChanged("IsTotalItemPriceVisible");
	}

	private async Task UpdateStoreAsync(bool forceRefresh, CancellationToken cancellationToken)
	{
		int num = 4;
		try
		{
			if (!_adminContext.AppConfigIsNotNull || _onPaused)
			{
				return;
			}
			using (forceRefresh ? BeginRequest() : null)
			{
				YieldAwaitable.YieldAwaiter awaiter = Task.Yield().GetAwaiter();
				bool isCompleted = awaiter.IsCompleted;
				await awaiter;
				YieldAwaitable.YieldAwaiter yieldAwaiter = default(YieldAwaitable.YieldAwaiter);
				awaiter = yieldAwaiter;
				awaiter.GetResult();
				IDisposable disposable = ((!forceRefresh) ? null : (await _updateStoreLock.LockAsync(default(CancellationToken))));
				using (disposable)
				{
					await _ecomContext.SyncReceiveMethodQueued();
					cancellationToken.ThrowIfCancellationRequested();
					UpdateStoreProperties();
					await ShowChangeInLoyaltyRegion();
					cancellationToken.ThrowIfCancellationRequested();
					if (forceRefresh || _updateRecomsOnResume)
					{
						await LoadRecommendations();
					}
					cancellationToken.ThrowIfCancellationRequested();
				}
			}
		}
		catch (OperationCanceledException)
		{
		}
	}

	private async Task UpdateStoreAndCartOnMethodChangeAsync()
	{
		using (BeginRequest())
		{
			await UpdateStoreAsync(forceRefresh: true, default(CancellationToken));
			await UpdateCartState(forCheckout: false, default(CancellationToken));
		}
	}

	private void UpdateStoreProperties()
	{
		ReceivingMethodPriceText = _ecomContext.ReceivingMethod switch
		{
			ReceivingMethod.ExpressDelivery => "Быстрая доставка", 
			ReceivingMethod.Delivery => "Доставка", 
			ReceivingMethod.Pickup => "Самовывоз", 
			ReceivingMethod.CarPickup => "Авто", 
			_ => "Доставка", 
		};
		DeliveryAddress deliveryAddress = _ecomContext.DeliveryAddress;
		if (_ecomContext.ReceivingMethod == ReceivingMethod.Pickup)
		{
			ReceiveMode = ReceivingMethod.Pickup;
			ReceiveAddress = _ecomContext.ActiveStore.Address;
			IsAddressValid = _ecomContext.ActiveStore.HasStorePickUp;
			StoreMaxWeightValue = _ecomContext.ActiveStore.MaxPickupWeightKg;
			IsFreeDelivery = true;
		}
		else if (_ecomContext.ReceivingMethod == ReceivingMethod.CarPickup)
		{
			ReceiveMode = ReceivingMethod.CarPickup;
			ReceiveAddress = _ecomContext.ActiveStore.Address;
			IsAddressValid = _ecomContext.ActiveStore.HasCarPickup;
			StoreMaxWeightValue = _ecomContext.ActiveStore.MaxCarPickupWeightKg;
			IsFreeDelivery = true;
		}
		else if (_ecomContext.ReceivingMethod == ReceivingMethod.Delivery && (deliveryAddress != null || _ecomContext.ActiveStore != null))
		{
			ReceiveMode = ReceivingMethod.Delivery;
			ReceiveAddress = deliveryAddress?.AddressLine ?? _ecomContext.ActiveStore.Address;
			IsAddressValid = _ecomContext.ActiveStore.HasDelivery;
			StoreMaxWeightValue = _ecomContext.ActiveStore.MaxDeliveryWeightKg;
			IsFreeDelivery = _cart.CartModel.DeliveryTotalPrice == 0m;
		}
		else if (_ecomContext.ReceivingMethod == ReceivingMethod.ExpressDelivery && (deliveryAddress != null || _ecomContext.ActiveStore != null))
		{
			ReceiveMode = ReceivingMethod.ExpressDelivery;
			ReceiveAddress = deliveryAddress?.AddressLine ?? _ecomContext.ActiveStore.Address;
			IsAddressValid = _ecomContext.ActiveStore.HasExpressDelivery;
			StoreMaxWeightValue = _ecomContext.ActiveStore.ExpressWeightMax;
			IsFreeDelivery = _cart.CartModel.DeliveryTotalPrice == 0m;
		}
		else if (deliveryAddress == null)
		{
			IsAddressValid = false;
			ReceiveMode = ReceivingMethod.RegionDefault;
			ReceiveAddress = _ecomContext.ActiveStore.City.Name + ", Укажите адрес доставки";
			StoreMaxWeightValue = _ecomContext.ActiveStore.MaxDeliveryWeightKg;
			IsFreeDelivery = _cart.CartModel.DeliveryTotalPrice == 0m;
		}
		if (!ReceiveMethodViewModel.IsReceiveMethodSelected)
		{
			IsAddressValid = false;
		}
		RaisePropertyChanged("PickingPriceVisible");
		RaisePropertyChanged("StoreMinPriceValue");
		RaisePropertyChanged("MinOrderSumText");
		RaisePropertyChanged("ReceiveMethodLabel");
		RaisePropertyChanged("ReceiveAddress");
		RaisePropertyChanged("OrderEnabled");
		RaisePropertyChanged("OrderButtonTitle");
		StoreFreeDeliveryPriceValue = ((ReceiveMode == ReceivingMethod.ExpressDelivery) ? _ecomContext.ActiveStore.MinCostForFreeExpressDelivery : _ecomContext.ActiveStore.MinCostForFreeDelivery);
		UpdateReceiveMethodProgress();
		RaisePropertyChanged("ReceiveMethodProgress");
		RaisePropertyChanged("OverweightWarningDescription");
		RaisePropertyChanged("NotEnoughDeliveryText");
		UpdateWarningMessage();
	}

	public string GetImage(ProductModel product)
	{
		return product.ImageUrl ?? string.Empty;
	}

	public ProgressState GetProgressStatus()
	{
		if (!ReceiveMode.IsDelivery())
		{
			if (!PriceMoreThanMinStorePrice)
			{
				return ProgressState.RedLessThanStoreMinPrice;
			}
			return ProgressState.GreenFreeDelivery;
		}
		if (TotalOrderPriceValue > StoreFreeDeliveryPriceValue)
		{
			if (!IsFreeDeliveryOverweight)
			{
				return ProgressState.GreenFreeDelivery;
			}
			return ProgressState.OrangeOverweight;
		}
		if (!PriceMoreThanMinStorePrice)
		{
			return ProgressState.RedLessThanStoreMinPrice;
		}
		return ProgressState.OrangeIncreasePriceForFreeDelivery;
	}

	private void UpdateReceiveMethodProgress()
	{
		if (!ReceiveMethodViewModel.IsReceiveMethodSelected)
		{
			ReceiveMethodProgressText = "Доставка бесплатно";
			IsFreeDeliveryOverweight = false;
			IsFreeDelivery = true;
			ReceiveMethodProgressDescription = string.Empty;
			ReceiveMethodProgress = 0;
			return;
		}
		decimal totalOrderPriceValue = TotalOrderPriceValue;
		decimal num;
		decimal num2;
		switch (ReceiveMode)
		{
		case ReceivingMethod.Pickup:
		case ReceivingMethod.CarPickup:
			num = (num2 = _ecomContext.ActiveStore.GetMinCost(ReceiveMode, IsAdultInCart));
			break;
		case ReceivingMethod.ExpressDelivery:
			num = _ecomContext.ActiveStore.GetMinCost(ReceivingMethod.ExpressDelivery, IsAdultInCart);
			num2 = _ecomContext.ActiveStore.MinCostForFreeExpressDelivery;
			break;
		default:
			num = _ecomContext.ActiveStore.GetMinCost(ReceivingMethod.Delivery, IsAdultInCart);
			num2 = _ecomContext.ActiveStore.MinCostForFreeDelivery;
			break;
		}
		switch (ReceiveMode)
		{
		case ReceivingMethod.Pickup:
		case ReceivingMethod.CarPickup:
			ReceiveMethodProgress = ((!(num <= 0m)) ? ((int)(Math.Min(totalOrderPriceValue / num, 1m) * 100m)) : 0);
			ReceiveMethodProgressTwoParts = false;
			break;
		default:
			ReceiveMethodProgress = ((!(num <= 0m)) ? ((int)(Math.Min(totalOrderPriceValue / num, 1m) * 50m) + (int)(((totalOrderPriceValue - num) / (num2 - num)).Clamp(0m, 1m) * 50m)) : 0);
			ReceiveMethodProgressTwoParts = ReceiveMethodProgress < 100;
			break;
		}
		if (totalOrderPriceValue < num)
		{
			ReceiveMethodProgressText = $"Осталось добавить товаров на {Math.Ceiling(StoreMinPriceValue - TotalOrderPriceValue):C2}";
			ReceiveMethodProgressDescription = string.Empty;
		}
		if (totalOrderPriceValue > num && totalOrderPriceValue < num2)
		{
			ReceiveMethodProgressText = DeliverySumText;
			ReceiveMethodProgressDescription = NotEnoughDeliveryText;
		}
		if (totalOrderPriceValue > num2)
		{
			IsFreeDeliveryOverweight = TotalItemsWeightValue > _ecomContext.ActiveStore.GetStandardWeightForDeliveryType(ReceiveMode) && (!(DeliveryPriceSummary == 0m) || !(DeliveryOverPriceSummary == 0m));
			if (IsFreeDeliveryOverweight)
			{
				ReceiveMethodProgressTwoParts = false;
				ReceiveMethodProgressText = DeliverySumText;
				return;
			}
			ReceiveMethodProgressText = ReceiveMode switch
			{
				ReceivingMethod.Delivery => "Доставка бесплатно", 
				ReceivingMethod.ExpressDelivery => "Быстрая доставка бесплатно", 
				ReceivingMethod.Pickup => "Самовывоз бесплатно", 
				ReceivingMethod.CarPickup => "АШАН Авто бесплатно", 
				_ => "Доставка бесплатно", 
			};
			ReceiveMethodProgressDescription = string.Empty;
		}
		else
		{
			IsFreeDeliveryOverweight = false;
		}
	}

	private string GetItemsUnavailableWarningMessage(int count)
	{
		int num = count % 10;
		string value = ((count % 100 / 10 == 1) ? "ов" : ((num == 1) ? "а" : "ов"));
		return $"Нет в наличии {count} товар{value}.";
	}

	private void UpdateWarningMessage()
	{
		IsOverweightWarningVisible = !IsWeightValid;
		IsWarningVisible = HasUnavailableItems;
		if (HasUnavailableItems)
		{
			WarningMessage = NotAvailableWarningMessage;
			WarningDescription = "Перейти к отсутствующим товарам";
		}
		IsAdultInCart = _cart.HasAnyAdultProducts;
		IsAdultWarningVisible = _cart.IsAnyAdultProductSelected;
		RaisePropertyChanged("HasUnavailableItems");
	}

	private async Task<Result<CartModel, DomainError>> UpdateCartState(bool forCheckout, CancellationToken cancellationToken)
	{
		_ = 4;
		try
		{
			TabBarVisible = !forCheckout;
			IsInErrorState = false;
			if (_ecomContext.ReceivingMethod.IsDelivery() && _cart.HasAnyAdultProducts)
			{
				await _cart.ClearAllAdultProducts();
			}
			cancellationToken.ThrowIfCancellationRequested();
			UpdatePreviousOrdersToAddList().SafeFireAndForget((Action<Exception>)null, false);
			UpdateFavoritesAvailability().SafeFireAndForget((Action<Exception>)null, false);
			UpdateLastCompletedOrder().SafeFireAndForget((Action<Exception>)null, false);
			Result<CartModel, DomainError> cartUpdateResult = await _cart.Update(Guid.NewGuid());
			cancellationToken.ThrowIfCancellationRequested();
			if (_ecomContext.ReceivingMethod.IsDelivery() && _cart.HasAnyAdultProducts)
			{
				await _cart.ClearAllAdultProducts();
			}
			cancellationToken.ThrowIfCancellationRequested();
			if (cartUpdateResult.TryGetError(out DomainError error))
			{
				(ErrorTitle, ErrorMessage) = _errorTranslator.Translate(error);
				SetErrorState(() => UpdateCartState(forCheckout: false, default(CancellationToken)));
				TabBarVisible = true;
				AppAnalytics.AppMetrica.TrackEvent("cartScreenNiEventError", ("errorId", error.GetType().Name + ": " + (error.Message ?? string.Empty)));
				return cartUpdateResult;
			}
			SharedCartParameter sharedCartParameter = _activationParametersStore.Value.PopFor<SharedCartParameter>(GetType());
			if (sharedCartParameter != null)
			{
				DoShowSharedCartAsync(sharedCartParameter.Token, sharedCartParameter.Model).SafeFireAndForget((Action<Exception>)null, false);
			}
			else if (IsAdultInCart && _ecomContext.AgeGateAgreement != AgreeState.Yes)
			{
				cancellationToken.ThrowIfCancellationRequested();
				if (false)
				{
					TaskAwaiter taskAwaiter2;
					TaskAwaiter taskAwaiter = taskAwaiter2;
					taskAwaiter.GetResult();
				}
				cancellationToken.ThrowIfCancellationRequested();
				if (await _ageGateDialog.Value.ShowAgeGateDialogAsync(cancellationToken) != AgreeState.Yes)
				{
					_bottomNavigationRemoteControl.Value.ActivatePreviousTabCommand.Trigger();
					return cartUpdateResult;
				}
			}
			cancellationToken.ThrowIfCancellationRequested();
			if (cartUpdateResult.Value.Items.Count == 0 && cartUpdateResult.Value.ItemsUnavailable.Count == 0)
			{
				TabBarVisible = true;
				return cartUpdateResult;
			}
			UpdatePropertiesFromCartModel(cartUpdateResult.Value);
			UpdateWarningMessage();
			UpdateReceiveMethodProgress();
			RaisePropertyChanged("ReceiveMethodProgress");
			TabBarVisible = !forCheckout;
			return cartUpdateResult;
		}
		catch (OperationCanceledException)
		{
			return new CancellationError();
		}
	}

	private void OnSilentCartUpdateCompleted(SilentCartUpdateCompletedEventArgs e)
	{
		UpdatePropertiesFromCartModel(e.Cart);
	}

	private void UpdatePropertiesFromCartModel(CartModel cartModel)
	{
		CartModel = cartModel;
		ItemCount = _cart.TotalItemsQty;
		IsFreeDelivery = cartModel.DeliveryTotalPrice == 0m;
		List<DiscountItemViewModel> list = new List<DiscountItemViewModel>();
		list.AddRange(cartModel.Discounts.Select((CartDiscount d) => new DiscountItemViewModel("• Акция", $"-{d.Value:C2}")));
		DiscountItems = new _003C_003Ez__ReadOnlyList<DiscountItemViewModel>(list);
		UpdateReceiveMethodProgress();
	}

	private void OnAvailableItemsChanged(AvailableItemsChangedEventArgs args)
	{
		GoodsSelected = args.Available.Count((ProductOffer i) => i.IsSelected);
		GoodsTotal = args.Available.Count();
	}

	private async Task DoShowSharedCartAsync(string cartToken, SharedCartModel sharedCartModel)
	{
		YieldAwaitable.YieldAwaiter awaiter = Task.Yield().GetAwaiter();
		bool isCompleted = awaiter.IsCompleted;
		await awaiter;
		YieldAwaitable.YieldAwaiter yieldAwaiter = default(YieldAwaitable.YieldAwaiter);
		awaiter = yieldAwaiter;
		awaiter.GetResult();
		SharedCartViewModel.Parameter parameter = new SharedCartViewModel.Parameter
		{
			Model = sharedCartModel
		};
		ShowSharedCartCommand.Trigger(_dataBroker.Push(parameter));
		SharedCartViewModel.Result result = await parameter.WaitForResultAsync();
		switch (result.Type)
		{
		case SharedCartViewModel.ResultType.ShowProduct:
			NavigateToProductDetailsCommand.Trigger(new ProductDetailsViewModel.Parameter(result.Product.Code));
			break;
		case SharedCartViewModel.ResultType.AddToCart:
		{
			if (_ecomContext.ReceivingMethod == ReceivingMethod.RegionDefault)
			{
				await _currentStoreSelectDialog.Value.ShowSelectAddressDialog(new AddressViewModel.Parameter());
				if (_ecomContext.ReceivingMethod != ReceivingMethod.RegionDefault)
				{
					await _cart.WaitForCartUpdateCompletion();
				}
			}
			else if (_ecomContext.ReceivingMethod.IsDelivery() && sharedCartModel.IsAdult && await _currentStoreSelectDialog.Value.ShowAskDeliveryTypeDialogAsync(ReceivingMethod.Pickup) == AgreeState.Yes)
			{
				await _currentStoreSelectDialog.Value.ShowSelectAddressDialog(new AddressViewModel.Parameter
				{
					ReceivingMethod = ReceivingMethod.Pickup
				});
				Task task = _cart.WaitForCartUpdateCompletion();
				Task<Result<SharedCartModel, DomainError>> gsc = _remoteCartService.GetSharedCart(cartToken);
				await Task.WhenAll(task, gsc);
				if (gsc.Result.TryGetValue(out SharedCartModel value))
				{
					sharedCartModel = value;
				}
			}
			bool addAdultGoodsToCart = _ecomContext.ReceivingMethod.IsPickupOrAuto();
			using (BeginRequest())
			{
				if ((await _cart.AddSharedCartAsync(sharedCartModel, addAdultGoodsToCart)).TryGetError(out var error))
				{
					string text = (error as CartNotChanged)?.Message;
					_infoMessageService.Value.ShowSnackbar(text ?? "Что-то пошло не так.\nПовторите попытку позже.");
					Task.Run(delegate
					{
						_appMetrica.Value.AddSharedCartItems(goodsAdded: false, cartToken);
					}).SafeFireAndForget((Action<Exception>)null, false);
					break;
				}
				Task.Run(delegate
				{
					_appMetrica.Value.AddSharedCartItems(goodsAdded: true, cartToken);
				}).SafeFireAndForget((Action<Exception>)null, false);
				_scrollToTopOnUpdate = true;
				if (!addAdultGoodsToCart && sharedCartModel.IsAdult)
				{
					_infoMessageService.Value.ShowSnackbar("Не удалось добавить товары категории 18+");
				}
				break;
			}
		}
		default:
			throw new NotImplementedException("dead code");
		case SharedCartViewModel.ResultType.Cancel:
			break;
		}
	}

	private async Task UpdateFavoritesAvailability()
	{
		YieldAwaitable.YieldAwaiter awaiter = Task.Yield().GetAwaiter();
		_ = awaiter.IsCompleted;
		await awaiter;
		YieldAwaitable.YieldAwaiter yieldAwaiter = default(YieldAwaitable.YieldAwaiter);
		awaiter = yieldAwaiter;
		awaiter.GetResult();
		IsFavoritesAvailable = false;
		IsFavoritesAvailable = (await _favorites.GetFavoritesFromApi())?.Any() ?? false;
		if (IsFavoritesAvailable && base.AutoLayout.Elements.Any((AutoLayoutViewModel.AutoLayoutElement e) => e.Type == "CartEmptyContent"))
		{
			Task.Run(delegate
			{
				AppAnalytics.Ecom.TrackEmptyCartFavoritesShown();
			}).SafeFireAndForget((Action<Exception>)null, false);
		}
	}

	private async Task UpdateLastCompletedOrder()
	{
		YieldAwaitable.YieldAwaiter awaiter = Task.Yield().GetAwaiter();
		_ = awaiter.IsCompleted;
		await awaiter;
		YieldAwaitable.YieldAwaiter yieldAwaiter = default(YieldAwaitable.YieldAwaiter);
		awaiter = yieldAwaiter;
		awaiter.GetResult();
		LastCompletedOrder = null;
		Result<IReadOnlyList<OrderListModel>, DomainError> result = await Task.Run(() => _ordersRepository.GetFirstPage());
		if (result.IsSuccess && (result.Value?.Any() ?? false))
		{
			LastCompletedOrder = (from i in result.Value
				orderby i.CreatedAt descending
				where i.Status == CustomerStatus.Completed || i.Status == CustomerStatus.Delivered
				select i).FirstOrDefault();
		}
		if (LastCompletedOrder != null && base.AutoLayout.Elements.Any((AutoLayoutViewModel.AutoLayoutElement e) => e.Type == "CartEmptyContent"))
		{
			Task.Run(delegate
			{
				AppAnalytics.Ecom.TrackEmptyCartRepeatLastOrderShown();
			}).SafeFireAndForget((Action<Exception>)null, false);
		}
	}

	private async Task RemoveSelectedGoods()
	{
		using (BeginRequest())
		{
			await _cart.WaitForPendingChangesAsync();
			ImmutableList<ProductOffer> products = _cart.Items.Where((ProductOffer i) => i.IsSelected).ToImmutableList();
			_cart.RemoveItems(products, Guid.NewGuid());
			_cart.FlushPendingChanges();
			if ((await _cart.WaitForPendingChangesAsync()).IsFailure)
			{
				SetErrorState(() => UpdateCartState(forCheckout: false, default(CancellationToken)));
			}
			else
			{
				_scrollToTopOnUpdate = true;
			}
		}
	}

	private async Task ClearCart()
	{
		using (BeginRequest())
		{
			if ((await _cart.Clear(Guid.NewGuid())).IsFailure)
			{
				SetErrorState(() => UpdateCartState(forCheckout: false, default(CancellationToken)));
			}
			else
			{
				_scrollToTopOnUpdate = true;
			}
		}
	}

	private async Task ShowReplacementFor(CartItemUnavailableViewModel item)
	{
		string gimaId = item.ProductOffer.GimaId;
		using (BeginRequest())
		{
			Result<(IAlgorithm, IReadOnlyList<ProductWithAnalyticsInfo>), DomainError> result = await _recommendationRepository.GetFirstAvailableAsync(new global::_003C_003Ez__ReadOnlyArray<IAlgorithm>(new IAlgorithm[2]
			{
				AnalogsOutOfStockProductsAlgorithm.Create(_resolver, new AnalogsOutOfStockProductsArgument
				{
					ProductIds = new global::_003C_003Ez__ReadOnlySingleElementList<string>(gimaId),
					BlockId = "analogs",
					Title = "Замена товара"
				}),
				AlternativesAlgorithm.Create(_resolver, new AlternativesArgument
				{
					ProductIds = new global::_003C_003Ez__ReadOnlySingleElementList<string>(gimaId),
					BlockId = "alternatives",
					Title = "Замена товара"
				})
			}));
			if (result.TryGetError(out var _))
			{
				_infoMessageService.Value.ShowSnackbar("Что-то пошло не так. Повторите попытку позже.");
			}
			if (result.TryGetValue(out var value))
			{
				IReadOnlyList<ProductWithAnalyticsInfo> item2 = value.Item2;
				if (item2.Count == 0)
				{
					_infoMessageService.Value.ShowSnackbar("Не удалось подобрать товары.");
					return;
				}
				NavigateToStaticProductListCommand.Trigger(_dataBroker.Push(new StaticProductListViewModel.Parameter
				{
					Title = "Замена товара",
					Items = item2
				}));
			}
		}
	}

	private void ShowLoyaltyRules()
	{
		OnLoyaltyPolicyCommand.Trigger(new InfoPageViewModel.Parameter(InfoType.LoyaltyPolicy));
	}

	private async Task ShowChangeInLoyaltyRegion()
	{
		Result<Cities, DomainError> result = await _storeService.Cities();
		if (result.IsFailure)
		{
			AppAnalytics.AppMetrica.TrackEvent("cartScreenNiEventError", ("errorId", result.Error.GetType().Name + ": " + (result.Error.Message ?? string.Empty)));
			return;
		}
		City city = result.Value.FirstOrDefault((City region) => region.FiasId == _ecomContext.ActiveStore.City.FiasId);
		if (city == null)
		{
			AppAnalytics.AppMetrica.TrackEvent("cartScreenNiEventError", ("errorId", "Active store region not found"));
		}
		else
		{
			IsInLoyalty = city.IsInLoyalty;
		}
	}

	private Task LoadRecommendations()
	{
		_updateRecomsOnResume = false;
		IReadOnlyList<string> readOnlyList = GetGimaIds(_cart.Items);
		IReadOnlyList<string> readOnlyList2 = GetGimaIds(_cart.ItemsUnavailable);
		LoadRequest loadRequest;
		if (_cart.IsEmpty)
		{
			loadRequest = _recommendationBuilderFactory().AddAnyProductPlacement("Специальное предложение", PlacementId.EmptyCart, "empty_cart_pp_specials").AddPersonalOrdered("Уже покупали", "empty_cart_personal_ordered").AddPersonal("Вам может понравиться", "cart_empty_screen")
				.ShowShevronButton(show: false)
				.Build();
		}
		else
		{
			RecommendationBuilder recommendationBuilder = _recommendationBuilderFactory();
			IReadOnlyList<string> readOnlyList3 = readOnlyList2;
			int num = 0;
			string[] array = new string[readOnlyList.Count + readOnlyList3.Count];
			foreach (string item in readOnlyList)
			{
				array[num] = item;
				num++;
			}
			foreach (string item2 in readOnlyList3)
			{
				array[num] = item2;
				num++;
			}
			loadRequest = recommendationBuilder.AddProductGroupPlacements("Специальное предложение", PlacementId.Cart, new global::_003C_003Ez__ReadOnlyArray<string>(array), "cart_pp_specials").AddPersonalOrdered("Уже покупали", "full_cart_personal_ordered").AddRelatedWithPopularityPenalty("Добавить к заказу", "cart_related", new global::_003C_003Ez__ReadOnlyArray<string>(readOnlyList.ToArray()))
				.Build();
		}
		LoadRequest request = loadRequest;
		LoadRequest endlessRequest = (_cart.IsEmpty ? _recommendationBuilderFactory().AddPersonalViewedEndless("Вы смотрели", "empty_cart_personal_viewed").Build() : _recommendationBuilderFactory().AddPersonalViewedEndless("Вы смотрели", "recently_viewed_cart").Build());
		return _loadRecommendationsQueue.Enqueue(async delegate
		{
			await Recommendations.Load(request);
			await EndlessRecommendations.Load(endlessRequest);
		});
		static IReadOnlyList<string> GetGimaIds(IReadOnlyList<ProductOffer> from)
		{
			List<string> list = new List<string>();
			list.AddRange(from i in @from
				let id = i.GimaId
				where !string.IsNullOrEmpty(id)
				select id);
			return new _003C_003Ez__ReadOnlyList<string>(list);
		}
	}

	private void OnRecommendationSectionsChanged(IReadOnlyCollection<SectionItemViewModel> sections, BlockOrder order, ICollection<IDisposable> disposables)
	{
		disposables.ForEach(delegate(IDisposable d)
		{
			d.Dispose();
		});
		disposables.Clear();
		if (sections.Count > 0)
		{
			HandleCollectionChange();
			return;
		}
		base.AutoLayout.Elements.RemoveAll((AutoLayoutViewModel.AutoLayoutElement e) => e.Type == "RecommendationHorizontalBlock" && e.Order == (int)order && sections.Select((SectionItemViewModel s) => s.Id).Contains(e.Tag));
		void HandleCollectionChange()
		{
			ImmutableArray<AutoLayoutViewModel.AutoLayoutElement> immutableArray = base.AutoLayout.Elements.Where((AutoLayoutViewModel.AutoLayoutElement e) => e.Type == "RecommendationHorizontalBlock" && e.Order == (int)order).ToImmutableArray();
			IEnumerable<AutoLayoutViewModel.AutoLayoutElement> enumerable = from s in sections
				where s.Preview.Count > 0
				select AutoLayoutViewModel.AutoLayoutElement.New("RecommendationHorizontalBlock", s, order, s.Id);
			if (enumerable.Any())
			{
				if (immutableArray.Any())
				{
					base.AutoLayout.Elements.ReplaceRange(base.AutoLayout.Elements.IndexOf(immutableArray.First()), immutableArray.Count(), enumerable);
				}
				else
				{
					base.AutoLayout.InsertRange(enumerable);
				}
			}
			else if (immutableArray.Any())
			{
				base.AutoLayout.Elements.RemoveRange(immutableArray);
			}
		}
	}

	public void OnRecommendationsViewed(SectionItemViewModel section)
	{
		Recommendations.Viewed(section);
	}

	public void OnEndlessRecommendationsViewed()
	{
		if (!_recommendationsViewed)
		{
			_recommendationsViewed = true;
			EndlessRecommendations.Viewed();
		}
	}

	private static Task DoNothing()
	{
		return Task.CompletedTask;
	}

	private void SetErrorState(Func<Task> retryAction)
	{
		IsInErrorState = true;
		_retryAction = retryAction;
	}

	public void SetNeedUpdateRecoms()
	{
		_updateRecomsOnResume = true;
		_scrollToTopOnUpdate = true;
		ScrollToTopCommand.Trigger();
		base.AutoLayout.Elements.RemoveAll((AutoLayoutViewModel.AutoLayoutElement e) => e.Type == "RecommendationHorizontalBlock");
		EndlessRecommendations.ClearItems();
	}

	private void OnStateChanged()
	{
		CloseHighlightReceiveMethodsCommand.Trigger();
	}

	private Task OnLogout()
	{
		Dispose();
		return Task.CompletedTask;
	}

	private async Task OnAddToOrderCommand(CartPreviousOrderItemViewModel ivm, CancellationToken cancellationToken = default(CancellationToken))
	{
		YieldAwaitable.YieldAwaiter awaiter = Task.Yield().GetAwaiter();
		_ = awaiter.IsCompleted;
		await awaiter;
		YieldAwaitable.YieldAwaiter yieldAwaiter = default(YieldAwaitable.YieldAwaiter);
		awaiter = yieldAwaiter;
		awaiter.GetResult();
		_appMetrica.Value.TrackAddToPreviousOrderTap();
		Result<AddProductsToOrderPopupViewModel.Parameter, DomainError> result = await InvokeRequest(() => _ordersRepository.CheckAdditionItemsAsync(ivm.OrderId, _cart.Items.Where((ProductOffer i) => !i.ContainsModifications && i.IsSelected).ToImmutableList(), cancellationToken));
		DomainError error2;
		if (result.TryGetValue(out var vmParam))
		{
			ShowAddProductsToOrderPopupCommand.Trigger(_dataBroker.Push(vmParam));
			if (!(await vmParam.TaskCompletionSource.Task))
			{
				return;
			}
			_appMetrica.Value.TrackConfirmAddToPreviousOrderTap(vmParam);
			Result<SuccessAdditionalOrderPopupViewModel.Parameter, DomainError> result2 = await InvokeRequest(() => _ordersRepository.AddGoodsToOrderAsync(ivm.OrderId, vmParam.AvailableItems, cancellationToken));
			DomainError error;
			if (result2.TryGetValue(out var goods))
			{
				ShowSuccessAdditionalOrderPopupCommand.Trigger(_dataBroker.Push(goods));
				switch (await goods.TaskCompletionSource.Task)
				{
				case SuccessAdditionalOrderPopupViewModel.ModelResult.Unknown:
					UpdateStoreAsync(_firstStart, base.NavigationToken.GetValueOrDefault()).SafeFireAndForget((Action<Exception>)null, false);
					break;
				case SuccessAdditionalOrderPopupViewModel.ModelResult.GotoHome:
					await _universalLinksService.Value.HandleLink("auchan://home?activate_tab=Home");
					break;
				case SuccessAdditionalOrderPopupViewModel.ModelResult.GotoOrder:
				{
					if ((await InvokeRequest(() => _ordersRepository.GetOrderAsync(goods.Model.Id))).TryGetValue(out var value))
					{
						OrderDetailsViewModel.Parameter parameter = await _orderDetailsParameterFactory.Value.CreateAsync(value);
						if (parameter != null)
						{
							ShowOrderDetailCommand.Trigger(parameter);
						}
					}
					break;
				}
				}
			}
			else if (result2.TryGetError(out error))
			{
				ProcessAddToOrderError(error);
			}
		}
		else if (result.TryGetError(out error2))
		{
			ProcessAddToOrderError(error2);
		}
	}

	private void ProcessAddToOrderError(DomainError error)
	{
		if (error is OrderAdditionError orderAdditionError && !string.IsNullOrEmpty(orderAdditionError.Message) && !string.IsNullOrEmpty(orderAdditionError.Details))
		{
			ShowAddToOrderFailedCommand.Trigger(new AddToOrderFailedViewModel.Parameter
			{
				Title = orderAdditionError.Message,
				Description = orderAdditionError.Details
			});
		}
		else
		{
			_infoMessageService.Value.ShowSnackbar("Произошла ошибка. Пожалуйста, повторите попытку позже.");
		}
		UpdateStoreAsync(_firstStart, base.NavigationToken.GetValueOrDefault()).SafeFireAndForget((Action<Exception>)null, false);
	}

	private async Task OnToggleAllGoodsSelectionCommand()
	{
		bool allItemsSelected = !IsAllGoodsSelected;
		if (!(await _cart.SetAllItemsSelected(allItemsSelected)))
		{
			_infoMessageService.Value.ShowSnackbar("Что-то пошло не так. Повторите попытку позже.");
		}
	}

	public IDisposable BeginRequest()
	{
		IsInProgress = Interlocked.Increment(ref _requestCounter) > 0;
		return Disposable.Create(delegate
		{
			IsInProgress = Interlocked.Decrement(ref _requestCounter) > 0;
		});
	}

	public async Task<T> InvokeRequest<T>(Func<Task<T>> getResult)
	{
		using (BeginRequest())
		{
			return await getResult();
		}
	}
}
