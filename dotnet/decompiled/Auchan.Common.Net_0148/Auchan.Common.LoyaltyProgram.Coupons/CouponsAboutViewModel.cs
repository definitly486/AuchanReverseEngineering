using Auchan.Common.Base;
using Auchan.Common.Common.Binding;

namespace Auchan.Common.LoyaltyProgram.Coupons;

public class CouponsAboutViewModel : ScreenViewModel
{
	public UICommand CloseCommand { get; } = new UICommand();

	public string Title { get; } = "Собирайте купоны –\nполучайте скидки!";

	public string Description { get; } = "Бесплатная доставка, скидки, бонусные\nбаллы и не только!";

	public string HowToObtainTitle { get; } = "Как получить купоны?";

	public string HowToObtainDescriptionBuy { get; } = "Покупайте товары в приложении\nАШАН или\u00a0на сайте";

	public string HowToObtainDescriptionLook { get; } = "Смотрите, какие купоны вы получили";

	public string HowToObtainDescriptionUse { get; } = "Успевайте использовать купоны\nдо момента их сгорания";

	public string HowToUseTitle { get; } = "Как использовать купоны?";

	public string HowToUseDescriptionTitle { get; } = "В магазине АШАН:";

	public string HowToUseDescriptionDescription { get; } = "Выберите подходящий купон и покажите штрих-код кассиру, или отсканируйте его на кассе самообслуживания.";
}
