using System.Collections.Generic;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors.Domain;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Ecom.Drive;

public interface ICarsService
{
	Task<Result<List<Car>, DomainError>> UpdateCars(List<Car> cars);

	Task<Result<List<Car>, DomainError>> Cars();
}
