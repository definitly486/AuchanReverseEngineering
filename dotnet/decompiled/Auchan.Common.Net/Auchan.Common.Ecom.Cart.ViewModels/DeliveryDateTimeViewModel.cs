using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Analytics;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Common.Binding;
using Auchan.Common.Ecom.Cart.Models;
using Auchan.Common.Extensions;
using Auchan.Common.Logs;

namespace Auchan.Common.Ecom.Cart.ViewModels;

public class DeliveryDateTimeViewModel : ScreenViewModel<DeliveryDateTimeViewModel.Parameter>
{
	public sealed class Parameter : BrokeredParameter<SelectedDateTime?>
	{
		public required IReadOnlyList<CheckoutDate> Dates { get; init; }

		public required SelectedDateTime? SelectedDateTime { get; init; }

		public required CheckoutReceiveMethod ReceiveMethod { get; init; }

		public Parameter()
			: base(default(CancellationToken))
		{
		}
	}

	private SelectedDateTime? _result;

	private readonly ILogService _logService;

	private readonly HashSet<string> _displayedSurgeSlots = new HashSet<string>();

	[CompilerGenerated]
	private IReadOnlyList<TimeItemViewModel> _003CDeliveryTimes_003Ek__BackingField;

	[CompilerGenerated]
	private DateItemViewModel? _003CSelectedDate_003Ek__BackingField;

	[CompilerGenerated]
	private SelectedDateTime? _003CSelectedSlot_003Ek__BackingField;

	public string Title
	{
		get
		{
			if (!ReceiveMethod.IsDelivery())
			{
				return "Дата и время получения";
			}
			return "Дата и время доставки";
		}
	}

	public string SaveButtonText => "Сохранить выбранное время";

	public CheckoutReceiveMethod ReceiveMethod => base.Argument.ReceiveMethod;

	public IReadOnlyList<DateItemViewModel> DeliveryDates { get; }

	public IReadOnlyList<TimeItemViewModel> DeliveryTimes
	{
		[CompilerGenerated]
		get
		{
			return _003CDeliveryTimes_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003CDeliveryTimes_003Ek__BackingField, value))
			{
				_003CDeliveryTimes_003Ek__BackingField = value;
				RaisePropertyChanged("DeliveryTimes");
			}
		}
	}

	public bool CanSave => SelectedSlot != null;

	public UICommand CloseCommand { get; } = new UICommand();

	public DateItemViewModel? SelectedDate
	{
		[CompilerGenerated]
		get
		{
			return _003CSelectedDate_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!object.Equals(_003CSelectedDate_003Ek__BackingField, value))
			{
				DateItemViewModel selectedDate = SelectedDate;
				_003CSelectedDate_003Ek__BackingField = value;
				DateItemViewModel selectedDate2 = SelectedDate;
				OnSelectedDateChanged(selectedDate, selectedDate2);
				RaisePropertyChanged("SelectedDate");
			}
		}
	}

	public SelectedDateTime? SelectedSlot
	{
		[CompilerGenerated]
		get
		{
			return _003CSelectedSlot_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003CSelectedSlot_003Ek__BackingField, value))
			{
				_003CSelectedSlot_003Ek__BackingField = value;
				RaisePropertyChanged("CanSave");
				RaisePropertyChanged("SelectedSlot");
			}
		}
	}

	public DeliveryDateTimeViewModel(BrokerToken brokerToken, ILogService logService)
		: base(brokerToken)
	{
		_logService = logService;
		SelectedSlot = base.Argument.SelectedDateTime;
		List<DateItemViewModel> list = new List<DateItemViewModel>();
		list.AddRange(base.Argument.Dates.Select((CheckoutDate i) => new DateItemViewModel(i, this, selected: false)));
		DeliveryDates = new _003C_003Ez__ReadOnlyList<DateItemViewModel>(list);
		DeliveryTimes = Array.Empty<TimeItemViewModel>();
		SelectedDate = DeliveryDates.FirstOrDefault(delegate(DateItemViewModel i)
		{
			DateTimeOffset date = i.Item.Date;
			DateTimeOffset? obj = SelectedSlot?.Day.Date;
			return date == obj;
		}) ?? DeliveryDates.FirstOrDefault();
		base.Argument.CancellationToken.Register(delegate
		{
			CloseCommand.Trigger();
		}).AddTo(base.CloseDisposable);
	}

	protected override async Task OnResumed()
	{
		_logService.LogInfo("DeliveryPickerViewModel", "Открыт блок выбора времени доставки", LogType.UserAction, SystemType.MobileApp);
		await base.Start();
	}

	public void SelectTime(TimeItemViewModel time)
	{
		if (SelectedDate == null)
		{
			return;
		}
		SelectedSlot = new SelectedDateTime
		{
			Day = SelectedDate.Item,
			Time = time.Item
		};
		foreach (TimeItemViewModel deliveryTime in DeliveryTimes)
		{
			deliveryTime.Selected = deliveryTime == time;
		}
	}

	public void Save()
	{
		if (SelectedSlot != null)
		{
			_result = SelectedSlot;
			CloseCommand.Trigger();
		}
	}

	private bool IsSelected(CheckoutDate date, CheckoutTime time)
	{
		if (SelectedSlot != null && SelectedSlot.Day.Date == date.Date)
		{
			return SelectedSlot.Time.Id == time.Id;
		}
		return false;
	}

	private void OnSelectedDateChanged(DateItemViewModel? old, DateItemViewModel? @new)
	{
		if (old != null)
		{
			old.Selected = false;
		}
		if (@new != null)
		{
			@new.Selected = true;
		}
		IReadOnlyList<TimeItemViewModel> deliveryTimes;
		if (@new != null)
		{
			List<TimeItemViewModel> list = new List<TimeItemViewModel>();
			list.AddRange(@new.Item.Time.Select((CheckoutTime i) => new TimeItemViewModel(i, this, IsSelected(@new.Item, i))));
			IReadOnlyList<TimeItemViewModel> readOnlyList = new _003C_003Ez__ReadOnlyList<TimeItemViewModel>(list);
			deliveryTimes = readOnlyList;
		}
		else
		{
			IReadOnlyList<TimeItemViewModel> readOnlyList = Array.Empty<TimeItemViewModel>();
			deliveryTimes = readOnlyList;
		}
		DeliveryTimes = deliveryTimes;
		if (DeliveryTimes.FirstOrDefault((TimeItemViewModel i) => i.Selected) == null)
		{
			TimeItemViewModel timeItemViewModel = DeliveryTimes.FirstOrDefault();
			if (timeItemViewModel != null)
			{
				SelectTime(timeItemViewModel);
			}
		}
		foreach (TimeItemViewModel item in DeliveryTimes.Where((TimeItemViewModel i) => i.HasSurge))
		{
			if (@new != null && _displayedSurgeSlots.Add($"{@new.Item.Date:yyyyMMdd}:{item.Item.Id}"))
			{
				AppAnalytics.AppMetrica.SurgeSlotDisplayed();
			}
		}
	}

	protected override Task OnPaused()
	{
		CloseCommand.Trigger();
		return base.OnPaused();
	}

	public void OnCloseCompleted()
	{
		base.Argument.TaskCompletionSource.TrySetResult(_result);
	}

	public override void Dispose()
	{
		OnCloseCompleted();
		base.Dispose();
	}
}
