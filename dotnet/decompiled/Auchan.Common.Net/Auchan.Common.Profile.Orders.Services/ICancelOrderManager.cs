using System.Threading.Tasks;
using Auchan.Common.Common;
using Auchan.Common.Profile.Orders.Dto;

namespace Auchan.Common.Profile.Orders.Services;

public interface ICancelOrderManager
{
	Task<AgreeState> AskDoYouWantToCancelOrder();

	Task<AskForOrderCancellationReasonViewModel.Result?> AskForOrderCancellationReason(PossibleOrderCancellationReasonsDto reasons);

	Task<AgreeState> ShowOrderCannotBeCanceled();
}
