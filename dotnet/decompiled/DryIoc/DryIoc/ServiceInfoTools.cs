using System;
using System.Runtime.CompilerServices;
using System.Text;

namespace DryIoc;

public static class ServiceInfoTools
{
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static ServiceInfo WithType(this ServiceInfo source, Type serviceType)
	{
		return source.Create(serviceType, source.Details);
	}

	public static ServiceInfo WithIfUnresolved(this ServiceInfo source, IfUnresolved ifUnresolved)
	{
		ServiceDetails details = source.Details;
		if (details.IfUnresolved == ifUnresolved || details.HasCustomValue)
		{
			return source;
		}
		return source.Create(details: (details != ServiceDetails.Default) ? ServiceDetails.Of(details.RequiredServiceType, details.ServiceKey, ifUnresolved, details.DefaultValue, details.MetadataKey, details.Metadata) : ((ifUnresolved == IfUnresolved.ReturnDefault) ? ServiceDetails.IfUnresolvedReturnDefault : ServiceDetails.IfUnresolvedReturnDefaultIfNotRegistered), serviceType: source.ServiceType);
	}

	public static T WithDetails<T>(this T serviceInfo, ServiceDetails details) where T : ServiceInfo
	{
		details = details ?? ServiceDetails.Default;
		ServiceDetails details2 = serviceInfo.Details;
		if (!details.HasCustomValue && details2 != ServiceDetails.Default && details2 != details)
		{
			object serviceKey = details.ServiceKey ?? details2.ServiceKey;
			string text = details.MetadataKey ?? details2.MetadataKey;
			object metadata = ((text == details.MetadataKey) ? details.Metadata : details2.Metadata);
			object defaultValue = details.DefaultValue ?? details2.DefaultValue;
			details = ServiceDetails.Of(details.RequiredServiceType, serviceKey, details.IfUnresolved, defaultValue, text, metadata);
		}
		Type serviceType = serviceInfo.ServiceType;
		Type requiredServiceType = details.RequiredServiceType;
		if (requiredServiceType != null && requiredServiceType == serviceType)
		{
			details = ServiceDetails.Of(null, details.ServiceKey, details.IfUnresolved, details.DefaultValue, details.MetadataKey, details.Metadata);
		}
		if (!(serviceType == serviceInfo.ServiceType) || (details != null && details != serviceInfo.Details))
		{
			return (T)serviceInfo.Create(serviceType, details);
		}
		return serviceInfo;
	}

	public static ServiceInfo InheritInfoFromDependencyOwner(this ServiceInfo dependency, Type ownerServiceType, ServiceDetails ownerDetails, IContainer container, FactoryType ownerType = FactoryType.Service)
	{
		ServiceDetails details = dependency.Details;
		IfUnresolved ifUnresolved = ownerDetails.IfUnresolved;
		IfUnresolved ifUnresolved2 = details.IfUnresolved;
		if (ifUnresolved == IfUnresolved.ReturnDefault)
		{
			ifUnresolved2 = ifUnresolved;
		}
		Type serviceType = dependency.ServiceType;
		Type type = details.RequiredServiceType;
		object serviceKey = details.ServiceKey;
		string metadataKey = details.MetadataKey;
		object metadata = details.Metadata;
		if (ownerType == FactoryType.Wrapper || (ownerType == FactoryType.Decorator && ownerServiceType.IsAssignableFrom(container.GetWrappedType(serviceType, type))))
		{
			if (ifUnresolved == IfUnresolved.ReturnDefaultIfNotRegistered)
			{
				ifUnresolved2 = ifUnresolved;
			}
			if (serviceKey == null)
			{
				serviceKey = ownerDetails.ServiceKey;
			}
			if (metadataKey == null && metadata == null)
			{
				metadataKey = ownerDetails.MetadataKey;
				metadata = ownerDetails.Metadata;
			}
		}
		Type requiredServiceType = ownerDetails.RequiredServiceType;
		if (ownerType != FactoryType.Service && requiredServiceType != null && type == null)
		{
			type = requiredServiceType;
		}
		if (serviceKey == details.ServiceKey && metadataKey == details.MetadataKey && metadata == details.Metadata && ifUnresolved2 == details.IfUnresolved && type == details.RequiredServiceType)
		{
			return dependency;
		}
		if (serviceType == type)
		{
			type = null;
		}
		ServiceDetails details2 = ServiceDetails.Of(type, serviceKey, ifUnresolved2, details.DefaultValue, metadataKey, metadata);
		return dependency.Create(serviceType, details2);
	}

	public static object InheritInfoFromDependencyOwner(this Type serviceType, Type ownerServiceType, ServiceDetails ownerDetails, IContainer container, FactoryType ownerType = FactoryType.Service)
	{
		IfUnresolved ifUnresolved = IfUnresolved.Throw;
		IfUnresolved ifUnresolved2 = ownerDetails.IfUnresolved;
		if (ifUnresolved2 == IfUnresolved.ReturnDefault)
		{
			ifUnresolved = ifUnresolved2;
		}
		object obj = null;
		string text = null;
		object obj2 = null;
		if (ownerType == FactoryType.Wrapper || (ownerType == FactoryType.Decorator && ownerServiceType.IsAssignableFrom(container.GetWrappedType(serviceType, null))))
		{
			if (ifUnresolved2 == IfUnresolved.ReturnDefaultIfNotRegistered)
			{
				ifUnresolved = ifUnresolved2;
			}
			obj = ownerDetails.ServiceKey;
			text = ownerDetails.MetadataKey;
			obj2 = ownerDetails.Metadata;
		}
		Type type = null;
		Type requiredServiceType = ownerDetails.RequiredServiceType;
		if (ownerType != FactoryType.Service && requiredServiceType != null)
		{
			type = requiredServiceType;
		}
		if (serviceType == type)
		{
			type = null;
		}
		if (obj == null && text == null && obj2 == null && ifUnresolved == IfUnresolved.Throw && type == null)
		{
			return serviceType;
		}
		return ServiceInfo.Of(serviceType, ServiceDetails.Of(type, obj, ifUnresolved, null, text, obj2));
	}

	public static ServiceInfo InheritInfoFromDependencyOwner(this Type serviceType, ServiceInfo owner, IContainer container, FactoryType ownerFactoryType = FactoryType.Service)
	{
		ServiceDetails details = owner.Details;
		if (details == null || details == ServiceDetails.Default)
		{
			return ServiceInfo.Of(serviceType);
		}
		IfUnresolved ifUnresolved = IfUnresolved.Throw;
		IfUnresolved ifUnresolved2 = details.IfUnresolved;
		if (ifUnresolved2 == IfUnresolved.ReturnDefault)
		{
			ifUnresolved = ifUnresolved2;
		}
		Type requiredServiceType = details.RequiredServiceType;
		object obj = null;
		string text = null;
		object obj2 = null;
		if (ownerFactoryType == FactoryType.Wrapper || (ownerFactoryType == FactoryType.Decorator && container.GetWrappedType(serviceType).IsAssignableTo(owner.ServiceType)))
		{
			if (ifUnresolved2 == IfUnresolved.ReturnDefaultIfNotRegistered)
			{
				ifUnresolved = ifUnresolved2;
			}
			obj = details.ServiceKey;
			text = details.MetadataKey;
			obj2 = details.Metadata;
		}
		if (ownerFactoryType != FactoryType.Service && requiredServiceType != null && requiredServiceType != serviceType)
		{
			return ServiceInfo.OfServiceAndRequiredType(serviceType, requiredServiceType, ifUnresolved, obj, text, obj2);
		}
		if (obj == null && text == null && obj2 == null && ifUnresolved == IfUnresolved.Throw)
		{
			return ServiceInfo.Of(serviceType);
		}
		return ServiceInfo.Of(serviceType, null, ifUnresolved, obj, text, obj2);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Type GetActualServiceType(this ServiceInfo info)
	{
		Type requiredServiceType = info.Details.RequiredServiceType;
		if (!(requiredServiceType != null) || !info.ServiceType.IsAssignableFrom(requiredServiceType))
		{
			return info.ServiceType;
		}
		return requiredServiceType;
	}

	public static StringBuilder Print(this StringBuilder s, ServiceInfo info)
	{
		s.Print(info.ServiceType);
		string text = info.Details.ToString();
		if (!(text == string.Empty))
		{
			return s.Append(' ').Append(text);
		}
		return s;
	}
}
