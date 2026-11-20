using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Auchan.Common.Base;
using Auchan.Common.Ecom.Cart.Models;
using Auchan.Common.Profile.Orders.Enums;
using Auchan.Common.Profile.Orders.Models;

namespace Auchan.Common.Ecom.Cart.ViewModels;

public class CheckoutItemViewModel : BaseItemViewModel
{
	public int MaxVisibleCells => 4;

	public CheckoutOrderDetails Order { get; }

	public string OrderNumber => "Заказ №" + Order.Number;

	public string TotalPrice => $"{Order.Price:C2}";

	public string DeliveryTypeAndTime => GetDeliveryTypeAndTime();

	public bool IsPayed => Order.IsPayed;

	public IReadOnlyList<string?> ImageUrls => Order.Products.Select((ProductModel x) => x.ImageUrl).Take(5).ToImmutableList() ?? ImmutableList.Create(default(ReadOnlySpan<string>));

	public string PlusNProductsText
	{
		get
		{
			if (ImageUrls.Count > 4)
			{
				int value = ProductsCount - 4;
				return $"+{value}";
			}
			return string.Empty;
		}
	}

	public string PaymentStatus
	{
		get
		{
			if (!IsPayed)
			{
				if (Order.PaymentMethod != 2)
				{
					return "Ожидает оплаты";
				}
				return "Оплата при получении";
			}
			return Order.StatusText;
		}
	}

	public string PaymentType
	{
		get
		{
			if (Order.PaymentMethod != 2)
			{
				return "Оплата онлайн";
			}
			return "Оплата при получении";
		}
	}

	public int ProductsCount => Order.Products.Count;

	public string DateWithPaymentType => $"от {Date} ({PaymentType})";

	private string Date => $"{Order.DeliveryDate:dd.MM.yyyy}";

	private string DateWithOptionalTime
	{
		get
		{
			if (!string.IsNullOrWhiteSpace(Order.DeliveryTime))
			{
				return Date + " · " + Order.DeliveryTime;
			}
			return Date;
		}
	}

	public CheckoutItemViewModel(CheckoutOrderDetails orderDetails)
	{
		Order = orderDetails;
	}

	private string GetDeliveryTypeAndTime()
	{
		return Order.DeliveryMethod switch
		{
			Auchan.Common.Profile.Orders.Enums.DeliveryMethod.Delivery => "Доставка: " + DateWithOptionalTime, 
			Auchan.Common.Profile.Orders.Enums.DeliveryMethod.BySelf => "Самовывоз: " + DateWithOptionalTime, 
			Auchan.Common.Profile.Orders.Enums.DeliveryMethod.Drive => "Авто: " + DateWithOptionalTime, 
			Auchan.Common.Profile.Orders.Enums.DeliveryMethod.ExpressDelivery => "Быстрая доставка: " + DateWithOptionalTime, 
			_ => string.Empty, 
		};
	}
}
