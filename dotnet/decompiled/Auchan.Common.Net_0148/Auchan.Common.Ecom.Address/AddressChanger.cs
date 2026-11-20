using System;
using System.Collections.Generic;
using System.Reactive;
using System.Threading.Tasks;
using AsyncAwaitBestPractices;
using Auchan.Common.Addresses;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Common;
using Auchan.Common.Ecom.Address.Models;
using Auchan.Common.Ecom.AddressStoreSelection;
using Auchan.Common.Ecom.Cart;
using Auchan.Common.Ecom.Cart.Models;
using Auchan.Common.Ecom.DTO;
using Auchan.Common.Ecom.Extensions;
using Auchan.Common.Ecom.ProducModels;
using Auchan.Common.Ecom.Products;
using Auchan.Common.Extensions;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Ecom.Address;

public class AddressChanger
{
	private const string ProductAddingErrorText = "Не удалось добавить товар";

	private IEcomContext _ecomContext;

	private Lazy<Auchan.Common.Ecom.Cart.Cart> _cart;

	private IProductsRepository _productsRepository;

	private readonly IStoreService _storeService;

	private readonly IUserAddressService _userAddressService;

	private readonly Lazy<StoreRepository> _storeRepository;

	public AddressChanger(IEcomContext ecomContext, Lazy<Auchan.Common.Ecom.Cart.Cart> cart, IProductsRepository productsRepository, IStoreService storeService, IUserAddressService userAddressService, Lazy<StoreRepository> storeRepository)
	{
		_ecomContext = ecomContext;
		_cart = cart;
		_productsRepository = productsRepository;
		_storeService = storeService;
		_userAddressService = userAddressService;
		_storeRepository = storeRepository;
	}

	public async Task<Result<bool>> Simulate(Store store, ReceivingMethod receivingMethod)
	{
		Result<SetShopResponse, DomainError> result = await _storeService.SetCurrentUserStore(store, receivingMethod, true);
		if (result.TryGetValue(out var value))
		{
			return value.BasketChanged;
		}
		result.TryGetError(out var error);
		return Result.Failure<bool>(GetFailureText(error));
	}

	public async Task<Result<SavedAddress?, DomainError>> Change(Store store, ReceivingMethod receivingMethod, bool isFirstTimeAddressSelection, ProductOffer? productOffer, SavedAddress? selectedSavedAddress, DeliveryAddress? lastSelectedAddressModel)
	{
		Result<SavedAddress, DomainError>? result = null;
		if (receivingMethod == ReceivingMethod.Delivery || receivingMethod == ReceivingMethod.ExpressDelivery)
		{
			if (selectedSavedAddress != null)
			{
				result = await _userAddressService.SaveAddress(selectedSavedAddress);
			}
			else if (lastSelectedAddressModel != null)
			{
				result = await _userAddressService.SaveAddress(lastSelectedAddressModel);
			}
		}
		SavedAddress savedAddress = null;
		if (result.HasValue)
		{
			Result<SavedAddress, DomainError> valueOrDefault = result.GetValueOrDefault();
			if (valueOrDefault.IsFailure)
			{
				return Result.Failure<SavedAddress, DomainError>(new NoDataError
				{
					Message = ((result.Value.Error is ConnectionError) ? "Нет соединения с интернетом" : "Не удалось сохранить выбранный адрес, попробуйте еще раз")
				});
			}
			savedAddress = valueOrDefault.Value;
		}
		Task<Result<SetShopResponse, DomainError>> saveStoreOnServerTask = _ecomContext.SaveOnServer(store, receivingMethod);
		if (!receivingMethod.IsDelivery())
		{
			await saveStoreOnServerTask;
		}
		else
		{
			Task<Result<Unit, DomainError>> clearAllAdultProductsTask = _cart.Value.ClearAllAdultProducts();
			await Task.WhenAll(saveStoreOnServerTask, clearAllAdultProductsTask);
			_ = clearAllAdultProductsTask.Result.IsFailure;
		}
		if (saveStoreOnServerTask.Result.TryGetError(out DomainError error))
		{
			return Result.Failure<SavedAddress, DomainError>(new NoDataError
			{
				Message = GetFailureText(error)
			});
		}
		_storeRepository.Value.CleanupReceiveMethodsCache();
		_ecomContext.ReceivingMethod = receivingMethod;
		if (receivingMethod.IsDelivery())
		{
			_ecomContext.DeliveryAddress = savedAddress?.ToDeliveryAddress() ?? lastSelectedAddressModel ?? _ecomContext.DeliveryAddress;
			_ecomContext.NotifyDeliveryAddressChanged();
		}
		_ecomContext.SyncReceiveMethodQueued(appSessionStarted: false, force: true).SafeFireAndForget((Action<Exception>)null, false);
		Guid cartRequestId = Guid.NewGuid();
		if (productOffer != null)
		{
			if (productOffer.IsAdult && receivingMethod.IsDelivery())
			{
				return Result.Failure<SavedAddress, DomainError>(new NoDataError
				{
					Message = "Не удалось добавить товар"
				});
			}
			await _cart.Value.Update(cartRequestId);
			await AddProductToCart(productOffer, cartRequestId);
			return Result.Success<SavedAddress, DomainError>(savedAddress);
		}
		await _cart.Value.Update(cartRequestId);
		return Result.Success<SavedAddress, DomainError>(savedAddress);
	}

	private string GetFailureText(DomainError? error)
	{
		if (error is ConnectionError)
		{
			return "Нет соединения с интернетом";
		}
		return "Не удалось сохранить выбранный магазин, попробуйте еще раз";
	}

	private async Task AddProductToCart(ProductOffer productOffer, Guid requestId)
	{
		Result<Product, DomainError> result = await _productsRepository.GetProductDetailAsync(productOffer.Code, _ecomContext.ActiveStore.Id);
		if (result.IsSuccess && result.Value.Id >= 0)
		{
			ReadOnlyEquatableList<SelectedModification> selectedModifications = productOffer.SelectedModifications;
			Product value = result.Value;
			IReadOnlyList<SelectedModification> modifications = selectedModifications;
			ProductOffer product = value.CreateOffer(null, modifications);
			_cart.Value.AddItem(product, requestId);
		}
	}
}
