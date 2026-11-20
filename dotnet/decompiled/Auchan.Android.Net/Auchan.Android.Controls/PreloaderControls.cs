using Android.Views;

namespace Auchan.Android.Controls;

internal sealed class PreloaderControls(View view)
{
	public View View => view;

	public View DefaultLayout { get; } = view.RequireViewById<View>(2131296904);

	public ErrorLayoutControls Error { get; } = new ErrorLayoutControls(view.RequireViewById<View>(2131297111));

	public ProgressLayoutControls Progress { get; } = new ProgressLayoutControls(view.RequireViewById<View>(2131298079));
}
