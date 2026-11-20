using System;
using System.Collections.Specialized;
using System.Diagnostics.CodeAnalysis;
using System.Reactive;
using System.Reactive.Disposables;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using AsyncAwaitBestPractices;
using Auchan.Common.Analytics;
using Auchan.Common.Base.Errors;
using Auchan.Common.Base.Errors.Custom;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Base.Errors.Service;
using Auchan.Common.Cache;
using Auchan.Common.Common;
using Auchan.Common.Ecom.DTO;
using Auchan.Common.Extensions;
using Auchan.Common.Logs;
using Auchan.Common.LoyaltyProgram;
using Auchan.Common.LoyaltyProgram.Managers;
using Auchan.Common.LoyaltyProgram.Models;
using Auchan.Common.LoyaltyProgramLoymax;
using Auchan.Common.Networking;
using Auchan.Common.PersonalCabinet.Authorization;
using Auchan.Common.PersonalCabinet.DTO;
using Auchan.Common.PersonalCabinet.DomainModels;
using Auchan.Common.PersonalCabinet.Interactors;
using Auchan.Common.Recommendations;
using CSharpFunctionalExtensions;

namespace Auchan.Common.PersonalCabinet;

internal sealed class VkAuthService : IVkAuthService
{
	private sealed record CacheData
	{
		public required string Challenge { get; init; }

		public required string Verifier { get; init; }

		public required string State { get; init; }

		public required string SessionId { get; init; }

		[CompilerGenerated]
		[SetsRequiredMembers]
		private CacheData(CacheData original)
		{
			Challenge = original.Challenge;
			Verifier = original.Verifier;
			State = original.State;
			SessionId = original.SessionId;
		}

		public CacheData()
		{
		}
	}

	private const string CACHE_KEY = "079FCBBF-684C-4060-8C40-C1CECC1D8F91";

	private readonly WeakReference<IVkAuthViewModel> _weakVisualStateModel = new WeakReference<IVkAuthViewModel>(null);

	private readonly Lazy<ICache> _cache;

	private readonly Lazy<ILogService> _logService;

	private readonly Lazy<IVkAuthApi> _api;

	private readonly Lazy<IVkAuthLauncher> _launcher;

	private readonly Lazy<IRequestExecutor> _requestExecutor;

	private readonly Lazy<IInfoMessageService> _infoMessageService;

	private readonly Lazy<ITokenService> _tokenService;

	private readonly Lazy<ILoyaltyCardManager> _loyaltyCardManager;

	private readonly Lazy<IUserContext> _userContext;

	private readonly Lazy<ILoyaltyManager> _loyaltyManager;

	private readonly Lazy<IDataBroker> _dataBroker;

	private readonly Lazy<ProfileInteractor> _profileInteractor;

	private readonly Lazy<ITrackingService> _trackingService;

	private Uri? _authUri;

	public VkAuthService(Lazy<ICache> cache, Lazy<ILogService> logService, Lazy<IVkAuthApi> api, Lazy<IVkAuthLauncher> launcher, Lazy<IRequestExecutor> requestExecutor, Lazy<IInfoMessageService> infoMessageService, Lazy<ITokenService> tokenService, Lazy<ILoyaltyCardManager> loyaltyCardManager, Lazy<IUserContext> userContext, Lazy<ILoyaltyManager> loyaltyManager, Lazy<IDataBroker> dataBroker, Lazy<ProfileInteractor> profileInteractor, Lazy<ITrackingService> trackingService)
	{
		_cache = cache;
		_logService = logService;
		_api = api;
		_launcher = launcher;
		_requestExecutor = requestExecutor;
		_infoMessageService = infoMessageService;
		_tokenService = tokenService;
		_loyaltyCardManager = loyaltyCardManager;
		_userContext = userContext;
		_loyaltyManager = loyaltyManager;
		_dataBroker = dataBroker;
		_profileInteractor = profileInteractor;
		_trackingService = trackingService;
	}

	public void Init(IVkAuthViewModel visualStateModel)
	{
		_weakVisualStateModel.SetTarget(visualStateModel);
	}

	public async Task<Result<Unit, DomainError>> StartAsync(CancellationToken cancellationToken = default(CancellationToken))
	{
		_weakVisualStateModel.Invoke(delegate(IVkAuthViewModel m)
		{
			m.State = VisualState.InProgress;
		});
		using (Disposable.Create(delegate
		{
			_weakVisualStateModel.Invoke(delegate(IVkAuthViewModel m)
			{
				m.State = VisualState.Default;
			});
		}))
		{
			Result<VkInitResponseDto, ServiceError> r = await _requestExecutor.Value.Execute(_api.Value.InitAsync, cancellationToken);
			if (r.TryGetError(out ServiceError error))
			{
				ShowErrorSnackbar();
				return error.ToBaseDomainError();
			}
			var (challenge, verifier) = Pkce.Generate();
			await _cache.Value.Save("079FCBBF-684C-4060-8C40-C1CECC1D8F91", new CacheData
			{
				Challenge = challenge,
				Verifier = verifier,
				State = r.Value.State,
				SessionId = r.Value.SessionId
			});
			NameValueCollection nameValueCollection = HttpUtility.ParseQueryString("");
			UriBuilder uriBuilder = new UriBuilder("vk54269263://vk.com/blank.html")
			{
				Query = nameValueCollection.ToString()
			};
			NameValueCollection nameValueCollection2 = HttpUtility.ParseQueryString("");
			nameValueCollection2["state"] = r.Value.State;
			nameValueCollection2["response_type"] = "code";
			nameValueCollection2["code_challenge"] = challenge;
			nameValueCollection2["code_challenge_method"] = "S256";
			nameValueCollection2["client_id"] = "54269263";
			nameValueCollection2["scope"] = "phone email";
			nameValueCollection2["prompt"] = "login";
			nameValueCollection2["redirect_uri"] = uriBuilder.Uri.AbsoluteUri;
			Uri uri = new UriBuilder("https://id.vk.ru/authorize")
			{
				Query = nameValueCollection2.ToString()
			}.Uri;
			await _launcher.Value.LaunchAsync(uri);
			return Unit.Default;
		}
	}

	public void SetIntermediateState(Uri? uri)
	{
		_authUri = ((uri?.Host == "vk.com" && uri?.Scheme == "vk54269263") ? uri : null);
	}

	public async Task ContinueLoginAsync(CancellationToken cancellationToken = default(CancellationToken))
	{
		if (_authUri == null)
		{
			return;
		}
		CacheData cd = await _cache.Value.TryGet<CacheData>("079FCBBF-684C-4060-8C40-C1CECC1D8F91");
		_logService.Value.LogInfo("VkAuthService", $"got [{_authUri}] with data [{cd}]", LogType.Debug, SystemType.MobileApp);
		if (!(cd != null) || !(_authUri != null))
		{
			return;
		}
		NameValueCollection nameValueCollection = HttpUtility.ParseQueryString(_authUri.Query);
		string code = nameValueCollection["code"];
		string state = nameValueCollection["state"];
		string deviceId = nameValueCollection["device_id"];
		if (!(state == cd.State) || string.IsNullOrEmpty(code) || string.IsNullOrEmpty(deviceId))
		{
			return;
		}
		_weakVisualStateModel.Invoke(delegate(IVkAuthViewModel m)
		{
			m.State = VisualState.InProgress;
		});
		if ((await _requestExecutor.Value.Execute((CancellationToken ct) => _api.Value.Token(new VkTokenRequestDto
		{
			Code = code,
			DeviceId = deviceId,
			CodeVerifier = cd.Verifier,
			State = state,
			SessionId = cd.SessionId
		}, ct), cancellationToken)).TryGetValue(out var value))
		{
			await _cache.Value.Remove("079FCBBF-684C-4060-8C40-C1CECC1D8F91");
			await _tokenService.Value.SaveToken(new TokenModel(value.Token, TokenLevel.L80));
			_userContext.Value.Profile = value.Data.Profile.ToProfileModel();
			if (value.Status != VkTokenResponseDto.StatusDto.Unchanged)
			{
				VkSignUpViewModel.Result result = await _weakVisualStateModel.Invoke(async delegate(IVkAuthViewModel? m)
				{
					if (m == null)
					{
						return (VkSignUpViewModel.Result)null;
					}
					VkSignUpViewModel.Parameter parameter = new VkSignUpViewModel.Parameter();
					m.OpenVkSignUpCommand.Trigger(_dataBroker.Value.Push(parameter));
					return await parameter.TaskCompletionSource.Task;
				});
				if (result == null)
				{
					_weakVisualStateModel.Invoke(delegate(IVkAuthViewModel m)
					{
						m.State = VisualState.Default;
					});
					return;
				}
				if (result.WantReceivePromoCheck)
				{
					await _profileInteractor.Value.UpdateWithSubscriptionsOn(_userContext.Value.Profile);
				}
				if (value.Status == VkTokenResponseDto.StatusDto.Unregistered && (await EnrollVirtualCard(_userContext.Value.Profile)).TryGetError(out var error))
				{
					string errorMessage = null;
					if (error is CardEnrollError cardEnrollError)
					{
						errorMessage = cardEnrollError.Message;
					}
					ShowErrorSnackbar(errorMessage);
					_weakVisualStateModel.Invoke(delegate(IVkAuthViewModel m)
					{
						m.State = VisualState.Default;
					});
					return;
				}
				if (value.Status == VkTokenResponseDto.StatusDto.Updated)
				{
					UpdateProfile(_userContext.Value.Profile).SafeFireAndForget((Action<Exception>)null, false);
				}
			}
			_loyaltyManager.Value.UpdateSocialStatus(updateProfile: false).SafeFireAndForget((Action<Exception>)null, false);
			await _userContext.Value.LogIn();
			AppAnalytics.Loymax.UserLogin();
			SetCustomerOnRetailRocket().SafeFireAndForget((Action<Exception>)null, false);
			_infoMessageService.Value.ShowHomePage();
		}
		else
		{
			_weakVisualStateModel.Invoke(delegate(IVkAuthViewModel m)
			{
				m.State = VisualState.Default;
			});
			ShowErrorSnackbar();
		}
	}

	private async Task SetCustomerOnRetailRocket()
	{
		ProfileModel profile = _userContext.Value.Profile;
		if (profile != null)
		{
			Result<LoyaltyCardEntity, DomainError> result = await _loyaltyCardManager.Value.GetLoyaltyCard(CancellationToken.None);
			if (result.IsSuccess)
			{
				await _trackingService.Value.SetCustomer(profile, result.Value);
			}
		}
	}

	private async Task<Result<LoyaltyEnrollmentModel, DomainError>> EnrollVirtualCard(ProfileModel profile)
	{
		Result<LoyaltyEnrollmentModel, DomainError> result = await _loyaltyCardManager.Value.EnrollVirtualCard(profile, LoyaltyEnrollmentRequestDto.ChannelDto.VK);
		if (result.TryGetError(out var error) && error is CardEnrollError cardEnrollError && !string.IsNullOrEmpty(profile.Email))
		{
			CardEnrollError.Type errorType = cardEnrollError.ErrorType;
			if ((uint)(errorType - 7) <= 1u)
			{
				profile.Email = null;
				return await EnrollVirtualCard(profile);
			}
		}
		return result;
	}

	private async Task UpdateProfile(ProfileModel profile)
	{
		if ((await _profileInteractor.Value.UpdateProfile(profile)).TryGetError(out var error) && error is ProfileError profileError && (profileError.ErrorType == ProfileError.Type.BadEmailAddress || profileError.ErrorType == ProfileError.Type.EmailAlreadyExists) && !string.IsNullOrEmpty(profile.Email))
		{
			profile.Email = "";
			await UpdateProfile(profile);
		}
	}

	private void ShowErrorSnackbar(string? errorMessage = null)
	{
		_infoMessageService.Value.ShowSnackbar(errorMessage ?? "Произошла ошибка. Пожалуйста, повторите попытку позже");
	}
}
