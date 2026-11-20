using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.AdminTool.DTO;
using Refit;

namespace Auchan.Common.AdminTool;

public interface IAdminToolApi
{
	[Post("/initialize?region_fias_id={regionFiasId}")]
	Task<InitializationDto> Initialize([Body] UdidPayload udid, [Query][AliasAs("store_id")] string storeId, string regionFiasId, [Header("User-Agent")] string userAgent, CancellationToken cancellationToken = default(CancellationToken));

	[Get("/app-config")]
	Task<AppConfigDto> AppConfig([Header("Authorization")] string token, [Header("User-Agent")] string userAgent, CancellationToken cancellationToken = default(CancellationToken));
}
