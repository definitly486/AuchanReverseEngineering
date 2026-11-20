using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Base.Errors.Service;
using Auchan.Common.Extensions;
using Auchan.Common.LoyaltyProgram.Coupons.DTO;
using Auchan.Common.LoyaltyProgram.Coupons.Models;
using Auchan.Common.Networking;
using Auchan.Common.PersonalCabinet;
using CSharpFunctionalExtensions;

namespace Auchan.Common.LoyaltyProgram.Coupons.Infrastructure;

public class CouponsService
{
	private readonly ICouponsApi _couponsApi;

	private readonly IRequestExecutor _requestExecutor;

	public CouponsService(ICouponsApi couponsApi, IRequestExecutor requestExecutor)
	{
		_couponsApi = couponsApi;
		_requestExecutor = requestExecutor;
	}

	internal async Task<Result<List<Coupon>, DomainError>> GetCoupons()
	{
		Result<CouponsResponseDTO, ServiceError> result = await _requestExecutor.ExecuteWithToken((CancellationToken ct, TokenModel tokenModel) => _couponsApi.Coupons(tokenModel.Token, ct));
		if (result.IsFailure)
		{
			if (result.Error is IUnsuccessfulStatusCodeError { StatusCode: HttpStatusCode.BadRequest })
			{
				return Result.Failure<List<Coupon>, DomainError>(new NoDataError());
			}
			return Result.Failure<List<Coupon>, DomainError>(new UnknownError());
		}
		Result<IEnumerable<Coupon>, DomainError> result2 = result.Map((CouponsResponseDTO dto) => dto.Data.Select((CouponDTO c) => c.Map()), (ServiceError err) => err.ToBaseDomainError());
		if (result2.IsFailure || !result2.Value.Any())
		{
			return Result.Failure<List<Coupon>, DomainError>(new NoDataError());
		}
		return Result.Success<List<Coupon>, DomainError>(result2.Value.ToList());
	}
}
