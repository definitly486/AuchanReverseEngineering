using System;
using System.Collections.Generic;
using Android.Content;
using Android.Text.Method;
using Android.Views;
using Android.Widget;
using AndroidX.Core.Text;
using AndroidX.ViewPager.Widget;
using Java.Lang;
using Me.Relex.CircleIndicatorLib;

namespace Auchan.Android.LoyaltyProgram;

internal class LoyaltyPagerAdapter : PagerAdapter
{
	private readonly Context _context;

	private readonly CircleIndicator _indicator;

	private IReadOnlyList<string> _items;

	public IReadOnlyList<string> Items
	{
		get
		{
			return _items;
		}
		set
		{
			_items = value ?? Array.Empty<string>();
			_indicator.CreateIndicators(_items.Count, 0);
			NotifyDataSetChanged();
		}
	}

	public override int Count => Items.Count;

	public LoyaltyPagerAdapter(Context context, CircleIndicator indicator)
	{
		_context = context;
		_indicator = indicator;
		_items = Array.Empty<string>();
	}

	public override bool IsViewFromObject(View view, Java.Lang.Object @object)
	{
		return view == @object;
	}

	public override Java.Lang.Object InstantiateItem(ViewGroup container, int position)
	{
		TextView textView = (TextView)LayoutInflater.FromContext(_context).Inflate(2131493254, null);
		textView.TextFormatted = HtmlCompat.FromHtml(Items[position], 0);
		textView.MovementMethod = LinkMovementMethod.Instance;
		((ViewPager)container).AddView(textView);
		return textView;
	}

	public override void DestroyItem(ViewGroup container, int position, Java.Lang.Object @object)
	{
		((ViewPager)container).RemoveView(@object as View);
	}
}
