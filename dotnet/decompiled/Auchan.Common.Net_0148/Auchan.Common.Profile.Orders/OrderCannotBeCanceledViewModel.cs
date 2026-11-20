using Auchan.Common.Base;
using Auchan.Common.Navigation;

namespace Auchan.Common.Profile.Orders;

[RequiresAuthorization]
public sealed class OrderCannotBeCanceledViewModel : ScreenViewModel
{
	public string ScreenTitle => "Отмена заказа недоступна";

	public string DescriptionText => "К сожалению, сейчас мы не можем отменить ваш заказ";

	public string CallSupportButtonText => "Связаться с поддержкой";
}
