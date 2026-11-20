using System;
using System.Runtime.CompilerServices;
using System.Threading;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Common.Binding;
using Auchan.Common.InfoPages;

namespace Auchan.Common.PersonalCabinet.Authorization;

public sealed class VkSignUpViewModel : ScreenViewModel<VkSignUpViewModel.Parameter>
{
	public sealed class Parameter : BrokeredParameter<Result?>
	{
		public Parameter()
			: base(default(CancellationToken))
		{
		}
	}

	public sealed class Result
	{
		public required bool PrivacyDataConsentCheck { get; init; }

		public required bool WantReceivePromoCheck { get; init; }
	}

	private Result? _result;

	[CompilerGenerated]
	private bool _003CPrivacyDataConsentCheck_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CWantReceivePromoCheck_003Ek__BackingField;

	public string Title => "Осталось совсем немного...";

	public LinkedText PrivacyDataConsentText { get; }

	public LinkedText WantReceivePromoText { get; }

	public bool PrivacyDataConsentCheck
	{
		[CompilerGenerated]
		get
		{
			return _003CPrivacyDataConsentCheck_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (_003CPrivacyDataConsentCheck_003Ek__BackingField != value)
			{
				_003CPrivacyDataConsentCheck_003Ek__BackingField = value;
				RaisePropertyChanged("IsSignUpButtonEnabled");
				RaisePropertyChanged("PrivacyDataConsentCheck");
			}
		}
	}

	public bool WantReceivePromoCheck
	{
		[CompilerGenerated]
		get
		{
			return _003CWantReceivePromoCheck_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (_003CWantReceivePromoCheck_003Ek__BackingField != value)
			{
				_003CWantReceivePromoCheck_003Ek__BackingField = value;
				RaisePropertyChanged("WantReceivePromoCheck");
			}
		}
	}

	public bool IsSignUpButtonEnabled => PrivacyDataConsentCheck;

	public string SignUpButtonText => "За покупками в АШАН";

	public UICommand<InfoPageViewModel.Parameter> OpenInfoPageCommand { get; } = new UICommand<InfoPageViewModel.Parameter>();

	public UICommand CloseCommand { get; } = new UICommand();

	public VkSignUpViewModel(BrokerToken brokerToken)
		: base(brokerToken)
	{
		PrivacyDataConsentText = new LinkedText("Согласен с обработкой персональных данных и политикой по обработке персональных данных", new string[2] { "обработкой персональных данных", "политикой по обработке персональных данных" }, new Action[2]
		{
			delegate
			{
				OpenInfoPageCommand.Trigger(new InfoPageViewModel.Parameter(InfoType.PersonalDataProcessingAgreement));
			},
			delegate
			{
				OpenInfoPageCommand.Trigger(new InfoPageViewModel.Parameter(InfoType.PersonalDataProcessingPolicy));
			}
		});
		WantReceivePromoText = new LinkedText("Согласен на получение рекламных сообщений", "получение рекламных сообщений", delegate
		{
			OpenInfoPageCommand.Trigger(new InfoPageViewModel.Parameter(InfoType.AdvertisementConsent));
		});
	}

	public void Close()
	{
		CloseCommand.Trigger();
	}

	public void SignUp()
	{
		_result = new Result
		{
			PrivacyDataConsentCheck = PrivacyDataConsentCheck,
			WantReceivePromoCheck = WantReceivePromoCheck
		};
		CloseCommand.Trigger();
	}

	public override void Dispose()
	{
		base.Dispose();
		base.Argument.TaskCompletionSource.TrySetResult(_result);
	}
}
