using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Auchan.Common.Ecom.ProducModels;
using Auchan.Common.Ecom.Products;

namespace Auchan.Common.Profile.Orders.Models;

public sealed record AdditionalOrderProductItem
{
	public required long Id { get; init; }

	public required long ProductId { get; init; }

	public required int GimaId { get; init; }

	public required decimal BasketStep { get; init; }

	public required string? Title { get; init; }

	public string PricePerItemWithCount => GetPricePerUnit() + "  •  " + GetQtyByUnit();

	public required decimal CurrentQty { get; init; }

	public required Price Price { get; init; }

	public required Price PricePerItem { get; init; }

	public string AvailableQty => "Доступно: " + GetQtyByUnit();

	public bool AvailableQtyVisible => HaveConstraints;

	public required string ImageUrl { get; init; }

	public string PriceText => $"{Price?.Value:C2}";

	public required bool HaveConstraints { get; init; }

	public required bool IsSeparatorVisible { get; init; }

	private string GetPricePerUnit()
	{
		string value = Price?.UnitType switch
		{
			ProductUnitType.Unit => "шт", 
			ProductUnitType.Kilogram_1 => "кг", 
			ProductUnitType.Gram_100 => "100г", 
			_ => throw new NotSupportedException("dead code"), 
		};
		return $"{PricePerItem?.Value:C2}/{value}";
	}

	private string GetQtyByUnit()
	{
		string value = Price?.UnitType switch
		{
			ProductUnitType.Unit => "шт", 
			ProductUnitType.Kilogram_1 => "кг", 
			ProductUnitType.Gram_100 => "кг", 
			_ => throw new NotSupportedException("dead code"), 
		};
		return $"{CurrentQty} {value}";
	}

	[CompilerGenerated]
	[SetsRequiredMembers]
	private AdditionalOrderProductItem(AdditionalOrderProductItem original)
	{
		Id = original.Id;
		ProductId = original.ProductId;
		GimaId = original.GimaId;
		BasketStep = original.BasketStep;
		Title = original.Title;
		CurrentQty = original.CurrentQty;
		Price = original.Price;
		PricePerItem = original.PricePerItem;
		ImageUrl = original.ImageUrl;
		HaveConstraints = original.HaveConstraints;
		IsSeparatorVisible = original.IsSeparatorVisible;
	}

	public AdditionalOrderProductItem()
	{
	}
}
