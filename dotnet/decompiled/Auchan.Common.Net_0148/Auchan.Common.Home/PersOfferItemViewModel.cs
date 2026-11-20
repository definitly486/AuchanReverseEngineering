using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using Auchan.Common.AdminTool;
using Auchan.Common.Base;
using Auchan.Common.PersonalOffers.DTO;

namespace Auchan.Common.Home;

public class PersOfferItemViewModel : BaseItemViewModel, IEquatable<PersOfferItemViewModel>
{
	public const string ActivateString = "Активировать";

	public const string ActivatedString = "Активировано";

	private readonly IAdminContext? _adminContext;

	[CompilerGenerated]
	private string _003CCode_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CIsAiOffer_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CLoymaxId_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CImageUrl_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CTitle_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CSubitle_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CDetailsTitle_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CDetailsText_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CProductGimaIds_003Ek__BackingField;

	[CompilerGenerated]
	private OfferDisplayType _003CDisplayType_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CTimePeriod_003Ek__BackingField;

	[CompilerGenerated]
	private DateTime? _003CEndsOn_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CIsViewed_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CIsAccepted_003Ek__BackingField;

	public string ActivateLabel
	{
		get
		{
			if (!IsAccepted)
			{
				return "Активировать";
			}
			return "Активировано";
		}
	}

	public string Code
	{
		[CompilerGenerated]
		get
		{
			return _003CCode_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(_003CCode_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CCode_003Ek__BackingField = value;
				RaisePropertyChanged("Code");
			}
		}
	}

	public bool IsAiOffer
	{
		[CompilerGenerated]
		get
		{
			return _003CIsAiOffer_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (_003CIsAiOffer_003Ek__BackingField != value)
			{
				_003CIsAiOffer_003Ek__BackingField = value;
				RaisePropertyChanged("IsAiOffer");
			}
		}
	}

	public Color BgColor { get; }

	public string LoymaxId
	{
		[CompilerGenerated]
		get
		{
			return _003CLoymaxId_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(_003CLoymaxId_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CLoymaxId_003Ek__BackingField = value;
				RaisePropertyChanged("LoymaxId");
			}
		}
	}

	public string ImageUrl
	{
		[CompilerGenerated]
		get
		{
			return _003CImageUrl_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(_003CImageUrl_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CImageUrl_003Ek__BackingField = value;
				RaisePropertyChanged("ImageUrl");
			}
		}
	}

	public string Title
	{
		[CompilerGenerated]
		get
		{
			return _003CTitle_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(_003CTitle_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CTitle_003Ek__BackingField = value;
				RaisePropertyChanged("Title");
			}
		}
	}

	public string Subitle
	{
		[CompilerGenerated]
		get
		{
			return _003CSubitle_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(_003CSubitle_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CSubitle_003Ek__BackingField = value;
				RaisePropertyChanged("Subitle");
			}
		}
	}

	public string DetailsTitle
	{
		[CompilerGenerated]
		get
		{
			return _003CDetailsTitle_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(_003CDetailsTitle_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CDetailsTitle_003Ek__BackingField = value;
				RaisePropertyChanged("DetailsTitle");
			}
		}
	}

	public string DetailsText
	{
		[CompilerGenerated]
		get
		{
			return _003CDetailsText_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(_003CDetailsText_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CDetailsText_003Ek__BackingField = value;
				RaisePropertyChanged("DetailsText");
			}
		}
	}

	public string ProductGimaIds
	{
		[CompilerGenerated]
		get
		{
			return _003CProductGimaIds_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(_003CProductGimaIds_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CProductGimaIds_003Ek__BackingField = value;
				RaisePropertyChanged("ProductGimaIds");
			}
		}
	}

	public OfferDisplayType DisplayType
	{
		[CompilerGenerated]
		get
		{
			return _003CDisplayType_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (_003CDisplayType_003Ek__BackingField != value)
			{
				_003CDisplayType_003Ek__BackingField = value;
				RaisePropertyChanged("DisplayType");
			}
		}
	}

	public string TimePeriod
	{
		[CompilerGenerated]
		get
		{
			return _003CTimePeriod_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(_003CTimePeriod_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CTimePeriod_003Ek__BackingField = value;
				RaisePropertyChanged("TimePeriod");
			}
		}
	}

	public DateTime? EndsOn
	{
		[CompilerGenerated]
		get
		{
			return _003CEndsOn_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!Nullable.Equals(_003CEndsOn_003Ek__BackingField, value))
			{
				_003CEndsOn_003Ek__BackingField = value;
				RaisePropertyChanged("EndsOn");
			}
		}
	}

	public bool IsViewed
	{
		[CompilerGenerated]
		get
		{
			return _003CIsViewed_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (_003CIsViewed_003Ek__BackingField != value)
			{
				_003CIsViewed_003Ek__BackingField = value;
				RaisePropertyChanged("IsViewed");
			}
		}
	}

	public bool IsAccepted
	{
		[CompilerGenerated]
		get
		{
			return _003CIsAccepted_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (_003CIsAccepted_003Ek__BackingField != value)
			{
				_003CIsAccepted_003Ek__BackingField = value;
				RaisePropertyChanged("ActivateLabel");
				RaisePropertyChanged("IsAccepted");
			}
		}
	}

	public PersOfferItemViewModel(PersonalOfferDto offer, IAdminContext adminContext)
	{
		_adminContext = adminContext;
		IsAiOffer = false;
		Code = offer.Code;
		LoymaxId = offer.LoymaxId;
		ImageUrl = offer.Image;
		Title = offer.Title;
		Subitle = offer.Subtitle;
		DetailsText = offer.Text;
		DetailsTitle = "";
		ProductGimaIds = "";
		DisplayType = offer.OfferType switch
		{
			PersOfferType.Discount => OfferDisplayType.Discount, 
			PersOfferType.Cashback => OfferDisplayType.Cashback, 
			_ => OfferDisplayType.Unknown, 
		};
		IsAccepted = offer.Accepted;
		BgColor = ColorTranslator.FromHtml(offer.BackgroundHex);
		EndsOn = offer.EndsOn;
		if (offer.EndsOn.HasValue)
		{
			TimePeriod = $"до {offer.EndsOn:dd.MM}";
		}
		else
		{
			TimePeriod = "";
		}
		Update();
	}

	public PersOfferItemViewModel(AIPersOfferDto offer, IAdminContext adminContext)
	{
		_adminContext = adminContext;
		IsAiOffer = true;
		Code = offer.Code;
		LoymaxId = offer.Code;
		ImageUrl = offer.Image;
		Title = offer.Title;
		Subitle = offer.Subtitle;
		DetailsText = offer.DetailsDescription;
		DetailsTitle = offer.DetailsTitle;
		ProductGimaIds = offer.GimaIds;
		DisplayType = offer.LoymaxOfferType switch
		{
			LoymaxOfferType.CheckAmountCashbackNoLimit => OfferDisplayType.Cashback, 
			LoymaxOfferType.CheckAmountCashback => OfferDisplayType.Cashback, 
			LoymaxOfferType.CashbackPercentCategory => OfferDisplayType.Cashback, 
			LoymaxOfferType.CashbackPercentGoods => OfferDisplayType.Cashback, 
			LoymaxOfferType.CheckAmountDiscountNoLimit => OfferDisplayType.Discount, 
			LoymaxOfferType.CheckAmountDiscount => OfferDisplayType.Discount, 
			LoymaxOfferType.DiscountPercentCategory => OfferDisplayType.Discount, 
			LoymaxOfferType.DiscountPercentGoods => OfferDisplayType.Discount, 
			LoymaxOfferType.CheckAmountFixDiscountNoLimit => OfferDisplayType.Discount, 
			_ => OfferDisplayType.Unknown, 
		};
		IsAccepted = true;
		BgColor = ColorTranslator.FromHtml(offer.BackgroundHex);
		EndsOn = offer.EndsOn;
		if (offer.EndsOn.HasValue)
		{
			TimePeriod = $"до {offer.EndsOn:dd.MM}";
		}
		else
		{
			TimePeriod = "";
		}
		Update();
	}

	public override string ToString()
	{
		return $"{Code}: {Title} ({IsAccepted})";
	}

	public bool Equals(PersOfferItemViewModel other)
	{
		if (other == null)
		{
			return false;
		}
		if (!string.IsNullOrEmpty(LoymaxId))
		{
			if (IsViewed == other.IsViewed && Code.Equals(other.Code) && LoymaxId.Equals(other.LoymaxId) && IsAccepted == other.IsAccepted)
			{
				return IsAiOffer == other.IsAiOffer;
			}
			return false;
		}
		return false;
	}

	public void Update()
	{
		IsViewed = _adminContext?.IsMyOfferViewed(Code) ?? true;
	}

	public void SetAccepted()
	{
		IsAccepted = true;
	}
}
