using Auchan.Common.Common;
using Auchan.Common.Common.Binding;
using Auchan.Common.LoyaltyProgram.ViewModels.Abstract;

namespace Auchan.Common.LoyaltyProgram.ViewModels.MyPurchase.FeedItems;

public sealed class DeleayedPointsInformerItemViewModel : FeedItemViewModel
{
	public LinkedText Description { get; }

	public DeleayedPointsInformerItemViewModel(UICommand showDelayedPointsInfoCommand)
	{
		Description = new LinkedText("Баллы станут активными спустя 24 часа после покупки. Подробнее", "Подробнее", delegate
		{
			showDelayedPointsInfoCommand.Trigger();
		});
	}
}
