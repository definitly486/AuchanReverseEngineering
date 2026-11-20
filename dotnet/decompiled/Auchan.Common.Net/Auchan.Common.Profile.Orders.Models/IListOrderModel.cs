using System;
using System.Collections.Generic;
using System.Linq;
using Auchan.Common.Helpers;
using Auchan.Common.Profile.Orders.Enums;
using Auchan.Common.Profile.Orders.Extensions;

namespace Auchan.Common.Profile.Orders.Models;

public interface IListOrderModel : IOrderModel
{
	CustomerStatus Status { get; }

	DeliveryMethod DeliveryMethod { get; }

	bool IsValid { get; }

	ShopInfoModel Shop { get; }

	bool IsAuchanDriveOrder
	{
		get
		{
			if (IsValid)
			{
				return DeliveryMethod == DeliveryMethod.Drive;
			}
			return false;
		}
	}

	bool IsPickupOrder
	{
		get
		{
			if (IsValid)
			{
				return DeliveryMethod == DeliveryMethod.BySelf;
			}
			return false;
		}
	}

	bool StoreHasPickupPoint
	{
		get
		{
			if (IsValid)
			{
				return Shop.CollectOrder == true;
			}
			return false;
		}
	}

	bool IsReadyToReceive
	{
		get
		{
			if (IsAuchanDriveOrder || (IsPickupOrder && StoreHasPickupPoint))
			{
				return Status == CustomerStatus.ReadyToIssue;
			}
			return false;
		}
	}

	string Number { get; }

	bool HasChanges => Products.Any((ProductModel product) => product.HasChanges);

	bool NotChanged => !HasChanges;

	string HasChangesText => "Есть изменения";

	DateTimeOffset DeliveryDate { get; }

	string DeliveryTime { get; }

	IReadOnlyList<ProductModel> Products { get; }

	string DeliveryAddress { get; }

	decimal Price { get; }

	string NumberText => "№" + Number;

	string StatusText => Status.ConvertToString();

	string DateTimeText
	{
		get
		{
			string text = $"{DeliveryDate:M} {DeliveryDate:yyyy}";
			if (!string.IsNullOrWhiteSpace(DeliveryTime))
			{
				return text + ", с " + DeliveryTime.Replace(" - ", " до ");
			}
			return text;
		}
	}

	string GoodsCountText => $"{Products.Count} {GrammarHelper.DeclineNoun(Products.Count, new string[3] { "товар", "товара", "товаров" })}";

	string DeliveryDescriptionText => DeliveryMethod switch
	{
		DeliveryMethod.Delivery => "Доставка: " + DeliveryAddress, 
		DeliveryMethod.ExpressDelivery => "Быстрая доставка: " + DeliveryAddress, 
		DeliveryMethod.Drive => "Авто: АШАН " + Shop.Name.Replace("АШАН ", ""), 
		DeliveryMethod.BySelf => "Самовывоз: АШАН " + Shop.Name.Replace("АШАН ", ""), 
		_ => "", 
	};

	string PriceText => $"{Price:C2}";

	string? CourierNumber { get; }
}
