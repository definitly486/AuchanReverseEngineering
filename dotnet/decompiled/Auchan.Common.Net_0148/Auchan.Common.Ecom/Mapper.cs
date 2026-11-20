using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Auchan.Common.Ecom.DTO;
using Auchan.Common.Ecom.ProducModels;

namespace Auchan.Common.Ecom;

public static class Mapper
{
	public static Category Map(this CategoryDto dto)
	{
		return new Category
		{
			Id = dto.Id,
			Code = dto.Code,
			PathCode = dto.PathCode,
			Icon = dto.Icon,
			Image = dto.Image,
			ImageUrl = dto.ImageUrl,
			IsAdult = (dto.IsAdult == true),
			Name = dto.Name,
			ProductsCount = dto.ProductsCount,
			ActiveProductsCount = dto.ActiveProductsCount,
			TopCategoryImageUrl = dto.TopCategoryImageUrl,
			DefaultSortMap = (((dto.DefaultSortMap?.Count ?? 0) != 3) ? null : dto.DefaultSortMap?.ToDictionary((KeyValuePair<int, ProductSortSelectionDto> kvp) => kvp.Key, (KeyValuePair<int, ProductSortSelectionDto> kvp) => kvp.Value.Map())),
			Items = (dto.Items?.Select((CategoryDto item) => item.Map()).ToImmutableList() ?? ImmutableList.Create(default(ReadOnlySpan<Category>)))
		};
	}

	public static Brand Map(this BrandResponseDto dto)
	{
		try
		{
			return new Brand(dto.Id, dto.Categories?.Select(Map).ToList() ?? new List<Category>());
		}
		catch (Exception)
		{
			return new Brand(dto.Id, new List<Category>());
		}
	}

	public static ProductSortSelection Map(this ProductSortSelectionDto dto)
	{
		return new ProductSortSelection
		{
			Direction = dto.Direction,
			Field = dto.Field
		};
	}
}
