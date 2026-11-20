using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AsyncAwaitBestPractices;
using Auchan.Common.Addresses;
using Auchan.Common.AdminTool;
using Auchan.Common.Base;
using Auchan.Common.Base.Errors;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Base.Errors.Service;
using Auchan.Common.Common;
using Auchan.Common.Common.Binding;
using Auchan.Common.DependencyInjection;
using Auchan.Common.Ecom;
using Auchan.Common.Ecom.Products.ViewModels;
using Auchan.Common.Extensions;
using Auchan.Common.Logs;
using Auchan.Common.Networking;
using Auchan.Common.PersonalCabinet;
using Auchan.Common.UniversalLinks;
using CSharpFunctionalExtensions;
using DryIoc;
using Microsoft.Maui.ApplicationModel;
using Newtonsoft.Json;

namespace Auchan.Common.Promotions;

public class PromotionViewModel : ScreenViewModel
{
	public class Parameter
	{
		public int PromotionId { get; }

		public Parameter(int promotionId)
		{
			PromotionId = promotionId;
		}
	}

	public const string AccessTokenStub = "<access_token>";

	public const string AdminTokenStub = "<admin_token>";

	public const string PostLoadJSCodeTemplate = "window.addEventListener('message', event => {{ JSPostMessageInterface.OnPostMessage(event.data); }});\ngetRegion = function()\n{{\n    return {0};\n}};\ngetStock = function()\n{{\n    return {1};\n}};\ngetToken = function()\n{{\n    return \"{2}\";\n}};\ngetGuid = function()\n{{\n    return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function(c) {{\n        var r = Math.random() * 16 | 0,\n            v = c === 'x' ? r : (r & 0x3 | 0x8);\n        return v.toString(16);\n    }});\n}};\nsendRequest = function (method, url, headers, body) \n{{\n    var id = getGuid();\n\n    const jsonMessage = JSON.stringify({{\n        id: id,\n        type: \"sendRequest\",\n        data: {{\n            method: method,\n            url: url,\n            headers: headers,\n            body: body\n        }}\n    }});\n\n    window.postMessage(jsonMessage, '*');\n\n    return id;\n}};";

	private readonly IAdminContext _adminContext;

	private readonly IEcomContext _ecomContext;

	private readonly ILocationProvider _locationProvider;

	private readonly ITokenService _tokenService;

	private readonly DefaultErrorTranslator _errorTranslator;

	private readonly Parameter _parameter;

	private readonly IUniversalLinksService _universalLinksService;

	private readonly CoreHttpMessageHandler _messageHandler;

	private readonly IAdminToolAuthorizer _toolAuthorizer;

	private readonly IPolicyProvider _policyProvider;

	private readonly RequestLoggingProcessor _requestLoggingProcessor;

	private readonly IDeviceService _deviceService;

	private string? _webViewToken80;

	private IDictionary<string, string> _webViewHeaders = new Dictionary<string, string>();

	private bool _initialWebViewLoadCompleted;

	[CompilerGenerated]
	private VisualState _003CState_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CErrorTitle_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CErrorMessage_003Ek__BackingField;

	[CompilerGenerated]
	private Promotion? _003CPromotion_003Ek__BackingField;

	[CompilerGenerated]
	private PromotionKind? _003CPromotionKind_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CTitle_003Ek__BackingField;

	[CompilerGenerated]
	private string? _003CUrl_003Ek__BackingField;

	[CompilerGenerated]
	private string? _003CDescription_003Ek__BackingField;

	[CompilerGenerated]
	private string _003COnStartRedirectUrl_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CPostLoadJSCode_003Ek__BackingField;

	public ILocationProvider LocationProvider => _locationProvider;

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
	} = string.Empty;

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
	} = string.Empty;

	private Promotion? Promotion
	{
		[CompilerGenerated]
		get
		{
			return _003CPromotion_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!object.Equals(_003CPromotion_003Ek__BackingField, value))
			{
				_003CPromotion_003Ek__BackingField = value;
				RaisePropertyChanged("IsDigitalCatalog");
				RaisePropertyChanged("Promotion");
			}
		}
	}

	public PromotionKind? PromotionKind
	{
		[CompilerGenerated]
		get
		{
			return _003CPromotionKind_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!Nullable.Equals(_003CPromotionKind_003Ek__BackingField, value))
			{
				_003CPromotionKind_003Ek__BackingField = value;
				RaisePropertyChanged("PromotionKind");
			}
		}
	}

	public string Title
	{
		[CompilerGenerated]
		get
		{
			return _003CTitle_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CTitle_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CTitle_003Ek__BackingField = value;
				RaisePropertyChanged("Title");
			}
		}
	} = "Акция";

	public string? Url
	{
		[CompilerGenerated]
		get
		{
			return _003CUrl_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CUrl_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CUrl_003Ek__BackingField = value;
				RaisePropertyChanged("Url");
			}
		}
	}

	public string? Description
	{
		[CompilerGenerated]
		get
		{
			return _003CDescription_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CDescription_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CDescription_003Ek__BackingField = value;
				RaisePropertyChanged("DescriptionHtml");
				RaisePropertyChanged("Description");
			}
		}
	}

	public string? DescriptionHtml
	{
		get
		{
			if (Description == null)
			{
				return null;
			}
			return HtmlConverter.WrapIntoHtml(Description);
		}
	}

	public bool IsDigitalCatalog => Promotion?.Positions?.Contains(Position.DigitalCatalog) == true;

	public string OnStartRedirectUrl
	{
		[CompilerGenerated]
		get
		{
			return _003COnStartRedirectUrl_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003COnStartRedirectUrl_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003COnStartRedirectUrl_003Ek__BackingField = value;
				RaisePropertyChanged("OnStartRedirectUrl");
			}
		}
	} = string.Empty;

	public string PostLoadJSCode
	{
		[CompilerGenerated]
		get
		{
			return _003CPostLoadJSCode_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CPostLoadJSCode_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CPostLoadJSCode_003Ek__BackingField = value;
				RaisePropertyChanged("PostLoadJSCode");
			}
		}
	} = string.Empty;

	public UICommand<string> OpenSystemBrowserCommand { get; } = new UICommand<string>();

	public UICommand<string> OpenLinkCommand { get; } = new UICommand<string>();

	public UICommand<ProductDetailsViewModel.Parameter> OpenProductDetailsCommand { get; } = new UICommand<ProductDetailsViewModel.Parameter>();

	public UICommand<string> PostMessageCommand { get; } = new UICommand<string>();

	public PromotionViewModel(IAdminContext adminContext, DefaultErrorTranslator defaultErrorTranslator, Parameter parameter, IUniversalLinksService universalLinksService, IEcomContext ecomContext, ITokenService tokenService, ILocationProvider locationProvider, CoreHttpMessageHandler messageHandler, IAdminToolAuthorizer toolAuthorizer, IPolicyProvider policyProvider, ILogService logService, IDeviceService deviceService)
	{
		_adminContext = adminContext;
		_errorTranslator = defaultErrorTranslator;
		_parameter = parameter;
		_universalLinksService = universalLinksService;
		_ecomContext = ecomContext;
		_locationProvider = locationProvider;
		_tokenService = tokenService;
		_messageHandler = messageHandler;
		_toolAuthorizer = toolAuthorizer;
		_policyProvider = policyProvider;
		_requestLoggingProcessor = new RequestLoggingProcessor(logService);
		_deviceService = deviceService;
	}

	protected override async Task Start()
	{
		Result<TokenModel, DomainError> result = await _tokenService.SavedToken80();
		if (result.IsSuccess)
		{
			_webViewToken80 = result.Value.Token;
		}
		PostLoadJSCode = StringExtensions.Format("window.addEventListener('message', event => {{ JSPostMessageInterface.OnPostMessage(event.data); }});\ngetRegion = function()\n{{\n    return {0};\n}};\ngetStock = function()\n{{\n    return {1};\n}};\ngetToken = function()\n{{\n    return \"{2}\";\n}};\ngetGuid = function()\n{{\n    return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function(c) {{\n        var r = Math.random() * 16 | 0,\n            v = c === 'x' ? r : (r & 0x3 | 0x8);\n        return v.toString(16);\n    }});\n}};\nsendRequest = function (method, url, headers, body) \n{{\n    var id = getGuid();\n\n    const jsonMessage = JSON.stringify({{\n        id: id,\n        type: \"sendRequest\",\n        data: {{\n            method: method,\n            url: url,\n            headers: headers,\n            body: body\n        }}\n    }});\n\n    window.postMessage(jsonMessage, '*');\n\n    return id;\n}};", _ecomContext.ActiveStore.City.EcomId.ToString(), _ecomContext.ActiveStore.Id.ToString(), _webViewToken80 ?? string.Empty);
		await base.Start();
		await LoadPromotion();
	}

	public override void Dispose()
	{
		_webViewToken80 = null;
		_webViewHeaders.Clear();
		base.Dispose();
	}

	public void OnPageLoad()
	{
		if (PromotionKind == Auchan.Common.AdminTool.PromotionKind.Webview)
		{
			_initialWebViewLoadCompleted = true;
		}
		State = VisualState.Default;
	}

	public bool HandleLink(string url, bool opensNewWindow = false)
	{
		if (Uri.TryCreate(url, UriKind.Absolute, out Uri _) && _universalLinksService.ShouldOpenInBrowser(url))
		{
			_universalLinksService.HandleLink(url);
			return true;
		}
		if (PromotionKind == Auchan.Common.AdminTool.PromotionKind.Webview)
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
			if (Uri.TryCreate(url, UriKind.Absolute, out Uri result2) && (result2.Scheme == Uri.UriSchemeHttp || result2.Scheme == Uri.UriSchemeHttps) && !result2.IsAuchanHost())
			{
				OpenSystemBrowserCommand.Trigger(url);
				return true;
			}
		}
		if (url == "about:blank" || url == "about:srcdoc")
		{
			return false;
		}
		if (_universalLinksService.ShouldHandlePromoLink(url))
		{
			_universalLinksService.HandleLink(url);
			return true;
		}
		if (url.EndsWith(".pdf"))
		{
			OpenSystemBrowserCommand.Trigger(url);
			return true;
		}
		if (url.ContainsIgnoreCase("auchan.digift.ru") || url.ContainsIgnoreCase("flippingbook.com") || url.ContainsIgnoreCase("leafment.com") || url.ContainsIgnoreCase("catalog.auchan.ru"))
		{
			OpenLinkCommand.Trigger(url);
			return false;
		}
		if (url.ContainsIgnoreCase("auchan.ru/product"))
		{
			string text = url.Replace("https", "").Replace("http", "").Replace("://www.auchan.ru/product/", "");
			text = text.Substring(0, text.IndexOf("/"));
			if (!string.IsNullOrEmpty(text))
			{
				OpenProductDetailsCommand.Trigger(new ProductDetailsViewModel.Parameter(text));
				return true;
			}
		}
		if (PromotionKind == Auchan.Common.AdminTool.PromotionKind.Native)
		{
			OpenSystemBrowserCommand.Trigger(url);
			return true;
		}
		if (PromotionKind == Auchan.Common.AdminTool.PromotionKind.Webview)
		{
			return false;
		}
		OpenSystemBrowserCommand.Trigger(url);
		return true;
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

	private async Task LoadPromotion()
	{
		Result<Promotion, DomainError> result = await _adminContext.Promotion(_parameter.PromotionId);
		if (result.IsFailure)
		{
			State = VisualState.Error;
			(ErrorTitle, ErrorMessage) = _errorTranslator.Translate(result.Error);
			return;
		}
		Promotion = result.Value;
		if ((result.Value.Url?.EndsWith(".pdf") ?? false) && Promotion.PromotionKind != Auchan.Common.AdminTool.PromotionKind.Native)
		{
			OnStartRedirectUrl = result.Value.Url;
			return;
		}
		if (Promotion == null)
		{
			State = VisualState.Error;
			return;
		}
		Title = Promotion.Name;
		Description = Promotion.Description;
		Url = Promotion.Url;
		PromotionKind = Promotion.PromotionKind;
		_initialWebViewLoadCompleted = false;
		if (Promotion.PromotionKind != Auchan.Common.AdminTool.PromotionKind.Webview)
		{
			State = VisualState.Default;
		}
	}

	public void OnMessageReceived(string message)
	{
		PromotionMessageSendRequestDTO sendRequestDTO = PromotionsMessageHelper.GetSendRequestDTO(message);
		if (sendRequestDTO != null && sendRequestDTO.Type == PromotionMessageType.SendRequest)
		{
			SendWebViewRequest(sendRequestDTO).SafeFireAndForget((Action<Exception>)null, true);
		}
	}

	public async Task SendWebViewRequest(PromotionMessageSendRequestDTO dto)
	{
		if (await AddAccessToken(dto) && await AddAdminToken(dto))
		{
			HttpRequestMessage message = new HttpRequestMessage(dto.Data.Method.ToHttpMethod(), dto.Data.Url);
			dto.Data.Headers.ForEach<KeyValuePair<string, string>>(delegate(KeyValuePair<string, string> h)
			{
				message.Headers.Add(h.Key, h.Value);
			});
			if (!message.Headers.Contains("Host"))
			{
				message.Headers.Add("Host", new Uri(dto.Data.Url).Host);
			}
			if (!string.IsNullOrWhiteSpace(dto.Data.Body))
			{
				message.Content = new StringContent(dto.Data.Body);
			}
			HttpResponseMessage httpResponseMessage;
			try
			{
				httpResponseMessage = await _requestLoggingProcessor.SendRequestWithLogging(_messageHandler.SendAsync, message);
			}
			catch (Exception ex)
			{
				SendPostMessage(PromotionsMessageHelper.GetResponseMessage(dto.Id, "503", ex.Message));
				return;
			}
			if (httpResponseMessage == null || !httpResponseMessage.IsSuccessStatusCode)
			{
				SendPostMessage(PromotionsMessageHelper.GetResponseMessage(dto.Id, ((int)(httpResponseMessage?.StatusCode ?? HttpStatusCode.InternalServerError)).ToString(), httpResponseMessage?.ReasonPhrase ?? string.Empty));
				return;
			}
			string id = dto.Id;
			string statusCode = ((int)httpResponseMessage.StatusCode).ToString();
			string value = ((httpResponseMessage == null) ? string.Empty : (await httpResponseMessage.Content.ReadAsStringAsync()));
			SendPostMessage(PromotionsMessageHelper.GetResponseMessage(id, statusCode, JsonConvert.SerializeObject(value)));
		}
	}

	private async Task<bool> AddAccessToken(PromotionMessageSendRequestDTO dto)
	{
		Result<TokenModel, DomainError> token = await _tokenService.SavedToken80();
		if (token.IsFailure)
		{
			SendPostMessage(PromotionsMessageHelper.GetResponseMessage(dto.Id, "401", token.Error.Message ?? string.Empty));
			return false;
		}
		dto.Data.Headers.ForEach<KeyValuePair<string, string>>(delegate(KeyValuePair<string, string> h)
		{
			if (h.Value.Contains("<access_token>"))
			{
				dto.Data.Headers[h.Key] = dto.Data.Headers[h.Key].Replace("<access_token>", token.Value);
			}
		});
		return true;
	}

	private async Task<bool> AddAdminToken(PromotionMessageSendRequestDTO dto)
	{
		Result<string, ServiceError> token = await _toolAuthorizer.UdidKey();
		if (token.IsFailure)
		{
			SendPostMessage(PromotionsMessageHelper.GetResponseMessage(dto.Id, "401", token.Error.Message ?? string.Empty));
			return false;
		}
		dto.Data.Headers.ForEach<KeyValuePair<string, string>>(delegate(KeyValuePair<string, string> h)
		{
			if (h.Value.Contains("<admin_token>"))
			{
				dto.Data.Headers[h.Key] = dto.Data.Headers[h.Key].Replace("<admin_token>", token.Value);
			}
		});
		return true;
	}

	public void SendPostMessage(string message)
	{
		PostMessageCommand.Trigger(message);
	}

	public static void OpenBrowserOrSelf(Promotion promotion, UICommand<Parameter> openPromotionViewModelCommand)
	{
		string? url = promotion.Url;
		if (url != null && url.EndsWith(".pdf") && promotion.PromotionKind != Auchan.Common.AdminTool.PromotionKind.Native)
		{
			IUniversalLinksService universalLinksService = DI.ResolverBecauseConstructorInjectionIsNotPossible.Resolve<IUniversalLinksService>();
			if (universalLinksService.ShouldHandlePromoLink(promotion.Url))
			{
				universalLinksService.HandleLink(promotion.Url).SafeFireAndForget((Action<Exception>)null, false);
			}
			else
			{
				Browser.OpenAsync(promotion.Url).SafeFireAndForget((Action<Exception>)null, false);
			}
		}
		else
		{
			openPromotionViewModelCommand.Trigger(new Parameter(promotion.Id));
		}
	}
}
