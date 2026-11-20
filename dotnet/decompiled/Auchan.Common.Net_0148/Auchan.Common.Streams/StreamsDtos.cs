using System.Collections.Generic;
using Newtonsoft.Json;

namespace Auchan.Common.Streams;

public class StreamsDtos
{
	public class StreamBlockDto
	{
		[JsonProperty("status")]
		public int? Status { get; set; }

		[JsonProperty("body")]
		public StreamsDto? Body { get; set; }
	}

	public class StreamsDto
	{
		[JsonProperty("plannedStreams")]
		public List<StreamDto>? PlannedStreams { get; set; }

		[JsonProperty("availableStreams")]
		public List<StreamDto>? AvailableStreams { get; set; }
	}

	public class StreamDto
	{
		[JsonProperty("id")]
		public string? Id { get; set; }

		[JsonProperty("application")]
		public string? Application { get; set; }

		[JsonProperty("name")]
		public string? Name { get; set; }

		[JsonProperty("description")]
		public string? Description { get; set; }

		[JsonProperty("previewImages")]
		public List<StreamImageDto>? PreviewImages { get; set; }
	}

	public class StreamImageDto
	{
		[JsonProperty("src")]
		public string? Src { get; set; }
	}

	public class ProductDto
	{
		[JsonProperty("id")]
		public string? Id { get; set; }

		[JsonProperty("name")]
		public string? Name { get; set; }

		[JsonProperty("url")]
		public string? Url { get; set; }
	}

	public class ProductJSDto
	{
		[JsonProperty("name")]
		public string? Name { get; set; }

		[JsonProperty("feedProductId")]
		public string? FeedProductId { get; set; }

		[JsonProperty("feedProductGroupId")]
		public string? FeedProductGroupId { get; set; }

		[JsonProperty("vendorCode")]
		public string? VendorCode { get; set; }
	}
}
