using System;
using JetBrains.Annotations;

namespace NLog.Config;

[AttributeUsage(AttributeTargets.Property)]
[MeansImplicitUse]
public sealed class DefaultParameterAttribute : Attribute
{
}
