using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using Auchan.Common.Base;
using Auchan.Common.Extensions;
using Auchan.Common.LoyaltyProgram.Coupons.Models;

namespace Auchan.Common.Home.MainMyOffers;

public class HomeMyOfferItemViewModel : BaseItemViewModel
{
	private const string CouponButtonText = "Открыть купон";

	private const string TimeTextFormat = "до {0}";

	[CompilerGenerated]
	private MainMyOfferType _003CType_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CTitleText_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CDescriptionText_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CTimeText_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CButtonText_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CIsNew_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CIsActivated_003Ek__BackingField;

	[CompilerGenerated]
	private Color _003CBackgroundColor_003Ek__BackingField;

	[CompilerGenerated]
	private object? _003CData_003Ek__BackingField;

	public MainMyOfferType Type
	{
		[CompilerGenerated]
		get
		{
			return _003CType_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CType_003Ek__BackingField != value)
			{
				_003CType_003Ek__BackingField = value;
				RaisePropertyChanged("Type");
			}
		}
	}

	public string TitleText
	{
		[CompilerGenerated]
		get
		{
			return _003CTitleText_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CTitleText_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CTitleText_003Ek__BackingField = value;
				RaisePropertyChanged("TitleText");
			}
		}
	}

	public string DescriptionText
	{
		[CompilerGenerated]
		get
		{
			return _003CDescriptionText_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CDescriptionText_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CDescriptionText_003Ek__BackingField = value;
				RaisePropertyChanged("DescriptionText");
			}
		}
	}

	public string TimeText
	{
		[CompilerGenerated]
		get
		{
			return _003CTimeText_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CTimeText_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CTimeText_003Ek__BackingField = value;
				RaisePropertyChanged("TimeText");
			}
		}
	}

	public string ButtonText
	{
		[CompilerGenerated]
		get
		{
			return _003CButtonText_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CButtonText_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CButtonText_003Ek__BackingField = value;
				RaisePropertyChanged("ButtonText");
			}
		}
	}

	public bool IsNew
	{
		[CompilerGenerated]
		get
		{
			return _003CIsNew_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CIsNew_003Ek__BackingField != value)
			{
				_003CIsNew_003Ek__BackingField = value;
				RaisePropertyChanged("IsNew");
			}
		}
	}

	public bool IsActivated
	{
		[CompilerGenerated]
		get
		{
			return _003CIsActivated_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CIsActivated_003Ek__BackingField != value)
			{
				_003CIsActivated_003Ek__BackingField = value;
				RaisePropertyChanged("IsActivated");
			}
		}
	}

	public Color BackgroundColor
	{
		[CompilerGenerated]
		get
		{
			return _003CBackgroundColor_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!(_003CBackgroundColor_003Ek__BackingField == value))
			{
				_003CBackgroundColor_003Ek__BackingField = value;
				RaisePropertyChanged("BackgroundColor");
			}
		}
	}

	public object? Data
	{
		[CompilerGenerated]
		get
		{
			return _003CData_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003CData_003Ek__BackingField, value))
			{
				_003CData_003Ek__BackingField = value;
				RaisePropertyChanged("Data");
			}
		}
	}

	public HomeMyOfferItemViewModel(MainMyOfferType type, string titleText, string descriptionText, string timeText, string buttonText, bool isNew, bool isActivated, Color backgroundColor, object? data)
	{
		Type = type;
		TitleText = titleText;
		DescriptionText = descriptionText;
		TimeText = timeText;
		ButtonText = buttonText;
		IsNew = isNew;
		IsActivated = isActivated;
		BackgroundColor = backgroundColor;
		Data = data;
	}

	public static HomeMyOfferItemViewModel CreateFavoriteCategories(FavoriteCategoriesItemViewModel valueData)
	{
		return new HomeMyOfferItemViewModel(MainMyOfferType.FavoriteCategories, valueData.Title, valueData.Subtitle, string.Empty, string.Empty, isNew: false, isActivated: false, ColorTranslator.FromHtml("#F0F2F5"), valueData);
	}

	public static HomeMyOfferItemViewModel CreateCoupon(Coupon coupon)
	{
		return new HomeMyOfferItemViewModel(MainMyOfferType.Coupon, coupon.Name, coupon.Description, coupon.ExpiryDate.HasValue ? StringExtensions.Format("до {0}", coupon.ExpiryDate.Value.ToString("dd.MM")) : string.Empty, "Открыть купон", coupon.IsNew, isActivated: false, ColorTranslator.FromHtml(coupon.BackgroundHEXColor), coupon);
	}

	public static HomeMyOfferItemViewModel CreatePersonalOffer(PersOfferItemViewModel offer)
	{
		return new HomeMyOfferItemViewModel(MainMyOfferType.PersonalOffer, offer.Title, offer.Subitle, offer.EndsOn.HasValue ? StringExtensions.Format("до {0}", offer.EndsOn.Value.ToString("dd.MM")) : string.Empty, offer.ActivateLabel, !offer.IsViewed, offer.IsAccepted, offer.BgColor, offer);
	}

	public void SetAccepted()
	{
		ButtonText = "Активировано";
		IsActivated = true;
	}
}
