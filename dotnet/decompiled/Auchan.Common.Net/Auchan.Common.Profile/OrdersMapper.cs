using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Net;
using Auchan.Common.Base.Errors;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Base.Errors.Service;
using Auchan.Common.Ecom.DTO;
using Auchan.Common.Ecom.ProducModels;
using Auchan.Common.Extensions;
using Auchan.Common.Profile.Orders;
using Auchan.Common.Profile.Orders.Dto;
using Auchan.Common.Profile.Orders.Enums;
using Auchan.Common.Profile.Orders.Models;

namespace Auchan.Common.Profile;

internal static class OrdersMapper
{
	public static IReadOnlyList<OrderListModel> ToModel(this OrdersDto orders)
	{
		if (!(orders == null) && orders.Orders != null)
		{
			return orders.Orders.Select(delegate(OrderDto order)
			{
				OrderListModel obj = new OrderListModel
				{
					CreatedAt = order.CreatedAt,
					DeliveryDate = (order.Deliveries.FirstOrDefault()?.DeliveryDate ?? DateTimeOffset.MinValue),
					DeliveryTime = MapDeliveryTime(order.Deliveries.FirstOrDefault()?.DeliveryTime),
					DeliveryToTime = MapDeliveryToTime(order.Deliveries.FirstOrDefault()?.DeliveryToTime),
					DeliveryAddress = (order.Deliveries.FirstOrDefault()?.AddressInfo?.Address ?? string.Empty),
					DeliveryPrice = order.DeliveryPrice.GetValueOrDefault(),
					Id = order.Id.GetValueOrDefault(),
					Number = order.Number,
					IsAdult = order.IsAdult,
					Price = order.Price.GetValueOrDefault(),
					Qty = (order.Deliveries.FirstOrDefault()?.Products.Count ?? 0),
					Status = order.CustomerStatus,
					IsDelayed = (order.IsDelayed == true),
					AwaitingPayment = order.AwaitingPayment,
					PaymentUrl = order.PaymentUrl,
					DeliveryMethod = (order.Deliveries.FirstOrDefault()?.DeliveryMethod ?? DeliveryMethod.BySelf)
				};
				DeliveryDto? deliveryDto = order.Deliveries.FirstOrDefault();
				object courierNumber;
				if ((object)deliveryDto == null)
				{
					courierNumber = null;
				}
				else
				{
					string? courierPhoneNumber = deliveryDto.CourierPhoneNumber;
					courierNumber = ((courierPhoneNumber != null) ? StringExtensions.TrimStart(courierPhoneNumber, "tel:") : null);
				}
				obj.CourierNumber = (string?)courierNumber;
				obj.Products = order.Deliveries.FirstOrDefault()?.Products.Select((Auchan.Common.Profile.Orders.Dto.ProductDto c) => new ProductModel
				{
					Name = (c.Name ?? ""),
					ImageUrl = c.ImageUrl,
					Code = (c.Code ?? ""),
					GimaId = (c.GimaId ?? ""),
					SelectedModifications = CartItemDtoMapper.Map(c.SelectedModifications, c.Modifications),
					Price = c.Price.GetValueOrDefault(),
					Qty = c.Qty.GetValueOrDefault(),
					QtyInit = c.QtyInit.GetValueOrDefault(),
					ItemId = c.ItemId.GetValueOrDefault(),
					SourceItemId = c.SourceItemId,
					DestItemId = c.DestItemId
				}).ToImmutableList() ?? ImmutableList.Create(default(ReadOnlySpan<ProductModel>));
				obj.StoreName = order.Shop.Name;
				obj.StoreAddress = order.Shop.Address;
				obj.PickupPointDescription = order.Shop.PickupDescription ?? string.Empty;
				obj.PickupPointImageUrls = order.Shop.PickupPhotoUrls ?? Array.Empty<string>();
				obj.CollectOrder = order.Shop.CollectOrder;
				obj.PaymentMethod = order.Payments.FirstOrDefault()?.PaymentMethod ?? PaymentMethod.Online;
				obj.Shop = order.Shop.ToModel();
				obj.IsCanAddGoodsToOrder = order.AdditionAvailable;
				return obj;
			}).ToImmutableList();
		}
		return ImmutableList<OrderListModel>.Empty;
	}

	public static ShopInfoModel ToModel(this Auchan.Common.Profile.Orders.Dto.ShopDto shop)
	{
		return new ShopInfoModel
		{
			Address = shop.Address,
			Name = shop.Name,
			PickupDescription = (shop.PickupDescription ?? string.Empty),
			PickupPhotoUrls = (shop.PickupPhotoUrls ?? Array.Empty<string>()),
			CollectOrder = shop.CollectOrder
		};
	}

	public static OrderModel? ToModel(this OrderApiDto orderApi)
	{
		OrderDto order = orderApi.Order;
		if (order == null)
		{
			return null;
		}
		DeliveryDto deliveryDto = order.Deliveries.FirstOrDefault();
		if (deliveryDto == null)
		{
			return null;
		}
		OrderModel obj = new OrderModel
		{
			Id = (order.Id ?? (-1)),
			CreatedAt = order.CreatedAt,
			Number = order.Number,
			Status = order.CustomerStatus,
			IsDelayed = (order.IsDelayed == true),
			PickingPrice = order.PickingPrice,
			SurgeAmount = order.SurgeAmount,
			IsAdult = order.IsAdult,
			AwaitingPayment = order.AwaitingPayment,
			PaymentUrl = order.PaymentUrl,
			DeliveryPrice = order.DeliveryPrice.GetValueOrDefault(),
			UsedPoints = order.UsedPoints.GetValueOrDefault(),
			UsedStamps = order.UsedStamps.GetValueOrDefault(),
			Price = order.Price.GetValueOrDefault(),
			ProductsOnlyPrice = order.ProductsOnlyPrice,
			SelfPickupPointInfo = ((order.selfPickupPointInfo != null) ? new SelfPickupPointInfoModel
			{
				Position = order.selfPickupPointInfo.Position,
				Description = order.selfPickupPointInfo.Description,
				ImageUrl = order.selfPickupPointInfo.ImageUrl
			} : null),
			Shop = order.Shop.ToModel()
		};
		DeliveryInfoModel obj2 = new DeliveryInfoModel
		{
			DeliveryDate = deliveryDto.DeliveryDate,
			DeliveryMethod = deliveryDto.DeliveryMethod,
			DeliveryTime = MapDeliveryTime(deliveryDto.DeliveryTime),
			DeliveryToTime = MapDeliveryToTime(deliveryDto.DeliveryToTime),
			Address = (deliveryDto.AddressInfo?.Address ?? ""),
			Area = (deliveryDto.AddressInfo?.Area ?? ""),
			Block = (deliveryDto.AddressInfo?.Block ?? ""),
			City = (deliveryDto.AddressInfo?.City ?? ""),
			Flat = (deliveryDto.AddressInfo?.Flat ?? ""),
			Floor = (deliveryDto.AddressInfo?.Floor ?? ""),
			Comment = (deliveryDto.AddressInfo?.Comment ?? ""),
			GeoLat = (deliveryDto.AddressInfo?.GeoLat).GetValueOrDefault(),
			GeoLon = (deliveryDto.AddressInfo?.GeoLon).GetValueOrDefault(),
			House = (deliveryDto.AddressInfo?.House ?? ""),
			Porch = (deliveryDto.AddressInfo?.Porch ?? ""),
			Region = (deliveryDto.AddressInfo?.Region ?? ""),
			Street = (deliveryDto.AddressInfo?.Street ?? "")
		};
		string? courierPhoneNumber = deliveryDto.CourierPhoneNumber;
		obj2.CourierNumber = ((courierPhoneNumber != null) ? StringExtensions.TrimStart(courierPhoneNumber, "tel:") : null);
		obj2.Products = deliveryDto.Products.Select((Auchan.Common.Profile.Orders.Dto.ProductDto c) => new ProductModel
		{
			ImageUrl = c.ImageUrl,
			Name = (c.Name ?? ""),
			Price = c.Price.GetValueOrDefault(),
			PriceInit = c.PriceInit.GetValueOrDefault(),
			GimaId = (c.GimaId ?? ""),
			Qty = c.Qty.GetValueOrDefault(),
			QtyInit = (c.QtyInit ?? 1m),
			Weight = c.Weight.GetValueOrDefault(),
			ProductTypeIsPerKilo = (c.ProductTypeIsPerKilo == true),
			Code = (c.Code ?? ""),
			SelectedModifications = CartItemDtoMapper.Map(c.SelectedModifications, c.Modifications),
			ItemId = c.ItemId.GetValueOrDefault(),
			SourceItemId = c.SourceItemId,
			DestItemId = c.DestItemId
		}).ToImmutableList();
		obj.Delivery = obj2;
		obj.PaymentMethod = order.Payments.FirstOrDefault()?.PaymentMethod ?? PaymentMethod.Online;
		obj.IsCancellationPossible = order.IsCancellationPossible;
		obj.IsCanAddGoodsToOrder = order.AdditionAvailable;
		return obj;
	}

	public static IReadOnlyList<OrderToAdditionModel> ToModel(this IReadOnlyList<OrdersToAdditionDto.OrderDto> @this)
	{
		return (from i in @this
			where i.Deliveries.Count > 0
			select i.ToModel()).ToImmutableList();
	}

	public static OrderToAdditionModel ToModel(this OrdersToAdditionDto.OrderDto @this)
	{
		return new OrderToAdditionModel
		{
			Id = @this.Id,
			Number = @this.Number,
			Price = @this.Price,
			DeliveryPrice = @this.DeliveryPrice,
			PickingPrice = @this.PickingPrice,
			DeliveryDate = @this.Deliveries.First().DeliveryDate,
			DeliveryTime = MapDeliveryTime(@this.Deliveries.First().DeliveryTime).Replace(" - ", " до "),
			DeliveryPlace = (@this.Deliveries.First().AddressInfo?.Address ?? ""),
			DeliveryMethod = @this.Deliveries.First().DeliveryMethod,
			ShopName = @this.ShopName,
			EditableTill = @this.EditableTill
		};
	}

	public static AddProductsToOrderPopupViewModel.Parameter ToModel(this CheckAdditionItemsResponseDto.DataDto @this)
	{
		int ail = @this.Items.Count - 1;
		int uil = @this.UnavailableItems.Count - 1;
		return new AddProductsToOrderPopupViewModel.Parameter
		{
			OrderNumber = @this.Summary.OrderNumber,
			AvailableItems = @this.Items.Select((CheckAdditionItemsResponseDto.ItemDto i, int n) => i.ToModel(uil >= 0 || n < ail)).ToImmutableList(),
			UnavailableItems = @this.UnavailableItems.Select((CheckAdditionItemsResponseDto.ItemDto i, int n) => i.ToModel(n < uil)).ToImmutableList(),
			AvailableItemsCount = @this.Summary.AvailableItemsCount,
			ProductsSum = @this.Summary.OrderAdditionPrice,
			NewOrderPrice = @this.Summary.OrderPrice
		};
	}

	public static AdditionalOrderProductItem ToModel(this CheckAdditionItemsResponseDto.ItemDto @this, bool isSeparatorVisible)
	{
		return new AdditionalOrderProductItem
		{
			Id = @this.OfferId,
			ProductId = @this.ProductId,
			GimaId = @this.GimaId,
			BasketStep = @this.BasketStep,
			Title = @this.Name,
			CurrentQty = @this.Qty,
			Price = @this.Price.ToModel(),
			PricePerItem = @this.PricePerOne.ToModel(),
			ImageUrl = @this.ImageUrl,
			HaveConstraints = (@this.Constraints != null),
			IsSeparatorVisible = isSeparatorVisible
		};
	}

	public static Price ToModel(this CheckAdditionItemsResponseDto.PriceDto @this)
	{
		return new Price
		{
			Value = @this.Value,
			Currency = @this.Currency,
			UnitType = @this.UnitType
		};
	}

	public static DomainError ToOrderAdditionError(this ServiceError serviceError)
	{
		if (serviceError is IUnsuccessfulStatusCodeError<IAdditionErrorDto> { StatusCode: HttpStatusCode.UnprocessableEntity } unsuccessfulStatusCodeError)
		{
			AddtionErrorDto addtionErrorDto = unsuccessfulStatusCodeError.Content?.Errors?.FirstOrDefault();
			if (addtionErrorDto != null)
			{
				return new OrderAdditionError
				{
					Message = addtionErrorDto.Message,
					Details = addtionErrorDto.Details
				};
			}
		}
		return serviceError.ToBaseDomainError();
	}

	private static string MapDeliveryTime(string? deliveryTime)
	{
		return deliveryTime ?? string.Empty;
	}

	private static string MapDeliveryToTime(string? deliveryToTime)
	{
		string text = MapDeliveryTime(deliveryToTime);
		if (!text.StartsWith("До", StringComparison.Ordinal))
		{
			return text;
		}
		return "до" + text.Substring(2);
	}

	public static SuccessAdditionalOrderPopupViewModel.Parameter ToModel(this AddGoodsToOrderResposeDto.DataDto @this)
	{
		AddGoodsToOrderResposeDto.DeliveryDto deliveryDto = @this.Deliveries.First();
		return new SuccessAdditionalOrderPopupViewModel.Parameter
		{
			Model = new AddGoodsOrderModel
			{
				Id = @this.OrderId,
				Status = @this.Status,
				DeliveryMethod = DeliveryMethod.Unknown,
				IsValid = true,
				Shop = new ShopInfoModel
				{
					Name = "",
					Address = "",
					PickupDescription = "",
					PickupPhotoUrls = Array.Empty<string>(),
					CollectOrder = null
				},
				Number = @this.OrderNumber,
				DeliveryDate = deliveryDto.DeliveryDate,
				DeliveryTime = MapDeliveryTime(deliveryDto.DeliveryTime),
				Products = @this.Products.Select((AddGoodsToOrderResposeDto.ProductDto i) => new ProductModel
				{
					ItemId = i.Id,
					ImageUrl = i.ImageUrl,
					Name = i.Name,
					Code = "",
					SelectedModifications = Array.Empty<SelectedModification>()
				}).ToImmutableList(),
				DeliveryAddress = "",
				Price = @this.OrderPrice,
				IsAdult = false,
				IsCanAddGoodsToOrder = false
			},
			OrderAdditionPrice = @this.OrderAdditionPrice
		};
	}
}
