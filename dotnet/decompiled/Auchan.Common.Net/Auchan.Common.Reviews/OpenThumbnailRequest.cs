using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Auchan.Common.Reviews;

public sealed record OpenThumbnailRequest
{
	public required IReadOnlyList<string> Urls { get; init; }

	public required int Index { get; init; }

	[CompilerGenerated]
	[SetsRequiredMembers]
	private OpenThumbnailRequest(OpenThumbnailRequest original)
	{
		Urls = original.Urls;
		Index = original.Index;
	}

	public OpenThumbnailRequest()
	{
	}
}
