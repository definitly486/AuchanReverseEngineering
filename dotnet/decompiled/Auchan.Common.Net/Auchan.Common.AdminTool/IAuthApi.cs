using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.AdminTool.DTO;
using Refit;

namespace Auchan.Common.AdminTool;

public interface IAuthApi
{
	[Post("/udid")]
	Task<UdidDto> Udid([Body] UdidPayload udid, CancellationToken cancellationToken = default(CancellationToken));
}
