using System;
using System.Text;

namespace DryIoc;

public struct ServiceRegistrationInfo : IComparable<ServiceRegistrationInfo>
{
	public Factory Factory;

	public Type ServiceType;

	public object OptionalServiceKey;

	public int FactoryRegistrationOrder => Factory.RegistrationOrder;

	public Type ImplementationType
	{
		get
		{
			if (!Factory.CanAccessImplementationType)
			{
				return null;
			}
			return Factory.ImplementationType;
		}
	}

	public bool AsResolutionRoot => Factory.Setup.AsResolutionRoot;

	public ServiceInfo ToServiceInfo()
	{
		if (OptionalServiceKey != null)
		{
			return ServiceInfo.Of(ServiceType, OptionalServiceKey);
		}
		return ServiceInfo.Of(ServiceType);
	}

	public ServiceInfo ToServiceInfo(Type serviceType)
	{
		return ServiceInfo.Of(serviceType, ServiceType, IfUnresolved.Throw, OptionalServiceKey);
	}

	public ServiceInfo ToServiceInfo<TService>()
	{
		return ToServiceInfo(typeof(TService));
	}

	public ServiceRegistrationInfo(Factory factory, Type serviceType, object optionalServiceKey)
	{
		Factory = factory;
		ServiceType = serviceType;
		OptionalServiceKey = optionalServiceKey;
	}

	public int CompareTo(ServiceRegistrationInfo other)
	{
		return Factory.FactoryID - other.Factory.FactoryID;
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder("ServiceType=`").Print(ServiceType).Append('`');
		if (OptionalServiceKey != null)
		{
			stringBuilder.Append(" with ServiceKey=`").Print(OptionalServiceKey).Append('`');
		}
		return stringBuilder.Append(" with Factory=`").Append(Factory).Append('`')
			.ToString();
	}
}
