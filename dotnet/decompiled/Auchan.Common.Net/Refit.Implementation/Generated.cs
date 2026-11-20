using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.AdminTool;
using Auchan.Common.AdminTool.DTO;
using Auchan.Common.Analytics.Digenetica;
using Auchan.Common.Analytics.Loymax;
using Auchan.Common.Analytics.Loymax.DTO;
using Auchan.Common.Analytics.YandexAppMetrica;
using Auchan.Common.Cashback.Wallet;
using Auchan.Common.Cashback.Wallet.DTO;
using Auchan.Common.DynamicFeedback;
using Auchan.Common.DynamicFeedback.Dto;
using Auchan.Common.DynamicFeedback.Responses;
using Auchan.Common.Ecom;
using Auchan.Common.Ecom.Address;
using Auchan.Common.Ecom.Address.DTO;
using Auchan.Common.Ecom.Banners;
using Auchan.Common.Ecom.Banners.DTO;
using Auchan.Common.Ecom.Cart;
using Auchan.Common.Ecom.CtmShelves;
using Auchan.Common.Ecom.CtmShelves.DTO;
using Auchan.Common.Ecom.DTO;
using Auchan.Common.Ecom.Onboardings.DTO;
using Auchan.Common.Ecom.Onboardings.Infrastructure;
using Auchan.Common.Ecom.PriceChecker;
using Auchan.Common.Ecom.PriceChecker.Dto;
using Auchan.Common.Ecom.Products;
using Auchan.Common.Ecom.Search.DTO;
using Auchan.Common.Ecom.Search.Infrastructure;
using Auchan.Common.Feedback;
using Auchan.Common.Feedback.DTO;
using Auchan.Common.InfoPages;
using Auchan.Common.InfoPages.DTO;
using Auchan.Common.LoyaltyProgram.Coupons.DTO;
using Auchan.Common.LoyaltyProgram.Coupons.Infrastructure;
using Auchan.Common.LoyaltyProgram.Dtos;
using Auchan.Common.LoyaltyProgram.Dtos.Balance;
using Auchan.Common.LoyaltyProgram.Services;
using Auchan.Common.LoyaltyProgram.Services.Infrastructure;
using Auchan.Common.LoyaltyProgramLoymax;
using Auchan.Common.LoyaltyProgramLoymax.Dtos;
using Auchan.Common.Notifications;
using Auchan.Common.Notifications.DTO;
using Auchan.Common.PersonalCabinet;
using Auchan.Common.PersonalCabinet.DTO;
using Auchan.Common.PersonalOffers;
using Auchan.Common.PersonalOffers.DTO;
using Auchan.Common.Profile;
using Auchan.Common.Profile.Cases.Api;
using Auchan.Common.Profile.GiftCards.Infrastructure;
using Auchan.Common.Profile.Orders.Dto;
using Auchan.Common.Profile.Orders.Services;
using Auchan.Common.Profile.Stores.Dto;
using Auchan.Common.Profile.Stores.Services;
using Auchan.Common.Profile.UserCards;
using Auchan.Common.Profile.UserCards.DTO;
using Auchan.Common.Profile.WaitList.Api;
using Auchan.Common.Recommendations.API;
using Auchan.Common.Recommendations.API.DTO;
using Auchan.Common.Recommendations.API.Requests;
using Auchan.Common.Reviews;
using Auchan.Common.Reviews.Api.Ecom.Dto;
using Auchan.Common.StoreReview;
using Auchan.Common.Streams;
using Auchan.Common.SupportChat;
using Auchan.Common.SupportChat.DTO;
using Auchan.Common.Tooltips;
using Auchan.CommonRefitInternalGenerated;

namespace Refit.Implementation;

[ExcludeFromCodeCoverage]
[DebuggerNonUserCode]
[Preserve]
[Obfuscation(Exclude = true)]
[EditorBrowsable(EditorBrowsableState.Never)]
internal static class Generated
{
	[ExcludeFromCodeCoverage]
	[DebuggerNonUserCode]
	[Preserve]
	[Obfuscation(Exclude = true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	private class AuchanCommonAdminToolIAdminToolApi : IAdminToolApi
	{
		private readonly IRequestBuilder requestBuilder;

		private static readonly Type[] ______typeParameters = new Type[5]
		{
			typeof(UdidPayload),
			typeof(string),
			typeof(string),
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters0 = new Type[3]
		{
			typeof(string),
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters1 = new Type[5]
		{
			typeof(UdidPayload),
			typeof(string),
			typeof(string),
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters2 = new Type[3]
		{
			typeof(string),
			typeof(string),
			typeof(CancellationToken)
		};

		public HttpClient Client { get; }

		public AuchanCommonAdminToolIAdminToolApi(HttpClient client, IRequestBuilder requestBuilder)
		{
			Client = client;
			this.requestBuilder = requestBuilder;
		}

		public async Task<InitializationDto> Initialize(UdidPayload udid, string storeId, string regionFiasId, string userAgent, CancellationToken cancellationToken)
		{
			object[] arg = new object[5] { udid, storeId, regionFiasId, userAgent, cancellationToken };
			return await ((Task<InitializationDto>)requestBuilder.BuildRestResultFuncForMethod("Initialize", ______typeParameters)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<AppConfigDto> AppConfig(string token, string userAgent, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { token, userAgent, cancellationToken };
			return await ((Task<AppConfigDto>)requestBuilder.BuildRestResultFuncForMethod("AppConfig", ______typeParameters0)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<InitializationDto> IAdminToolApi.Initialize(UdidPayload udid, string storeId, string regionFiasId, string userAgent, CancellationToken cancellationToken)
		{
			object[] arg = new object[5] { udid, storeId, regionFiasId, userAgent, cancellationToken };
			return await ((Task<InitializationDto>)requestBuilder.BuildRestResultFuncForMethod("Initialize", ______typeParameters1)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<AppConfigDto> IAdminToolApi.AppConfig(string token, string userAgent, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { token, userAgent, cancellationToken };
			return await ((Task<AppConfigDto>)requestBuilder.BuildRestResultFuncForMethod("AppConfig", ______typeParameters2)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	[ExcludeFromCodeCoverage]
	[DebuggerNonUserCode]
	[Preserve]
	[Obfuscation(Exclude = true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	private class AuchanCommonAdminToolIAuthApi : IAuthApi
	{
		private readonly IRequestBuilder requestBuilder;

		private static readonly Type[] ______typeParameters = new Type[2]
		{
			typeof(UdidPayload),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters0 = new Type[2]
		{
			typeof(UdidPayload),
			typeof(CancellationToken)
		};

		public HttpClient Client { get; }

		public AuchanCommonAdminToolIAuthApi(HttpClient client, IRequestBuilder requestBuilder)
		{
			Client = client;
			this.requestBuilder = requestBuilder;
		}

		public async Task<UdidDto> Udid(UdidPayload udid, CancellationToken cancellationToken)
		{
			object[] arg = new object[2] { udid, cancellationToken };
			return await ((Task<UdidDto>)requestBuilder.BuildRestResultFuncForMethod("Udid", ______typeParameters)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<UdidDto> IAuthApi.Udid(UdidPayload udid, CancellationToken cancellationToken)
		{
			object[] arg = new object[2] { udid, cancellationToken };
			return await ((Task<UdidDto>)requestBuilder.BuildRestResultFuncForMethod("Udid", ______typeParameters0)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	[ExcludeFromCodeCoverage]
	[DebuggerNonUserCode]
	[Preserve]
	[Obfuscation(Exclude = true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	private class AuchanCommonAdminToolIPromotionsApi : IPromotionsApi
	{
		private readonly IRequestBuilder requestBuilder;

		private static readonly Type[] ______typeParameters = new Type[6]
		{
			typeof(string),
			typeof(string),
			typeof(string),
			typeof(IEnumerable<string>),
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters0 = new Type[3]
		{
			typeof(string),
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters1 = new Type[6]
		{
			typeof(string),
			typeof(string),
			typeof(string),
			typeof(IEnumerable<string>),
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters2 = new Type[3]
		{
			typeof(string),
			typeof(string),
			typeof(CancellationToken)
		};

		public HttpClient Client { get; }

		public AuchanCommonAdminToolIPromotionsApi(HttpClient client, IRequestBuilder requestBuilder)
		{
			Client = client;
			this.requestBuilder = requestBuilder;
		}

		public async Task<List<PromotionDto>> Promotions(string token, string fiasId, string storeId, IEnumerable<string>? segmentCodes, string userAgent, CancellationToken cancellationToken)
		{
			object[] arg = new object[6] { token, fiasId, storeId, segmentCodes, userAgent, cancellationToken };
			return await ((Task<List<PromotionDto>>)requestBuilder.BuildRestResultFuncForMethod("Promotions", ______typeParameters)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<List<ExtraPromotionDto>> ExtraPromotions(string token, string fiasId, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { token, fiasId, cancellationToken };
			return await ((Task<List<ExtraPromotionDto>>)requestBuilder.BuildRestResultFuncForMethod("ExtraPromotions", ______typeParameters0)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<List<PromotionDto>> IPromotionsApi.Promotions(string token, string fiasId, string storeId, IEnumerable<string>? segmentCodes, string userAgent, CancellationToken cancellationToken)
		{
			object[] arg = new object[6] { token, fiasId, storeId, segmentCodes, userAgent, cancellationToken };
			return await ((Task<List<PromotionDto>>)requestBuilder.BuildRestResultFuncForMethod("Promotions", ______typeParameters1)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<List<ExtraPromotionDto>> IPromotionsApi.ExtraPromotions(string token, string fiasId, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { token, fiasId, cancellationToken };
			return await ((Task<List<ExtraPromotionDto>>)requestBuilder.BuildRestResultFuncForMethod("ExtraPromotions", ______typeParameters2)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	[ExcludeFromCodeCoverage]
	[DebuggerNonUserCode]
	[Preserve]
	[Obfuscation(Exclude = true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	private class AuchanCommonAdminToolIStampsApi : IStampsApi
	{
		private readonly IRequestBuilder requestBuilder;

		private static readonly Type[] ______typeParameters = new Type[1] { typeof(CancellationToken) };

		private static readonly Type[] ______typeParameters0 = new Type[1] { typeof(CancellationToken) };

		private static readonly Type[] ______typeParameters1 = new Type[1] { typeof(CancellationToken) };

		private static readonly Type[] ______typeParameters2 = new Type[1] { typeof(CancellationToken) };

		public HttpClient Client { get; }

		public AuchanCommonAdminToolIStampsApi(HttpClient client, IRequestBuilder requestBuilder)
		{
			Client = client;
			this.requestBuilder = requestBuilder;
		}

		public async Task<SectionVisibleDto> SectionVisible(CancellationToken cancellationToken)
		{
			object[] arg = new object[1] { cancellationToken };
			return await ((Task<SectionVisibleDto>)requestBuilder.BuildRestResultFuncForMethod("SectionVisible", ______typeParameters)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<InformersDto> GetInformers(CancellationToken cancellationToken)
		{
			object[] arg = new object[1] { cancellationToken };
			return await ((Task<InformersDto>)requestBuilder.BuildRestResultFuncForMethod("GetInformers", ______typeParameters0)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<SectionVisibleDto> IStampsApi.SectionVisible(CancellationToken cancellationToken)
		{
			object[] arg = new object[1] { cancellationToken };
			return await ((Task<SectionVisibleDto>)requestBuilder.BuildRestResultFuncForMethod("SectionVisible", ______typeParameters1)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<InformersDto> IStampsApi.GetInformers(CancellationToken cancellationToken)
		{
			object[] arg = new object[1] { cancellationToken };
			return await ((Task<InformersDto>)requestBuilder.BuildRestResultFuncForMethod("GetInformers", ______typeParameters2)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	[ExcludeFromCodeCoverage]
	[DebuggerNonUserCode]
	[Preserve]
	[Obfuscation(Exclude = true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	private class AuchanCommonAnalyticsDigeneticaIDigeneticaApi : IDigeneticaApi
	{
		private readonly IRequestBuilder requestBuilder;

		private static readonly Type[] ______typeParameters = new Type[2]
		{
			typeof(string),
			typeof(string)
		};

		private static readonly Type[] ______typeParameters0 = new Type[2]
		{
			typeof(string),
			typeof(string)
		};

		public HttpClient Client { get; }

		public AuchanCommonAnalyticsDigeneticaIDigeneticaApi(HttpClient client, IRequestBuilder requestBuilder)
		{
			Client = client;
			this.requestBuilder = requestBuilder;
		}

		public async Task<object> TrackEvent(string eventJson, string contentType)
		{
			object[] arg = new object[2] { eventJson, contentType };
			return await ((Task<object>)requestBuilder.BuildRestResultFuncForMethod("TrackEvent", ______typeParameters)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<object> IDigeneticaApi.TrackEvent(string eventJson, string contentType)
		{
			object[] arg = new object[2] { eventJson, contentType };
			return await ((Task<object>)requestBuilder.BuildRestResultFuncForMethod("TrackEvent", ______typeParameters0)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	[ExcludeFromCodeCoverage]
	[DebuggerNonUserCode]
	[Preserve]
	[Obfuscation(Exclude = true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	private class AuchanCommonAnalyticsLoymaxILoymaxAnalyticsApi : ILoymaxAnalyticsApi
	{
		private readonly IRequestBuilder requestBuilder;

		private static readonly Type[] ______typeParameters = new Type[3]
		{
			typeof(string),
			typeof(WebEventRequestDto),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters0 = new Type[3]
		{
			typeof(string),
			typeof(WebEventRequestDto),
			typeof(CancellationToken)
		};

		public HttpClient Client { get; }

		public AuchanCommonAnalyticsLoymaxILoymaxAnalyticsApi(HttpClient client, IRequestBuilder requestBuilder)
		{
			Client = client;
			this.requestBuilder = requestBuilder;
		}

		public async Task<LoymaxResponseDto> WebEventAsync(string token80, WebEventRequestDto webEventRequestDto, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { token80, webEventRequestDto, cancellationToken };
			return await ((Task<LoymaxResponseDto>)requestBuilder.BuildRestResultFuncForMethod("WebEventAsync", ______typeParameters)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<LoymaxResponseDto> ILoymaxAnalyticsApi.WebEventAsync(string token80, WebEventRequestDto webEventRequestDto, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { token80, webEventRequestDto, cancellationToken };
			return await ((Task<LoymaxResponseDto>)requestBuilder.BuildRestResultFuncForMethod("WebEventAsync", ______typeParameters0)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	[ExcludeFromCodeCoverage]
	[DebuggerNonUserCode]
	[Preserve]
	[Obfuscation(Exclude = true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	private class AuchanCommonAnalyticsLoymaxILoymaxApi : ILoymaxApi
	{
		private readonly IRequestBuilder requestBuilder;

		private static readonly Type[] ______typeParameters = new Type[3]
		{
			typeof(string),
			typeof(LoymaxPushesRequestDto),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters0 = new Type[3]
		{
			typeof(string),
			typeof(LoymaxEventsRequestDto),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters1 = new Type[3]
		{
			typeof(string),
			typeof(LoymaxPushesRequestDto),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters2 = new Type[3]
		{
			typeof(string),
			typeof(LoymaxEventsRequestDto),
			typeof(CancellationToken)
		};

		public HttpClient Client { get; }

		public AuchanCommonAnalyticsLoymaxILoymaxApi(HttpClient client, IRequestBuilder requestBuilder)
		{
			Client = client;
			this.requestBuilder = requestBuilder;
		}

		public async Task<LoymaxResponseDto> CommunicationPushes(string token80, LoymaxPushesRequestDto body, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { token80, body, cancellationToken };
			return await ((Task<LoymaxResponseDto>)requestBuilder.BuildRestResultFuncForMethod("CommunicationPushes", ______typeParameters)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<LoymaxResponseDto> CommunicationEvents(string token80, LoymaxEventsRequestDto body, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { token80, body, cancellationToken };
			return await ((Task<LoymaxResponseDto>)requestBuilder.BuildRestResultFuncForMethod("CommunicationEvents", ______typeParameters0)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<LoymaxResponseDto> ILoymaxApi.CommunicationPushes(string token80, LoymaxPushesRequestDto body, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { token80, body, cancellationToken };
			return await ((Task<LoymaxResponseDto>)requestBuilder.BuildRestResultFuncForMethod("CommunicationPushes", ______typeParameters1)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<LoymaxResponseDto> ILoymaxApi.CommunicationEvents(string token80, LoymaxEventsRequestDto body, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { token80, body, cancellationToken };
			return await ((Task<LoymaxResponseDto>)requestBuilder.BuildRestResultFuncForMethod("CommunicationEvents", ______typeParameters2)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	[ExcludeFromCodeCoverage]
	[DebuggerNonUserCode]
	[Preserve]
	[Obfuscation(Exclude = true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	private class AuchanCommonAnalyticsYandexAppMetricaIMetricaApi : IMetricaApi
	{
		private readonly IRequestBuilder requestBuilder;

		private static readonly Type[] ______typeParameters = new Type[4]
		{
			typeof(string),
			typeof(string),
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters0 = new Type[4]
		{
			typeof(string),
			typeof(string),
			typeof(string),
			typeof(CancellationToken)
		};

		public HttpClient Client { get; }

		public AuchanCommonAnalyticsYandexAppMetricaIMetricaApi(HttpClient client, IRequestBuilder requestBuilder)
		{
			Client = client;
			this.requestBuilder = requestBuilder;
		}

		public async Task<string> TrackEvent(string postApiKey, string postApiKey2, string csvContent, CancellationToken cancellationToken)
		{
			object[] arg = new object[4] { postApiKey, postApiKey2, csvContent, cancellationToken };
			return await ((Task<string>)requestBuilder.BuildRestResultFuncForMethod("TrackEvent", ______typeParameters)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<string> IMetricaApi.TrackEvent(string postApiKey, string postApiKey2, string csvContent, CancellationToken cancellationToken)
		{
			object[] arg = new object[4] { postApiKey, postApiKey2, csvContent, cancellationToken };
			return await ((Task<string>)requestBuilder.BuildRestResultFuncForMethod("TrackEvent", ______typeParameters0)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	[ExcludeFromCodeCoverage]
	[DebuggerNonUserCode]
	[Preserve]
	[Obfuscation(Exclude = true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	private class AuchanCommonCashbackWalletIWalletApi : IWalletApi
	{
		private readonly IRequestBuilder requestBuilder;

		private static readonly Type[] ______typeParameters = new Type[2]
		{
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters0 = new Type[2]
		{
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters1 = new Type[3]
		{
			typeof(string),
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters2 = new Type[3]
		{
			typeof(string),
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters3 = new Type[2]
		{
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters4 = new Type[2]
		{
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters5 = new Type[2]
		{
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters6 = new Type[3]
		{
			typeof(string),
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters7 = new Type[3]
		{
			typeof(string),
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters8 = new Type[2]
		{
			typeof(string),
			typeof(CancellationToken)
		};

		public HttpClient Client { get; }

		public AuchanCommonCashbackWalletIWalletApi(HttpClient client, IRequestBuilder requestBuilder)
		{
			Client = client;
			this.requestBuilder = requestBuilder;
		}

		public async Task<PassAndroidDTO> CashbackQrPassAndroid(string token, CancellationToken cancellationToken)
		{
			object[] arg = new object[2] { token, cancellationToken };
			return await ((Task<PassAndroidDTO>)requestBuilder.BuildRestResultFuncForMethod("CashbackQrPassAndroid", ______typeParameters)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<HttpResponseMessage> CashbackQrPassiOS(string token, CancellationToken cancellationToken)
		{
			object[] arg = new object[2] { token, cancellationToken };
			return await ((Task<HttpResponseMessage>)requestBuilder.BuildRestResultFuncForMethod("CashbackQrPassiOS", ______typeParameters0)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<PassCheckAndroidDTO> LoyaltyQrPassCheckAndroid(string token, string deviceId, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { token, deviceId, cancellationToken };
			return await ((Task<PassCheckAndroidDTO>)requestBuilder.BuildRestResultFuncForMethod("LoyaltyQrPassCheckAndroid", ______typeParameters1)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<PassAndroidDTO> LoyaltyQrPassAndroid(string token, string deviceId, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { token, deviceId, cancellationToken };
			return await ((Task<PassAndroidDTO>)requestBuilder.BuildRestResultFuncForMethod("LoyaltyQrPassAndroid", ______typeParameters2)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<HttpResponseMessage> LoyaltyQrPassiOS(string token, CancellationToken cancellationToken)
		{
			object[] arg = new object[2] { token, cancellationToken };
			return await ((Task<HttpResponseMessage>)requestBuilder.BuildRestResultFuncForMethod("LoyaltyQrPassiOS", ______typeParameters3)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<PassAndroidDTO> IWalletApi.CashbackQrPassAndroid(string token, CancellationToken cancellationToken)
		{
			object[] arg = new object[2] { token, cancellationToken };
			return await ((Task<PassAndroidDTO>)requestBuilder.BuildRestResultFuncForMethod("CashbackQrPassAndroid", ______typeParameters4)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<HttpResponseMessage> IWalletApi.CashbackQrPassiOS(string token, CancellationToken cancellationToken)
		{
			object[] arg = new object[2] { token, cancellationToken };
			return await ((Task<HttpResponseMessage>)requestBuilder.BuildRestResultFuncForMethod("CashbackQrPassiOS", ______typeParameters5)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<PassCheckAndroidDTO> IWalletApi.LoyaltyQrPassCheckAndroid(string token, string deviceId, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { token, deviceId, cancellationToken };
			return await ((Task<PassCheckAndroidDTO>)requestBuilder.BuildRestResultFuncForMethod("LoyaltyQrPassCheckAndroid", ______typeParameters6)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<PassAndroidDTO> IWalletApi.LoyaltyQrPassAndroid(string token, string deviceId, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { token, deviceId, cancellationToken };
			return await ((Task<PassAndroidDTO>)requestBuilder.BuildRestResultFuncForMethod("LoyaltyQrPassAndroid", ______typeParameters7)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<HttpResponseMessage> IWalletApi.LoyaltyQrPassiOS(string token, CancellationToken cancellationToken)
		{
			object[] arg = new object[2] { token, cancellationToken };
			return await ((Task<HttpResponseMessage>)requestBuilder.BuildRestResultFuncForMethod("LoyaltyQrPassiOS", ______typeParameters8)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	[ExcludeFromCodeCoverage]
	[DebuggerNonUserCode]
	[Preserve]
	[Obfuscation(Exclude = true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	private class AuchanCommonDynamicFeedbackIDynamicFeedbackApi : IDynamicFeedbackApi
	{
		private readonly IRequestBuilder requestBuilder;

		private static readonly Type[] ______typeParameters = new Type[1] { typeof(CancellationToken) };

		private static readonly Type[] ______typeParameters0 = new Type[2]
		{
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters1 = new Type[1] { typeof(CancellationToken) };

		private static readonly Type[] ______typeParameters2 = new Type[2]
		{
			typeof(object),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters3 = new Type[2]
		{
			typeof(IEnumerable<StreamPart>),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters4 = new Type[1] { typeof(CancellationToken) };

		private static readonly Type[] ______typeParameters5 = new Type[1] { typeof(CancellationToken) };

		private static readonly Type[] ______typeParameters6 = new Type[1] { typeof(CancellationToken) };

		private static readonly Type[] ______typeParameters7 = new Type[2]
		{
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters8 = new Type[1] { typeof(CancellationToken) };

		private static readonly Type[] ______typeParameters9 = new Type[2]
		{
			typeof(object),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters10 = new Type[2]
		{
			typeof(IEnumerable<StreamPart>),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters11 = new Type[1] { typeof(CancellationToken) };

		private static readonly Type[] ______typeParameters12 = new Type[1] { typeof(CancellationToken) };

		public HttpClient Client { get; }

		public AuchanCommonDynamicFeedbackIDynamicFeedbackApi(HttpClient client, IRequestBuilder requestBuilder)
		{
			Client = client;
			this.requestBuilder = requestBuilder;
		}

		public async Task<FeedbackCategoriesResponse> GetCategories(CancellationToken cancellationToken)
		{
			object[] arg = new object[1] { cancellationToken };
			return await ((Task<FeedbackCategoriesResponse>)requestBuilder.BuildRestResultFuncForMethod("GetCategories", ______typeParameters)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<FeedbackFieldsResponse> GetFields(string serviceCrmId, CancellationToken cancellationToken)
		{
			object[] arg = new object[2] { serviceCrmId, cancellationToken };
			return await ((Task<FeedbackFieldsResponse>)requestBuilder.BuildRestResultFuncForMethod("GetFields", ______typeParameters0)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<IsFeedbackActiveDto> IsFeedbackActive(CancellationToken cancellationToken)
		{
			object[] arg = new object[1] { cancellationToken };
			return await ((Task<IsFeedbackActiveDto>)requestBuilder.BuildRestResultFuncForMethod("IsFeedbackActive", ______typeParameters1)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<FeedbackRespondResponse> Respond(object body, CancellationToken cancellationToken)
		{
			object[] arg = new object[2] { body, cancellationToken };
			return await ((Task<FeedbackRespondResponse>)requestBuilder.BuildRestResultFuncForMethod("Respond", ______typeParameters2)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<List<FeedbackUploadFilesResponse>> UploadFiles(IEnumerable<StreamPart> streams, CancellationToken cancellationToken)
		{
			object[] arg = new object[2] { streams, cancellationToken };
			return await ((Task<List<FeedbackUploadFilesResponse>>)requestBuilder.BuildRestResultFuncForMethod("UploadFiles", ______typeParameters3)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<FeedbackCitiesResponse> GetCities(CancellationToken cancellationToken)
		{
			object[] arg = new object[1] { cancellationToken };
			return await ((Task<FeedbackCitiesResponse>)requestBuilder.BuildRestResultFuncForMethod("GetCities", ______typeParameters4)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<FeedbackChannelsResponse> GetChannels(CancellationToken cancellationToken)
		{
			object[] arg = new object[1] { cancellationToken };
			return await ((Task<FeedbackChannelsResponse>)requestBuilder.BuildRestResultFuncForMethod("GetChannels", ______typeParameters5)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<FeedbackCategoriesResponse> IDynamicFeedbackApi.GetCategories(CancellationToken cancellationToken)
		{
			object[] arg = new object[1] { cancellationToken };
			return await ((Task<FeedbackCategoriesResponse>)requestBuilder.BuildRestResultFuncForMethod("GetCategories", ______typeParameters6)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<FeedbackFieldsResponse> IDynamicFeedbackApi.GetFields(string serviceCrmId, CancellationToken cancellationToken)
		{
			object[] arg = new object[2] { serviceCrmId, cancellationToken };
			return await ((Task<FeedbackFieldsResponse>)requestBuilder.BuildRestResultFuncForMethod("GetFields", ______typeParameters7)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<IsFeedbackActiveDto> IDynamicFeedbackApi.IsFeedbackActive(CancellationToken cancellationToken)
		{
			object[] arg = new object[1] { cancellationToken };
			return await ((Task<IsFeedbackActiveDto>)requestBuilder.BuildRestResultFuncForMethod("IsFeedbackActive", ______typeParameters8)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<FeedbackRespondResponse> IDynamicFeedbackApi.Respond(object body, CancellationToken cancellationToken)
		{
			object[] arg = new object[2] { body, cancellationToken };
			return await ((Task<FeedbackRespondResponse>)requestBuilder.BuildRestResultFuncForMethod("Respond", ______typeParameters9)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<List<FeedbackUploadFilesResponse>> IDynamicFeedbackApi.UploadFiles(IEnumerable<StreamPart> streams, CancellationToken cancellationToken)
		{
			object[] arg = new object[2] { streams, cancellationToken };
			return await ((Task<List<FeedbackUploadFilesResponse>>)requestBuilder.BuildRestResultFuncForMethod("UploadFiles", ______typeParameters10)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<FeedbackCitiesResponse> IDynamicFeedbackApi.GetCities(CancellationToken cancellationToken)
		{
			object[] arg = new object[1] { cancellationToken };
			return await ((Task<FeedbackCitiesResponse>)requestBuilder.BuildRestResultFuncForMethod("GetCities", ______typeParameters11)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<FeedbackChannelsResponse> IDynamicFeedbackApi.GetChannels(CancellationToken cancellationToken)
		{
			object[] arg = new object[1] { cancellationToken };
			return await ((Task<FeedbackChannelsResponse>)requestBuilder.BuildRestResultFuncForMethod("GetChannels", ______typeParameters12)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	[ExcludeFromCodeCoverage]
	[DebuggerNonUserCode]
	[Preserve]
	[Obfuscation(Exclude = true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	private class AuchanCommonEcomAddressIAddressApi : IAddressApi
	{
		private readonly IRequestBuilder requestBuilder;

		private static readonly Type[] ______typeParameters = new Type[3]
		{
			typeof(string),
			typeof(SaveAddressRequest),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters0 = new Type[3]
		{
			typeof(string),
			typeof(UpdateAddressRequest),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters1 = new Type[3]
		{
			typeof(string),
			typeof(long),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters2 = new Type[2]
		{
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters3 = new Type[3]
		{
			typeof(string),
			typeof(int),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters4 = new Type[3]
		{
			typeof(string),
			typeof(int),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters5 = new Type[3]
		{
			typeof(string),
			typeof(SuggestGeocodeRequestDto),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters6 = new Type[3]
		{
			typeof(string),
			typeof(SaveAddressRequest),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters7 = new Type[3]
		{
			typeof(string),
			typeof(UpdateAddressRequest),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters8 = new Type[3]
		{
			typeof(string),
			typeof(long),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters9 = new Type[2]
		{
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters10 = new Type[3]
		{
			typeof(string),
			typeof(int),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters11 = new Type[3]
		{
			typeof(string),
			typeof(int),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters12 = new Type[3]
		{
			typeof(string),
			typeof(SuggestGeocodeRequestDto),
			typeof(CancellationToken)
		};

		public HttpClient Client { get; }

		public AuchanCommonEcomAddressIAddressApi(HttpClient client, IRequestBuilder requestBuilder)
		{
			Client = client;
			this.requestBuilder = requestBuilder;
		}

		public async Task<SetAddressResponse> SaveAddress(string token80, SaveAddressRequest request, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { token80, request, cancellationToken };
			return await ((Task<SetAddressResponse>)requestBuilder.BuildRestResultFuncForMethod("SaveAddress", ______typeParameters)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<object> UpdateAddress(string token80, UpdateAddressRequest request, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { token80, request, cancellationToken };
			return await ((Task<object>)requestBuilder.BuildRestResultFuncForMethod("UpdateAddress", ______typeParameters0)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<object> RemoveSavedAddress(string token80, long addressId, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { token80, addressId, cancellationToken };
			return await ((Task<object>)requestBuilder.BuildRestResultFuncForMethod("RemoveSavedAddress", ______typeParameters1)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<ReceiveMethodsResponseDto> SavedReceiveMethods(string token80, CancellationToken cancellationToken)
		{
			object[] arg = new object[2] { token80, cancellationToken };
			return await ((Task<ReceiveMethodsResponseDto>)requestBuilder.BuildRestResultFuncForMethod("SavedReceiveMethods", ______typeParameters2)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<object> RemoveSavedPickupShop(string token80, int shopId, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { token80, shopId, cancellationToken };
			return await ((Task<object>)requestBuilder.BuildRestResultFuncForMethod("RemoveSavedPickupShop", ______typeParameters3)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<object> RemoveSavedCarPickupShop(string token80, int shopId, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { token80, shopId, cancellationToken };
			return await ((Task<object>)requestBuilder.BuildRestResultFuncForMethod("RemoveSavedCarPickupShop", ______typeParameters4)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<SuggestGeocodeResponseDto> SuggestGeocode(string token80, SuggestGeocodeRequestDto requestBody, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { token80, requestBody, cancellationToken };
			return await ((Task<SuggestGeocodeResponseDto>)requestBuilder.BuildRestResultFuncForMethod("SuggestGeocode", ______typeParameters5)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<SetAddressResponse> IAddressApi.SaveAddress(string token80, SaveAddressRequest request, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { token80, request, cancellationToken };
			return await ((Task<SetAddressResponse>)requestBuilder.BuildRestResultFuncForMethod("SaveAddress", ______typeParameters6)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<object> IAddressApi.UpdateAddress(string token80, UpdateAddressRequest request, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { token80, request, cancellationToken };
			return await ((Task<object>)requestBuilder.BuildRestResultFuncForMethod("UpdateAddress", ______typeParameters7)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<object> IAddressApi.RemoveSavedAddress(string token80, long addressId, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { token80, addressId, cancellationToken };
			return await ((Task<object>)requestBuilder.BuildRestResultFuncForMethod("RemoveSavedAddress", ______typeParameters8)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<ReceiveMethodsResponseDto> IAddressApi.SavedReceiveMethods(string token80, CancellationToken cancellationToken)
		{
			object[] arg = new object[2] { token80, cancellationToken };
			return await ((Task<ReceiveMethodsResponseDto>)requestBuilder.BuildRestResultFuncForMethod("SavedReceiveMethods", ______typeParameters9)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<object> IAddressApi.RemoveSavedPickupShop(string token80, int shopId, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { token80, shopId, cancellationToken };
			return await ((Task<object>)requestBuilder.BuildRestResultFuncForMethod("RemoveSavedPickupShop", ______typeParameters10)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<object> IAddressApi.RemoveSavedCarPickupShop(string token80, int shopId, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { token80, shopId, cancellationToken };
			return await ((Task<object>)requestBuilder.BuildRestResultFuncForMethod("RemoveSavedCarPickupShop", ______typeParameters11)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<SuggestGeocodeResponseDto> IAddressApi.SuggestGeocode(string token80, SuggestGeocodeRequestDto requestBody, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { token80, requestBody, cancellationToken };
			return await ((Task<SuggestGeocodeResponseDto>)requestBuilder.BuildRestResultFuncForMethod("SuggestGeocode", ______typeParameters12)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	[ExcludeFromCodeCoverage]
	[DebuggerNonUserCode]
	[Preserve]
	[Obfuscation(Exclude = true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	private class AuchanCommonEcomAddressIStoreApi : IStoreApi
	{
		private readonly IRequestBuilder requestBuilder;

		private static readonly Type[] ______typeParameters = new Type[3]
		{
			typeof(string),
			typeof(int),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters0 = new Type[3]
		{
			typeof(string),
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters1 = new Type[4]
		{
			typeof(double?),
			typeof(double?),
			typeof(long?),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters2 = new Type[3]
		{
			typeof(float),
			typeof(float),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters3 = new Type[4]
		{
			typeof(long),
			typeof(float),
			typeof(float),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters4 = new Type[2]
		{
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters5 = new Type[3]
		{
			typeof(string),
			typeof(SetShopRequest),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters6 = new Type[4]
		{
			typeof(string),
			typeof(double?),
			typeof(double?),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters7 = new Type[3]
		{
			typeof(string),
			typeof(int),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters8 = new Type[3]
		{
			typeof(string),
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters9 = new Type[4]
		{
			typeof(double?),
			typeof(double?),
			typeof(long?),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters10 = new Type[3]
		{
			typeof(float),
			typeof(float),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters11 = new Type[4]
		{
			typeof(long),
			typeof(float),
			typeof(float),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters12 = new Type[2]
		{
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters13 = new Type[3]
		{
			typeof(string),
			typeof(SetShopRequest),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters14 = new Type[4]
		{
			typeof(string),
			typeof(double?),
			typeof(double?),
			typeof(CancellationToken)
		};

		public HttpClient Client { get; }

		public AuchanCommonEcomAddressIStoreApi(HttpClient client, IRequestBuilder requestBuilder)
		{
			Client = client;
			this.requestBuilder = requestBuilder;
		}

		public async Task<IApiResponse<RegionsResponse>> Regions(string userAgent, int getCoordinates, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { userAgent, getCoordinates, cancellationToken };
			return await ((Task<IApiResponse<RegionsResponse>>)requestBuilder.BuildRestResultFuncForMethod("Regions", ______typeParameters)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<IApiResponse<RegionsResponse>> AllExistingRegions(string userAgent, string showAll, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { userAgent, showAll, cancellationToken };
			return await ((Task<IApiResponse<RegionsResponse>>)requestBuilder.BuildRestResultFuncForMethod("AllExistingRegions", ______typeParameters0)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<ShopsResponse> Shops(double? lat, double? lon, long? showVisible, CancellationToken cancellationToken)
		{
			object[] arg = new object[4] { lat, lon, showVisible, cancellationToken };
			return await ((Task<ShopsResponse>)requestBuilder.BuildRestResultFuncForMethod("Shops", ______typeParameters1)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<DeliveryMethodsForAddressResponseDto> DeliveryMethodsForAddressAsync(float latitude, float longitude, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { latitude, longitude, cancellationToken };
			return await ((Task<DeliveryMethodsForAddressResponseDto>)requestBuilder.BuildRestResultFuncForMethod("DeliveryMethodsForAddressAsync", ______typeParameters2)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<DeliveryMethodsForAddressResponseDto> DeliveryMethodsForAddressAsync(long regionId, float latitude, float longitude, CancellationToken cancellationToken)
		{
			object[] arg = new object[4] { regionId, latitude, longitude, cancellationToken };
			return await ((Task<DeliveryMethodsForAddressResponseDto>)requestBuilder.BuildRestResultFuncForMethod("DeliveryMethodsForAddressAsync", ______typeParameters3)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<CurrentShopResponse> CurrentOrDefault(string token80, CancellationToken cancellationToken)
		{
			object[] arg = new object[2] { token80, cancellationToken };
			return await ((Task<CurrentShopResponse>)requestBuilder.BuildRestResultFuncForMethod("CurrentOrDefault", ______typeParameters4)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<SetShopResponse> SetCurrentShop(string token80, SetShopRequest request, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { token80, request, cancellationToken };
			return await ((Task<SetShopResponse>)requestBuilder.BuildRestResultFuncForMethod("SetCurrentShop", ______typeParameters5)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<ReceiveMethodsResponseDTO> GetReceiveMethods(string token80, double? lat, double? lon, CancellationToken cancellationToken)
		{
			object[] arg = new object[4] { token80, lat, lon, cancellationToken };
			return await ((Task<ReceiveMethodsResponseDTO>)requestBuilder.BuildRestResultFuncForMethod("GetReceiveMethods", ______typeParameters6)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<IApiResponse<RegionsResponse>> IStoreApi.Regions(string userAgent, int getCoordinates, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { userAgent, getCoordinates, cancellationToken };
			return await ((Task<IApiResponse<RegionsResponse>>)requestBuilder.BuildRestResultFuncForMethod("Regions", ______typeParameters7)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<IApiResponse<RegionsResponse>> IStoreApi.AllExistingRegions(string userAgent, string showAll, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { userAgent, showAll, cancellationToken };
			return await ((Task<IApiResponse<RegionsResponse>>)requestBuilder.BuildRestResultFuncForMethod("AllExistingRegions", ______typeParameters8)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<ShopsResponse> IStoreApi.Shops(double? lat, double? lon, long? showVisible, CancellationToken cancellationToken)
		{
			object[] arg = new object[4] { lat, lon, showVisible, cancellationToken };
			return await ((Task<ShopsResponse>)requestBuilder.BuildRestResultFuncForMethod("Shops", ______typeParameters9)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<DeliveryMethodsForAddressResponseDto> IStoreApi.DeliveryMethodsForAddressAsync(float latitude, float longitude, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { latitude, longitude, cancellationToken };
			return await ((Task<DeliveryMethodsForAddressResponseDto>)requestBuilder.BuildRestResultFuncForMethod("DeliveryMethodsForAddressAsync", ______typeParameters10)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<DeliveryMethodsForAddressResponseDto> IStoreApi.DeliveryMethodsForAddressAsync(long regionId, float latitude, float longitude, CancellationToken cancellationToken)
		{
			object[] arg = new object[4] { regionId, latitude, longitude, cancellationToken };
			return await ((Task<DeliveryMethodsForAddressResponseDto>)requestBuilder.BuildRestResultFuncForMethod("DeliveryMethodsForAddressAsync", ______typeParameters11)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<CurrentShopResponse> IStoreApi.CurrentOrDefault(string token80, CancellationToken cancellationToken)
		{
			object[] arg = new object[2] { token80, cancellationToken };
			return await ((Task<CurrentShopResponse>)requestBuilder.BuildRestResultFuncForMethod("CurrentOrDefault", ______typeParameters12)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<SetShopResponse> IStoreApi.SetCurrentShop(string token80, SetShopRequest request, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { token80, request, cancellationToken };
			return await ((Task<SetShopResponse>)requestBuilder.BuildRestResultFuncForMethod("SetCurrentShop", ______typeParameters13)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<ReceiveMethodsResponseDTO> IStoreApi.GetReceiveMethods(string token80, double? lat, double? lon, CancellationToken cancellationToken)
		{
			object[] arg = new object[4] { token80, lat, lon, cancellationToken };
			return await ((Task<ReceiveMethodsResponseDTO>)requestBuilder.BuildRestResultFuncForMethod("GetReceiveMethods", ______typeParameters14)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	[ExcludeFromCodeCoverage]
	[DebuggerNonUserCode]
	[Preserve]
	[Obfuscation(Exclude = true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	private class AuchanCommonEcomBannersIBannersApi : IBannersApi
	{
		private readonly IRequestBuilder requestBuilder;

		private static readonly Type[] ______typeParameters = new Type[4]
		{
			typeof(string),
			typeof(string),
			typeof(BannersRequestDto),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters0 = new Type[3]
		{
			typeof(string),
			typeof(BannersRequestDto),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters1 = new Type[4]
		{
			typeof(string),
			typeof(string),
			typeof(BannersRequestDto),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters2 = new Type[3]
		{
			typeof(string),
			typeof(BannersRequestDto),
			typeof(CancellationToken)
		};

		public HttpClient Client { get; }

		public AuchanCommonEcomBannersIBannersApi(HttpClient client, IRequestBuilder requestBuilder)
		{
			Client = client;
			this.requestBuilder = requestBuilder;
		}

		public async Task<IReadOnlyDictionary<string, IReadOnlyList<BannerDto>>> GetBanners(string token80, string userAgent, BannersRequestDto request, CancellationToken cancellationToken)
		{
			object[] arg = new object[4] { token80, userAgent, request, cancellationToken };
			return await ((Task<IReadOnlyDictionary<string, IReadOnlyList<BannerDto>>>)requestBuilder.BuildRestResultFuncForMethod("GetBanners", ______typeParameters)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<IReadOnlyDictionary<string, IReadOnlyList<BannerDto>>> GetBanners(string userAgent, BannersRequestDto request, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { userAgent, request, cancellationToken };
			return await ((Task<IReadOnlyDictionary<string, IReadOnlyList<BannerDto>>>)requestBuilder.BuildRestResultFuncForMethod("GetBanners", ______typeParameters0)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<IReadOnlyDictionary<string, IReadOnlyList<BannerDto>>> IBannersApi.GetBanners(string token80, string userAgent, BannersRequestDto request, CancellationToken cancellationToken)
		{
			object[] arg = new object[4] { token80, userAgent, request, cancellationToken };
			return await ((Task<IReadOnlyDictionary<string, IReadOnlyList<BannerDto>>>)requestBuilder.BuildRestResultFuncForMethod("GetBanners", ______typeParameters1)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<IReadOnlyDictionary<string, IReadOnlyList<BannerDto>>> IBannersApi.GetBanners(string userAgent, BannersRequestDto request, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { userAgent, request, cancellationToken };
			return await ((Task<IReadOnlyDictionary<string, IReadOnlyList<BannerDto>>>)requestBuilder.BuildRestResultFuncForMethod("GetBanners", ______typeParameters2)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	[ExcludeFromCodeCoverage]
	[DebuggerNonUserCode]
	[Preserve]
	[Obfuscation(Exclude = true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	private class AuchanCommonEcomCartICheckoutApi : ICheckoutApi
	{
		private readonly IRequestBuilder requestBuilder;

		private static readonly Type[] ______typeParameters = new Type[2]
		{
			typeof(CheckoutCommitDto),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters0 = new Type[2]
		{
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters1 = new Type[2]
		{
			typeof(string[]),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters2 = new Type[2]
		{
			typeof(CheckoutCommitDto),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters3 = new Type[2]
		{
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters4 = new Type[2]
		{
			typeof(string[]),
			typeof(CancellationToken)
		};

		public HttpClient Client { get; }

		public AuchanCommonEcomCartICheckoutApi(HttpClient client, IRequestBuilder requestBuilder)
		{
			Client = client;
			this.requestBuilder = requestBuilder;
		}

		public async Task<CheckoutCommitResultDto> Commit(CheckoutCommitDto data, CancellationToken cancellationToken)
		{
			object[] arg = new object[2] { data, cancellationToken };
			return await ((Task<CheckoutCommitResultDto>)requestBuilder.BuildRestResultFuncForMethod("Commit", ______typeParameters)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<Auchan.Common.Ecom.DTO.OrderDetailsDto> OrderData(string orderId, CancellationToken cancellationToken)
		{
			object[] arg = new object[2] { orderId, cancellationToken };
			return await ((Task<Auchan.Common.Ecom.DTO.OrderDetailsDto>)requestBuilder.BuildRestResultFuncForMethod("OrderData", ______typeParameters0)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<Auchan.Common.Ecom.DTO.OrderDetailsDto[]> OrderData(string[] orderId, CancellationToken cancellationToken)
		{
			object[] arg = new object[2] { orderId, cancellationToken };
			return await ((Task<Auchan.Common.Ecom.DTO.OrderDetailsDto[]>)requestBuilder.BuildRestResultFuncForMethod("OrderData", ______typeParameters1)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<CheckoutCommitResultDto> ICheckoutApi.Commit(CheckoutCommitDto data, CancellationToken cancellationToken)
		{
			object[] arg = new object[2] { data, cancellationToken };
			return await ((Task<CheckoutCommitResultDto>)requestBuilder.BuildRestResultFuncForMethod("Commit", ______typeParameters2)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<Auchan.Common.Ecom.DTO.OrderDetailsDto> ICheckoutApi.OrderData(string orderId, CancellationToken cancellationToken)
		{
			object[] arg = new object[2] { orderId, cancellationToken };
			return await ((Task<Auchan.Common.Ecom.DTO.OrderDetailsDto>)requestBuilder.BuildRestResultFuncForMethod("OrderData", ______typeParameters3)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<Auchan.Common.Ecom.DTO.OrderDetailsDto[]> ICheckoutApi.OrderData(string[] orderId, CancellationToken cancellationToken)
		{
			object[] arg = new object[2] { orderId, cancellationToken };
			return await ((Task<Auchan.Common.Ecom.DTO.OrderDetailsDto[]>)requestBuilder.BuildRestResultFuncForMethod("OrderData", ______typeParameters4)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	[ExcludeFromCodeCoverage]
	[DebuggerNonUserCode]
	[Preserve]
	[Obfuscation(Exclude = true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	private class AuchanCommonEcomCartICheckoutApiV2 : ICheckoutApiV2
	{
		private readonly IRequestBuilder requestBuilder;

		private static readonly Type[] ______typeParameters = new Type[2]
		{
			typeof(CheckoutFullDataRequestDto),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters0 = new Type[2]
		{
			typeof(RecalculateRequestDto),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters1 = new Type[2]
		{
			typeof(CheckoutFullDataRequestDto),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters2 = new Type[2]
		{
			typeof(RecalculateRequestDto),
			typeof(CancellationToken)
		};

		public HttpClient Client { get; }

		public AuchanCommonEcomCartICheckoutApiV2(HttpClient client, IRequestBuilder requestBuilder)
		{
			Client = client;
			this.requestBuilder = requestBuilder;
		}

		public async Task<IApiResponse<CheckoutDataResponseDto>> FullDataAsync(CheckoutFullDataRequestDto body, CancellationToken cancellationToken)
		{
			object[] arg = new object[2] { body, cancellationToken };
			return await ((Task<IApiResponse<CheckoutDataResponseDto>>)requestBuilder.BuildRestResultFuncForMethod("FullDataAsync", ______typeParameters)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<RecalculateResponseDto> RecalculateAsync(RecalculateRequestDto body, CancellationToken cancellationToken)
		{
			object[] arg = new object[2] { body, cancellationToken };
			return await ((Task<RecalculateResponseDto>)requestBuilder.BuildRestResultFuncForMethod("RecalculateAsync", ______typeParameters0)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<IApiResponse<CheckoutDataResponseDto>> ICheckoutApiV2.FullDataAsync(CheckoutFullDataRequestDto body, CancellationToken cancellationToken)
		{
			object[] arg = new object[2] { body, cancellationToken };
			return await ((Task<IApiResponse<CheckoutDataResponseDto>>)requestBuilder.BuildRestResultFuncForMethod("FullDataAsync", ______typeParameters1)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<RecalculateResponseDto> ICheckoutApiV2.RecalculateAsync(RecalculateRequestDto body, CancellationToken cancellationToken)
		{
			object[] arg = new object[2] { body, cancellationToken };
			return await ((Task<RecalculateResponseDto>)requestBuilder.BuildRestResultFuncForMethod("RecalculateAsync", ______typeParameters2)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	[ExcludeFromCodeCoverage]
	[DebuggerNonUserCode]
	[Preserve]
	[Obfuscation(Exclude = true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	private class AuchanCommonEcomCtmShelvesICtmShelvesApi : ICtmShelvesApi
	{
		private readonly IRequestBuilder requestBuilder;

		private static readonly Type[] ______typeParameters = new Type[2]
		{
			typeof(ShelfRequestDto),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters0 = new Type[2]
		{
			typeof(ShelfRequestDto),
			typeof(CancellationToken)
		};

		public HttpClient Client { get; }

		public AuchanCommonEcomCtmShelvesICtmShelvesApi(HttpClient client, IRequestBuilder requestBuilder)
		{
			Client = client;
			this.requestBuilder = requestBuilder;
		}

		public async Task<ShelfResponseDto> GetShelves(ShelfRequestDto body, CancellationToken cancellationToken)
		{
			object[] arg = new object[2] { body, cancellationToken };
			return await ((Task<ShelfResponseDto>)requestBuilder.BuildRestResultFuncForMethod("GetShelves", ______typeParameters)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<ShelfResponseDto> ICtmShelvesApi.GetShelves(ShelfRequestDto body, CancellationToken cancellationToken)
		{
			object[] arg = new object[2] { body, cancellationToken };
			return await ((Task<ShelfResponseDto>)requestBuilder.BuildRestResultFuncForMethod("GetShelves", ______typeParameters0)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	[ExcludeFromCodeCoverage]
	[DebuggerNonUserCode]
	[Preserve]
	[Obfuscation(Exclude = true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	private class AuchanCommonEcomICarsApi : ICarsApi
	{
		private readonly IRequestBuilder requestBuilder;

		private static readonly Type[] ______typeParameters = new Type[2]
		{
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters0 = new Type[3]
		{
			typeof(string),
			typeof(SetCarsRequest),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters1 = new Type[2]
		{
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters2 = new Type[3]
		{
			typeof(string),
			typeof(SetCarsRequest),
			typeof(CancellationToken)
		};

		public HttpClient Client { get; }

		public AuchanCommonEcomICarsApi(HttpClient client, IRequestBuilder requestBuilder)
		{
			Client = client;
			this.requestBuilder = requestBuilder;
		}

		public async Task<CarsResponse> Cars(string token80, CancellationToken cancellationToken)
		{
			object[] arg = new object[2] { token80, cancellationToken };
			return await ((Task<CarsResponse>)requestBuilder.BuildRestResultFuncForMethod("Cars", ______typeParameters)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<CarsResponse> UpdateCars(string token80, SetCarsRequest request, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { token80, request, cancellationToken };
			return await ((Task<CarsResponse>)requestBuilder.BuildRestResultFuncForMethod("UpdateCars", ______typeParameters0)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<CarsResponse> ICarsApi.Cars(string token80, CancellationToken cancellationToken)
		{
			object[] arg = new object[2] { token80, cancellationToken };
			return await ((Task<CarsResponse>)requestBuilder.BuildRestResultFuncForMethod("Cars", ______typeParameters1)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<CarsResponse> ICarsApi.UpdateCars(string token80, SetCarsRequest request, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { token80, request, cancellationToken };
			return await ((Task<CarsResponse>)requestBuilder.BuildRestResultFuncForMethod("UpdateCars", ______typeParameters2)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	[ExcludeFromCodeCoverage]
	[DebuggerNonUserCode]
	[Preserve]
	[Obfuscation(Exclude = true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	private class AuchanCommonEcomIEcomApi : IEcomApi
	{
		private readonly IRequestBuilder requestBuilder;

		private static readonly Type[] ______typeParameters = new Type[6]
		{
			typeof(int),
			typeof(string),
			typeof(string),
			typeof(string),
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters0 = new Type[5]
		{
			typeof(int),
			typeof(string),
			typeof(string),
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters1 = new Type[3]
		{
			typeof(int),
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters2 = new Type[3]
		{
			typeof(int),
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters3 = new Type[2]
		{
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters4 = new Type[2]
		{
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters5 = new Type[3]
		{
			typeof(string),
			typeof(CartItemsChangeRequest),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters6 = new Type[3]
		{
			typeof(string),
			typeof(SelectAllRequestDto),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters7 = new Type[3]
		{
			typeof(string),
			typeof(CartItemAddCommentRequest),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters8 = new Type[2]
		{
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters9 = new Type[2]
		{
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters10 = new Type[2]
		{
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters11 = new Type[3]
		{
			typeof(string),
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters12 = new Type[3]
		{
			typeof(string),
			typeof(ComboSuggestionsRequestDto),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters13 = new Type[6]
		{
			typeof(int),
			typeof(string),
			typeof(string),
			typeof(string),
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters14 = new Type[5]
		{
			typeof(int),
			typeof(string),
			typeof(string),
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters15 = new Type[3]
		{
			typeof(int),
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters16 = new Type[3]
		{
			typeof(int),
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters17 = new Type[2]
		{
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters18 = new Type[2]
		{
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters19 = new Type[3]
		{
			typeof(string),
			typeof(CartItemsChangeRequest),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters20 = new Type[3]
		{
			typeof(string),
			typeof(SelectAllRequestDto),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters21 = new Type[3]
		{
			typeof(string),
			typeof(CartItemAddCommentRequest),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters22 = new Type[2]
		{
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters23 = new Type[2]
		{
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters24 = new Type[2]
		{
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters25 = new Type[3]
		{
			typeof(string),
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters26 = new Type[3]
		{
			typeof(string),
			typeof(ComboSuggestionsRequestDto),
			typeof(CancellationToken)
		};

		public HttpClient Client { get; }

		public AuchanCommonEcomIEcomApi(HttpClient client, IRequestBuilder requestBuilder)
		{
			Client = client;
			this.requestBuilder = requestBuilder;
		}

		public async Task<IReadOnlyList<Auchan.Common.Ecom.DTO.CategoryDto>> TopCategories(int storeId, string? promoOnly, string? activeOnly, string? showHidden, string? cashbackOnly, CancellationToken cancellationToken)
		{
			object[] arg = new object[6] { storeId, promoOnly, activeOnly, showHidden, cashbackOnly, cancellationToken };
			return await ((Task<IReadOnlyList<Auchan.Common.Ecom.DTO.CategoryDto>>)requestBuilder.BuildRestResultFuncForMethod("TopCategories", ______typeParameters)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<List<Auchan.Common.Ecom.DTO.CategoryDto>> Categories(int storeId, string categoryCode, string? showHidden, string? activeOnly, CancellationToken cancellationToken)
		{
			object[] arg = new object[5] { storeId, categoryCode, showHidden, activeOnly, cancellationToken };
			return await ((Task<List<Auchan.Common.Ecom.DTO.CategoryDto>>)requestBuilder.BuildRestResultFuncForMethod("Categories", ______typeParameters0)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<CategoriesPreviewDto> CategoriesPreview(int storeId, string categoryCode, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { storeId, categoryCode, cancellationToken };
			return await ((Task<CategoriesPreviewDto>)requestBuilder.BuildRestResultFuncForMethod("CategoriesPreview", ______typeParameters1)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<BrandResponseDto> Brand(int storeId, string brand, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { storeId, brand, cancellationToken };
			return await ((Task<BrandResponseDto>)requestBuilder.BuildRestResultFuncForMethod("Brand", ______typeParameters2)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<StampDiscountDto> CartStampDiscount(string token80, CancellationToken cancellationToken)
		{
			object[] arg = new object[2] { token80, cancellationToken };
			return await ((Task<StampDiscountDto>)requestBuilder.BuildRestResultFuncForMethod("CartStampDiscount", ______typeParameters3)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<CartDto> CartNoCache(string token80, CancellationToken cancellationToken)
		{
			object[] arg = new object[2] { token80, cancellationToken };
			return await ((Task<CartDto>)requestBuilder.BuildRestResultFuncForMethod("CartNoCache", ______typeParameters4)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<CartItemsChangedDto> ChangeItems(string token80, CartItemsChangeRequest cartItemRequest, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { token80, cartItemRequest, cancellationToken };
			return await ((Task<CartItemsChangedDto>)requestBuilder.BuildRestResultFuncForMethod("ChangeItems", ______typeParameters5)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<object> SetAllSelected(string token80, SelectAllRequestDto body, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { token80, body, cancellationToken };
			return await ((Task<object>)requestBuilder.BuildRestResultFuncForMethod("SetAllSelected", ______typeParameters6)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<object> AddCommentToItem(string token80, CartItemAddCommentRequest cartItemRequest, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { token80, cartItemRequest, cancellationToken };
			return await ((Task<object>)requestBuilder.BuildRestResultFuncForMethod("AddCommentToItem", ______typeParameters7)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<CartDto> ClearCart(string token80, CancellationToken cancellationToken)
		{
			object[] arg = new object[2] { token80, cancellationToken };
			return await ((Task<CartDto>)requestBuilder.BuildRestResultFuncForMethod("ClearCart", ______typeParameters8)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<CartClearResponseDto> ClearAdultProductFromCart(string token80, CancellationToken cancellationToken)
		{
			object[] arg = new object[2] { token80, cancellationToken };
			return await ((Task<CartClearResponseDto>)requestBuilder.BuildRestResultFuncForMethod("ClearAdultProductFromCart", ______typeParameters9)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<ShareCartResponseDto> ShareCart(string token80, CancellationToken cancellationToken)
		{
			object[] arg = new object[2] { token80, cancellationToken };
			return await ((Task<ShareCartResponseDto>)requestBuilder.BuildRestResultFuncForMethod("ShareCart", ______typeParameters10)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<SharedCartResponseDto> GetSharedCart(string token80, string cartToken, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { token80, cartToken, cancellationToken };
			return await ((Task<SharedCartResponseDto>)requestBuilder.BuildRestResultFuncForMethod("GetSharedCart", ______typeParameters11)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<ComboSuggestionsResponseDto> GetComboSuggestionsAsync(string token80, ComboSuggestionsRequestDto request, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { token80, request, cancellationToken };
			return await ((Task<ComboSuggestionsResponseDto>)requestBuilder.BuildRestResultFuncForMethod("GetComboSuggestionsAsync", ______typeParameters12)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<IReadOnlyList<Auchan.Common.Ecom.DTO.CategoryDto>> IEcomApi.TopCategories(int storeId, string? promoOnly, string? activeOnly, string? showHidden, string? cashbackOnly, CancellationToken cancellationToken)
		{
			object[] arg = new object[6] { storeId, promoOnly, activeOnly, showHidden, cashbackOnly, cancellationToken };
			return await ((Task<IReadOnlyList<Auchan.Common.Ecom.DTO.CategoryDto>>)requestBuilder.BuildRestResultFuncForMethod("TopCategories", ______typeParameters13)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<List<Auchan.Common.Ecom.DTO.CategoryDto>> IEcomApi.Categories(int storeId, string categoryCode, string? showHidden, string? activeOnly, CancellationToken cancellationToken)
		{
			object[] arg = new object[5] { storeId, categoryCode, showHidden, activeOnly, cancellationToken };
			return await ((Task<List<Auchan.Common.Ecom.DTO.CategoryDto>>)requestBuilder.BuildRestResultFuncForMethod("Categories", ______typeParameters14)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<CategoriesPreviewDto> IEcomApi.CategoriesPreview(int storeId, string categoryCode, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { storeId, categoryCode, cancellationToken };
			return await ((Task<CategoriesPreviewDto>)requestBuilder.BuildRestResultFuncForMethod("CategoriesPreview", ______typeParameters15)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<BrandResponseDto> IEcomApi.Brand(int storeId, string brand, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { storeId, brand, cancellationToken };
			return await ((Task<BrandResponseDto>)requestBuilder.BuildRestResultFuncForMethod("Brand", ______typeParameters16)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<StampDiscountDto> IEcomApi.CartStampDiscount(string token80, CancellationToken cancellationToken)
		{
			object[] arg = new object[2] { token80, cancellationToken };
			return await ((Task<StampDiscountDto>)requestBuilder.BuildRestResultFuncForMethod("CartStampDiscount", ______typeParameters17)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<CartDto> IEcomApi.CartNoCache(string token80, CancellationToken cancellationToken)
		{
			object[] arg = new object[2] { token80, cancellationToken };
			return await ((Task<CartDto>)requestBuilder.BuildRestResultFuncForMethod("CartNoCache", ______typeParameters18)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<CartItemsChangedDto> IEcomApi.ChangeItems(string token80, CartItemsChangeRequest cartItemRequest, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { token80, cartItemRequest, cancellationToken };
			return await ((Task<CartItemsChangedDto>)requestBuilder.BuildRestResultFuncForMethod("ChangeItems", ______typeParameters19)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<object> IEcomApi.SetAllSelected(string token80, SelectAllRequestDto body, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { token80, body, cancellationToken };
			return await ((Task<object>)requestBuilder.BuildRestResultFuncForMethod("SetAllSelected", ______typeParameters20)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<object> IEcomApi.AddCommentToItem(string token80, CartItemAddCommentRequest cartItemRequest, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { token80, cartItemRequest, cancellationToken };
			return await ((Task<object>)requestBuilder.BuildRestResultFuncForMethod("AddCommentToItem", ______typeParameters21)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<CartDto> IEcomApi.ClearCart(string token80, CancellationToken cancellationToken)
		{
			object[] arg = new object[2] { token80, cancellationToken };
			return await ((Task<CartDto>)requestBuilder.BuildRestResultFuncForMethod("ClearCart", ______typeParameters22)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<CartClearResponseDto> IEcomApi.ClearAdultProductFromCart(string token80, CancellationToken cancellationToken)
		{
			object[] arg = new object[2] { token80, cancellationToken };
			return await ((Task<CartClearResponseDto>)requestBuilder.BuildRestResultFuncForMethod("ClearAdultProductFromCart", ______typeParameters23)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<ShareCartResponseDto> IEcomApi.ShareCart(string token80, CancellationToken cancellationToken)
		{
			object[] arg = new object[2] { token80, cancellationToken };
			return await ((Task<ShareCartResponseDto>)requestBuilder.BuildRestResultFuncForMethod("ShareCart", ______typeParameters24)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<SharedCartResponseDto> IEcomApi.GetSharedCart(string token80, string cartToken, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { token80, cartToken, cancellationToken };
			return await ((Task<SharedCartResponseDto>)requestBuilder.BuildRestResultFuncForMethod("GetSharedCart", ______typeParameters25)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<ComboSuggestionsResponseDto> IEcomApi.GetComboSuggestionsAsync(string token80, ComboSuggestionsRequestDto request, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { token80, request, cancellationToken };
			return await ((Task<ComboSuggestionsResponseDto>)requestBuilder.BuildRestResultFuncForMethod("GetComboSuggestionsAsync", ______typeParameters26)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	[ExcludeFromCodeCoverage]
	[DebuggerNonUserCode]
	[Preserve]
	[Obfuscation(Exclude = true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	private class AuchanCommonEcomOnboardingsInfrastructureIOnboardingsAPI : IOnboardingsAPI
	{
		private readonly IRequestBuilder requestBuilder;

		private static readonly Type[] ______typeParameters = new Type[5]
		{
			typeof(string),
			typeof(string),
			typeof(IEnumerable<string>),
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters0 = new Type[5]
		{
			typeof(string),
			typeof(string),
			typeof(IEnumerable<string>),
			typeof(string),
			typeof(CancellationToken)
		};

		public HttpClient Client { get; }

		public AuchanCommonEcomOnboardingsInfrastructureIOnboardingsAPI(HttpClient client, IRequestBuilder requestBuilder)
		{
			Client = client;
			this.requestBuilder = requestBuilder;
		}

		public async Task<List<OnboardingDTO>> Onboardings(string token, string merchantId, IEnumerable<string>? segmentCodes, string userAgent, CancellationToken ct)
		{
			object[] arg = new object[5] { token, merchantId, segmentCodes, userAgent, ct };
			return await ((Task<List<OnboardingDTO>>)requestBuilder.BuildRestResultFuncForMethod("Onboardings", ______typeParameters)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<List<OnboardingDTO>> IOnboardingsAPI.Onboardings(string token, string merchantId, IEnumerable<string>? segmentCodes, string userAgent, CancellationToken ct)
		{
			object[] arg = new object[5] { token, merchantId, segmentCodes, userAgent, ct };
			return await ((Task<List<OnboardingDTO>>)requestBuilder.BuildRestResultFuncForMethod("Onboardings", ______typeParameters0)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	[ExcludeFromCodeCoverage]
	[DebuggerNonUserCode]
	[Preserve]
	[Obfuscation(Exclude = true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	private class AuchanCommonEcomOnboardingsInfrastructureIOnbardingsApi : IOnbardingsApi
	{
		private readonly IRequestBuilder requestBuilder;

		private static readonly Type[] ______typeParameters = new Type[3]
		{
			typeof(string),
			typeof(OnboardingsRequestDto),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters0 = new Type[3]
		{
			typeof(string),
			typeof(OnboardingsRequestDto),
			typeof(CancellationToken)
		};

		public HttpClient Client { get; }

		public AuchanCommonEcomOnboardingsInfrastructureIOnbardingsApi(HttpClient client, IRequestBuilder requestBuilder)
		{
			Client = client;
			this.requestBuilder = requestBuilder;
		}

		public async Task<OnboardingsResponseDto> GetOnboardingsAsync(string? token, OnboardingsRequestDto body, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { token, body, cancellationToken };
			return await ((Task<OnboardingsResponseDto>)requestBuilder.BuildRestResultFuncForMethod("GetOnboardingsAsync", ______typeParameters)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<OnboardingsResponseDto> IOnbardingsApi.GetOnboardingsAsync(string? token, OnboardingsRequestDto body, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { token, body, cancellationToken };
			return await ((Task<OnboardingsResponseDto>)requestBuilder.BuildRestResultFuncForMethod("GetOnboardingsAsync", ______typeParameters0)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	[ExcludeFromCodeCoverage]
	[DebuggerNonUserCode]
	[Preserve]
	[Obfuscation(Exclude = true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	private class AuchanCommonEcomPriceCheckerIPriceCheckerApi : IPriceCheckerApi
	{
		private readonly IRequestBuilder requestBuilder;

		private static readonly Type[] ______typeParameters = new Type[2]
		{
			typeof(PriceCheckerRequestDto),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters0 = new Type[2]
		{
			typeof(PriceCheckerRequestDto),
			typeof(CancellationToken)
		};

		public HttpClient Client { get; }

		public AuchanCommonEcomPriceCheckerIPriceCheckerApi(HttpClient client, IRequestBuilder requestBuilder)
		{
			Client = client;
			this.requestBuilder = requestBuilder;
		}

		public async Task<PriceCheckerResponseDto> ProductByEan(PriceCheckerRequestDto requestDto, CancellationToken token)
		{
			object[] arg = new object[2] { requestDto, token };
			return await ((Task<PriceCheckerResponseDto>)requestBuilder.BuildRestResultFuncForMethod("ProductByEan", ______typeParameters)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<PriceCheckerResponseDto> IPriceCheckerApi.ProductByEan(PriceCheckerRequestDto requestDto, CancellationToken token)
		{
			object[] arg = new object[2] { requestDto, token };
			return await ((Task<PriceCheckerResponseDto>)requestBuilder.BuildRestResultFuncForMethod("ProductByEan", ______typeParameters0)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	[ExcludeFromCodeCoverage]
	[DebuggerNonUserCode]
	[Preserve]
	[Obfuscation(Exclude = true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	private class AuchanCommonEcomPriceCheckerIPriceCheckerEventsApi : IPriceCheckerEventsApi
	{
		private readonly IRequestBuilder requestBuilder;

		private static readonly Type[] ______typeParameters = new Type[3]
		{
			typeof(string),
			typeof(PriceCheckerMiddleWareEventDto),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters0 = new Type[3]
		{
			typeof(string),
			typeof(PriceCheckerMiddleWareEventDtoAfterOpenPricechecker),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters1 = new Type[3]
		{
			typeof(string),
			typeof(PriceCheckerMiddleWareEventDto),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters2 = new Type[3]
		{
			typeof(string),
			typeof(PriceCheckerMiddleWareEventDtoAfterOpenPricechecker),
			typeof(CancellationToken)
		};

		public HttpClient Client { get; }

		public AuchanCommonEcomPriceCheckerIPriceCheckerEventsApi(HttpClient client, IRequestBuilder requestBuilder)
		{
			Client = client;
			this.requestBuilder = requestBuilder;
		}

		public async Task<object> Events(string token, PriceCheckerMiddleWareEventDto requestDto, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { token, requestDto, cancellationToken };
			return await ((Task<object>)requestBuilder.BuildRestResultFuncForMethod("Events", ______typeParameters)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<object> Events(string token, PriceCheckerMiddleWareEventDtoAfterOpenPricechecker requestDto, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { token, requestDto, cancellationToken };
			return await ((Task<object>)requestBuilder.BuildRestResultFuncForMethod("Events", ______typeParameters0)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<object> IPriceCheckerEventsApi.Events(string token, PriceCheckerMiddleWareEventDto requestDto, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { token, requestDto, cancellationToken };
			return await ((Task<object>)requestBuilder.BuildRestResultFuncForMethod("Events", ______typeParameters1)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<object> IPriceCheckerEventsApi.Events(string token, PriceCheckerMiddleWareEventDtoAfterOpenPricechecker requestDto, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { token, requestDto, cancellationToken };
			return await ((Task<object>)requestBuilder.BuildRestResultFuncForMethod("Events", ______typeParameters2)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	[ExcludeFromCodeCoverage]
	[DebuggerNonUserCode]
	[Preserve]
	[Obfuscation(Exclude = true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	private class AuchanCommonEcomProductsIProductsApi : IProductsApi
	{
		private readonly IRequestBuilder requestBuilder;

		private static readonly Type[] ______typeParameters = new Type[9]
		{
			typeof(string),
			typeof(int),
			typeof(int),
			typeof(string),
			typeof(string),
			typeof(bool?),
			typeof(List<string>),
			typeof(int),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters0 = new Type[9]
		{
			typeof(string),
			typeof(int),
			typeof(int),
			typeof(bool),
			typeof(string),
			typeof(string),
			typeof(ProductRequestDto),
			typeof(int),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters1 = new Type[9]
		{
			typeof(string),
			typeof(int),
			typeof(int),
			typeof(string),
			typeof(string),
			typeof(List<string>),
			typeof(bool?),
			typeof(int),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters2 = new Type[6]
		{
			typeof(string),
			typeof(int),
			typeof(string),
			typeof(string),
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters3 = new Type[7]
		{
			typeof(string),
			typeof(string),
			typeof(int),
			typeof(string),
			typeof(string),
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters4 = new Type[3]
		{
			typeof(string),
			typeof(IEnumerable<string>),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters5 = new Type[9]
		{
			typeof(int),
			typeof(int?),
			typeof(string),
			typeof(string),
			typeof(List<string>),
			typeof(bool?),
			typeof(int),
			typeof(int),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters6 = new Type[10]
		{
			typeof(int),
			typeof(int),
			typeof(int),
			typeof(string),
			typeof(string),
			typeof(List<string>),
			typeof(bool?),
			typeof(int),
			typeof(int),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters7 = new Type[4]
		{
			typeof(string),
			typeof(int),
			typeof(FilterRequestDto),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters8 = new Type[9]
		{
			typeof(string),
			typeof(int),
			typeof(int),
			typeof(string),
			typeof(string),
			typeof(bool?),
			typeof(List<string>),
			typeof(int),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters9 = new Type[9]
		{
			typeof(string),
			typeof(int),
			typeof(int),
			typeof(bool),
			typeof(string),
			typeof(string),
			typeof(ProductRequestDto),
			typeof(int),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters10 = new Type[9]
		{
			typeof(string),
			typeof(int),
			typeof(int),
			typeof(string),
			typeof(string),
			typeof(List<string>),
			typeof(bool?),
			typeof(int),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters11 = new Type[6]
		{
			typeof(string),
			typeof(int),
			typeof(string),
			typeof(string),
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters12 = new Type[7]
		{
			typeof(string),
			typeof(string),
			typeof(int),
			typeof(string),
			typeof(string),
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters13 = new Type[3]
		{
			typeof(string),
			typeof(IEnumerable<string>),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters14 = new Type[9]
		{
			typeof(int),
			typeof(int?),
			typeof(string),
			typeof(string),
			typeof(List<string>),
			typeof(bool?),
			typeof(int),
			typeof(int),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters15 = new Type[10]
		{
			typeof(int),
			typeof(int),
			typeof(int),
			typeof(string),
			typeof(string),
			typeof(List<string>),
			typeof(bool?),
			typeof(int),
			typeof(int),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters16 = new Type[4]
		{
			typeof(string),
			typeof(int),
			typeof(FilterRequestDto),
			typeof(CancellationToken)
		};

		public HttpClient Client { get; }

		public AuchanCommonEcomProductsIProductsApi(HttpClient client, IRequestBuilder requestBuilder)
		{
			Client = client;
			this.requestBuilder = requestBuilder;
		}

		public async Task<ProductResultDto> GetAllProductsByCategoryAsync(string categoryCode, int storeId, int offset, string? orderField, string? orderDirection, bool? isAdult, List<string>? filters, int perPage, CancellationToken cancellationToken)
		{
			object[] arg = new object[9] { categoryCode, storeId, offset, orderField, orderDirection, isAdult, filters, perPage, cancellationToken };
			return await ((Task<ProductResultDto>)requestBuilder.BuildRestResultFuncForMethod("GetAllProductsByCategoryAsync", ______typeParameters)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<ProductResultDto> GetAllProductsByCategoryAsync(string? accessToken, int storeId, int offset, bool deliveryAddressSelected, string? orderField, string? orderDirection, ProductRequestDto? request, int perPage, CancellationToken cancellationToken)
		{
			object[] arg = new object[9] { accessToken, storeId, offset, deliveryAddressSelected, orderField, orderDirection, request, perPage, cancellationToken };
			return await ((Task<ProductResultDto>)requestBuilder.BuildRestResultFuncForMethod("GetAllProductsByCategoryAsync", ______typeParameters0)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<ProductResultDto> GetAllProductsByBrandAsync(string brandCode, int storeId, int offset, string? orderField, string? orderDirection, List<string>? filters, bool? isAdult, int perPage, CancellationToken cancellationToken)
		{
			object[] arg = new object[9] { brandCode, storeId, offset, orderField, orderDirection, filters, isAdult, perPage, cancellationToken };
			return await ((Task<ProductResultDto>)requestBuilder.BuildRestResultFuncForMethod("GetAllProductsByBrandAsync", ______typeParameters1)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<Auchan.Common.Ecom.DTO.ProductDto> GetProductDetailWithoutTokenAsync(string? productCode, int storeId, string? gimaId, string channel, string? pricecheckerChannel, CancellationToken cancellationToken)
		{
			object[] arg = new object[6] { productCode, storeId, gimaId, channel, pricecheckerChannel, cancellationToken };
			return await ((Task<Auchan.Common.Ecom.DTO.ProductDto>)requestBuilder.BuildRestResultFuncForMethod("GetProductDetailWithoutTokenAsync", ______typeParameters2)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<Auchan.Common.Ecom.DTO.ProductDto> GetProductDetailWithTokenAsync(string accessToken, string? productCode, int storeId, string? gimaId, string channel, string? pricecheckerChannel, CancellationToken cancellationToken)
		{
			object[] arg = new object[7] { accessToken, productCode, storeId, gimaId, channel, pricecheckerChannel, cancellationToken };
			return await ((Task<Auchan.Common.Ecom.DTO.ProductDto>)requestBuilder.BuildRestResultFuncForMethod("GetProductDetailWithTokenAsync", ______typeParameters3)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<Auchan.Common.Ecom.DTO.ProductDto[]> GetProductsByGimaIdAsync(string merchantId, IEnumerable<string> gimaIds, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { merchantId, gimaIds, cancellationToken };
			return await ((Task<Auchan.Common.Ecom.DTO.ProductDto[]>)requestBuilder.BuildRestResultFuncForMethod("GetProductsByGimaIdAsync", ______typeParameters4)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<ProductSortTypesDto> GetSortTypes()
		{
			object[] arg = Array.Empty<object>();
			return await ((Task<ProductSortTypesDto>)requestBuilder.BuildRestResultFuncForMethod("GetSortTypes", Array.Empty<Type>())(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<ProductResultDto> GetProductsPromoOnlyAsync(int storeId, int? offset, string? orderField, string? orderDirection, List<string>? filters, bool? isAdult, int promoOnly, int perPage, CancellationToken cancellationToken)
		{
			object[] arg = new object[9] { storeId, offset, orderField, orderDirection, filters, isAdult, promoOnly, perPage, cancellationToken };
			return await ((Task<ProductResultDto>)requestBuilder.BuildRestResultFuncForMethod("GetProductsPromoOnlyAsync", ______typeParameters5)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<ProductResultDto> GetProductsCashbackOnlyAsync(int storeId, int page, int offset, string? orderField, string? orderDirection, List<string>? filters, bool? isAdult, int cashbackOnly, int perPage, CancellationToken cancellationToken)
		{
			object[] arg = new object[10] { storeId, page, offset, orderField, orderDirection, filters, isAdult, cashbackOnly, perPage, cancellationToken };
			return await ((Task<ProductResultDto>)requestBuilder.BuildRestResultFuncForMethod("GetProductsCashbackOnlyAsync", ______typeParameters6)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<ProductFilterResponseDto> GetFiltersAsync(string categoryCode, int storeId, FilterRequestDto? request, CancellationToken cancellationToken)
		{
			object[] arg = new object[4] { categoryCode, storeId, request, cancellationToken };
			return await ((Task<ProductFilterResponseDto>)requestBuilder.BuildRestResultFuncForMethod("GetFiltersAsync", ______typeParameters7)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<ProductResultDto> IProductsApi.GetAllProductsByCategoryAsync(string categoryCode, int storeId, int offset, string? orderField, string? orderDirection, bool? isAdult, List<string>? filters, int perPage, CancellationToken cancellationToken)
		{
			object[] arg = new object[9] { categoryCode, storeId, offset, orderField, orderDirection, isAdult, filters, perPage, cancellationToken };
			return await ((Task<ProductResultDto>)requestBuilder.BuildRestResultFuncForMethod("GetAllProductsByCategoryAsync", ______typeParameters8)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<ProductResultDto> IProductsApi.GetAllProductsByCategoryAsync(string? accessToken, int storeId, int offset, bool deliveryAddressSelected, string? orderField, string? orderDirection, ProductRequestDto? request, int perPage, CancellationToken cancellationToken)
		{
			object[] arg = new object[9] { accessToken, storeId, offset, deliveryAddressSelected, orderField, orderDirection, request, perPage, cancellationToken };
			return await ((Task<ProductResultDto>)requestBuilder.BuildRestResultFuncForMethod("GetAllProductsByCategoryAsync", ______typeParameters9)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<ProductResultDto> IProductsApi.GetAllProductsByBrandAsync(string brandCode, int storeId, int offset, string? orderField, string? orderDirection, List<string>? filters, bool? isAdult, int perPage, CancellationToken cancellationToken)
		{
			object[] arg = new object[9] { brandCode, storeId, offset, orderField, orderDirection, filters, isAdult, perPage, cancellationToken };
			return await ((Task<ProductResultDto>)requestBuilder.BuildRestResultFuncForMethod("GetAllProductsByBrandAsync", ______typeParameters10)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<Auchan.Common.Ecom.DTO.ProductDto> IProductsApi.GetProductDetailWithoutTokenAsync(string? productCode, int storeId, string? gimaId, string channel, string? pricecheckerChannel, CancellationToken cancellationToken)
		{
			object[] arg = new object[6] { productCode, storeId, gimaId, channel, pricecheckerChannel, cancellationToken };
			return await ((Task<Auchan.Common.Ecom.DTO.ProductDto>)requestBuilder.BuildRestResultFuncForMethod("GetProductDetailWithoutTokenAsync", ______typeParameters11)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<Auchan.Common.Ecom.DTO.ProductDto> IProductsApi.GetProductDetailWithTokenAsync(string accessToken, string? productCode, int storeId, string? gimaId, string channel, string? pricecheckerChannel, CancellationToken cancellationToken)
		{
			object[] arg = new object[7] { accessToken, productCode, storeId, gimaId, channel, pricecheckerChannel, cancellationToken };
			return await ((Task<Auchan.Common.Ecom.DTO.ProductDto>)requestBuilder.BuildRestResultFuncForMethod("GetProductDetailWithTokenAsync", ______typeParameters12)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<Auchan.Common.Ecom.DTO.ProductDto[]> IProductsApi.GetProductsByGimaIdAsync(string merchantId, IEnumerable<string> gimaIds, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { merchantId, gimaIds, cancellationToken };
			return await ((Task<Auchan.Common.Ecom.DTO.ProductDto[]>)requestBuilder.BuildRestResultFuncForMethod("GetProductsByGimaIdAsync", ______typeParameters13)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<ProductSortTypesDto> IProductsApi.GetSortTypes()
		{
			object[] arg = Array.Empty<object>();
			return await ((Task<ProductSortTypesDto>)requestBuilder.BuildRestResultFuncForMethod("GetSortTypes", Array.Empty<Type>())(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<ProductResultDto> IProductsApi.GetProductsPromoOnlyAsync(int storeId, int? offset, string? orderField, string? orderDirection, List<string>? filters, bool? isAdult, int promoOnly, int perPage, CancellationToken cancellationToken)
		{
			object[] arg = new object[9] { storeId, offset, orderField, orderDirection, filters, isAdult, promoOnly, perPage, cancellationToken };
			return await ((Task<ProductResultDto>)requestBuilder.BuildRestResultFuncForMethod("GetProductsPromoOnlyAsync", ______typeParameters14)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<ProductResultDto> IProductsApi.GetProductsCashbackOnlyAsync(int storeId, int page, int offset, string? orderField, string? orderDirection, List<string>? filters, bool? isAdult, int cashbackOnly, int perPage, CancellationToken cancellationToken)
		{
			object[] arg = new object[10] { storeId, page, offset, orderField, orderDirection, filters, isAdult, cashbackOnly, perPage, cancellationToken };
			return await ((Task<ProductResultDto>)requestBuilder.BuildRestResultFuncForMethod("GetProductsCashbackOnlyAsync", ______typeParameters15)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<ProductFilterResponseDto> IProductsApi.GetFiltersAsync(string categoryCode, int storeId, FilterRequestDto? request, CancellationToken cancellationToken)
		{
			object[] arg = new object[4] { categoryCode, storeId, request, cancellationToken };
			return await ((Task<ProductFilterResponseDto>)requestBuilder.BuildRestResultFuncForMethod("GetFiltersAsync", ______typeParameters16)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	[ExcludeFromCodeCoverage]
	[DebuggerNonUserCode]
	[Preserve]
	[Obfuscation(Exclude = true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	private class AuchanCommonEcomSearchInfrastructureISearchAPI : ISearchAPI
	{
		private readonly IRequestBuilder requestBuilder;

		private static readonly Type[] ______typeParameters = new Type[7]
		{
			typeof(string),
			typeof(int),
			typeof(bool?),
			typeof(SearchRequestDTO),
			typeof(int?),
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters0 = new Type[5]
		{
			typeof(string),
			typeof(int),
			typeof(int?),
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters1 = new Type[7]
		{
			typeof(string),
			typeof(int),
			typeof(bool?),
			typeof(SearchRequestDTO),
			typeof(int?),
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters2 = new Type[5]
		{
			typeof(string),
			typeof(int),
			typeof(int?),
			typeof(string),
			typeof(CancellationToken)
		};

		public HttpClient Client { get; }

		public AuchanCommonEcomSearchInfrastructureISearchAPI(HttpClient client, IRequestBuilder requestBuilder)
		{
			Client = client;
			this.requestBuilder = requestBuilder;
		}

		public async Task<SearchResultDTO> ProductsBySearchQuery(string query, int storeId, bool? isAdult, SearchRequestDTO searchRequest, int? showHidden, string channel, CancellationToken cancellationToken)
		{
			object[] arg = new object[7] { query, storeId, isAdult, searchRequest, showHidden, channel, cancellationToken };
			return await ((Task<SearchResultDTO>)requestBuilder.BuildRestResultFuncForMethod("ProductsBySearchQuery", ______typeParameters)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<SearchAutohintsResultDTO> AutohintsBySearchQuery(string query, int storeId, int? showHidden, string channel, CancellationToken cancellationToken)
		{
			object[] arg = new object[5] { query, storeId, showHidden, channel, cancellationToken };
			return await ((Task<SearchAutohintsResultDTO>)requestBuilder.BuildRestResultFuncForMethod("AutohintsBySearchQuery", ______typeParameters0)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<SearchResultDTO> ISearchAPI.ProductsBySearchQuery(string query, int storeId, bool? isAdult, SearchRequestDTO searchRequest, int? showHidden, string channel, CancellationToken cancellationToken)
		{
			object[] arg = new object[7] { query, storeId, isAdult, searchRequest, showHidden, channel, cancellationToken };
			return await ((Task<SearchResultDTO>)requestBuilder.BuildRestResultFuncForMethod("ProductsBySearchQuery", ______typeParameters1)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<SearchAutohintsResultDTO> ISearchAPI.AutohintsBySearchQuery(string query, int storeId, int? showHidden, string channel, CancellationToken cancellationToken)
		{
			object[] arg = new object[5] { query, storeId, showHidden, channel, cancellationToken };
			return await ((Task<SearchAutohintsResultDTO>)requestBuilder.BuildRestResultFuncForMethod("AutohintsBySearchQuery", ______typeParameters2)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	[ExcludeFromCodeCoverage]
	[DebuggerNonUserCode]
	[Preserve]
	[Obfuscation(Exclude = true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	private class AuchanCommonFeedbackIFeedbackApi : IFeedbackApi
	{
		private readonly IRequestBuilder requestBuilder;

		private static readonly Type[] ______typeParameters = new Type[3]
		{
			typeof(FeedbackMessage),
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters0 = new Type[3]
		{
			typeof(StreamPart),
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters1 = new Type[2]
		{
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters2 = new Type[3]
		{
			typeof(FeedbackMessage),
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters3 = new Type[3]
		{
			typeof(StreamPart),
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters4 = new Type[2]
		{
			typeof(string),
			typeof(CancellationToken)
		};

		public HttpClient Client { get; }

		public AuchanCommonFeedbackIFeedbackApi(HttpClient client, IRequestBuilder requestBuilder)
		{
			Client = client;
			this.requestBuilder = requestBuilder;
		}

		public async Task<FeedbackResponseDto> Feedback(FeedbackMessage feedback, string token, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { feedback, token, cancellationToken };
			return await ((Task<FeedbackResponseDto>)requestBuilder.BuildRestResultFuncForMethod("Feedback", ______typeParameters)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<FeedbackAttachmentResponseDto> FeedbackAttachment(StreamPart stream, string token, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { stream, token, cancellationToken };
			return await ((Task<FeedbackAttachmentResponseDto>)requestBuilder.BuildRestResultFuncForMethod("FeedbackAttachment", ______typeParameters0)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<FeedbackConfigResponseDto> Config(string token, CancellationToken cancellationToken)
		{
			object[] arg = new object[2] { token, cancellationToken };
			return await ((Task<FeedbackConfigResponseDto>)requestBuilder.BuildRestResultFuncForMethod("Config", ______typeParameters1)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<FeedbackResponseDto> IFeedbackApi.Feedback(FeedbackMessage feedback, string token, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { feedback, token, cancellationToken };
			return await ((Task<FeedbackResponseDto>)requestBuilder.BuildRestResultFuncForMethod("Feedback", ______typeParameters2)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<FeedbackAttachmentResponseDto> IFeedbackApi.FeedbackAttachment(StreamPart stream, string token, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { stream, token, cancellationToken };
			return await ((Task<FeedbackAttachmentResponseDto>)requestBuilder.BuildRestResultFuncForMethod("FeedbackAttachment", ______typeParameters3)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<FeedbackConfigResponseDto> IFeedbackApi.Config(string token, CancellationToken cancellationToken)
		{
			object[] arg = new object[2] { token, cancellationToken };
			return await ((Task<FeedbackConfigResponseDto>)requestBuilder.BuildRestResultFuncForMethod("Config", ______typeParameters4)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	[ExcludeFromCodeCoverage]
	[DebuggerNonUserCode]
	[Preserve]
	[Obfuscation(Exclude = true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	private class AuchanCommonInfoPagesIInfoPagesApi : IInfoPagesApi
	{
		private readonly IRequestBuilder requestBuilder;

		private static readonly Type[] ______typeParameters = new Type[2]
		{
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters0 = new Type[3]
		{
			typeof(string),
			typeof(FAQType),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters1 = new Type[2]
		{
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters2 = new Type[2]
		{
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters3 = new Type[3]
		{
			typeof(string),
			typeof(FAQType),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters4 = new Type[2]
		{
			typeof(string),
			typeof(CancellationToken)
		};

		public HttpClient Client { get; }

		public AuchanCommonInfoPagesIInfoPagesApi(HttpClient client, IRequestBuilder requestBuilder)
		{
			Client = client;
			this.requestBuilder = requestBuilder;
		}

		public async Task<List<InfoResponseDto>> InfoPages(string token, CancellationToken cancellationToken)
		{
			object[] arg = new object[2] { token, cancellationToken };
			return await ((Task<List<InfoResponseDto>>)requestBuilder.BuildRestResultFuncForMethod("InfoPages", ______typeParameters)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<List<FAQResponseDto>> FAQ(string token, FAQType type, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { token, type, cancellationToken };
			return await ((Task<List<FAQResponseDto>>)requestBuilder.BuildRestResultFuncForMethod("FAQ", ______typeParameters0)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<List<TutorialDto>> Tutorials(string token, CancellationToken cancellationToken)
		{
			object[] arg = new object[2] { token, cancellationToken };
			return await ((Task<List<TutorialDto>>)requestBuilder.BuildRestResultFuncForMethod("Tutorials", ______typeParameters1)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<List<InfoResponseDto>> IInfoPagesApi.InfoPages(string token, CancellationToken cancellationToken)
		{
			object[] arg = new object[2] { token, cancellationToken };
			return await ((Task<List<InfoResponseDto>>)requestBuilder.BuildRestResultFuncForMethod("InfoPages", ______typeParameters2)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<List<FAQResponseDto>> IInfoPagesApi.FAQ(string token, FAQType type, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { token, type, cancellationToken };
			return await ((Task<List<FAQResponseDto>>)requestBuilder.BuildRestResultFuncForMethod("FAQ", ______typeParameters3)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<List<TutorialDto>> IInfoPagesApi.Tutorials(string token, CancellationToken cancellationToken)
		{
			object[] arg = new object[2] { token, cancellationToken };
			return await ((Task<List<TutorialDto>>)requestBuilder.BuildRestResultFuncForMethod("Tutorials", ______typeParameters4)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	[ExcludeFromCodeCoverage]
	[DebuggerNonUserCode]
	[Preserve]
	[Obfuscation(Exclude = true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	private class AuchanCommonLoyaltyProgramCouponsInfrastructureICouponsApi : ICouponsApi
	{
		private readonly IRequestBuilder requestBuilder;

		private static readonly Type[] ______typeParameters = new Type[3]
		{
			typeof(string),
			typeof(CancellationToken),
			typeof(string)
		};

		private static readonly Type[] ______typeParameters0 = new Type[3]
		{
			typeof(string),
			typeof(CancellationToken),
			typeof(string)
		};

		public HttpClient Client { get; }

		public AuchanCommonLoyaltyProgramCouponsInfrastructureICouponsApi(HttpClient client, IRequestBuilder requestBuilder)
		{
			Client = client;
			this.requestBuilder = requestBuilder;
		}

		public async Task<CouponsResponseDTO> Coupons(string token80, CancellationToken token, string channel)
		{
			object[] arg = new object[3] { token80, token, channel };
			return await ((Task<CouponsResponseDTO>)requestBuilder.BuildRestResultFuncForMethod("Coupons", ______typeParameters)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<CouponsResponseDTO> ICouponsApi.Coupons(string token80, CancellationToken token, string channel)
		{
			object[] arg = new object[3] { token80, token, channel };
			return await ((Task<CouponsResponseDTO>)requestBuilder.BuildRestResultFuncForMethod("Coupons", ______typeParameters0)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	[ExcludeFromCodeCoverage]
	[DebuggerNonUserCode]
	[Preserve]
	[Obfuscation(Exclude = true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	private class AuchanCommonLoyaltyProgramServicesInfrastructureILoyaltyProgramAdminApi : ILoyaltyProgramAdminApi
	{
		private readonly IRequestBuilder requestBuilder;

		private static readonly Type[] ______typeParameters = new Type[3]
		{
			typeof(string),
			typeof(string[]),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters0 = new Type[3]
		{
			typeof(string),
			typeof(string[]),
			typeof(CancellationToken)
		};

		public HttpClient Client { get; }

		public AuchanCommonLoyaltyProgramServicesInfrastructureILoyaltyProgramAdminApi(HttpClient client, IRequestBuilder requestBuilder)
		{
			Client = client;
			this.requestBuilder = requestBuilder;
		}

		public async Task<IEnumerable<LoyaltyProgramGreetingDto>> GetGreetingsForTheUser(string authToken, string[] slugs, CancellationToken token)
		{
			object[] arg = new object[3] { authToken, slugs, token };
			return await ((Task<IEnumerable<LoyaltyProgramGreetingDto>>)requestBuilder.BuildRestResultFuncForMethod("GetGreetingsForTheUser", ______typeParameters)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<IEnumerable<LoyaltyProgramGreetingDto>> ILoyaltyProgramAdminApi.GetGreetingsForTheUser(string authToken, string[] slugs, CancellationToken token)
		{
			object[] arg = new object[3] { authToken, slugs, token };
			return await ((Task<IEnumerable<LoyaltyProgramGreetingDto>>)requestBuilder.BuildRestResultFuncForMethod("GetGreetingsForTheUser", ______typeParameters0)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	[ExcludeFromCodeCoverage]
	[DebuggerNonUserCode]
	[Preserve]
	[Obfuscation(Exclude = true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	private class AuchanCommonLoyaltyProgramServicesILoyaltyProgramApi : ILoyaltyProgramApi
	{
		private readonly IRequestBuilder requestBuilder;

		private static readonly Type[] ______typeParameters = new Type[2]
		{
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters0 = new Type[3]
		{
			typeof(string),
			typeof(LoyaltyCardBlockDto),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters1 = new Type[4]
		{
			typeof(string),
			typeof(string),
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters2 = new Type[2]
		{
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters3 = new Type[3]
		{
			typeof(string),
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters4 = new Type[3]
		{
			typeof(string),
			typeof(object),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters5 = new Type[2]
		{
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters6 = new Type[2]
		{
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters7 = new Type[3]
		{
			typeof(string),
			typeof(LoyaltyCardBlockDto),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters8 = new Type[4]
		{
			typeof(string),
			typeof(string),
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters9 = new Type[2]
		{
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters10 = new Type[3]
		{
			typeof(string),
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters11 = new Type[3]
		{
			typeof(string),
			typeof(object),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters12 = new Type[2]
		{
			typeof(string),
			typeof(CancellationToken)
		};

		public HttpClient Client { get; }

		public AuchanCommonLoyaltyProgramServicesILoyaltyProgramApi(HttpClient client, IRequestBuilder requestBuilder)
		{
			Client = client;
			this.requestBuilder = requestBuilder;
		}

		public async Task<LoyaltyProgramBalanceResponseDto> Balance(string token80, CancellationToken token)
		{
			object[] arg = new object[2] { token80, token };
			return await ((Task<LoyaltyProgramBalanceResponseDto>)requestBuilder.BuildRestResultFuncForMethod("Balance", ______typeParameters)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<LoyaltyProgramBlockCardResponseDto> BlockCard(string token80, LoyaltyCardBlockDto request, CancellationToken token)
		{
			object[] arg = new object[3] { token80, request, token };
			return await ((Task<LoyaltyProgramBlockCardResponseDto>)requestBuilder.BuildRestResultFuncForMethod("BlockCard", ______typeParameters0)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<LoyaltyProgramBlockCardResponseDto> BlockAndReissueCard(string token80, string? cardNumber, string? cardCvvNumber, CancellationToken token)
		{
			object[] arg = new object[4] { token80, cardNumber, cardCvvNumber, token };
			return await ((Task<LoyaltyProgramBlockCardResponseDto>)requestBuilder.BuildRestResultFuncForMethod("BlockAndReissueCard", ______typeParameters1)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<IEnumerable<LoyaltyProgramPurchaseDto>> Purchases(string token80, CancellationToken token)
		{
			object[] arg = new object[2] { token80, token };
			return await ((Task<IEnumerable<LoyaltyProgramPurchaseDto>>)requestBuilder.BuildRestResultFuncForMethod("Purchases", ______typeParameters2)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<TransactionDetailsDto> TransactionDetails(string token80, string transactionId, CancellationToken token)
		{
			object[] arg = new object[3] { token80, transactionId, token };
			return await ((Task<TransactionDetailsDto>)requestBuilder.BuildRestResultFuncForMethod("TransactionDetails", ______typeParameters3)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<LoyaltyEnrollmentDto> Enrollment(string token80, object request, CancellationToken token)
		{
			object[] arg = new object[3] { token80, request, token };
			return await ((Task<LoyaltyEnrollmentDto>)requestBuilder.BuildRestResultFuncForMethod("Enrollment", ______typeParameters4)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<LoyaltyProgramSocialStatusResponseDto> SocialStatus(string token80, CancellationToken token)
		{
			object[] arg = new object[2] { token80, token };
			return await ((Task<LoyaltyProgramSocialStatusResponseDto>)requestBuilder.BuildRestResultFuncForMethod("SocialStatus", ______typeParameters5)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<LoyaltyProgramBalanceResponseDto> ILoyaltyProgramApi.Balance(string token80, CancellationToken token)
		{
			object[] arg = new object[2] { token80, token };
			return await ((Task<LoyaltyProgramBalanceResponseDto>)requestBuilder.BuildRestResultFuncForMethod("Balance", ______typeParameters6)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<LoyaltyProgramBlockCardResponseDto> ILoyaltyProgramApi.BlockCard(string token80, LoyaltyCardBlockDto request, CancellationToken token)
		{
			object[] arg = new object[3] { token80, request, token };
			return await ((Task<LoyaltyProgramBlockCardResponseDto>)requestBuilder.BuildRestResultFuncForMethod("BlockCard", ______typeParameters7)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<LoyaltyProgramBlockCardResponseDto> ILoyaltyProgramApi.BlockAndReissueCard(string token80, string? cardNumber, string? cardCvvNumber, CancellationToken token)
		{
			object[] arg = new object[4] { token80, cardNumber, cardCvvNumber, token };
			return await ((Task<LoyaltyProgramBlockCardResponseDto>)requestBuilder.BuildRestResultFuncForMethod("BlockAndReissueCard", ______typeParameters8)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<IEnumerable<LoyaltyProgramPurchaseDto>> ILoyaltyProgramApi.Purchases(string token80, CancellationToken token)
		{
			object[] arg = new object[2] { token80, token };
			return await ((Task<IEnumerable<LoyaltyProgramPurchaseDto>>)requestBuilder.BuildRestResultFuncForMethod("Purchases", ______typeParameters9)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<TransactionDetailsDto> ILoyaltyProgramApi.TransactionDetails(string token80, string transactionId, CancellationToken token)
		{
			object[] arg = new object[3] { token80, transactionId, token };
			return await ((Task<TransactionDetailsDto>)requestBuilder.BuildRestResultFuncForMethod("TransactionDetails", ______typeParameters10)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<LoyaltyEnrollmentDto> ILoyaltyProgramApi.Enrollment(string token80, object request, CancellationToken token)
		{
			object[] arg = new object[3] { token80, request, token };
			return await ((Task<LoyaltyEnrollmentDto>)requestBuilder.BuildRestResultFuncForMethod("Enrollment", ______typeParameters11)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<LoyaltyProgramSocialStatusResponseDto> ILoyaltyProgramApi.SocialStatus(string token80, CancellationToken token)
		{
			object[] arg = new object[2] { token80, token };
			return await ((Task<LoyaltyProgramSocialStatusResponseDto>)requestBuilder.BuildRestResultFuncForMethod("SocialStatus", ______typeParameters12)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	[ExcludeFromCodeCoverage]
	[DebuggerNonUserCode]
	[Preserve]
	[Obfuscation(Exclude = true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	private class AuchanCommonLoyaltyProgramLoymaxILoymaxLoyaltyApi : ILoymaxLoyaltyApi
	{
		private readonly IRequestBuilder requestBuilder;

		private static readonly Type[] ______typeParameters = new Type[3]
		{
			typeof(LoyaltyEnrollmentRequestDto),
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters0 = new Type[2]
		{
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters1 = new Type[3]
		{
			typeof(ProfileSnackCaseDto),
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters2 = new Type[3]
		{
			typeof(object),
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters3 = new Type[3]
		{
			typeof(object),
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters4 = new Type[2]
		{
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters5 = new Type[2]
		{
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters6 = new Type[2]
		{
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters7 = new Type[3]
		{
			typeof(string),
			typeof(object),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters8 = new Type[3]
		{
			typeof(object),
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters9 = new Type[3]
		{
			typeof(string),
			typeof(object),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters10 = new Type[3]
		{
			typeof(string),
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters11 = new Type[4]
		{
			typeof(string),
			typeof(string),
			typeof(object),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters12 = new Type[3]
		{
			typeof(LoyaltyEnrollmentRequestDto),
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters13 = new Type[2]
		{
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters14 = new Type[3]
		{
			typeof(ProfileSnackCaseDto),
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters15 = new Type[3]
		{
			typeof(object),
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters16 = new Type[3]
		{
			typeof(object),
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters17 = new Type[2]
		{
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters18 = new Type[2]
		{
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters19 = new Type[2]
		{
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters20 = new Type[3]
		{
			typeof(string),
			typeof(object),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters21 = new Type[3]
		{
			typeof(object),
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters22 = new Type[3]
		{
			typeof(string),
			typeof(object),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters23 = new Type[3]
		{
			typeof(string),
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters24 = new Type[4]
		{
			typeof(string),
			typeof(string),
			typeof(object),
			typeof(CancellationToken)
		};

		public HttpClient Client { get; }

		public AuchanCommonLoyaltyProgramLoymaxILoymaxLoyaltyApi(HttpClient client, IRequestBuilder requestBuilder)
		{
			Client = client;
			this.requestBuilder = requestBuilder;
		}

		public async Task<LoyaltyEnrollmentDtos> LoyaltyEnrollment(LoyaltyEnrollmentRequestDto body, string token80, CancellationToken token)
		{
			object[] arg = new object[3] { body, token80, token };
			return await ((Task<LoyaltyEnrollmentDtos>)requestBuilder.BuildRestResultFuncForMethod("LoyaltyEnrollment", ______typeParameters)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<ProfileResponseSnackCaseDto> GetProfile(string token80, CancellationToken cancellationToken)
		{
			object[] arg = new object[2] { token80, cancellationToken };
			return await ((Task<ProfileResponseSnackCaseDto>)requestBuilder.BuildRestResultFuncForMethod("GetProfile", ______typeParameters0)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<ProfileResponseSnackCaseDto> UpdateProfile(ProfileSnackCaseDto profileDto, string token80, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { profileDto, token80, cancellationToken };
			return await ((Task<ProfileResponseSnackCaseDto>)requestBuilder.BuildRestResultFuncForMethod("UpdateProfile", ______typeParameters1)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<LoymaxResponseBaseDto> LoyaltyCardMerge(object? requestBody, string token80, CancellationToken token)
		{
			object[] arg = new object[3] { requestBody, token80, token };
			return await ((Task<LoymaxResponseBaseDto>)requestBuilder.BuildRestResultFuncForMethod("LoyaltyCardMerge", ______typeParameters2)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<LoyaltyOperationsResponseDto> LoyaltyPointsOperations(object? requestBody, string token80, CancellationToken token)
		{
			object[] arg = new object[3] { requestBody, token80, token };
			return await ((Task<LoyaltyOperationsResponseDto>)requestBuilder.BuildRestResultFuncForMethod("LoyaltyPointsOperations", ______typeParameters3)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<BalanceDto> Balance(string token80, CancellationToken token)
		{
			object[] arg = new object[2] { token80, token };
			return await ((Task<BalanceDto>)requestBuilder.BuildRestResultFuncForMethod("Balance", ______typeParameters4)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<LoyaltyProgramQrCodeResponseDto> GetQrCode(string token80, CancellationToken token)
		{
			object[] arg = new object[2] { token80, token };
			return await ((Task<LoyaltyProgramQrCodeResponseDto>)requestBuilder.BuildRestResultFuncForMethod("GetQrCode", ______typeParameters5)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<SocialStatusDto> SocialStatus(string token80, CancellationToken token)
		{
			object[] arg = new object[2] { token80, token };
			return await ((Task<SocialStatusDto>)requestBuilder.BuildRestResultFuncForMethod("SocialStatus", ______typeParameters6)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<object> Pushes(string token80, object requestBody, CancellationToken token)
		{
			object[] arg = new object[3] { token80, requestBody, token };
			return await ((Task<object>)requestBuilder.BuildRestResultFuncForMethod("Pushes", ______typeParameters7)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<LoymaxHistoryResponseDto> LoyaltyHistory(object requestBody, string token80, CancellationToken token)
		{
			object[] arg = new object[3] { requestBody, token80, token };
			return await ((Task<LoymaxHistoryResponseDto>)requestBuilder.BuildRestResultFuncForMethod("LoyaltyHistory", ______typeParameters8)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<PointsTransferResponseDto> TransferPoints(string token80, object body, CancellationToken token)
		{
			object[] arg = new object[3] { token80, body, token };
			return await ((Task<PointsTransferResponseDto>)requestBuilder.BuildRestResultFuncForMethod("TransferPoints", ______typeParameters9)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<FavoriteCategoriesDto> FavoriteCategories(string token80, string source, CancellationToken token)
		{
			object[] arg = new object[3] { token80, source, token };
			return await ((Task<FavoriteCategoriesDto>)requestBuilder.BuildRestResultFuncForMethod("FavoriteCategories", ______typeParameters10)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<FavoriteCategoriesDto> SendCategories(string token80, string source, object body, CancellationToken cancellationToken)
		{
			object[] arg = new object[4] { token80, source, body, cancellationToken };
			return await ((Task<FavoriteCategoriesDto>)requestBuilder.BuildRestResultFuncForMethod("SendCategories", ______typeParameters11)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<LoyaltyEnrollmentDtos> ILoymaxLoyaltyApi.LoyaltyEnrollment(LoyaltyEnrollmentRequestDto body, string token80, CancellationToken token)
		{
			object[] arg = new object[3] { body, token80, token };
			return await ((Task<LoyaltyEnrollmentDtos>)requestBuilder.BuildRestResultFuncForMethod("LoyaltyEnrollment", ______typeParameters12)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<ProfileResponseSnackCaseDto> ILoymaxLoyaltyApi.GetProfile(string token80, CancellationToken cancellationToken)
		{
			object[] arg = new object[2] { token80, cancellationToken };
			return await ((Task<ProfileResponseSnackCaseDto>)requestBuilder.BuildRestResultFuncForMethod("GetProfile", ______typeParameters13)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<ProfileResponseSnackCaseDto> ILoymaxLoyaltyApi.UpdateProfile(ProfileSnackCaseDto profileDto, string token80, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { profileDto, token80, cancellationToken };
			return await ((Task<ProfileResponseSnackCaseDto>)requestBuilder.BuildRestResultFuncForMethod("UpdateProfile", ______typeParameters14)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<LoymaxResponseBaseDto> ILoymaxLoyaltyApi.LoyaltyCardMerge(object? requestBody, string token80, CancellationToken token)
		{
			object[] arg = new object[3] { requestBody, token80, token };
			return await ((Task<LoymaxResponseBaseDto>)requestBuilder.BuildRestResultFuncForMethod("LoyaltyCardMerge", ______typeParameters15)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<LoyaltyOperationsResponseDto> ILoymaxLoyaltyApi.LoyaltyPointsOperations(object? requestBody, string token80, CancellationToken token)
		{
			object[] arg = new object[3] { requestBody, token80, token };
			return await ((Task<LoyaltyOperationsResponseDto>)requestBuilder.BuildRestResultFuncForMethod("LoyaltyPointsOperations", ______typeParameters16)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<BalanceDto> ILoymaxLoyaltyApi.Balance(string token80, CancellationToken token)
		{
			object[] arg = new object[2] { token80, token };
			return await ((Task<BalanceDto>)requestBuilder.BuildRestResultFuncForMethod("Balance", ______typeParameters17)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<LoyaltyProgramQrCodeResponseDto> ILoymaxLoyaltyApi.GetQrCode(string token80, CancellationToken token)
		{
			object[] arg = new object[2] { token80, token };
			return await ((Task<LoyaltyProgramQrCodeResponseDto>)requestBuilder.BuildRestResultFuncForMethod("GetQrCode", ______typeParameters18)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<SocialStatusDto> ILoymaxLoyaltyApi.SocialStatus(string token80, CancellationToken token)
		{
			object[] arg = new object[2] { token80, token };
			return await ((Task<SocialStatusDto>)requestBuilder.BuildRestResultFuncForMethod("SocialStatus", ______typeParameters19)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<object> ILoymaxLoyaltyApi.Pushes(string token80, object requestBody, CancellationToken token)
		{
			object[] arg = new object[3] { token80, requestBody, token };
			return await ((Task<object>)requestBuilder.BuildRestResultFuncForMethod("Pushes", ______typeParameters20)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<LoymaxHistoryResponseDto> ILoymaxLoyaltyApi.LoyaltyHistory(object requestBody, string token80, CancellationToken token)
		{
			object[] arg = new object[3] { requestBody, token80, token };
			return await ((Task<LoymaxHistoryResponseDto>)requestBuilder.BuildRestResultFuncForMethod("LoyaltyHistory", ______typeParameters21)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<PointsTransferResponseDto> ILoymaxLoyaltyApi.TransferPoints(string token80, object body, CancellationToken token)
		{
			object[] arg = new object[3] { token80, body, token };
			return await ((Task<PointsTransferResponseDto>)requestBuilder.BuildRestResultFuncForMethod("TransferPoints", ______typeParameters22)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<FavoriteCategoriesDto> ILoymaxLoyaltyApi.FavoriteCategories(string token80, string source, CancellationToken token)
		{
			object[] arg = new object[3] { token80, source, token };
			return await ((Task<FavoriteCategoriesDto>)requestBuilder.BuildRestResultFuncForMethod("FavoriteCategories", ______typeParameters23)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<FavoriteCategoriesDto> ILoymaxLoyaltyApi.SendCategories(string token80, string source, object body, CancellationToken cancellationToken)
		{
			object[] arg = new object[4] { token80, source, body, cancellationToken };
			return await ((Task<FavoriteCategoriesDto>)requestBuilder.BuildRestResultFuncForMethod("SendCategories", ______typeParameters24)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	[ExcludeFromCodeCoverage]
	[DebuggerNonUserCode]
	[Preserve]
	[Obfuscation(Exclude = true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	private class AuchanCommonNotificationsINotificationsApi : INotificationsApi
	{
		private readonly IRequestBuilder requestBuilder;

		private static readonly Type[] ______typeParameters = new Type[2]
		{
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters0 = new Type[3]
		{
			typeof(string),
			typeof(NotificationViewRequestDto),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters1 = new Type[2]
		{
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters2 = new Type[3]
		{
			typeof(string),
			typeof(NotificationViewRequestDto),
			typeof(CancellationToken)
		};

		public HttpClient Client { get; }

		public AuchanCommonNotificationsINotificationsApi(HttpClient client, IRequestBuilder requestBuilder)
		{
			Client = client;
			this.requestBuilder = requestBuilder;
		}

		public async Task<NotificationsListResponseDto> GetNotifications(string token, CancellationToken cancellationToken)
		{
			object[] arg = new object[2] { token, cancellationToken };
			return await ((Task<NotificationsListResponseDto>)requestBuilder.BuildRestResultFuncForMethod("GetNotifications", ______typeParameters)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<NotificationViewResponseDto> MarkAsViewed(string token, NotificationViewRequestDto body, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { token, body, cancellationToken };
			return await ((Task<NotificationViewResponseDto>)requestBuilder.BuildRestResultFuncForMethod("MarkAsViewed", ______typeParameters0)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<NotificationsListResponseDto> INotificationsApi.GetNotifications(string token, CancellationToken cancellationToken)
		{
			object[] arg = new object[2] { token, cancellationToken };
			return await ((Task<NotificationsListResponseDto>)requestBuilder.BuildRestResultFuncForMethod("GetNotifications", ______typeParameters1)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<NotificationViewResponseDto> INotificationsApi.MarkAsViewed(string token, NotificationViewRequestDto body, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { token, body, cancellationToken };
			return await ((Task<NotificationViewResponseDto>)requestBuilder.BuildRestResultFuncForMethod("MarkAsViewed", ______typeParameters2)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	[ExcludeFromCodeCoverage]
	[DebuggerNonUserCode]
	[Preserve]
	[Obfuscation(Exclude = true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	private class AuchanCommonPersonalCabinetIPersonalCabinetApi : IPersonalCabinetApi
	{
		private readonly IRequestBuilder requestBuilder;

		private static readonly Type[] ______typeParameters = new Type[3]
		{
			typeof(string),
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters0 = new Type[2]
		{
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters1 = new Type[4]
		{
			typeof(string),
			typeof(string),
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters2 = new Type[2]
		{
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters3 = new Type[5]
		{
			typeof(string),
			typeof(string),
			typeof(string),
			typeof(bool),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters4 = new Type[3]
		{
			typeof(string),
			typeof(CheckAccountRequestDto),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters5 = new Type[4]
		{
			typeof(string),
			typeof(string),
			typeof(bool),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters6 = new Type[4]
		{
			typeof(string),
			typeof(string),
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters7 = new Type[5]
		{
			typeof(string),
			typeof(bool),
			typeof(string),
			typeof(string),
			typeof(string)
		};

		private static readonly Type[] ______typeParameters8 = new Type[3]
		{
			typeof(string),
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters9 = new Type[2]
		{
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters10 = new Type[4]
		{
			typeof(string),
			typeof(string),
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters11 = new Type[2]
		{
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters12 = new Type[5]
		{
			typeof(string),
			typeof(string),
			typeof(string),
			typeof(bool),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters13 = new Type[3]
		{
			typeof(string),
			typeof(CheckAccountRequestDto),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters14 = new Type[4]
		{
			typeof(string),
			typeof(string),
			typeof(bool),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters15 = new Type[4]
		{
			typeof(string),
			typeof(string),
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters16 = new Type[5]
		{
			typeof(string),
			typeof(bool),
			typeof(string),
			typeof(string),
			typeof(string)
		};

		public HttpClient Client { get; }

		public AuchanCommonPersonalCabinetIPersonalCabinetApi(HttpClient client, IRequestBuilder requestBuilder)
		{
			Client = client;
			this.requestBuilder = requestBuilder;
		}

		public async Task<TokenDto> Token20(string password, string login, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { password, login, cancellationToken };
			return await ((Task<TokenDto>)requestBuilder.BuildRestResultFuncForMethod("Token20", ______typeParameters)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<string> NewYearGameToken(string token80, CancellationToken token)
		{
			object[] arg = new object[2] { token80, token };
			return await ((Task<string>)requestBuilder.BuildRestResultFuncForMethod("NewYearGameToken", ______typeParameters0)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<TokenDto> Token80(string phone, string pin, string deviceId, CancellationToken cancellationToken)
		{
			object[] arg = new object[4] { phone, pin, deviceId, cancellationToken };
			return await ((Task<TokenDto>)requestBuilder.BuildRestResultFuncForMethod("Token80", ______typeParameters1)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<SubscriptionsListDto> GetSubscriptions(string token80, CancellationToken cancellationToken)
		{
			object[] arg = new object[2] { token80, cancellationToken };
			return await ((Task<SubscriptionsListDto>)requestBuilder.BuildRestResultFuncForMethod("GetSubscriptions", ______typeParameters2)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<CheckPhoneDto> CheckPhone(string token20, string phone, string deviceid, bool needHash, CancellationToken cancellationToken)
		{
			object[] arg = new object[5] { token20, phone, deviceid, needHash, cancellationToken };
			return await ((Task<CheckPhoneDto>)requestBuilder.BuildRestResultFuncForMethod("CheckPhone", ______typeParameters3)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<BasePersonalCabinetResponseDto> CheckAccount(string token80, CheckAccountRequestDto dto, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { token80, dto, cancellationToken };
			return await ((Task<BasePersonalCabinetResponseDto>)requestBuilder.BuildRestResultFuncForMethod("CheckAccount", ______typeParameters4)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<BasePersonalCabinetResponseDto> BeginVerifyPhone(string token80, string phone, bool needHash, CancellationToken cancellationToken)
		{
			object[] arg = new object[4] { token80, phone, needHash, cancellationToken };
			return await ((Task<BasePersonalCabinetResponseDto>)requestBuilder.BuildRestResultFuncForMethod("BeginVerifyPhone", ______typeParameters5)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<BasePersonalCabinetResponseDto> VerifyPhone(string token80, string phone, string pin, CancellationToken cancellationToken)
		{
			object[] arg = new object[4] { token80, phone, pin, cancellationToken };
			return await ((Task<BasePersonalCabinetResponseDto>)requestBuilder.BuildRestResultFuncForMethod("VerifyPhone", ______typeParameters6)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<LogoutResponseDto> Logout(string token80, bool forAll, string osType, string mobileType, string resolution)
		{
			object[] arg = new object[5] { token80, forAll, osType, mobileType, resolution };
			return await ((Task<LogoutResponseDto>)requestBuilder.BuildRestResultFuncForMethod("Logout", ______typeParameters7)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<TokenDto> IPersonalCabinetApi.Token20(string password, string login, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { password, login, cancellationToken };
			return await ((Task<TokenDto>)requestBuilder.BuildRestResultFuncForMethod("Token20", ______typeParameters8)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<string> IPersonalCabinetApi.NewYearGameToken(string token80, CancellationToken token)
		{
			object[] arg = new object[2] { token80, token };
			return await ((Task<string>)requestBuilder.BuildRestResultFuncForMethod("NewYearGameToken", ______typeParameters9)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<TokenDto> IPersonalCabinetApi.Token80(string phone, string pin, string deviceId, CancellationToken cancellationToken)
		{
			object[] arg = new object[4] { phone, pin, deviceId, cancellationToken };
			return await ((Task<TokenDto>)requestBuilder.BuildRestResultFuncForMethod("Token80", ______typeParameters10)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<SubscriptionsListDto> IPersonalCabinetApi.GetSubscriptions(string token80, CancellationToken cancellationToken)
		{
			object[] arg = new object[2] { token80, cancellationToken };
			return await ((Task<SubscriptionsListDto>)requestBuilder.BuildRestResultFuncForMethod("GetSubscriptions", ______typeParameters11)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<CheckPhoneDto> IPersonalCabinetApi.CheckPhone(string token20, string phone, string deviceid, bool needHash, CancellationToken cancellationToken)
		{
			object[] arg = new object[5] { token20, phone, deviceid, needHash, cancellationToken };
			return await ((Task<CheckPhoneDto>)requestBuilder.BuildRestResultFuncForMethod("CheckPhone", ______typeParameters12)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<BasePersonalCabinetResponseDto> IPersonalCabinetApi.CheckAccount(string token80, CheckAccountRequestDto dto, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { token80, dto, cancellationToken };
			return await ((Task<BasePersonalCabinetResponseDto>)requestBuilder.BuildRestResultFuncForMethod("CheckAccount", ______typeParameters13)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<BasePersonalCabinetResponseDto> IPersonalCabinetApi.BeginVerifyPhone(string token80, string phone, bool needHash, CancellationToken cancellationToken)
		{
			object[] arg = new object[4] { token80, phone, needHash, cancellationToken };
			return await ((Task<BasePersonalCabinetResponseDto>)requestBuilder.BuildRestResultFuncForMethod("BeginVerifyPhone", ______typeParameters14)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<BasePersonalCabinetResponseDto> IPersonalCabinetApi.VerifyPhone(string token80, string phone, string pin, CancellationToken cancellationToken)
		{
			object[] arg = new object[4] { token80, phone, pin, cancellationToken };
			return await ((Task<BasePersonalCabinetResponseDto>)requestBuilder.BuildRestResultFuncForMethod("VerifyPhone", ______typeParameters15)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<LogoutResponseDto> IPersonalCabinetApi.Logout(string token80, bool forAll, string osType, string mobileType, string resolution)
		{
			object[] arg = new object[5] { token80, forAll, osType, mobileType, resolution };
			return await ((Task<LogoutResponseDto>)requestBuilder.BuildRestResultFuncForMethod("Logout", ______typeParameters16)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	[ExcludeFromCodeCoverage]
	[DebuggerNonUserCode]
	[Preserve]
	[Obfuscation(Exclude = true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	private class AuchanCommonPersonalCabinetIVkAuthApi : IVkAuthApi
	{
		private readonly IRequestBuilder requestBuilder;

		private static readonly Type[] ______typeParameters = new Type[1] { typeof(CancellationToken) };

		private static readonly Type[] ______typeParameters0 = new Type[2]
		{
			typeof(VkTokenRequestDto),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters1 = new Type[1] { typeof(CancellationToken) };

		private static readonly Type[] ______typeParameters2 = new Type[2]
		{
			typeof(VkTokenRequestDto),
			typeof(CancellationToken)
		};

		public HttpClient Client { get; }

		public AuchanCommonPersonalCabinetIVkAuthApi(HttpClient client, IRequestBuilder requestBuilder)
		{
			Client = client;
			this.requestBuilder = requestBuilder;
		}

		public async Task<VkInitResponseDto> InitAsync(CancellationToken cancellationToken)
		{
			object[] arg = new object[1] { cancellationToken };
			return await ((Task<VkInitResponseDto>)requestBuilder.BuildRestResultFuncForMethod("InitAsync", ______typeParameters)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<VkTokenResponseDto> Token(VkTokenRequestDto request, CancellationToken cancellationToken)
		{
			object[] arg = new object[2] { request, cancellationToken };
			return await ((Task<VkTokenResponseDto>)requestBuilder.BuildRestResultFuncForMethod("Token", ______typeParameters0)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<VkInitResponseDto> IVkAuthApi.InitAsync(CancellationToken cancellationToken)
		{
			object[] arg = new object[1] { cancellationToken };
			return await ((Task<VkInitResponseDto>)requestBuilder.BuildRestResultFuncForMethod("InitAsync", ______typeParameters1)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<VkTokenResponseDto> IVkAuthApi.Token(VkTokenRequestDto request, CancellationToken cancellationToken)
		{
			object[] arg = new object[2] { request, cancellationToken };
			return await ((Task<VkTokenResponseDto>)requestBuilder.BuildRestResultFuncForMethod("Token", ______typeParameters2)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	[ExcludeFromCodeCoverage]
	[DebuggerNonUserCode]
	[Preserve]
	[Obfuscation(Exclude = true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	private class AuchanCommonPersonalOffersIPersonalOffersApi : IPersonalOffersApi
	{
		private readonly IRequestBuilder requestBuilder;

		private static readonly Type[] ______typeParameters = new Type[2]
		{
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters0 = new Type[3]
		{
			typeof(string),
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters1 = new Type[3]
		{
			typeof(string),
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters2 = new Type[3]
		{
			typeof(string),
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters3 = new Type[3]
		{
			typeof(string),
			typeof(ActivatePersonalOfferRequestDto),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters4 = new Type[2]
		{
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters5 = new Type[3]
		{
			typeof(string),
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters6 = new Type[3]
		{
			typeof(string),
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters7 = new Type[3]
		{
			typeof(string),
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters8 = new Type[3]
		{
			typeof(string),
			typeof(ActivatePersonalOfferRequestDto),
			typeof(CancellationToken)
		};

		public HttpClient Client { get; }

		public AuchanCommonPersonalOffersIPersonalOffersApi(HttpClient client, IRequestBuilder requestBuilder)
		{
			Client = client;
			this.requestBuilder = requestBuilder;
		}

		public async Task<AIlOffersResponseDto> AIPersonalOffers(string token, CancellationToken cancellationToken)
		{
			object[] arg = new object[2] { token, cancellationToken };
			return await ((Task<AIlOffersResponseDto>)requestBuilder.BuildRestResultFuncForMethod("AIPersonalOffers", ______typeParameters)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<PersonalOffersResponseDto> PersonalOffers(string token, string body, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { token, body, cancellationToken };
			return await ((Task<PersonalOffersResponseDto>)requestBuilder.BuildRestResultFuncForMethod("PersonalOffers", ______typeParameters0)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<PersonalOfferDetailsResponseDto> PersonalOfferDetails(string token, string code, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { token, code, cancellationToken };
			return await ((Task<PersonalOfferDetailsResponseDto>)requestBuilder.BuildRestResultFuncForMethod("PersonalOfferDetails", ______typeParameters1)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<AIOfferDetailsResponseDto> AIPersonalOfferDetails(string token, string code, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { token, code, cancellationToken };
			return await ((Task<AIOfferDetailsResponseDto>)requestBuilder.BuildRestResultFuncForMethod("AIPersonalOfferDetails", ______typeParameters2)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<object> ActivatePersonalOffer(string token, ActivatePersonalOfferRequestDto body, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { token, body, cancellationToken };
			return await ((Task<object>)requestBuilder.BuildRestResultFuncForMethod("ActivatePersonalOffer", ______typeParameters3)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<AIlOffersResponseDto> IPersonalOffersApi.AIPersonalOffers(string token, CancellationToken cancellationToken)
		{
			object[] arg = new object[2] { token, cancellationToken };
			return await ((Task<AIlOffersResponseDto>)requestBuilder.BuildRestResultFuncForMethod("AIPersonalOffers", ______typeParameters4)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<PersonalOffersResponseDto> IPersonalOffersApi.PersonalOffers(string token, string body, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { token, body, cancellationToken };
			return await ((Task<PersonalOffersResponseDto>)requestBuilder.BuildRestResultFuncForMethod("PersonalOffers", ______typeParameters5)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<PersonalOfferDetailsResponseDto> IPersonalOffersApi.PersonalOfferDetails(string token, string code, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { token, code, cancellationToken };
			return await ((Task<PersonalOfferDetailsResponseDto>)requestBuilder.BuildRestResultFuncForMethod("PersonalOfferDetails", ______typeParameters6)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<AIOfferDetailsResponseDto> IPersonalOffersApi.AIPersonalOfferDetails(string token, string code, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { token, code, cancellationToken };
			return await ((Task<AIOfferDetailsResponseDto>)requestBuilder.BuildRestResultFuncForMethod("AIPersonalOfferDetails", ______typeParameters7)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<object> IPersonalOffersApi.ActivatePersonalOffer(string token, ActivatePersonalOfferRequestDto body, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { token, body, cancellationToken };
			return await ((Task<object>)requestBuilder.BuildRestResultFuncForMethod("ActivatePersonalOffer", ______typeParameters8)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	[ExcludeFromCodeCoverage]
	[DebuggerNonUserCode]
	[Preserve]
	[Obfuscation(Exclude = true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	private class AuchanCommonProfileCasesApiICasesApi : ICasesApi
	{
		private readonly IRequestBuilder requestBuilder;

		private static readonly Type[] ______typeParameters = new Type[3]
		{
			typeof(string),
			typeof(CasesDtos.CasesRequestDto),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters0 = new Type[4]
		{
			typeof(string),
			typeof(string),
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters1 = new Type[3]
		{
			typeof(string),
			typeof(CasesDtos.CasesRequestDto),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters2 = new Type[4]
		{
			typeof(string),
			typeof(string),
			typeof(string),
			typeof(CancellationToken)
		};

		public HttpClient Client { get; }

		public AuchanCommonProfileCasesApiICasesApi(HttpClient client, IRequestBuilder requestBuilder)
		{
			Client = client;
			this.requestBuilder = requestBuilder;
		}

		public async Task<CasesDtos.CasesResponseDto> GetCases(string cmdToken, CasesDtos.CasesRequestDto body, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { cmdToken, body, cancellationToken };
			return await ((Task<CasesDtos.CasesResponseDto>)requestBuilder.BuildRestResultFuncForMethod("GetCases", ______typeParameters)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<CasesDtos.CaseDetailsResponseDto> GetCaseById(string cmdToken, string caseId, string number, CancellationToken cancellationToken)
		{
			object[] arg = new object[4] { cmdToken, caseId, number, cancellationToken };
			return await ((Task<CasesDtos.CaseDetailsResponseDto>)requestBuilder.BuildRestResultFuncForMethod("GetCaseById", ______typeParameters0)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<CasesDtos.CasesResponseDto> ICasesApi.GetCases(string cmdToken, CasesDtos.CasesRequestDto body, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { cmdToken, body, cancellationToken };
			return await ((Task<CasesDtos.CasesResponseDto>)requestBuilder.BuildRestResultFuncForMethod("GetCases", ______typeParameters1)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<CasesDtos.CaseDetailsResponseDto> ICasesApi.GetCaseById(string cmdToken, string caseId, string number, CancellationToken cancellationToken)
		{
			object[] arg = new object[4] { cmdToken, caseId, number, cancellationToken };
			return await ((Task<CasesDtos.CaseDetailsResponseDto>)requestBuilder.BuildRestResultFuncForMethod("GetCaseById", ______typeParameters2)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	[ExcludeFromCodeCoverage]
	[DebuggerNonUserCode]
	[Preserve]
	[Obfuscation(Exclude = true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	private class AuchanCommonProfileIFavoritesApi : IFavoritesApi
	{
		private readonly IRequestBuilder requestBuilder;

		private static readonly Type[] ______typeParameters = new Type[3]
		{
			typeof(string),
			typeof(FavoritesDtos.AddRequestDto),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters0 = new Type[3]
		{
			typeof(string),
			typeof(FavoritesDtos.AddRequestDto),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters1 = new Type[3]
		{
			typeof(string),
			typeof(FavoritesDtos.FavoritesRequestDto),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters2 = new Type[2]
		{
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters3 = new Type[3]
		{
			typeof(string),
			typeof(FavoritesDtos.AddRequestDto),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters4 = new Type[3]
		{
			typeof(string),
			typeof(FavoritesDtos.AddRequestDto),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters5 = new Type[3]
		{
			typeof(string),
			typeof(FavoritesDtos.FavoritesRequestDto),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters6 = new Type[2]
		{
			typeof(string),
			typeof(CancellationToken)
		};

		public HttpClient Client { get; }

		public AuchanCommonProfileIFavoritesApi(HttpClient client, IRequestBuilder requestBuilder)
		{
			Client = client;
			this.requestBuilder = requestBuilder;
		}

		public async Task<FavoritesDtos.AddDto> AddProduct(string cmdToken, FavoritesDtos.AddRequestDto body, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { cmdToken, body, cancellationToken };
			return await ((Task<FavoritesDtos.AddDto>)requestBuilder.BuildRestResultFuncForMethod("AddProduct", ______typeParameters)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<FavoritesDtos.DeleteDto> DeleteProduct(string cmdToken, FavoritesDtos.AddRequestDto body, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { cmdToken, body, cancellationToken };
			return await ((Task<FavoritesDtos.DeleteDto>)requestBuilder.BuildRestResultFuncForMethod("DeleteProduct", ______typeParameters0)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<FavoriteProductsDto> Favorites(string cmdToken, FavoritesDtos.FavoritesRequestDto body, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { cmdToken, body, cancellationToken };
			return await ((Task<FavoriteProductsDto>)requestBuilder.BuildRestResultFuncForMethod("Favorites", ______typeParameters1)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<FavoritesDtos.FavoriteFieldsDto> FavoriteFields(string cmdToken, CancellationToken cancellationToken)
		{
			object[] arg = new object[2] { cmdToken, cancellationToken };
			return await ((Task<FavoritesDtos.FavoriteFieldsDto>)requestBuilder.BuildRestResultFuncForMethod("FavoriteFields", ______typeParameters2)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<FavoritesDtos.AddDto> IFavoritesApi.AddProduct(string cmdToken, FavoritesDtos.AddRequestDto body, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { cmdToken, body, cancellationToken };
			return await ((Task<FavoritesDtos.AddDto>)requestBuilder.BuildRestResultFuncForMethod("AddProduct", ______typeParameters3)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<FavoritesDtos.DeleteDto> IFavoritesApi.DeleteProduct(string cmdToken, FavoritesDtos.AddRequestDto body, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { cmdToken, body, cancellationToken };
			return await ((Task<FavoritesDtos.DeleteDto>)requestBuilder.BuildRestResultFuncForMethod("DeleteProduct", ______typeParameters4)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<FavoriteProductsDto> IFavoritesApi.Favorites(string cmdToken, FavoritesDtos.FavoritesRequestDto body, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { cmdToken, body, cancellationToken };
			return await ((Task<FavoriteProductsDto>)requestBuilder.BuildRestResultFuncForMethod("Favorites", ______typeParameters5)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<FavoritesDtos.FavoriteFieldsDto> IFavoritesApi.FavoriteFields(string cmdToken, CancellationToken cancellationToken)
		{
			object[] arg = new object[2] { cmdToken, cancellationToken };
			return await ((Task<FavoritesDtos.FavoriteFieldsDto>)requestBuilder.BuildRestResultFuncForMethod("FavoriteFields", ______typeParameters6)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	[ExcludeFromCodeCoverage]
	[DebuggerNonUserCode]
	[Preserve]
	[Obfuscation(Exclude = true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	private class AuchanCommonProfileGiftCardsInfrastructureIGiftCardsApi : IGiftCardsApi
	{
		private readonly IRequestBuilder requestBuilder;

		private static readonly Type[] ______typeParameters = new Type[4]
		{
			typeof(string),
			typeof(string),
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters0 = new Type[4]
		{
			typeof(string),
			typeof(string),
			typeof(string),
			typeof(CancellationToken)
		};

		public HttpClient Client { get; }

		public AuchanCommonProfileGiftCardsInfrastructureIGiftCardsApi(HttpClient client, IRequestBuilder requestBuilder)
		{
			Client = client;
			this.requestBuilder = requestBuilder;
		}

		public async Task<GiftCardDataDTO> GiftCardData(string accessToken, string number, string pin, CancellationToken cancellationToken)
		{
			object[] arg = new object[4] { accessToken, number, pin, cancellationToken };
			return await ((Task<GiftCardDataDTO>)requestBuilder.BuildRestResultFuncForMethod("GiftCardData", ______typeParameters)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<GiftCardDataDTO> IGiftCardsApi.GiftCardData(string accessToken, string number, string pin, CancellationToken cancellationToken)
		{
			object[] arg = new object[4] { accessToken, number, pin, cancellationToken };
			return await ((Task<GiftCardDataDTO>)requestBuilder.BuildRestResultFuncForMethod("GiftCardData", ______typeParameters0)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	[ExcludeFromCodeCoverage]
	[DebuggerNonUserCode]
	[Preserve]
	[Obfuscation(Exclude = true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	private class AuchanCommonProfileOrdersServicesIOrderCancellationReasonsApi : IOrderCancellationReasonsApi
	{
		private readonly IRequestBuilder requestBuilder;

		private static readonly Type[] ______typeParameters = new Type[1] { typeof(CancellationToken) };

		private static readonly Type[] ______typeParameters0 = new Type[1] { typeof(CancellationToken) };

		public HttpClient Client { get; }

		public AuchanCommonProfileOrdersServicesIOrderCancellationReasonsApi(HttpClient client, IRequestBuilder requestBuilder)
		{
			Client = client;
			this.requestBuilder = requestBuilder;
		}

		public async Task<PossibleOrderCancellationReasonsDto> GetOrderCancellationReasonsAsync(CancellationToken cancellationToken)
		{
			object[] arg = new object[1] { cancellationToken };
			return await ((Task<PossibleOrderCancellationReasonsDto>)requestBuilder.BuildRestResultFuncForMethod("GetOrderCancellationReasonsAsync", ______typeParameters)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<PossibleOrderCancellationReasonsDto> IOrderCancellationReasonsApi.GetOrderCancellationReasonsAsync(CancellationToken cancellationToken)
		{
			object[] arg = new object[1] { cancellationToken };
			return await ((Task<PossibleOrderCancellationReasonsDto>)requestBuilder.BuildRestResultFuncForMethod("GetOrderCancellationReasonsAsync", ______typeParameters0)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	[ExcludeFromCodeCoverage]
	[DebuggerNonUserCode]
	[Preserve]
	[Obfuscation(Exclude = true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	private class AuchanCommonProfileOrdersServicesIOrdersApi : IOrdersApi
	{
		private readonly IRequestBuilder requestBuilder;

		private static readonly Type[] ______typeParameters = new Type[3]
		{
			typeof(int),
			typeof(int),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters0 = new Type[2]
		{
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters1 = new Type[3]
		{
			typeof(long),
			typeof(RepeatCartRequest),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters2 = new Type[3]
		{
			typeof(long),
			typeof(UpdateCartRequest),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters3 = new Type[3]
		{
			typeof(long),
			typeof(OrderCancellationRequestDto),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters4 = new Type[1] { typeof(CancellationToken) };

		private static readonly Type[] ______typeParameters5 = new Type[3]
		{
			typeof(long),
			typeof(AdditionItemsRequrestDto),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters6 = new Type[3]
		{
			typeof(long),
			typeof(AdditionItemsRequrestDto),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters7 = new Type[3]
		{
			typeof(int),
			typeof(int),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters8 = new Type[2]
		{
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters9 = new Type[3]
		{
			typeof(long),
			typeof(RepeatCartRequest),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters10 = new Type[3]
		{
			typeof(long),
			typeof(UpdateCartRequest),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters11 = new Type[3]
		{
			typeof(long),
			typeof(OrderCancellationRequestDto),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters12 = new Type[1] { typeof(CancellationToken) };

		private static readonly Type[] ______typeParameters13 = new Type[3]
		{
			typeof(long),
			typeof(AdditionItemsRequrestDto),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters14 = new Type[3]
		{
			typeof(long),
			typeof(AdditionItemsRequrestDto),
			typeof(CancellationToken)
		};

		public HttpClient Client { get; }

		public AuchanCommonProfileOrdersServicesIOrdersApi(HttpClient client, IRequestBuilder requestBuilder)
		{
			Client = client;
			this.requestBuilder = requestBuilder;
		}

		public async Task<OrdersDto> GetOrdersAsync(int page, int perPage, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { page, perPage, cancellationToken };
			return await ((Task<OrdersDto>)requestBuilder.BuildRestResultFuncForMethod("GetOrdersAsync", ______typeParameters)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<OrderApiDto> GetOrderAsync(string orderId, CancellationToken cancellationToken)
		{
			object[] arg = new object[2] { orderId, cancellationToken };
			return await ((Task<OrderApiDto>)requestBuilder.BuildRestResultFuncForMethod("GetOrderAsync", ______typeParameters0)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<object> RepeatOrderAsync(long orderId, RepeatCartRequest merchantId, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { orderId, merchantId, cancellationToken };
			return await ((Task<object>)requestBuilder.BuildRestResultFuncForMethod("RepeatOrderAsync", ______typeParameters1)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<object> UpdateOrderAsync(long orderId, UpdateCartRequest request, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { orderId, request, cancellationToken };
			return await ((Task<object>)requestBuilder.BuildRestResultFuncForMethod("UpdateOrderAsync", ______typeParameters2)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<OrderCancellationResponseDto> CancelOrderAsync(long orderId, OrderCancellationRequestDto request, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { orderId, request, cancellationToken };
			return await ((Task<OrderCancellationResponseDto>)requestBuilder.BuildRestResultFuncForMethod("CancelOrderAsync", ______typeParameters3)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<OrdersToAdditionDto> GetOrdersAvailableToAddition(CancellationToken cancellationToken)
		{
			object[] arg = new object[1] { cancellationToken };
			return await ((Task<OrdersToAdditionDto>)requestBuilder.BuildRestResultFuncForMethod("GetOrdersAvailableToAddition", ______typeParameters4)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<CheckAdditionItemsResponseDto> CheckAdditionItemsAsync(long orderId, AdditionItemsRequrestDto request, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { orderId, request, cancellationToken };
			return await ((Task<CheckAdditionItemsResponseDto>)requestBuilder.BuildRestResultFuncForMethod("CheckAdditionItemsAsync", ______typeParameters5)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<AddGoodsToOrderResposeDto> AddGoodsToOrderAsync(long orderId, AdditionItemsRequrestDto request, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { orderId, request, cancellationToken };
			return await ((Task<AddGoodsToOrderResposeDto>)requestBuilder.BuildRestResultFuncForMethod("AddGoodsToOrderAsync", ______typeParameters6)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<OrdersDto> IOrdersApi.GetOrdersAsync(int page, int perPage, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { page, perPage, cancellationToken };
			return await ((Task<OrdersDto>)requestBuilder.BuildRestResultFuncForMethod("GetOrdersAsync", ______typeParameters7)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<OrderApiDto> IOrdersApi.GetOrderAsync(string orderId, CancellationToken cancellationToken)
		{
			object[] arg = new object[2] { orderId, cancellationToken };
			return await ((Task<OrderApiDto>)requestBuilder.BuildRestResultFuncForMethod("GetOrderAsync", ______typeParameters8)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<object> IOrdersApi.RepeatOrderAsync(long orderId, RepeatCartRequest merchantId, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { orderId, merchantId, cancellationToken };
			return await ((Task<object>)requestBuilder.BuildRestResultFuncForMethod("RepeatOrderAsync", ______typeParameters9)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<object> IOrdersApi.UpdateOrderAsync(long orderId, UpdateCartRequest request, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { orderId, request, cancellationToken };
			return await ((Task<object>)requestBuilder.BuildRestResultFuncForMethod("UpdateOrderAsync", ______typeParameters10)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<OrderCancellationResponseDto> IOrdersApi.CancelOrderAsync(long orderId, OrderCancellationRequestDto request, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { orderId, request, cancellationToken };
			return await ((Task<OrderCancellationResponseDto>)requestBuilder.BuildRestResultFuncForMethod("CancelOrderAsync", ______typeParameters11)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<OrdersToAdditionDto> IOrdersApi.GetOrdersAvailableToAddition(CancellationToken cancellationToken)
		{
			object[] arg = new object[1] { cancellationToken };
			return await ((Task<OrdersToAdditionDto>)requestBuilder.BuildRestResultFuncForMethod("GetOrdersAvailableToAddition", ______typeParameters12)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<CheckAdditionItemsResponseDto> IOrdersApi.CheckAdditionItemsAsync(long orderId, AdditionItemsRequrestDto request, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { orderId, request, cancellationToken };
			return await ((Task<CheckAdditionItemsResponseDto>)requestBuilder.BuildRestResultFuncForMethod("CheckAdditionItemsAsync", ______typeParameters13)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<AddGoodsToOrderResposeDto> IOrdersApi.AddGoodsToOrderAsync(long orderId, AdditionItemsRequrestDto request, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { orderId, request, cancellationToken };
			return await ((Task<AddGoodsToOrderResposeDto>)requestBuilder.BuildRestResultFuncForMethod("AddGoodsToOrderAsync", ______typeParameters14)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	[ExcludeFromCodeCoverage]
	[DebuggerNonUserCode]
	[Preserve]
	[Obfuscation(Exclude = true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	private class AuchanCommonProfileStoresServicesIFullStoreApi : IFullStoreApi
	{
		private readonly IRequestBuilder requestBuilder;

		private static readonly Type[] ______typeParameters = new Type[1] { typeof(CancellationToken) };

		private static readonly Type[] ______typeParameters0 = new Type[2]
		{
			typeof(int),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters1 = new Type[2]
		{
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters2 = new Type[1] { typeof(CancellationToken) };

		private static readonly Type[] ______typeParameters3 = new Type[1] { typeof(CancellationToken) };

		private static readonly Type[] ______typeParameters4 = new Type[2]
		{
			typeof(int),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters5 = new Type[2]
		{
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters6 = new Type[1] { typeof(CancellationToken) };

		public HttpClient Client { get; }

		public AuchanCommonProfileStoresServicesIFullStoreApi(HttpClient client, IRequestBuilder requestBuilder)
		{
			Client = client;
			this.requestBuilder = requestBuilder;
		}

		public async Task<List<FullStoreDto>> GetStores(CancellationToken cancellationToken)
		{
			object[] arg = new object[1] { cancellationToken };
			return await ((Task<List<FullStoreDto>>)requestBuilder.BuildRestResultFuncForMethod("GetStores", ______typeParameters)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<FullStoreDto> GetStore(int storeId, CancellationToken cancellationToken)
		{
			object[] arg = new object[2] { storeId, cancellationToken };
			return await ((Task<FullStoreDto>)requestBuilder.BuildRestResultFuncForMethod("GetStore", ______typeParameters0)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<List<FullStoreServiceDto>> GetAllServicesAsync(string userAgent, CancellationToken cancellationToken)
		{
			object[] arg = new object[2] { userAgent, cancellationToken };
			return await ((Task<List<FullStoreServiceDto>>)requestBuilder.BuildRestResultFuncForMethod("GetAllServicesAsync", ______typeParameters1)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<List<FullStoreDto>> GetSelfScanStores(CancellationToken cancellationToken)
		{
			object[] arg = new object[1] { cancellationToken };
			return await ((Task<List<FullStoreDto>>)requestBuilder.BuildRestResultFuncForMethod("GetSelfScanStores", ______typeParameters2)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<List<FullStoreDto>> IFullStoreApi.GetStores(CancellationToken cancellationToken)
		{
			object[] arg = new object[1] { cancellationToken };
			return await ((Task<List<FullStoreDto>>)requestBuilder.BuildRestResultFuncForMethod("GetStores", ______typeParameters3)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<FullStoreDto> IFullStoreApi.GetStore(int storeId, CancellationToken cancellationToken)
		{
			object[] arg = new object[2] { storeId, cancellationToken };
			return await ((Task<FullStoreDto>)requestBuilder.BuildRestResultFuncForMethod("GetStore", ______typeParameters4)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<List<FullStoreServiceDto>> IFullStoreApi.GetAllServicesAsync(string userAgent, CancellationToken cancellationToken)
		{
			object[] arg = new object[2] { userAgent, cancellationToken };
			return await ((Task<List<FullStoreServiceDto>>)requestBuilder.BuildRestResultFuncForMethod("GetAllServicesAsync", ______typeParameters5)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<List<FullStoreDto>> IFullStoreApi.GetSelfScanStores(CancellationToken cancellationToken)
		{
			object[] arg = new object[1] { cancellationToken };
			return await ((Task<List<FullStoreDto>>)requestBuilder.BuildRestResultFuncForMethod("GetSelfScanStores", ______typeParameters6)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	[ExcludeFromCodeCoverage]
	[DebuggerNonUserCode]
	[Preserve]
	[Obfuscation(Exclude = true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	private class AuchanCommonProfileStoresServicesIRegionApi : IRegionApi
	{
		private readonly IRequestBuilder requestBuilder;

		private static readonly Type[] ______typeParameters = new Type[1] { typeof(CancellationToken) };

		private static readonly Type[] ______typeParameters0 = new Type[1] { typeof(CancellationToken) };

		public HttpClient Client { get; }

		public AuchanCommonProfileStoresServicesIRegionApi(HttpClient client, IRequestBuilder requestBuilder)
		{
			Client = client;
			this.requestBuilder = requestBuilder;
		}

		public async Task<List<FullRegionDto>> GetRegions(CancellationToken cancellationToken)
		{
			object[] arg = new object[1] { cancellationToken };
			return await ((Task<List<FullRegionDto>>)requestBuilder.BuildRestResultFuncForMethod("GetRegions", ______typeParameters)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<List<FullRegionDto>> IRegionApi.GetRegions(CancellationToken cancellationToken)
		{
			object[] arg = new object[1] { cancellationToken };
			return await ((Task<List<FullRegionDto>>)requestBuilder.BuildRestResultFuncForMethod("GetRegions", ______typeParameters0)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	[ExcludeFromCodeCoverage]
	[DebuggerNonUserCode]
	[Preserve]
	[Obfuscation(Exclude = true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	private class AuchanCommonProfileUserCardsIUserCardsApi : IUserCardsApi
	{
		private readonly IRequestBuilder requestBuilder;

		private static readonly Type[] ______typeParameters = new Type[2]
		{
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters0 = new Type[2]
		{
			typeof(CreateTokenRequestDto),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters1 = new Type[2]
		{
			typeof(DeleteTokenRequestDto),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters2 = new Type[2]
		{
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters3 = new Type[2]
		{
			typeof(CreateTokenRequestDto),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters4 = new Type[2]
		{
			typeof(DeleteTokenRequestDto),
			typeof(CancellationToken)
		};

		public HttpClient Client { get; }

		public AuchanCommonProfileUserCardsIUserCardsApi(HttpClient client, IRequestBuilder requestBuilder)
		{
			Client = client;
			this.requestBuilder = requestBuilder;
		}

		public async Task<TokenListResponseDto> Tokens(string magentoAccountId, CancellationToken cancellationToken)
		{
			object[] arg = new object[2] { magentoAccountId, cancellationToken };
			return await ((Task<TokenListResponseDto>)requestBuilder.BuildRestResultFuncForMethod("Tokens", ______typeParameters)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<CreateTokenResponseDto> CreateTokenValidate(CreateTokenRequestDto requestDto, CancellationToken cancellationToken)
		{
			object[] arg = new object[2] { requestDto, cancellationToken };
			return await ((Task<CreateTokenResponseDto>)requestBuilder.BuildRestResultFuncForMethod("CreateTokenValidate", ______typeParameters0)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<DeleteTokenResponseDto> DeleteToken(DeleteTokenRequestDto request, CancellationToken cancellationToken)
		{
			object[] arg = new object[2] { request, cancellationToken };
			return await ((Task<DeleteTokenResponseDto>)requestBuilder.BuildRestResultFuncForMethod("DeleteToken", ______typeParameters1)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<TokenListResponseDto> IUserCardsApi.Tokens(string magentoAccountId, CancellationToken cancellationToken)
		{
			object[] arg = new object[2] { magentoAccountId, cancellationToken };
			return await ((Task<TokenListResponseDto>)requestBuilder.BuildRestResultFuncForMethod("Tokens", ______typeParameters2)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<CreateTokenResponseDto> IUserCardsApi.CreateTokenValidate(CreateTokenRequestDto requestDto, CancellationToken cancellationToken)
		{
			object[] arg = new object[2] { requestDto, cancellationToken };
			return await ((Task<CreateTokenResponseDto>)requestBuilder.BuildRestResultFuncForMethod("CreateTokenValidate", ______typeParameters3)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<DeleteTokenResponseDto> IUserCardsApi.DeleteToken(DeleteTokenRequestDto request, CancellationToken cancellationToken)
		{
			object[] arg = new object[2] { request, cancellationToken };
			return await ((Task<DeleteTokenResponseDto>)requestBuilder.BuildRestResultFuncForMethod("DeleteToken", ______typeParameters4)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	[ExcludeFromCodeCoverage]
	[DebuggerNonUserCode]
	[Preserve]
	[Obfuscation(Exclude = true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	private class AuchanCommonProfileWaitListApiIWaitListApi : IWaitListApi
	{
		private readonly IRequestBuilder requestBuilder;

		private static readonly Type[] ______typeParameters = new Type[3]
		{
			typeof(string),
			typeof(WaitListDtos.AddRequestDto),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters0 = new Type[3]
		{
			typeof(string),
			typeof(WaitListDtos.DeleteRequestDto),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters1 = new Type[3]
		{
			typeof(string),
			typeof(WaitListDtos.WaitListRequestDto),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters2 = new Type[3]
		{
			typeof(string),
			typeof(WaitListDtos.NotificationRequestDto),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters3 = new Type[3]
		{
			typeof(string),
			typeof(WaitListDtos.AddRequestDto),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters4 = new Type[3]
		{
			typeof(string),
			typeof(WaitListDtos.DeleteRequestDto),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters5 = new Type[3]
		{
			typeof(string),
			typeof(WaitListDtos.WaitListRequestDto),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters6 = new Type[3]
		{
			typeof(string),
			typeof(WaitListDtos.NotificationRequestDto),
			typeof(CancellationToken)
		};

		public HttpClient Client { get; }

		public AuchanCommonProfileWaitListApiIWaitListApi(HttpClient client, IRequestBuilder requestBuilder)
		{
			Client = client;
			this.requestBuilder = requestBuilder;
		}

		public async Task<WaitListDtos.AddDto> AddProduct(string cmdToken, WaitListDtos.AddRequestDto body, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { cmdToken, body, cancellationToken };
			return await ((Task<WaitListDtos.AddDto>)requestBuilder.BuildRestResultFuncForMethod("AddProduct", ______typeParameters)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<WaitListDtos.DeleteDto> DeleteProduct(string cmdToken, WaitListDtos.DeleteRequestDto body, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { cmdToken, body, cancellationToken };
			return await ((Task<WaitListDtos.DeleteDto>)requestBuilder.BuildRestResultFuncForMethod("DeleteProduct", ______typeParameters0)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<WaitListDtos.WaitListProductsDto> WaitListProducts(string cmdToken, WaitListDtos.WaitListRequestDto body, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { cmdToken, body, cancellationToken };
			return await ((Task<WaitListDtos.WaitListProductsDto>)requestBuilder.BuildRestResultFuncForMethod("WaitListProducts", ______typeParameters1)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<WaitListDtos.NotificationResponseDto> GetNotification(string cmdToken, WaitListDtos.NotificationRequestDto body, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { cmdToken, body, cancellationToken };
			return await ((Task<WaitListDtos.NotificationResponseDto>)requestBuilder.BuildRestResultFuncForMethod("GetNotification", ______typeParameters2)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<WaitListDtos.AddDto> IWaitListApi.AddProduct(string cmdToken, WaitListDtos.AddRequestDto body, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { cmdToken, body, cancellationToken };
			return await ((Task<WaitListDtos.AddDto>)requestBuilder.BuildRestResultFuncForMethod("AddProduct", ______typeParameters3)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<WaitListDtos.DeleteDto> IWaitListApi.DeleteProduct(string cmdToken, WaitListDtos.DeleteRequestDto body, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { cmdToken, body, cancellationToken };
			return await ((Task<WaitListDtos.DeleteDto>)requestBuilder.BuildRestResultFuncForMethod("DeleteProduct", ______typeParameters4)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<WaitListDtos.WaitListProductsDto> IWaitListApi.WaitListProducts(string cmdToken, WaitListDtos.WaitListRequestDto body, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { cmdToken, body, cancellationToken };
			return await ((Task<WaitListDtos.WaitListProductsDto>)requestBuilder.BuildRestResultFuncForMethod("WaitListProducts", ______typeParameters5)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<WaitListDtos.NotificationResponseDto> IWaitListApi.GetNotification(string cmdToken, WaitListDtos.NotificationRequestDto body, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { cmdToken, body, cancellationToken };
			return await ((Task<WaitListDtos.NotificationResponseDto>)requestBuilder.BuildRestResultFuncForMethod("GetNotification", ______typeParameters6)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	[ExcludeFromCodeCoverage]
	[DebuggerNonUserCode]
	[Preserve]
	[Obfuscation(Exclude = true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	private class AuchanCommonRecommendationsAPIIProductPlacementsApi : IProductPlacementsApi
	{
		private readonly IRequestBuilder requestBuilder;

		private static readonly Type[] ______typeParameters = new Type[2]
		{
			typeof(PlacementId),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters0 = new Type[3]
		{
			typeof(PlacementId),
			typeof(IReadOnlyList<long>),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters1 = new Type[3]
		{
			typeof(PlacementId),
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters2 = new Type[3]
		{
			typeof(PlacementId),
			typeof(long),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters3 = new Type[2]
		{
			typeof(PlacementId),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters4 = new Type[3]
		{
			typeof(PlacementId),
			typeof(IReadOnlyList<long>),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters5 = new Type[3]
		{
			typeof(PlacementId),
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters6 = new Type[3]
		{
			typeof(PlacementId),
			typeof(long),
			typeof(CancellationToken)
		};

		public HttpClient Client { get; }

		public AuchanCommonRecommendationsAPIIProductPlacementsApi(HttpClient client, IRequestBuilder requestBuilder)
		{
			Client = client;
			this.requestBuilder = requestBuilder;
		}

		public async Task<HttpResponseMessage> GetAnyPlacementsAsync(PlacementId placementId, CancellationToken cancellationToken)
		{
			object[] arg = new object[2] { placementId, cancellationToken };
			return await ((Task<HttpResponseMessage>)requestBuilder.BuildRestResultFuncForMethod("GetAnyPlacementsAsync", ______typeParameters)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<HttpResponseMessage> GetProductGroupPlacementsAsync(PlacementId placementId, IReadOnlyList<long> productGimaIdsInTheCart, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { placementId, productGimaIdsInTheCart, cancellationToken };
			return await ((Task<HttpResponseMessage>)requestBuilder.BuildRestResultFuncForMethod("GetProductGroupPlacementsAsync", ______typeParameters0)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<HttpResponseMessage> GetCategoryPlacementsAsync(PlacementId placementId, string categoryPath, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { placementId, categoryPath, cancellationToken };
			return await ((Task<HttpResponseMessage>)requestBuilder.BuildRestResultFuncForMethod("GetCategoryPlacementsAsync", ______typeParameters1)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<HttpResponseMessage> GetProductPlacementsAsync(PlacementId placementId, long productGimaId, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { placementId, productGimaId, cancellationToken };
			return await ((Task<HttpResponseMessage>)requestBuilder.BuildRestResultFuncForMethod("GetProductPlacementsAsync", ______typeParameters2)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<HttpResponseMessage> IProductPlacementsApi.GetAnyPlacementsAsync(PlacementId placementId, CancellationToken cancellationToken)
		{
			object[] arg = new object[2] { placementId, cancellationToken };
			return await ((Task<HttpResponseMessage>)requestBuilder.BuildRestResultFuncForMethod("GetAnyPlacementsAsync", ______typeParameters3)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<HttpResponseMessage> IProductPlacementsApi.GetProductGroupPlacementsAsync(PlacementId placementId, IReadOnlyList<long> productGimaIdsInTheCart, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { placementId, productGimaIdsInTheCart, cancellationToken };
			return await ((Task<HttpResponseMessage>)requestBuilder.BuildRestResultFuncForMethod("GetProductGroupPlacementsAsync", ______typeParameters4)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<HttpResponseMessage> IProductPlacementsApi.GetCategoryPlacementsAsync(PlacementId placementId, string categoryPath, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { placementId, categoryPath, cancellationToken };
			return await ((Task<HttpResponseMessage>)requestBuilder.BuildRestResultFuncForMethod("GetCategoryPlacementsAsync", ______typeParameters5)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<HttpResponseMessage> IProductPlacementsApi.GetProductPlacementsAsync(PlacementId placementId, long productGimaId, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { placementId, productGimaId, cancellationToken };
			return await ((Task<HttpResponseMessage>)requestBuilder.BuildRestResultFuncForMethod("GetProductPlacementsAsync", ______typeParameters6)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	[ExcludeFromCodeCoverage]
	[DebuggerNonUserCode]
	[Preserve]
	[Obfuscation(Exclude = true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	private class AuchanCommonRecommendationsAPIIProductPostApi : IProductPostApi
	{
		private readonly IRequestBuilder requestBuilder;

		private static readonly Type[] ______typeParameters = new Type[4]
		{
			typeof(ProductPostRequest),
			typeof(string),
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters0 = new Type[4]
		{
			typeof(ProductPostRequest),
			typeof(string),
			typeof(string),
			typeof(CancellationToken)
		};

		public HttpClient Client { get; }

		public AuchanCommonRecommendationsAPIIProductPostApi(HttpClient client, IRequestBuilder requestBuilder)
		{
			Client = client;
			this.requestBuilder = requestBuilder;
		}

		public async Task<HttpResponseMessage> ProductPost(ProductPostRequest request, string apiKey, string gimaId, CancellationToken token)
		{
			object[] arg = new object[4] { request, apiKey, gimaId, token };
			return await ((Task<HttpResponseMessage>)requestBuilder.BuildRestResultFuncForMethod("ProductPost", ______typeParameters)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<HttpResponseMessage> IProductPostApi.ProductPost(ProductPostRequest request, string apiKey, string gimaId, CancellationToken token)
		{
			object[] arg = new object[4] { request, apiKey, gimaId, token };
			return await ((Task<HttpResponseMessage>)requestBuilder.BuildRestResultFuncForMethod("ProductPost", ______typeParameters0)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	[ExcludeFromCodeCoverage]
	[DebuggerNonUserCode]
	[Preserve]
	[Obfuscation(Exclude = true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	private class AuchanCommonRecommendationsAPIIRecommendationApi : IRecommendationApi
	{
		private readonly IRequestBuilder requestBuilder;

		private static readonly Type[] ______typeParameters = new Type[1] { typeof(CancellationToken) };

		private static readonly Type[] ______typeParameters0 = new Type[2]
		{
			typeof(IReadOnlyList<string>),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters1 = new Type[1] { typeof(CancellationToken) };

		private static readonly Type[] ______typeParameters2 = new Type[1] { typeof(CancellationToken) };

		private static readonly Type[] ______typeParameters3 = new Type[1] { typeof(CancellationToken) };

		private static readonly Type[] ______typeParameters4 = new Type[2]
		{
			typeof(IReadOnlyList<string>),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters5 = new Type[2]
		{
			typeof(IReadOnlyList<string>),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters6 = new Type[2]
		{
			typeof(IReadOnlyList<string>),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters7 = new Type[2]
		{
			typeof(IReadOnlyList<string>),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters8 = new Type[2]
		{
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters9 = new Type[1] { typeof(CancellationToken) };

		private static readonly Type[] ______typeParameters10 = new Type[2]
		{
			typeof(IReadOnlyList<string>),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters11 = new Type[2]
		{
			typeof(IReadOnlyList<string>),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters12 = new Type[2]
		{
			typeof(IReadOnlyList<string>),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters13 = new Type[2]
		{
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters14 = new Type[2]
		{
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters15 = new Type[2]
		{
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters16 = new Type[1] { typeof(CancellationToken) };

		private static readonly Type[] ______typeParameters17 = new Type[2]
		{
			typeof(IReadOnlyList<string>),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters18 = new Type[1] { typeof(CancellationToken) };

		private static readonly Type[] ______typeParameters19 = new Type[1] { typeof(CancellationToken) };

		private static readonly Type[] ______typeParameters20 = new Type[1] { typeof(CancellationToken) };

		private static readonly Type[] ______typeParameters21 = new Type[2]
		{
			typeof(IReadOnlyList<string>),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters22 = new Type[2]
		{
			typeof(IReadOnlyList<string>),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters23 = new Type[2]
		{
			typeof(IReadOnlyList<string>),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters24 = new Type[2]
		{
			typeof(IReadOnlyList<string>),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters25 = new Type[2]
		{
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters26 = new Type[1] { typeof(CancellationToken) };

		private static readonly Type[] ______typeParameters27 = new Type[2]
		{
			typeof(IReadOnlyList<string>),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters28 = new Type[2]
		{
			typeof(IReadOnlyList<string>),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters29 = new Type[2]
		{
			typeof(IReadOnlyList<string>),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters30 = new Type[2]
		{
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters31 = new Type[2]
		{
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters32 = new Type[2]
		{
			typeof(string),
			typeof(CancellationToken)
		};

		public HttpClient Client { get; }

		public AuchanCommonRecommendationsAPIIRecommendationApi(HttpClient client, IRequestBuilder requestBuilder)
		{
			Client = client;
			this.requestBuilder = requestBuilder;
		}

		public async Task<HttpResponseMessage> PersonalRecommendations(CancellationToken token)
		{
			object[] arg = new object[1] { token };
			return await ((Task<HttpResponseMessage>)requestBuilder.BuildRestResultFuncForMethod("PersonalRecommendations", ______typeParameters)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<HttpResponseMessage> LatestByCategoryPath(IReadOnlyList<string> categoryPaths, CancellationToken token)
		{
			object[] arg = new object[2] { categoryPaths, token };
			return await ((Task<HttpResponseMessage>)requestBuilder.BuildRestResultFuncForMethod("LatestByCategoryPath", ______typeParameters0)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<HttpResponseMessage> LatestInInterestedCategories(CancellationToken token)
		{
			object[] arg = new object[1] { token };
			return await ((Task<HttpResponseMessage>)requestBuilder.BuildRestResultFuncForMethod("LatestInInterestedCategories", ______typeParameters1)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<HttpResponseMessage> PersonalViewed(CancellationToken token)
		{
			object[] arg = new object[1] { token };
			return await ((Task<HttpResponseMessage>)requestBuilder.BuildRestResultFuncForMethod("PersonalViewed", ______typeParameters2)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<HttpResponseMessage> PersonalOrdered(CancellationToken token)
		{
			object[] arg = new object[1] { token };
			return await ((Task<HttpResponseMessage>)requestBuilder.BuildRestResultFuncForMethod("PersonalOrdered", ______typeParameters3)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<HttpResponseMessage> Related(IReadOnlyList<string> productIds, CancellationToken token)
		{
			object[] arg = new object[2] { productIds, token };
			return await ((Task<HttpResponseMessage>)requestBuilder.BuildRestResultFuncForMethod("Related", ______typeParameters4)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<HttpResponseMessage> CrossSellForLargeBaskets(IReadOnlyList<string> productIds, CancellationToken token)
		{
			object[] arg = new object[2] { productIds, token };
			return await ((Task<HttpResponseMessage>)requestBuilder.BuildRestResultFuncForMethod("CrossSellForLargeBaskets", ______typeParameters5)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<HttpResponseMessage> Alternatives(IReadOnlyList<string> productIds, CancellationToken token)
		{
			object[] arg = new object[2] { productIds, token };
			return await ((Task<HttpResponseMessage>)requestBuilder.BuildRestResultFuncForMethod("Alternatives", ______typeParameters6)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<HttpResponseMessage> AnalogsOutOfStockProducts(IReadOnlyList<string> productIds, CancellationToken token)
		{
			object[] arg = new object[2] { productIds, token };
			return await ((Task<HttpResponseMessage>)requestBuilder.BuildRestResultFuncForMethod("AnalogsOutOfStockProducts", ______typeParameters7)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<HttpResponseMessage> SortItemsInCategory(string categoryId, CancellationToken token)
		{
			object[] arg = new object[2] { categoryId, token };
			return await ((Task<HttpResponseMessage>)requestBuilder.BuildRestResultFuncForMethod("SortItemsInCategory", ______typeParameters8)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<HttpResponseMessage> PopularInInterestedCategories(CancellationToken token)
		{
			object[] arg = new object[1] { token };
			return await ((Task<HttpResponseMessage>)requestBuilder.BuildRestResultFuncForMethod("PopularInInterestedCategories", ______typeParameters9)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<HttpResponseMessage> PopularInCategory(IReadOnlyList<string> categoryIds, CancellationToken token)
		{
			object[] arg = new object[2] { categoryIds, token };
			return await ((Task<HttpResponseMessage>)requestBuilder.BuildRestResultFuncForMethod("PopularInCategory", ______typeParameters10)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<HttpResponseMessage> PopularInCategoryByPath(IReadOnlyList<string> categoryPaths, CancellationToken token)
		{
			object[] arg = new object[2] { categoryPaths, token };
			return await ((Task<HttpResponseMessage>)requestBuilder.BuildRestResultFuncForMethod("PopularInCategoryByPath", ______typeParameters11)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<HttpResponseMessage> SaleByPopularInCategoryByPath(IReadOnlyList<string> categoryPaths, CancellationToken token)
		{
			object[] arg = new object[2] { categoryPaths, token };
			return await ((Task<HttpResponseMessage>)requestBuilder.BuildRestResultFuncForMethod("SaleByPopularInCategoryByPath", ______typeParameters12)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<HttpResponseMessage> Search(string searchPhrase, CancellationToken token)
		{
			object[] arg = new object[2] { searchPhrase, token };
			return await ((Task<HttpResponseMessage>)requestBuilder.BuildRestResultFuncForMethod("Search", ______typeParameters13)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<HttpResponseMessage> PersonalCompositeForCategoryByCategoryPath(string categoryPaths, CancellationToken token)
		{
			object[] arg = new object[2] { categoryPaths, token };
			return await ((Task<HttpResponseMessage>)requestBuilder.BuildRestResultFuncForMethod("PersonalCompositeForCategoryByCategoryPath", ______typeParameters14)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<HttpResponseMessage> PopularByInterestedPropertiesByCategoryPath(string categoryPaths, CancellationToken token)
		{
			object[] arg = new object[2] { categoryPaths, token };
			return await ((Task<HttpResponseMessage>)requestBuilder.BuildRestResultFuncForMethod("PopularByInterestedPropertiesByCategoryPath", ______typeParameters15)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<HttpResponseMessage> IRecommendationApi.PersonalRecommendations(CancellationToken token)
		{
			object[] arg = new object[1] { token };
			return await ((Task<HttpResponseMessage>)requestBuilder.BuildRestResultFuncForMethod("PersonalRecommendations", ______typeParameters16)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<HttpResponseMessage> IRecommendationApi.LatestByCategoryPath(IReadOnlyList<string> categoryPaths, CancellationToken token)
		{
			object[] arg = new object[2] { categoryPaths, token };
			return await ((Task<HttpResponseMessage>)requestBuilder.BuildRestResultFuncForMethod("LatestByCategoryPath", ______typeParameters17)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<HttpResponseMessage> IRecommendationApi.LatestInInterestedCategories(CancellationToken token)
		{
			object[] arg = new object[1] { token };
			return await ((Task<HttpResponseMessage>)requestBuilder.BuildRestResultFuncForMethod("LatestInInterestedCategories", ______typeParameters18)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<HttpResponseMessage> IRecommendationApi.PersonalViewed(CancellationToken token)
		{
			object[] arg = new object[1] { token };
			return await ((Task<HttpResponseMessage>)requestBuilder.BuildRestResultFuncForMethod("PersonalViewed", ______typeParameters19)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<HttpResponseMessage> IRecommendationApi.PersonalOrdered(CancellationToken token)
		{
			object[] arg = new object[1] { token };
			return await ((Task<HttpResponseMessage>)requestBuilder.BuildRestResultFuncForMethod("PersonalOrdered", ______typeParameters20)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<HttpResponseMessage> IRecommendationApi.Related(IReadOnlyList<string> productIds, CancellationToken token)
		{
			object[] arg = new object[2] { productIds, token };
			return await ((Task<HttpResponseMessage>)requestBuilder.BuildRestResultFuncForMethod("Related", ______typeParameters21)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<HttpResponseMessage> IRecommendationApi.CrossSellForLargeBaskets(IReadOnlyList<string> productIds, CancellationToken token)
		{
			object[] arg = new object[2] { productIds, token };
			return await ((Task<HttpResponseMessage>)requestBuilder.BuildRestResultFuncForMethod("CrossSellForLargeBaskets", ______typeParameters22)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<HttpResponseMessage> IRecommendationApi.Alternatives(IReadOnlyList<string> productIds, CancellationToken token)
		{
			object[] arg = new object[2] { productIds, token };
			return await ((Task<HttpResponseMessage>)requestBuilder.BuildRestResultFuncForMethod("Alternatives", ______typeParameters23)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<HttpResponseMessage> IRecommendationApi.AnalogsOutOfStockProducts(IReadOnlyList<string> productIds, CancellationToken token)
		{
			object[] arg = new object[2] { productIds, token };
			return await ((Task<HttpResponseMessage>)requestBuilder.BuildRestResultFuncForMethod("AnalogsOutOfStockProducts", ______typeParameters24)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<HttpResponseMessage> IRecommendationApi.SortItemsInCategory(string categoryId, CancellationToken token)
		{
			object[] arg = new object[2] { categoryId, token };
			return await ((Task<HttpResponseMessage>)requestBuilder.BuildRestResultFuncForMethod("SortItemsInCategory", ______typeParameters25)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<HttpResponseMessage> IRecommendationApi.PopularInInterestedCategories(CancellationToken token)
		{
			object[] arg = new object[1] { token };
			return await ((Task<HttpResponseMessage>)requestBuilder.BuildRestResultFuncForMethod("PopularInInterestedCategories", ______typeParameters26)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<HttpResponseMessage> IRecommendationApi.PopularInCategory(IReadOnlyList<string> categoryIds, CancellationToken token)
		{
			object[] arg = new object[2] { categoryIds, token };
			return await ((Task<HttpResponseMessage>)requestBuilder.BuildRestResultFuncForMethod("PopularInCategory", ______typeParameters27)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<HttpResponseMessage> IRecommendationApi.PopularInCategoryByPath(IReadOnlyList<string> categoryPaths, CancellationToken token)
		{
			object[] arg = new object[2] { categoryPaths, token };
			return await ((Task<HttpResponseMessage>)requestBuilder.BuildRestResultFuncForMethod("PopularInCategoryByPath", ______typeParameters28)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<HttpResponseMessage> IRecommendationApi.SaleByPopularInCategoryByPath(IReadOnlyList<string> categoryPaths, CancellationToken token)
		{
			object[] arg = new object[2] { categoryPaths, token };
			return await ((Task<HttpResponseMessage>)requestBuilder.BuildRestResultFuncForMethod("SaleByPopularInCategoryByPath", ______typeParameters29)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<HttpResponseMessage> IRecommendationApi.Search(string searchPhrase, CancellationToken token)
		{
			object[] arg = new object[2] { searchPhrase, token };
			return await ((Task<HttpResponseMessage>)requestBuilder.BuildRestResultFuncForMethod("Search", ______typeParameters30)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<HttpResponseMessage> IRecommendationApi.PersonalCompositeForCategoryByCategoryPath(string categoryPaths, CancellationToken token)
		{
			object[] arg = new object[2] { categoryPaths, token };
			return await ((Task<HttpResponseMessage>)requestBuilder.BuildRestResultFuncForMethod("PersonalCompositeForCategoryByCategoryPath", ______typeParameters31)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<HttpResponseMessage> IRecommendationApi.PopularByInterestedPropertiesByCategoryPath(string categoryPaths, CancellationToken token)
		{
			object[] arg = new object[2] { categoryPaths, token };
			return await ((Task<HttpResponseMessage>)requestBuilder.BuildRestResultFuncForMethod("PopularByInterestedPropertiesByCategoryPath", ______typeParameters32)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	[ExcludeFromCodeCoverage]
	[DebuggerNonUserCode]
	[Preserve]
	[Obfuscation(Exclude = true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	private class AuchanCommonRecommendationsAPIITrackingApi : ITrackingApi
	{
		private readonly IRequestBuilder requestBuilder;

		private static readonly Type[] ______typeParameters = new Type[2]
		{
			typeof(ProductTrackingRequest),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters0 = new Type[2]
		{
			typeof(ProductTrackingRequest),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters1 = new Type[2]
		{
			typeof(OrderTrackingRequest),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters2 = new Type[2]
		{
			typeof(CategoryViewTrackingRequest),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters3 = new Type[2]
		{
			typeof(CategoryViewByPathTrackingRequest),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters4 = new Type[2]
		{
			typeof(SearchTrackingRequest),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters5 = new Type[2]
		{
			typeof(IList<BatchItemRequest>),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters6 = new Type[2]
		{
			typeof(RecomItemInteractionRequest),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters7 = new Type[2]
		{
			typeof(RecomItemInteractionRequest),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters8 = new Type[2]
		{
			typeof(RecomBlockViewedRequest),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters9 = new Type[2]
		{
			typeof(CustomerInfoRequest),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters10 = new Type[2]
		{
			typeof(ProductPlacementTrackingRequest),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters11 = new Type[2]
		{
			typeof(ProductPlacementTrackingRequest),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters12 = new Type[2]
		{
			typeof(ProductTrackingRequest),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters13 = new Type[2]
		{
			typeof(ProductTrackingRequest),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters14 = new Type[2]
		{
			typeof(OrderTrackingRequest),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters15 = new Type[2]
		{
			typeof(CategoryViewTrackingRequest),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters16 = new Type[2]
		{
			typeof(CategoryViewByPathTrackingRequest),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters17 = new Type[2]
		{
			typeof(SearchTrackingRequest),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters18 = new Type[2]
		{
			typeof(IList<BatchItemRequest>),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters19 = new Type[2]
		{
			typeof(RecomItemInteractionRequest),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters20 = new Type[2]
		{
			typeof(RecomItemInteractionRequest),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters21 = new Type[2]
		{
			typeof(RecomBlockViewedRequest),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters22 = new Type[2]
		{
			typeof(CustomerInfoRequest),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters23 = new Type[2]
		{
			typeof(ProductPlacementTrackingRequest),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters24 = new Type[2]
		{
			typeof(ProductPlacementTrackingRequest),
			typeof(CancellationToken)
		};

		public HttpClient Client { get; }

		public AuchanCommonRecommendationsAPIITrackingApi(HttpClient client, IRequestBuilder requestBuilder)
		{
			Client = client;
			this.requestBuilder = requestBuilder;
		}

		public async Task<HttpResponseMessage> ViewProduct(ProductTrackingRequest request, CancellationToken token)
		{
			object[] arg = new object[2] { request, token };
			return await ((Task<HttpResponseMessage>)requestBuilder.BuildRestResultFuncForMethod("ViewProduct", ______typeParameters)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<HttpResponseMessage> AddToCart(ProductTrackingRequest request, CancellationToken token)
		{
			object[] arg = new object[2] { request, token };
			return await ((Task<HttpResponseMessage>)requestBuilder.BuildRestResultFuncForMethod("AddToCart", ______typeParameters0)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<HttpResponseMessage> Order(OrderTrackingRequest request, CancellationToken token)
		{
			object[] arg = new object[2] { request, token };
			return await ((Task<HttpResponseMessage>)requestBuilder.BuildRestResultFuncForMethod("Order", ______typeParameters1)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<HttpResponseMessage> ViewCategory(CategoryViewTrackingRequest request, CancellationToken token)
		{
			object[] arg = new object[2] { request, token };
			return await ((Task<HttpResponseMessage>)requestBuilder.BuildRestResultFuncForMethod("ViewCategory", ______typeParameters2)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<HttpResponseMessage> ViewCategoryByPath(CategoryViewByPathTrackingRequest request, CancellationToken token)
		{
			object[] arg = new object[2] { request, token };
			return await ((Task<HttpResponseMessage>)requestBuilder.BuildRestResultFuncForMethod("ViewCategoryByPath", ______typeParameters3)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<HttpResponseMessage> Search(SearchTrackingRequest request, CancellationToken token)
		{
			object[] arg = new object[2] { request, token };
			return await ((Task<HttpResponseMessage>)requestBuilder.BuildRestResultFuncForMethod("Search", ______typeParameters4)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<HttpResponseMessage> BatchUpload(IList<BatchItemRequest> body, CancellationToken token)
		{
			object[] arg = new object[2] { body, token };
			return await ((Task<HttpResponseMessage>)requestBuilder.BuildRestResultFuncForMethod("BatchUpload", ______typeParameters5)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<HttpResponseMessage> RecommendationTap(RecomItemInteractionRequest body, CancellationToken token)
		{
			object[] arg = new object[2] { body, token };
			return await ((Task<HttpResponseMessage>)requestBuilder.BuildRestResultFuncForMethod("RecommendationTap", ______typeParameters6)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<HttpResponseMessage> RecommendationAddedToBasket(RecomItemInteractionRequest body, CancellationToken token)
		{
			object[] arg = new object[2] { body, token };
			return await ((Task<HttpResponseMessage>)requestBuilder.BuildRestResultFuncForMethod("RecommendationAddedToBasket", ______typeParameters7)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<HttpResponseMessage> RecommendationBlockViewed(RecomBlockViewedRequest body, CancellationToken token)
		{
			object[] arg = new object[2] { body, token };
			return await ((Task<HttpResponseMessage>)requestBuilder.BuildRestResultFuncForMethod("RecommendationBlockViewed", ______typeParameters8)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<HttpResponseMessage> SetCustomer(CustomerInfoRequest customerInfo, CancellationToken token)
		{
			object[] arg = new object[2] { customerInfo, token };
			return await ((Task<HttpResponseMessage>)requestBuilder.BuildRestResultFuncForMethod("SetCustomer", ______typeParameters9)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<HttpResponseMessage> ProductPlacementViewed(ProductPlacementTrackingRequest body, CancellationToken cancellationToken)
		{
			object[] arg = new object[2] { body, cancellationToken };
			return await ((Task<HttpResponseMessage>)requestBuilder.BuildRestResultFuncForMethod("ProductPlacementViewed", ______typeParameters10)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<HttpResponseMessage> ProductPlacementClicked(ProductPlacementTrackingRequest body, CancellationToken cancellationToken)
		{
			object[] arg = new object[2] { body, cancellationToken };
			return await ((Task<HttpResponseMessage>)requestBuilder.BuildRestResultFuncForMethod("ProductPlacementClicked", ______typeParameters11)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<HttpResponseMessage> ITrackingApi.ViewProduct(ProductTrackingRequest request, CancellationToken token)
		{
			object[] arg = new object[2] { request, token };
			return await ((Task<HttpResponseMessage>)requestBuilder.BuildRestResultFuncForMethod("ViewProduct", ______typeParameters12)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<HttpResponseMessage> ITrackingApi.AddToCart(ProductTrackingRequest request, CancellationToken token)
		{
			object[] arg = new object[2] { request, token };
			return await ((Task<HttpResponseMessage>)requestBuilder.BuildRestResultFuncForMethod("AddToCart", ______typeParameters13)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<HttpResponseMessage> ITrackingApi.Order(OrderTrackingRequest request, CancellationToken token)
		{
			object[] arg = new object[2] { request, token };
			return await ((Task<HttpResponseMessage>)requestBuilder.BuildRestResultFuncForMethod("Order", ______typeParameters14)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<HttpResponseMessage> ITrackingApi.ViewCategory(CategoryViewTrackingRequest request, CancellationToken token)
		{
			object[] arg = new object[2] { request, token };
			return await ((Task<HttpResponseMessage>)requestBuilder.BuildRestResultFuncForMethod("ViewCategory", ______typeParameters15)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<HttpResponseMessage> ITrackingApi.ViewCategoryByPath(CategoryViewByPathTrackingRequest request, CancellationToken token)
		{
			object[] arg = new object[2] { request, token };
			return await ((Task<HttpResponseMessage>)requestBuilder.BuildRestResultFuncForMethod("ViewCategoryByPath", ______typeParameters16)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<HttpResponseMessage> ITrackingApi.Search(SearchTrackingRequest request, CancellationToken token)
		{
			object[] arg = new object[2] { request, token };
			return await ((Task<HttpResponseMessage>)requestBuilder.BuildRestResultFuncForMethod("Search", ______typeParameters17)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<HttpResponseMessage> ITrackingApi.BatchUpload(IList<BatchItemRequest> body, CancellationToken token)
		{
			object[] arg = new object[2] { body, token };
			return await ((Task<HttpResponseMessage>)requestBuilder.BuildRestResultFuncForMethod("BatchUpload", ______typeParameters18)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<HttpResponseMessage> ITrackingApi.RecommendationTap(RecomItemInteractionRequest body, CancellationToken token)
		{
			object[] arg = new object[2] { body, token };
			return await ((Task<HttpResponseMessage>)requestBuilder.BuildRestResultFuncForMethod("RecommendationTap", ______typeParameters19)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<HttpResponseMessage> ITrackingApi.RecommendationAddedToBasket(RecomItemInteractionRequest body, CancellationToken token)
		{
			object[] arg = new object[2] { body, token };
			return await ((Task<HttpResponseMessage>)requestBuilder.BuildRestResultFuncForMethod("RecommendationAddedToBasket", ______typeParameters20)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<HttpResponseMessage> ITrackingApi.RecommendationBlockViewed(RecomBlockViewedRequest body, CancellationToken token)
		{
			object[] arg = new object[2] { body, token };
			return await ((Task<HttpResponseMessage>)requestBuilder.BuildRestResultFuncForMethod("RecommendationBlockViewed", ______typeParameters21)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<HttpResponseMessage> ITrackingApi.SetCustomer(CustomerInfoRequest customerInfo, CancellationToken token)
		{
			object[] arg = new object[2] { customerInfo, token };
			return await ((Task<HttpResponseMessage>)requestBuilder.BuildRestResultFuncForMethod("SetCustomer", ______typeParameters22)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<HttpResponseMessage> ITrackingApi.ProductPlacementViewed(ProductPlacementTrackingRequest body, CancellationToken cancellationToken)
		{
			object[] arg = new object[2] { body, cancellationToken };
			return await ((Task<HttpResponseMessage>)requestBuilder.BuildRestResultFuncForMethod("ProductPlacementViewed", ______typeParameters23)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<HttpResponseMessage> ITrackingApi.ProductPlacementClicked(ProductPlacementTrackingRequest body, CancellationToken cancellationToken)
		{
			object[] arg = new object[2] { body, cancellationToken };
			return await ((Task<HttpResponseMessage>)requestBuilder.BuildRestResultFuncForMethod("ProductPlacementClicked", ______typeParameters24)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	[ExcludeFromCodeCoverage]
	[DebuggerNonUserCode]
	[Preserve]
	[Obfuscation(Exclude = true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	private class AuchanCommonReviewsIReviewsEcomApi : IReviewsEcomApi
	{
		private readonly IRequestBuilder requestBuilder;

		private static readonly Type[] ______typeParameters = new Type[4]
		{
			typeof(string),
			typeof(int),
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters0 = new Type[3]
		{
			typeof(string),
			typeof(IEnumerable<StreamPart>),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters1 = new Type[3]
		{
			typeof(string),
			typeof(ReviewCreateRequestDto),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters2 = new Type[3]
		{
			typeof(string),
			typeof(int?),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters3 = new Type[2]
		{
			typeof(ReviewsRequestBodyDto),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters4 = new Type[3]
		{
			typeof(string),
			typeof(UnreviewedProductsRequestBodyDto),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters5 = new Type[3]
		{
			typeof(string),
			typeof(ReviewsRequestBodyDto),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters6 = new Type[2]
		{
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters7 = new Type[3]
		{
			typeof(string),
			typeof(HideFromUnreviewedRequestBodyDto),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters8 = new Type[4]
		{
			typeof(string),
			typeof(int),
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters9 = new Type[3]
		{
			typeof(string),
			typeof(IEnumerable<StreamPart>),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters10 = new Type[3]
		{
			typeof(string),
			typeof(ReviewCreateRequestDto),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters11 = new Type[3]
		{
			typeof(string),
			typeof(int?),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters12 = new Type[2]
		{
			typeof(ReviewsRequestBodyDto),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters13 = new Type[3]
		{
			typeof(string),
			typeof(UnreviewedProductsRequestBodyDto),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters14 = new Type[3]
		{
			typeof(string),
			typeof(ReviewsRequestBodyDto),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters15 = new Type[2]
		{
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters16 = new Type[3]
		{
			typeof(string),
			typeof(HideFromUnreviewedRequestBodyDto),
			typeof(CancellationToken)
		};

		public HttpClient Client { get; }

		public AuchanCommonReviewsIReviewsEcomApi(HttpClient client, IRequestBuilder requestBuilder)
		{
			Client = client;
			this.requestBuilder = requestBuilder;
		}

		public async Task<CheckAddingResponseDto> CheckAdding(string accessToken, int gimaId, string channel, CancellationToken token)
		{
			object[] arg = new object[4] { accessToken, gimaId, channel, token };
			return await ((Task<CheckAddingResponseDto>)requestBuilder.BuildRestResultFuncForMethod("CheckAdding", ______typeParameters)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<UploadImagesResponseDto> UploadImages(string accessToken, IEnumerable<StreamPart> streams, CancellationToken token)
		{
			object[] arg = new object[3] { accessToken, streams, token };
			return await ((Task<UploadImagesResponseDto>)requestBuilder.BuildRestResultFuncForMethod("UploadImages", ______typeParameters0)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<AddReviewResponseDto> Create(string accessToken, ReviewCreateRequestDto body, CancellationToken token)
		{
			object[] arg = new object[3] { accessToken, body, token };
			return await ((Task<AddReviewResponseDto>)requestBuilder.BuildRestResultFuncForMethod("Create", ______typeParameters1)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<ReviewFormSettingsResponseDto> FormSettings(string accessToken, int? gimaId, CancellationToken token)
		{
			object[] arg = new object[3] { accessToken, gimaId, token };
			return await ((Task<ReviewFormSettingsResponseDto>)requestBuilder.BuildRestResultFuncForMethod("FormSettings", ______typeParameters2)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<ReviewsResponseDto> ProductReviews(ReviewsRequestBodyDto data, CancellationToken cancellationToken)
		{
			object[] arg = new object[2] { data, cancellationToken };
			return await ((Task<ReviewsResponseDto>)requestBuilder.BuildRestResultFuncForMethod("ProductReviews", ______typeParameters3)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<UnreviewedProductsResponseDto> Products(string accessToken, UnreviewedProductsRequestBodyDto body, CancellationToken token)
		{
			object[] arg = new object[3] { accessToken, body, token };
			return await ((Task<UnreviewedProductsResponseDto>)requestBuilder.BuildRestResultFuncForMethod("Products", ______typeParameters4)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<ReviewsResponseDto> UserReviews(string accessToken, ReviewsRequestBodyDto data, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { accessToken, data, cancellationToken };
			return await ((Task<ReviewsResponseDto>)requestBuilder.BuildRestResultFuncForMethod("UserReviews", ______typeParameters5)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<ProductsPopupResponseDto> CheckIfPopupNeeded(string accessToken, CancellationToken cancellationToken)
		{
			object[] arg = new object[2] { accessToken, cancellationToken };
			return await ((Task<ProductsPopupResponseDto>)requestBuilder.BuildRestResultFuncForMethod("CheckIfPopupNeeded", ______typeParameters6)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<string> HideProductFromUnreviewed(string accessToken, HideFromUnreviewedRequestBodyDto body, CancellationToken token)
		{
			object[] arg = new object[3] { accessToken, body, token };
			return await ((Task<string>)requestBuilder.BuildRestResultFuncForMethod("HideProductFromUnreviewed", ______typeParameters7)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<CheckAddingResponseDto> IReviewsEcomApi.CheckAdding(string accessToken, int gimaId, string channel, CancellationToken token)
		{
			object[] arg = new object[4] { accessToken, gimaId, channel, token };
			return await ((Task<CheckAddingResponseDto>)requestBuilder.BuildRestResultFuncForMethod("CheckAdding", ______typeParameters8)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<UploadImagesResponseDto> IReviewsEcomApi.UploadImages(string accessToken, IEnumerable<StreamPart> streams, CancellationToken token)
		{
			object[] arg = new object[3] { accessToken, streams, token };
			return await ((Task<UploadImagesResponseDto>)requestBuilder.BuildRestResultFuncForMethod("UploadImages", ______typeParameters9)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<AddReviewResponseDto> IReviewsEcomApi.Create(string accessToken, ReviewCreateRequestDto body, CancellationToken token)
		{
			object[] arg = new object[3] { accessToken, body, token };
			return await ((Task<AddReviewResponseDto>)requestBuilder.BuildRestResultFuncForMethod("Create", ______typeParameters10)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<ReviewFormSettingsResponseDto> IReviewsEcomApi.FormSettings(string accessToken, int? gimaId, CancellationToken token)
		{
			object[] arg = new object[3] { accessToken, gimaId, token };
			return await ((Task<ReviewFormSettingsResponseDto>)requestBuilder.BuildRestResultFuncForMethod("FormSettings", ______typeParameters11)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<ReviewsResponseDto> IReviewsEcomApi.ProductReviews(ReviewsRequestBodyDto data, CancellationToken cancellationToken)
		{
			object[] arg = new object[2] { data, cancellationToken };
			return await ((Task<ReviewsResponseDto>)requestBuilder.BuildRestResultFuncForMethod("ProductReviews", ______typeParameters12)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<UnreviewedProductsResponseDto> IReviewsEcomApi.Products(string accessToken, UnreviewedProductsRequestBodyDto body, CancellationToken token)
		{
			object[] arg = new object[3] { accessToken, body, token };
			return await ((Task<UnreviewedProductsResponseDto>)requestBuilder.BuildRestResultFuncForMethod("Products", ______typeParameters13)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<ReviewsResponseDto> IReviewsEcomApi.UserReviews(string accessToken, ReviewsRequestBodyDto data, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { accessToken, data, cancellationToken };
			return await ((Task<ReviewsResponseDto>)requestBuilder.BuildRestResultFuncForMethod("UserReviews", ______typeParameters14)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<ProductsPopupResponseDto> IReviewsEcomApi.CheckIfPopupNeeded(string accessToken, CancellationToken cancellationToken)
		{
			object[] arg = new object[2] { accessToken, cancellationToken };
			return await ((Task<ProductsPopupResponseDto>)requestBuilder.BuildRestResultFuncForMethod("CheckIfPopupNeeded", ______typeParameters15)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<string> IReviewsEcomApi.HideProductFromUnreviewed(string accessToken, HideFromUnreviewedRequestBodyDto body, CancellationToken token)
		{
			object[] arg = new object[3] { accessToken, body, token };
			return await ((Task<string>)requestBuilder.BuildRestResultFuncForMethod("HideProductFromUnreviewed", ______typeParameters16)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	[ExcludeFromCodeCoverage]
	[DebuggerNonUserCode]
	[Preserve]
	[Obfuscation(Exclude = true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	private class AuchanCommonStoreReviewICustomerFlagApi : ICustomerFlagApi
	{
		private readonly IRequestBuilder requestBuilder;

		private static readonly Type[] ______typeParameters = new Type[2]
		{
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters0 = new Type[3]
		{
			typeof(string),
			typeof(UpdateCustomerFlagsRequestDto),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters1 = new Type[2]
		{
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters2 = new Type[3]
		{
			typeof(string),
			typeof(UpdateCustomerFlagsRequestDto),
			typeof(CancellationToken)
		};

		public HttpClient Client { get; }

		public AuchanCommonStoreReviewICustomerFlagApi(HttpClient client, IRequestBuilder requestBuilder)
		{
			Client = client;
			this.requestBuilder = requestBuilder;
		}

		public async Task<CustomerFlagsResponseDto> GetCustomerFlags(string token80, CancellationToken cancellationToken)
		{
			object[] arg = new object[2] { token80, cancellationToken };
			return await ((Task<CustomerFlagsResponseDto>)requestBuilder.BuildRestResultFuncForMethod("GetCustomerFlags", ______typeParameters)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<CustomerFlagsResponseDto> UpdateCustomerFlags(string token80, UpdateCustomerFlagsRequestDto request, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { token80, request, cancellationToken };
			return await ((Task<CustomerFlagsResponseDto>)requestBuilder.BuildRestResultFuncForMethod("UpdateCustomerFlags", ______typeParameters0)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<CustomerFlagsResponseDto> ICustomerFlagApi.GetCustomerFlags(string token80, CancellationToken cancellationToken)
		{
			object[] arg = new object[2] { token80, cancellationToken };
			return await ((Task<CustomerFlagsResponseDto>)requestBuilder.BuildRestResultFuncForMethod("GetCustomerFlags", ______typeParameters1)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<CustomerFlagsResponseDto> ICustomerFlagApi.UpdateCustomerFlags(string token80, UpdateCustomerFlagsRequestDto request, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { token80, request, cancellationToken };
			return await ((Task<CustomerFlagsResponseDto>)requestBuilder.BuildRestResultFuncForMethod("UpdateCustomerFlags", ______typeParameters2)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	[ExcludeFromCodeCoverage]
	[DebuggerNonUserCode]
	[Preserve]
	[Obfuscation(Exclude = true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	private class AuchanCommonStreamsIStreamApi : IStreamApi
	{
		private readonly IRequestBuilder requestBuilder;

		private static readonly Type[] ______typeParameters = new Type[2]
		{
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters0 = new Type[2]
		{
			typeof(string),
			typeof(CancellationToken)
		};

		public HttpClient Client { get; }

		public AuchanCommonStreamsIStreamApi(HttpClient client, IRequestBuilder requestBuilder)
		{
			Client = client;
			this.requestBuilder = requestBuilder;
		}

		public async Task<StreamsDtos.StreamBlockDto> GetStreams(string applicationId, CancellationToken cancellationToken)
		{
			object[] arg = new object[2] { applicationId, cancellationToken };
			return await ((Task<StreamsDtos.StreamBlockDto>)requestBuilder.BuildRestResultFuncForMethod("GetStreams", ______typeParameters)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<StreamsDtos.StreamBlockDto> IStreamApi.GetStreams(string applicationId, CancellationToken cancellationToken)
		{
			object[] arg = new object[2] { applicationId, cancellationToken };
			return await ((Task<StreamsDtos.StreamBlockDto>)requestBuilder.BuildRestResultFuncForMethod("GetStreams", ______typeParameters0)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	[ExcludeFromCodeCoverage]
	[DebuggerNonUserCode]
	[Preserve]
	[Obfuscation(Exclude = true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	private class AuchanCommonSupportChatIBeesenderFileServiseAPI : IBeesenderFileServiseAPI
	{
		private readonly IRequestBuilder requestBuilder;

		private static readonly Type[] ______typeParameters = new Type[4]
		{
			typeof(string),
			typeof(string),
			typeof(StreamPart),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters0 = new Type[4]
		{
			typeof(string),
			typeof(string),
			typeof(StreamPart),
			typeof(CancellationToken)
		};

		public HttpClient Client { get; }

		public AuchanCommonSupportChatIBeesenderFileServiseAPI(HttpClient client, IRequestBuilder requestBuilder)
		{
			Client = client;
			this.requestBuilder = requestBuilder;
		}

		public async Task<UploadFileResponseDTO> SendFileAsync(string name, string fileName, StreamPart file, CancellationToken cancellationToken)
		{
			object[] arg = new object[4] { name, fileName, file, cancellationToken };
			return await ((Task<UploadFileResponseDTO>)requestBuilder.BuildRestResultFuncForMethod("SendFileAsync", ______typeParameters)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<UploadFileResponseDTO> IBeesenderFileServiseAPI.SendFileAsync(string name, string fileName, StreamPart file, CancellationToken cancellationToken)
		{
			object[] arg = new object[4] { name, fileName, file, cancellationToken };
			return await ((Task<UploadFileResponseDTO>)requestBuilder.BuildRestResultFuncForMethod("SendFileAsync", ______typeParameters0)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	[ExcludeFromCodeCoverage]
	[DebuggerNonUserCode]
	[Preserve]
	[Obfuscation(Exclude = true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	private class AuchanCommonSupportChatIChatSettingsApi : IChatSettingsApi
	{
		private readonly IRequestBuilder requestBuilder;

		private static readonly Type[] ______typeParameters = new Type[1] { typeof(CancellationToken) };

		private static readonly Type[] ______typeParameters0 = new Type[1] { typeof(CancellationToken) };

		public HttpClient Client { get; }

		public AuchanCommonSupportChatIChatSettingsApi(HttpClient client, IRequestBuilder requestBuilder)
		{
			Client = client;
			this.requestBuilder = requestBuilder;
		}

		public async Task<ChatConfigurationResponseDto> GetTestSettings(CancellationToken cancellationToken)
		{
			object[] arg = new object[1] { cancellationToken };
			return await ((Task<ChatConfigurationResponseDto>)requestBuilder.BuildRestResultFuncForMethod("GetTestSettings", ______typeParameters)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<ChatConfigurationResponseDto> IChatSettingsApi.GetTestSettings(CancellationToken cancellationToken)
		{
			object[] arg = new object[1] { cancellationToken };
			return await ((Task<ChatConfigurationResponseDto>)requestBuilder.BuildRestResultFuncForMethod("GetTestSettings", ______typeParameters0)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	[ExcludeFromCodeCoverage]
	[DebuggerNonUserCode]
	[Preserve]
	[Obfuscation(Exclude = true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	private class AuchanCommonSupportChatISupportChatAPI : ISupportChatAPI
	{
		private readonly IRequestBuilder requestBuilder;

		private static readonly Type[] ______typeParameters = new Type[3]
		{
			typeof(string),
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters0 = new Type[3]
		{
			typeof(string),
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters1 = new Type[3]
		{
			typeof(string),
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters2 = new Type[3]
		{
			typeof(string),
			typeof(string),
			typeof(CancellationToken)
		};

		public HttpClient Client { get; }

		public AuchanCommonSupportChatISupportChatAPI(HttpClient client, IRequestBuilder requestBuilder)
		{
			Client = client;
			this.requestBuilder = requestBuilder;
		}

		public async Task<MessageCountResponseDTO> GetMessageCount(string cmdId, string token80, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { cmdId, token80, cancellationToken };
			return await ((Task<MessageCountResponseDTO>)requestBuilder.BuildRestResultFuncForMethod("GetMessageCount", ______typeParameters)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<ChatStatusResponseDTO> GetChatStatus(string cmdId, string token80, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { cmdId, token80, cancellationToken };
			return await ((Task<ChatStatusResponseDTO>)requestBuilder.BuildRestResultFuncForMethod("GetChatStatus", ______typeParameters0)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<MessageCountResponseDTO> ISupportChatAPI.GetMessageCount(string cmdId, string token80, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { cmdId, token80, cancellationToken };
			return await ((Task<MessageCountResponseDTO>)requestBuilder.BuildRestResultFuncForMethod("GetMessageCount", ______typeParameters1)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<ChatStatusResponseDTO> ISupportChatAPI.GetChatStatus(string cmdId, string token80, CancellationToken cancellationToken)
		{
			object[] arg = new object[3] { cmdId, token80, cancellationToken };
			return await ((Task<ChatStatusResponseDTO>)requestBuilder.BuildRestResultFuncForMethod("GetChatStatus", ______typeParameters2)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	[ExcludeFromCodeCoverage]
	[DebuggerNonUserCode]
	[Preserve]
	[Obfuscation(Exclude = true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	private class AuchanCommonTooltipsITooltipsApi : ITooltipsApi
	{
		private readonly IRequestBuilder requestBuilder;

		private static readonly Type[] ______typeParameters = new Type[2]
		{
			typeof(string),
			typeof(CancellationToken)
		};

		private static readonly Type[] ______typeParameters0 = new Type[2]
		{
			typeof(string),
			typeof(CancellationToken)
		};

		public HttpClient Client { get; }

		public AuchanCommonTooltipsITooltipsApi(HttpClient client, IRequestBuilder requestBuilder)
		{
			Client = client;
			this.requestBuilder = requestBuilder;
		}

		public async Task<List<TooltipDto>> Tooltips(string token, CancellationToken cancellationToken)
		{
			object[] arg = new object[2] { token, cancellationToken };
			return await ((Task<List<TooltipDto>>)requestBuilder.BuildRestResultFuncForMethod("Tooltips", ______typeParameters)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}

		async Task<List<TooltipDto>> ITooltipsApi.Tooltips(string token, CancellationToken cancellationToken)
		{
			object[] arg = new object[2] { token, cancellationToken };
			return await ((Task<List<TooltipDto>>)requestBuilder.BuildRestResultFuncForMethod("Tooltips", ______typeParameters0)(Client, arg)).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	[ModuleInitializer]
	[DynamicDependency(DynamicallyAccessedMemberTypes.All, typeof(Generated))]
	public static void Initialize()
	{
	}
}
