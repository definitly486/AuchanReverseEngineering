using Android.Views;
using Android.Widget;
using Google.Android.Material.TextField;

namespace Auchan.Android.Controls;

internal sealed class TextFieldControls(View view)
{
	public enum EndIconVisibility
	{
		None,
		Warning,
		Clear
	}

	public View View => view;

	public View Background { get; } = view.RequireViewById<View>(2131298611);

	public TextInputLayout InputLayout { get; } = view.RequireViewById<TextInputLayout>(2131298610);

	public TextInputEditText EditText { get; } = view.RequireViewById<TextInputEditText>(2131298609);

	public ImageButton ClearButton { get; } = view.RequireViewById<ImageButton>(2131298608);

	public ImageButton WarningButton { get; } = view.RequireViewById<ImageButton>(2131298612);

	public TextView ErrorMessage { get; } = view.RequireViewById<TextView>(2131298626);

	public void SetEndIconVisibility(EndIconVisibility visibility)
	{
		switch (visibility)
		{
		case EndIconVisibility.None:
			WarningButton.Visibility = ViewStates.Gone;
			ClearButton.Visibility = ViewStates.Gone;
			break;
		case EndIconVisibility.Clear:
			WarningButton.Visibility = ViewStates.Gone;
			ClearButton.Visibility = ViewStates.Visible;
			break;
		case EndIconVisibility.Warning:
			WarningButton.Visibility = ViewStates.Visible;
			ClearButton.Visibility = ViewStates.Gone;
			break;
		}
	}
}
