namespace Auchan.Common.Analytics.Firebase;

internal static class FirebaseConstants
{
	public static class Events
	{
		public const string AddToCart = "add_to_cart";

		public const string RemoveFromCart = "remove_from_cart";

		public const string Checkout = "checkout_progress";

		public const string ViewProductCard = "view_item";

		public const string ViewItemList = "view_item_list";

		public const string ViewPromotion = "view_promotion";

		public const string SelectPromotion = "select_promotion";

		public const string Search = "view_search_results";

		public const string Purchase = "purchase";

		public const string Button = "buttons";

		public const string PopupClick = "popup_click";

		public const string PopupClose = "popup_close";
	}

	public static class Buttons
	{
		public const string TabbarHome = "tabbar_tap_home";

		public const string TabbarCatalog = "tabbar_tap_catalog";

		public const string TabbarCart = "tabbar_tap_cart";

		public const string TabbarLoyalty = "tabbar_tap_loyality";

		public const string TabbarProfile = "tabbar_tap_profile";

		public const string BannerTop = "main_tap_on_banner_up";

		public const string BannerDown = "main_tap_on_banner_down";

		public const string SearchTap = "main_tap_on_search";

		public const string CatalogTap = "main_tap_on_catalog";

		public const string CategoryTap = "main_tap_on_category";

		public const string SalesAndNewsTap = "main_tap_on_sales_and_news";

		public const string DeliveryAddressTap = "main_tap_on_edit_delivery_adress";

		public const string PickupTap = "main_delivery_adress_tap_on_pickup";

		public const string SaveAddress = "main_delivery_adress_tap_on_save_adress";

		public const string Offers = "main_tap_on_my_offers";

		public const string TapOnSubcategory = "catalog_tap_on_sub_category";

		public const string TapOnCategory = "catalog_tap_on_category";

		public const string AddItemTap = "item_name_{0}_tap_on_add";

		public const string CartTapOrder = "cart_tap_on_order_registration";

		public const string CartTapClear = "cart_tap_on_clear";

		public const string CheckoutTapPay = "checkout_tap_on_pay";

		public const string CheckoutCheckboxNotMe = "checkout_tap_on_checkbox_not_me";

		public const string Fill = "loyalty_tap_on_deposit";

		public const string AuchanPay = "loyalty_tap_on_pay";

		public const string TransactionHistory = "loyalty_tap_on_transactions";

		public const string LoyaltyCardCantScan = "loyalty_card_cant_scan";

		public const string SelfScan = "scan_entry_bottom_menu";

		public const string SSEnterBarcode = "scan_manual_data";

		public const string SSTorch = "scan_flash";

		public const string SSClose = "scan_close";

		public const string SSDeleteCart = "scan_close_del";

		public const string SSSaveCart = "scan_close_save";

		public const string SSPlus = "scan_cart_tap_on_minus";

		public const string SSMinus = "scan_cart_tap_on_plus";

		public const string SSRemove = "scan_cart_del";

		public const string SSPay = "scan_goto_pay";

		public const string SSAuchanPay = "scan_checkout_apay";

		public const string SSAddItem = "scan_manual_add";

		public const string ProfileAuth = "profile_info_tap_on_auth";

		public const string AuthExitAll = "auth_my_info_tap_on_exit_all";

		public const string AuthExit = "auth_my_info_tap_on_exit";

		public const string AuthRecoverPassword = "auth_my_info_tap_on_restore_password";

		public const string AuthSave = "auth_my_info_tap_on_save_password";

		public const string AuthDelete = "auth_my_info_tap_on_delete_account";

		public const string AuthSocialStatus = "auth_social_status";

		public const string AuthPurchaseHistory = "auth_purchase_history";

		public const string SubscriptionOn = "auth_notifications_turn_on";

		public const string SubscriptionOff = "auth_notifications_turn_off";

		public const string SubscriptionTap = "auth_my_info_tap_on_checkbox_notifications";

		public const string Stores = "info_stores";

		public const string DeliveryAndPayment = "info_dostavka_oplata";

		public const string ExchangeRefund = "info_obmen_vozvrat";

		public const string FAQ = "info_faq";

		public const string Documents = "info_documents";

		public const string Tutorials = "info_instructions";

		public const string InfoWrite = "info_send_feedback";

		public const string InfoCall = "info_call";

		public const string InfoPage = "info_page";

		public const string ReceiveCode = "entry_tap_on_receive_code";

		public const string CodeField = "entry_tap_on_code";

		public const string Continue = "entry_tap_on_continue";

		public const string TapOnEmail = "entry_tap_on_email";

		public const string TapRegister = "loyality_tap_on_reg_button";

		public const string SuccessSignUpContinue = "entry_reg_tap_on_continue";

		public const string SuccessSignUpGoToProfile = "entry_reg_tap_on_profile";

		public const string EnterByEmail = "entry_email_tap_on_entry";

		public const string EnterByEmailRestore = "entry_email_tap_on_restore_password";

		public const string EnterByPhone = "entry_email_tap_on_tel";

		public const string AddCard = "auth_my_cards_tap_on_add_card";

		public const string SaveCard = "auth_my_cards_add_card_tap_on_save_card";

		public const string DeleteCard = "auth_my_cards_delete_card";

		public const string EntryRegionSaved = "entry_region_saved";

		public const string AuthLogin = "entry_enter";

		public const string AuthRegister = "entry_reg";

		public const string ActiveCard = "loyality_activate_plastic_card";

		public const string CreateCard = "loyality_create_virtual_card";

		public const string CardManualInput = "loyality_scan_manual_input";

		public const string LoyaltyCashback = "loyalty_tap_on_cashback";

		public const string LoyaltyCardDetails = "loyality_tap_on_details";

		public const string LoyaltyPointsBurn = "loyality_tap_on_score_statistic";

		public const string LoyaltySharePoints = "loyality_tap_on_share_bonus";

		public const string LoyaltyAllOffers = "loyality_tap_on_all_offers";

		public const string LoyaltyOfferBanner = "loyality_tap_on_banner{0}";

		public const string LoyaltyQuestions = "loyality_questions";

		public const string LoyaltyContact = "loyality_contact";

		public const string LoyaltyAddCard = "loyality_add_plastic_card";

		public const string LoyaltyRules = "loyality_rules";

		public const string BlockCardButton = "loyality_tap_on_block_card";

		public const string CantScanWrite = "loyality_card_not_read_tap_on_write";

		public const string CantScanCall = "loyality_card_not_read_tap_on_call";

		public const string PopupBlockCard = "loyality_block_card_popup_tap_on_block";

		public const string PopupBlockReissueCard = "loyality_block_card_popup_tap_on_create_new";

		public const string TapCharity = "loyality_transfer_tap_on_charity";

		public const string TapParticipant = "loyality_transfer_tap_on_participant";

		public const string MakeTransfer = "loyality_transfer_tap_on_make_transfer";

		public const string GeoAllowed = "entry_geo_access_allowed";

		public const string GeoCancelled = "entry_geo_access_cancelled";

		public const string PlayGame = "playgame";
	}

	public static class Screens
	{
		public const string Main = "Main";

		public const string ItemList = "Item_list";

		public const string ItemListSearch = "Item_list_search";

		public const string Item = "Item_name";

		public const string Cart = "Cart";

		public const string Checkout = "Checkout";

		public const string Thanks = "ThankYou";

		public const string Info = "Info";

		public const string SignUp = "entry";

		public const string Tutorials = "loyality_tutorial_{0}step";

		public const string Cashback = "loyalty_cashback";

		public const string LoyaltyCardDetails = "loyalty_card_details";

		public const string LoyaltyCardQrPreview = "loyalty_card_qr_preview";

		public const string EditDeliveryAddress = "main_edit_delivery_adress";

		public const string SelfScanVerify = "scan_check";

		public const string SelfScanPayment = "scan_checkout";

		public const string ProfileAuth = "profile_auth";

		public const string ProfileAuthUndescore = "profile_auth_";

		public const string ProfileInfo = "profile_info";

		public const string ProfileInfoUnderscore = "profile_info_";

		public const string UserData = "auth_my_info";

		public const string UserNotifications = "auth_notifications";

		public const string EntryReg = "entry_reg";

		public const string CatalogUnderscore = "catalog_";

		public const string Orders = "auth_my_orders";

		public const string Cards = "auth_my_cards";

		public const string EnterRegion = "entry_enter_your_region";

		public const string Onboarding = "onboarding_{0}step";

		public const string AuthWelcome = "entry_welcome";

		public const string GreetingRetired = "entry_popup_pensioner";

		public const string GreetingExistingCustomer = "entry_popup_existing_customer";

		public const string LoyaltyCardActivation = "loyality_new_card_activation_screen";

		public const string LoyaltyAlreadyActiveCard = "loyality_already_active_card_screen";

		public const string LoyaltySignUpCardActive = "loyality_card_activation_success";

		public const string LoyaltySignUp = "loyality_registration_success";

		public const string LoyaltyCardBlockSuccess = "loyality_card_successfully_blocked";

		public const string LoyaltyCardCantScan = "loyality_csrd_is_not_read";

		public const string LoyaltyTransfer = "loyality_transfer";

		public const string LoyaltyTransferSuccess = "loyality_transfer_success_screen";

		public const string SocialStatusConfirmed = "social_status_confirmed";

		public const string SocialStatusNotConfirmed = "social_status_not_confirmed";

		public const string FeedbackSend = "feedback_send";

		public const string FeedbackSendSuccess = "feedback_success_screen";

		public const string OrderHistory = "history_order_composition_screen";

		public const string CardScanSuccess = "loyality_scan_success";

		public const string CardScanFailure = "loyality_scan_error";
	}

	public static class Fields
	{
		public const string EntryFirstName = "entry_reg_tap_on_name";

		public const string EntryLastName = "entry_reg_tap_on_2_name";

		public const string EntryDate = "entry_reg_tap_on_date";

		public const string EntryFemaleGender = "entry_reg_tap_on_female_gender";

		public const string EntryMaleGender = "entry_reg_tap_on_male_gender";

		public const string EntryEmail = "entry_reg_tap_on_email";

		public const string EntryCheckbox = "entry_reg_tap_on_checkbox_notifications";

		public const string RegCardNumber = "loyality_reg_tap_on_card_number";

		public const string RegCvv = "loyality_reg_tap_on_card_cvv";

		public const string AuthFirstName = "auth_my_info_tap_on_name";

		public const string AuthLastName = "auth_my_info_tap_on_2_name";

		public const string AuthDate = "auth_my_info_tap_on_date";

		public const string AuthFemaleGender = "auth_my_info_tap_on_female_gender";

		public const string AuthMaleGender = "auth_my_info_tap_on_male_gender";

		public const string AuthEmail = "auth_my_info_tap_on_email";

		public const string AuthPassword = "auth_my_info_tap_on_password";

		public const string CheckoutEntrance = "checkout_tap_on_entrance";

		public const string CheckoutFloor = "checkout_tap_on_floor";

		public const string CheckoutFlat = "checkout_tap_on_flat";

		public const string CheckoutCode = "checkout_tap_on_code";

		public const string CheckoutComment = "checkout_tap_on_comment";

		public const string CheckoutDate = "checkout_tap_on_date";

		public const string CheckoutNotMeName = "checkout_tap_on_not_me_name";

		public const string CheckoutNotMeTel = "checkout_tap_on_not_me_tel";

		public const string CheckoutNotMeEmail = "checkout_tap_on_not_me_email";

		public const string CheckoutPromocode = "checkout_tap_on_promocode";

		public const string CheckoutUsePoints = "checkout_tap_on_spend_loyality_points";

		public const string LoyaltyPointsQuantity = "loyality_transfer_tap_on_quantity";

		public const string LoyaltyPhone = "loyality_transfer_tap_on_phone";
	}

	public const string ItemId = "item_id";

	public const string ItemName = "item_name";

	public const string ItemCategory = "item_category";

	public const string Quantity = "quantity";

	public const string Price = "price";

	public const string Value = "value";

	public const string Currency = "currency";

	public const string DefaultCurrency = "RUB";

	public const string Items = "items";

	public const string CheckoutStep = "checkout_step";

	public const string Affiliation = "affiliation";

	public const string DefaultAffiliation = "Auchan";

	public const string Shipping = "shipping";

	public const string TransactionId = "transaction_id";

	public const string SearchTerm = "search_term";

	public const string Catalog = "catalog";

	public const string SearchParam = "search";

	public const string ScreenName = "screenname";

	public const string ClassName = "classname";

	public const string Empty = "empty";

	public const string Index = "index";

	public const string ItemListId = "item_list_id";

	public const string ItemListName = "item_list_name";

	public const string PopupId = "popup_id";

	public const string PopupName = "popup_name";

	public const string PopupFrom = "popup_from";

	public const string PopupFromId = "popup_from_id";

	public const string PopupTo = "popup_to";

	public const string PopupToId = "popup_to_id";

	public const string PopupRegion = "popup_region";

	public const string PopupBegins = "popup_begins";

	public const string PopupUrl = "popup_url";
}
