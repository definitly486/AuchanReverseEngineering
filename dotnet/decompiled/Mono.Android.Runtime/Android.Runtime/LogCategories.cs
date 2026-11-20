using System;

namespace Android.Runtime;

[Flags]
internal enum LogCategories
{
	None = 0,
	Default = 1,
	Assembly = 2,
	Debugger = 4,
	GC = 8,
	GlobalRef = 0x10,
	LocalRef = 0x20,
	Timing = 0x40,
	Bundle = 0x80,
	Net = 0x100,
	Netlink = 0x200
}
