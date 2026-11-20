using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace System.Reflection.Emit;

[StructLayout(LayoutKind.Sequential)]
public class CustomAttributeBuilder
{
	internal struct CustomAttributeInfo
	{
		public ConstructorInfo ctor;

		public object[] ctorArgs;

		public string[] namedParamNames;

		public object[] namedParamValues;
	}

	private ConstructorInfo ctor;

	private byte[] data;

	private object[] args;

	private PropertyInfo[] namedProperties;

	private object[] propertyValues;

	private FieldInfo[] namedFields;

	private object[] fieldValues;

	internal ConstructorInfo Ctor => ctor;

	internal byte[] Data => data;

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern byte[] GetBlob(Assembly asmb, ConstructorInfo con, object[] constructorArgs, PropertyInfo[] namedProperties, object[] propertyValues, FieldInfo[] namedFields, object[] fieldValues);

	internal CustomAttributeBuilder(ConstructorInfo con, ReadOnlySpan<byte> binaryAttribute)
	{
		ArgumentNullException.ThrowIfNull(con, "con");
		ctor = con;
		data = binaryAttribute.ToArray();
	}

	public CustomAttributeBuilder(ConstructorInfo con, object?[] constructorArgs)
	{
		Initialize(con, constructorArgs, Array.Empty<PropertyInfo>(), Array.Empty<object>(), Array.Empty<FieldInfo>(), Array.Empty<object>());
	}

	public CustomAttributeBuilder(ConstructorInfo con, object?[] constructorArgs, FieldInfo[] namedFields, object[] fieldValues)
	{
		Initialize(con, constructorArgs, Array.Empty<PropertyInfo>(), Array.Empty<object>(), namedFields, fieldValues);
	}

	public CustomAttributeBuilder(ConstructorInfo con, object?[] constructorArgs, PropertyInfo[] namedProperties, object[] propertyValues)
	{
		Initialize(con, constructorArgs, namedProperties, propertyValues, Array.Empty<FieldInfo>(), Array.Empty<object>());
	}

	public CustomAttributeBuilder(ConstructorInfo con, object?[] constructorArgs, PropertyInfo[] namedProperties, object[] propertyValues, FieldInfo[] namedFields, object[] fieldValues)
	{
		Initialize(con, constructorArgs, namedProperties, propertyValues, namedFields, fieldValues);
	}

	private static bool IsValidType(Type t)
	{
		if (t.IsArray && t.GetArrayRank() > 1)
		{
			return false;
		}
		if (t is TypeBuilder && t.IsEnum)
		{
			Enum.GetUnderlyingType(t);
		}
		if (t.IsClass && !t.IsArray && !(t == typeof(object)) && !typeof(Type).IsAssignableFrom(t) && !(t == typeof(string)) && !(t.Assembly.GetName().Name == "mscorlib"))
		{
			return false;
		}
		if (t.IsValueType && !t.IsPrimitive && !t.IsEnum && (!(t.Assembly is AssemblyBuilder) || !(t.Assembly.GetName().Name == "mscorlib")))
		{
			return false;
		}
		return true;
	}

	private static bool IsValidParam(object o, Type paramType)
	{
		Type type = o.GetType();
		if (!IsValidType(type))
		{
			return false;
		}
		if (paramType == typeof(object))
		{
			if (type.IsArray && type.GetArrayRank() == 1)
			{
				return IsValidType(type.GetElementType());
			}
			if (!type.IsPrimitive && !typeof(Type).IsAssignableFrom(type) && type != typeof(string) && !type.IsEnum)
			{
				return false;
			}
		}
		return true;
	}

	private static bool IsValidValue(Type type, object value)
	{
		if (type.IsValueType && value == null)
		{
			return false;
		}
		if (type.IsArray && type.GetElementType().IsValueType && value != null)
		{
			foreach (object item in (Array)value)
			{
				if (item == null)
				{
					return false;
				}
			}
		}
		return true;
	}

	private void Initialize(ConstructorInfo con, object[] constructorArgs, PropertyInfo[] namedProperties, object[] propertyValues, FieldInfo[] namedFields, object[] fieldValues)
	{
		ctor = con;
		args = constructorArgs;
		this.namedProperties = namedProperties;
		this.propertyValues = propertyValues;
		this.namedFields = namedFields;
		this.fieldValues = fieldValues;
		ArgumentNullException.ThrowIfNull(con, "con");
		ArgumentNullException.ThrowIfNull(constructorArgs, "constructorArgs");
		ArgumentNullException.ThrowIfNull(namedProperties, "namedProperties");
		ArgumentNullException.ThrowIfNull(propertyValues, "propertyValues");
		ArgumentNullException.ThrowIfNull(namedFields, "namedFields");
		ArgumentNullException.ThrowIfNull(fieldValues, "fieldValues");
		AssemblyBuilder.EnsureDynamicCodeSupported();
		if (con.GetParametersCount() != constructorArgs.Length)
		{
			throw new ArgumentException("Argument_BadParameterCountsForConstructor");
		}
		if (namedProperties.Length != propertyValues.Length)
		{
			throw new ArgumentException("Arg_ArrayLengthsDiffer", "namedProperties, propertyValues");
		}
		if (namedFields.Length != fieldValues.Length)
		{
			throw new ArgumentException("Arg_ArrayLengthsDiffer", "namedFields, fieldValues");
		}
		if ((con.Attributes & MethodAttributes.Static) == MethodAttributes.Static || (con.Attributes & MethodAttributes.MemberAccessMask) == MethodAttributes.Private)
		{
			throw new ArgumentException("Argument_BadConstructor");
		}
		Type declaringType = ctor.DeclaringType;
		int num = 0;
		foreach (FieldInfo fieldInfo in namedFields)
		{
			Type declaringType2 = fieldInfo.DeclaringType;
			if (declaringType != declaringType2 && !declaringType2.IsSubclassOf(declaringType) && !declaringType.IsSubclassOf(declaringType2))
			{
				throw new ArgumentException(SR.Format("Argument_FieldDoesNotBelongToConstructorClass", fieldInfo.Name));
			}
			if (!IsValidType(fieldInfo.FieldType))
			{
				throw new ArgumentException(SR.Format("Argument_FieldDoesNotHaveAValidType", fieldInfo.Name));
			}
			if (!IsValidValue(fieldInfo.FieldType, fieldValues[num]))
			{
				throw new ArgumentException(SR.Format("Argument_FieldDoesNotHaveAValidValue", fieldInfo.Name));
			}
			if (fieldValues[num] != null && !(fieldInfo.FieldType is TypeBuilder) && !fieldInfo.FieldType.IsEnum && !fieldInfo.FieldType.IsInstanceOfType(fieldValues[num]) && !fieldInfo.FieldType.IsArray)
			{
				throw new ArgumentException(SR.Format("Argument_UnmatchedFieldValueAndType", fieldInfo.Name, fieldInfo.FieldType));
			}
			num++;
		}
		num = 0;
		foreach (PropertyInfo propertyInfo in namedProperties)
		{
			if (!propertyInfo.CanWrite)
			{
				throw new ArgumentException(SR.Format("Argument_PropertyMissingSetter", propertyInfo.Name));
			}
			Type declaringType3 = propertyInfo.DeclaringType;
			if (declaringType != declaringType3 && !declaringType3.IsSubclassOf(declaringType) && !declaringType.IsSubclassOf(declaringType3))
			{
				throw new ArgumentException(SR.Format("Argument_PropertyClassUnmatchedWithConstructor", propertyInfo.Name));
			}
			if (!IsValidType(propertyInfo.PropertyType))
			{
				throw new ArgumentException(SR.Format("Argument_PropertyInvalidType", propertyInfo.Name));
			}
			if (!IsValidValue(propertyInfo.PropertyType, propertyValues[num]))
			{
				throw new ArgumentException(SR.Format("Argument_PropertyInvalidValue", propertyInfo.Name));
			}
			if (propertyValues[num] != null && !(propertyInfo.PropertyType is TypeBuilder) && !propertyInfo.PropertyType.IsEnum && !propertyInfo.PropertyType.IsInstanceOfType(propertyValues[num]) && !propertyInfo.PropertyType.IsArray)
			{
				throw new ArgumentException(SR.Format("Argument_PropertyUnmatchingPropertyType", propertyInfo.Name, propertyInfo.PropertyType, propertyValues[num]));
			}
			num++;
		}
		num = 0;
		ParameterInfo[] parameters = GetParameters(con);
		foreach (ParameterInfo parameterInfo in parameters)
		{
			if (parameterInfo != null)
			{
				Type parameterType = parameterInfo.ParameterType;
				if (!IsValidType(parameterType))
				{
					throw new ArgumentException(SR.Format("Argument_ParameterInvalidType", num));
				}
				if (!IsValidValue(parameterType, constructorArgs[num]))
				{
					throw new ArgumentException(SR.Format("Argument_ParameterInvalidValue", num));
				}
				if (constructorArgs[num] != null)
				{
					if (!(parameterType is TypeBuilder) && !parameterType.IsEnum && !parameterType.IsInstanceOfType(constructorArgs[num]) && !parameterType.IsArray)
					{
						throw new ArgumentException(SR.Format("Argument_ParameterHasUnmatchedArgumentValue", num, parameterType, constructorArgs[num]));
					}
					if (!IsValidParam(constructorArgs[num], parameterType))
					{
						throw new ArgumentException(SR.Format("Argument_BadParameterTypeForCAB", constructorArgs[num].GetType()));
					}
				}
			}
			num++;
		}
		data = GetBlob(declaringType.Assembly, con, constructorArgs, namedProperties, propertyValues, namedFields, fieldValues);
	}

	internal static int decode_len(ReadOnlySpan<byte> data, int pos, out int rpos)
	{
		int result;
		if ((data[pos] & 0x80) == 0)
		{
			result = data[pos++] & 0x7F;
		}
		else if ((data[pos] & 0x40) == 0)
		{
			result = ((data[pos] & 0x3F) << 8) + data[pos + 1];
			pos += 2;
		}
		else
		{
			result = ((data[pos] & 0x1F) << 24) + (data[pos + 1] << 16) + (data[pos + 2] << 8) + data[pos + 3];
			pos += 4;
		}
		rpos = pos;
		return result;
	}

	internal static string string_from_bytes(ReadOnlySpan<byte> data, int pos, int len)
	{
		return Encoding.UTF8.GetString(data.Slice(pos, len));
	}

	internal static string decode_string(byte[] data, int pos, out int rpos)
	{
		if (data[pos] == byte.MaxValue)
		{
			rpos = pos + 1;
			return null;
		}
		int num = decode_len(data, pos, out pos);
		string result = string_from_bytes(data, pos, num);
		pos += num;
		rpos = pos;
		return result;
	}

	[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2057:UnrecognizedReflectionPattern", Justification = "Types referenced from custom attributes are preserved")]
	internal static UnmanagedMarshal get_umarshal(CustomAttributeBuilder customBuilder, bool is_field)
	{
		byte[] array = customBuilder.Data;
		UnmanagedType elemType = (UnmanagedType)80;
		int num = -1;
		int sizeParamIndex = -1;
		bool flag = false;
		string text = null;
		_ = string.Empty;
		int num2 = array[2];
		num2 |= array[3] << 8;
		string? fullName = GetParameters(customBuilder.Ctor)[0].ParameterType.FullName;
		int rpos = 6;
		if (fullName == "System.Int16")
		{
			rpos = 4;
		}
		int num3 = array[rpos++];
		num3 |= array[rpos++] << 8;
		for (int i = 0; i < num3; i++)
		{
			_ = array[rpos++];
			if (array[rpos++] == 85)
			{
				decode_string(array, rpos, out rpos);
			}
			string text2 = decode_string(array, rpos, out rpos);
			switch (text2)
			{
			case "ArraySubType":
				elemType = (UnmanagedType)(array[rpos++] | (array[rpos++] << 8) | (array[rpos++] << 16) | (array[rpos++] << 24));
				break;
			case "SizeConst":
				num = array[rpos++] | (array[rpos++] << 8) | (array[rpos++] << 16) | (array[rpos++] << 24);
				flag = true;
				break;
			case "SafeArraySubType":
				elemType = (UnmanagedType)(array[rpos++] | (array[rpos++] << 8) | (array[rpos++] << 16) | (array[rpos++] << 24));
				break;
			case "IidParameterIndex":
				rpos += 4;
				break;
			case "SafeArrayUserDefinedSubType":
				decode_string(array, rpos, out rpos);
				break;
			case "SizeParamIndex":
				sizeParamIndex = array[rpos++] | (array[rpos++] << 8);
				flag = true;
				break;
			case "MarshalType":
				text = decode_string(array, rpos, out rpos);
				break;
			case "MarshalTypeRef":
				text = decode_string(array, rpos, out rpos);
				if (text != null)
				{
					Type.GetType(text);
				}
				break;
			case "MarshalCookie":
				decode_string(array, rpos, out rpos);
				break;
			default:
				throw new Exception(SR.Format("Exception_UnknownMarshalAsAttributeField", text2));
			}
		}
		switch ((UnmanagedType)num2)
		{
		case UnmanagedType.LPArray:
			if (flag)
			{
				return UnmanagedMarshal.DefineLPArrayInternal(elemType, num, sizeParamIndex);
			}
			return UnmanagedMarshal.DefineLPArray(elemType);
		case UnmanagedType.ByValArray:
			if (!is_field)
			{
				throw new ArgumentException("Argument_UnmanagedTypeOnlyValidOnFields");
			}
			return UnmanagedMarshal.DefineByValArray(num);
		case UnmanagedType.ByValTStr:
			return UnmanagedMarshal.DefineByValTStr(num);
		default:
			return UnmanagedMarshal.DefineUnmanagedMarshal((UnmanagedType)num2);
		}
	}

	private static Type elementTypeToType(int elementType)
	{
		return elementType switch
		{
			2 => typeof(bool), 
			3 => typeof(char), 
			4 => typeof(sbyte), 
			5 => typeof(byte), 
			6 => typeof(short), 
			7 => typeof(ushort), 
			8 => typeof(int), 
			9 => typeof(uint), 
			10 => typeof(long), 
			11 => typeof(ulong), 
			12 => typeof(float), 
			13 => typeof(double), 
			14 => typeof(string), 
			_ => throw new Exception(SR.Format("ArgumentException_InvalidTypeArgument", elementType)), 
		};
	}

	private static object decode_cattr_value(Type t, ReadOnlySpan<byte> data, int pos, out int rpos)
	{
		switch (Type.GetTypeCode(t))
		{
		case TypeCode.String:
		{
			if (data[pos] == byte.MaxValue)
			{
				rpos = pos + 1;
				return null;
			}
			int num = decode_len(data, pos, out pos);
			rpos = pos + num;
			return string_from_bytes(data, pos, num);
		}
		case TypeCode.Int32:
			rpos = pos + 4;
			return data[pos] + (data[pos + 1] << 8) + (data[pos + 2] << 16) + (data[pos + 3] << 24);
		case TypeCode.Boolean:
			rpos = pos + 1;
			return data[pos] != 0;
		case TypeCode.Object:
		{
			int num2 = data[pos];
			pos++;
			if (num2 >= 2 && num2 <= 14)
			{
				return decode_cattr_value(elementTypeToType(num2), data, pos, out rpos);
			}
			throw new Exception("Exception_UnhandledSubType");
		}
		default:
			throw new Exception("FIXME: Type " + t?.ToString() + " not yet handled in decode_cattr_value.");
		}
	}

	internal static CustomAttributeInfo decode_cattr(CustomAttributeBuilder customBuilder)
	{
		byte[] array = customBuilder.Data;
		return decode_cattr(customBuilder.Ctor, array);
	}

	[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2057:UnrecognizedReflectionPattern", Justification = "Types referenced from custom attributes are preserved")]
	[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2075:UnrecognizedReflectionPattern", Justification = "Types referenced from custom attributes are preserved")]
	internal static CustomAttributeInfo decode_cattr(ConstructorInfo ctor, ReadOnlySpan<byte> data)
	{
		CustomAttributeInfo result = default(CustomAttributeInfo);
		if (data.Length < 2)
		{
			throw new Exception(SR.Format("Exception_InvalidCustomAttributeLength", data.Length));
		}
		if (data[0] != 1 || data[1] != 0)
		{
			throw new Exception("Exception_InvalidProlog");
		}
		int rpos = 2;
		ParameterInfo[] parameters = GetParameters(ctor);
		result.ctor = ctor;
		result.ctorArgs = new object[parameters.Length];
		for (int i = 0; i < parameters.Length; i++)
		{
			result.ctorArgs[i] = decode_cattr_value(parameters[i].ParameterType, data, rpos, out rpos);
		}
		int num = data[rpos] + data[rpos + 1] * 256;
		rpos += 2;
		result.namedParamNames = new string[num];
		result.namedParamValues = new object[num];
		for (int j = 0; j < num; j++)
		{
			int num2 = data[rpos++];
			byte num3 = data[rpos++];
			string text = null;
			if (num3 == 85)
			{
				int num4 = decode_len(data, rpos, out rpos);
				text = string_from_bytes(data, rpos, num4);
				rpos += num4;
			}
			int num5 = decode_len(data, rpos, out rpos);
			string text2 = string_from_bytes(data, rpos, num5);
			result.namedParamNames[j] = text2;
			rpos += num5;
			if (num2 == 83)
			{
				FieldInfo? field = ctor.DeclaringType.GetField(text2, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
				if (field == null)
				{
					throw new Exception(SR.Format("Exception_EmptyFieldForCustomAttributeType", ctor.DeclaringType, text2));
				}
				object obj = decode_cattr_value(field.FieldType, data, rpos, out rpos);
				if (text != null)
				{
					obj = Enum.ToObject(Type.GetType(text), obj);
				}
				result.namedParamValues[j] = obj;
				continue;
			}
			throw new Exception(SR.Format("Exception_UnknownNamedType", num2));
		}
		return result;
	}

	private static ParameterInfo[] GetParameters(ConstructorInfo ctor)
	{
		if (ctor is ConstructorBuilder constructorBuilder)
		{
			return constructorBuilder.GetParametersInternal();
		}
		return ctor.GetParametersInternal();
	}
}
