using Auchan.Common.Base;
using Auchan.Common.Navigation;

namespace Auchan.Common.Profile.Orders;

[RequiresAuthorization]
public sealed class AskDoYouWantToCancelOrderViewModel : ScreenViewModel
{
	public string ScreenTitle => "Хотите отменить заказ?";

	public string ProceedButtonText => "Да, отменить";

	public string CancelButtonText => "Нет, оставить";
}
