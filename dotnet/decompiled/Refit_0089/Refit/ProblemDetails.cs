using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Refit;

public class ProblemDetails
{
	public Dictionary<string, string[]> Errors { get; set; } = new Dictionary<string, string[]>();

	[JsonExtensionData]
	public IDictionary<string, object> Extensions { get; set; } = new Dictionary<string, object>(StringComparer.Ordinal);

	public string? Type { get; set; } = "about:blank";

	public string? Title { get; set; }

	public int Status { get; set; }

	public string? Detail { get; set; }

	public string? Instance { get; set; }
}
