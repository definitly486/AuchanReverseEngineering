using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Refit;

namespace Auchan.Common.Tooltips;

public interface ITooltipsApi
{
	[Get("/prompts")]
	Task<List<TooltipDto>> Tooltips([Header("Authorization")] string token, CancellationToken cancellationToken = default(CancellationToken));
}
