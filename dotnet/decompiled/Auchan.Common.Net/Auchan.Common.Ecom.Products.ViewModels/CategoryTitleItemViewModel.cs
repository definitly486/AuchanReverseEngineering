using Auchan.Common.Base;

namespace Auchan.Common.Ecom.Products.ViewModels;

public class CategoryTitleItemViewModel : BaseItemViewModel
{
	public string Title { get; }

	public int TitlePosition { get; }

	public CategoryTitleItemViewModel(string title, int titlePosition)
	{
		Title = title;
		TitlePosition = titlePosition;
	}
}
