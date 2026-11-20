using System;
using System.ComponentModel;

namespace NLog.Config;

[Obsolete("Marked obsolete on NLog 5.3, instead use ThreadAgnosticImmutableAttribute")]
[AttributeUsage(AttributeTargets.Class)]
[EditorBrowsable(EditorBrowsableState.Never)]
public sealed class MutableUnsafeAttribute : Attribute
{
}
