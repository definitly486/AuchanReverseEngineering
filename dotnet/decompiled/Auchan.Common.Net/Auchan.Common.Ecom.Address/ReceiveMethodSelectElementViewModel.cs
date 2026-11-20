using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Auchan.Common.Analytics;
using Auchan.Common.Base;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Common;
using Auchan.Common.Common.Binding;
using Auchan.Common.Ecom.Address.DTO;
using Auchan.Common.Ecom.AddressStoreSelection;
using Auchan.Common.Ecom.Cart;
using Auchan.Common.Ecom.Cart.ViewModels;
using Auchan.Common.Ecom.Products.ViewModels;
using Auchan.Common.Extensions;
using Auchan.Common.Helpers;
using Auchan.Common.Home;
using Auchan.Common.Navigation;
using CSharpFunctionalExtensions;
using EBind;

namespace Auchan.Common.Ecom.Address;

public class ReceiveMethodSelectElementViewModel : ElementViewModel
{
	public enum VisualState
	{
		Default,
		Empty
	}

	public enum GlobalVisualState
	{
		Default,
		InProgress
	}

	public class ReceiveMethodSelectElementItemViewModel
	{
		public string Title { get; }

		public string Description { get; }

		public ReceivingMethod ReceiveMethod { get; }

		public bool IsAvailable { get; }

		public bool IconVisible { get; }

		public ReceiveMethodSelectElementItemViewModel(string title, string description, ReceivingMethod receiveMethod, bool isAvailable)
		{
			Title = title;
			Description = description;
			ReceiveMethod = receiveMethod;
			IsAvailable = isAvailable;
			IconVisible = receiveMethod == ReceivingMethod.ExpressDelivery;
		}
	}

	private readonly TaskQueue _loadReceiveMethodsQueue = new TaskQueue();

	private readonly Lazy<IEcomContext> _ecomContext;

	private readonly Lazy<StoreRepository> _storeRepository;

	private readonly Lazy<Auchan.Common.Ecom.Cart.Cart> _cart;

	private readonly Lazy<IDataBroker> _dataBroker;

	private readonly Lazy<INavigationContext> _navigationContext;

	private bool _receiveMethodUnavailable;

	private bool _receiveMethodsEmpty;

	[CompilerGenerated]
	private VisualState _003CState_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CAddressText_003Ek__BackingField;

	[CompilerGenerated]
	private ReceiveMethodSelectElementItemViewModel? _003CSelectedReceiveMethod_003Ek__BackingField;

	private AddressMapViewModel.NavigatedFrom NavigatedFrom { get; }

	public VisualState State
	{
		[CompilerGenerated]
		get
		{
			return _003CState_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CState_003Ek__BackingField != value)
			{
				_003CState_003Ek__BackingField = value;
				RaisePropertyChanged("IsReceiveMethodSelected");
				RaisePropertyChanged("IsAddressUnavailable");
				RaisePropertyChanged("EmptyText");
				RaisePropertyChanged("EmptyButtonText");
				RaisePropertyChanged("State");
			}
		}
	} = VisualState.Empty;

	private bool IsAddressUnavailable
	{
		get
		{
			if (_ecomContext.Value.SavedStore == null)
			{
				return _ecomContext.Value.ReceivingMethod != ReceivingMethod.RegionDefault;
			}
			return false;
		}
	}

	public string EmptyText
	{
		get
		{
			if (!IsAddressUnavailable && (!_receiveMethodUnavailable || _receiveMethodsEmpty))
			{
				if (!_receiveMethodUnavailable)
				{
					return "Чтобы смотреть актуальные цены,\nукажите адрес доставки или магазин самовывоза";
				}
				return "Чтобы смотреть актуальные цены,\nвыберите способ получения";
			}
			return "Ранее выбранный способ получения заказа временно недоступен. Попробуйте изменить адрес или способ получения.";
		}
	}

	public string EmptyButtonText
	{
		get
		{
			if (!IsAddressUnavailable && !_receiveMethodUnavailable)
			{
				return "Выбрать адрес";
			}
			return "Выбрать способ получения";
		}
	}

	public string AddressText
	{
		[CompilerGenerated]
		get
		{
			return _003CAddressText_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CAddressText_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CAddressText_003Ek__BackingField = value;
				RaisePropertyChanged("AddressText");
			}
		}
	} = string.Empty;

	public bool FavoritesIconVisible => NavigatedFrom == AddressMapViewModel.NavigatedFrom.Home;

	public bool NotificationsIconVisible => NavigatedFrom == AddressMapViewModel.NavigatedFrom.Home;

	public bool IsReceiveMethodSelected => State == VisualState.Default;

	public ObservableRangeCollection<ReceiveMethodSelectElementItemViewModel> ReceiveMethods { get; } = new ObservableRangeCollection<ReceiveMethodSelectElementItemViewModel>();

	public UICommand OpenAddressSelectionDefaultCommand { get; } = new UICommand();

	public UICommand<AddressViewModel.Parameter> OpenAddressSelectionCommand { get; } = new UICommand<AddressViewModel.Parameter>();

	public UICommand<ReceiveMethodSelectElementItemViewModel> SelectReceiveMethodCommand { get; } = new UICommand<ReceiveMethodSelectElementItemViewModel>();

	public UICommand OpenFavoritesCommand { get; } = new UICommand();

	public ReceiveMethodSelectElementItemViewModel? SelectedReceiveMethod
	{
		[CompilerGenerated]
		get
		{
			return _003CSelectedReceiveMethod_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003CSelectedReceiveMethod_003Ek__BackingField, value))
			{
				_003CSelectedReceiveMethod_003Ek__BackingField = value;
				RaisePropertyChanged("SelectedReceiveMethod");
			}
		}
	}

	public UICommand LoadReceiveMethodsCommand { get; } = new UICommand();

	public UICommand UpdateReceiveMethodsCommand { get; } = new UICommand();

	public UICommand<ReceiveMethodSelectElementItemViewModel> ShowReceiveMethodCommand { get; } = new UICommand<ReceiveMethodSelectElementItemViewModel>();

	public UICommand ShowLastReceiveMethodCommand { get; } = new UICommand();

	public UICommand ShowExpressDeliveryHighlightCommand { get; } = new UICommand();

	public static UICommand ReceiveMethodsSelectUpdated { get; } = new UICommand();

	public ReceiveMethodSelectElementViewModel(ScreenViewModel parentViewModel, Lazy<IEcomContext> ecomContext, Lazy<StoreRepository> storeRepository, Lazy<Auchan.Common.Ecom.Cart.Cart> cart, Lazy<IDataBroker> dataBroker, Lazy<INavigationContext> navigationContext)
		: base(parentViewModel)
	{
		_ecomContext = ecomContext;
		_storeRepository = storeRepository;
		_cart = cart;
		_dataBroker = dataBroker;
		_navigationContext = navigationContext;
		NavigatedFrom = ((!(base.ParentViewModel is HomeViewModel)) ? ((base.ParentViewModel is CartScreenViewModel) ? AddressMapViewModel.NavigatedFrom.Cart : ((base.ParentViewModel is CatalogViewModel) ? AddressMapViewModel.NavigatedFrom.Catalog : AddressMapViewModel.NavigatedFrom.Unknown)) : AddressMapViewModel.NavigatedFrom.Home);
		SelectReceiveMethodCommand.Debounce(2000).ObserveOn(MainThread.Scheduler).PerformDebouncingTask(OnMethodSelected)
			.Subscribe()
			.AddTo(base.Disposables);
		OpenAddressSelectionDefaultCommand.ObserveOn(MainThread.Scheduler).PerformDebouncingTask((Func<Unit, Task>)delegate
		{
			AppAnalytics.AppMetrica.TrackAddressBlockClick(_ecomContext.Value.ReceivingMethod, NavigatedFrom);
			OpenAddressSelectionCommand.Trigger(new AddressViewModel.Parameter
			{
				ReceivingMethod = _ecomContext.Value.ReceivingMethod
			});
			return Task.CompletedTask;
		}, (IScheduler?)null).Subscribe()
			.AddTo(base.Disposables);
		LoadReceiveMethodsCommand.Sample(TimeSpan.FromSeconds(1L)).ObserveOn(MainThread.Scheduler).PerformDebouncingTask((Unit _) => LoadReceiveMethods())
			.Subscribe()
			.AddTo(base.Disposables);
		UpdateReceiveMethodsCommand.Sample(TimeSpan.FromSeconds(1L)).ObserveOn(MainThread.Scheduler).PerformDebouncingTask((Unit _) => UpdateReceivingMethod())
			.Subscribe()
			.AddTo(base.Disposables);
	}

	public override async Task Start()
	{
		await base.Start();
		await LoadReceiveMethods();
		_ecomContext.Value.OnPropertyChanges((IEcomContext _) => _ecomContext.Value.ReceivingMethod).Subscribe(delegate
		{
			UpdateReceiveMethodsCommand.Trigger();
		}).AddTo(base.Disposables);
		_ecomContext.Value.OnPropertyChanges((IEcomContext _) => _ecomContext.Value.ActiveStore).Subscribe(delegate
		{
			UpdateReceiveMethodsCommand.Trigger();
		}).AddTo(base.Disposables);
		_ecomContext.Value.AfterAddressSet += new DisposableDelegate<Func<Task>>(delegate
		{
			UpdateReceiveMethodsCommand.Trigger();
			return Task.CompletedTask;
		}, delegate(Func<Task> d)
		{
			_ecomContext.Value.AfterAddressSet -= d;
		}).AddTo(base.Disposables);
	}

	public override async Task OnResumed()
	{
		await base.OnResumed();
		LoadReceiveMethodsCommand.Trigger();
	}

	public void ShowExpressDeliveryHighlightIfNeeded()
	{
		if (GetExpressDeliveryForHighlight() != null)
		{
			ShowExpressDeliveryHighlightCommand.Trigger();
		}
	}

	public BrokerToken? CreateExpressDeliveryHighlight()
	{
		ReceiveMethodSelectElementItemViewModel expressDelivery = GetExpressDeliveryForHighlight();
		if (expressDelivery == null)
		{
			return null;
		}
		ExpressDeliveryHighlightScreenViewModel.Parameter data = new ExpressDeliveryHighlightScreenViewModel.Parameter
		{
			ViewAction = delegate
			{
				SelectReceiveMethodCommand.Trigger(expressDelivery);
			}
		};
		return _dataBroker.Value.Push(data);
	}

	private ReceiveMethodSelectElementItemViewModel? GetExpressDeliveryForHighlight()
	{
		if (_navigationContext.Value.IsNavigatedFromStart || _navigationContext.Value.IsNavigating || _storeRepository.Value.IsExpressDeliveryInformerShown || !IsReceiveMethodSelected)
		{
			return null;
		}
		return ReceiveMethods.FirstOrDefault((ReceiveMethodSelectElementItemViewModel i) => i.ReceiveMethod == ReceivingMethod.ExpressDelivery && i.IsAvailable);
	}

	public Task LoadReceiveMethods()
	{
		return _loadReceiveMethodsQueue.Enqueue(DoAsync);
		async Task DoAsync()
		{
			SetReceiveMethodUnavailable(unavailable: false, empty: false);
			if (_ecomContext.Value.SavedStore == null)
			{
				State = VisualState.Empty;
			}
			else
			{
				Result<ReceiveMethodsResponseDTO, DomainError> result = await _storeRepository.Value.ReceiveMethods();
				if (result.IsFailure)
				{
					State = VisualState.Empty;
					ReceiveMethodsSelectUpdated.Trigger();
				}
				else if (!result.Value.Data.IsReceiveMethodSet)
				{
					SetReceiveMethodUnavailable(unavailable: true, result.Value.Data.ReceiveMethods.IsNullOrEmpty());
					ReceiveMethods.Clear();
					State = VisualState.Empty;
					ReceiveMethodsSelectUpdated.Trigger();
				}
				else if (result.Value.Data.ReceiveMethods.IsNullOrEmpty())
				{
					State = VisualState.Empty;
					ReceiveMethodsSelectUpdated.Trigger();
				}
				else
				{
					ReceiveMethodsResponseReceiveMethodDTO selectedRM = result.Value.Data.ReceiveMethods.FirstOrDefault((ReceiveMethodsResponseReceiveMethodDTO rm) => rm.IsSelectedMethod && rm.IsAvailable);
					if (selectedRM == null)
					{
						State = VisualState.Empty;
						ReceiveMethodsSelectUpdated.Trigger();
					}
					else
					{
						if (selectedRM.ReceiveMethod.IsDelivery())
						{
							AddressText = selectedRM.DeliveryInfo.Address ?? _ecomContext.Value.DeliveryAddress?.AddressLine ?? string.Empty;
						}
						else
						{
							AddressText = StoreNameToAddressText(selectedRM.ReceiveMethod, result.Value.Data.Store.Name);
						}
						IOrderedEnumerable<ReceiveMethodSelectElementItemViewModel> collection = from rm in result.Value.Data.ReceiveMethods
							where rm.ReceiveMethod != ReceivingMethod.Delivery || !string.IsNullOrEmpty(rm.DeliveryInfo.Time)
							select new ReceiveMethodSelectElementItemViewModel(ReceiveMethodToTitle(rm.ReceiveMethod), ReceiveMethodToDescription(rm), rm.ReceiveMethod, rm.IsAvailable) into n
							orderby (n.ReceiveMethod != ReceivingMethod.ExpressDelivery) ? 1 : 0
							select n;
						ReceiveMethods.Clear();
						ReceiveMethods.AddRange(collection);
						SelectedReceiveMethod = ReceiveMethods.FirstOrDefault((ReceiveMethodSelectElementItemViewModel rm) => rm.ReceiveMethod == selectedRM.ReceiveMethod);
						if (SelectedReceiveMethod == null || string.IsNullOrEmpty(AddressText))
						{
							State = VisualState.Empty;
							ReceiveMethodsSelectUpdated.Trigger();
						}
						else
						{
							State = VisualState.Default;
							ShowReceiveMethodCommand.Trigger(SelectedReceiveMethod);
							ReceiveMethodsSelectUpdated.Trigger();
						}
					}
				}
			}
		}
	}

	private void SetReceiveMethodUnavailable(bool unavailable, bool empty)
	{
		if (_receiveMethodUnavailable != unavailable || _receiveMethodsEmpty != empty)
		{
			_receiveMethodUnavailable = unavailable;
			_receiveMethodsEmpty = empty;
			RaisePropertyChanged("EmptyText");
			RaisePropertyChanged("EmptyButtonText");
		}
	}

	private async Task UpdateReceivingMethod()
	{
		if (_ecomContext.Value.ReceivingMethod == ReceivingMethod.RegionDefault)
		{
			State = VisualState.Empty;
			LoadReceiveMethodsCommand.Trigger();
			return;
		}
		if (_ecomContext.Value.SavedStore == null)
		{
			State = VisualState.Empty;
			return;
		}
		if (_ecomContext.Value.ReceivingMethod.IsDelivery())
		{
			AddressText = _ecomContext.Value.DeliveryAddress?.AddressLine ?? string.Empty;
		}
		else
		{
			AddressText = StoreNameToAddressText(_ecomContext.Value.ReceivingMethod, _ecomContext.Value.ActiveStore.Name);
		}
		SelectedReceiveMethod = ReceiveMethods.FirstOrDefault((ReceiveMethodSelectElementItemViewModel rm) => rm.ReceiveMethod == _ecomContext.Value.ReceivingMethod);
		if (SelectedReceiveMethod != null && !string.IsNullOrEmpty(AddressText))
		{
			State = VisualState.Default;
		}
		else
		{
			State = VisualState.Empty;
		}
		LoadReceiveMethodsCommand.Trigger();
	}

	private async Task OnMethodSelected(ReceiveMethodSelectElementItemViewModel newSelectedMethodItemViewModel)
	{
		AppAnalytics.AppMetrica.TrackAddressBlockClick(newSelectedMethodItemViewModel.ReceiveMethod, NavigatedFrom);
		OpenAddressSelectionCommand.Trigger(new AddressViewModel.Parameter
		{
			ReceivingMethod = ((!newSelectedMethodItemViewModel.IsAvailable) ? ReceivingMethod.Delivery : newSelectedMethodItemViewModel.ReceiveMethod)
		});
	}

	private string ReceiveMethodToTitle(ReceivingMethod receiveMethod)
	{
		return receiveMethod switch
		{
			ReceivingMethod.ExpressDelivery => "Быстро", 
			ReceivingMethod.Delivery => "Доставка", 
			ReceivingMethod.Pickup => "Самовывоз", 
			ReceivingMethod.CarPickup => "Авто", 
			_ => "Доставка", 
		};
	}

	private string ReceiveMethodToDescription(ReceiveMethodsResponseReceiveMethodDTO dto)
	{
		return dto.ReceiveMethod switch
		{
			ReceivingMethod.ExpressDelivery => dto.DeliveryInfo?.Time ?? string.Empty, 
			ReceivingMethod.Delivery => dto.DeliveryInfo?.Time ?? string.Empty, 
			ReceivingMethod.Pickup => dto.DeliveryInfo?.Time ?? "бесплатно", 
			ReceivingMethod.CarPickup => dto.DeliveryInfo?.Time ?? "с парковки", 
			_ => string.Empty, 
		};
	}

	private string StoreNameToAddressText(ReceivingMethod receivingMethod, string storeName)
	{
		return receivingMethod switch
		{
			ReceivingMethod.Pickup => "Самовывоз: АШАН " + storeName, 
			ReceivingMethod.CarPickup => "АШАН Авто: " + storeName, 
			_ => string.Empty, 
		};
	}
}
