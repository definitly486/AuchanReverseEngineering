using System;
using Auchan.Common.Base;
using Auchan.Common.Ecom.Cart.Models;

namespace Auchan.Common.Ecom.Cart.ViewModels;

public sealed class CheckoutSlotItemViewModel : SelectionItemViewModel<SelectedDateTime, CheckoutViewModel>
{
	public string DayText
	{
		get
		{
			if (!(base.Item.Day.Date.Date <= DateTime.Today.AddDays(1.0)))
			{
				return base.Item.Day.DayOfMonth;
			}
			return base.Item.Day.Day;
		}
	}

	public string TimeText => base.Item.Time.Slot;

	public bool HasSurge => base.Item.Time.HasSurge;

	public bool IsPriceVisible => CheckoutSlotPrice.IsVisible(base.Item.Time.Price);

	public string PriceText => CheckoutSlotPrice.Format(base.Item.Time.Price);

	public CheckoutSlotItemViewModel(SelectedDateTime item, CheckoutViewModel parent, bool selected)
		: base(item, parent, selected)
	{
	}
}
