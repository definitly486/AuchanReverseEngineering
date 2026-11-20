using System.Threading;
using System.Threading.Tasks;
using Refit;

namespace Auchan.Common.Profile.WaitList.Api;

public interface IWaitListApi
{
	[Post("/customers/waitlist:add")]
	Task<WaitListDtos.AddDto> AddProduct([Header("X-Token-CMD")] string cmdToken, [Body] WaitListDtos.AddRequestDto body, CancellationToken cancellationToken = default(CancellationToken));

	[Delete("/customers/waitlist:delete")]
	Task<WaitListDtos.DeleteDto> DeleteProduct([Header("X-Token-CMD")] string cmdToken, [Body] WaitListDtos.DeleteRequestDto body, CancellationToken cancellationToken = default(CancellationToken));

	[Post("/customers/waitlist")]
	Task<WaitListDtos.WaitListProductsDto> WaitListProducts([Header("X-Token-CMD")] string cmdToken, [Body] WaitListDtos.WaitListRequestDto body, CancellationToken cancellationToken = default(CancellationToken));

	[Post("/customers/waitlist-notification")]
	Task<WaitListDtos.NotificationResponseDto> GetNotification([Header("X-Token-CMD")] string cmdToken, [Body] WaitListDtos.NotificationRequestDto body, CancellationToken cancellationToken = default(CancellationToken));
}
