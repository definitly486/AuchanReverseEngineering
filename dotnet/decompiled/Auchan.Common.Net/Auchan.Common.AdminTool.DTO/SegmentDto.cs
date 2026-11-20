using Newtonsoft.Json;

namespace Auchan.Common.AdminTool.DTO;

public class SegmentDto
{
	[JsonProperty("id", Required = Required.Always)]
	public int Id { get; set; }

	[JsonProperty("segment_id", Required = Required.Always)]
	public int SegmentId { get; set; }

	[JsonProperty("created_at", Required = Required.Always)]
	public string CreatedAt { get; set; }

	[JsonProperty("updated_at", Required = Required.Always)]
	public string UpdatedAt { get; set; }
}
