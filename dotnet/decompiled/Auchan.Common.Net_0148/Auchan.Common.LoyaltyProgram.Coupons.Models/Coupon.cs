using System;

namespace Auchan.Common.LoyaltyProgram.Coupons.Models;

public class Coupon
{
	public long Id { get; set; }

	public DateTime? UsageStartDate { get; set; }

	public DateTime? ExpiryDate { get; set; }

	public string Name { get; set; } = string.Empty;

	public string Description { get; set; } = string.Empty;

	public string BottomDescription { get; set; } = string.Empty;

	public string MediaUrl { get; set; } = string.Empty;

	public string? CouponNumber { get; set; }

	public bool IsNew { get; set; } = true;

	public string Image { get; set; }

	public string BackgroundHEXColor { get; set; }

	public Coupon(long id, DateTime? expiryDate, string name, string description, string bottomDescription, string mediaUrl, DateTime? usageStartDate, string? couponNumber, string image, string backgroundHEXColor)
	{
		Id = id;
		ExpiryDate = expiryDate;
		Name = name;
		Description = description;
		BottomDescription = bottomDescription;
		MediaUrl = mediaUrl;
		UsageStartDate = usageStartDate;
		CouponNumber = couponNumber;
		Image = image;
		BackgroundHEXColor = backgroundHEXColor;
	}
}
