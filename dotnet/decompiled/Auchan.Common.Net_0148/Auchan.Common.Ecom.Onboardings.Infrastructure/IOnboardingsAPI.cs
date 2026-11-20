using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Ecom.Onboardings.DTO;
using Refit;

namespace Auchan.Common.Ecom.Onboardings.Infrastructure;

public interface IOnboardingsAPI
{
	[Get("/onboardings")]
	Task<List<OnboardingDTO>> Onboardings([Header("Authorization")] string token, [Query][AliasAs("merchant_id")] string merchantId, [Query(CollectionFormat.Multi)][AliasAs("segments")] IEnumerable<string>? segmentCodes, [Header("User-Agent")] string userAgent, CancellationToken ct = default(CancellationToken));
}
