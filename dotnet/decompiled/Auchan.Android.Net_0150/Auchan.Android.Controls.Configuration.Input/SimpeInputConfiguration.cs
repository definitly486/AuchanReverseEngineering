using Android.Text;

namespace Auchan.Android.Controls.Configuration.Input;

public class SimpeInputConfiguration : InputConfiguration
{
	public override InputTypes InputType => InputTypes.ClassNumber;

	public override string InitialPlaceHolder { get; set; }
}
