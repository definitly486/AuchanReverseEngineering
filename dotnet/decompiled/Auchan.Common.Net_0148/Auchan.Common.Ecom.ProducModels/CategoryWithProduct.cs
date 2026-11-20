using System.Collections.Generic;

namespace Auchan.Common.Ecom.ProducModels;

public class CategoryWithProduct
{
	public string? Name { get; set; }

	public string? ParentCategoryCode { get; set; }

	public string? ParentCategoryName { get; set; }

	public List<Product>? Products { get; set; }

	public bool IsAdult { get; set; }
}
