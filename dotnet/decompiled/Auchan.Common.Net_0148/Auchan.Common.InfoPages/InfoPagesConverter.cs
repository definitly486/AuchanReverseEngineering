using System.ComponentModel;

namespace Auchan.Common.InfoPages;

public static class InfoPagesConverter
{
	public static string InfoTypeToSlug(InfoType infoType)
	{
		return infoType switch
		{
			InfoType.About => "about", 
			InfoType.Exchange => "info", 
			InfoType.Refund => "refund", 
			InfoType.Vacancy => "auchan_job", 
			InfoType.Delivery => "delivery", 
			InfoType.Payment => "payment", 
			InfoType.Tutorial => "tutorial", 
			InfoType.FAQ => "faq", 
			InfoType.ReviewingRules => "reviews_publishing_rules", 
			InfoType.PrivacyPolicy => "privacy_policy", 
			InfoType.PersonalDataProcessingPolicy => "personal_data_policy", 
			InfoType.PersonalDataProcessingAgreement => "accept_personal_data", 
			InfoType.AuchanPayAgreement => "auchan_pay_agreement", 
			InfoType.UserGuide => "user_guide", 
			InfoType.LoyaltyPolicy => "loyalty_rules", 
			InfoType.StampsPolicy => "kollection_pravila", 
			InfoType.EmployeesLoyaltyPolicy => "loyalty_rules_employees", 
			InfoType.EmployeesLoyaltyPrivileges => "loyalty_privileges_employees", 
			InfoType.FundAuchan => "fund_auchan", 
			InfoType.Offerta => "offerta", 
			InfoType.AuchanPayMemo => "auchan_pay_memo", 
			InfoType.GiftCardRules => "gift_card_rules", 
			InfoType.GiftCardFAQ => "giftcardfaq", 
			InfoType.PromocodeInfoPage => "promocode_rules", 
			InfoType.AdvertisementConsent => "reklama", 
			_ => throw new InvalidEnumArgumentException(), 
		};
	}

	public static InfoType SlugToInfoType(string slug)
	{
		return slug switch
		{
			"about" => InfoType.About, 
			"info" => InfoType.Exchange, 
			"refund" => InfoType.Refund, 
			"delivery" => InfoType.Delivery, 
			"payment" => InfoType.Payment, 
			"tutorial" => InfoType.Tutorial, 
			"faq" => InfoType.FAQ, 
			"privacy_policy" => InfoType.PrivacyPolicy, 
			"accept_personal_data" => InfoType.PersonalDataProcessingAgreement, 
			"reviews_publishing_rules" => InfoType.ReviewingRules, 
			"personal_data_policy" => InfoType.PersonalDataProcessingPolicy, 
			"auchan_pay_agreement" => InfoType.AuchanPayAgreement, 
			"user_guide" => InfoType.UserGuide, 
			"loyalty_rules" => InfoType.LoyaltyPolicy, 
			"kollection_pravila" => InfoType.StampsPolicy, 
			"fund_auchan" => InfoType.FundAuchan, 
			"auchan_pay_memo" => InfoType.AuchanPayMemo, 
			_ => InfoType.About, 
		};
	}

	public static string InfoTypeToTitle(InfoType infoType)
	{
		return infoType switch
		{
			InfoType.About => "АШАН в России", 
			InfoType.AuchanPayAgreement => "Соглашение АШАН Pay", 
			InfoType.Delivery => "Доставка", 
			InfoType.Exchange => "Обмен", 
			InfoType.FAQ => "Вопросы с ответы", 
			InfoType.Payment => "Оплата", 
			InfoType.PersonalDataProcessingPolicy => "Политика по обработке персональных данных", 
			InfoType.PrivacyPolicy => "Политика конфиденциальности", 
			InfoType.Refund => "Возврат", 
			InfoType.Tutorial => "Обучающие инструкции", 
			InfoType.UserGuide => "Руководство пользователя АШАН Pay", 
			InfoType.LoyaltyPolicy => "Правила использования программы лояльности", 
			InfoType.ReviewingRules => "Правила размещения отзывов", 
			InfoType.StampsPolicy => "Правила коллекционной акции", 
			InfoType.FundAuchan => "Благотворительный фонд «Поколение АШАН»", 
			InfoType.AuchanPayMemo => "Памятка о дальнейшей работе Auchan Pay", 
			_ => throw new InvalidEnumArgumentException(), 
		};
	}

	public static string PositionToCategoryTitle(InfoPagePosition position)
	{
		return position switch
		{
			InfoPagePosition.Documents => "Документы", 
			InfoPagePosition.PaymentDelivery => "Доставка и оплата", 
			InfoPagePosition.RefundExchange => "Обмен и возврат товаров", 
			_ => string.Empty, 
		};
	}
}
