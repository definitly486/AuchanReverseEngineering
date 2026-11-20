using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AsyncAwaitBestPractices;
using Auchan.Common.AdminTool;
using Auchan.Common.Base;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Common;
using Auchan.Common.Common.Binding;
using Auchan.Common.InfoPages.Models;
using Auchan.Common.Networking;
using Auchan.Common.PersonalCabinet;
using Auchan.Common.UniversalLinks;
using CSharpFunctionalExtensions;

namespace Auchan.Common.InfoPages;

public class TutorialViewModel : ScreenViewModel
{
	public enum VisualState
	{
		Default,
		Error,
		InProgress
	}

	public class Parameter
	{
		public Tutorial Tutorial { get; }

		public Parameter(Tutorial tutorial)
		{
			Tutorial = tutorial;
		}
	}

	private readonly IUniversalLinksService _universalLinksService;

	private readonly ITokenService _tokenService;

	private readonly IAdminContext _adminContext;

	private readonly IDeviceService _deviceService;

	private readonly Tutorial _tutorial;

	private string? _webViewToken80;

	private IDictionary<string, string> _webViewHeaders = new Dictionary<string, string>();

	[CompilerGenerated]
	private bool _003CIsLoaded_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CErrorTitle_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CErrorMessage_003Ek__BackingField;

	[CompilerGenerated]
	private VisualState _003CState_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CErrorButtonText_003Ek__BackingField;

	public bool IsLoaded
	{
		[CompilerGenerated]
		get
		{
			return _003CIsLoaded_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CIsLoaded_003Ek__BackingField != value)
			{
				_003CIsLoaded_003Ek__BackingField = value;
				RaisePropertyChanged("IsLoaded");
			}
		}
	}

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
	} = "Небольшие технические проблемы,\nпопробуйте обновить экран.";

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

	public TutorialContentType ContentType => _tutorial.ContentType;

	public string Title => _tutorial.Title;

	public string HtmlWrappedDescription => HtmlConverter.WrapIntoHtml(_tutorial.Description);

	public string Url => _tutorial.Url;

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

	public UICommand LoadDataCommand { get; } = new UICommand();

	public TutorialViewModel(Parameter parameter, IUniversalLinksService universalLinksService, ITokenService tokenService, IAdminContext adminContext, IDeviceService deviceService)
	{
		_tutorial = parameter.Tutorial;
		_universalLinksService = universalLinksService;
		_tokenService = tokenService;
		_adminContext = adminContext;
		_deviceService = deviceService;
	}

	protected override async Task Start()
	{
		await base.Start();
		await LoadTutorial();
	}

	public override void Dispose()
	{
		_webViewToken80 = null;
		_webViewHeaders.Clear();
		base.Dispose();
	}

	public void RetryClick()
	{
		LoadTutorial().SafeFireAndForget((Action<Exception>)null, false);
	}

	private async Task LoadTutorial()
	{
		if (ContentType == TutorialContentType.WebView)
		{
			await PrepareWebViewHeaders();
		}
		else
		{
			_webViewToken80 = null;
		}
		IsLoaded = true;
		LoadDataCommand.Trigger();
	}

	private async Task PrepareWebViewHeaders()
	{
		_webViewToken80 = null;
		if (AuchanHeaderHostFilter.ShouldInject(Url))
		{
			Result<TokenModel, DomainError> result = await _tokenService.SavedToken80();
			if (result.IsSuccess)
			{
				_webViewToken80 = result.Value.Token;
			}
		}
	}

	public IDictionary<string, string> GetWebViewHeaders(string? url)
	{
		_webViewHeaders.Clear();
		if (AuchanHeaderHostFilter.ShouldInject(url))
		{
			_webViewHeaders["Authorization"] = "Basic " + _adminContext.AppConfig.BasicAuthToken;
			_webViewHeaders["x-app-user-agent"] = _deviceService.BuildNumberAndOSVersion;
			if (!string.IsNullOrWhiteSpace(_webViewToken80))
			{
				_webViewHeaders["X-Token-CMD"] = _webViewToken80;
			}
		}
		return _webViewHeaders;
	}

	public bool OverrideUrlHandlingIfNeccesary(string url)
	{
		if (_universalLinksService.ShouldHandleLink(url))
		{
			_universalLinksService.HandleLink(url);
			return true;
		}
		return false;
	}

	public void OnPageStarted()
	{
		State = VisualState.InProgress;
	}

	public void OnPageFinished()
	{
		State = VisualState.Default;
	}

	public void OnPageError()
	{
		ErrorTitle = "Упс! Что-то пошло не так.";
		ErrorMessage = "Небольшие технические проблемы,\nпопробуйте обновить экран.";
		State = VisualState.Error;
	}
}
