namespace Auchan.Common.Ecom.ProducModels;

public sealed class RequestRedirect
{
	public required string RedirectFrom { get; init; }

	public required string RedirectTo { get; init; }
}
