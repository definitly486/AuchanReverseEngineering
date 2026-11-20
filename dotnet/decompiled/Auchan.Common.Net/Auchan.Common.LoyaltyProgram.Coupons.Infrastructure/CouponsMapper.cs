using Auchan.Common.LoyaltyProgram.Coupons.DTO;
using Auchan.Common.LoyaltyProgram.Coupons.Models;

namespace Auchan.Common.LoyaltyProgram.Coupons.Infrastructure;

internal static class CouponsMapper
{
	public static Coupon Map(this CouponDTO couponDTO)
	{
		return new Coupon(couponDTO.Id, couponDTO.ExpiryDate, couponDTO.Name, couponDTO.Description, couponDTO.BottomDescription, couponDTO.MediaUrl, couponDTO.UsageStartDate, couponDTO.CouponNumber, couponDTO.Image, couponDTO.BackgroundHEXColor ?? "#FFECDE");
	}
}
