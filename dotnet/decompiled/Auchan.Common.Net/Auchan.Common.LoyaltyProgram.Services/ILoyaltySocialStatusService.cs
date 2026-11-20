using System.Threading.Tasks;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.LoyaltyProgram.Models;
using CSharpFunctionalExtensions;

namespace Auchan.Common.LoyaltyProgram.Services;

public interface ILoyaltySocialStatusService
{
	Task<Result<LoyaltyProgramSocialStatusResponse, DomainError>> GetSocialStatusAsync(int timeout = 15);
}
