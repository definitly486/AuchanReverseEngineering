using Auchan.Common.Base;

namespace Auchan.Common.SupportChat.ItemViewModels;

public abstract class BaseSupportChatItemViewModel : BaseItemViewModel
{
	public virtual bool ShouldBeDisplayed => true;
}
