using System;
using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Base.Errors.Service;
using Auchan.Common.Extensions;
using Auchan.Common.Networking;
using Auchan.Common.PersonalCabinet;
using CSharpFunctionalExtensions;

namespace Auchan.Common.StoreReview;

public class CustomerFlagService(Lazy<ICustomerFlagApi> storeReviewApi, Lazy<IRequestExecutor> requestExecutor)
{
	public async Task<Result<CustomerFlags, DomainError>> GetCustomerFlags()
	{
		return (await requestExecutor.Value.ExecuteWithToken((CancellationToken ct, TokenModel token80) => storeReviewApi.Value.GetCustomerFlags(token80.Token, ct))).Ensure((CustomerFlagsResponseDto dto) => dto?.Data != null, new ApiContractError()).Map((CustomerFlagsResponseDto dto) => dto.Data.ToModel(), (ServiceError err) => err.ToBaseDomainError());
	}

	public async Task<Result<CustomerFlags, DomainError>> UpdateCustomerFlags(UpdateCustomerFlagsRequestDto request)
	{
		return (await requestExecutor.Value.ExecuteWithToken((CancellationToken ct, TokenModel token80) => storeReviewApi.Value.UpdateCustomerFlags(token80, request, ct))).Ensure((CustomerFlagsResponseDto dto) => dto?.Data != null, new ApiContractError()).Map((CustomerFlagsResponseDto dto) => dto.Data.ToModel(), (ServiceError err) => err.ToBaseDomainError());
	}
}
