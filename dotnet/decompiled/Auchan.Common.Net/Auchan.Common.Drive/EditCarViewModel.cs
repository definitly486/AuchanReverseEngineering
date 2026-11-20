using System.Collections.Generic;
using System.Reactive;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Common;
using Auchan.Common.Ecom.Drive;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Drive;

public class EditCarViewModel : CarFormViewModel
{
	public override string Title => "Редактировать автомобиль";

	public override string Description => string.Empty;

	public override bool IsDescriptionVisible => false;

	public EditCarViewModel(ICarsRepository carsRepository, DefaultErrorTranslator errorTranslator, Parameter parameter)
		: base(carsRepository, errorTranslator, parameter)
	{
		base.CarBrand = _parameter.Car.CarMark;
		base.CarColor = _parameter.Car.CarColor;
		base.CarNumber = _parameter.Car.CarNumber;
	}

	protected override async Task SaveCar()
	{
		Result<IEnumerable<Car>, DomainError> result = await CarsRepository.UpdateCar(new Car
		{
			CarNumber = base.CarNumber,
			CarColor = base.CarColor,
			CarMark = base.CarBrand,
			IsDefault = _parameter.Car.IsDefault,
			Id = _parameter.Car.Id
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
