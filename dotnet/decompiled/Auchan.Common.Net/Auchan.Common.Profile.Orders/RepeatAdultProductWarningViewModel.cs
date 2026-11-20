using Auchan.Common.Base;

namespace Auchan.Common.Profile.Orders;

public class RepeatAdultProductWarningViewModel : ScreenViewModel
{
	public string Title => "Этот товар доступен только для самовывоза";

	public string Description => "Вы хотите поменять способ получения заказа?";

	public string WarningInfoText => "При изменении способа получения заказа состав корзины может быть изменен";

	public string ButtonText => "Выбрать магазин";
}
