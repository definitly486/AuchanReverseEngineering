using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Auchan.Common.Ecom.DTO;
using Auchan.Common.Profile.Orders.Enums;
using Auchan.Common.Profile.Orders.Models;

namespace Auchan.Common.Ecom.Cart.Models;

public sealed record CheckoutOrderDetails : IListOrderModel, IOrderModel
{
	public required OrderDetailsDto Dto { get; init; }

	public CustomerStatus Status
	{
		get
		{
			if (!IsPayed)
			{
				return CustomerStatus.InForm;
			}
			return CustomerStatus.ReadyToIssue;
		}
	}

	public required Auchan.Common.Profile.Orders.Enums.DeliveryMethod DeliveryMethod { get; init; }

	public required bool IsValid { get; init; }

	public required ShopInfoModel Shop { get; init; }

	public required string Number { get; init; }

	public required DateTimeOffset DeliveryDate { get; init; }

	public required string DeliveryTime { get; init; }

	public required IReadOnlyList<ProductModel> Products { get; init; }

	public required string DeliveryAddress { get; init; }

	public required decimal Price { get; init; }

	public required long Id { get; init; }

	public required bool IsAdult { get; init; }

	public required bool IsCanAddGoodsToOrder { get; init; }

	public required bool IsPayed { get; init; }

	public required long PaymentMethod { get; init; }

	public required string StatusText { get; init; }

	public string? CourierNumber => null;

	[CompilerGenerated]
	[SetsRequiredMembers]
	private CheckoutOrderDetails(CheckoutOrderDetails original)
	{
		Dto = original.Dto;
		DeliveryMethod = original.DeliveryMethod;
		IsValid = original.IsValid;
		Shop = original.Shop;
		Number = original.Number;
		DeliveryDate = original.DeliveryDate;
		DeliveryTime = original.DeliveryTime;
		Products = original.Products;
		DeliveryAddress = original.DeliveryAddress;
		Price = original.Price;
		Id = original.Id;
		IsAdult = original.IsAdult;
		IsCanAddGoodsToOrder = original.IsCanAddGoodsToOrder;
		IsPayed = original.IsPayed;
		PaymentMethod = original.PaymentMethod;
		StatusText = original.StatusText;
	}

	public CheckoutOrderDetails()
	{
	}
}
