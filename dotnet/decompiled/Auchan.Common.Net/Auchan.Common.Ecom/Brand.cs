using System.Collections.Generic;

namespace Auchan.Common.Ecom;

public class Brand
{
	public int Id { get; }

	public List<Category> Categories { get; }

	public Brand(int id, List<Category> categories)
	{
		Id = id;
		Categories = categories;
	}
}
