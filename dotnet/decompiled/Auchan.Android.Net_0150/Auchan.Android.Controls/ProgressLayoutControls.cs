using Android.Views;
using Android.Widget;

namespace Auchan.Android.Controls;

internal sealed class ProgressLayoutControls(View view)
{
	public View Layout => view;

	public TextView Title { get; } = view.RequireViewById<TextView>(2131298080);

	public SkottieAnimationView Animation { get; } = view.RequireViewById<SkottieAnimationView>(2131298078);
}
