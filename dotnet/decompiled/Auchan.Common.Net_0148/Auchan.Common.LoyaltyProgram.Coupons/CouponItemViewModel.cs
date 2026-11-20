using System;
using System.Runtime.CompilerServices;
using Auchan.Common.Base;
using Auchan.Common.LoyaltyProgram.Coupons.Models;

namespace Auchan.Common.LoyaltyProgram.Coupons;

public class CouponItemViewModel : BaseItemViewModel
{
	private readonly Coupon? _coupon;

	[CompilerGenerated]
	private bool _003CIsNew_003Ek__BackingField;

	public Coupon? Coupon => _coupon;

	public bool IsStub { get; }

	public string StubTitle { get; } = "Совершайте покупки,\nчтобы получать купоны";

	public string StubAboutText { get; } = "Хочу получить купон";

	public long Id => _coupon.Id;

	public DateTime? UsageStartDate => _coupon?.UsageStartDate;

	public DateTime? ExpiryDate => _coupon?.ExpiryDate;

	public string Name => _coupon.Name;

	public string Description => _coupon.Description;

	public string MediaUrl => _coupon.Image;

	public string? CouponNumber => _coupon.CouponNumber;

	public bool IsNew
	{
		[CompilerGenerated]
		get
		{
			return _003CIsNew_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (_003CIsNew_003Ek__BackingField != value)
			{
				_003CIsNew_003Ek__BackingField = value;
				RaisePropertyChanged("IsNew");
			}
		}
	}

	public bool HasExpiryDate => ExpiryDate.HasValue;

	public string ExpiryText => $"до {_coupon.ExpiryDate:M}";

	public CouponItemViewModel()
	{
		IsStub = true;
		IsNew = false;
	}

	public CouponItemViewModel(Coupon coupon)
	{
		_coupon = coupon;
		IsNew = _coupon.IsNew;
	}

	public void SetCouponSeen()
	{
		if (!IsStub)
		{
			_coupon.IsNew = false;
		}
		IsNew = false;
		RaisePropertyChanged("IsNew");
	}
}
