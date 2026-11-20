using Auchan.Common.Home;

namespace Auchan.Common.Ecom.Products.ViewModels;

public class SubCategoryItemViewModel : CategoryItemViewModel
{
	public Category? Parent { get; }

	public SubCategoryItemViewModel(Category category, Category? parent = null)
		: base(category)
	{
		Parent = parent;
	}
}
