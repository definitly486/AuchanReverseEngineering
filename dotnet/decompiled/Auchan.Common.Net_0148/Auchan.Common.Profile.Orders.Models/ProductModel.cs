using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Auchan.Common.Common;
using Auchan.Common.Ecom.ProducModels;

namespace Auchan.Common.Profile.Orders.Models;

public sealed record ProductModel : IWithImageUrl
{
	public string? ImageUrl { get; init; }

	public required string Name { get; init; }

	public decimal Price { get; init; }

	public decimal PriceInit { get; init; }

	public bool HasChanges => Math.Abs(Qty - QtyInit) > 0.001m;

	public decimal Qty { get; init; }

	public decimal QtyInit { get; init; }

	public decimal Weight { get; init; }

	public bool ProductTypeIsPerKilo { get; set; }

	public required string Code { get; set; }

	public required IReadOnlyList<SelectedModification> SelectedModifications { get; init; }

	public int ItemId { get; init; }

	public int? SourceItemId { get; init; }

	public int? DestItemId { get; init; }

	public string GimaId { get; init; } = string.Empty;

	public decimal CalculateWeight()
	{
		if (ProductTypeIsPerKilo)
		{
			return Qty;
		}
		return Weight * Qty;
	}

	[CompilerGenerated]
	[SetsRequiredMembers]
	private ProductModel(ProductModel original)
	{
		ImageUrl = original.ImageUrl;
		Name = original.Name;
		Price = original.Price;
		PriceInit = original.PriceInit;
		Qty = original.Qty;
		QtyInit = original.QtyInit;
		Weight = original.Weight;
		ProductTypeIsPerKilo = original.ProductTypeIsPerKilo;
		Code = original.Code;
		SelectedModifications = original.SelectedModifications;
		ItemId = original.ItemId;
		SourceItemId = original.SourceItemId;
		DestItemId = original.DestItemId;
		GimaId = original.GimaId;
	}

	public ProductModel()
	{
	}
}
