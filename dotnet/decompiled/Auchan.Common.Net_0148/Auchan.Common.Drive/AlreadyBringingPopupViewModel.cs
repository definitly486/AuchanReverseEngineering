using Auchan.Common.Base;

namespace Auchan.Common.Drive;

public class AlreadyBringingPopupViewModel : ScreenViewModel
{
	public string Title => "Уже несём!";

	public string Message => "Заказ уже собран и совсем скоро окажется у вас";

	public string ButtonText => "Хорошо";
}
