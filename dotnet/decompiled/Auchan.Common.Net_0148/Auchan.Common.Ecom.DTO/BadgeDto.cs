using Auchan.Common.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Auchan.Common.Ecom.DTO;

public class BadgeDto
{
	[JsonProperty("code")]
	[JsonConverter(typeof(EnumMemberJsonConverter<ProductBadge>))]
	public ProductBadge BadgeCode { get; init; }

	[JsonProperty("rang")]
	public int Rank { get; init; }

	[JsonProperty("mobile_image_link")]
	public string? ImageUrl { get; init; }

	[JsonProperty("description")]
	public string? Description { get; init; }

	[JsonProperty("meta")]
	public JObject? Metadata { get; init; }

	public T? ParseMetadata<T>() where T : class
	{
		try
		{
			JObject? metadata = Metadata;
			return (metadata != null) ? metadata.ToObject<T>() : null;
		}
		catch
		{
			return null;
		}
	}
}
