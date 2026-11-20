using System;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.LoyaltyProgram.Dtos;
using Auchan.Common.LoyaltyProgram.Models;
using CSharpFunctionalExtensions;

namespace Auchan.Common.LoyaltyProgram.Services.Infrastructure;

public interface ILoyaltyProgramRequestsProvider
{
	[Obsolete]
	Task<Result<LoyaltyProgramCommonRequestDto, DomainError>> GetLoyaltyProgramRequestDto();

	LoyaltyCardRolloutDto GetVirtualCardEnrollmentDto();

	LoyaltyCardBlockDto GetLoyaltyCardBlockDto();

	LoyaltyCardRolloutDto GetPlasticCardEnrollmentDto(LoyaltyCardEntity card);
}
