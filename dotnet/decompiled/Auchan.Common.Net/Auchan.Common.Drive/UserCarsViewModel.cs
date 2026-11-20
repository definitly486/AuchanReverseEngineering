using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Subjects;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Auchan.Common.Base;
using Auchan.Common.Base.Errors;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Common;
using Auchan.Common.Ecom.Drive;
using Auchan.Common.Extensions;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Drive;

public class UserCarsViewModel : ScreenViewModel
{
	private readonly ICarsRepository _carsRepository;

	private readonly IErrorTranslator _errorTranslator;

	private Subject<CarFormViewModel.Parameter> _onAddCar = new Subject<CarFormViewModel.Parameter>();

	private Subject<CarFormViewModel.Parameter> _onEditCar = new Subject<CarFormViewModel.Parameter>();

	private Subject<Car> _carUpdated = new Subject<Car>();

	[CompilerGenerated]
	private ObservableRangeCollection<UserCarsItemViewModel> _003CUserCars_003Ek__BackingField;

	[CompilerGenerated]
	private VisualState _003CState_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CErrorTitle_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CErrorMessage_003Ek__BackingField;

	public string Title => "Мои автомобили";

	public string ProgressTitle => "Загружаем данные…";

	public string AddNewCarButtonText => "Добавить новый автомобиль";

	public ObservableRangeCollection<UserCarsItemViewModel> UserCars
	{
		[CompilerGenerated]
		get
		{
			return _003CUserCars_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!object.Equals(_003CUserCars_003Ek__BackingField, value))
			{
				_003CUserCars_003Ek__BackingField = value;
				RaisePropertyChanged("UserCars");
			}
		}
	} = new ObservableRangeCollection<UserCarsItemViewModel>();

	public IObservable<CarFormViewModel.Parameter> OpenAddCarCommand => _onAddCar.Debounce();

	public IObservable<CarFormViewModel.Parameter> OpenEditCarCommand => _onEditCar.Debounce();

	public IObservable<Car> UpdatedCarCommand => _carUpdated.Debounce();

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

	public string ErrorTitle
	{
		[CompilerGenerated]
		get
		{
			return _003CErrorTitle_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CErrorTitle_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CErrorTitle_003Ek__BackingField = value;
				RaisePropertyChanged("ErrorTitle");
			}
		}
	} = string.Empty;

	public string ErrorMessage
	{
		[CompilerGenerated]
		get
		{
			return _003CErrorMessage_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CErrorMessage_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CErrorMessage_003Ek__BackingField = value;
				RaisePropertyChanged("ErrorMessage");
			}
		}
	} = string.Empty;

	public UserCarsViewModel(ICarsRepository carsRepository, DefaultErrorTranslator errorTranslator)
	{
		_carsRepository = carsRepository;
		_errorTranslator = errorTranslator;
	}

	protected override async Task Start()
	{
		await base.Start();
		RxTaskExtensions.StartWithDefault(_carsRepository.Cars.CollectionChangedAsObservable()).Subscribe(delegate
		{
			UpdateUserCars(_carsRepository.Cars);
		}).AddTo(base.CloseDisposable);
		await LoadUserCars();
	}

	public void AddCarClick()
	{
		_onAddCar.OnNext(new CarFormViewModel.Parameter());
	}

	public async Task SetAsDefault(UserCarsItemViewModel itemModel)
	{
		if (itemModel.Car != null)
		{
			itemModel.Car.IsDefault = true;
			if ((await _carsRepository.UpdateCar(itemModel.Car)).IsSuccess)
			{
				State = VisualState.Default;
				_carUpdated.OnNext(itemModel.Car);
			}
			else
			{
				State = VisualState.Error;
			}
		}
	}

	public void EditCarClick(UserCarsItemViewModel viewModel)
	{
		if (viewModel.Car != null)
		{
			_onEditCar.OnNext(new CarFormViewModel.Parameter(viewModel.Car));
		}
	}

	private async Task LoadUserCars()
	{
		State = VisualState.InProgress;
		Result<IEnumerable<Car>, DomainError> result = await _carsRepository.GetCars(forceUpdate: true);
		if (result.IsFailure)
		{
			(string, string) tuple = _errorTranslator.Translate(result.Error);
			ErrorTitle = tuple.Item1;
			ErrorMessage = tuple.Item2;
			State = VisualState.Error;
		}
		else
		{
			State = VisualState.Default;
		}
	}

	private void UpdateUserCars(IEnumerable<Car> cars)
	{
		if (cars.Any())
		{
			SetCars(cars.Select((Car x) => new UserCarsItemViewModel(x)).ToList());
		}
		else
		{
			SetCars();
		}
	}

	private void SetCars(ICollection<UserCarsItemViewModel>? userCars = null)
	{
		if (userCars == null)
		{
			UserCars.ReplaceRange(Enumerable.Repeat(new UserCarsItemViewModel(UserCarsItemViewType.AddNewUserCar), 1));
			return;
		}
		userCars.Add(new UserCarsItemViewModel(UserCarsItemViewType.AddNewUserCar));
		UserCars.ReplaceRange(userCars);
	}
}
