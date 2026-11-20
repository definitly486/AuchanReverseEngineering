using System;
using JetBrains.Annotations;

namespace NLog.Config;

[AttributeUsage(AttributeTargets.Class)]
[MeansImplicitUse]
public sealed class NLogConfigurationItemAttribute : Attribute
{
}
