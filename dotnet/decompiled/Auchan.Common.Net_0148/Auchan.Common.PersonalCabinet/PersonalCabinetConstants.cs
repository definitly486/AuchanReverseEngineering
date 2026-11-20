namespace Auchan.Common.PersonalCabinet;

public static class PersonalCabinetConstants
{
	public const string CountryCode = "7";

	public const string PhonePrefix = "+7";

	public const string PhoneMask = "+7 ([000]) [000]-[00]-[00]";

	public const string CardMask = "[0000] [0000] [0000] [0]";

	public const string CvvMask = "[000]";

	public const int PinCodeLength = 4;

	public const string LoyaltyCardNumberMask = "[0000] [0000] [0000] [0]";

	public const int LoyaltyCardCvcLength = 3;

	public const string DateMask = "[00].[00].[00]";

	public const string DateMaskFull = "[00].[00].[0000]";

	public const string DateTimeMask = "[00].[00].[00], [00]:[00]";

	public const int SecondsToRetryPinGetting = 60;

	public const int SecondsToRetryMaxRetryReached = 900;

	public const int MaxPinGettingRetry = 5;

	public const int MinValidAge = 18;

	public const string CachedPhoneKey = "CachedPhone";

	public const string CachedEmailKey = "CachedEmail";

	public const string CachedSignUpData = "CachedSignUpData";

	public const string CachedNotificationsCount = "CachedNotificationsCount";
}
