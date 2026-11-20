using System.Runtime.CompilerServices;

namespace System.Diagnostics;

public sealed class InitializingSwitchEventArgs : EventArgs
{
	[CompilerGenerated]
	private readonly Switch _003CSwitch_003Ek__BackingField;

	public InitializingSwitchEventArgs(Switch @switch)
	{
		_003CSwitch_003Ek__BackingField = @switch;
	}
}
