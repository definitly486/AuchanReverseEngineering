using System;

namespace NLog.Config;

[Obsolete("Attribute is no longer used. Obsolete with NLog 5.0")]
[AttributeUsage(AttributeTargets.Property)]
public sealed class AdvancedAttribute : Attribute
{
}
