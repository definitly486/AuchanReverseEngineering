using InputMask;

namespace Auchan.Android.Controls.Configuration.Input;

public class PhoneMaskOption
{
	public string PhoneMask { get; }

	public ValueListener ValueListener { get; }

	public PhoneMaskOption(string phoneMask, ValueListener valueListener)
	{
		PhoneMask = phoneMask;
		ValueListener = valueListener;
	}
}
