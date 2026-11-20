using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Analytics;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Common.Binding;
using Auchan.Common.Ecom.Address.Models;
using Auchan.Common.Navigation;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Ecom.PriceChecker;

public sealed class ManualBarcodeViewModel : ScreenViewModel<ManualBarcodeViewModel.Parameter>
{
	public sealed class Parameter : BrokeredParameter<Result<ValidationResult, ValidationError>>
	{
		public required Store Store { get; init; }

		public Parameter()
			: base(default(CancellationToken))
		{
		}
	}

	private readonly PriceChecker _priceChecker;

	private Result<ValidationResult, ValidationError> _result = new ValidationError
	{
		Barcode = ""
	};

	[CompilerGenerated]
	private VisualState _003CState_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CBarcode_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CCanCheckBarcode_003Ek__BackingField;

	public UICommand DismissCommand { get; } = new UICommand();

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

	public string Title => "Введите штрих-код с упаковки товара или ценника";

	public string Hint => "Номер состоит из 6-13 цифр";

	public string CheckPlaceholder => "Проверка штрих-кода...";

	public string ReadyButtonTitle => "Готово";

	public string Barcode
	{
		[CompilerGenerated]
		get
		{
			return _003CBarcode_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CBarcode_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CBarcode_003Ek__BackingField = value;
				RaisePropertyChanged("Barcode");
			}
		}
	} = string.Empty;

	public bool CanCheckBarcode
	{
		[CompilerGenerated]
		get
		{
			return _003CCanCheckBarcode_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CCanCheckBarcode_003Ek__BackingField != value)
			{
				_003CCanCheckBarcode_003Ek__BackingField = value;
				RaisePropertyChanged("CanCheckBarcode");
			}
		}
	}

	public ManualBarcodeViewModel(BrokerToken brokerToken, PriceChecker priceChecker, IInfoMessageService infoMessageService)
		: base(brokerToken)
	{
		_priceChecker = priceChecker;
	}

	public void OnEnterBarcode(string? barcode)
	{
		bool flag = !string.IsNullOrWhiteSpace(barcode) && (barcode.Length == 6 || barcode.Length == 8 || barcode.Length == 13);
		if (flag)
		{
			Barcode = barcode;
		}
		CanCheckBarcode = flag;
	}

	public async Task OkClicked()
	{
		State = VisualState.InProgress;
		Result<ValidationResult, ValidationError> result = await _priceChecker.Validate(base.Argument.Store, Barcode);
		AppAnalytics.AppMetrica.TrackEvent("TapPricecheckerBarcode", ("barcode", Barcode), ("result", result.IsFailure ? "error" : "success"));
		_result = result;
		Dismiss();
		State = VisualState.Default;
	}

	public void Clear()
	{
		Barcode = string.Empty;
	}

	public void Dismiss()
	{
		DismissCommand.Trigger();
	}

	public override NavigationPossibilityType OnNavigateFrom()
	{
		return NavigationPossibilityType.Impossible;
	}

	public override void Dispose()
	{
		base.Dispose();
		base.Argument.TaskCompletionSource.TrySetResult(_result);
	}
}
