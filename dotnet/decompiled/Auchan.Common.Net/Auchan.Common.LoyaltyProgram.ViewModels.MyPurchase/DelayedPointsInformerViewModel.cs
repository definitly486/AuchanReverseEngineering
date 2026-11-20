using Auchan.Common.Base;
using Auchan.Common.Common.Binding;

namespace Auchan.Common.LoyaltyProgram.ViewModels.MyPurchase;

public class DelayedPointsInformerViewModel : ScreenViewModel
{
	public string Title => "Неактивные баллы";

	public string Description => "Баллы станут активными спустя 24 часа после покупки.\n\nБаллы, начисленные за непродовольственные товары, станут активны через 14 дней после покупки.";

	public UICommand CloseCommand { get; } = new UICommand();
}
