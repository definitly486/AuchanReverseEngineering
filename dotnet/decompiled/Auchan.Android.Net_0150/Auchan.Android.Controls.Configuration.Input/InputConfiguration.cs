using Android.Text;

namespace Auchan.Android.Controls.Configuration.Input;

public abstract class InputConfiguration
{
	public abstract InputTypes InputType { get; }

	public abstract string InitialPlaceHolder { get; set; }
}
