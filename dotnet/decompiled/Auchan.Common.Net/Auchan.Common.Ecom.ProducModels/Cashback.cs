using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Auchan.Common.Ecom.ProducModels;

public sealed record Cashback
{
	public required int Amount { get; init; }

	public required CashbackCalculationType CalculationType { get; init; }

	public required LimitType LimitType { get; init; }

	public required decimal Limit { get; init; }

	public required CashbackType Type { get; init; }

	[CompilerGenerated]
	[SetsRequiredMembers]
	private Cashback(Cashback original)
	{
		Amount = original.Amount;
		CalculationType = original.CalculationType;
		LimitType = original.LimitType;
		Limit = original.Limit;
		Type = original.Type;
	}

	public Cashback()
	{
	}
}
