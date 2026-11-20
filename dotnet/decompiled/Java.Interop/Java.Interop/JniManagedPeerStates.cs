using System;

namespace Java.Interop;

[Flags]
public enum JniManagedPeerStates
{
	None = 0,
	Activatable = 1,
	Replaceable = 2
}
