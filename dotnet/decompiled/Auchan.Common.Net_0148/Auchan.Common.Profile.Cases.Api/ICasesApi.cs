using System.Threading;
using System.Threading.Tasks;
using Refit;

namespace Auchan.Common.Profile.Cases.Api;

public interface ICasesApi
{
	[Post("/cases")]
	Task<CasesDtos.CasesResponseDto> GetCases([Header("X-Token-CMD")] string cmdToken, [Body] CasesDtos.CasesRequestDto body, CancellationToken cancellationToken = default(CancellationToken));

	[Get("/cases/{caseId}")]
	Task<CasesDtos.CaseDetailsResponseDto> GetCaseById([Header("X-Token-CMD")] string cmdToken, string caseId, [Query("number")] string number, CancellationToken cancellationToken = default(CancellationToken));
}
