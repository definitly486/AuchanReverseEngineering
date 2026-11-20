using System;
using System.Linq;
using Auchan.Common.Extensions;
using Auchan.Common.Profile.Orders.Enums;
using Auchan.Common.Profile.Orders.Models;

namespace Auchan.Common.Profile.Orders.Extensions;

public static class OrderExtensions
{
	public static string GetNearestOrderStatusDescription(this OrderListModel? Order)
	{
		switch (Order?.Status)
		{
		case CustomerStatus.OnWay:
			if (Order.IsDelayed && Order.DeliveryMethod.IsDelivery())
			{
				return "Извините, курьер задерживается, но скоро будет у вас";
			}
			return FormatCourierDescription(Order);
		case CustomerStatus.InProcessBuild:
			if (Order.IsDelayed && Order.DeliveryMethod.IsDelivery())
			{
				return "Задерживаемся, но скоро отправим к вам курьера";
			}
			if (Order.DeliveryMethod.IsDelivery())
			{
				return FormatInProcessBuildDescription(Order);
			}
			return Order.SelectStringByDeliveryState("Сборщик ищет самые качественные товары и\u00a0проверяет сроки годности. Доставим {1} до\u00a0{0}", "Сборщик ищет самые качественные товары и\u00a0проверяет сроки годности", "Сборщик ищет самые качественные товары и\u00a0проверяет сроки годности");
		case CustomerStatus.ReadyToIssue:
			return Order.SelectStringByDeliveryState("", "Приходите за заказом {1} до {0}", "Приезжайте на специальное место на\u00a0парковке {1} до {0}");
		case CustomerStatus.InForm:
			if (Order.DeliveryMethod == DeliveryMethod.ExpressDelivery)
			{
				return "Скоро начнем его собирать";
			}
			return Order.SelectStringByDeliveryState("Скоро начнем его собирать. Доставим {1} до {0}", "Скоро начнем его собирать", "Скоро начнем его собирать");
		case CustomerStatus.Takeout:
			return "Сотрудник спешит вынести ваш заказ";
		case CustomerStatus.Accepted:
			if (Order.DeliveryMethod == DeliveryMethod.ExpressDelivery)
			{
				return "Скоро начнем его собирать";
			}
			return Order.SelectStringByDeliveryState("Заказ будет передан на сборку ближе ко времени доставки", "Заказ будет передан на сборку ближе ко времени получения", "Заказ будет передан на сборку ближе ко времени получения");
		default:
			return string.Empty;
		}
	}

	private static string SelectStringByDeliveryState(this OrderListModel? order, string delivery, string bySelf, string drive)
	{
		return order?.DeliveryMethod switch
		{
			DeliveryMethod.Delivery => FormatOrderDateTimeString(order, delivery), 
			DeliveryMethod.BySelf => FormatOrderDateTimeString(order, bySelf), 
			DeliveryMethod.Drive => FormatOrderDateTimeString(order, drive), 
			DeliveryMethod.ExpressDelivery => FormatOrderDateTimeString(order, delivery), 
			_ => string.Empty, 
		};
	}

	private static string FormatOrderDateTimeString(OrderListModel order, string format)
	{
		string todayTomorrowOrDate = order.DeliveryDate.GetTodayTomorrowOrDate((DateTimeOffset dto) => dto.ToString("dd.MM"));
		string deliveryTimeLastPart = GetDeliveryTimeLastPart(order.DeliveryTime);
		if (string.IsNullOrWhiteSpace(deliveryTimeLastPart))
		{
			return string.Format(format.Replace(" до {0}", "").Replace(" до\u00a0{0}", ""), string.Empty, todayTomorrowOrDate);
		}
		return string.Format(format, deliveryTimeLastPart, todayTomorrowOrDate);
	}

	private static string FormatInProcessBuildDescription(OrderListModel order)
	{
		string todayTomorrowOrDate = order.DeliveryDate.GetTodayTomorrowOrDate((DateTimeOffset dto) => dto.ToString("dd.MM"));
		string text = "Сборщик ищет самые качественные товары и\u00a0проверяет сроки годности. Доставим " + todayTomorrowOrDate;
		if (!string.IsNullOrWhiteSpace(order.DeliveryToTime))
		{
			return text + " " + order.DeliveryToTime;
		}
		return text;
	}

	private static string FormatCourierDescription(OrderListModel order)
	{
		string deliveryToTime = order.DeliveryToTime;
		if (!string.IsNullOrWhiteSpace(deliveryToTime))
		{
			return "Курьер спешит доставить заказ " + deliveryToTime;
		}
		return "Курьер спешит доставить заказ " + order.DeliveryDate.GetTodayTomorrowOrDate((DateTimeOffset dto) => dto.ToString("dd.MM"));
	}

	private static string? GetDeliveryTimeLastPart(string? deliveryTime)
	{
		if (string.IsNullOrWhiteSpace(deliveryTime))
		{
			return null;
		}
		return deliveryTime.Split('-', StringSplitOptions.RemoveEmptyEntries).LastOrDefault()?.Trim();
	}

	public static TimeSpan MapDeliveryTimeStart(this OrderListModel order)
	{
		if (TimeSpan.TryParse(order.GetDeliveryTimeFirstPart() ?? "00:00", out var result))
		{
			return result;
		}
		return default(TimeSpan);
	}

	public static string? GetDeliveryTimeFirstPart(this OrderListModel order)
	{
		return order.DeliveryTime.Split('-', StringSplitOptions.RemoveEmptyEntries).FirstOrDefault()?.Trim();
	}

	public static TimeSpan MapDeliveryTimeEnd(this OrderListModel order)
	{
		if (TimeSpan.TryParse(order.GetDeliveryTimeLastPart() ?? "00:00", out var result))
		{
			return result;
		}
		return default(TimeSpan);
	}

	public static string? GetDeliveryTimeLastPart(this OrderListModel order)
	{
		return order.DeliveryTime.Split('-', StringSplitOptions.RemoveEmptyEntries).LastOrDefault()?.Trim();
	}

	public static string ConvertToNearestOrderStatusString(this IListOrderModel orderModel)
	{
		switch (orderModel.Status)
		{
		case CustomerStatus.ReadyToIssue:
			return "Заказ готов к выдаче";
		case CustomerStatus.OnWay:
			return "Заказ в пути";
		case CustomerStatus.InProcessBuild:
			return "Бережно собираем ваш заказ";
		case CustomerStatus.InForm:
			if (orderModel.DeliveryMethod == DeliveryMethod.ExpressDelivery)
			{
				return "Мы приняли ваш заказ";
			}
			return "Заказ принят";
		case CustomerStatus.Takeout:
			if (orderModel.IsAuchanDriveOrder)
			{
				return "Уже несем!";
			}
			return "Несем ваш заказ";
		case CustomerStatus.Accepted:
			return "Мы приняли ваш заказ";
		default:
			return string.Empty;
		}
	}
}
