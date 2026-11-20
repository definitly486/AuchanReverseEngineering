namespace Auchan.Common.UniversalLinks;

public sealed class UniversalLinkServiceLinkEvent
{
	public required string Link { get; init; }

	public bool Handled { get; set; }
}
