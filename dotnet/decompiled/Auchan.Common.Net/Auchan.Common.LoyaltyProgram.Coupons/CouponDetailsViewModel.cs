using System;
using System.Reactive;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using AsyncAwaitBestPractices;
using Auchan.Common.Analytics;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Common.Binding;
using Auchan.Common.Extensions;
using Auchan.Common.LoyaltyProgram.Coupons.Infrastructure;
using Auchan.Common.LoyaltyProgram.Coupons.Models;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.ApplicationModel.DataTransfer;

namespace Auchan.Common.LoyaltyProgram.Coupons;

public class CouponDetailsViewModel : ScreenViewModel<CouponDetailsViewModel.Parameter>
{
	public class Parameter(Coupon coupon) : BrokeredParameter<bool>(default(CancellationToken))
	{
		public Coupon Coupon { get; } = coupon;
	}

	private readonly CouponsRepository _couponsRepository;

	private readonly Parameter _parameter;

	private readonly IInfoMessageService _infoMessageService;

	[CompilerGenerated]
	private VisualState _003CState_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CCouponUsageTime_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CCouponTitle_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CCouponDescription_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CCouponValue_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CCouponUsageDescription_003Ek__BackingField;

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

	public string CouponUsageTime
	{
		[CompilerGenerated]
		get
		{
			return _003CCouponUsageTime_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CCouponUsageTime_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CCouponUsageTime_003Ek__BackingField = value;
				RaisePropertyChanged("CouponUsageTime");
			}
		}
	} = string.Empty;

	public string CouponTitle
	{
		[CompilerGenerated]
		get
		{
			return _003CCouponTitle_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CCouponTitle_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CCouponTitle_003Ek__BackingField = value;
				RaisePropertyChanged("CouponTitle");
			}
		}
	} = string.Empty;

	public string CouponDescription
	{
		[CompilerGenerated]
		get
		{
			return _003CCouponDescription_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CCouponDescription_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CCouponDescription_003Ek__BackingField = value;
				RaisePropertyChanged("CouponDescription");
			}
		}
	} = string.Empty;

	public string CouponValue
	{
		[CompilerGenerated]
		get
		{
			return _003CCouponValue_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CCouponValue_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CCouponValue_003Ek__BackingField = value;
				RaisePropertyChanged("CouponValue");
			}
		}
	} = string.Empty;

	public string CouponUsageDescription
	{
		[CompilerGenerated]
		get
		{
			return _003CCouponUsageDescription_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CCouponUsageDescription_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CCouponUsageDescription_003Ek__BackingField = value;
				RaisePropertyChanged("CouponUsageDescription");
			}
		}
	} = string.Empty;

	public string CouponFullDescriptionText { get; } = "Полные условия";

	public string? PromocodeTitle => "Промокод";

	public string ErrorTitle { get; } = "Сервис временно недоступен";

	public string ErrorDescription { get; } = "Попробуйте применить купон позже";

	public string RetryText { get; } = "Обновить";

	public UICommand RetryCommand { get; } = new UICommand();

	public UICommand CloseCommand { get; } = new UICommand();

	public UICommand OpenCouponDetailsCommand { get; } = new UICommand();

	public UICommand CopyPromocodeCommand { get; } = new UICommand();

	public CouponDetailsViewModel(BrokerToken parameter, CouponsRepository couponsRepository, IInfoMessageService infoMessageService)
		: base(parameter)
	{
		_parameter = base.Argument;
		_couponsRepository = couponsRepository;
		_infoMessageService = infoMessageService;
		RetryCommand.PerformDebouncingTask(ShowCoupon).Subscribe().AddTo(base.CloseDisposable);
		OpenCouponDetailsCommand.PerformDebouncingTask(OpenCouponDetailsAsync).Subscribe().AddTo(base.CloseDisposable);
		CopyPromocodeCommand.Subscribe(OnCopyPromocodeCommand).AddTo(base.CloseDisposable);
	}

	public void OpenCouponDetails()
	{
		AppAnalytics.AppMetrica.TrackEvent("Tap_Main_MyCoupons_conditions");
		OpenCouponDetailsCommand.Trigger();
	}

	protected override async Task Start()
	{
		await base.Start();
		await ShowCoupon();
	}

	private async Task ShowCoupon()
	{
		State = VisualState.InProgress;
		if (!_parameter.Coupon.UsageStartDate.HasValue || string.IsNullOrEmpty(_parameter.Coupon.CouponNumber))
		{
			State = VisualState.Error;
			return;
		}
		await _couponsRepository.OnCouponSeen(_parameter.Coupon.Id);
		AppAnalytics.AppMetrica.TrackEvent("TapMyCoupons_details");
		CouponUsageTime = $"с {_parameter.Coupon.UsageStartDate:M}";
		if (_parameter.Coupon.ExpiryDate.HasValue)
		{
			CouponUsageTime += $" до {_parameter.Coupon.ExpiryDate:M}";
		}
		CouponTitle = _parameter.Coupon.Name;
		CouponDescription = _parameter.Coupon.Description;
		CouponUsageDescription = _parameter.Coupon.BottomDescription;
		CouponValue = _parameter.Coupon.CouponNumber;
		State = VisualState.Default;
	}

	private async Task OpenCouponDetailsAsync()
	{
		AppAnalytics.AppMetrica.TrackEvent("TapMyCoupons_conditions");
		await Browser.Default.OpenAsync(_parameter.Coupon.MediaUrl);
	}

	private void OnCopyPromocodeCommand(Unit unit)
	{
		AppAnalytics.AppMetrica.TrackEvent("TapCopyPromoCode", ("CouponId", $"{_parameter.Coupon.Id}"), ("CouponName", CouponTitle ?? ""));
		Clipboard.SetTextAsync(CouponValue).SafeFireAndForget((Action<Exception>)null, false);
		_infoMessageService.ShowSnackbar("Промокод скопирован", SnackbarStyle.Success);
	}

	public override void Dispose()
	{
		base.Argument.TaskCompletionSource.TrySetResult(result: true);
		base.Dispose();
	}
}
