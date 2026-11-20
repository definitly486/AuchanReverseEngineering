using System;
using NLog.Internal;

namespace NLog.Config;

public class ServiceRepositoryUpdateEventArgs : EventArgs
{
	public Type ServiceType { get; }

	public ServiceRepositoryUpdateEventArgs(Type serviceType)
	{
		ServiceType = Guard.ThrowIfNull(serviceType, "serviceType");
	}
}
