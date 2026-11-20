using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reactive;
using System.Threading;
using System.Threading.Tasks;
using Akavache.Sqlite3.Internal;
using AsyncAwaitBestPractices;
using Auchan.Common.Analytics.Loymax.DTO;
using Auchan.Common.Base.Errors;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Base.Errors.Service;
using Auchan.Common.Common;
using Auchan.Common.Ecom.Address.Models;
using Auchan.Common.Ecom.Cart.Models;
using Auchan.Common.Ecom.ProducModels;
using Auchan.Common.Extensions;
using Auchan.Common.Networking;
using Auchan.Common.PersonalCabinet;
using Auchan.Common.PersonalCabinet.DomainModels;
using CSharpFunctionalExtensions;
using Microsoft.Maui.Storage;

namespace Auchan.Common.Analytics.Loymax;

internal class LoymaxAnalyticsService : ILoymaxAnalyticsService, IApplicationStateObserver
{
	private const string LOYMAX_SESSION_ID = "7E1E5F45-F8C3-4961-A39F-D4074CC4B00E";

	private const string PREVIOUS_LOYMAX_SESSION_ID = "BF0E03D5-3DB0-4579-A875-719D0DE244F4";

	private string _sessionId = GetCurrentSessionId();

	private string? _previousSessionId = Preferences.Get("BF0E03D5-3DB0-4579-A875-719D0DE244F4", "", "UserContextPreferences");

	private readonly AsyncLock _sendUserLoginRequestLock = new AsyncLock();

	private readonly Lazy<IUserContext> _userContext;

	private readonly Lazy<ILoymaxAnalyticsApi> _api;

	private readonly Lazy<IRequestExecutor> _requestExecutor;

	public LoymaxAnalyticsService(Lazy<IUserContext> userContext, Lazy<ILoymaxAnalyticsApi> api, Lazy<IRequestExecutor> requestExecutor)
	{
		_userContext = userContext;
		_api = api;
		_requestExecutor = requestExecutor;
	}

	public void OnResumed()
	{
		Task.Run(() => CheckAndUpdateSessionId()).SafeFireAndForget((Action<Exception>)null, false);
	}

	private async Task<bool> CheckAndUpdateSessionId()
	{
		using (await _sendUserLoginRequestLock.LockAsync(default(CancellationToken)))
		{
			_sessionId = GetCurrentSessionId();
			if (_sessionId != _previousSessionId)
			{
				if (!TryCreateRequest("user_login", out WebEventRequestDto result))
				{
					return false;
				}
				if ((await SendEventAsync(result)).IsFailure)
				{
					return false;
				}
				Preferences.Set("BF0E03D5-3DB0-4579-A875-719D0DE244F4", _previousSessionId = _sessionId, "UserContextPreferences");
			}
		}
		return true;
	}

	private async Task<Result<Unit, DomainError>> SendEventAsync(WebEventRequestDto body)
	{
		return (await _requestExecutor.Value.ExecuteWithToken((CancellationToken ct, TokenModel t) => _api.Value.WebEventAsync(t, body, ct))).Map((LoymaxResponseDto d) => Unit.Default, (ServiceError err) => err.ToBaseDomainError());
	}

	private void SendEvent(string name, Action<WebEventRequestDto> customizeRequest)
	{
		SendEventAsync(name, customizeRequest).SafeFireAndForget((Action<Exception>)null, false);
	}

	private async Task SendEventAsync(string name, Action<WebEventRequestDto> customizeRequest)
	{
		using (await _sendUserLoginRequestLock.LockAsync(default(CancellationToken)))
		{
		}
		if (await CheckAndUpdateSessionId() && TryCreateRequest(name, out WebEventRequestDto result))
		{
			customizeRequest(result);
			await SendEventAsync(result);
		}
	}

	private bool TryCreateRequest(string name, [NotNullWhen(true)] out WebEventRequestDto? result)
	{
		ProfileModel profile = _userContext.Value.Profile;
		if (profile == null || profile.ClientAccountId == null)
		{
			result = null;
			return false;
		}
		result = new WebEventRequestDto
		{
			ClientId = (profile.LoymaxLoyaltyId ?? ""),
			SessionId = _sessionId,
			Date = DateTime.UtcNow,
			Name = name
		};
		return true;
	}

	public void UserLogin()
	{
		GenerateSessionId();
		CheckAndUpdateSessionId().SafeFireAndForget((Action<Exception>)null, false);
	}

	public void MerchantSelection(Store store)
	{
		SendEvent("merchant_selection", delegate(WebEventRequestDto body)
		{
			body.Context = new WebEventRequestDto.ContextDto
			{
				MerchantId = store.Id.ToString("D3")
			};
		});
	}

	public void AddToCart(ProductOffer offer)
	{
		SendEvent("add_to_container", delegate(WebEventRequestDto body)
		{
			WithOffer(offer, body);
		});
	}

	public void RemoveFromCart(ProductOffer offer)
	{
		SendEvent("remove_from_container", delegate(WebEventRequestDto body)
		{
			WithOffer(offer, body);
		});
	}

	private void WithOffer(ProductOffer offer, WebEventRequestDto body)
	{
		body.Container = "webcart";
		body.CategoryId = offer.CategoryCodes.FirstOrDefault()?.Id.ToString();
		body.ProductId = FormatProductId(offer.GimaId);
		body.Quantity = offer.Qty;
		body.Price = offer.Price;
	}

	public void ViewProduct(Product product)
	{
		SendEvent("view_product", delegate(WebEventRequestDto body)
		{
			body.ProductId = FormatProductId(product.GimaId);
			body.CategoryId = product.CategoryCodes?.FirstOrDefault()?.Id.ToString();
		});
	}

	public void ViewUnavailableProduct(Product product)
	{
		SendEvent("view_unavailable_product", delegate(WebEventRequestDto body)
		{
			body.ProductId = FormatProductId(product.GimaId);
			body.Quantity = default(decimal);
		});
	}

	public void ViewCategory(long categoryId)
	{
		SendEvent("view_category", delegate(WebEventRequestDto body)
		{
			body.CategoryId = categoryId.ToString();
		});
	}

	public void AddToFavorites(Product product)
	{
		SendEvent("add_to_favorites", delegate(WebEventRequestDto body)
		{
			body.ProductId = FormatProductId(product.GimaId);
		});
	}

	public void AddToWaitList(Product product)
	{
		SendEvent("subscribe_to_product", delegate(WebEventRequestDto body)
		{
			body.ProductId = FormatProductId(product.GimaId);
		});
	}

	private string FormatProductId(string? productId)
	{
		string text = "";
		if (productId != null && productId.Length < 8)
		{
			int num = 8 - productId.Length;
			for (int i = 0; i < num; i++)
			{
				text += "0";
			}
			text += productId;
		}
		return text;
	}

	private static string GenerateSessionId()
	{
		return PreferencesEx.Set("7E1E5F45-F8C3-4961-A39F-D4074CC4B00E", Guid.NewGuid().ToString(), TimeSpan.FromDays(1), "UserContextPreferences");
	}

	private static string GetCurrentSessionId()
	{
		return PreferencesEx.Get<string>("7E1E5F45-F8C3-4961-A39F-D4074CC4B00E", "UserContextPreferences") ?? GenerateSessionId();
	}
}
