using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors.Domain;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Ecom.Drive;

public interface ICarsRepository
{
	ObservableRangeCollection<Car> Cars { get; }

	Task<Result<IEnumerable<Car>, DomainError>> GetCars(bool forceUpdate = false);

	Task<Result<IEnumerable<Car>, DomainError>> SaveCar(Car newCar);

	Task<Result<IEnumerable<Car>, DomainError>> UpdateCar(Car newCar);
}
