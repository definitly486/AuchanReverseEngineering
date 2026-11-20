using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Auchan.Common.Ecom.Address.Models;
using Auchan.Common.Ecom.DTO;
using Auchan.Common.Ecom.Replacements;
using Auchan.Common.Logs;
using Auchan.Common.Profile.Orders.Enums;

namespace Auchan.Common.Ecom.Address;

public static class ShopDtoMapper
{
	public static Store ToStoreModel(this ShopDto dto, City city, Lazy<ILogService> logService)
	{
		string open = dto.TimeWork.Workdays.Open;
		string close = dto.TimeWork.Workdays.Close;
		string open2 = dto.TimeWork.Weekends.Open;
		string close2 = dto.TimeWork.Weekends.Close;
		string workingHours = ((open != null && close != null && open2 != null && close2 != null) ? $"Пн-Пт c {open} до {close},\nСб-Вс c {open2} до {close2}" : "Нет данных по адресу магазина");
		DateTime? dateTime = null;
		DateTime? dateTime2 = null;
		if (DateTime.TryParse(dto.ExpressEndsAt, out var result) && DateTime.TryParse(dto.ExpressStartsAt, out var result2))
		{
			dateTime2 = result;
			dateTime = result2;
		}
		DateTimeOffset? dateTimeOffset = null;
		DateTimeOffset? dateTimeOffset2 = null;
		if (DateTimeOffset.TryParse(dto.DeliveryEndsAt, out var result3) && DateTimeOffset.TryParse(dto.DeliveryStartsAt, out var result4))
		{
			dateTimeOffset2 = result3;
			dateTimeOffset = result4;
		}
		ShopExpressDeliveryDto expressDelivery = dto.ExpressDelivery;
		List<ReceiveMethod> receiveMethods = dto.ReceiveMethods;
		bool hasExpressDelivery = receiveMethods.Contains(ReceiveMethod.ExpressDelivery);
		Exception exception;
		Store result5 = new Store
		{
			Id = dto.MerchantId,
			Name = dto.Name,
			Address = (dto.AddressString ?? "Нет данных по адресу магазина"),
			WorkingHours = workingHours,
			City = city,
			ExpressWeightMax = (expressDelivery?.WeightMax).GetValueOrDefault(),
			ExpressDeliveryStandardWeight = (expressDelivery?.StandardWeight).GetValueOrDefault(),
			ExpressStartAt = (dateTime ?? DateTime.UtcNow),
			ExpressEndsAt = (dateTime2 ?? DateTime.UtcNow),
			ExpressDeliveryTime = (expressDelivery?.DeliveryTime).GetValueOrDefault(),
			DeliveryStartTime = (dto.DeliveryStartsAt ?? ""),
			DeliveryEndTime = (dto.DeliveryEndsAt ?? ""),
			HasDeliveryStartAndEnd = (dateTimeOffset.HasValue && dateTimeOffset2.HasValue),
			StandardDeliveryTariffs = (from i in dto.Delivery?.Tariffs ?? Array.Empty<ShopDeliveryTariffDto>()
				orderby i.BasketCost
				select i.ToModel()).ToImmutableList(),
			ExpressDeliveryStartTime = (dto.ExpressStartsAt ?? ""),
			ExpressDeliveryEndTime = (dto.ExpressEndsAt ?? ""),
			HasExpressDelivery = hasExpressDelivery,
			HasExpressDeliveryStartAndEnd = (dateTime.HasValue && dateTime2.HasValue),
			ExpressDeliveryTariffs = (from i in expressDelivery?.Tariffs ?? Array.Empty<ShopDeliveryTariffDto>()
				orderby i.BasketCost
				select i.ToModel()).ToImmutableList(),
			HasDelivery = receiveMethods.Contains(ReceiveMethod.Delivery),
			HasStorePickUp = receiveMethods.Contains(ReceiveMethod.Pickup),
			HasCarPickup = receiveMethods.Contains(ReceiveMethod.CarPickup),
			HasStoreOnlinePayment = dto.PaymentMethods.Contains(PaymentMethod.Online),
			HasStoreOfflinePayment = dto.PaymentMethods.Contains(PaymentMethod.Offline),
			HasStorePickupPoint = (dto.CollectOrder == true),
			HasDeliveryToDoor = (dto.DeliveryToDoor == true),
			IsDefaultInCity = dto.Default,
			MinCostForPickup = (dto.Pickup?.CostMin).GetValueOrDefault(),
			MinCostForCarPickup = (dto.CarPickup?.CostMin).GetValueOrDefault(),
			MinCostAdultForPickup = (dto.Pickup?.CostMinAdult).GetValueOrDefault(),
			MinCostAdultForCarPickup = (dto.CarPickup?.CostMinAdult).GetValueOrDefault(),
			MaxDeliveryWeightKg = (dto.Delivery?.WeightMax ?? int.MaxValue),
			MaxPickupWeightKg = (dto.Pickup?.WeightMax ?? int.MaxValue),
			MaxCarPickupWeightKg = (dto.CarPickup?.WeightMax ?? int.MaxValue),
			DistanceFromUserLocation = dto.DistanceFromUserLocation,
			Replacements = ReplacementsCollection.CreateInstance(dto.Replacements ?? Enumerable.Empty<ReplacementDto>(), out exception),
			DeliveryStandardWeight = (dto.Delivery?.StandardWeight).GetValueOrDefault(),
			StandardOverweightPricePerKilo = (dto.Delivery?.OverweightPricePerKilo).GetValueOrDefault(),
			ExpressOverweightPricePerKilo = (expressDelivery?.OverweightPricePerKilo).GetValueOrDefault()
		};
		if (exception != null)
		{
			logService.Value.LogError("StoreService", exception.ToString(), LogType.ApiRequest, SystemType.MobileApp);
		}
		return result5;
	}

	public static DeliveryMethodsForAddress ToModel(this DeliveryMethodsForAddressResponseDto dto, IEnumerable<IGrouping<City, Store>> allCityStores)
	{
		if (dto.Data == null)
		{
			return new DeliveryMethodsForAddress
			{
				IsDeliveryAvailable = false
			};
		}
		City region = (from cs in allCityStores
			let city = cs.Key
			where city.EcomId == dto.Data.RegionId
			select city).FirstOrDefault();
		DeliveryMethodsForAddress.Delivery standardDelivery = dto.Data.StandardDelivery?.ToModel(dto.Data, allCityStores);
		DeliveryMethodsForAddress.Delivery expressDelivery = dto.Data.ExpressDelivery?.ToModel(dto.Data, allCityStores, isExpressDelivery: true);
		DeliveryMethodsForAddressResponseDto.ExpressDeliveryUnavailableDto expressDeliveryUnavailable = dto.Data.ExpressDeliveryUnavailable;
		return new DeliveryMethodsForAddress
		{
			IsDeliveryAvailable = dto.Data.IsDeliveryAvailable,
			Region = region,
			StandardDelivery = standardDelivery,
			ExpressDelivery = expressDelivery,
			ExpressDeliveryUnavailableInfo = ((expressDeliveryUnavailable == null) ? null : new DeliveryMethodsForAddress.ExpressDeliveryUnavailable
			{
				UnavailableHint = (expressDeliveryUnavailable.UnavailableHint ?? string.Empty)
			})
		};
	}

	public static DeliveryMethodsForAddress.Delivery? ToModel(this DeliveryMethodsForAddressResponseDto.DeliveryDto dto, DeliveryMethodsForAddressResponseDto.DataDto parent, IEnumerable<IGrouping<City, Store>> allCityStores, bool isExpressDelivery = false)
	{
		Store store = (from stores in allCityStores
			let region = stores.Key
			where region.EcomId == parent.RegionId
			from s in stores
			where s.Id == dto.MerchantId
			select s).FirstOrDefault();
		if (store == null)
		{
			return null;
		}
		return new DeliveryMethodsForAddress.Delivery
		{
			Store = store,
			CostMin = dto.CostMin,
			CostFreeFrom = dto.CostFreeFrom,
			DeliveryStartsAt = dto.DeliveryStartsAt,
			DeliveryTimeHint = dto.DeliveryTimeHint,
			IsDefault = dto.IsDefault
		};
	}

	public static Store.DeliveryTariff ToModel(this ShopDeliveryTariffDto @this)
	{
		return new Store.DeliveryTariff
		{
			BasketCost = @this.BasketCost,
			DeliveryPrice = @this.DeliveryPrice
		};
	}
}
