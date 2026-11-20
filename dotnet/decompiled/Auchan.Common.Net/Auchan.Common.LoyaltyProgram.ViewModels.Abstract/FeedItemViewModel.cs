using Auchan.Common.Base;

namespace Auchan.Common.LoyaltyProgram.ViewModels.Abstract;

public abstract class FeedItemViewModel : BaseItemViewModel
{
	public virtual void OnItemsSelected(FeedItemViewModel item, int position)
	{
	}
}
