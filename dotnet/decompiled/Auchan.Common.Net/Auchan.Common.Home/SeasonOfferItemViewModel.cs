using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using Auchan.Common.AdminTool;
using Auchan.Common.Deeplinks;

namespace Auchan.Common.Home;

public class SeasonOfferItemViewModel : INotifyPropertyChanged, IEquatable<SeasonOfferItemViewModel>
{
	public int Id => Promotion.Id;

	public string ImageUrl => Promotion.Picture;

	public PromotionKind PromotionKind => Promotion.PromotionKind;

	public DeeplinkType? Deeplink => Promotion.Deeplink;

	public string? DeeplinkId => Promotion.DeeplinkId;

	public Promotion Promotion { get; }

	public event PropertyChangedEventHandler? PropertyChanged;

	public SeasonOfferItemViewModel(Promotion promotion)
	{
		Promotion = promotion;
	}

	public bool Equals(SeasonOfferItemViewModel other)
	{
		if (other == null)
		{
			return false;
		}
		return Promotion.Equals(other.Promotion);
	}

	[GeneratedCode("PropertyChanged.Fody", "4.1.0.0")]
	[DebuggerNonUserCode]
	protected void _003C_003EOnPropertyChanged(PropertyChangedEventArgs eventArgs)
	{
		this.PropertyChanged?.Invoke(this, eventArgs);
	}
}
