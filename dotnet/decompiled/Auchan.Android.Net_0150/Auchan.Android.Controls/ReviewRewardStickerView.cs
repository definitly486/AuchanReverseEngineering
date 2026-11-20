using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Runtime;
using Android.Text;
using Android.Util;
using Android.Views;
using AndroidX.AppCompat.Widget;
using AndroidX.Core.Widget;
using Auchan.Android.Base;
using Auchan.Common.Ecom.ProducModels;

namespace Auchan.Android.Controls;

[Register("auchan.ReviewRewardStickerView")]
public sealed class ReviewRewardStickerView : AppCompatTextView
{
	public ReviewRewardStickerView(Context context)
		: base(context)
	{
		Initialize();
	}

	public ReviewRewardStickerView(Context context, IAttributeSet? attrs)
		: base(context, attrs)
	{
		Initialize();
	}

	public ReviewRewardStickerView(Context context, IAttributeSet? attrs, int defStyleAttr)
		: base(context, attrs, defStyleAttr)
	{
		Initialize();
	}

	private void Initialize()
	{
		Gravity = GravityFlags.Center;
		TextViewCompat.SetTextAppearance(this, 2131952216);
		SetIncludeFontPadding(includepad: false);
		LetterSpacing = 0f;
		SetPadding(Converter.DpToPx(6f), Converter.DpToPx(1f), Converter.DpToPx(6f), Converter.DpToPx(1f));
		SetSingleLine(singleLine: true);
		TextViewCompat.SetLineHeight(this, Converter.SpToPx(14f));
		SetMinimumHeight(Converter.SpToPx(14f) + PaddingTop + PaddingBottom);
		Ellipsize = TextUtils.TruncateAt.End;
		Visibility = ViewStates.Gone;
	}

	public void Setup(ReviewRewardSticker? sticker)
	{
		if (sticker == null || !TryParseColor(sticker.TextColor, out var color) || !TryParseColor(sticker.BackgroundColor, out var color2))
		{
			base.Text = string.Empty;
			Visibility = ViewStates.Gone;
			return;
		}
		base.Text = sticker.Text;
		SetTextColor(color);
		GradientDrawable gradientDrawable = new GradientDrawable();
		gradientDrawable.SetCornerRadius(Converter.DpToPx(3f));
		gradientDrawable.SetColor(color2);
		Background = gradientDrawable;
		Visibility = ViewStates.Visible;
	}

	private static bool TryParseColor(string value, out Color color)
	{
		try
		{
			color = Color.ParseColor(value);
			return true;
		}
		catch
		{
			color = Color.Transparent;
			return false;
		}
	}
}
