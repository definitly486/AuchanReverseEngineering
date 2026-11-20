using System.Reactive;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Logs;
using CSharpFunctionalExtensions;

namespace Auchan.Common.PersonalCabinet.Interactors;

public class LogoutInteractor
{
	private readonly IUserContext _userContext;

	private readonly IPersonalCabinetService _personalCabinetService;

	private readonly ITokenService _tokenService;

	private readonly ILogService _logService;

	public LogoutInteractor(IUserContext userContext, IPersonalCabinetService personalCabinetService, ITokenService tokenService, ILogService logService)
	{
		_userContext = userContext;
		_personalCabinetService = personalCabinetService;
		_tokenService = tokenService;
		_logService = logService;
	}

	public async Task<Result<Unit, DomainError>> Logout(bool fromAll = false)
	{
		Result<TokenModel, DomainError> tokenResult = await _tokenService.SavedToken80();
		if (tokenResult.IsFailure)
		{
			return Result.Failure<Unit, DomainError>(tokenResult.Error);
		}
		Result<Unit, DomainError> result = await _personalCabinetService.Logout(tokenResult.Value.Token, fromAll);
		if (result.IsSuccess && !fromAll)
		{
			await _userContext.LogOut();
			_logService.LogInfo("Logout", $"Токен '{tokenResult.Value.TokenLevel}' [REDACTED]", LogType.UserAction, SystemType.PersonalAccount);
		}
		return result;
	}
}
