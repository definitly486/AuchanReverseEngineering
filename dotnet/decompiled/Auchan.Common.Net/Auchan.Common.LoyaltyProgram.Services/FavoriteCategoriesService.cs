using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Base.Errors.Service;
using Auchan.Common.Extensions;
using Auchan.Common.Home;
using Auchan.Common.LoyaltyProgramLoymax;
using Auchan.Common.LoyaltyProgramLoymax.Dtos;
using Auchan.Common.Networking;
using Auchan.Common.PersonalCabinet;
using CSharpFunctionalExtensions;

namespace Auchan.Common.LoyaltyProgram.Services;

public class FavoriteCategoriesService(ILoymaxLoyaltyApi loyaltyApi, IRequestExecutor requestExecutor)
{
	public async Task<Result<FavoriteCategoriesItemViewModel, DomainError>> GetFavoriteCategories()
	{
		return (await requestExecutor.ExecuteWithToken((CancellationToken cancellationToken, TokenModel accessToken) => loyaltyApi.FavoriteCategories(accessToken.Token, "mobile_site", cancellationToken))).Ensure((FavoriteCategoriesDto dto) => dto.Data != null, (FavoriteCategoriesDto dto) => new UnsuccessfulStatusCodeError(HttpStatusCode.NotFound, null)).Map((FavoriteCategoriesDto dto) => new FavoriteCategoriesItemViewModel(dto.Data), (ServiceError err) => err.ToBaseDomainError());
	}

	public async Task<Result<FavoriteCategoriesItemViewModel, DomainError>> SendCategories(string[] ids)
	{
		var body = new
		{
			category_ids = ids
		};
		return (await requestExecutor.ExecuteWithToken((CancellationToken cancellationToken, TokenModel accessToken) => loyaltyApi.SendCategories(accessToken.Token, "mobile_site", body, cancellationToken))).Map((FavoriteCategoriesDto dto) => new FavoriteCategoriesItemViewModel(dto.Data), (ServiceError err) => err.ToBaseDomainError());
	}
}
