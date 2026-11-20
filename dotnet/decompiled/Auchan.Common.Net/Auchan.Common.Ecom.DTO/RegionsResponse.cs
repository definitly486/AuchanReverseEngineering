using System.Collections.Generic;
using Auchan.Common.Networking;
using Newtonsoft.Json;

namespace Auchan.Common.Ecom.DTO;

public class RegionsResponse : IVpnStateDto
{
	[JsonProperty("regions", Required = Required.Always)]
	public required IReadOnlyList<RegionBundleDto> Regions { get; init; }

	[JsonProperty("regionDefault", Required = Required.Always)]
	public required RegionBundleDto Default { get; init; }

	[JsonIgnore]
	public VpnState VpnState { get; set; }
}
