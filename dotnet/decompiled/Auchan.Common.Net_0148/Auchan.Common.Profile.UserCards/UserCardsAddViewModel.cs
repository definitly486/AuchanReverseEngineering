using System;
using System.Linq;
using System.Reactive;
using System.Reactive.Subjects;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AsyncAwaitBestPractices;
using Auchan.Common.Base;
using Auchan.Common.Base.Errors;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Common;
using Auchan.Common.Ecom;
using Auchan.Common.Extensions;
using Auchan.Common.Navigation;
using Auchan.Common.Networking;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Profile.UserCards;

[RequiresAuthorization]
public class UserCardsAddViewModel : ScreenViewModel
{
	private readonly string[] _urlsToIgnore = new string[1] { "favicon" };

	private readonly string _callbackUrl;

	private readonly IUserCardsService _userCardsService;

	private readonly DefaultErrorTranslator _errorTranslator;

	private readonly Subject<string> _onLoadTokenUrl = new Subject<string>();

	private readonly Subject<Unit> _onBack = new Subject<Unit>();

	[CompilerGenerated]
	private VisualState _003CState_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CScreenTitle_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CErrorMessage_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CErrorHint_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CErrorButtonText_003Ek__BackingField;

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

	public string ScreenTitle
	{
		[CompilerGenerated]
		get
		{
			return _003CScreenTitle_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CScreenTitle_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CScreenTitle_003Ek__BackingField = value;
				RaisePropertyChanged("ScreenTitle");
			}
		}
	} = "Новая карта";

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
	} = "";

	public string ErrorHint
	{
		[CompilerGenerated]
		get
		{
			return _003CErrorHint_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CErrorHint_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CErrorHint_003Ek__BackingField = value;
				RaisePropertyChanged("ErrorHint");
			}
		}
	} = "";

	public string ErrorButtonText
	{
		[CompilerGenerated]
		get
		{
			return _003CErrorButtonText_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CErrorButtonText_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CErrorButtonText_003Ek__BackingField = value;
				RaisePropertyChanged("ErrorButtonText");
			}
		}
	} = "Повторить";

	public IObservable<string> LoadTokenUrlCommand => _onLoadTokenUrl;

	public IObservable<Unit> GoBackCommand => _onBack.Debounce();

	public UserCardsAddViewModel(IUserCardsService userCardsService, DefaultErrorTranslator defaultErrorTranslator, CheckoutPaymentSuccessUrlProvider urlProvider, IEnvironmentManager environmentManager)
	{
		_userCardsService = userCardsService;
		_errorTranslator = defaultErrorTranslator;
		_callbackUrl = urlProvider.BaseUrlForEnvironment(environmentManager.CurrentEnvironment) + "/createTokenFinish";
	}

	protected override async Task Start()
	{
		await base.Start();
		await LoadTokenUrl();
	}

	public bool OnPageLoading(string url)
	{
		if (_urlsToIgnore.Any(url.Contains))
		{
			return true;
		}
		State = VisualState.InProgress;
		try
		{
			if (url.Contains(_callbackUrl))
			{
				OnRedirectToCallbackUrl();
				return true;
			}
		}
		catch (Exception)
		{
		}
		return false;
	}

	public void OnRedirectToCallbackUrl()
	{
		_onBack.OnNext(Unit.Default);
	}

	public void OnPageLoaded(string url)
	{
		if (!_urlsToIgnore.Any(url.Contains) && !url.Contains(_callbackUrl))
		{
			State = VisualState.Default;
		}
	}

	public void OnError(string error)
	{
		State = VisualState.Error;
		ErrorMessage = error;
		ErrorHint = "";
	}

	public void Retry()
	{
		LoadTokenUrl().SafeFireAndForget((Action<Exception>)null, false);
	}

	private async Task LoadTokenUrl()
	{
		State = VisualState.InProgress;
		Result<string, DomainError> result = await _userCardsService.AddCardUrl(_callbackUrl);
		if (result.IsFailure)
		{
			(string, string) tuple = _errorTranslator.Translate(result.Error);
			ErrorMessage = tuple.Item1;
			ErrorHint = tuple.Item2;
			State = VisualState.Error;
		}
		else
		{
			_onLoadTokenUrl.OnNext(result.Value);
		}
	}
}
