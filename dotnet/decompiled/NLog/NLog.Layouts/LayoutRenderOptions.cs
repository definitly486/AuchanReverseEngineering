using System;

namespace NLog.Layouts;

[Flags]
public enum LayoutRenderOptions
{
	None = 0,
	[Obsolete("All LayoutRenderers and Layout should be ThreadSafe by default. Marked obsolete with NLog 5.0")]
	ThreadSafe = 1,
	ThreadAgnostic = 3
}
