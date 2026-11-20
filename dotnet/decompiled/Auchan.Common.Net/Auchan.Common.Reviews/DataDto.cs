using System.Collections.Generic;
using Newtonsoft.Json;

namespace Auchan.Common.Reviews;

public class DataDto
{
	[JsonProperty("images")]
	public IEnumerable<int>? Images { get; set; }
}
