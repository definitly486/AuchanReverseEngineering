using System;
using System.ComponentModel;

namespace NLog.Config;

[Obsolete("All LayoutRenderer's and Layout's should be ThreadSafe by default. Marked obsolete with NLog 5.0")]
[AttributeUsage(AttributeTargets.Class)]
[EditorBrowsable(EditorBrowsableState.Never)]
public sealed class ThreadSafeAttribute : Attribute
{
}
