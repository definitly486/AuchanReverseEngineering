using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors.Domain;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Ecom.Drive;

public class CarsRepository : ICarsRepository
{
	private readonly ICarsService _carsService;

	public ObservableRangeCollection<Car> Cars { get; private set; } = new ObservableRangeCollection<Car>();

	public CarsRepository(ICarsService carsService)
	{
		_carsService = carsService;
	}

	public async Task<Result<IEnumerable<Car>, DomainError>> GetCars(bool forceUpdate = false)
	{
		if (Cars.Any() && !forceUpdate)
		{
			return Result.Success<IEnumerable<Car>, DomainError>(Cars);
		}
		Result<List<Car>, DomainError> result = await _carsService.Cars();
		if (result.IsFailure)
		{
			return Result.Failure<IEnumerable<Car>, DomainError>(result.Error);
		}
		Cars.ReplaceRange(result.Value);
		return Result.Success<IEnumerable<Car>, DomainError>(Cars);
	}

	public async Task<Result<IEnumerable<Car>, DomainError>> SaveCar(Car newCar)
	{
		if (newCar.IsDefault)
		{
			foreach (Car car in Cars)
			{
				car.IsDefault = false;
			}
		}
		IEnumerable<Car> source = Cars.Concat(Enumerable.Repeat(newCar, 1));
		if (source.All((Car x) => !x.IsDefault))
		{
			source.First().IsDefault = true;
		}
		Result<List<Car>, DomainError> result = await _carsService.UpdateCars(source.ToList());
		if (result.IsFailure)
		{
			return Result.Failure<IEnumerable<Car>, DomainError>(result.Error);
		}
		Cars.ReplaceRange(result.Value);
		return Result.Success<IEnumerable<Car>, DomainError>(Cars);
	}

	public async Task<Result<IEnumerable<Car>, DomainError>> UpdateCar(Car newCar)
	{
		if (newCar.IsDefault)
		{
			foreach (Car car in Cars)
			{
				car.IsDefault = car.Id == newCar.Id;
			}
		}
		List<Car> list = Cars.ToList();
		list.RemoveAll((Car x) => x.Id == newCar.Id);
		list.Add(newCar);
		if (list.All((Car x) => !x.IsDefault))
		{
			list.First().IsDefault = true;
		}
		Result<List<Car>, DomainError> result = await _carsService.UpdateCars(list);
		if (result.IsFailure)
		{
			return Result.Failure<IEnumerable<Car>, DomainError>(result.Error);
		}
		Cars.ReplaceRange(result.Value);
		return Result.Success<IEnumerable<Car>, DomainError>(Cars);
	}
}
