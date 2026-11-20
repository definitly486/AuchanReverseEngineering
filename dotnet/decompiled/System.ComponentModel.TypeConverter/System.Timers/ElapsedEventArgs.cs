using System.Runtime.CompilerServices;

namespace System.Timers;

public sealed class ElapsedEventArgs : EventArgs
{
	[CompilerGenerated]
	private readonly DateTime _003CSignalTime_003Ek__BackingField;

	public ElapsedEventArgs(DateTime signalTime)
	{
		_003CSignalTime_003Ek__BackingField = signalTime;
	}
}
