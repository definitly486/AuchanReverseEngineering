using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reactive;
using System.Threading.Tasks;
using Auchan.Common.Addresses;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Common;
using Auchan.Common.Ecom.Address.Models;
using Auchan.Common.Ecom.AddressStoreSelection;
using Auchan.Common.Ecom.DTO;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Ecom;

public interface IEcomContext : INotifyPropertyChanged
{
	Store ActiveStore { get; }

	Store? SavedStore { get; }

	bool Initialized { get; }

	bool ReceivingMethodNotSelected { get; }

	AgreeState AgeGateAgreement { get; set; }

	DeliveryAddress? DeliveryAddress { get; set; }

	ReceivingMethod ReceivingMethod { get; set; }

	event Func<Task> AfterAddressSet;

	Task<Store> GetActiveStoreAsync();

	Task<Result<Unit, DomainError>> Initialize();

	Task<Result<bool, DomainError>> CanChange(Store store, ReceivingMethod receivingMethod);

	Task<Result<SetShopResponse, DomainError>> SaveOnServer(Store store, ReceivingMethod receivingMethod);

	Task CleanDeinitialize();

	void NotifyDeliveryAddressChanged();

	void NotifyAppResumed();

	Task SyncReceiveMethodQueued(bool appSessionStarted = false, bool force = false);

	void UpdateActiveStoreProperties(IEnumerable<Store> stores);
}
