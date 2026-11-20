using System;
using System.Runtime.CompilerServices;
using Auchan.Common.AdminTool;
using Auchan.Common.Base;
using Auchan.Common.Deeplinks;

namespace Auchan.Common.Home;

public class PromotionItemViewModel : BaseItemViewModel, IEquatable<PromotionItemViewModel>
{
	private readonly IAdminContext? _adminContext;

	[CompilerGenerated]
	private bool _003CIsViewed_003Ek__BackingField;

	public int Id => Promotion.Id;

	public string ImageUrl => Promotion.Picture;

	public PromotionKind PromotionKind => Promotion.PromotionKind;

	public DeeplinkType? Deeplink => Promotion.Deeplink;

	public string? DeeplinkId => Promotion.DeeplinkId;

	public string Name => Promotion.Name;

	public string TimePeriod { get; }

	public DateTime EndsOn { get; }

	public Promotion Promotion { get; }

	public int Position { get; }

	public bool IsViewed
	{
		[CompilerGenerated]
		get
		{
			return _003CIsViewed_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CIsViewed_003Ek__BackingField != value)
			{
				_003CIsViewed_003Ek__BackingField = value;
				RaisePropertyChanged("IsViewed");
			}
		}
	}

	public PromotionItemViewModel(Promotion promotion, int position = 0, IAdminContext? adminContext = null)
	{
		_adminContext = adminContext;
		Promotion = promotion;
		Position = position;
		EndsOn = promotion.EndsOn;
		TimePeriod = $"с {promotion.BeginsOn:dd.MM.yyyy} до {promotion.EndsOn:dd.MM.yyyy}";
		Update();
	}

	public override string ToString()
	{
		return $"{Id}: {Name}";
	}

	public bool Equals(PromotionItemViewModel? other)
	{
		if (other == null)
		{
			return false;
		}
		if (IsViewed == other.IsViewed)
		{
			return Promotion.Equals(other.Promotion);
		}
		return false;
	}

	public void Update()
	{
		IsViewed = _adminContext?.IsBannerViewed(Id) ?? true;
	}
}
