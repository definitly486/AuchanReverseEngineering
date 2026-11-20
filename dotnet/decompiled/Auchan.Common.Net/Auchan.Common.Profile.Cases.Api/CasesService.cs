using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Base.Errors.Service;
using Auchan.Common.Extensions;
using Auchan.Common.Networking;
using Auchan.Common.PersonalCabinet;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Profile.Cases.Api;

public class CasesService
{
	private readonly ICasesApi _api;

	private readonly IRequestExecutor _requestExecutor;

	public CasesService(ICasesApi api, IRequestExecutor requestExecutor)
	{
		_api = api;
		_requestExecutor = requestExecutor;
	}

	public Task<Result<CasesDtos.CasesResponseDto, DomainError>> GetCases(int offset, int limit)
	{
		return GetCasesInternal(offset, limit);
	}

	public Task<Result<CasesDtos.CaseDetailsResponseDto, DomainError>> GetCaseById(string caseId, string number)
	{
		return GetCaseByIdInternal(caseId, number);
	}

	private async Task<Result<CasesDtos.CasesResponseDto, DomainError>> GetCasesInternal(int offset, int limit)
	{
		CasesDtos.CasesRequestDto request = new CasesDtos.CasesRequestDto
		{
			Pagination = new CasesDtos.PaginationRequestDto
			{
				Offset = offset,
				Limit = limit
			}
		};
		return (await _requestExecutor.ExecuteWithToken((CancellationToken ct, TokenModel t) => _api.GetCases(t, request, ct))).Map((CasesDtos.CasesResponseDto x) => x, (ServiceError x) => x.ToCasesDomainError());
	}

	private async Task<Result<CasesDtos.CaseDetailsResponseDto, DomainError>> GetCaseByIdInternal(string caseId, string number)
	{
		return (await _requestExecutor.ExecuteWithToken((CancellationToken ct, TokenModel t) => _api.GetCaseById(t, caseId, number, ct))).Map((CasesDtos.CaseDetailsResponseDto x) => x, (ServiceError x) => x.ToCaseDetailsDomainError());
	}
}
