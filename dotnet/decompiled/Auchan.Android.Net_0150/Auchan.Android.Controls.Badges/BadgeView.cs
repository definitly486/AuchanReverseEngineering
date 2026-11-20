using Android.Content;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Auchan.Android.Extensions;
using Auchan.Common.Ecom.Badges;

namespace Auchan.Android.Controls.Badges;

public sealed class BadgeView : FrameLayout
{
	public BadgeView(Context context)
		: base(context)
	{
	}

	public BadgeView(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	public BadgeView(Context context, IAttributeSet? attrs)
		: base(context, attrs)
	{
	}

	public BadgeView(Context context, IAttributeSet? attrs, int defStyleAttr)
		: base(context, attrs, defStyleAttr)
	{
	}

	public BadgeView(Context context, IAttributeSet? attrs, int defStyleAttr, int defStyleRes)
		: base(context, attrs, defStyleAttr, defStyleRes)
	{
	}

	public void Setup(BadgeItemViewModel badge)
	{
		RemoveAllViews();
		int resource = badge.Item.BadgeType switch
		{
			BadgeType.Cashback => 2131492933, 
			BadgeType.DelayedCashback => 2131492936, 
			BadgeType.ExpressPoints => 2131492938, 
			BadgeType.Stamps => 2131492945, 
			BadgeType.NPlusOne => badge.IsCompact ? 2131492940 : 2131492939, 
			BadgeType.Discount => 2131492937, 
			BadgeType.PriceDown => 2131492942, 
			BadgeType.NewProduct => 2131492941, 
			BadgeType.PrivateLabel => 2131492943, 
			BadgeType.Combo => 2131492934, 
			BadgeType.ProgressiveDiscount => 2131492944, 
			_ => 2131492935, 
		};
		View view = LayoutInflater.From(base.Context).Inflate(resource, this, attachToRoot: true);
		TextView textView = view.FindViewById<TextView>(2131296503);
		if (textView != null)
		{
			textView.Text = (badge.IsCompact ? badge.Item.ShortDisplayValue : badge.Item.DisplayValue);
		}
		if (!string.IsNullOrEmpty(badge.Item.SecondLine))
		{
			TextView textView2 = view.FindViewById<TextView>(2131296502);
			if (textView2 != null)
			{
				textView2.Text = badge.Item.SecondLine;
			}
		}
		if (!string.IsNullOrEmpty(badge.Item.ImageUrl))
		{
			view.FindViewById<ImageView>(2131296501)?.FromUrl(badge.Item.ImageUrl);
		}
	}
}
