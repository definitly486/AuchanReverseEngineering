using System;
using System.Runtime.CompilerServices;
using System.Text;

namespace DryIoc;

public abstract class ServiceInfo
{
	public class Typed : ServiceInfo
	{
		public override Type ServiceType { get; }

		public Typed(Type serviceType)
		{
			ServiceType = serviceType.ThrowIfNull();
		}
	}

	private sealed class TypedIfUnresolvedReturnDefault : Typed
	{
		public override ServiceDetails Details => ServiceDetails.IfUnresolvedReturnDefault;

		public TypedIfUnresolvedReturnDefault(Type serviceType)
			: base(serviceType)
		{
		}
	}

	private sealed class TypedIfUnresolvedReturnDefaultIfNotRegistered : Typed
	{
		public override ServiceDetails Details => ServiceDetails.IfUnresolvedReturnDefaultIfNotRegistered;

		public TypedIfUnresolvedReturnDefaultIfNotRegistered(Type serviceType)
			: base(serviceType)
		{
		}
	}

	public class Typed<TService> : ServiceInfo
	{
		public override Type ServiceType => typeof(TService);
	}

	private sealed class WithDetails : Typed
	{
		public override ServiceDetails Details { get; }

		public WithDetails(Type serviceType, ServiceDetails details)
			: base(serviceType)
		{
			Details = details;
		}
	}

	private sealed class TypedWithDetails<TService> : Typed<TService>
	{
		public override ServiceDetails Details { get; }

		public TypedWithDetails(ServiceDetails details)
		{
			Details = details;
		}
	}

	public abstract Type ServiceType { get; }

	public virtual ServiceDetails Details => ServiceDetails.Default;

	public object ServiceKey => Details.ServiceKey;

	public static ServiceInfo OfServiceAndRequiredType(Type serviceType, Type requiredServiceType, IfUnresolved ifUnresolved = IfUnresolved.Throw, object serviceKey = null, string metadataKey = null, object metadata = null)
	{
		return new WithDetails(serviceType, new ServiceDetails(requiredServiceType, ifUnresolved, serviceKey, metadataKey, metadata, null, hasCustomValue: false));
	}

	public virtual ServiceInfo Create(Type serviceType, ServiceDetails details)
	{
		if (details != ServiceDetails.Default)
		{
			return new WithDetails(serviceType, details);
		}
		return new Typed(serviceType);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static ServiceInfo Of(Type serviceType)
	{
		return new Typed(serviceType);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static ServiceInfo Of(Type serviceType, IfUnresolved ifUnresolved)
	{
		return ifUnresolved switch
		{
			IfUnresolved.ReturnDefault => new TypedIfUnresolvedReturnDefault(serviceType), 
			IfUnresolved.Throw => new Typed(serviceType), 
			_ => new TypedIfUnresolvedReturnDefaultIfNotRegistered(serviceType), 
		};
	}

	public static ServiceInfo Of(Type serviceType, object serviceKey)
	{
		if (serviceKey != null)
		{
			return new WithDetails(serviceType, ServiceDetails.Of(null, serviceKey));
		}
		return new Typed(serviceType);
	}

	public static ServiceInfo Of(Type serviceType, ServiceDetails details)
	{
		return new WithDetails(serviceType, details);
	}

	public static ServiceInfo Of(Type serviceType, IfUnresolved ifUnresolved, object serviceKey)
	{
		if (serviceKey != null)
		{
			return new WithDetails(serviceType, ServiceDetails.Of(null, serviceKey, ifUnresolved));
		}
		return ifUnresolved switch
		{
			IfUnresolved.ReturnDefault => new WithDetails(serviceType, ServiceDetails.IfUnresolvedReturnDefault), 
			IfUnresolved.Throw => new Typed(serviceType), 
			_ => new WithDetails(serviceType, ServiceDetails.IfUnresolvedReturnDefaultIfNotRegistered), 
		};
	}

	public static ServiceInfo Of(Type serviceType, Type requiredServiceType, IfUnresolved ifUnresolved = IfUnresolved.Throw, object serviceKey = null, string metadataKey = null, object metadata = null)
	{
		(serviceType ?? requiredServiceType).ThrowIfNull();
		if (serviceType == requiredServiceType)
		{
			requiredServiceType = null;
		}
		if (serviceKey != null || !(requiredServiceType == null) || metadataKey != null || metadata != null)
		{
			return new WithDetails(serviceType, ServiceDetails.Of(requiredServiceType, serviceKey, ifUnresolved, null, metadataKey, metadata));
		}
		return ifUnresolved switch
		{
			IfUnresolved.ReturnDefault => new TypedIfUnresolvedReturnDefault(serviceType), 
			IfUnresolved.Throw => new Typed(serviceType), 
			_ => new TypedIfUnresolvedReturnDefaultIfNotRegistered(serviceType), 
		};
	}

	public static Typed<TService> Of<TService>(IfUnresolved ifUnresolved = IfUnresolved.Throw, object serviceKey = null)
	{
		if (serviceKey != null || ifUnresolved != IfUnresolved.Throw)
		{
			return new TypedWithDetails<TService>(ServiceDetails.Of(null, serviceKey, ifUnresolved));
		}
		return new Typed<TService>();
	}

	public override string ToString()
	{
		return new StringBuilder().Print(this).ToString();
	}
}
