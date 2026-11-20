using System;
using System.Collections.Generic;
using System.Linq;
using Auchan.Common.Ecom.ProducModels;
using Newtonsoft.Json;

namespace Auchan.Common.Ecom;

public sealed class Category
{
	public long Id { get; init; }

	public required string Code { get; init; }

	public string? PathCode { get; init; }

	public bool IsAdult { get; init; }

	public required string Name { get; init; }

	public string? Icon { get; init; }

	public IReadOnlyList<Category> Items { get; init; } = Array.Empty<Category>();

	public string? Image { get; init; }

	public string? ImageUrl { get; set; }

	public string? TopCategoryImageUrl { get; init; }

	public int ProductsCount { get; init; }

	public int ActiveProductsCount { get; init; }

	[JsonIgnore]
	public bool HasChildCategories
	{
		get
		{
			if (Items != null)
			{
				return Items.Count > 0;
			}
			return false;
		}
	}

	[JsonIgnore]
	public int CategoryLevel
	{
		get
		{
			if (Items == null || Items.Count == 0)
			{
				return 3;
			}
			if (Items.All((Category i) => i.CategoryLevel == 3))
			{
				return 2;
			}
			return 1;
		}
	}

	[JsonIgnore]
	public Dictionary<int, ProductSortSelection>? DefaultSortMap { get; init; }

	[JsonIgnore]
	public bool Expandable { get; init; } = true;

	[JsonIgnore]
	public string? ImageUrlForIndexing { get; set; }
}
