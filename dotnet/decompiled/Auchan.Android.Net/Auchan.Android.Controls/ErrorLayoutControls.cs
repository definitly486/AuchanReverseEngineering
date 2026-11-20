using Android.Views;
using Android.Widget;

namespace Auchan.Android.Controls;

internal sealed class ErrorLayoutControls(View view)
{
	public View Layout => view;

	public TextView Title { get; } = view.RequireViewById<TextView>(2131298646);

	public TextView Message { get; } = view.RequireViewById<TextView>(2131297563);

	public TextView Action { get; } = view.RequireViewById<TextView>(2131296325);

	public Button ShowQrButton { get; } = view.RequireViewById<Button>(2131298371);
}
