using System;
using NLog.Internal;

namespace NLog.Config;

public sealed class NLogDependencyResolveException : Exception
{
	public Type ServiceType { get; }

	public NLogDependencyResolveException(string message, Type serviceType)
		: base(CreateFullMessage(serviceType, message))
	{
		ServiceType = Guard.ThrowIfNull(serviceType, "serviceType");
	}

	public NLogDependencyResolveException(string message, Exception innerException, Type serviceType)
		: base(CreateFullMessage(serviceType, message), innerException)
	{
		ServiceType = Guard.ThrowIfNull(serviceType, "serviceType");
	}

	private static string CreateFullMessage(Type typeToResolve, string message)
	{
		return ("Cannot resolve the type: '" + typeToResolve.Name + "'. " + message).Trim();
	}
}
