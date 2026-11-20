using System;
using System.Reflection;

namespace Refit;

public record RestMethodInfo(string Name, Type HostingType, MethodInfo MethodInfo, string RelativePath, Type ReturnType);
