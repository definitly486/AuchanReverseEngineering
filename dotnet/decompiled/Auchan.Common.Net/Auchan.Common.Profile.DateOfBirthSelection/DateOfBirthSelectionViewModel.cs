using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Subjects;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Extensions;
using Auchan.Common.Profile.DateOfBirthSelection.Items.Contracts;
using Auchan.Common.Profile.Enums;

namespace Auchan.Common.Profile.DateOfBirthSelection;

public class DateOfBirthSelectionViewModel : ScreenViewModel
{
	public class Parameter
	{
		public DateTime? CurrentDate { get; }

		public Parameter(DateTime? currentDate)
		{
			CurrentDate = currentDate;
		}
	}

	private const int MonthsInYear = 12;

	private const int DaysInMonth = 31;

	private readonly DateTime _minPossibleDate = new DateTime(1900, 1, 1);

	private readonly DateTime _maxPossibleDate = DateTime.Now.Date.AddYears(-18).AddDays(-1.0);

	private DateTime? _initialDate;

	private int _currentYear = -1;

	private int _currentMonth = -1;

	private int _currentDay = -1;

	private readonly Subject<Unit> _closeCommand = new Subject<Unit>();

	private readonly Subject<DateTime> _saveCommand = new Subject<DateTime>();

	private readonly IInfoMessageService _infoMessageService;

	[CompilerGenerated]
	private VisualState _003CState_003Ek__BackingField;

	[CompilerGenerated]
	private IReadOnlyList<YearSelectorItemViewModel>? _003CYearsCollection_003Ek__BackingField;

	[CompilerGenerated]
	private IReadOnlyList<MonthSelectorItemViewModel>? _003CMonthsCollection_003Ek__BackingField;

	[CompilerGenerated]
	private IReadOnlyList<DaySelectorItemViewModel>? _003CAllDaysCollection_003Ek__BackingField;

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
	} = VisualState.Default;

	public string CloseTitle => "Закрыть";

	public string ScreenTitle => "Дата рождения";

	public string ScreenSubtitle
	{
		get
		{
			if (!IsAllDatePartsSelected)
			{
				return "Укажите дату";
			}
			return CurrentlySelectedDate.ToLongDateWithFullMonth().ToLower();
		}
	}

	public string SaveButtonTitle => "Сохранить";

	public bool IsSaveButtonEnabled
	{
		get
		{
			if (IsAllDatePartsSelected)
			{
				DateTime? initialDate = _initialDate;
				if (initialDate.HasValue)
				{
					return !_initialDate.Value.Date.Equals(CurrentlySelectedDate);
				}
				return true;
			}
			return false;
		}
	}

	public string CancelButtonTitle => "Отмена";

	public IReadOnlyList<YearSelectorItemViewModel>? YearsCollection
	{
		[CompilerGenerated]
		get
		{
			return _003CYearsCollection_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003CYearsCollection_003Ek__BackingField, value))
			{
				_003CYearsCollection_003Ek__BackingField = value;
				RaisePropertyChanged("YearsCollection");
			}
		}
	}

	public IReadOnlyList<MonthSelectorItemViewModel>? MonthsCollection
	{
		[CompilerGenerated]
		get
		{
			return _003CMonthsCollection_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003CMonthsCollection_003Ek__BackingField, value))
			{
				_003CMonthsCollection_003Ek__BackingField = value;
				RaisePropertyChanged("MonthsCollection");
			}
		}
	}

	public IReadOnlyList<DaySelectorItemViewModel>? AllDaysCollection
	{
		[CompilerGenerated]
		get
		{
			return _003CAllDaysCollection_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003CAllDaysCollection_003Ek__BackingField, value))
			{
				_003CAllDaysCollection_003Ek__BackingField = value;
				RaisePropertyChanged("AllDaysCollection");
			}
		}
	}

	public int YearCollectionInitialPositionIndex
	{
		get
		{
			if (_initialDate.HasValue)
			{
				return _initialDate.Value.Year - _minPossibleDate.Year;
			}
			return _maxPossibleDate.Year - _minPossibleDate.Year;
		}
	}

	public int MonthsCollectionInitialPositionIndex
	{
		get
		{
			ref DateTime? initialDate = ref _initialDate;
			if (!initialDate.HasValue)
			{
				return 0;
			}
			return initialDate.GetValueOrDefault().Month - 1;
		}
	}

	public IObservable<Unit> CloseCommand => _closeCommand.Debounce();

	public IObservable<DateTime> SaveCommand => _saveCommand.Debounce();

	private bool IsAllDatePartsSelected
	{
		get
		{
			if (_currentYear > 0 && _currentMonth > 0)
			{
				return _currentDay > 0;
			}
			return false;
		}
	}

	private DateTime CurrentlySelectedDate => new DateTime(_currentYear, _currentMonth, _currentDay).Date;

	public DateOfBirthSelectionViewModel(Parameter parameter, IInfoMessageService infoMessageService)
	{
		_initialDate = parameter.CurrentDate;
		_infoMessageService = infoMessageService;
		InitCurrentDatePartsFromDate();
	}

	private void InitCurrentDatePartsFromDate()
	{
		if (_initialDate.HasValue)
		{
			_currentYear = _initialDate.Value.Year;
			_currentMonth = _initialDate.Value.Month;
			_currentDay = _initialDate.Value.Day;
		}
	}

	protected override async Task Start()
	{
		State = VisualState.InProgress;
		if (_maxPossibleDate < _minPossibleDate)
		{
			await ShowWrongSystemDateError(DateOfBirthSelectorInitializationErrorType.WrongSettings);
			State = VisualState.Default;
			_closeCommand.OnNext(Unit.Default);
			return;
		}
		if (_initialDate.HasValue && _initialDate.Value.Date > _maxPossibleDate)
		{
			await ShowWrongSystemDateError(DateOfBirthSelectorInitializationErrorType.WrongInitialDate);
			_initialDate = null;
		}
		InitYears();
		InitMonths();
		InitDays();
		State = VisualState.Default;
	}

	public void OnCloseButtonSelected()
	{
		_closeCommand.OnNext(Unit.Default);
	}

	public void OnSaveButtonSelected()
	{
		_saveCommand.OnNext(CurrentlySelectedDate);
	}

	public void OnCancelButtonSelected()
	{
		RemoveSelectionForDatePartCollection(YearsCollection);
		RemoveSelectionForDatePartCollection(MonthsCollection);
		RemoveSelectionForDatePartCollection(AllDaysCollection);
		_currentYear = (_currentMonth = (_currentDay = -1));
		RaiseSelectionRelatedProperties();
	}

	private void InitYears()
	{
		List<YearSelectorItemViewModel> list = new List<YearSelectorItemViewModel>();
		for (int i = _minPossibleDate.Year; i <= _maxPossibleDate.Year; i++)
		{
			YearSelectorItemViewModel item = new YearSelectorItemViewModel(i, _initialDate.HasValue && _initialDate.Value.Year == i, OnDateSelectorItemChanged);
			list.Add(item);
		}
		YearsCollection = list;
	}

	private void InitMonths()
	{
		List<MonthSelectorItemViewModel> list = new List<MonthSelectorItemViewModel>();
		for (int i = 1; i <= 12; i++)
		{
			MonthSelectorItemViewModel monthSelectorItemViewModel = new MonthSelectorItemViewModel(i, _initialDate.HasValue && _initialDate.Value.Month == i, OnDateSelectorItemChanged);
			if (!_initialDate.HasValue)
			{
				monthSelectorItemViewModel.IsEnabled = true;
			}
			else
			{
				monthSelectorItemViewModel.IsEnabled = !IsMaxPossibleYear(_initialDate.Value.Year) || i <= _maxPossibleDate.Month;
			}
			list.Add(monthSelectorItemViewModel);
		}
		MonthsCollection = list;
	}

	private void InitDays()
	{
		List<DaySelectorItemViewModel> list = new List<DaySelectorItemViewModel>();
		for (int i = 1; i <= 31; i++)
		{
			DaySelectorItemViewModel daySelectorItemViewModel = new DaySelectorItemViewModel(i, _initialDate.HasValue && _initialDate.Value.Day == i, OnDateSelectorItemChanged);
			if (!_initialDate.HasValue)
			{
				daySelectorItemViewModel.IsEnabled = true;
			}
			else
			{
				int num = DateTime.DaysInMonth(_initialDate.Value.Year, _initialDate.Value.Month);
				bool flag = i <= num;
				daySelectorItemViewModel.IsEnabled = flag && (!IsMaxPossibleYearMonth(_initialDate.Value.Year, _initialDate.Value.Month) || i <= _maxPossibleDate.Day);
			}
			list.Add(daySelectorItemViewModel);
		}
		AllDaysCollection = list;
	}

	private void OnDateSelectorItemChanged(DateSelectorItemDatePart datePart, int datePartValue)
	{
		switch (datePart)
		{
		case DateSelectorItemDatePart.Year:
			OnYearChanged(datePartValue);
			break;
		case DateSelectorItemDatePart.Month:
			OnMonthChanged(datePartValue);
			break;
		case DateSelectorItemDatePart.Day:
			OnDayChanged(datePartValue);
			break;
		}
		RaiseSelectionRelatedProperties();
	}

	private void OnYearChanged(int selectedYear)
	{
		_currentYear = selectedYear;
		UpdateDatePartSelectionProperty(YearsCollection, selectedYear);
		for (int i = 0; i < 12; i++)
		{
			MonthSelectorItemViewModel monthSelectorItemViewModel = MonthsCollection[i];
			bool flag = (((IEnablable)monthSelectorItemViewModel).IsEnabled = !IsMaxPossibleYear(selectedYear) || i < _maxPossibleDate.Month);
			if (monthSelectorItemViewModel.IsSelected && !flag)
			{
				monthSelectorItemViewModel.IsSelected = false;
				_currentMonth = -1;
			}
		}
		RefreshEnabledDays();
	}

	private void OnMonthChanged(int selectedMonth)
	{
		_currentMonth = selectedMonth;
		UpdateDatePartSelectionProperty(MonthsCollection, _currentMonth);
		if (_currentYear >= 0)
		{
			RefreshEnabledDays();
		}
	}

	private void OnDayChanged(int selectedDay)
	{
		UpdateDatePartSelectionProperty(AllDaysCollection, selectedDay);
		_currentDay = selectedDay;
	}

	private void RefreshEnabledDays()
	{
		if (_currentMonth < 0 || _currentYear < 0)
		{
			return;
		}
		bool flag = IsMaxPossibleYearMonth(_currentYear, _currentMonth);
		int num = DateTime.DaysInMonth(_currentYear, _currentMonth);
		for (int i = 0; i < 31; i++)
		{
			DaySelectorItemViewModel daySelectorItemViewModel = AllDaysCollection[i];
			bool num2 = i < num;
			bool flag2 = !flag || i < _maxPossibleDate.Day;
			bool flag3 = num2 && flag2;
			((IEnablable)daySelectorItemViewModel).IsEnabled = flag3;
			if (daySelectorItemViewModel.IsSelected && !flag3)
			{
				daySelectorItemViewModel.IsSelected = false;
				_currentDay = -1;
			}
		}
	}

	private void UpdateDatePartSelectionProperty(IReadOnlyList<BaseDateSelectorItemViewModel> datePartItemsCollection, int datePartValue)
	{
		RemoveSelectionForDatePartCollection(datePartItemsCollection);
		datePartItemsCollection.First((BaseDateSelectorItemViewModel item) => item.DatePartValue == datePartValue).IsSelected = true;
	}

	private void RemoveSelectionForDatePartCollection(IReadOnlyList<BaseDateSelectorItemViewModel> datePartItemsCollection)
	{
		BaseDateSelectorItemViewModel baseDateSelectorItemViewModel = datePartItemsCollection.FirstOrDefault((BaseDateSelectorItemViewModel item) => item.IsSelected);
		if (baseDateSelectorItemViewModel != null)
		{
			baseDateSelectorItemViewModel.IsSelected = false;
		}
	}

	private void RaiseSelectionRelatedProperties()
	{
		RaisePropertyChanged("IsSaveButtonEnabled");
		RaisePropertyChanged("ScreenSubtitle");
	}

	private async Task ShowWrongSystemDateError(DateOfBirthSelectorInitializationErrorType errorType)
	{
		await _infoMessageService.ShowDialogAsync("Ошибка", "Не удалось инициализировать форму выбора даты рождения. " + ((errorType == DateOfBirthSelectorInitializationErrorType.WrongSettings) ? "Пожалуйста, проверьте настройки Даты и Времени устройства и убедитесь, что установлена актуальная дата." : "Текущая дата рождения содержит недопустимое значение!"), new AlertButton[1]
		{
			new AlertButton
			{
				Title = "ОК",
				Type = ActionType.Positive
			}
		});
	}

	private bool IsMaxPossibleYear(int year)
	{
		return _maxPossibleDate.Year == year;
	}

	private bool IsMaxPossibleYearMonth(int year, int month)
	{
		if (IsMaxPossibleYear(year))
		{
			return _maxPossibleDate.Month == month;
		}
		return false;
	}
}
