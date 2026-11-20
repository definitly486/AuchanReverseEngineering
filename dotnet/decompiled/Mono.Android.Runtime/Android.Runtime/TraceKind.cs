using System;

namespace Android.Runtime;

[Flags]
internal enum TraceKind : uint
{
	Java = 1u,
	Managed = 2u,
	Native = 4u,
	Signals = 8u,
	All = 0xFu
}
