using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Base.Errors.Service;
using Auchan.Common.Extensions;
using Auchan.Common.Networking;
using Auchan.Common.Profile.Orders.Dto;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Profile.Orders.Services;

public sealed class OrderCancellationReasonsService : IOrderCancellationReasonsService
{
	private readonly IOrderCancellationReasonsApi _api;

	private readonly IRequestExecutor _requestExecutor;

	public OrderCancellationReasonsService(IOrderCancellationReasonsApi api, IRequestExecutor requestExecutor)
	{
		_api = api;
		_requestExecutor = requestExecutor;
	}

	public async Task<Result<PossibleOrderCancellationReasonsDto, DomainError>> GetOrderCancellationReasonsAsync()
	{
		return (await _requestExecutor.Execute((CancellationToken t) => _api.GetOrderCancellationReasonsAsync(t))).Map((PossibleOrderCancellationReasonsDto dto) => dto, (ServiceError err) => err.ToBaseDomainError());
	}
}
