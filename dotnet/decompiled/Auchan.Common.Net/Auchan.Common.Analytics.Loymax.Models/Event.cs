namespace Auchan.Common.Analytics.Loymax.Models;

public sealed class Event
{
	public required string Type { get; init; }

	public required string MessageId { get; init; }
}
