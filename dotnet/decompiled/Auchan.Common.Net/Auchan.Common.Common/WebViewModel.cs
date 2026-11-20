using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AsyncAwaitBestPractices;
using Auchan.Common.Addresses;
using Auchan.Common.AdminTool;
using Auchan.Common.Base;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Base.Errors.Service;
using Auchan.Common.Common.Binding;
using Auchan.Common.Ecom;
using Auchan.Common.Ecom.Products.ViewModels;
using Auchan.Common.Extensions;
using Auchan.Common.Logs;
using Auchan.Common.Networking;
using Auchan.Common.PersonalCabinet;
using Auchan.Common.Promotions;
using Auchan.Common.UniversalLinks;
using CSharpFunctionalExtensions;
using Microsoft.Maui.ApplicationModel;
using Newtonsoft.Json;

namespace Auchan.Common.Common;

public sealed class WebViewModel : ScreenViewModel
{
	public class Parameter
	{
		public string Title { get; init; } = "";

		public string? Content { get; init; }

		public string? Url { get; init; }
	}

	public const string ACCESS_TOKEN_STUB = "<access_token>";

	public const string ADMIN_TOKEN_STUB = "<admin_token>";

	public const string POST_LOAD_JS_CODE_TEMPLATE = "window.addEventListener('message', event => {{ JSPostMessageInterface.OnPostMessage(event.data); }});\ngetRegion = function()\n{{\n    return {0};\n}};\ngetStock = function()\n{{\n    return {1};\n}};\ngetToken = function()\n{{\n    return \"{2}\";\n}};\ngetGuid = function()\n{{\n    return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function(c) {{\n        var r = Math.random() * 16 | 0,\n            v = c === 'x' ? r : (r & 0x3 | 0x8);\n        return v.toString(16);\n    }});\n}};\nsendRequest = function (method, url, headers, body) \n{{\n    var id = getGuid();\n\n    const jsonMessage = JSON.stringify({{\n        id: id,\n        type: \"sendRequest\",\n        data: {{\n            method: method,\n            url: url,\n            headers: headers,\n            body: body\n        }}\n    }});\n\n    window.postMessage(jsonMessage, '*');\n\n    return id;\n}};";

	private Result<TokenModel, DomainError> _tokenResult;

	private readonly Parameter _parameter;

	private readonly IUniversalLinksService _universalLinksService;

	private readonly IEcomContext _ecomContext;

	private readonly ITokenService _tokenService;

	private readonly CoreHttpMessageHandler _messageHandler;

	private readonly Lazy<IAdminToolAuthorizer> _toolAuthorizer;

	private readonly RequestLoggingProcessor _requestLoggingProcessor;

	[CompilerGenerated]
	private UICommand _003CCloseCommand_003Ek__BackingField;

	[CompilerGenerated]
	private UICommand<string> _003CLoadUrlCommand_003Ek__BackingField;

	[CompilerGenerated]
	private UICommand<string> _003CLoadContentCommand_003Ek__BackingField;

	[CompilerGenerated]
	private UICommand<ProductDetailsViewModel.Parameter> _003COpenProductDetailsCommand_003Ek__BackingField;

	public ILocationProvider LocationProvider { get; }

	public UICommand CloseCommand
	{
		[CompilerGenerated]
		get
		{
			return _003CCloseCommand_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!object.Equals(_003CCloseCommand_003Ek__BackingField, value))
			{
				_003CCloseCommand_003Ek__BackingField = value;
				RaisePropertyChanged("CloseCommand");
			}
		}
	} = new UICommand();

	public UICommand<string> LoadUrlCommand
	{
		[CompilerGenerated]
		get
		{
			return _003CLoadUrlCommand_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!object.Equals(_003CLoadUrlCommand_003Ek__BackingField, value))
			{
				_003CLoadUrlCommand_003Ek__BackingField = value;
				RaisePropertyChanged("LoadUrlCommand");
			}
		}
	} = new UICommand<string>();

	public UICommand<string> LoadContentCommand
	{
		[CompilerGenerated]
		get
		{
			return _003CLoadContentCommand_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!object.Equals(_003CLoadContentCommand_003Ek__BackingField, value))
			{
				_003CLoadContentCommand_003Ek__BackingField = value;
				RaisePropertyChanged("LoadContentCommand");
			}
		}
	} = new UICommand<string>();

	public UICommand<string> PostMessageCommand { get; } = new UICommand<string>();

	public UICommand<ProductDetailsViewModel.Parameter> OpenProductDetailsCommand
	{
		[CompilerGenerated]
		get
		{
			return _003COpenProductDetailsCommand_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!object.Equals(_003COpenProductDetailsCommand_003Ek__BackingField, value))
			{
				_003COpenProductDetailsCommand_003Ek__BackingField = value;
				RaisePropertyChanged("OpenProductDetailsCommand");
			}
		}
	} = new UICommand<ProductDetailsViewModel.Parameter>();

	public string Title => _parameter.Title;

	public string? Url => _parameter.Url;

	public string? Content => HtmlConverter.WrapIntoHtml(_parameter.Content);

	private bool IsNative
	{
		get
		{
			if (!string.IsNullOrEmpty(Content))
			{
				return string.IsNullOrEmpty(Url);
			}
			return false;
		}
	}

	private bool IsWebView
	{
		get
		{
			if (!string.IsNullOrEmpty(Url))
			{
				return string.IsNullOrEmpty(Content);
			}
			return false;
		}
	}

	public string PostLoadJSCode => StringExtensions.Format("window.addEventListener('message', event => {{ JSPostMessageInterface.OnPostMessage(event.data); }});\ngetRegion = function()\n{{\n    return {0};\n}};\ngetStock = function()\n{{\n    return {1};\n}};\ngetToken = function()\n{{\n    return \"{2}\";\n}};\ngetGuid = function()\n{{\n    return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function(c) {{\n        var r = Math.random() * 16 | 0,\n            v = c === 'x' ? r : (r & 0x3 | 0x8);\n        return v.toString(16);\n    }});\n}};\nsendRequest = function (method, url, headers, body) \n{{\n    var id = getGuid();\n\n    const jsonMessage = JSON.stringify({{\n        id: id,\n        type: \"sendRequest\",\n        data: {{\n            method: method,\n            url: url,\n            headers: headers,\n            body: body\n        }}\n    }});\n\n    window.postMessage(jsonMessage, '*');\n\n    return id;\n}};", _ecomContext.ActiveStore.City.EcomId.ToString(), _ecomContext.ActiveStore.Id.ToString(), _tokenResult.IsSuccess ? ((string)_tokenResult.Value) : string.Empty);

	public WebViewModel(Parameter parameter, IUniversalLinksService universalLinksService, IEcomContext ecomContext, ITokenService tokenService, CoreHttpMessageHandler messageHandler, Lazy<IAdminToolAuthorizer> toolAuthorizer, ILogService logService, ILocationProvider locationProvider)
	{
		_parameter = parameter;
		_universalLinksService = universalLinksService;
		_ecomContext = ecomContext;
		_tokenService = tokenService;
		_messageHandler = messageHandler;
		_toolAuthorizer = toolAuthorizer;
		LocationProvider = locationProvider;
		_requestLoggingProcessor = new RequestLoggingProcessor(logService);
	}

	protected override async Task Start()
	{
		await base.Start();
		_tokenResult = await _tokenService.SavedToken80();
		if (!IsNative && !IsWebView)
		{
			CloseCommand.Trigger();
		}
	}

	public bool HandleLink(string url)
	{
		if (url == "about:blank" || url == "about:srcdoc")
		{
			return false;
		}
		if (_universalLinksService.ShouldHandlePromoLink(url))
		{
			_universalLinksService.HandleLink(url);
			return true;
		}
		if (url.ContainsIgnoreCase("auchan.digift.ru") || url.ContainsIgnoreCase("flippingbook.com") || url.ContainsIgnoreCase("leafment.com") || url.ContainsIgnoreCase("catalog.auchan.ru"))
		{
			return false;
		}
		if (url.ContainsIgnoreCase("auchan.ru/product"))
		{
			string text = url.Split('/').LastOrDefault();
			if (!string.IsNullOrEmpty(text))
			{
				OpenProductDetailsCommand.Trigger(new ProductDetailsViewModel.Parameter(text));
				return true;
			}
		}
		if (IsNative)
		{
			Browser.OpenAsync(url).SafeFireAndForget((Action<Exception>)null, false);
			return true;
		}
		if (IsWebView)
		{
			return false;
		}
		Browser.OpenAsync(url).SafeFireAndForget((Action<Exception>)null, false);
		return true;
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
		bool flag = !AddAccessToken(dto);
		if (!flag)
		{
			flag = !(await AddAdminToken(dto));
		}
		if (flag)
		{
			return;
		}
		HttpRequestMessage httpRequestMessage = new HttpRequestMessage(dto.Data.Method.ToHttpMethod(), dto.Data.Url);
		foreach (KeyValuePair<string, string> header in dto.Data.Headers)
		{
			httpRequestMessage.Headers.Add(header.Key, header.Value);
		}
		if (!httpRequestMessage.Headers.Contains("Host"))
		{
			httpRequestMessage.Headers.Add("Host", new Uri(dto.Data.Url).Host);
		}
		if (!string.IsNullOrWhiteSpace(dto.Data.Body))
		{
			httpRequestMessage.Content = new StringContent(dto.Data.Body);
		}
		HttpResponseMessage httpResponseMessage;
		try
		{
			httpResponseMessage = await _requestLoggingProcessor.SendRequestWithLogging(_messageHandler.SendAsync, httpRequestMessage);
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

	private bool AddAccessToken(PromotionMessageSendRequestDTO dto)
	{
		if (_tokenResult.TryGetError(out DomainError error))
		{
			Send401(dto, error.Message);
			return false;
		}
		ReplaceStub(dto, "<access_token>", _tokenResult.Value);
		return true;
	}

	private async Task<bool> AddAdminToken(PromotionMessageSendRequestDTO dto)
	{
		Result<string, ServiceError> result = await _toolAuthorizer.Value.UdidKey();
		if (result.TryGetError(out var error))
		{
			Send401(dto, error.Message);
			return false;
		}
		ReplaceStub(dto, "<admin_token>", result.Value);
		return true;
	}

	private void SendPostMessage(string message)
	{
		PostMessageCommand.Trigger(message);
	}

	private void Send401(PromotionMessageSendRequestDTO dto, string? message)
	{
		SendPostMessage(PromotionsMessageHelper.GetResponseMessage(dto.Id, "401", message ?? string.Empty));
	}

	private void ReplaceStub(PromotionMessageSendRequestDTO dto, string from, string to)
	{
		foreach (KeyValuePair<string, string> item in dto.Data.Headers.Where<KeyValuePair<string, string>>((KeyValuePair<string, string> h) => h.Value.Contains(from)))
		{
			dto.Data.Headers[item.Key] = dto.Data.Headers[item.Key].Replace(from, to);
		}
	}
}
