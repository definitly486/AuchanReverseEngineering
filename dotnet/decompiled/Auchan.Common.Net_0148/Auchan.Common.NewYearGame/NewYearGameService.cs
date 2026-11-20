using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Base.Errors.Service;
using Auchan.Common.Extensions;
using Auchan.Common.Networking;
using Auchan.Common.PersonalCabinet;
using CSharpFunctionalExtensions;

namespace Auchan.Common.NewYearGame;

public class NewYearGameService : INewYearGameService
{
	private readonly IPersonalCabinetApi _api;

	private readonly IRequestExecutor _requestExecutor;

	private readonly ITokenService _tokenService;

	public NewYearGameService(IPersonalCabinetApi api, ITokenService tokenService, IRequestExecutor requestExecutor)
	{
		_api = api;
		_tokenService = tokenService;
		_requestExecutor = requestExecutor;
	}

	public async Task<Result<string, DomainError>> NewYearGameToken()
	{
		Result<TokenModel, DomainError> tokenResult = await _tokenService.SavedToken80();
		if (tokenResult.IsFailure)
		{
			return Result.Failure<string, DomainError>(tokenResult.Error);
		}
		return (await _requestExecutor.Execute((CancellationToken t) => _api.NewYearGameToken(tokenResult.Value, t))).Ensure((string x) => !string.IsNullOrWhiteSpace(x), new UnknownServiceError()).Map((string dto) => dto, (ServiceError err) => err.ToBaseDomainError());
	}
}
