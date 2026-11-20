using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Auchan.Common.Profile.Orders.Enums;
using Auchan.Common.Profile.Orders.Extensions;
using Auchan.Common.Profile.Orders.Models;

namespace Auchan.Common.Ecom.Cart.ViewModels;

public sealed record CartPreviousOrderItemViewModel
{
	public string Title => "Добавить товары в текущий заказ?";

	public string Description { get; }

	public string ButtonText => "Да, добавить";

	public string HintText { get; }

	public long OrderId => _order.Id;

	private readonly OrderToAdditionModel _order;

	public CartPreviousOrderItemViewModel(OrderToAdditionModel order)
	{
		_order = order;
		Description = GetDescription(order);
		HintText = $"Заказ №{_order.Number} на {_order.Price:C2}.{"\n"}{(_order.DeliveryMethod.IsDelivery() ? _order.DeliveryPlace : GetShopName(_order.ShopName))}.";
	}

	private static string GetDescription(OrderToAdditionModel order)
	{
		StringBuilder stringBuilder = new StringBuilder();
		switch (order.DeliveryMethod)
		{
		case DeliveryMethod.Delivery:
			stringBuilder.Append("Доставка ");
			break;
		case DeliveryMethod.ExpressDelivery:
			stringBuilder.Append("Быстрая доставка ");
			break;
		case DeliveryMethod.BySelf:
			stringBuilder.Append("Самовывоз ");
			break;
		case DeliveryMethod.Drive:
			stringBuilder.Append("Авто ");
			break;
		}
		StringBuilder stringBuilder2 = stringBuilder;
		StringBuilder stringBuilder3 = stringBuilder2;
		StringBuilder.AppendInterpolatedStringHandler handler = new StringBuilder.AppendInterpolatedStringHandler(0, 1, stringBuilder2);
		handler.AppendFormatted(order.DeliveryDate, "M");
		stringBuilder3.Append(ref handler);
		if (!string.IsNullOrWhiteSpace(order.DeliveryTime))
		{
			stringBuilder2 = stringBuilder;
			StringBuilder stringBuilder4 = stringBuilder2;
			handler = new StringBuilder.AppendInterpolatedStringHandler(3, 1, stringBuilder2);
			handler.AppendLiteral(" с ");
			handler.AppendFormatted(order.DeliveryTime);
			stringBuilder4.Append(ref handler);
		}
		DateTimeOffset utcNow = DateTimeOffset.UtcNow;
		if (utcNow.Year == order.EditableTill.Year && utcNow.DayOfYear == order.EditableTill.DayOfYear)
		{
			stringBuilder2 = stringBuilder;
			StringBuilder stringBuilder5 = stringBuilder2;
			handler = new StringBuilder.AppendInterpolatedStringHandler(27, 1, stringBuilder2);
			handler.AppendLiteral(", товары можно добавить до ");
			handler.AppendFormatted(order.EditableTill, "t");
			stringBuilder5.Append(ref handler);
		}
		return stringBuilder.ToString();
	}

	private static string GetShopName(string rawShopName)
	{
		return "АШАН " + rawShopName.Replace("АШАН ", "");
	}

	[CompilerGenerated]
	private bool PrintMembers(StringBuilder builder)
	{
		RuntimeHelpers.EnsureSufficientExecutionStack();
		builder.Append("Title = ");
		builder.Append((object?)"Добавить товары в текущий заказ?");
		builder.Append(", Description = ");
		builder.Append((object?)Description);
		builder.Append(", ButtonText = ");
		builder.Append((object?)"Да, добавить");
		builder.Append(", HintText = ");
		builder.Append((object?)HintText);
		builder.Append(", OrderId = ");
		builder.Append(OrderId.ToString());
		return true;
	}

	[CompilerGenerated]
	public override int GetHashCode()
	{
		return ((EqualityComparer<Type>.Default.GetHashCode(EqualityContract) * -1521134295 + EqualityComparer<OrderToAdditionModel>.Default.GetHashCode(_order)) * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Description)) * -1521134295 + EqualityComparer<string>.Default.GetHashCode(HintText);
	}

	[CompilerGenerated]
	public bool Equals(CartPreviousOrderItemViewModel? other)
	{
		if ((object)this != other)
		{
			if ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<OrderToAdditionModel>.Default.Equals(_order, other._order) && EqualityComparer<string>.Default.Equals(Description, other.Description))
			{
				return EqualityComparer<string>.Default.Equals(HintText, other.HintText);
			}
			return false;
		}
		return true;
	}

	[CompilerGenerated]
	private CartPreviousOrderItemViewModel(CartPreviousOrderItemViewModel original)
	{
		_order = original._order;
		Description = original.Description;
		HintText = original.HintText;
	}
}
