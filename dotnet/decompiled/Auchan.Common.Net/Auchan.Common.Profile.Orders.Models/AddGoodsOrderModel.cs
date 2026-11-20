using System;
using System.Collections.Generic;
using Auchan.Common.Profile.Orders.Enums;

namespace Auchan.Common.Profile.Orders.Models;

internal class AddGoodsOrderModel : IListOrderModel, IOrderModel
{
	public required CustomerStatus Status { get; init; }

	public required DeliveryMethod DeliveryMethod { get; init; }

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

	public string? CourierNumber => null;
}
