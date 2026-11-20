using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Auchan.Common.Ecom.ProducModels;

public sealed record Description
{
	public required string Content { get; init; }

	[CompilerGenerated]
	[SetsRequiredMembers]
	private Description(Description original)
	{
		Content = original.Content;
	}

	public Description()
	{
	}
}
