using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.DynamicFeedback.Dto;
using Auchan.Common.DynamicFeedback.Responses;
using Refit;

namespace Auchan.Common.DynamicFeedback;

public interface IDynamicFeedbackApi
{
	[Get("/feedback/categories")]
	Task<FeedbackCategoriesResponse> GetCategories(CancellationToken cancellationToken = default(CancellationToken));

	[Get("/feedback/fields")]
	Task<FeedbackFieldsResponse> GetFields([AliasAs("service_crm_id")] string serviceCrmId, CancellationToken cancellationToken = default(CancellationToken));

	[Get("/feedback/active")]
	Task<IsFeedbackActiveDto> IsFeedbackActive(CancellationToken cancellationToken = default(CancellationToken));

	[Post("/feedback/respond")]
	Task<FeedbackRespondResponse> Respond([Body] object body, CancellationToken cancellationToken = default(CancellationToken));

	[Multipart("----MyGreatBoundary")]
	[Post("/feedback/upload-files")]
	Task<List<FeedbackUploadFilesResponse>> UploadFiles([AliasAs("files[]")] IEnumerable<StreamPart> streams, CancellationToken cancellationToken = default(CancellationToken));

	[Get("/feedback/cities")]
	Task<FeedbackCitiesResponse> GetCities(CancellationToken cancellationToken = default(CancellationToken));

	[Get("/feedback/channels")]
	Task<FeedbackChannelsResponse> GetChannels(CancellationToken cancellationToken = default(CancellationToken));
}
