using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Auchan.Common.Base;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Common;
using Auchan.Common.LoyaltyProgram.Enums;
using Auchan.Common.LoyaltyProgram.Managers;
using Auchan.Common.LoyaltyProgram.ViewModels.MyPurchase.FeedItems;
using Auchan.Common.Navigation;
using Auchan.Common.Profile.Stores.Models;
using Auchan.Common.Profile.Stores.Repositories;
using CSharpFunctionalExtensions;
using Microsoft.Maui.Devices.Sensors;

namespace Auchan.Common.LoyaltyProgram.ViewModels.MyPurchase;

public sealed class OperationDetailsViewModel : ScreenViewModel
{
	public class Parameter
	{
		public PurchaseItemViewModel PurchaseItemVM { get; }

		public Parameter(PurchaseItemViewModel purchaseItemVM)
		{
			PurchaseItemVM = purchaseItemVM;
		}
	}

	private readonly PurchaseItemViewModel _purchaseItemVM;

	private readonly IStoreRepository _storeRepo;

	private readonly ILoyaltyManager _loyaltyManager;

	private readonly UrlNavigationHandler _urlNavigationHandler;

	[CompilerGenerated]
	private VisualState _003CState_003Ek__BackingField;

	[CompilerGenerated]
	private string? _003CStoreName_003Ek__BackingField;

	[CompilerGenerated]
	private string? _003CStoreAddress_003Ek__BackingField;

	[CompilerGenerated]
	private Location? _003CStoreLocation_003Ek__BackingField;

	public string Title => _purchaseItemVM.OperationName;

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
	} = VisualState.Default;

	public string Amount => _purchaseItemVM.Amount;

	public string FormattedTime { get; }

	public QualifiedLoyaltyOperationType OperationType => _purchaseItemVM.OperationType;

	public bool HasPointIcon
	{
		get
		{
			if (OperationType != QualifiedLoyaltyOperationType.Purchase)
			{
				return OperationType != QualifiedLoyaltyOperationType.Order;
			}
			return false;
		}
	}

	public bool HasPurchasePoints => _purchaseItemVM.HasPoints;

	public bool HasPurchaseEPoints => _purchaseItemVM.HasEPoints;

	public bool HasStamps => _purchaseItemVM.HasStamps;

	public string PurchasePoints => _purchaseItemVM.Points;

	public string PurchaseEPoints => _purchaseItemVM.EPoints;

	public string Stamps => _purchaseItemVM.Stamps;

	public string ConnectionErrorText => _loyaltyManager.ConnectionErrorText;

	public string ConnectionErrorImage => _loyaltyManager.ConnectionErrorImage;

	public bool HasStoreInfo
	{
		get
		{
			if (StoreName != null && StoreAddress != null)
			{
				return StoreLocation != null;
			}
			return false;
		}
	}

	public string? StoreName
	{
		[CompilerGenerated]
		get
		{
			return _003CStoreName_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CStoreName_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CStoreName_003Ek__BackingField = value;
				RaisePropertyChanged("HasStoreInfo");
				RaisePropertyChanged("StoreName");
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

	public OperationDetailsViewModel(Parameter parameter, IStoreRepository storeRepo, ILoyaltyManager loyaltyManager, UrlNavigationHandler urlNavigationHandler)
	{
		_purchaseItemVM = parameter.PurchaseItemVM;
		_storeRepo = storeRepo;
		_loyaltyManager = loyaltyManager;
		_urlNavigationHandler = urlNavigationHandler;
		FormattedTime = $"{_purchaseItemVM.LoyaltyProgramPurchase.OperationDate:d MMMM yyyy, HH:mm}";
	}

	protected override async Task Start()
	{
		await base.Start();
		if (_purchaseItemVM.LoyaltyProgramPurchase.StoreExternalId.HasValue)
		{
			Result<FullStoreModel, DomainError> result = await _storeRepo.FromCacheOrApiByExternalIdAsync(_purchaseItemVM.LoyaltyProgramPurchase.StoreExternalId.Value);
			if (!result.IsFailure)
			{
				StoreName = result.Value.Name;
				StoreAddress = result.Value.Address;
				StoreLocation = new Location(result.Value.Latitude, result.Value.Longitude);
			}
		}
	}

	public void HandleLink(string url)
	{
		_urlNavigationHandler.HandleUrl(url);
	}
}
