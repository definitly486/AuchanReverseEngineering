using System;
using JetBrains.Annotations;

namespace NLog.Config;

[AttributeUsage(AttributeTargets.Property)]
[MeansImplicitUse]
[Obsolete("Instead perform relevant config validation in InitializeTarget / InitializeLayout. Marked obsolete with NLog v6.0")]
public sealed class RequiredParameterAttribute : Attribute
{
}
