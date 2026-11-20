using System.Collections.Generic;
using System.Linq;
using Auchan.Common.Common;
using Auchan.Common.LoyaltyProgram.Models;
using Auchan.Common.Networking;

namespace Auchan.Common.AdminTool.Models;

public class AppConfig
{
	public required int BannerAutoscrollDelay { get; init; }

	public required MaintenanceType MaintenanceStatus { get; init; }

	public required string MaintenanceTitle { get; init; }

	public required string MaintenanceMessage { get; init; }

	public required string MaintenanceButtonTitle { get; init; }

	public required string MaintenancePromocode { get; init; }

	public required string MaintenancePromocodeMessage { get; init; }

	public required RocketRetailModel RocketRetail { get; init; }

	public required YandexMapsModel? YandexMapsModel { get; init; }

	public required AppVersion? AppVersion { get; init; }

	public required Loyalty? Loyalty { get; init; }

	public required LoyaltyConfig? LoyaltyConfig { get; init; }

	public GameConfig? GameConfig => GameConfigs?.FirstOrDefault();

	public required List<GameConfig>? GameConfigs { get; init; }

	public required LoadScreenConfig? LoadScreenConfig { get; init; }

	public required FeedbackConfig? FeedbackConfig { get; init; }

	public required int? SmartcommPushTokenUpdateInterval { get; init; }

	public required bool DigeneticaEnabled { get; init; }

	public required bool AutohintsEnabled { get; init; }

	public required string? MainInformerText { get; init; }

	public required bool PriceCheckerEnabled { get; init; }

	public required AudienceType PricecheckerAudience { get; init; }

	public required bool PriceCheckerMWEventsEnabled { get; init; }

	public required bool GiftCardsEnabled { get; init; }

	public required bool IsChatEnabled { get; init; }

	public required List<string> AppMetricaDisabledEvents { get; init; }

	public required AppIconType AppIcon { get; init; }

	public required string AppMetricaPostApiKey { get; init; }

	public required string BasicAuthToken { get; init; }

	public required List<AppMetricaLimitedEvent> AppMetricaLimitedEvents { get; init; }

	public required IOrderedEnumerable<AppConfigMyOffer> MainMyOffersConfig { get; init; }

	public required IReadOnlySet<RetailRocketFeature> RetailRocketActiveFeatures { get; init; }

	public required IReadOnlyDictionary<Environment, StageUrlConfig> StageUrlConfigs { get; init; }

	public required bool IsCanAddGoodsToOrder { get; init; }
}
