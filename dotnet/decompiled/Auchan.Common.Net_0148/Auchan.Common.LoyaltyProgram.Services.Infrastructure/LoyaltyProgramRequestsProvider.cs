using System.Linq;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.LoyaltyProgram.Dtos;
using Auchan.Common.LoyaltyProgram.Models;
using Auchan.Common.PersonalCabinet;
using CSharpFunctionalExtensions;

namespace Auchan.Common.LoyaltyProgram.Services.Infrastructure;

public class LoyaltyProgramRequestsProvider : ILoyaltyProgramRequestsProvider
{
	private readonly string _mobileSideSourceCode = "1";

	private readonly ITokenService _tokenService;

	private readonly IUserContext _userContext;

	public LoyaltyProgramRequestsProvider(ITokenService tokenService, IUserContext userContext)
	{
		_tokenService = tokenService;
		_userContext = userContext;
	}

	public async Task<Result<LoyaltyProgramCommonRequestDto, DomainError>> GetLoyaltyProgramRequestDto()
	{
		Result<TokenModel, DomainError> result = await _tokenService.SavedToken80();
		if (result.IsFailure)
		{
			return Result.Failure<LoyaltyProgramCommonRequestDto, DomainError>(result.Error);
		}
		return Result.Success<LoyaltyProgramCommonRequestDto, DomainError>(new LoyaltyProgramCommonRequestDto
		{
			AccessToken = result.Value.Token,
			Source = _mobileSideSourceCode
		});
	}

	public LoyaltyCardRolloutDto GetVirtualCardEnrollmentDto()
	{
		return GetBasicRolloutDto();
	}

	public LoyaltyCardBlockDto GetLoyaltyCardBlockDto()
	{
		return new LoyaltyCardBlockDto
		{
			Fraud = false,
			Reason = "Заблокирована клиентом"
		};
	}

	public LoyaltyCardRolloutDto GetPlasticCardEnrollmentDto(LoyaltyCardEntity card)
	{
		LoyaltyCardRolloutDto basicRolloutDto = GetBasicRolloutDto();
		basicRolloutDto.CardNumber = card.CardNumber;
		basicRolloutDto.CvcCode = card.Cvc;
		return basicRolloutDto;
	}

	private LoyaltyCardRolloutDto GetBasicRolloutDto()
	{
		return new LoyaltyCardRolloutDto
		{
			FirstName = _userContext.Profile?.FirstName,
			LastName = ((!string.IsNullOrWhiteSpace(_userContext.Profile?.LastName)) ? _userContext.Profile?.LastName.ToArray().FirstOrDefault().ToString() : _userContext.Profile?.FirstName.ToArray().FirstOrDefault().ToString()),
			BirthDate = _userContext.Profile?.Birthday?.ToString("yyyy-MM-dd"),
			Permissions = new LoyaltyCardRolloutPermissionsDto()
		};
	}
}
