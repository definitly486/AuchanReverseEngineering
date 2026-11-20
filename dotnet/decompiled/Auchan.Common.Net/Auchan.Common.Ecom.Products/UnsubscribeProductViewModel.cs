using Auchan.Common.Base;
using Auchan.Common.Navigation;

namespace Auchan.Common.Ecom.Products;

public class UnsubscribeProductViewModel : ScreenViewModel
{
	public string Title => "Отменить подписку на товар?";

	public string Message => "Вы уверены, что хотите отписаться от уведомлений о наличии товара?";

	public string YesButtonText => "Да, отписаться";

	public string NoButtonText => "Нет, оставить";

	public override NavigationPossibilityType OnNavigateFrom()
	{
		return NavigationPossibilityType.Impossible;
	}
}
