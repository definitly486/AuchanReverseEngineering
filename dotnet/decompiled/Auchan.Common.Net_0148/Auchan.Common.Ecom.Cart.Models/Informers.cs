using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Auchan.Common.Ecom.Cart.Models;

public sealed record Informers
{
	public required string? TwoMechanicInformer { get; init; }

	public required string? PointsInformer { get; init; }

	public required string? AlcoholInformer { get; init; }

	[CompilerGenerated]
	[SetsRequiredMembers]
	private Informers(Informers original)
	{
		TwoMechanicInformer = original.TwoMechanicInformer;
		PointsInformer = original.PointsInformer;
		AlcoholInformer = original.AlcoholInformer;
	}

	public Informers()
	{
	}
}
