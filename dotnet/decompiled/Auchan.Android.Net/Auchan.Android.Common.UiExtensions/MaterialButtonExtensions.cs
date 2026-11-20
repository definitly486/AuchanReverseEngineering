using Google.Android.Material.Button;

namespace Auchan.Android.Common.UiExtensions;

public static class MaterialButtonExtensions
{
	public static void ForceChecked(this MaterialButton button, bool check)
	{
		if (button.Checkable)
		{
			button.Checked = check;
			return;
		}
		button.Checkable = true;
		button.Checked = check;
		button.Checkable = false;
	}
}
