using System.Collections.Generic;
using Auchan.Common.Common;
using Auchan.Common.Networking;

namespace Auchan.Common.Ecom.Cart.Models;

public sealed class CheckoutData
{
	public required Recipient Recipient { get; init; }

	public required DeliveryMethod DeliveryMethod { get; init; }

	public required AdditionalBenefit? AdditionalBenefit { get; init; }

	public required ReadOnlyEquatableList<CheckoutProduct> Products { get; init; }

	public required ReadOnlyEquatableList<CheckoutProduct> AdultProducts { get; init; }

	public required Summary Summary { get; init; }

	public required IReadOnlyList<AvailablePayment> AvailablePayments { get; init; }

	public required IReadOnlyList<Replacement> Replacements { get; init; }

	public required bool NeedsRecalculate { get; init; }

	public VpnState VpnState { get; set; }
}
