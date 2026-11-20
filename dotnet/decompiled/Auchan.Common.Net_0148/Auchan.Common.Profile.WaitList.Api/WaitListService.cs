using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Base.Errors.Service;
using Auchan.Common.Extensions;
using Auchan.Common.Networking;
using Auchan.Common.PersonalCabinet;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Profile.WaitList.Api;

public class WaitListService
{
	private readonly IWaitListApi _api;

	private readonly IRequestExecutor _requestExecutor;

	public WaitListService(IWaitListApi api, IRequestExecutor requestExecutor)
	{
		_api = api;
		_requestExecutor = requestExecutor;
	}

	public async Task<Result<WaitListDtos.AddDto, DomainError>> Add(int gimaId, int storeId)
	{
		return (await _requestExecutor.ExecuteWithToken((CancellationToken ct, TokenModel t) => _api.AddProduct(t, new WaitListDtos.AddRequestDto
		{
			GimaId = gimaId,
			StoreId = storeId
		}, ct))).Map((WaitListDtos.AddDto x) => x, (ServiceError x) => x.ToBaseDomainError());
	}

	public async Task<Result<WaitListDtos.DeleteDto, DomainError>> Delete(int gimaId)
	{
		return (await _requestExecutor.ExecuteWithToken((CancellationToken ct, TokenModel t) => _api.DeleteProduct(t, new WaitListDtos.DeleteRequestDto
		{
			GimaId = gimaId
		}, ct))).Map((WaitListDtos.DeleteDto x) => x, (ServiceError x) => x.ToBaseDomainError());
	}

	public async Task<Result<WaitListDtos.WaitListProductsDto, DomainError>> WaitListProducts(int storeId, bool onlyActive, string? category)
	{
		return (await _requestExecutor.ExecuteWithToken((CancellationToken ct, TokenModel t) => _api.WaitListProducts(t, new WaitListDtos.WaitListRequestDto
		{
			StoreId = storeId,
			OnlyActive = onlyActive,
			Category = category
		}, ct))).Map((WaitListDtos.WaitListProductsDto x) => x, (ServiceError x) => x.ToBaseDomainError());
	}

	public async Task<Result<WaitListDtos.NotificationResponseDto, DomainError>> GetNotification(int storeId)
	{
		return (await _requestExecutor.ExecuteWithToken((CancellationToken ct, TokenModel t) => _api.GetNotification(t, new WaitListDtos.NotificationRequestDto
		{
			StoreId = storeId
		}, ct))).Map((WaitListDtos.NotificationResponseDto x) => x, (ServiceError x) => x.ToBaseDomainError());
	}
}
