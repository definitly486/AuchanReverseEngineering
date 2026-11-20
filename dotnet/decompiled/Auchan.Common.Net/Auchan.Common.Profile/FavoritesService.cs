using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Base.Errors.Service;
using Auchan.Common.Ecom.DTO;
using Auchan.Common.Ecom.ProducModels;
using Auchan.Common.Extensions;
using Auchan.Common.Networking;
using Auchan.Common.PersonalCabinet;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Profile;

public class FavoritesService
{
	private readonly IFavoritesApi _api;

	private readonly IRequestExecutor _requestExecutor;

	public FavoritesService(IFavoritesApi api, IRequestExecutor requestExecutor)
	{
		_api = api;
		_requestExecutor = requestExecutor;
	}

	public async Task<Result<FavoritesDtos.AddDto, DomainError>> Add(string gimaId)
	{
		return (await _requestExecutor.ExecuteWithToken((CancellationToken ct, TokenModel t) => _api.AddProduct(t, new FavoritesDtos.AddRequestDto
		{
			GimaId = gimaId
		}, ct))).Map((FavoritesDtos.AddDto x) => x, (ServiceError x) => x.ToBaseDomainError());
	}

	public async Task<Result<FavoritesDtos.DeleteDto, DomainError>> Delete(string gimaId)
	{
		return (await _requestExecutor.ExecuteWithToken((CancellationToken ct, TokenModel t) => _api.DeleteProduct(t, new FavoritesDtos.AddRequestDto
		{
			GimaId = gimaId
		}, ct))).Map((FavoritesDtos.DeleteDto x) => x, (ServiceError x) => x.ToBaseDomainError());
	}

	public async Task<Result<List<Product>, DomainError>> Favorites(string orderFields, string orderDirection)
	{
		return (await _requestExecutor.ExecuteWithToken((CancellationToken ct, TokenModel t) => _api.Favorites(t, new FavoritesDtos.FavoritesRequestDto
		{
			OrderDirection = orderDirection,
			OrderField = orderFields
		}, ct))).Map((FavoriteProductsDto x) => x.Data?.Items?.Select((FavoriteProductDto dto) => dto.Map()).ToList() ?? new List<Product>(), (ServiceError x) => x.ToBaseDomainError());
	}

	public async Task<Result<FavoritesDtos.FavoriteFieldsDto, DomainError>> FavoriteFields()
	{
		return (await _requestExecutor.ExecuteWithToken((CancellationToken ct, TokenModel t) => _api.FavoriteFields(t, ct))).Map((FavoritesDtos.FavoriteFieldsDto x) => x, (ServiceError x) => x.ToBaseDomainError());
	}
}
