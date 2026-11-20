using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Auchan.Common.Ecom.ProducModels;

public sealed record SelectedModification
{
	public required string Code { get; init; }

	public required string Name { get; init; }

	public required ProductModificationValue Value { get; init; }

	[CompilerGenerated]
	[SetsRequiredMembers]
	private SelectedModification(SelectedModification original)
	{
		Code = original.Code;
		Name = original.Name;
		Value = original.Value;
	}

	public SelectedModification()
	{
	}
}
