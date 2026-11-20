using Android.Views;
using Android.Widget;

namespace Auchan.Android.Controls;

internal sealed class ChevronRightButtonControls(View view)
{
	public View View => view;

	public TextView TextView { get; } = view.RequireViewById<TextView>(2131296424);
}
