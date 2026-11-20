using System;
using System.Reflection;
using DryIoc.ImTools;

namespace DryIoc;

public static class Parameters
{
	public static ParameterSelector Of = (Request request) => ParameterServiceInfo.Of;

	public static ParameterSelector IfUnresolvedReturnDefault = (Request request) => (ParameterInfo pi) => ParameterServiceInfo.Of(pi).WithDetails(ServiceDetails.IfUnresolvedReturnDefault);

	public static ParameterSelector OverrideWith(this ParameterSelector source, ParameterSelector other)
	{
		if (source != null && source != Of)
		{
			if (other != null && other != Of)
			{
				return (Request req) => delegate(ParameterInfo paramInfo)
				{
					object obj = other(req)?.Invoke(paramInfo);
					if (obj == null)
					{
						Func<ParameterInfo, ParameterServiceInfo> func = source(req);
						if (func == null)
						{
							return (ParameterServiceInfo)null;
						}
						obj = func(paramInfo);
					}
					return (ParameterServiceInfo)obj;
				};
			}
			return source;
		}
		return other ?? Of;
	}

	[Obsolete("Replaced with OverrideWith", false)]
	public static ParameterSelector And(this ParameterSelector source, ParameterSelector other)
	{
		return source.OverrideWith(other);
	}

	public static ParameterSelector Details(this ParameterSelector source, Func<Request, ParameterInfo, ServiceDetails> getDetailsOrNull)
	{
		getDetailsOrNull.ThrowIfNull();
		return source.OverrideWith((Request request) => (ParameterInfo p) => getDetailsOrNull(request, p)?.To(ParameterServiceInfo.Of(p).WithDetails));
	}

	public static ParameterSelector Position(this ParameterSelector source, int position, Type requiredServiceType = null, object serviceKey = null, IfUnresolved ifUnresolved = IfUnresolved.Throw, object defaultValue = null, string metadataKey = null, object metadata = null)
	{
		return source.Details((Request r, ParameterInfo p) => (p.Position == position) ? ServiceDetails.Of(requiredServiceType, serviceKey, ifUnresolved, defaultValue, metadataKey, metadata) : null);
	}

	public static ParameterSelector Position(this ParameterSelector source, int position, Func<Request, ParameterInfo, ServiceDetails> getServiceDetails)
	{
		return source.Details((Request r, ParameterInfo p) => (p.Position != position) ? null : getServiceDetails(r, p));
	}

	public static ParameterSelector Position(this ParameterSelector source, int position, Func<Request, object> getCustomValue)
	{
		return source.Position(position, (Request r, ParameterInfo p) => ServiceDetails.Of(getCustomValue(r)));
	}

	public static ParameterSelector Name(this ParameterSelector source, string name, Type requiredServiceType = null, object serviceKey = null, IfUnresolved ifUnresolved = IfUnresolved.Throw, object defaultValue = null, string metadataKey = null, object metadata = null)
	{
		return source.Details((Request r, ParameterInfo p) => p.Name.Equals(name) ? ServiceDetails.Of(requiredServiceType, serviceKey, ifUnresolved, defaultValue, metadataKey, metadata) : null);
	}

	public static ParameterSelector Name(this ParameterSelector source, string name, Func<Request, ParameterInfo, ServiceDetails> getServiceDetails)
	{
		return source.Details((Request r, ParameterInfo p) => (!p.Name.Equals(name)) ? null : getServiceDetails(r, p));
	}

	public static ParameterSelector Name(this ParameterSelector source, string name, Func<Request, object> getCustomValue)
	{
		return source.Name(name, (Request r, ParameterInfo p) => ServiceDetails.Of(getCustomValue(r)));
	}

	public static ParameterSelector Type(this ParameterSelector source, Type parameterType, Type requiredServiceType = null, object serviceKey = null, IfUnresolved ifUnresolved = IfUnresolved.Throw, object defaultValue = null, string metadataKey = null, object metadata = null)
	{
		return source.Details((Request r, ParameterInfo p) => parameterType.IsAssignableTo(p.ParameterType) ? ServiceDetails.Of(requiredServiceType, serviceKey, ifUnresolved, defaultValue, metadataKey, metadata) : null);
	}

	public static ParameterSelector Type<T>(this ParameterSelector source, Type requiredServiceType = null, object serviceKey = null, IfUnresolved ifUnresolved = IfUnresolved.Throw, object defaultValue = null, string metadataKey = null, object metadata = null)
	{
		return source.Type(typeof(T), requiredServiceType, serviceKey, ifUnresolved, defaultValue, metadataKey, metadata);
	}

	public static ParameterSelector Type<T>(this ParameterSelector source, Func<Request, ParameterInfo, ServiceDetails> getServiceDetails)
	{
		return source.Details((Request r, ParameterInfo p) => (!(p.ParameterType == typeof(T))) ? null : getServiceDetails(r, p));
	}

	public static ParameterSelector Type<T>(this ParameterSelector source, Func<Request, T> getCustomValue)
	{
		return source.Type<T>((Request r, ParameterInfo p) => ServiceDetails.Of(getCustomValue(r)));
	}

	public static ParameterSelector Type(this ParameterSelector source, Type parameterType, Func<Request, object> getCustomValue)
	{
		return source.Details((Request r, ParameterInfo p) => (!(p.ParameterType == parameterType)) ? null : ServiceDetails.Of(getCustomValue(r)));
	}
}
