using Auchan.Common.Common;
using Newtonsoft.Json;

namespace Auchan.Common.Ecom.ProducModels;

public sealed record ProductModificationValue
{
	public string Key { get; init; } = string.Empty;

	public string Description { get; init; } = string.Empty;

	public string PreviewImageUrl { get; init; } = string.Empty;

	[JsonConverter(typeof(ReadOnlyEquatableListConverter<string>))]
	public ReadOnlyEquatableList<string> ImageUrls { get; init; } = new ReadOnlyEquatableList<string>();
}
