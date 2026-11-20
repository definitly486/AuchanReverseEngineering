using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Auchan.Common.Analytics;
using Auchan.Common.Base;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Common;
using Auchan.Common.Common.Binding;
using Auchan.Common.Extensions;
using Auchan.Common.LoyaltyProgram.Coupons.Infrastructure;
using Auchan.Common.LoyaltyProgram.Coupons.Models;
using CSharpFunctionalExtensions;
using EBind;
using Newtonsoft.Json;

namespace Auchan.Common.LoyaltyProgram.Coupons;

public class CouponsViewModel : ScreenViewModel, ICouponsViewModel
{
	public enum VisualState
	{
		Default,
		InProgress,
		Error,
		Empty
	}

	public class Parameter
	{
		public long? IdToOpen { get; set; }

		public Parameter(long? id)
		{
			IdToOpen = id;
		}

		[JsonConstructor]
		public Parameter()
		{
		}
	}

	private readonly CouponsRepository _couponsRepository;

	private Parameter _parameter;

	private readonly IDataBroker _dataBroker;

	[CompilerGenerated]
	private VisualState _003CState_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CCouponsNewAvailable_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CCouponsNewText_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CErrorTitle_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CErrorDescription_003Ek__BackingField;

	[CompilerGenerated]
	private ObservableRangeCollection<CouponItemViewModel> _003CCoupons_003Ek__BackingField;

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

	public string Title { get; } = "Мои купоны и промокоды";

	public bool CouponsNewAvailable
	{
		[CompilerGenerated]
		get
		{
			return _003CCouponsNewAvailable_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CCouponsNewAvailable_003Ek__BackingField != value)
			{
				_003CCouponsNewAvailable_003Ek__BackingField = value;
				RaisePropertyChanged("CouponsNewAvailable");
			}
		}
	}

	public string CouponsNewText
	{
		[CompilerGenerated]
		get
		{
			return _003CCouponsNewText_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CCouponsNewText_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CCouponsNewText_003Ek__BackingField = value;
				RaisePropertyChanged("CouponsNewText");
			}
		}
	} = string.Empty;

	public string EmptyTitle => "Уже совсем скоро!";

	public string EmptyDescription => "Здесь появятся интересные предложения специально для вас";

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
	} = "Упс! Что-то пошло не так.";

	public string ErrorDescription
	{
		[CompilerGenerated]
		get
		{
			return _003CErrorDescription_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CErrorDescription_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CErrorDescription_003Ek__BackingField = value;
				RaisePropertyChanged("ErrorDescription");
			}
		}
	} = "Небольшие технические проблемы,\nпопробуйте обновить экран.";

	public string RetryText { get; } = "Обновить";

	public ObservableRangeCollection<CouponItemViewModel> Coupons
	{
		[CompilerGenerated]
		get
		{
			return _003CCoupons_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003CCoupons_003Ek__BackingField, value))
			{
				_003CCoupons_003Ek__BackingField = value;
				RaisePropertyChanged("Auchan.Common.LoyaltyProgram.Coupons.ICouponsViewModel.Coupons");
				RaisePropertyChanged("Coupons");
			}
		}
	} = new ObservableRangeCollection<CouponItemViewModel>();

	IReadOnlyList<CouponItemViewModel> ICouponsViewModel.Coupons => Coupons;

	public UICommand RetryCommand { get; } = new UICommand();

	public UICommand ShowQrCommand { get; } = new UICommand();

	public UICommand<BrokerToken> OpenCouponDetailsCommand { get; } = new UICommand<BrokerToken>();

	public UICommand CloseCommand { get; } = new UICommand();

	UICommand ICouponsViewModel.OpenAboutCouponsCommand => new UICommand();

	public CouponsViewModel(Parameter parameter, IDataBroker dataBroker, CouponsRepository couponsRepository)
	{
		_parameter = parameter;
		_couponsRepository = couponsRepository;
		_dataBroker = dataBroker;
		RetryCommand.PerformDebouncingTask(LoadCoupons).Subscribe().AddTo(base.CloseDisposable);
		_couponsRepository.CouponSeen += new DisposableDelegate<EventHandler<long>>(delegate(object? _, long couponId)
		{
			Coupons.FirstOrDefault((CouponItemViewModel c) => c.Id == couponId)?.SetCouponSeen();
			CouponsNewAvailable = Coupons.Any((CouponItemViewModel c) => c.IsNew);
			if (CouponsNewAvailable)
			{
				int value = Coupons.Count((CouponItemViewModel c) => c.IsNew);
				CouponsNewText = $"+{value}";
			}
			Coupons.ReplaceRange((from c in _couponsRepository.OrderCoupons(Coupons.Select((CouponItemViewModel c) => c.Coupon).ToList())
				select new CouponItemViewModel(c)).ToList());
		}, delegate(EventHandler<long> d)
		{
			_couponsRepository.CouponSeen -= d;
		}).AddTo(base.CloseDisposable);
	}

	protected override async Task Start()
	{
		await base.Start();
		RetryCommand.Trigger();
		AppAnalytics.AppMetrica.TrackEvent("TapLoyaltyMyCoupons");
		if (_parameter.IdToOpen.HasValue)
		{
			await LoadCoupons();
			CouponItemViewModel couponItemViewModel = Coupons.FirstOrDefault((CouponItemViewModel c) => c.Id == _parameter.IdToOpen);
			lock (_parameter)
			{
				_parameter = new Parameter(null);
			}
			if (couponItemViewModel != null)
			{
				CouponDetailsViewModel.Parameter parameter = new CouponDetailsViewModel.Parameter(couponItemViewModel.Coupon);
				OpenCouponDetailsCommand.Trigger(_dataBroker.Push(parameter));
				await parameter.WaitForResultAsync();
				CloseCommand.Trigger();
			}
		}
	}

	protected override async Task OnResumed()
	{
		await base.OnResumed();
		RetryCommand.Trigger();
	}

	public void ShowQr()
	{
		ShowQrCommand.Trigger();
	}

	public void CouponTapped(CouponItemViewModel c)
	{
		AppAnalytics.AppMetrica.TrackEvent("Tap_offer");
		OpenCouponDetailsCommand.Trigger(_dataBroker.Push(new CouponDetailsViewModel.Parameter(c.Coupon)));
	}

	private async Task LoadCoupons()
	{
		State = VisualState.InProgress;
		Result<List<Coupon>, DomainError> result = await _couponsRepository.GetCoupons();
		if (result.IsFailure)
		{
			CouponsNewAvailable = false;
			Coupons.Clear();
			State = ((result.Error is NoDataError) ? VisualState.Empty : VisualState.Error);
			return;
		}
		if (result.IsSuccess && result.Value.Count == 0)
		{
			State = VisualState.Empty;
			return;
		}
		Coupons.ReplaceRange(result.Value.Select((Coupon c) => new CouponItemViewModel(c)).ToList());
		CouponsNewAvailable = result.Value.Any((Coupon c) => c.IsNew);
		if (CouponsNewAvailable)
		{
			int value = result.Value.Count((Coupon c) => c.IsNew);
			CouponsNewText = $"+{value}";
		}
		await Task.Delay(500);
		State = VisualState.Default;
	}
}
