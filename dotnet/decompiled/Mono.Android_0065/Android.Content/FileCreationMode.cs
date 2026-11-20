using System;
using System.Runtime.Versioning;

namespace Android.Content;

[Flags]
public enum FileCreationMode
{
	Append = 0x8000,
	EnableWriteAheadLogging = 8,
	MultiProcess = 4,
	[SupportedOSPlatform("android24.0")]
	NoLocalizedCollators = 0x10,
	Private = 0,
	WorldReadable = 1,
	WorldWriteable = 2
}
