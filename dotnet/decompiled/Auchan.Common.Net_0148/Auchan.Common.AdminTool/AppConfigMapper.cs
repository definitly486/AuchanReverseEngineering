using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Auchan.Common.AdminTool.DTO;
using Auchan.Common.AdminTool.Models;
using Auchan.Common.Extensions;
using Auchan.Common.LoyaltyProgram.Mappers;
using Auchan.Common.LoyaltyProgram.Models;
using Auchan.Common.Networking;

namespace Auchan.Common.AdminTool;

public static class AppConfigMapper
{
	public static AppConfig ToModel(this AppConfigDto dto)
	{
		AppConfig appConfig = new AppConfig();
		appConfig.BannerAutoscrollDelay = dto.BannerAutoscrollDelay;
		appConfig.MaintenanceStatus = dto.MaintenanceStatus;
		appConfig.MaintenanceTitle = dto.MaintenanceTitle;
		appConfig.MaintenanceMessage = dto.MaintenanceMessage;
		appConfig.MaintenanceButtonTitle = dto.MaintenanceButtonTitle;
		appConfig.MaintenancePromocode = dto.MaintenancePromocode;
		appConfig.MaintenancePromocodeMessage = dto.MaintenancePromocodeMessage;
		appConfig.AppVersion = ((dto.AppVersion != null) ? new AppVersion(dto.AppVersion) : null);
		appConfig.RocketRetail = new RocketRetailModel(dto.RocketRetail.ApiKey, dto.RocketRetail.PartnerId);
		appConfig.YandexMapsModel = ((dto.YandexMaps != null) ? new YandexMapsModel(dto.YandexMaps) : null);
		appConfig.Loyalty = dto.Loyalty?.Map() ?? new Loyalty();
		appConfig.LoyaltyConfig = dto.LoyaltyConfig?.Map() ?? new LoyaltyConfig();
		appConfig.GameConfigs = dto.GameConfigs?.SelectNotNull((GameConfigDto x) => x?.Map()).ToList();
		appConfig.LoadScreenConfig = dto.LoadScreenConfig?.Map() ?? null;
		appConfig.FeedbackConfig = ((dto.FeedbackConfigDto != null) ? new FeedbackConfig(dto.FeedbackConfigDto.PhoneNumber, dto.FeedbackConfigDto.Email) : null);
		appConfig.SmartcommPushTokenUpdateInterval = dto.SmartcommPushTokenUpdateInterval;
		appConfig.DigeneticaEnabled = dto.DigeneticaEnabled;
		appConfig.AutohintsEnabled = dto.AutohintsEnabled;
		appConfig.MainInformerText = dto.MainInformer?.Text;
		appConfig.PriceCheckerEnabled = dto.PriceCheckerEnabled;
		appConfig.PricecheckerAudience = dto.PricecheckerAudience;
		appConfig.PriceCheckerMWEventsEnabled = dto.PriceCheckerMWEventsEnabled;
		appConfig.GiftCardsEnabled = dto.GiftCardsEnabled;
		appConfig.IsChatEnabled = dto.IsChatEnabled;
		appConfig.AppMetricaPostApiKey = dto.AppmetricaPostApiKey ?? string.Empty;
		appConfig.AppMetricaDisabledEvents = dto.AppMetricaDisabledEvents?.Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries)?.Select((string e) => e.Trim())?.ToList() ?? new List<string>();
		appConfig.AppIcon = dto.AppIcon;
		appConfig.AppMetricaLimitedEvents = dto.AppMetricaLimitedEvents.SelectNotNull((AppMetricaLimitedEventDto x) => x.Map()).ToList();
		IEnumerable<AppConfigMyOffer> enumerable = dto.MainMyOffersConfig?.Where((AppConfigMyOfferDto mo) => mo.Active)?.Select((AppConfigMyOfferDto mo) => new AppConfigMyOffer(mo.Code, mo.Priority, mo.Limit.GetValueOrDefault()))?.ToList();
		appConfig.MainMyOffersConfig = (enumerable ?? Enumerable.Empty<AppConfigMyOffer>()).OrderBy((AppConfigMyOffer mo) => mo.Priority);
		appConfig.RetailRocketActiveFeatures = dto.RetailRocketFeatures.Map();
		appConfig.StageUrlConfigs = dto.StageUrlConfigs.Map();
		appConfig.IsCanAddGoodsToOrder = dto.AdditionAvailable;
		appConfig.BasicAuthToken = dto.BasicAuthToken;
		return appConfig;
	}

	public static LoyaltyConfig Map(this LoyaltyConfigDto dto)
	{
		return new LoyaltyConfig
		{
			EPointsBalanceEnabled = dto.EPointsBalanceEnabled,
			EPointsBalanceOperationsHistoryEnabled = dto.EPointsBalanceOperationsHistoryEnabled,
			SocialStatusConfirmedText = dto.SocialStatusConfirmedText,
			SocialStatusUnconfirmedText = dto.SocialStatusUnconfirmedText,
			IsPointsTransferToAuchanFundEnabled = dto.IsPointsTransferToAuchanFundEnabled,
			IsPointsTransferToUserEnabled = dto.IsPointsTransferToUserEnabled,
			PointsTransferDisabledMessage = dto.PointsTransferDisabledMessage,
			PointsTransferToAuchanFundDisabledMessage = dto.PointsTransferToAuchanFundDisabledMessage,
			PointsTransferToUsersDisabledMessage = dto.PointsTransferToUsersDisabledMessage,
			ConnectionErrorText = dto.ConnectionErrorText,
			ConnectionErrorImage = dto.ConnectionErrorImage
		};
	}

	public static GameConfig Map(this GameConfigDto dto)
	{
		return new GameConfig(dto.Id, dto.Name, dto.GameEnabled, dto.BeginsOn, dto.EndsOn, dto.Url, dto.Animations.Select(Map).ToList(), dto.ButtonText, dto.PopupText);
	}

	public static AppMetricaLimitedEvent Map(this AppMetricaLimitedEventDto dto)
	{
		return new AppMetricaLimitedEvent(dto.Event, dto.Limit);
	}

	public static GameAnimation Map(this GameAnimationDto dto)
	{
		return new GameAnimation(dto.AnimationUrl, dto.Position, dto.Priority, dto.CloseButtonEnabled && !string.IsNullOrWhiteSpace(dto.CloseButtonImageUrl), dto.ClosePosition, dto.CloseButtonHorizontalOffset, dto.CloseButtonVerticalOffset, dto.CloseButtonImageUrl, dto.CloseAnimationUrl);
	}

	public static LoadScreenConfig Map(this LoadScreenConfigDto dto)
	{
		return new LoadScreenConfig(dto.Name, dto.LoadScreenAnimationUrl);
	}

	public static IReadOnlySet<RetailRocketFeature> Map(this IReadOnlyList<RetailRocketFeatureDto>? dto)
	{
		if (dto == null)
		{
			return ImmutableHashSet<RetailRocketFeature>.Empty;
		}
		return (from i in dto
			where i.Active == true && i.Code > RetailRocketFeatureDto.CodeDto.Unknown
			select (RetailRocketFeature)(i.Code - 1)).ToImmutableHashSet();
	}

	public static IReadOnlyDictionary<Auchan.Common.Networking.Environment, StageUrlConfig> Map(this IReadOnlyList<StageUrlConfigDto> @this)
	{
		return @this.Where((StageUrlConfigDto i) => i.Environment != StageUrlConfigDto.EnvironmentDto.Unknown).ToImmutableDictionary((StageUrlConfigDto i) => (Auchan.Common.Networking.Environment)(i.Environment - 1), (StageUrlConfigDto i) => i.Map());
	}

	public static StageUrlConfig Map(this StageUrlConfigDto @this)
	{
		return new StageUrlConfig
		{
			ChatbotFileserverAddress = @this.Address,
			ChatbotWebsocketToken = @this.WebsocketKey
		};
	}
}
