using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.AdminTool;
using Auchan.Common.Base.Errors;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Base.Errors.Service;
using Auchan.Common.Logs;
using Auchan.Common.LoyaltyProgram.Dtos;
using Auchan.Common.LoyaltyProgram.Mappers;
using Auchan.Common.LoyaltyProgram.Models;
using Auchan.Common.LoyaltyProgram.Services.Infrastructure;
using CSharpFunctionalExtensions;
using Polly;

namespace Auchan.Common.LoyaltyProgram.Services;

public class LoyaltyPersonalizedGreetingsService : ILoyaltyPersonalizedGreetingsService
{
	private readonly ILoyaltyProgramAdminApi _api;

	private readonly IAdminToolAuthorizer _authorizer;

	public LoyaltyPersonalizedGreetingsService(ILoyaltyProgramAdminApi api, IAdminToolAuthorizer authorizer, ILogService logService)
	{
		_api = api;
		_authorizer = authorizer;
	}

	public async Task<Result<IEnumerable<LoyaltyProgramGreetingDto>, DomainError>> GetGreetingAsync(LoyaltyUserCategoriesEntity userCategories)
	{
		string[] categoriesDtoNames = userCategories.GetCategoriesDtoNames().ToArray();
		if (categoriesDtoNames.Length == 0)
		{
			return Result.Failure<IEnumerable<LoyaltyProgramGreetingDto>, DomainError>(new NoDataError());
		}
		Result<string, ServiceError> tokenResult = await _authorizer.UdidKey();
		if (tokenResult.IsFailure)
		{
			return Result.Failure<IEnumerable<LoyaltyProgramGreetingDto>, DomainError>(tokenResult.Error.ToBaseDomainError());
		}
		Result<IEnumerable<LoyaltyProgramGreetingDto>, ServiceError> result = await Policy.TimeoutAsync(15).ExecuteAsync((CancellationToken ct) => _api.GetGreetingsForTheUser(tokenResult.Value, categoriesDtoNames, ct).CatchErrors(), CancellationToken.None);
		if (result.IsFailure)
		{
			return Result.Failure<IEnumerable<LoyaltyProgramGreetingDto>, DomainError>(result.Error.ToBaseDomainError());
		}
		return Result.Success<IEnumerable<LoyaltyProgramGreetingDto>, DomainError>(result.Value);
	}
}
