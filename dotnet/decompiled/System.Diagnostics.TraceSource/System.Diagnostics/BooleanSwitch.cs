namespace System.Diagnostics;

[SwitchLevel(typeof(bool))]
public class BooleanSwitch : Switch
{
	public bool Enabled => base.SwitchSetting != 0;

	public BooleanSwitch(string displayName, string? description)
		: base(displayName, description)
	{
	}

	protected override void OnValueChanged()
	{
		if (bool.TryParse(base.Value, out var result))
		{
			base.SwitchSetting = (result ? 1 : 0);
		}
		else
		{
			base.OnValueChanged();
		}
	}
}
