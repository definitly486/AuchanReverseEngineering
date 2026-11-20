using System;
using System.Collections.Generic;
using Auchan.Common.Common;
using Auchan.Common.LoyaltyProgram.Dtos.Triggers;
using Newtonsoft.Json;

namespace Auchan.Common.AdminTool.DTO;

public class AppConfigDto
{
	[JsonProperty("non_field_errors")]
	public List<AppConfigError> Errors { get; set; }

	[JsonProperty("banner_autoscroll_delay")]
	public int BannerAutoscrollDelay { get; set; }

	[JsonProperty("maintenance_status")]
	public MaintenanceType MaintenanceStatus { get; set; }

	[JsonProperty("maintenance_title")]
	public string MaintenanceTitle { get; set; }

	[JsonProperty("maintenance_message")]
	public string MaintenanceMessage { get; set; }

	[JsonProperty("maintenance_button_title")]
	public string MaintenanceButtonTitle { get; set; }

	[JsonProperty("maintenance_promocode")]
	public string MaintenancePromocode { get; set; }

	[JsonProperty("maintenance_promocode_message")]
	public string MaintenancePromocodeMessage { get; set; }

	[JsonProperty("rocketRetail")]
	public RocketRetailDto RocketRetail { get; set; }

	[JsonProperty("yandex_maps")]
	public YandexMapsDto? YandexMaps { get; set; }

	[JsonProperty("app_version", Required = Required.Default)]
	public AppVersionDto? AppVersion { get; set; }

	[JsonProperty("new_loyalty_program")]
	public LoyaltyDto? Loyalty { get; set; }

	[JsonProperty("loyalty_config")]
	public LoyaltyConfigDto? LoyaltyConfig { get; set; }

	[JsonProperty("game_configs", Required = Required.Default)]
	public List<GameConfigDto?> GameConfigs { get; set; }

	[JsonProperty("load_screen_config")]
	public LoadScreenConfigDto? LoadScreenConfig { get; set; }

	[JsonProperty("feedback_config")]
	public FeedbackConfigDto? FeedbackConfigDto { get; set; }

	[JsonProperty("smartcomm_push_token_update_interval")]
	public int SmartcommPushTokenUpdateInterval { get; set; }

	[JsonProperty("feature_flag_digenetica")]
	public bool DigeneticaEnabled { get; set; }

	[JsonProperty("feature_flag_autohints")]
	public bool AutohintsEnabled { get; set; }

	[JsonProperty("main_informer")]
	public MainInformerDto? MainInformer { get; set; }

	[JsonProperty("pricechecker_enabled")]
	public bool PriceCheckerEnabled { get; set; }

	[JsonProperty("pricechecker_audience")]
	[JsonConverter(typeof(EnumMemberJsonConverter<AudienceType>))]
	public AudienceType PricecheckerAudience { get; set; }

	[JsonProperty("pricechecker_MW_events_enabled")]
	public bool PriceCheckerMWEventsEnabled { get; set; }

	[JsonProperty("gift_cards_enabled")]
	public bool GiftCardsEnabled { get; set; }

	[JsonProperty("feature_chat_enabled")]
	public bool IsChatEnabled { get; set; }

	[JsonProperty("appmetrica_post_api_key")]
	public string? AppmetricaPostApiKey { get; set; }

	[JsonProperty("appmetrica_disabled_events")]
	public string? AppMetricaDisabledEvents { get; set; }

	[JsonProperty("app_icon")]
	[JsonConverter(typeof(EnumMemberJsonConverter<AppIconType>))]
	public AppIconType AppIcon { get; set; }

	[JsonProperty("appmetrica_limited_events")]
	public List<AppMetricaLimitedEventDto> AppMetricaLimitedEvents { get; set; } = new List<AppMetricaLimitedEventDto>();

	[JsonProperty("my_offers")]
	public List<AppConfigMyOfferDto>? MainMyOffersConfig { get; set; }

	[JsonProperty("rr")]
	public IReadOnlyList<RetailRocketFeatureDto>? RetailRocketFeatures { get; init; }

	[JsonProperty("stage_configs")]
	public IReadOnlyList<StageUrlConfigDto> StageUrlConfigs { get; init; } = Array.Empty<StageUrlConfigDto>();

	[JsonProperty("addition_available")]
	public bool AdditionAvailable { get; init; }

	[JsonProperty("basic_auth_token")]
	public string BasicAuthToken { get; set; }
}
