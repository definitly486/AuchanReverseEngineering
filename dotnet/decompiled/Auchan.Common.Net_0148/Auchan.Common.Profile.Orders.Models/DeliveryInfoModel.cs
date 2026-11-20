using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Auchan.Common.Profile.Orders.Enums;

namespace Auchan.Common.Profile.Orders.Models;

public sealed record DeliveryInfoModel
{
	public required DateTimeOffset DeliveryDate { get; init; }

	public required string DeliveryTime { get; set; }

	public required string DeliveryToTime { get; init; }

	public required DeliveryMethod DeliveryMethod { get; init; }

	public required string Address { get; init; }

	public required string Region { get; set; }

	public required string Area { get; init; }

	public required string City { get; init; }

	public required string Street { get; init; }

	public required string House { get; init; }

	public required string Block { get; init; }

	public required string Flat { get; init; }

	public required string Floor { get; init; }

	public required string Porch { get; init; }

	public required string Comment { get; init; }

	public required double GeoLat { get; init; }

	public required double GeoLon { get; init; }

	public required IReadOnlyList<ProductModel> Products { get; init; }

	public required string? CourierNumber { get; init; }

	[CompilerGenerated]
	[SetsRequiredMembers]
	private DeliveryInfoModel(DeliveryInfoModel original)
	{
		DeliveryDate = original.DeliveryDate;
		DeliveryTime = original.DeliveryTime;
		DeliveryToTime = original.DeliveryToTime;
		DeliveryMethod = original.DeliveryMethod;
		Address = original.Address;
		Region = original.Region;
		Area = original.Area;
		City = original.City;
		Street = original.Street;
		House = original.House;
		Block = original.Block;
		Flat = original.Flat;
		Floor = original.Floor;
		Porch = original.Porch;
		Comment = original.Comment;
		GeoLat = original.GeoLat;
		GeoLon = original.GeoLon;
		Products = original.Products;
		CourierNumber = original.CourierNumber;
	}

	public DeliveryInfoModel()
	{
	}
}
