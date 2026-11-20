using System.Collections.Generic;
using Auchan.Common.Common.Binding;

namespace Auchan.Common.LoyaltyProgram.Coupons;

public interface ICouponsViewModel
{
	IReadOnlyList<CouponItemViewModel> Coupons { get; }

	UICommand OpenAboutCouponsCommand { get; }

	void CouponTapped(CouponItemViewModel c);
}
