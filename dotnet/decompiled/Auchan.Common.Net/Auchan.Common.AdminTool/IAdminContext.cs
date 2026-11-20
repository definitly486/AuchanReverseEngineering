using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using Auchan.Common.AdminTool.Models;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Home;
using CSharpFunctionalExtensions;

namespace Auchan.Common.AdminTool;

public interface IAdminContext : INotifyPropertyChanged
{
	bool AppConfigIsNotNull { get; }

	string LastNewAppVersion { get; set; }

	AppConfig AppConfig { get; }

	StampsConfig? StampsConfig { get; }

	bool ShowedStartOnboardingsThisSession { get; }

	bool ShowedTooltipThisSession { get; }

	bool ShowedEcoCheck { get; }

	bool ShowedGameAnimationPopup { get; }

	DateTime GamePopupLastShowTime { get; }

	bool GamePopupDontShowFlag { get; set; }

	string CustomSplashAnimationKey { get; set; }

	bool AdditionalOrderTooltipShown { get; set; }

	ReadOnlyObservableCollection<Promotion> Promotions { get; }

	IObservable<IReadOnlyList<Promotion>> PromotionsChanged { get; }

	ReadOnlyObservableCollection<PersOfferItemViewModel> PersonalOffers { get; }

	IObservable<IReadOnlyList<PersOfferItemViewModel>> PersonalOffersChanged { get; }

	int CountOfNewPersonalOffers { get; }

	void InitializeAppConfigAndExtraPromotionAtAppStart(AppConfig appConfig, ImmutableList<ExtraPromotion> extraPromotions);

	Task<AppConfig> WaitForAppConfig();

	Task<Result<AppConfig, DomainError>> GetAppConfig();

	Task<Result<AppConfig, DomainError>> SyncAppConfig();

	Task CleanDeinitialize();

	Task<Result<List<Promotion>, DomainError>> GetPromotions(bool forceUpdate = false);

	Task<Result<Promotion, DomainError>> Promotion(int id);

	Task<Result<List<PersOfferItemViewModel>, DomainError>> GetPersonalOffers();

	Task<Result<object, DomainError>> ActivatePersonalOffer(string loymaxId);

	bool IsMyOfferViewed(string id);

	void SaveViewedMyOfferId(string id);

	void InvalidatePersOffersCache();

	bool IsBannerViewed(int id);

	void SaveViewedBannerId(int id);

	Task<ImmutableList<ExtraPromotion>> GetExtraPromotionsAsync();

	void UpdateExtraPromotions();

	GameAnimation? GetNextGameAnimation();

	void AddShowedExtraPromotion(int id);

	bool IsShowedExtraPromotion(int id);

	void OnStartOnboardingsShown();

	void OnTooltipPopupShown();

	void OnEcoCheckShown();

	void OnGameAnimationPopupShown();

	void OnGamePopupShown();

	bool ShouldShowTooltipPopup(int limit);

	bool IsGameActive();

	void PrefetchPromotions();

	Task<StampsConfig?> UpdateStampsConfig();
}
