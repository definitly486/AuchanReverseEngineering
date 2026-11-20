using System;
using System.Collections.Generic;
using System.Reactive;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AsyncAwaitBestPractices;
using Auchan.Common.AdminTool;
using Auchan.Common.Base;
using Auchan.Common.Base.Errors;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Common;
using Auchan.Common.Common.Binding;
using Auchan.Common.Extensions;
using Auchan.Common.InfoPages.Models;
using Auchan.Common.Networking;
using Auchan.Common.PersonalCabinet;
using Auchan.Common.UniversalLinks;
using CSharpFunctionalExtensions;
using Microsoft.Maui.ApplicationModel;

namespace Auchan.Common.InfoPages;

public class InfoPageViewModel : ScreenViewModel
{
	public enum VisualState
	{
		Default,
		InProgress,
		Error
	}

	public class Parameter
	{
		public string Slug { get; set; }

		public bool TabBarVisible { get; set; } = true;

		public Parameter()
		{
			Slug = "";
		}

		public Parameter(string slug)
		{
			Slug = slug;
		}

		public Parameter(InfoType infoType)
		{
			Slug = InfoPagesConverter.InfoTypeToSlug(infoType);
		}
	}

	private readonly IUserContext _userContext;

	private readonly IInfoPagesRepository _infoPagesRepository;

	private readonly IErrorTranslator _errorTranslator;

	private readonly IUniversalLinksService _universalLinksService;

	private readonly ITokenService _tokenService;

	private readonly IAdminContext _adminContext;

	private readonly IDeviceService _deviceService;

	private string? _webViewToken80;

	private IDictionary<string, string> _webViewHeaders = new Dictionary<string, string>();

	private bool _initialWebViewLoadCompleted;

	private readonly Parameter _parameter;

	[CompilerGenerated]
	private InfoContentType _003CInfoContentType_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CInfoUrl_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CInfoTitle_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CInfoContent_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CInfoBannerUrl_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CErrorTitle_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CErrorMessage_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CErrorButtonText_003Ek__BackingField;

	[CompilerGenerated]
	private VisualState _003CState_003Ek__BackingField;

	public InfoContentType InfoContentType
	{
		[CompilerGenerated]
		get
		{
			return _003CInfoContentType_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CInfoContentType_003Ek__BackingField != value)
			{
				_003CInfoContentType_003Ek__BackingField = value;
				RaisePropertyChanged("InfoContentType");
			}
		}
	}

	public string InfoUrl
	{
		[CompilerGenerated]
		get
		{
			return _003CInfoUrl_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CInfoUrl_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CInfoUrl_003Ek__BackingField = value;
				RaisePropertyChanged("InfoUrl");
			}
		}
	} = "";

	public string InfoTitle
	{
		[CompilerGenerated]
		get
		{
			return _003CInfoTitle_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CInfoTitle_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CInfoTitle_003Ek__BackingField = value;
				RaisePropertyChanged("InfoTitle");
			}
		}
	} = "";

	public string HtmlWrappedInfoContent => HtmlConverter.WrapIntoHtml(InfoContent);

	public string InfoContent
	{
		[CompilerGenerated]
		get
		{
			return _003CInfoContent_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CInfoContent_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CInfoContent_003Ek__BackingField = value;
				RaisePropertyChanged("HtmlWrappedInfoContent");
				RaisePropertyChanged("InfoContent");
			}
		}
	} = "";

	public bool IsBannerVisible => !string.IsNullOrEmpty(InfoBannerUrl);

	public string InfoBannerUrl
	{
		[CompilerGenerated]
		get
		{
			return _003CInfoBannerUrl_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CInfoBannerUrl_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CInfoBannerUrl_003Ek__BackingField = value;
				RaisePropertyChanged("IsBannerVisible");
				RaisePropertyChanged("InfoBannerUrl");
			}
		}
	} = "";

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

	public VisualState State
	{
		[CompilerGenerated]
		get
		{
			return _003CState_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (_003CState_003Ek__BackingField != value)
			{
				_003CState_003Ek__BackingField = value;
				RaisePropertyChanged("State");
			}
		}
	} = VisualState.InProgress;

	public UICommand<InfoContentType> LoadDataCommand { get; } = new UICommand<InfoContentType>();

	public UICommand RetryCommand { get; } = new UICommand();

	public UICommand<string> OpenSystemBrowserCommand { get; } = new UICommand<string>();

	public override bool TabBarVisible
	{
		get
		{
			return _parameter.TabBarVisible;
		}
		protected set
		{
			if (TabBarVisible != value)
			{
				base.TabBarVisible = value;
			}
		}
	}

	public bool IsQrButtonVisible => _userContext.Authorized;

	public InfoPageViewModel(IUserContext userContext, IInfoPagesRepository infoPagesRepository, DefaultErrorTranslator defaultErrorTranslator, Parameter parameter, IUniversalLinksService universalLinksService, ITokenService tokenService, IAdminContext adminContext, IDeviceService deviceService)
	{
		_userContext = userContext;
		_infoPagesRepository = infoPagesRepository;
		_errorTranslator = defaultErrorTranslator;
		_parameter = parameter;
		_universalLinksService = universalLinksService;
		_tokenService = tokenService;
		_adminContext = adminContext;
		_deviceService = deviceService;
		RetryCommand.PerformDebouncingTask((Unit _) => LoadInfo()).Subscribe().AddTo(base.CloseDisposable);
	}

	protected override async Task Start()
	{
		await base.Start();
		await LoadInfo();
	}

	public override void Dispose()
	{
		_webViewToken80 = null;
		_webViewHeaders.Clear();
		base.Dispose();
	}

	private async Task LoadInfo()
	{
		State = VisualState.InProgress;
		Result<InfoPage, DomainError> result = await _infoPagesRepository.InfoPage(_parameter.Slug);
		if (result.IsSuccess)
		{
			InfoContentType = result.Value.ContentType;
			switch (InfoContentType)
			{
			case InfoContentType.Native:
				_webViewToken80 = null;
				_webViewHeaders.Clear();
				LoadAsNative(result.Value);
				break;
			case InfoContentType.Webview:
				LoadAsWebView(result.Value);
				await PrepareWebViewHeaders(InfoUrl);
				break;
			}
			State = VisualState.Default;
			LoadDataCommand.Trigger(InfoContentType);
		}
		else
		{
			(string, string) tuple = _errorTranslator.Translate(result.Error);
			ErrorTitle = tuple.Item1;
			ErrorMessage = tuple.Item2;
			State = VisualState.Error;
		}
	}

	private void LoadAsNative(InfoPage response)
	{
		InfoTitle = response.Title;
		InfoContent = response.Content;
		InfoBannerUrl = response.BannerUrl;
	}

	private void LoadAsWebView(InfoPage response)
	{
		_initialWebViewLoadCompleted = false;
		InfoTitle = response.Title;
		InfoUrl = response.Url;
	}

	public async Task PrepareWebViewHeaders(string? url)
	{
		_webViewToken80 = null;
		if (AuchanHeaderHostFilter.ShouldInject(url))
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

	public void RetryClick()
	{
		RetryCommand.Trigger();
	}

	public bool OverrideUrlHandlingIfNeccesary(string url, bool opensNewWindow = false)
	{
		if (InfoContentType == InfoContentType.Webview)
		{
			if (opensNewWindow)
			{
				OpenSystemBrowserCommand.Trigger(url);
				return true;
			}
			if (!_initialWebViewLoadCompleted)
			{
				return false;
			}
			if (Uri.TryCreate(url, UriKind.Absolute, out Uri result) && (result.Scheme == Uri.UriSchemeHttp || result.Scheme == Uri.UriSchemeHttps) && !result.IsAuchanHost())
			{
				OpenSystemBrowserCommand.Trigger(url);
				return true;
			}
		}
		if (!Uri.TryCreate(url, UriKind.Absolute, out Uri result2))
		{
			return false;
		}
		if (result2.Scheme == "mailto" || result2.Scheme == "tel")
		{
			Launcher.OpenAsync(url).SafeFireAndForget((Action<Exception>)null, false);
			return true;
		}
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
		if (InfoContentType == InfoContentType.Webview)
		{
			_initialWebViewLoadCompleted = true;
		}
		State = VisualState.Default;
	}

	public void OnPageError()
	{
		ErrorTitle = "Упс! Что-то пошло не так.";
		ErrorMessage = "Небольшие технические проблемы,\nпопробуйте обновить экран.";
		State = VisualState.Error;
	}
}
