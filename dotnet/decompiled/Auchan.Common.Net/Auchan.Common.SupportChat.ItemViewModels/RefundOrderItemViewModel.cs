using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Auchan.Common.Helpers;

namespace Auchan.Common.SupportChat.ItemViewModels;

public sealed record RefundOrderItemViewModel
{
	public required SupportChatViewModel Parent { get; init; }

	public required string Name { get; init; }

	public required string? Store { get; init; }

	public required int? Quantity { get; init; }

	public required decimal? Amount { get; init; }

	public required RefundOrderStatus? Status { get; init; }

	public bool IsStoreVisible => Store != null;

	public bool IsQuantityVisible => Quantity.HasValue;

	public string QuantityText
	{
		get
		{
			if (!Quantity.HasValue)
			{
				return "";
			}
			return $"{Quantity} товар{GrammarHelper.DeclineNoun(Quantity.Value)}";
		}
	}

	public bool IsAmountVisible => Amount.HasValue;

	public string AmountText
	{
		get
		{
			if (!Amount.HasValue)
			{
				return "";
			}
			return $"{Amount:C2}";
		}
	}

	public bool IsStatusVisible => Status != null;

	[CompilerGenerated]
	[SetsRequiredMembers]
	private RefundOrderItemViewModel(RefundOrderItemViewModel original)
	{
		Parent = original.Parent;
		Name = original.Name;
		Store = original.Store;
		Quantity = original.Quantity;
		Amount = original.Amount;
		Status = original.Status;
	}

	public RefundOrderItemViewModel()
	{
	}
}
