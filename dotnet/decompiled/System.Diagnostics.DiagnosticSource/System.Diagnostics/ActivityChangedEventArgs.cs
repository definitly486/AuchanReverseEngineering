using System.Runtime.CompilerServices;

namespace System.Diagnostics;

public readonly struct ActivityChangedEventArgs
{
	[CompilerGenerated]
	private readonly Activity _003CPrevious_003Ek__BackingField;

	[CompilerGenerated]
	private readonly Activity _003CCurrent_003Ek__BackingField;

	public Activity? Previous
	{
		[CompilerGenerated]
		init
		{
			_003CPrevious_003Ek__BackingField = value;
		}
	}

	public Activity? Current
	{
		[CompilerGenerated]
		init
		{
			_003CCurrent_003Ek__BackingField = value;
		}
	}

	internal ActivityChangedEventArgs(Activity previous, Activity current)
	{
		Previous = previous;
		Current = current;
	}
}
