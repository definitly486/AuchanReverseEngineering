namespace Auchan.Common.Addresses;

public sealed record Suggestion
{
	public int? RegionId { get; init; }

	public bool IsFull { get; init; }

	public DeliveryAddress? Address { get; init; }
}
