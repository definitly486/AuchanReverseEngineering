using System;

namespace Akavache.Internal;

[Flags]
public enum FileAccess
{
	Read = 1,
	Write = 2,
	ReadWrite = 3
}
