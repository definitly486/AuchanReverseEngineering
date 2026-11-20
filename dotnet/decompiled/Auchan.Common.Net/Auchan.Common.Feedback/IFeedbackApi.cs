using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Feedback.DTO;
using Refit;

namespace Auchan.Common.Feedback;

internal interface IFeedbackApi
{
	[Post("/feedback")]
	Task<FeedbackResponseDto> Feedback([Body] FeedbackMessage feedback, [Header("Authorization")] string token, CancellationToken cancellationToken = default(CancellationToken));

	[Multipart("----MyGreatBoundary")]
	[Post("/feedback/attachment")]
	Task<FeedbackAttachmentResponseDto> FeedbackAttachment([AliasAs("file")] StreamPart stream, [Header("Authorization")] string token, CancellationToken cancellationToken = default(CancellationToken));

	[Get("/feedback/config")]
	Task<FeedbackConfigResponseDto> Config([Header("Authorization")] string token, CancellationToken cancellationToken = default(CancellationToken));
}
