using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Auchan.Common.Common;
using Auchan.Common.Ecom.ProducModels;
using Newtonsoft.Json;

namespace Auchan.Common.Ecom.Cart.Models;

public sealed record ProductOfferKey
{
	public required long? Id { get; init; }

	public required long ProductId { get; init; }

	public required string? Code { get; init; }

	public required string? GimaId { get; init; }

	[JsonConverter(typeof(ReadOnlyEquatableListConverter<SelectedModification>))]
	public required ReadOnlyEquatableList<SelectedModification> SelectedModifications { get; init; }

	[CompilerGenerated]
	[SetsRequiredMembers]
	private ProductOfferKey(ProductOfferKey original)
	{
		Id = original.Id;
		ProductId = original.ProductId;
		Code = original.Code;
		GimaId = original.GimaId;
		SelectedModifications = original.SelectedModifications;
	}

	public ProductOfferKey()
	{
	}
}
