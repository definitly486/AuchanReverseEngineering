using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.LoyaltyProgram.Dtos;
using Refit;

namespace Auchan.Common.LoyaltyProgram.Services.Infrastructure;

public interface ILoyaltyProgramAdminApi
{
	[Get("/register_greetings")]
	Task<IEnumerable<LoyaltyProgramGreetingDto>> GetGreetingsForTheUser([Header("Authorization")] string authToken, [Query(CollectionFormat.Csv)] string[] slugs, CancellationToken token);
}
