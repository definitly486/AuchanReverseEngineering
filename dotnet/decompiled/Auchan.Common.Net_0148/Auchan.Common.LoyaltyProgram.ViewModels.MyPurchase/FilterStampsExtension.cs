using System.Collections.Generic;
using System.Linq;
using Auchan.Common.LoyaltyProgram.Enums;
using Auchan.Common.LoyaltyProgram.ViewModels.Abstract;
using Auchan.Common.LoyaltyProgram.ViewModels.MyPurchase.FeedItems;

namespace Auchan.Common.LoyaltyProgram.ViewModels.MyPurchase;

internal static class FilterStampsExtension
{
	internal static IEnumerable<FeedItemViewModel> FilterStamps(this IEnumerable<FeedItemViewModel> models, bool showStamps)
	{
		return models.Where((FeedItemViewModel v) => !(v is PurchaseItemViewModel purchaseItemViewModel) || showStamps || (purchaseItemViewModel.OperationType != QualifiedLoyaltyOperationType.StampsExpired && purchaseItemViewModel.OperationType != QualifiedLoyaltyOperationType.StampsCorrecred && purchaseItemViewModel.OperationType != QualifiedLoyaltyOperationType.StampsRecieved && purchaseItemViewModel.OperationType != QualifiedLoyaltyOperationType.StampsGivenAway && purchaseItemViewModel.OperationType != QualifiedLoyaltyOperationType.GameStamps)).Select(delegate(FeedItemViewModel vm)
		{
			if (vm is PurchaseItemViewModel purchaseItemViewModel)
			{
				purchaseItemViewModel.ShouldDisplayStamps = showStamps;
			}
			return vm;
		});
	}
}
