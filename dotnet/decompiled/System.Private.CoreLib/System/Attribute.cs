using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace System;

[Serializable]
[AttributeUsage(AttributeTargets.All, Inherited = true, AllowMultiple = false)]
[TypeForwardedFrom("mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")]
public abstract class Attribute
{
	public virtual object TypeId => GetType();

	private static Attribute GetAttr(ICustomAttributeProvider element, Type attributeType, bool inherit)
	{
		ArgumentNullException.ThrowIfNull(attributeType, "attributeType");
		if (!attributeType.IsSubclassOf(typeof(Attribute)) && !attributeType.IsInterface && attributeType != typeof(Attribute) && attributeType != typeof(CustomAttribute))
		{
			throw new ArgumentException("Argument_MustHaveAttributeBaseClass" + " " + attributeType.FullName);
		}
		object[] customAttributes = CustomAttribute.GetCustomAttributes(element, attributeType, inherit);
		if (customAttributes == null || customAttributes.Length == 0)
		{
			return null;
		}
		Attribute attribute = (Attribute)customAttributes[0];
		if (customAttributes.Length != 1)
		{
			throw ThrowHelper.GetAmbiguousMatchException(attribute);
		}
		return attribute;
	}

	public static Attribute? GetCustomAttribute(Assembly element, Type attributeType)
	{
		return GetAttr(element, attributeType, inherit: true);
	}

	public static Attribute? GetCustomAttribute(Assembly element, Type attributeType, bool inherit)
	{
		return GetAttr(element, attributeType, inherit);
	}

	public static Attribute? GetCustomAttribute(MemberInfo element, Type attributeType)
	{
		return GetAttr(element, attributeType, inherit: true);
	}

	public static Attribute? GetCustomAttribute(MemberInfo element, Type attributeType, bool inherit)
	{
		return GetAttr(element, attributeType, inherit);
	}

	public static Attribute? GetCustomAttribute(Module element, Type attributeType)
	{
		return GetAttr(element, attributeType, inherit: true);
	}

	public static Attribute? GetCustomAttribute(Module element, Type attributeType, bool inherit)
	{
		return GetAttr(element, attributeType, inherit);
	}

	public static Attribute? GetCustomAttribute(ParameterInfo element, Type attributeType)
	{
		return GetAttr(element, attributeType, inherit: true);
	}

	public static Attribute? GetCustomAttribute(ParameterInfo element, Type attributeType, bool inherit)
	{
		return GetAttr(element, attributeType, inherit);
	}

	public static Attribute[] GetCustomAttributes(Assembly element)
	{
		return (Attribute[])CustomAttribute.GetCustomAttributes(element, inherit: true);
	}

	public static Attribute[] GetCustomAttributes(Assembly element, bool inherit)
	{
		return (Attribute[])CustomAttribute.GetCustomAttributes(element, inherit);
	}

	public static Attribute[] GetCustomAttributes(Assembly element, Type attributeType)
	{
		return (Attribute[])CustomAttribute.GetCustomAttributes(element, attributeType, inherit: true);
	}

	public static Attribute[] GetCustomAttributes(Assembly element, Type attributeType, bool inherit)
	{
		return (Attribute[])CustomAttribute.GetCustomAttributes(element, attributeType, inherit);
	}

	public static Attribute[] GetCustomAttributes(MemberInfo element)
	{
		return (Attribute[])CustomAttribute.GetCustomAttributes(element, inherit: true);
	}

	public static Attribute[] GetCustomAttributes(MemberInfo element, bool inherit)
	{
		return (Attribute[])CustomAttribute.GetCustomAttributes(element, inherit);
	}

	public static Attribute[] GetCustomAttributes(MemberInfo element, Type attributeType)
	{
		return (Attribute[])CustomAttribute.GetCustomAttributes(element, attributeType, inherit: true);
	}

	public static Attribute[] GetCustomAttributes(MemberInfo element, Type attributeType, bool inherit)
	{
		return (Attribute[])CustomAttribute.GetCustomAttributes(element, attributeType, inherit);
	}

	public static Attribute[] GetCustomAttributes(Module element)
	{
		return (Attribute[])CustomAttribute.GetCustomAttributes(element, inherit: true);
	}

	public static Attribute[] GetCustomAttributes(Module element, bool inherit)
	{
		return (Attribute[])CustomAttribute.GetCustomAttributes(element, inherit);
	}

	public static Attribute[] GetCustomAttributes(Module element, Type attributeType)
	{
		return (Attribute[])CustomAttribute.GetCustomAttributes(element, attributeType, inherit: true);
	}

	public static Attribute[] GetCustomAttributes(Module element, Type attributeType, bool inherit)
	{
		return (Attribute[])CustomAttribute.GetCustomAttributes(element, attributeType, inherit);
	}

	public static Attribute[] GetCustomAttributes(ParameterInfo element)
	{
		return (Attribute[])CustomAttribute.GetCustomAttributes(element, inherit: true);
	}

	public static Attribute[] GetCustomAttributes(ParameterInfo element, bool inherit)
	{
		return (Attribute[])CustomAttribute.GetCustomAttributes(element, inherit);
	}

	public static Attribute[] GetCustomAttributes(ParameterInfo element, Type attributeType)
	{
		return (Attribute[])CustomAttribute.GetCustomAttributes(element, attributeType, inherit: true);
	}

	public static Attribute[] GetCustomAttributes(ParameterInfo element, Type attributeType, bool inherit)
	{
		return (Attribute[])CustomAttribute.GetCustomAttributes(element, attributeType, inherit);
	}

	public static bool IsDefined(Assembly element, Type attributeType)
	{
		return CustomAttribute.IsDefined(element, attributeType, inherit: true);
	}

	public static bool IsDefined(Assembly element, Type attributeType, bool inherit)
	{
		return CustomAttribute.IsDefined(element, attributeType, inherit);
	}

	public static bool IsDefined(MemberInfo element, Type attributeType)
	{
		return CustomAttribute.IsDefined(element, attributeType, inherit: true);
	}

	public static bool IsDefined(MemberInfo element, Type attributeType, bool inherit)
	{
		return CustomAttribute.IsDefined(element, attributeType, inherit);
	}

	public static bool IsDefined(Module element, Type attributeType)
	{
		return CustomAttribute.IsDefined(element, attributeType, inherit: true);
	}

	public static bool IsDefined(Module element, Type attributeType, bool inherit)
	{
		return CustomAttribute.IsDefined(element, attributeType, inherit);
	}

	public static bool IsDefined(ParameterInfo element, Type attributeType)
	{
		return CustomAttribute.IsDefined(element, attributeType, inherit: true);
	}

	public static bool IsDefined(ParameterInfo element, Type attributeType, bool inherit)
	{
		return CustomAttribute.IsDefined(element, attributeType, inherit);
	}

	[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2075:UnrecognizedReflectionPattern", Justification = "Unused fields don't make a difference for equality")]
	public override bool Equals([NotNullWhen(true)] object? obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (GetType() != obj.GetType())
		{
			return false;
		}
		Type type = GetType();
		while (type != typeof(Attribute))
		{
			FieldInfo[] fields = type.GetFields(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			for (int i = 0; i < fields.Length; i++)
			{
				object? value = fields[i].GetValue(this);
				object value2 = fields[i].GetValue(obj);
				if (!AreFieldValuesEqual(value, value2))
				{
					return false;
				}
			}
			type = type.BaseType;
		}
		return true;
	}

	[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2075:UnrecognizedReflectionPattern", Justification = "Unused fields don't make a difference for hashcode quality")]
	public override int GetHashCode()
	{
		Type type = GetType();
		while (type != typeof(Attribute))
		{
			FieldInfo[] fields = type.GetFields(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			object obj = null;
			for (int i = 0; i < fields.Length; i++)
			{
				object value = fields[i].GetValue(this);
				if (value != null && !value.GetType().IsArray)
				{
					obj = value;
				}
				if (obj != null)
				{
					break;
				}
			}
			if (obj != null)
			{
				return obj.GetHashCode();
			}
			type = type.BaseType;
		}
		return type.GetHashCode();
	}

	private static bool AreFieldValuesEqual(object thisValue, object thatValue)
	{
		if (thisValue == null && thatValue == null)
		{
			return true;
		}
		if (thisValue == null || thatValue == null)
		{
			return false;
		}
		Type type = thisValue.GetType();
		if (type.IsArray)
		{
			if (!type.Equals(thatValue.GetType()))
			{
				return false;
			}
			Array array = (Array)thisValue;
			Array array2 = (Array)thatValue;
			if (array.Length != array2.Length)
			{
				return false;
			}
			for (int i = 0; i < array.Length; i++)
			{
				if (!AreFieldValuesEqual(array.GetValue(i), array2.GetValue(i)))
				{
					return false;
				}
			}
		}
		else if (!thisValue.Equals(thatValue))
		{
			return false;
		}
		return true;
	}

	public virtual bool Match(object? obj)
	{
		return Equals(obj);
	}

	public virtual bool IsDefaultAttribute()
	{
		return false;
	}
}
