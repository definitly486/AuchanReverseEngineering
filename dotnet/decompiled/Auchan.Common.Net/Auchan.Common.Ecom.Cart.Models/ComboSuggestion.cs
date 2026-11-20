using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Auchan.Common.Ecom.Cart.Models;

public sealed record ComboSuggestion
{
	public required ComboSuggestionStatus Status { get; init; }

	public required string Tooltip { get; init; }

	[CompilerGenerated]
	[SetsRequiredMembers]
	private ComboSuggestion(ComboSuggestion original)
	{
		Status = original.Status;
		Tooltip = original.Tooltip;
	}

	public ComboSuggestion()
	{
	}
}
