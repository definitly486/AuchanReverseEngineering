using System.Threading.Tasks;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.LoyaltyProgram.Models;
using CSharpFunctionalExtensions;

namespace Auchan.Common.LoyaltyProgram.Services;

public interface ILoyaltyProgramBalanceService
{
	Task<Result<LoyaltyCardEntity, DomainError>> GetBalanceAsync(int timeout);
}
