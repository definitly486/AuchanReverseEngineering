using Android.Text;

namespace Auchan.Android.Controls.Configuration.Input;

public class PhoneInputConfiguration : InputConfiguration
{
	public override InputTypes InputType => InputTypes.ClassPhone;

	public override string InitialPlaceHolder { get; set; }

	public PhoneMaskOption? MaskOptions { get; set; }
}
