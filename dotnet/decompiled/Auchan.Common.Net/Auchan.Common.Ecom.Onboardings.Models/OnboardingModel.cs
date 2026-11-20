using System.Collections.Generic;
using System.Drawing;
using Auchan.Common.Ecom.AddressStoreSelection;

namespace Auchan.Common.Ecom.Onboardings.Models;

public sealed class OnboardingModel
{
	public required int Id { get; init; }

	public required string Name { get; init; }

	public required IReadOnlyList<ShowAt> ShowAt { get; init; }

	public required int Priority { get; init; }

	public required int ShowCount { get; init; }

	public required string Title { get; init; }

	public required Color TitleColor { get; init; }

	public required string Description { get; init; }

	public required IOnboardingDecoration Decoration { get; init; }

	public required IOnboardingAction Action { get; init; }

	public required IReadOnlyList<ReceivingMethod> ReceivingMethods { get; init; }
}
