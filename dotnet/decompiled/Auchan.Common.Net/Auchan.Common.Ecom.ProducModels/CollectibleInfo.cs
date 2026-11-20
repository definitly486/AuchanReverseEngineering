using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Auchan.Common.Ecom.ProducModels;

public sealed record CollectibleInfo
{
	public required int Stamps { get; init; }

	[CompilerGenerated]
	[SetsRequiredMembers]
	private CollectibleInfo(CollectibleInfo original)
	{
		Stamps = original.Stamps;
	}

	public CollectibleInfo()
	{
	}
}
