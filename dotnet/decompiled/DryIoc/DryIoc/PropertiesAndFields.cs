using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using DryIoc.ImTools;

namespace DryIoc;

public static class PropertiesAndFields
{
	public delegate PropertyOrFieldServiceInfo GetServiceInfo(MemberInfo member, Request request);

	public static PropertiesAndFieldsSelector Of = (Request request) => (IEnumerable<PropertyOrFieldServiceInfo>)null;

	public static PropertiesAndFieldsSelector Auto = All(withNonPublic: false, withPrimitive: false);

	private static readonly PropertiesAndFieldsSelector _requiredProperties = delegate(Request req)
	{
		Type implementationType = req.ImplementationType;
		if (implementationType == null)
		{
			return (IEnumerable<PropertyOrFieldServiceInfo>)null;
		}
		ConstructorInfo selectedConstructor = req.SelectedConstructor;
		if (selectedConstructor != null && selectedConstructor.GetCustomAttribute<SetsRequiredMembersAttribute>() != null)
		{
			return (IEnumerable<PropertyOrFieldServiceInfo>)null;
		}
		PropertyInfo[] properties = implementationType.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
		return (properties.Length == 0) ? null : properties.Match((PropertyInfo p) => p.GetCustomAttribute<RequiredMemberAttribute>() != null, (PropertyInfo p) => PropertyOrFieldServiceInfo.OfRequiredProperty(p));
	};

	public static PropertiesAndFieldsSelector Properties(bool withNonPublic = false, bool withBase = false, IfUnresolved ifUnresolved = IfUnresolved.ReturnDefaultIfNotRegistered)
	{
		return All(withNonPublic, withPrimitive: false, withFields: false, withBase, ifUnresolved);
	}

	public static PropertiesAndFieldsSelector RequiredProperties()
	{
		return _requiredProperties;
	}

	public static PropertiesAndFieldsSelector All(bool withNonPublic = true, bool withPrimitive = true, bool withFields = true, bool withBase = true, IfUnresolved ifUnresolved = IfUnresolved.ReturnDefaultIfNotRegistered, GetServiceInfo serviceInfo = null)
	{
		if (serviceInfo == null)
		{
			ServiceDetails details = ServiceDetails.Of(ifUnresolved);
			serviceInfo = (MemberInfo m, Request r) => PropertyOrFieldServiceInfo.Of(m).WithDetails(details);
		}
		return delegate(Request req)
		{
			Type implementationType = req.ImplementationType;
			if (implementationType == null)
			{
				return (IEnumerable<PropertyOrFieldServiceInfo>)null;
			}
			PropertyOrFieldServiceInfo[] array = implementationType.GetMembers((TypeInfo x) => x.DeclaredProperties, withBase).ToArrayOrSelf().Match(serviceInfo, req, (GetServiceInfo si, Request r, PropertyInfo p) => p.IsInjectable(withNonPublic, withPrimitive), (GetServiceInfo si, Request r, PropertyInfo p) => si(p, r));
			if (!withFields)
			{
				return array;
			}
			PropertyOrFieldServiceInfo[] added = implementationType.GetMembers((TypeInfo x) => x.DeclaredFields, withBase).ToArrayOrSelf().Match(serviceInfo, req, (GetServiceInfo si, Request r, FieldInfo f) => f.IsInjectable(withNonPublic, withPrimitive), (GetServiceInfo si, Request r, FieldInfo f) => si(f, r));
			return array.Append(added);
		};
	}

	public static PropertiesAndFieldsSelector OverrideWith(this PropertiesAndFieldsSelector source, PropertiesAndFieldsSelector other)
	{
		if (source != null && source != Of)
		{
			if (other != null && other != Of)
			{
				return delegate(Request r)
				{
					PropertyOrFieldServiceInfo[] array = source(r).ToArrayOrSelf();
					PropertyOrFieldServiceInfo[] array2 = other(r).ToArrayOrSelf();
					return (array != null && array.Length != 0) ? ((array2 != null && array2.Length != 0) ? array2.Append(array.Match(array2, (PropertyOrFieldServiceInfo[] om, PropertyOrFieldServiceInfo s) => s != null && om.All((PropertyOrFieldServiceInfo o) => o == null || !s.Member.Name.Equals(o.Member.Name)))) : array) : array2;
				};
			}
			return source;
		}
		return other ?? Of;
	}

	[Obsolete("Replaced with OverrideWith", false)]
	public static PropertiesAndFieldsSelector And(this PropertiesAndFieldsSelector source, PropertiesAndFieldsSelector other)
	{
		return source.OverrideWith(other);
	}

	public static PropertiesAndFieldsSelector Details(this PropertiesAndFieldsSelector source, string name, Func<Request, ServiceDetails> getDetails)
	{
		name.ThrowIfNull();
		getDetails.ThrowIfNull();
		return source.OverrideWith(delegate(Request req)
		{
			Type knownImplementationOrServiceType = req.GetKnownImplementationOrServiceType();
			PropertyInfo propertyInfo = knownImplementationOrServiceType.GetMembers((TypeInfo x) => x.DeclaredProperties, includeBase: true).FindFirst((PropertyInfo x) => x.Name == name);
			if (propertyInfo != null && propertyInfo.IsInjectable(withNonPublic: true, withPrimitive: true))
			{
				return getDetails(req)?.To(PropertyOrFieldServiceInfo.Of(propertyInfo).WithDetails).One();
			}
			FieldInfo fieldInfo = knownImplementationOrServiceType.GetMembers((TypeInfo x) => x.DeclaredFields, includeBase: true).FindFirst((FieldInfo x) => x.Name == name);
			return (fieldInfo != null && fieldInfo.IsInjectable(withNonPublic: true, withPrimitive: true)) ? getDetails(req)?.To(PropertyOrFieldServiceInfo.Of(fieldInfo).WithDetails).One() : Throw.For<IEnumerable<PropertyOrFieldServiceInfo>>(Error.NotFoundSpecifiedWritablePropertyOrField, name, req);
		});
	}

	public static PropertiesAndFieldsSelector Name(this PropertiesAndFieldsSelector source, string name, Type requiredServiceType = null, object serviceKey = null, IfUnresolved ifUnresolved = IfUnresolved.ReturnDefault, object defaultValue = null, string metadataKey = null, object metadata = null)
	{
		return source.Details(name, (Request r) => ServiceDetails.Of(requiredServiceType, serviceKey, ifUnresolved, defaultValue, metadataKey, metadata));
	}

	public static PropertiesAndFieldsSelector Name(this PropertiesAndFieldsSelector source, string name, Func<Request, object> getCustomValue)
	{
		return source.Details(name, (Request r) => ServiceDetails.Of(getCustomValue(r)));
	}

	public static bool IsInjectable(this PropertyInfo property, bool withNonPublic = false, bool withPrimitive = false)
	{
		if (!property.CanWrite || property.IsExplicitlyImplemented())
		{
			return false;
		}
		if (property.IsStatic())
		{
			return false;
		}
		if (!property.IsIndexer() && (withNonPublic || property.GetSetMethodOrNull() != null))
		{
			if (!withPrimitive)
			{
				return !property.PropertyType.IsPrimitive(orArrayOfPrimitives: true);
			}
			return true;
		}
		return false;
	}

	public static bool IsInjectable(this FieldInfo field, bool withNonPublic = false, bool withPrimitive = false)
	{
		if (!field.IsInitOnly && !field.IsBackingField() && (withNonPublic || field.IsPublic))
		{
			if (!withPrimitive)
			{
				return !field.FieldType.IsPrimitive(orArrayOfPrimitives: true);
			}
			return true;
		}
		return false;
	}
}
