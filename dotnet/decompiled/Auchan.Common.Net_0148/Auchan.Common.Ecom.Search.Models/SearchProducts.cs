using System.Collections.Generic;
using Auchan.Common.Ecom.ProducModels;

namespace Auchan.Common.Ecom.Search.Models;

public class SearchProducts
{
	public required IReadOnlyList<Product> Products { get; init; }
}
