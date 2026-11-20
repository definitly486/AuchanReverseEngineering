using Auchan.Common.Ecom.AddressStoreSelection;
using Auchan.Common.Profile.Orders.Enums;

namespace Auchan.Common.Profile.Orders.Extensions;

public static class OrderEnumExtensions
{
	public static string ConvertToString(this CustomerStatus status)
	{
		return status switch
		{
			CustomerStatus.Canceled => "Отменен", 
			CustomerStatus.Completed => "Заказ выполнен", 
			CustomerStatus.ReadyToIssue => "Готов к выдаче", 
			CustomerStatus.Delivered => "Доставлен", 
			CustomerStatus.OnWay => "В пути", 
			CustomerStatus.InProcessBuild => "В процессе сборки", 
			CustomerStatus.InForm => "В процессе оформления", 
			CustomerStatus.Takeout => "Уже несём!", 
			CustomerStatus.Accepted => "Принят", 
			_ => string.Empty, 
		};
	}

	public static string GetDelayNotificationText(this CustomerStatus status)
	{
		return status switch
		{
			CustomerStatus.InProcessBuild => "Задерживаемся, но скоро отправим к вам курьера", 
			CustomerStatus.OnWay => "Извините, курьер задерживается, но скоро будет у вас", 
			_ => string.Empty, 
		};
	}

	public static string ConvertToString(this DeliveryMethod method)
	{
		return method switch
		{
			DeliveryMethod.BySelf => "Магазин для самовывоза", 
			DeliveryMethod.Delivery => "Доставка по адресу", 
			DeliveryMethod.ExpressDelivery => "Быстрая доставка", 
			DeliveryMethod.Drive => "Авто", 
			_ => string.Empty, 
		};
	}

	public static bool IsDelivery(this DeliveryMethod deliveryMethod)
	{
		if (deliveryMethod != DeliveryMethod.Delivery)
		{
			return deliveryMethod == DeliveryMethod.ExpressDelivery;
		}
		return true;
	}

	public static ReceivingMethod ConvertToReceivingMethod(this DeliveryMethod method)
	{
		return method switch
		{
			DeliveryMethod.Delivery => ReceivingMethod.Delivery, 
			DeliveryMethod.ExpressDelivery => ReceivingMethod.ExpressDelivery, 
			DeliveryMethod.BySelf => ReceivingMethod.Pickup, 
			DeliveryMethod.Drive => ReceivingMethod.CarPickup, 
			_ => ReceivingMethod.RegionDefault, 
		};
	}

	public static string ConvertToString(this PaymentMethod method)
	{
		return method switch
		{
			PaymentMethod.Online => "Оплата картой", 
			PaymentMethod.Offline => "Оплата при получении", 
			_ => string.Empty, 
		};
	}

	public static bool IsInFinalState(this CustomerStatus status)
	{
		return status switch
		{
			CustomerStatus.Delivered => true, 
			CustomerStatus.Completed => true, 
			CustomerStatus.Canceled => true, 
			_ => false, 
		};
	}
}
