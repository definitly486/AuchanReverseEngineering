using System;
using System.Collections.Generic;
using Auchan.Common.Ecom.Products.Modifications;

namespace Auchan.Common.Ecom.ProducModels;

public class ProductModification
{
	public string Code { get; set; } = string.Empty;

	public string Name { get; set; } = string.Empty;

	public ModificationValueType ViewType { get; set; }

	public IReadOnlyList<ProductModificationValue> Values { get; set; } = Array.Empty<ProductModificationValue>();
}
