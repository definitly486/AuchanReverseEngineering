using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Base.Errors.Service;
using Auchan.Common.Ecom.DTO;
using Auchan.Common.Extensions;
using Auchan.Common.Networking;
using Auchan.Common.PersonalCabinet;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Ecom.Drive;

public class CarsService : ICarsService
{
	private readonly ICarsApi _api;

	private readonly IRequestExecutor _requestExecutor;

	public CarsService(ICarsApi api, IRequestExecutor requestExecutor)
	{
		_api = api;
		_requestExecutor = requestExecutor;
	}

	public async Task<Result<List<Car>, DomainError>> Cars()
	{
		return (await _requestExecutor.ExecuteWithToken((CancellationToken cancellationToken, TokenModel tokenModel) => _api.Cars(tokenModel.Token, cancellationToken))).Map((CarsResponse dto) => dto.Cars.Select((CarDto x) => x.ToModel()).ToList(), (ServiceError error) => error.ToBaseDomainError());
	}

	public async Task<Result<List<Car>, DomainError>> UpdateCars(List<Car> cars)
	{
		return (await _requestExecutor.ExecuteWithToken((CancellationToken cancellationToken, TokenModel tokenModel) => _api.UpdateCars(tokenModel.Token, new SetCarsRequest(cars.Select((Car x) => x.ToDTO()).ToList()), cancellationToken))).Map((CarsResponse dto) => dto.Cars.Select((CarDto x) => x.ToModel()).ToList(), (ServiceError error) => error.ToBaseDomainError());
	}
}
