using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Subjects;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Auchan.Common.Base;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Common;
using Auchan.Common.Ecom.Drive;
using Auchan.Common.Extensions;
using Auchan.Common.Profile.Orders.Services;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Drive;

public class AskIsPersonArrivedViewModel : ScreenViewModel
{
	public enum VisualState
	{
		Default,
		InProgress
	}

	public class Parameter
	{
		public long OrderId;

		public Parameter(long orderId)
		{
			OrderId = orderId;
		}
	}

	private readonly ICarsRepository _carsRepository;

	private readonly IOrdersRepository _ordersRepository;

	private readonly Parameter _parameter;

	private List<Car> _cars = new List<Car>();

	[CompilerGenerated]
	private VisualState _003CState_003Ek__BackingField;

	private readonly Subject<AgreeState> _onAnswer = new Subject<AgreeState>();

	[CompilerGenerated]
	private Car? _003CDefaultCar_003Ek__BackingField;

	public VisualState State
	{
		[CompilerGenerated]
		get
		{
			return _003CState_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CState_003Ek__BackingField != value)
			{
				_003CState_003Ek__BackingField = value;
				RaisePropertyChanged("State");
			}
		}
	} = VisualState.InProgress;

	public IObservable<AgreeState> OnAnswerCommand => _onAnswer.Debounce();

	public string Title => "Вы в зоне выдачи?";

	public string Message => "Заезжайте на парковку в зону выдачи \"АШАН АВТО\" согласно схеме, указанной в вашем заказе";

	public string YesButtonText => "Да, я уже тут";

	public string NoButtonText => "Отмена";

	public string DefaultCarSectionTitle => "Автомобиль";

	public string DriveHeaderText => "Автомобиль";

	public string DriveCarAddText => "Добавить автомобиль";

	public Car? DefaultCar
	{
		[CompilerGenerated]
		get
		{
			return _003CDefaultCar_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!object.Equals(_003CDefaultCar_003Ek__BackingField, value))
			{
				_003CDefaultCar_003Ek__BackingField = value;
				RaisePropertyChanged("DefaultCar");
			}
		}
	}

	public AskIsPersonArrivedViewModel(ICarsRepository carsRepository, IOrdersRepository ordersRepository, Parameter parameter)
	{
		_carsRepository = carsRepository;
		_ordersRepository = ordersRepository;
		_parameter = parameter;
	}

	protected override async Task OnResumed()
	{
		await base.OnResumed();
		await UpdateCars();
		State = VisualState.Default;
	}

	public async Task Reply(AgreeState answer)
	{
		if (DefaultCar != null && answer == AgreeState.Yes)
		{
			State = VisualState.InProgress;
			Result<Unit, DomainError> result = await _ordersRepository.UpdateOrderAsync(_parameter.OrderId, 1);
			State = VisualState.Default;
			if (result.IsSuccess)
			{
				_onAnswer.OnNext(answer);
			}
		}
	}

	public async Task UpdateCars(Car? newCar = null)
	{
		if (newCar != null)
		{
			DefaultCar = newCar;
			return;
		}
		State = VisualState.InProgress;
		Result<IEnumerable<Car>, DomainError> result = await _carsRepository.GetCars(forceUpdate: true);
		State = VisualState.Default;
		if (result.IsSuccess)
		{
			_cars = result.Value.ToList();
			DefaultCar = _cars.FirstOrDefault((Car car) => car.IsDefault) ?? _carsRepository.Cars.FirstOrDefault((Car car) => car.IsDefault) ?? _carsRepository.Cars.FirstOrDefault();
		}
	}
}
