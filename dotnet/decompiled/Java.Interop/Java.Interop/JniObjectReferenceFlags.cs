using System;

namespace Java.Interop;

[Flags]
internal enum JniObjectReferenceFlags : uint
{
	None = 0u,
	Alloc = 0x10000u
}
