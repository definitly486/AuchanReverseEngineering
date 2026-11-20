using System;
using System.Linq;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using AsyncAwaitBestPractices;
using Auchan.Common.AdminTool;
using Auchan.Common.Analytics;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Common;
using Auchan.Common.Common.Binding;
using Auchan.Common.Ecom;
using Auchan.Common.Ecom.Cart;
using Auchan.Common.Ecom.Cart.Models;
using Auchan.Common.Ecom.Search.Infrastructure;
using Auchan.Common.Extensions;
using Auchan.Common.LoyaltyProgram;
using Auchan.Common.LoyaltyProgram.Coupons.Infrastructure;
using Auchan.Common.Managers.Dialogs;
using Auchan.Common.Navigation;
using Auchan.Common.Notifications;
using Auchan.Common.PersonalCabinet.Authorization.Managers;
using Auchan.Common.Profile.WaitList;
using Auchan.Common.SupportChat;
using CSharpFunctionalExtensions;
using EBind;
using Microsoft.Maui.ApplicationModel;

namespace Auchan.Common.Base;

public class BottomNavigationViewModel : ScreenViewModel
{
	public enum TabbarItem
	{
		Home,
		Catalog,
		Cart,
		Loyalty,
		Profile
	}

	public sealed class RemoteControl : IRemoteControl
	{
		public UICommand ActivatePreviousTabCommand { get; } = new UICommand();
	}

	public interface IRemoteControl
	{
		UICommand ActivatePreviousTabCommand { get; }
	}

	private readonly Cart _cart;

	private readonly Lazy<INavigationService> _navigationService;

	private readonly Lazy<ILoginManager> _loginManager;

	private readonly Lazy<IAdminContext> _adminContext;

	private readonly Lazy<IEcomContext> _ecomContext;

	private readonly Lazy<IAgeGateDialog> _ageGateDialog;

	private readonly Lazy<SearchProductsManager> _searchManager;

	private readonly SupportChatMessageManager _supportChatMessageManager;

	private readonly WaitListProducts _waitListProducts;

	private readonly CouponsRepository _couponsRepository;

	private readonly NotificationsCounterService _notificationsCounterService;

	private readonly Subject<Unit> _showProfile = new Subject<Unit>();

	private int _unreadMessageCount;

	private int _productsCountInWaitList;

	private int _notificationsCount;

	private int _cartUpdateLock;

	private bool _cartUpdateCompleted;

	private TabbarItem _previousTab;

	private TabbarItem _nextTab;

	[CompilerGenerated]
	private int _003CBasketItemCount_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CBasketSum_003Ek__BackingField;

	[CompilerGenerated]
	private int _003COffersItemCount_003Ek__BackingField;

	[CompilerGenerated]
	private UICommand _003CResetSearchStateCommand_003Ek__BackingField;

	[CompilerGenerated]
	private VisualState _003CCartNavigationState_003Ek__BackingField;

	public int BasketItemCount
	{
		[CompilerGenerated]
		get
		{
			return _003CBasketItemCount_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CBasketItemCount_003Ek__BackingField != value)
			{
				_003CBasketItemCount_003Ek__BackingField = value;
				RaisePropertyChanged("BasketItemCount");
			}
		}
	}

	public string BasketSum
	{
		[CompilerGenerated]
		get
		{
			return _003CBasketSum_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CBasketSum_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CBasketSum_003Ek__BackingField = value;
				RaisePropertyChanged("BasketSum");
			}
		}
	} = string.Empty;

	public int OffersItemCount
	{
		[CompilerGenerated]
		get
		{
			return _003COffersItemCount_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003COffersItemCount_003Ek__BackingField != value)
			{
				_003COffersItemCount_003Ek__BackingField = value;
				RaisePropertyChanged("OffersItemCount");
			}
		}
	}

	public IObservable<Unit> ShowSProfileCommand => _showProfile.Debounce();

	private int UnreadMessagesCount
	{
		get
		{
			return _unreadMessageCount;
		}
		set
		{
			if (_unreadMessageCount != value)
			{
				_unreadMessageCount = value;
				RaisePropertyChanged("UnreadMessagesCount");
				RaisePropertyChanged("CommonCounter");
			}
		}
	}

	private int ProductsCountInWaitList
	{
		get
		{
			return _productsCountInWaitList;
		}
		set
		{
			if (_productsCountInWaitList != value)
			{
				_productsCountInWaitList = value;
				RaisePropertyChanged("ProductsCountInWaitList");
				RaisePropertyChanged("CommonCounter");
			}
		}
	}

	public int NotificationsCount
	{
		get
		{
			return _notificationsCount;
		}
		private set
		{
			if (_notificationsCount != value)
			{
				_notificationsCount = value;
				RaisePropertyChanged("NotificationsCount");
				RaisePropertyChanged("CommonCounter");
			}
		}
	}

	public int CommonCounter => UnreadMessagesCount + ProductsCountInWaitList + NotificationsCount;

	private UICommand ResetSearchStateCommand
	{
		[CompilerGenerated]
		get
		{
			return _003CResetSearchStateCommand_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!object.Equals(_003CResetSearchStateCommand_003Ek__BackingField, value))
			{
				_003CResetSearchStateCommand_003Ek__BackingField = value;
				RaisePropertyChanged("ResetSearchStateCommand");
			}
		}
	} = new UICommand();

	public UICommand<TabbarItem> ActivateTabCommand { get; } = new UICommand<TabbarItem>();

	public VisualState CartNavigationState
	{
		[CompilerGenerated]
		get
		{
			return _003CCartNavigationState_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CCartNavigationState_003Ek__BackingField != value)
			{
				_003CCartNavigationState_003Ek__BackingField = value;
				RaisePropertyChanged("CartNavigationState");
			}
		}
	}

	private UICommand<TabbarItem> SendAnalyticsOnClickedCommand { get; } = new UICommand<TabbarItem>();

	public BottomNavigationViewModel(Cart cart, Lazy<INavigationService> navigationService, Lazy<ILoyaltyTriggersManager> loyaltyTriggersManager, Lazy<ILoginManager> loginManager, Lazy<IAdminContext> adminContext, Lazy<IEcomContext> ecomContext, Lazy<IAgeGateDialog> ageGateDialog, Lazy<SearchProductsManager> searchManager, SupportChatMessageManager supportChatMessageManager, WaitListProducts waitListProducts, CouponsRepository couponsRepository, NotificationsCounterService notificationsCounterService, IRemoteControl remoteControl)
	{
		_cart = cart;
		_navigationService = navigationService;
		_loginManager = loginManager;
		_adminContext = adminContext;
		_ecomContext = ecomContext;
		_ageGateDialog = ageGateDialog;
		_searchManager = searchManager;
		_supportChatMessageManager = supportChatMessageManager;
		_waitListProducts = waitListProducts;
		_couponsRepository = couponsRepository;
		_notificationsCounterService = notificationsCounterService;
		_notificationsCounterService.Count.Subscribe(delegate(int c)
		{
			MainThread.BeginInvokeOnMainThread(delegate
			{
				NotificationsCount = c;
			});
		}).AddTo(base.CloseDisposable);
		((IObservable<Unit>)ResetSearchStateCommand).PerformDebouncingTask((Func<Unit, Task>)async delegate
		{
			await Task.Delay(100);
			_searchManager.Value.ResetSearchState();
		}, (IScheduler?)null).Subscribe().AddTo(base.CloseDisposable);
		_supportChatMessageManager.OnUnreadMessagesCountChanged += new DisposableDelegate<EventHandler<int>>(delegate(object? o, int e)
		{
			MainThread.BeginInvokeOnMainThread(delegate
			{
				UnreadMessagesCount = e;
			});
		}, delegate(EventHandler<int> eh)
		{
			_supportChatMessageManager.OnUnreadMessagesCountChanged -= eh;
		}).AddTo(base.CloseDisposable);
		_waitListProducts.OnProductsCountInWaitListChanged += new DisposableDelegate<EventHandler<int>>(delegate(object? o, int e)
		{
			MainThread.BeginInvokeOnMainThread(delegate
			{
				ProductsCountInWaitList = e;
			});
		}, delegate(EventHandler<int> eh)
		{
			_waitListProducts.OnProductsCountInWaitListChanged -= eh;
		}).AddTo(base.CloseDisposable);
		_adminContext.Value.PersonalOffersChanged.StartWith(_adminContext.Value.PersonalOffers).Subscribe(delegate
		{
			OffersItemCount = _adminContext.Value.CountOfNewPersonalOffers + _couponsRepository.NewCouponsCount;
		}).AddTo(base.CloseDisposable);
		_couponsRepository.CouponsChanged += new DisposableDelegate<EventHandler<int>>(delegate(object? _, int newCount)
		{
			OffersItemCount = _adminContext.Value.CountOfNewPersonalOffers + newCount;
		}, delegate(EventHandler<int> d)
		{
			_couponsRepository.CouponsChanged -= d;
		}).AddTo(base.CloseDisposable);
		UpdateCartProperties(new AvailableItemsChangedEventArgs
		{
			Available = _cart.Items,
			IsHavePendingChanges = false
		});
		_cart.OnAvailableItemsChanged(delegate(object? o, AvailableItemsChangedEventArgs e)
		{
			UpdateCartProperties(e);
		}).AddTo(base.CloseDisposable);
		remoteControl.ActivatePreviousTabCommand.Subscribe(delegate
		{
			ActivateTabCommand.Trigger(_previousTab);
		}).AddTo(base.CloseDisposable);
		SendAnalyticsOnClickedCommand.Subscribe(SendAnalyticsOnClicked).AddTo(base.CloseDisposable);
	}

	protected override async Task Start()
	{
		await base.Start();
		UpdateCommonCounter().SafeFireAndForget((Action<Exception>)null, false);
		_couponsRepository.GetCoupons().SafeFireAndForget((Action<Exception>)null, false);
		_adminContext.Value.GetPersonalOffers().SafeFireAndForget((Action<Exception>)null, false);
		_notificationsCounterService.RefreshInBackground();
		await _cart.Update(Guid.NewGuid());
	}

	protected override async Task OnResumed()
	{
		await base.OnResumed();
		UpdateCommonCounter().SafeFireAndForget((Action<Exception>)null, false);
		SetReadyForNavigation();
	}

	public bool ShouldActivateTab(TabbarItem from, TabbarItem to)
	{
		SendAnalyticsOnClickedCommand.Trigger(to);
		if (to == TabbarItem.Cart)
		{
			_nextTab = TabbarItem.Cart;
		}
		if (to == TabbarItem.Cart && _ecomContext.Value.AgeGateAgreement != AgreeState.Yes && !_cartUpdateCompleted && from != TabbarItem.Cart)
		{
			UpdateCartAndShowAgeGateIfNeed().SafeFireAndForget((Action<Exception>)null, false);
			return false;
		}
		_cartUpdateCompleted = false;
		return true;
	}

	public void OnClicked(TabbarItem from, TabbarItem to)
	{
		if (from != to)
		{
			_previousTab = from;
		}
		_nextTab = to;
		ResetSearchStateCommand.Trigger();
	}

	private async Task UpdateCartAndShowAgeGateIfNeed()
	{
		int num = Interlocked.Increment(ref _cartUpdateLock);
		using (Disposable.Create(delegate
		{
			Interlocked.Decrement(ref _cartUpdateLock);
		}))
		{
			if (num != 1)
			{
				return;
			}
			CartNavigationState = VisualState.InProgress;
			if (_cart.IsSyncInProgress)
			{
				await _cart.WaitForCartUpdateCompletion();
			}
			if (_nextTab != TabbarItem.Cart)
			{
				_cartUpdateCompleted = false;
				CartNavigationState = VisualState.Error;
				return;
			}
			if (_cart.HasAnyAdultProducts)
			{
				if (await _ageGateDialog.Value.ShowAgeGateDialogAsync() == AgreeState.Yes && _nextTab == TabbarItem.Cart)
				{
					CartNavigationState = VisualState.Default;
					ResetSearchStateCommand.Trigger();
					ActivateTabCommand.Trigger(TabbarItem.Cart);
				}
				else
				{
					CartNavigationState = VisualState.Error;
				}
				return;
			}
			if (_nextTab == TabbarItem.Cart)
			{
				_cartUpdateCompleted = true;
				ResetSearchStateCommand.Trigger();
				ActivateTabCommand.Trigger(TabbarItem.Cart);
			}
			CartNavigationState = VisualState.Default;
		}
	}

	private void SetReadyForNavigation()
	{
		if (false)
		{
		}
		if (_loginManager.Value.ShouldNavigateToProfile)
		{
			_showProfile.OnNext(Unit.Default);
		}
	}

	private async Task UpdateCommonCounter()
	{
		YieldAwaitable.YieldAwaiter awaiter = Task.Yield().GetAwaiter();
		_ = awaiter.IsCompleted;
		await awaiter;
		YieldAwaitable.YieldAwaiter yieldAwaiter = default(YieldAwaitable.YieldAwaiter);
		awaiter = yieldAwaiter;
		awaiter.GetResult();
		Result<int, DomainError> result = await Task.Run(() => _supportChatMessageManager.GetUnreadMessageCount());
		_unreadMessageCount = (result.IsSuccess ? result.Value : 0);
		_productsCountInWaitList = _waitListProducts.ProductsCountInWaitList;
		RaisePropertyChanged("CommonCounter");
	}

	private void SendAnalyticsOnClicked(TabbarItem item)
	{
		switch (item)
		{
		case TabbarItem.Home:
			AppAnalytics.AppMetrica.TrackEvent("TapTabbarMain");
			break;
		case TabbarItem.Catalog:
			AppAnalytics.AppMetrica.TrackEvent("TapTabbarCatalog");
			break;
		case TabbarItem.Cart:
			AppAnalytics.AppMetrica.TrackEvent("TapTabbarCart");
			break;
		case TabbarItem.Loyalty:
			AppAnalytics.AppMetrica.TrackEvent("TapTabbarLoyalty");
			break;
		case TabbarItem.Profile:
			AppAnalytics.AppMetrica.TrackEvent("TapTabbarProfile");
			break;
		}
	}

	private void UpdateCartProperties(AvailableItemsChangedEventArgs args)
	{
		BasketSum = ((args.Available.Count == 0) ? "Корзина" : args.Available.Sum((ProductOffer i) => i.GetSubTotal(!args.IsHavePendingChanges)).ToString("C2"));
		BasketItemCount = _cart.TotalItemsQty;
	}
}
