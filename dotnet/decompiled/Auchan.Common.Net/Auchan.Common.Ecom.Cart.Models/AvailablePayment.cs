using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Auchan.Common.Extensions;

namespace Auchan.Common.Ecom.Cart.Models;

public sealed record AvailablePayment
{
	public required PaymentCode Code { get; init; }

	public required bool IsAvailable { get; init; }

	public required int ItemsCount { get; init; }

	public required decimal Sum { get; init; }

	public string Name => Code switch
	{
		PaymentCode.Online => "Оплата онлайн", 
		PaymentCode.Offline => "Оплата при получении", 
		_ => "", 
	};

	public string QuantityText => ItemsCount.ToProductsCount();

	public string Price => $"{Sum:C2}";

	[CompilerGenerated]
	[SetsRequiredMembers]
	private AvailablePayment(AvailablePayment original)
	{
		Code = original.Code;
		IsAvailable = original.IsAvailable;
		ItemsCount = original.ItemsCount;
		Sum = original.Sum;
	}

	public AvailablePayment()
	{
	}
}
