using System.Runtime.Serialization;

namespace Auchan.Common.Tooltips;

public enum TooltipTargetType
{
	[EnumMember(Value = "None")]
	Unknown,
	[EnumMember(Value = "Loyalty card")]
	LoyaltyCard,
	[EnumMember(Value = "QR code button")]
	QrCodeButton,
	[EnumMember(Value = "Points")]
	Points,
	[EnumMember(Value = "Express points")]
	ExpressPoints,
	[EnumMember(Value = "Marks")]
	Marks,
	[EnumMember(Value = "Details")]
	Details,
	[EnumMember(Value = "Pricechecker")]
	PriceChecker,
	[EnumMember(Value = "FavoriteCategories")]
	FavoriteCategories
}
