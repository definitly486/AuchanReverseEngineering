using Android.Content;
using Android.Graphics;
using Android.Util;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.Widget;
using AndroidX.Core.Content;
using AndroidX.Core.Widget;
using Auchan.Android.Base;

namespace Auchan.Android.Controls;

public class CounterBadgeView : LinearLayout
{
	private const int BadgeWidthDp = 26;

	private const int BadgeHeightDp = 18;

	private readonly AppCompatTextView _textView;

	public CounterBadgeView(Context context)
		: base(context)
	{
		_textView = CreateLabel(context);
		Initialize();
	}

	public CounterBadgeView(Context context, IAttributeSet attrs)
		: base(context, attrs)
	{
		_textView = CreateLabel(context);
		Initialize();
	}

	public CounterBadgeView(Context context, IAttributeSet attrs, int defStyleAttr)
		: base(context, attrs, defStyleAttr)
	{
		_textView = CreateLabel(context);
		Initialize();
	}

	private void Initialize()
	{
		Orientation = Orientation.Vertical;
		SetGravity(GravityFlags.Center);
		SetBackgroundResource(2131230959);
		int minimumWidth = Converter.DpToPx(26f);
		int minimumHeight = Converter.DpToPx(18f);
		SetMinimumHeight(minimumHeight);
		SetMinimumWidth(minimumWidth);
		SetPadding(0, 0, 0, 0);
		AddView(_textView);
		Visibility = ViewStates.Gone;
	}

	private static AppCompatTextView CreateLabel(Context context)
	{
		AppCompatTextView appCompatTextView = new AppCompatTextView(context);
		appCompatTextView.LayoutParameters = new LayoutParams(-2, -2);
		appCompatTextView.Gravity = GravityFlags.Center;
		appCompatTextView.TextAlignment = TextAlignment.Center;
		int color = ContextCompat.GetColor(context, 2131099697);
		appCompatTextView.SetTextColor(new Color(color));
		appCompatTextView.SetTextSize(ComplexUnitType.Sp, 12f);
		appCompatTextView.SetTypeface(appCompatTextView.Typeface, TypefaceStyle.Bold);
		appCompatTextView.SetIncludeFontPadding(includepad: false);
		TextViewCompat.SetAutoSizeTextTypeUniformWithConfiguration(appCompatTextView, 6, 12, 1, 2);
		return appCompatTextView;
	}

	public void SetValue(int value)
	{
		if (value <= 0)
		{
			Visibility = ViewStates.Gone;
			return;
		}
		Visibility = ViewStates.Visible;
		_textView.Text = ((value > 9) ? "9+" : value.ToString());
	}

	protected override void OnMeasure(int widthMeasureSpec, int heightMeasureSpec)
	{
		int num = Converter.DpToPx(26f);
		int num2 = Converter.DpToPx(18f);
		int widthMeasureSpec2 = MeasureSpec.MakeMeasureSpec(num, MeasureSpecMode.Exactly);
		int heightMeasureSpec2 = MeasureSpec.MakeMeasureSpec(num2, MeasureSpecMode.Exactly);
		base.OnMeasure(widthMeasureSpec2, heightMeasureSpec2);
		SetMeasuredDimension(num, num2);
	}
}
