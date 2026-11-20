using System;
using System.Runtime.CompilerServices;
using System.Text;
using DryIoc.ImTools;

namespace DryIoc;

public sealed class ServiceDetails
{
	public static readonly ServiceDetails Default = new ServiceDetails(null, IfUnresolved.Throw, null, null, null, null, hasCustomValue: false);

	public static readonly ServiceDetails IfUnresolvedReturnDefault = new ServiceDetails(null, IfUnresolved.ReturnDefault, null, null, null, null, hasCustomValue: false);

	public static readonly ServiceDetails IfUnresolvedReturnDefaultIfNotRegistered = new ServiceDetails(null, IfUnresolved.ReturnDefaultIfNotRegistered, null, null, null, null, hasCustomValue: false);

	public readonly Type RequiredServiceType;

	public readonly object ServiceKey;

	public readonly string MetadataKey;

	public readonly object Metadata;

	public readonly bool HasCustomValue;

	private readonly object _value;

	public readonly IfUnresolved IfUnresolved;

	public object DefaultValue
	{
		get
		{
			if (IfUnresolved == IfUnresolved.Throw)
			{
				return null;
			}
			return _value;
		}
	}

	public object CustomValue
	{
		get
		{
			if (IfUnresolved != IfUnresolved.Throw)
			{
				return null;
			}
			return _value;
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static ServiceDetails Of(IfUnresolved ifUnresolved)
	{
		return ifUnresolved switch
		{
			IfUnresolved.ReturnDefault => IfUnresolvedReturnDefault, 
			IfUnresolved.Throw => Default, 
			_ => IfUnresolvedReturnDefaultIfNotRegistered, 
		};
	}

	public static ServiceDetails Of(Type requiredServiceType = null, object serviceKey = null, IfUnresolved ifUnresolved = IfUnresolved.Throw, object defaultValue = null, string metadataKey = null, object metadata = null)
	{
		if (defaultValue == null)
		{
			if (requiredServiceType == null && serviceKey == null && metadataKey == null && metadata == null)
			{
				return Of(ifUnresolved);
			}
		}
		else if (ifUnresolved == IfUnresolved.Throw)
		{
			ifUnresolved = IfUnresolved.ReturnDefault;
		}
		return new ServiceDetails(requiredServiceType, ifUnresolved, serviceKey, metadataKey, metadata, defaultValue, hasCustomValue: false);
	}

	public static ServiceDetails Of(object value)
	{
		return new ServiceDetails(null, IfUnresolved.Throw, null, null, null, value, hasCustomValue: true);
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (HasCustomValue)
		{
			return stringBuilder.Append("{CustomValue=").Print(CustomValue ?? "null").Append("}")
				.ToString();
		}
		if (RequiredServiceType != null)
		{
			stringBuilder.Append("RequiredServiceType=").Print(RequiredServiceType);
		}
		if (ServiceKey != null)
		{
			((stringBuilder.Length == 0) ? stringBuilder.Append('{') : stringBuilder.Append(", ")).Append("ServiceKey=").Print(ServiceKey);
		}
		if (MetadataKey != null || Metadata != null)
		{
			((stringBuilder.Length == 0) ? stringBuilder.Append('{') : stringBuilder.Append(", ")).Append("Metadata=").Append(MetadataKey.Pair(Metadata));
		}
		if (IfUnresolved != IfUnresolved.Throw)
		{
			stringBuilder = ((stringBuilder.Length == 0) ? stringBuilder.Append('{') : stringBuilder.Append(", ")).Print(IfUnresolved);
			stringBuilder = ((_value == null) ? stringBuilder : stringBuilder.Append(", DefaultValue=").Print(_value));
		}
		return ((stringBuilder.Length == 0) ? stringBuilder : stringBuilder.Append('}')).ToString();
	}

	internal ServiceDetails(Type requiredServiceType, IfUnresolved ifUnresolved, object serviceKey, string metadataKey, object metadata, object value, bool hasCustomValue)
	{
		RequiredServiceType = requiredServiceType;
		IfUnresolved = ifUnresolved;
		ServiceKey = serviceKey;
		MetadataKey = metadataKey;
		Metadata = metadata;
		_value = value;
		HasCustomValue = hasCustomValue;
	}

	public bool Equals(ServiceDetails d)
	{
		if ((d != Default || this != Default) && (d != IfUnresolvedReturnDefault || this != IfUnresolvedReturnDefault))
		{
			if (d.RequiredServiceType == RequiredServiceType && d.IfUnresolved == IfUnresolved && d.HasCustomValue == HasCustomValue && object.Equals(d.MetadataKey, MetadataKey) && object.Equals(d.Metadata, Metadata))
			{
				return object.Equals(d._value, _value);
			}
			return false;
		}
		return true;
	}
}
