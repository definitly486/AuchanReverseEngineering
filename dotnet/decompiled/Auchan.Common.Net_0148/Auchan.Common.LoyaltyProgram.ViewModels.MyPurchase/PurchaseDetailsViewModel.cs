using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Auchan.Common.AdminTool;
using Auchan.Common.Analytics;
using Auchan.Common.Base;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Common.Binding;
using Auchan.Common.Ecom.Products.ViewModels;
using Auchan.Common.Extensions;
using Auchan.Common.Helpers;
using Auchan.Common.LoyaltyProgram.Enums;
using Auchan.Common.LoyaltyProgram.Managers;
using Auchan.Common.LoyaltyProgram.Models;
using Auchan.Common.LoyaltyProgram.ViewModels.MyPurchase.FeedItems;
using Auchan.Common.Navigation;
using Auchan.Common.Profile.Stores.Models;
using Auchan.Common.Profile.Stores.Repositories;
using CSharpFunctionalExtensions;
using Microsoft.Maui.Devices.Sensors;

namespace Auchan.Common.LoyaltyProgram.ViewModels.MyPurchase;

public sealed class PurchaseDetailsViewModel : ScreenViewModel
{
	public class Parameter
	{
		public PurchaseItemViewModel? PurchaseItemViewModel { get; }

		public string? ChequeNumber { get; }

		public Parameter(PurchaseItemViewModel? purchaseItemViewModel, string? chequeNumber)
		{
			PurchaseItemViewModel = purchaseItemViewModel;
			ChequeNumber = chequeNumber;
		}
	}

	public enum VisualState
	{
		Default,
		InProgress,
		Error
	}

	private readonly IStoreRepository _storeRepository;

	private readonly IAdminContext _adminContext;

	private readonly ILoyaltyManager _loyaltyManager;

	private readonly ILoyaltyPurchasesRepository _purchasesRepository;

	private readonly UrlNavigationHandler _urlNavigationHandler;

	private readonly Parameter _parameter;

	[CompilerGenerated]
	private VisualState _003CState_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CTitle_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CReceiveDateTimeTitle_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CReceiveDateTime_003Ek__BackingField;

	[CompilerGenerated]
	private string? _003CStoreAddressTitle_003Ek__BackingField;

	[CompilerGenerated]
	private string? _003CStoreAddress_003Ek__BackingField;

	[CompilerGenerated]
	private Location? _003CStoreLocation_003Ek__BackingField;

	private bool _isOfflinePurchase;

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
				RaisePropertyChanged("State");
			}
		}
	} = VisualState.InProgress;

	public string Title
	{
		[CompilerGenerated]
		get
		{
			return _003CTitle_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CTitle_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CTitle_003Ek__BackingField = value;
				RaisePropertyChanged("Title");
			}
		}
	} = "";

	public string ConnectionErrorText => _loyaltyManager.ConnectionErrorText;

	public string ConnectionErrorImage => _loyaltyManager.ConnectionErrorImage;

	public string ReceiveDateTimeTitle
	{
		[CompilerGenerated]
		get
		{
			return _003CReceiveDateTimeTitle_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CReceiveDateTimeTitle_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CReceiveDateTimeTitle_003Ek__BackingField = value;
				RaisePropertyChanged("ReceiveDateTimeTitle");
			}
		}
	} = "";

	public string ReceiveDateTime
	{
		[CompilerGenerated]
		get
		{
			return _003CReceiveDateTime_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CReceiveDateTime_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CReceiveDateTime_003Ek__BackingField = value;
				RaisePropertyChanged("ReceiveDateTime");
			}
		}
	} = "-";

	public bool HasStoreInfo
	{
		get
		{
			if (StoreAddressTitle != null && StoreAddress != null)
			{
				return StoreLocation != null;
			}
			return false;
		}
	}

	public string? StoreAddressTitle
	{
		[CompilerGenerated]
		get
		{
			return _003CStoreAddressTitle_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CStoreAddressTitle_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CStoreAddressTitle_003Ek__BackingField = value;
				RaisePropertyChanged("HasStoreInfo");
				RaisePropertyChanged("StoreAddressTitle");
			}
		}
	}

	public string? StoreAddress
	{
		[CompilerGenerated]
		get
		{
			return _003CStoreAddress_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CStoreAddress_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CStoreAddress_003Ek__BackingField = value;
				RaisePropertyChanged("HasStoreInfo");
				RaisePropertyChanged("StoreAddress");
			}
		}
	}

	public Location? StoreLocation
	{
		[CompilerGenerated]
		get
		{
			return _003CStoreLocation_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!(_003CStoreLocation_003Ek__BackingField == value))
			{
				_003CStoreLocation_003Ek__BackingField = value;
				RaisePropertyChanged("HasStoreInfo");
				RaisePropertyChanged("StoreLocation");
			}
		}
	}

	public string ProductsTitle => "Товары";

	public string ProductCount => $"{LoyaltyProducts.Count} {GrammarHelper.DeclineNoun(LoyaltyProducts.Count, new string[3] { "товар", "товара", "товаров" })}";

	public ObservableRangeCollection<LoyaltyProductViewModel> LoyaltyProducts { get; } = new ObservableRangeCollection<LoyaltyProductViewModel>();

	public SumDetailsSectionViewModel SumDetailsViewModel { get; }

	public UICommand OpenDelayedPointsInfoCommand { get; } = new UICommand();

	protected override string ScreenName => "history_order_composition_screen";

	public UICommand<ProductDetailsViewModel.Parameter> NavigateToProductDetailsCommand { get; } = new UICommand<ProductDetailsViewModel.Parameter>();

	public PurchaseDetailsViewModel(Parameter parameter, SumDetailsSectionViewModel sumDetailsViewModel, IAdminContext adminContext, IStoreRepository storeRepository, ILoyaltyPurchasesRepository purchasesRepository, ILoyaltyManager loyaltyManager, UrlNavigationHandler urlNavigationHandler)
	{
		_parameter = parameter;
		_storeRepository = storeRepository;
		_adminContext = adminContext;
		_purchasesRepository = purchasesRepository;
		_loyaltyManager = loyaltyManager;
		_urlNavigationHandler = urlNavigationHandler;
		SumDetailsViewModel = sumDetailsViewModel;
	}

	protected override async Task Start()
	{
		await base.Start();
		PurchaseItemViewModel purchase = null;
		LoyaltyTransactionDetails transactionDetails = null;
		if (_parameter.PurchaseItemViewModel?.LoyaltyProgramPurchase.Transaction != null)
		{
			transactionDetails = _parameter.PurchaseItemViewModel.LoyaltyProgramPurchase.Transaction;
			purchase = _parameter.PurchaseItemViewModel;
			await Task.Delay(500);
		}
		else if (!string.IsNullOrEmpty(_parameter.ChequeNumber))
		{
			Result<LoyaltyProgramPurchase, DomainError> result = await _purchasesRepository.GetTransactionDetailsAsync(_parameter.ChequeNumber);
			if (result.IsSuccess)
			{
				purchase = new PurchaseItemViewModel(result.Value);
				transactionDetails = result.Value.Transaction;
			}
		}
		if (transactionDetails != null && purchase != null)
		{
			Title = purchase.OperationType switch
			{
				QualifiedLoyaltyOperationType.Order => string.IsNullOrEmpty(purchase.OrderNumber) ? "Заказ" : ("Заказ №" + purchase.OrderNumber), 
				QualifiedLoyaltyOperationType.Purchase => "Покупка в магазине", 
				_ => purchase.OperationName, 
			};
			bool showStamps = _adminContext.StampsConfig?.ShowStampsInHistory ?? false;
			LoyaltyProducts.AddRange(transactionDetails.Products.Select((LoyaltyProduct x) => new LoyaltyProductViewModel(x, showStamps)));
			string resultSum = $"{transactionDetails.Amount:N2}" + " ₽";
			string addedPoints = ((transactionDetails.AddedPoints != 0m) ? $"+{transactionDetails.AddedPoints:N2}" : string.Empty);
			string addedExpressPoints = ((transactionDetails.AddedExpressPoints != 0m) ? $"+{transactionDetails.AddedExpressPoints:N2}" : string.Empty);
			string addedStamps = ((showStamps && transactionDetails.AddedStamps != 0m) ? $"+{(int)transactionDetails.AddedStamps}" : string.Empty);
			string spentPoints = ((transactionDetails.RemovedPoints != 0m) ? $"{transactionDetails.RemovedPoints:N2}" : string.Empty);
			string spentExpressPoints = ((transactionDetails.RemovedExpressPoints != 0m) ? $"{transactionDetails.RemovedExpressPoints:N2}" : string.Empty);
			string spentStamps = ((showStamps && transactionDetails.RemovedStamps != 0m) ? $"{(int)transactionDetails.RemovedStamps}" : string.Empty);
			string delayedPoints = ((transactionDetails.DelayedPoints > 0m) ? ("+" + transactionDetails.DelayedPoints.ToPointsString("### ##0.00", removeDecimals: false)) : string.Empty);
			string delayedPointsBookDate = (transactionDetails.DelayedPointsBookDate.HasValue ? $"с {transactionDetails.DelayedPointsBookDate:dd.MM}" : string.Empty);
			ReceiveDateTime = $"{transactionDetails.ReceivingDateTime:dd MMMM yyyy, HH:mm}";
			SumDetailsViewModel.Initialize(resultSum, addedPoints, addedExpressPoints, addedStamps, spentPoints, spentExpressPoints, spentStamps, delayedPoints, delayedPointsBookDate);
			_isOfflinePurchase = purchase.OperationType == QualifiedLoyaltyOperationType.Purchase;
			if (purchase.StoreExternalId.HasValue)
			{
				Result<FullStoreModel, DomainError> result2 = await _storeRepository.FromCacheOrApiByExternalIdAsync(purchase.StoreExternalId.Value);
				if (result2.IsSuccess)
				{
					StoreAddressTitle = "Адрес магазина";
					StoreAddress = result2.Value.Address;
					StoreLocation = new Location(result2.Value.Latitude, result2.Value.Longitude);
				}
			}
			ReceiveDateTimeTitle = (IsPurchase(purchase) ? "Дата и время покупки" : "Дата и время доставки");
			if (purchase.OperationType == QualifiedLoyaltyOperationType.Order)
			{
				AppAnalytics.AppMetrica.OpenOrderDetails();
			}
			State = VisualState.Default;
		}
		else
		{
			State = VisualState.Error;
		}
	}

	private bool IsPurchase(PurchaseItemViewModel p)
	{
		string source = p.LoyaltyProgramPurchase.Source;
		switch (source)
		{
		default:
			return source == "G";
		case "L":
		case "C":
		case "S":
		case "P":
			return true;
		}
	}

	public void HandleLink(string url)
	{
		_urlNavigationHandler.HandleUrl(url);
	}

	public void ProductSelected(LoyaltyProductViewModel product)
	{
		NavigateToProductDetailsCommand.Trigger(new ProductDetailsViewModel.Parameter(product.Code)
		{
			OfflinePurchase = _isOfflinePurchase
		});
	}
}
