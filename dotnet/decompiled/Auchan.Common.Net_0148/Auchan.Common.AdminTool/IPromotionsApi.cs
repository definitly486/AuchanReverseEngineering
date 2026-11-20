using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.AdminTool.DTO;
using Refit;

namespace Auchan.Common.AdminTool;

public interface IPromotionsApi
{
	[Get("/promotions")]
	Task<List<PromotionDto>> Promotions([Header("Authorization")] string token, [Query][AliasAs("region_fias_id")] string fiasId, [Query][AliasAs("store_id")] string storeId, [Query(CollectionFormat.Multi)][AliasAs("segments")] IEnumerable<string>? segmentCodes, [Header("User-Agent")] string userAgent, CancellationToken cancellationToken = default(CancellationToken));

	[Get("/extra-promotions?region_fias_id={fiasId}")]
	Task<List<ExtraPromotionDto>> ExtraPromotions([Header("Authorization")] string token, string fiasId, CancellationToken cancellationToken = default(CancellationToken));
}
