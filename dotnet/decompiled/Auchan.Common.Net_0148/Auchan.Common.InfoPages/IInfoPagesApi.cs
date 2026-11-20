using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.InfoPages.DTO;
using Refit;

namespace Auchan.Common.InfoPages;

public interface IInfoPagesApi
{
	[Get("/about_sections")]
	Task<List<InfoResponseDto>> InfoPages([Header("Authorization")] string token, CancellationToken cancellationToken = default(CancellationToken));

	[Get("/faq")]
	Task<List<FAQResponseDto>> FAQ([Header("Authorization")] string token, [AliasAs("slug")] FAQType type, CancellationToken cancellationToken = default(CancellationToken));

	[Get("/what-can-app")]
	Task<List<TutorialDto>> Tutorials([Header("Authorization")] string token, CancellationToken cancellationToken = default(CancellationToken));
}
