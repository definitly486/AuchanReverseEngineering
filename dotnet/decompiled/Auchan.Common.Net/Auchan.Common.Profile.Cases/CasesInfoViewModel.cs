using Auchan.Common.Base;
using Auchan.Common.Common.Binding;

namespace Auchan.Common.Profile.Cases;

public sealed class CasesInfoViewModel : ScreenViewModel
{
	public string Title { get; } = "Коммуникация по обращениям";

	public string Description { get; } = "Обращение - это вопрос, который нам не удалось решить сразу. Иногда нам необходима дополнительная информация. Если вы увидите, что мы ждем вашего ответа, пожалуйста, ответьте на наш вопрос в чате или ответным письмом по email";

	public string CloseButtonText { get; } = "Понятно";

	public UICommand CloseCommand { get; } = new UICommand();
}
