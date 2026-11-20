using System.Collections.Generic;

namespace Auchan.Common.Ecom.Cart.Models;

public sealed class RecalculateResult
{
	public required IReadOnlyList<CheckoutDate>? Dates { get; init; }

	public required decimal? MinSlotPrice { get; init; }

	public required AdditionalBenefit? AdditionalBenefit { get; init; }

	public required Summary Summary { get; init; }

	public required IReadOnlyList<AvailablePayment> AvailablePayments { get; init; }
}
