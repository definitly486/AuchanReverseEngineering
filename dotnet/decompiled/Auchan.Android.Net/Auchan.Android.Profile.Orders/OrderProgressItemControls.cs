using Android.Content.Res;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Views;
using Android.Widget;
using AndroidX.CardView.Widget;
using AndroidX.Core.Content.Resources;
using Auchan.Android.Base;
using Auchan.Android.Extensions;
using Auchan.Android.Profile.Orders.Extensions;
using Auchan.Common.Profile.Orders;

namespace Auchan.Android.Profile.Orders;

internal sealed class OrderProgressItemControls(View view, bool showText)
{
	private readonly CardView _background = view.RequireViewById<CardView>(2131296491);

	private readonly ImageView _image = view.RequireViewById<ImageView>(2131297319);

	private readonly TextView _text = view.RequireViewById<TextView>(2131298603);

	private readonly View _left = view.RequireViewById<View>(2131297426);

	private readonly View _right = view.RequireViewById<View>(2131298245);

	public void Bind(LinearLayout progressBar, OrderProgressViewModel.Item item, Color backgroundColorPassed, Color backgroundColorToBe, Resources resources)
	{
		_text.Text = item.Title;
		_text.Visibility = showText.ToVisibility();
		_right.Visibility = item.RightVisible.ToVisibility();
		if (item.State == OrderProgressViewModel.State.Current)
		{
			_right.Background = new GradientDrawable(GradientDrawable.Orientation.LeftRight, new int[3]
			{
				backgroundColorPassed.ToArgb(),
				-14764932,
				backgroundColorToBe.ToArgb()
			});
		}
		else
		{
			_right.Background = new ColorDrawable((item.State < OrderProgressViewModel.State.Current) ? backgroundColorPassed : backgroundColorToBe);
		}
		_left.Visibility = item.LeftVisible.ToVisibility();
		_left.Background = new ColorDrawable((item.State <= OrderProgressViewModel.State.Current) ? backgroundColorPassed : backgroundColorToBe);
		_background.BackgroundTintList = ColorStateList.ValueOf((item.State <= OrderProgressViewModel.State.Current) ? backgroundColorPassed : backgroundColorToBe);
		_image.SetImageResource(item.ItemType.ToIconResourceId());
		_image.SetColorFilter(new Color(ResourcesCompat.GetColor(resources, (item.State <= OrderProgressViewModel.State.Current) ? 2131099697 : 2131099849, null)));
		progressBar.AddView(view);
		if (item.RightVisible)
		{
			View child = new View(progressBar.Context)
			{
				Id = View.GenerateViewId(),
				Background = new ColorDrawable((item.State < OrderProgressViewModel.State.Current) ? backgroundColorPassed : backgroundColorToBe)
			};
			progressBar.AddView(child, new LinearLayout.LayoutParams(0, Converter.DpToPx(4f))
			{
				Weight = 10f,
				TopMargin = Converter.DpToPx(14f),
				Gravity = GravityFlags.Top
			});
		}
	}
}
