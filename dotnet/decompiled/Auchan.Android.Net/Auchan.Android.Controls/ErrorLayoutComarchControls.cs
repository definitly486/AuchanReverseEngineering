using Android.Views;
using Android.Widget;

namespace Auchan.Android.Controls;

internal sealed class ErrorLayoutComarchControls(View view)
{
	public View View => view;

	public TextView Title { get; } = view.RequireViewById<TextView>(2131298646);

	public TextView Message { get; } = view.RequireViewById<TextView>(2131296809);

	public TextView Description { get; } = view.RequireViewById<TextView>(2131296808);

	public ImageView Image { get; } = view.RequireViewById<ImageView>(2131296807);
}
