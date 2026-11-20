using System;
using System.Text;

namespace DryIoc;

public sealed class ResolutionScopeName : IScopeName
{
	public readonly Type ServiceType;

	public readonly object ServiceKey;

	public static ResolutionScopeName Of(Type serviceType = null, object serviceKey = null)
	{
		return new ResolutionScopeName(serviceType, serviceKey);
	}

	public static ResolutionScopeName Of<TService>(object serviceKey = null)
	{
		return new ResolutionScopeName(typeof(TService), serviceKey);
	}

	private ResolutionScopeName(Type serviceType, object serviceKey)
	{
		ServiceType = serviceType;
		ServiceKey = serviceKey;
	}

	public bool Match(object scopeName)
	{
		if (scopeName is ResolutionScopeName resolutionScopeName && (ServiceType == null || resolutionScopeName.ServiceType.IsAssignableTo(ServiceType) || (ServiceType.IsOpenGeneric() && resolutionScopeName.ServiceType.GetGenericDefinitionOrNull().IsAssignableTo(ServiceType))))
		{
			if (ServiceKey != null)
			{
				return ServiceKey.Equals(resolutionScopeName.ServiceKey);
			}
			return true;
		}
		return false;
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder().Append("{ServiceType=").Print(ServiceType);
		if (ServiceKey != null)
		{
			stringBuilder.Append(", ServiceKey=").Print(ServiceKey);
		}
		return stringBuilder.Append('}').ToString();
	}
}
