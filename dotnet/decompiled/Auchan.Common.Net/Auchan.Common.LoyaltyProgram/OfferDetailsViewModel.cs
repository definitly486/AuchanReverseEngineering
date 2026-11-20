using System;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using AsyncAwaitBestPractices;
using Auchan.Common.AdminTool;
using Auchan.Common.Analytics;
using Auchan.Common.Base;
using Auchan.Common.Base.Errors;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Common;
using Auchan.Common.Common.Binding;
using Auchan.Common.Home;
using Auchan.Common.PersonalOffers;
using Auchan.Common.UniversalLinks;
using CSharpFunctionalExtensions;
using Microsoft.Maui.ApplicationModel;

namespace Auchan.Common.LoyaltyProgram;

public class OfferDetailsViewModel : ScreenViewModel<OfferDetailsViewModel.Parameter>
{
	public class OfferDetailsResult
	{
		public bool HasChanges { get; set; }

		public bool WentElsewhere { get; set; }
	}

	public class Parameter : BrokeredParameter<OfferDetailsResult>
	{
		public string Code { get; set; }

		[JsonConstructor]
		public Parameter(string code)
			: base(default(CancellationToken))
		{
			Code = code;
		}
	}

	private readonly PersonalOffersService _personalOffersService;

	private readonly IUniversalLinksService _universalLinksService;

	private readonly IAdminContext _adminContext;

	private readonly IErrorTranslator _errorTranslator;

	private readonly Lazy<IInfoMessageService> _infoMessageService;

	private string _offerCode;

	[CompilerGenerated]
	private string _003CErrorTitle_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CErrorDescription_003Ek__BackingField;

	[CompilerGenerated]
	private PersOfferItemViewModel? _003COfferModel_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CContent_003Ek__BackingField;

	[CompilerGenerated]
	private VisualState _003CState_003Ek__BackingField;

	private bool _hasChanges;

	public override bool ShowInPopup => true;

	public string ActivateButtonTitle => "Активировать";

	public string ActivatedLabel => "Активировано";

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
	} = "";

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
	} = "";

	public PersOfferItemViewModel? OfferModel
	{
		[CompilerGenerated]
		get
		{
			return _003COfferModel_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003COfferModel_003Ek__BackingField, value))
			{
				_003COfferModel_003Ek__BackingField = value;
				RaisePropertyChanged("OfferModel");
			}
		}
	}

	public string Content
	{
		[CompilerGenerated]
		get
		{
			return _003CContent_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CContent_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CContent_003Ek__BackingField = value;
				RaisePropertyChanged("Content");
			}
		}
	} = "";

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
	}

	public UICommand CloseCommand { get; } = new UICommand();

	public UICommand<string> OpenBrowserCommand { get; } = new UICommand<string>();

	public OfferDetailsViewModel(BrokerToken parameter, PersonalOffersService personalOffersService, IUniversalLinksService universalLinksService, DefaultErrorTranslator defaultErrorTranslator, Lazy<IInfoMessageService> infoMessageService, IAdminContext adminContext)
		: base(parameter)
	{
		_adminContext = adminContext;
		_infoMessageService = infoMessageService;
		_errorTranslator = defaultErrorTranslator;
		_offerCode = base.Argument.Code;
		_personalOffersService = personalOffersService;
		_universalLinksService = universalLinksService;
	}

	protected override async Task Start()
	{
		await base.Start();
		await LoadOfferDetails();
	}

	private async Task LoadOfferDetails()
	{
		State = VisualState.InProgress;
		Result<PersOfferItemViewModel, DomainError> result = await _personalOffersService.PersonalOfferDetails(_offerCode);
		if (result.IsSuccess)
		{
			OfferModel = result.Value;
			Content = OfferModel.DetailsText;
			_hasChanges = !_adminContext.IsMyOfferViewed(OfferModel.Code);
			_adminContext.SaveViewedMyOfferId(OfferModel.Code);
			OfferModel.Update();
			RaisePropertyChanged("OfferModel");
			State = VisualState.Default;
		}
		else
		{
			(string, string) tuple = _errorTranslator.Translate(result.Error);
			ErrorTitle = tuple.Item1;
			ErrorDescription = tuple.Item2;
			State = VisualState.Error;
		}
	}

	public void Retry()
	{
		LoadOfferDetails().SafeFireAndForget((Action<Exception>)null, false);
	}

	public async Task AcceptOfferTapped()
	{
		if (OfferModel != null)
		{
			AppAnalytics.AppMetrica.TrackEvent("Tap_MainPersonal_offer_activate");
			_hasChanges = true;
			if ((await _personalOffersService.ActivatePersonalOffer(OfferModel.LoymaxId)).IsSuccess)
			{
				OfferModel.IsAccepted = true;
				_adminContext.InvalidatePersOffersCache();
				_adminContext.GetPersonalOffers().SafeFireAndForget((Action<Exception>)null, false);
				RaisePropertyChanged("OfferModel");
			}
			else
			{
				_infoMessageService.Value.ShowSnackbar("К сожалению, сейчас активация невозможна. Попробуйте позднее.");
			}
		}
	}

	public void HandleUrl(string url)
	{
		if (_universalLinksService.ShouldHandleLink(url))
		{
			AppAnalytics.AppMetrica.TrackEvent("TapPersonalOfferView");
			if (!_universalLinksService.ShouldOpenInBrowser(url))
			{
				base.Argument.TaskCompletionSource.TrySetResult(new OfferDetailsResult
				{
					WentElsewhere = true,
					HasChanges = _hasChanges
				});
			}
			_universalLinksService.HandleLink(url).SafeFireAndForget((Action<Exception>)null, false);
		}
		else
		{
			Browser.Default.OpenAsync(url).SafeFireAndForget((Action<Exception>)null, false);
		}
	}

	public override void Dispose()
	{
		base.Dispose();
		base.Argument.TaskCompletionSource.TrySetResult(new OfferDetailsResult
		{
			WentElsewhere = false,
			HasChanges = _hasChanges
		});
	}
}
