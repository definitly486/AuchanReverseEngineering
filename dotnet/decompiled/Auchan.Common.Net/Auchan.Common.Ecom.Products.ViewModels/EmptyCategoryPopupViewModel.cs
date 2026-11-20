using Auchan.Common.Base;

namespace Auchan.Common.Ecom.Products.ViewModels;

public class EmptyCategoryPopupViewModel : ScreenViewModel
{
	public string Title => "Мы наполняем полки!";

	public string Description => "Категория активна – в этом магазине товаров пока нет, но в других они уже доступны.";

	public string ButtonText => "Вернуться";
}
