using System.Collections.Generic;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.LoyaltyProgram.Dtos;
using Auchan.Common.LoyaltyProgram.Models;
using CSharpFunctionalExtensions;

namespace Auchan.Common.LoyaltyProgram.Services;

public interface ILoyaltyPersonalizedGreetingsService
{
	Task<Result<IEnumerable<LoyaltyProgramGreetingDto>, DomainError>> GetGreetingAsync(LoyaltyUserCategoriesEntity userCategories);
}
