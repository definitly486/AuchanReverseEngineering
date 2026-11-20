using System.Collections.Generic;
using System.Reactive;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Common;
using Auchan.Common.Ecom.Drive;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Drive;

public class AddCarViewModel : CarFormViewModel
{
	public override string Title => "Добавьте автомобиль";

	public AddCarViewModel(ICarsRepository carsRepository, DefaultErrorTranslator errorTranslator, Parameter parameter)
		: base(carsRepository, errorTranslator, parameter)
	{
	}

	protected override async Task SaveCar()
	{
		Result<IEnumerable<Car>, DomainError> result = await CarsRepository.SaveCar(new Car
		{
			CarNumber = base.CarNumber,
			CarColor = base.CarColor,
			CarMark = base.CarBrand,
			IsDefault = true
		});
		if (result.IsFailure)
		{
			(string, string) tuple = ErrorTranslator.Translate(result.Error);
			base.ErrorTitle = tuple.Item1;
			base.ErrorMessage = tuple.Item2;
			base.State = VisualState.Error;
		}
		else
		{
			OnClose.OnNext(Unit.Default);
		}
	}
}
