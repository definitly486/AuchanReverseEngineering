using Android.Views;
using Android.Widget;

namespace Auchan.Android.Maintenance;

public sealed class MaintenanceControls(View view)
{
	public View View => view;

	public ImageView Image { get; } = view.RequireViewById<ImageView>(2131297308);

	public TextView Title { get; } = view.RequireViewById<TextView>(2131298646);

	public TextView Message { get; } = view.RequireViewById<TextView>(2131297563);

	public View InfoView { get; } = view.RequireViewById<View>(2131297356);

	public TextView InfoTextView { get; } = view.RequireViewById<TextView>(2131297355);

	public Button RetryButton { get; } = view.RequireViewById<Button>(2131296325);

	public Button QrCodeButton { get; } = view.RequireViewById<Button>(2131298126);
}
