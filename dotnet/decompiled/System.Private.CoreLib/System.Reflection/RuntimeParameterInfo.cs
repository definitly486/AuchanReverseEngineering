using System.Collections.Generic;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace System.Reflection;

internal sealed class RuntimeParameterInfo : ParameterInfo
{
	internal MarshalAsAttribute marshalAs;

	public override object DefaultValue => GetDefaultValue(raw: false);

	public override object RawDefaultValue
	{
		get
		{
			object defaultValue = GetDefaultValue(raw: true);
			if (defaultValue is Enum obj)
			{
				return obj.GetValue();
			}
			return defaultValue;
		}
	}

	public override int MetadataToken
	{
		get
		{
			if (MemberImpl is PropertyInfo propertyInfo)
			{
				return (propertyInfo.GetGetMethod(nonPublic: true) ?? propertyInfo.GetSetMethod(nonPublic: true)).GetParametersInternal()[PositionImpl].MetadataToken;
			}
			if (MemberImpl is MethodBase)
			{
				return GetMetadataToken();
			}
			throw new ArgumentException("NoMetadataTokenAvailable");
		}
	}

	public override bool HasDefaultValue
	{
		get
		{
			object defaultValue = DefaultValue;
			if (defaultValue == null)
			{
				return true;
			}
			if (defaultValue.GetType() == typeof(DBNull) || defaultValue.GetType() == typeof(Missing))
			{
				return false;
			}
			return true;
		}
	}

	internal RuntimeParameterInfo(string name, Type type, int position, int attrs, object defaultValue, MemberInfo member, MarshalAsAttribute marshalAs)
	{
		NameImpl = name;
		ClassImpl = type;
		PositionImpl = position;
		AttrsImpl = (ParameterAttributes)attrs;
		DefaultValueImpl = defaultValue;
		MemberImpl = member;
		this.marshalAs = marshalAs;
	}

	internal static void FormatParameters(StringBuilder sb, ReadOnlySpan<ParameterInfo> p, CallingConventions callingConvention)
	{
		for (int i = 0; i < p.Length; i++)
		{
			if (i > 0)
			{
				sb.Append(", ");
			}
			Type parameterType = p[i].ParameterType;
			string text = parameterType.FormatTypeName();
			if (parameterType.IsByRef)
			{
				sb.Append(text.TrimEnd('&'));
				sb.Append(" ByRef");
			}
			else
			{
				sb.Append(text);
			}
		}
		if ((callingConvention & CallingConventions.VarArgs) != 0)
		{
			if (p.Length > 0)
			{
				sb.Append(", ");
			}
			sb.Append("...");
		}
	}

	internal RuntimeParameterInfo(ParameterBuilder pb, Type type, MemberInfo member, int position)
	{
		ClassImpl = type;
		MemberImpl = member;
		if (pb != null)
		{
			NameImpl = pb.Name;
			PositionImpl = pb.Position - 1;
			AttrsImpl = (ParameterAttributes)pb.Attributes;
		}
		else
		{
			NameImpl = null;
			PositionImpl = position - 1;
			AttrsImpl = ParameterAttributes.None;
		}
	}

	internal static ParameterInfo New(ParameterBuilder pb, Type type, MemberInfo member, int position)
	{
		return new RuntimeParameterInfo(pb, type, member, position);
	}

	internal RuntimeParameterInfo(ParameterInfo pinfo, MemberInfo member)
	{
		ClassImpl = pinfo.ParameterType;
		MemberImpl = member;
		NameImpl = pinfo.Name;
		PositionImpl = pinfo.Position;
		AttrsImpl = pinfo.Attributes;
		DefaultValueImpl = GetDefaultValueImpl(pinfo);
	}

	internal RuntimeParameterInfo(Type type, MemberInfo member, MarshalAsAttribute marshalAs)
	{
		ClassImpl = type;
		MemberImpl = member;
		NameImpl = null;
		PositionImpl = -1;
		AttrsImpl = ParameterAttributes.Retval;
		this.marshalAs = marshalAs;
		DefaultValueImpl = DBNull.Value;
	}

	internal RuntimeParameterInfo(MethodInfo owner, string name, Type parameterType, int position)
	{
		MemberImpl = owner;
		NameImpl = name;
		ClassImpl = parameterType;
		PositionImpl = position;
		AttrsImpl = ParameterAttributes.None;
	}

	private object GetDefaultValueFromCustomAttributeData()
	{
		foreach (CustomAttributeData customAttribute in CustomAttributeData.GetCustomAttributes(this))
		{
			Type attributeType = customAttribute.AttributeType;
			if (attributeType == typeof(DecimalConstantAttribute))
			{
				return GetRawDecimalConstant(customAttribute);
			}
			if (attributeType.IsSubclassOf(typeof(CustomConstantAttribute)))
			{
				if (attributeType == typeof(DateTimeConstantAttribute))
				{
					return GetRawDateTimeConstant(customAttribute);
				}
				return GetRawConstant(customAttribute);
			}
		}
		return DBNull.Value;
	}

	private static decimal GetRawDecimalConstant(CustomAttributeData attr)
	{
		IList<CustomAttributeTypedArgument> constructorArguments = attr.ConstructorArguments;
		return new decimal(GetConstructorArgument(constructorArguments, 4), GetConstructorArgument(constructorArguments, 3), GetConstructorArgument(constructorArguments, 2), (byte)constructorArguments[1].Value != 0, (byte)constructorArguments[0].Value);
		static int GetConstructorArgument(IList<CustomAttributeTypedArgument> args, int index)
		{
			object value = args[index].Value;
			if (value is int)
			{
				return (int)value;
			}
			return (int)(uint)value;
		}
	}

	private static DateTime GetRawDateTimeConstant(CustomAttributeData attr)
	{
		return new DateTime((long)attr.ConstructorArguments[0].Value);
	}

	private static object GetRawConstant(CustomAttributeData attr)
	{
		foreach (CustomAttributeNamedArgument namedArgument in attr.NamedArguments)
		{
			if (namedArgument.MemberInfo.Name.Equals("Value"))
			{
				return namedArgument.TypedValue.Value;
			}
		}
		return DBNull.Value;
	}

	private object GetDefaultValueFromCustomAttributes()
	{
		object[] customAttributes = GetCustomAttributes(typeof(CustomConstantAttribute), inherit: false);
		if (customAttributes.Length != 0)
		{
			return ((CustomConstantAttribute)customAttributes[0]).Value;
		}
		customAttributes = GetCustomAttributes(typeof(DecimalConstantAttribute), inherit: false);
		if (customAttributes.Length != 0)
		{
			return ((DecimalConstantAttribute)customAttributes[0]).Value;
		}
		return DBNull.Value;
	}

	private object GetDefaultValue(bool raw)
	{
		object obj = DefaultValueImpl;
		if (obj != null && (obj.GetType() == typeof(DBNull) || obj.GetType() == typeof(Missing)))
		{
			obj = (raw ? GetDefaultValueFromCustomAttributeData() : GetDefaultValueFromCustomAttributes());
		}
		if (obj == DBNull.Value && base.IsOptional)
		{
			obj = Type.Missing;
		}
		return obj;
	}

	public override object[] GetCustomAttributes(bool inherit)
	{
		return CustomAttribute.GetCustomAttributes(this, inherit: false);
	}

	public override object[] GetCustomAttributes(Type attributeType, bool inherit)
	{
		return CustomAttribute.GetCustomAttributes(this, attributeType, inherit: false);
	}

	internal static object GetDefaultValueImpl(ParameterInfo pinfo)
	{
		return typeof(ParameterInfo).GetField("DefaultValueImpl", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(pinfo);
	}

	public override bool IsDefined(Type attributeType, bool inherit)
	{
		return CustomAttribute.IsDefined(this, attributeType, inherit);
	}

	public override IList<CustomAttributeData> GetCustomAttributesData()
	{
		return RuntimeCustomAttributeData.GetCustomAttributesInternal(this);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal extern int GetMetadataToken();

	public override Type[] GetOptionalCustomModifiers()
	{
		if (!(MemberImpl is DynamicMethod))
		{
			return GetCustomModifiers(optional: true);
		}
		return Type.EmptyTypes;
	}

	internal object[] GetPseudoCustomAttributes()
	{
		int num = 0;
		if (base.IsIn)
		{
			num++;
		}
		if (base.IsOut)
		{
			num++;
		}
		if (base.IsOptional)
		{
			num++;
		}
		if (marshalAs != null)
		{
			num++;
		}
		if (num == 0)
		{
			return null;
		}
		object[] array = new object[num];
		num = 0;
		if (base.IsIn)
		{
			array[num++] = new InAttribute();
		}
		if (base.IsOut)
		{
			array[num++] = new OutAttribute();
		}
		if (base.IsOptional)
		{
			array[num++] = new OptionalAttribute();
		}
		if (marshalAs != null)
		{
			array[num++] = (MarshalAsAttribute)marshalAs.CloneInternal();
		}
		return array;
	}

	internal CustomAttributeData[] GetPseudoCustomAttributesData()
	{
		int num = 0;
		if (base.IsIn)
		{
			num++;
		}
		if (base.IsOut)
		{
			num++;
		}
		if (base.IsOptional)
		{
			num++;
		}
		if (marshalAs != null)
		{
			num++;
		}
		if (num == 0)
		{
			return null;
		}
		CustomAttributeData[] array = new CustomAttributeData[num];
		num = 0;
		if (base.IsIn)
		{
			array[num++] = new RuntimeCustomAttributeData(typeof(InAttribute).GetConstructor(Type.EmptyTypes));
		}
		if (base.IsOut)
		{
			array[num++] = new RuntimeCustomAttributeData(typeof(OutAttribute).GetConstructor(Type.EmptyTypes));
		}
		if (base.IsOptional)
		{
			array[num++] = new RuntimeCustomAttributeData(typeof(OptionalAttribute).GetConstructor(Type.EmptyTypes));
		}
		if (marshalAs != null)
		{
			CustomAttributeTypedArgument[] ctorArgs = new CustomAttributeTypedArgument[1]
			{
				new CustomAttributeTypedArgument(typeof(UnmanagedType), marshalAs.Value)
			};
			array[num++] = new RuntimeCustomAttributeData(typeof(MarshalAsAttribute).GetConstructor(new Type[1] { typeof(UnmanagedType) }), ctorArgs, Array.Empty<CustomAttributeNamedArgument>());
		}
		return array;
	}

	public override Type[] GetRequiredCustomModifiers()
	{
		if (!(MemberImpl is DynamicMethod))
		{
			return GetCustomModifiers(optional: false);
		}
		return Type.EmptyTypes;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern Type[] GetTypeModifiers(Type type, MemberInfo member, int position, bool optional, int genericArgumentPosition = -1);

	internal static ParameterInfo New(ParameterInfo pinfo, MemberInfo member)
	{
		return new RuntimeParameterInfo(pinfo, member);
	}

	internal static ParameterInfo New(Type type, MemberInfo member, MarshalAsAttribute marshalAs)
	{
		return new RuntimeParameterInfo(type, member, marshalAs);
	}

	internal void SetName(string name)
	{
		NameImpl = name;
	}

	internal void SetAttributes(ParameterAttributes attributes)
	{
		AttrsImpl = attributes;
	}

	private Type[] GetCustomModifiers(bool optional)
	{
		return GetTypeModifiers(ParameterType, Member, Position, optional) ?? Type.EmptyTypes;
	}

	internal Type[] GetCustomModifiersFromModifiedType(bool optional, int genericArgumentPosition)
	{
		return GetTypeModifiers(ParameterType, Member, Position, optional, genericArgumentPosition) ?? Type.EmptyTypes;
	}

	public override Type GetModifiedParameterType()
	{
		return ModifiedType.Create(ParameterType, this);
	}
}
