using Newtonsoft.Json;

namespace Auchan.Common.PersonalCabinet.DTO;

public sealed class ProfileInfoResult
{
	[JsonProperty("profile")]
	public ProfileInfo? Profile { get; set; }
}
