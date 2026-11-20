using System;
using System.Reactive;
using System.Reactive.Subjects;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Auchan.Common.Base;
using Auchan.Common.Base.Errors;
using Auchan.Common.Common;
using Auchan.Common.Ecom.Drive;
using Auchan.Common.Extensions;

namespace Auchan.Common.Drive;

public abstract class CarFormViewModel : ScreenViewModel
{
	public class Parameter
	{
		public Car? Car { get; }

		public Parameter(Car? car = null)
		{
			Car = car;
		}
	}

	protected Parameter _parameter;

	private readonly string _startedCarNumber;

	private readonly string _startedCarColor;

	private readonly string _startedCarBrand;

	private readonly Subject<Unit> _onSave = new Subject<Unit>();

	protected readonly ICarsRepository CarsRepository;

	protected readonly IErrorTranslator ErrorTranslator;

	protected readonly Subject<Unit> OnClose = new Subject<Unit>();

	[CompilerGenerated]
	private VisualState _003CState_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CCarNumber_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CCarColor_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CCarBrand_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CErrorTitle_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CErrorMessage_003Ek__BackingField;

	private bool CarInformationChanged
	{
		get
		{
			if (!(CarNumber != _startedCarNumber) && !(CarColor != _startedCarColor))
			{
				return CarBrand != _startedCarBrand;
			}
			return true;
		}
	}

	public VisualState State
	{
		[CompilerGenerated]
		get
		{
			return _003CState_003Ek__BackingField;
		}
		[CompilerGenerated]
		protected set
		{
			if (_003CState_003Ek__BackingField != value)
			{
				_003CState_003Ek__BackingField = value;
				RaisePropertyChanged("State");
			}
		}
	} = VisualState.Default;

	public virtual string Title => "Добавьте автомобиль";

	public virtual string Description => "Пожалуйста, добавьте данные Вашего автомобиля, чтобы мы смогли найти его в\u00a0зоне выдачи";

	public virtual bool IsDescriptionVisible => true;

	public string CarNumber
	{
		[CompilerGenerated]
		get
		{
			return _003CCarNumber_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(_003CCarNumber_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CCarNumber_003Ek__BackingField = value;
				RaisePropertyChanged("CarInformationChanged");
				RaisePropertyChanged("SaveButtonEnabled");
				RaisePropertyChanged("CarNumber");
			}
		}
	} = string.Empty;

	public string CarColor
	{
		[CompilerGenerated]
		get
		{
			return _003CCarColor_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(_003CCarColor_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CCarColor_003Ek__BackingField = value;
				RaisePropertyChanged("CarInformationChanged");
				RaisePropertyChanged("SaveButtonEnabled");
				RaisePropertyChanged("CarColor");
			}
		}
	} = string.Empty;

	public string CarBrand
	{
		[CompilerGenerated]
		get
		{
			return _003CCarBrand_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(_003CCarBrand_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CCarBrand_003Ek__BackingField = value;
				RaisePropertyChanged("CarInformationChanged");
				RaisePropertyChanged("SaveButtonEnabled");
				RaisePropertyChanged("CarBrand");
			}
		}
	} = string.Empty;

	public string ErrorTitle
	{
		[CompilerGenerated]
		get
		{
			return _003CErrorTitle_003Ek__BackingField;
		}
		[CompilerGenerated]
		protected set
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
		protected set
		{
			if (!string.Equals(_003CErrorMessage_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CErrorMessage_003Ek__BackingField = value;
				RaisePropertyChanged("ErrorMessage");
			}
		}
	} = string.Empty;

	public string CarNumberTextFieldHint => "Номер автомобиля *";

	public string CarColorTextFieldHint => "Цвет *";

	public string CarBrandTextFieldHint => "Марка *";

	public string SaveButtonText => "Сохранить";

	public bool SaveButtonEnabled
	{
		get
		{
			if (!string.IsNullOrWhiteSpace(CarNumber) && CarNumber.Length < 25 && !string.IsNullOrWhiteSpace(CarColor) && CarColor.Length < 25 && !string.IsNullOrWhiteSpace(CarBrand) && CarBrand.Length < 25)
			{
				return CarInformationChanged;
			}
			return false;
		}
	}

	public IObservable<Unit> CloseCommand => OnClose.Debounce();

	protected CarFormViewModel(ICarsRepository carsRepository, DefaultErrorTranslator errorTranslator, Parameter parameter)
	{
		CarsRepository = carsRepository;
		ErrorTranslator = errorTranslator;
		_parameter = parameter;
		_onSave.PerformDebouncingTask(SaveCar).Subscribe().AddTo(base.CloseDisposable);
		if (_parameter.Car == null)
		{
			_startedCarColor = string.Empty;
			_startedCarBrand = string.Empty;
			_startedCarNumber = string.Empty;
		}
		else
		{
			_startedCarColor = _parameter.Car.CarColor;
			_startedCarBrand = _parameter.Car.CarMark;
			_startedCarNumber = _parameter.Car.CarNumber;
		}
	}

	public void OnSaveClick()
	{
		if (SaveButtonEnabled)
		{
			_onSave.OnNext(Unit.Default);
		}
	}

	protected abstract Task SaveCar();
}
