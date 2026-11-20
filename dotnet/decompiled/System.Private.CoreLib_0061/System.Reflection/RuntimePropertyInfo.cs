using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using Mono;

namespace System.Reflection;

[StructLayout(LayoutKind.Sequential)]
internal sealed class RuntimePropertyInfo : PropertyInfo
{
	private delegate object GetterAdapter(object _this);

	private delegate R Getter<T, R>(T _this);

	private delegate R StaticGetter<R>();

	internal nint klass;

	internal nint prop;

	private MonoPropertyInfo info;

	private PInfo cached;

	private GetterAdapter cached_getter;

	internal BindingFlags BindingFlags
	{
		get
		{
			CachePropertyInfo(PInfo.GetMethod | PInfo.SetMethod);
			MethodInfo set_method = info.set_method;
			bool isPublic = ((object)set_method != null && set_method.IsPublic) || (info.get_method?.IsPublic ?? false);
			MethodInfo set_method2 = info.set_method;
			bool isStatic = ((object)set_method2 != null && set_method2.IsStatic) || (info.get_method?.IsStatic ?? false);
			bool isInherited = DeclaringType != ReflectedType;
			return FilterPreCalculate(isPublic, isInherited, isStatic);
		}
	}

	public override Module Module => GetRuntimeModule();

	public override bool IsCollectible => false;

	public override PropertyAttributes Attributes
	{
		get
		{
			CachePropertyInfo(PInfo.Attributes);
			return info.attrs;
		}
	}

	public override bool CanRead
	{
		get
		{
			CachePropertyInfo(PInfo.GetMethod);
			return info.get_method != null;
		}
	}

	public override bool CanWrite
	{
		get
		{
			CachePropertyInfo(PInfo.SetMethod);
			return info.set_method != null;
		}
	}

	public override Type PropertyType
	{
		get
		{
			CachePropertyInfo(PInfo.GetMethod | PInfo.SetMethod);
			if (info.get_method != null)
			{
				return info.get_method.ReturnType;
			}
			ParameterInfo[] parametersInternal = info.set_method.GetParametersInternal();
			if (parametersInternal.Length == 0)
			{
				throw new ArgumentException("SetterHasNoParams", "indexer");
			}
			return parametersInternal[^1].ParameterType;
		}
	}

	public override Type ReflectedType
	{
		get
		{
			CachePropertyInfo(PInfo.ReflectedType);
			return info.parent;
		}
	}

	public override Type DeclaringType
	{
		get
		{
			CachePropertyInfo(PInfo.DeclaringType);
			return info.declaring_type;
		}
	}

	public override string Name
	{
		get
		{
			CachePropertyInfo(PInfo.Name);
			return info.name;
		}
	}

	public override int MetadataToken => get_metadata_token(this);

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern void get_property_info(RuntimePropertyInfo prop, ref MonoPropertyInfo info, PInfo req_info);

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern Type[] GetTypeModifiers(RuntimePropertyInfo prop, bool optional, int genericArgumentPosition = -1);

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern object get_default_value(RuntimePropertyInfo prop);

	private static BindingFlags FilterPreCalculate(bool isPublic, bool isInherited, bool isStatic)
	{
		BindingFlags bindingFlags = (isPublic ? BindingFlags.Public : BindingFlags.NonPublic);
		if (isInherited)
		{
			bindingFlags |= BindingFlags.DeclaredOnly;
			if (isStatic)
			{
				return bindingFlags | (BindingFlags.Static | BindingFlags.FlattenHierarchy);
			}
			return bindingFlags | BindingFlags.Instance;
		}
		if (isStatic)
		{
			return bindingFlags | BindingFlags.Static;
		}
		return bindingFlags | BindingFlags.Instance;
	}

	internal RuntimeType GetDeclaringTypeInternal()
	{
		return (RuntimeType)DeclaringType;
	}

	internal RuntimeModule GetRuntimeModule()
	{
		return GetDeclaringTypeInternal().GetRuntimeModule();
	}

	public override string ToString()
	{
		return FormatNameAndSig();
	}

	private string FormatNameAndSig()
	{
		StringBuilder stringBuilder = new StringBuilder(PropertyType.FormatTypeName());
		stringBuilder.Append(' ');
		stringBuilder.Append(Name);
		ParameterInfo[] indexParameters = GetIndexParameters();
		if (indexParameters.Length != 0)
		{
			stringBuilder.Append(" [");
			RuntimeParameterInfo.FormatParameters(stringBuilder, indexParameters, (CallingConventions)0);
			stringBuilder.Append(']');
		}
		return stringBuilder.ToString();
	}

	private void CachePropertyInfo(PInfo flags)
	{
		if ((cached & flags) != flags)
		{
			get_property_info(this, ref info, flags);
			cached |= flags;
		}
	}

	public override MethodInfo[] GetAccessors(bool nonPublic)
	{
		int num = 0;
		int num2 = 0;
		CachePropertyInfo(PInfo.GetMethod | PInfo.SetMethod);
		if (info.set_method != null && (nonPublic || info.set_method.IsPublic))
		{
			num2 = 1;
		}
		if (info.get_method != null && (nonPublic || info.get_method.IsPublic))
		{
			num = 1;
		}
		MethodInfo[] array = new MethodInfo[num + num2];
		int num3 = 0;
		if (num2 != 0)
		{
			array[num3++] = info.set_method;
		}
		if (num != 0)
		{
			array[num3++] = info.get_method;
		}
		return array;
	}

	public override MethodInfo GetGetMethod(bool nonPublic)
	{
		CachePropertyInfo(PInfo.GetMethod);
		if (info.get_method != null && (nonPublic || info.get_method.IsPublic))
		{
			return info.get_method;
		}
		return null;
	}

	public override ParameterInfo[] GetIndexParameters()
	{
		CachePropertyInfo(PInfo.GetMethod | PInfo.SetMethod);
		ParameterInfo[] parametersInternal;
		int num;
		if (info.get_method != null)
		{
			parametersInternal = info.get_method.GetParametersInternal();
			num = parametersInternal.Length;
		}
		else
		{
			if (!(info.set_method != null))
			{
				return Array.Empty<ParameterInfo>();
			}
			parametersInternal = info.set_method.GetParametersInternal();
			num = parametersInternal.Length - 1;
		}
		ParameterInfo[] array = new ParameterInfo[num];
		for (int i = 0; i < num; i++)
		{
			array[i] = RuntimeParameterInfo.New(parametersInternal[i], this);
		}
		return array;
	}

	public override MethodInfo GetSetMethod(bool nonPublic)
	{
		CachePropertyInfo(PInfo.SetMethod);
		if (info.set_method != null && (nonPublic || info.set_method.IsPublic))
		{
			return info.set_method;
		}
		return null;
	}

	public override object GetConstantValue()
	{
		return get_default_value(this);
	}

	public override object GetRawConstantValue()
	{
		return get_default_value(this);
	}

	public override bool IsDefined(Type attributeType, bool inherit)
	{
		return CustomAttribute.IsDefined(this, attributeType, inherit: false);
	}

	public override object[] GetCustomAttributes(bool inherit)
	{
		return CustomAttribute.GetCustomAttributes(this, inherit: false);
	}

	public override object[] GetCustomAttributes(Type attributeType, bool inherit)
	{
		return CustomAttribute.GetCustomAttributes(this, attributeType, inherit: false);
	}

	private static object GetterAdapterFrame<T, R>(Getter<T, R> getter, object obj)
	{
		return getter((T)obj);
	}

	private static object StaticGetterAdapterFrame<R>(StaticGetter<R> getter, object _)
	{
		return getter();
	}

	private static GetterAdapter CreateGetterDelegate(MethodInfo method)
	{
		Type[] typeArguments;
		Type typeFromHandle;
		string name;
		if (method.IsStatic)
		{
			typeArguments = new Type[1] { method.ReturnType };
			typeFromHandle = typeof(StaticGetter<>);
			name = "StaticGetterAdapterFrame";
		}
		else
		{
			typeArguments = new Type[2] { method.DeclaringType, method.ReturnType };
			typeFromHandle = typeof(Getter<, >);
			name = "GetterAdapterFrame";
		}
		object firstArgument = Delegate.CreateDelegate(typeFromHandle.MakeGenericType(typeArguments), method);
		MethodInfo method2 = typeof(RuntimePropertyInfo).GetMethod(name, BindingFlags.Static | BindingFlags.NonPublic);
		method2 = method2.MakeGenericMethod(typeArguments);
		return (GetterAdapter)Delegate.CreateDelegate(typeof(GetterAdapter), firstArgument, method2, throwOnBindFailure: true);
	}

	public override object GetValue(object obj, object[] index)
	{
		if (index == null || index.Length == 0)
		{
			_ = 1;
			if (cached_getter != null)
			{
				try
				{
					return cached_getter(obj);
				}
				catch (Exception inner)
				{
					throw new TargetInvocationException(inner);
				}
			}
			MethodInfo getMethod = GetGetMethod(nonPublic: true);
			if (getMethod == null)
			{
				throw new ArgumentException("Arg_GetMethNotFnd");
			}
			if (!DeclaringType.IsValueType && !PropertyType.IsByRef && !getMethod.ContainsGenericParameters)
			{
				cached_getter = CreateGetterDelegate(getMethod);
				try
				{
					return cached_getter(obj);
				}
				catch (Exception inner2)
				{
					throw new TargetInvocationException(inner2);
				}
			}
		}
		return GetValue(obj, BindingFlags.Default, null, index, null);
	}

	public override object GetValue(object obj, BindingFlags invokeAttr, Binder binder, object[] index, CultureInfo culture)
	{
		MethodInfo getMethod = GetGetMethod(nonPublic: true);
		if (getMethod == null)
		{
			throw new ArgumentException("Arg_GetMethNotFnd");
		}
		if (index == null || index.Length == 0)
		{
			return getMethod.Invoke(obj, invokeAttr, binder, null, culture);
		}
		return getMethod.Invoke(obj, invokeAttr, binder, index, culture);
	}

	public override void SetValue(object obj, object value, BindingFlags invokeAttr, Binder binder, object[] index, CultureInfo culture)
	{
		MethodInfo setMethod = GetSetMethod(nonPublic: true);
		if (setMethod == null)
		{
			throw new ArgumentException("Arg_SetMethNotFnd");
		}
		object[] array;
		if (index == null || index.Length == 0)
		{
			array = new object[1] { value };
		}
		else
		{
			int num = index.Length;
			array = new object[num + 1];
			index.CopyTo(array, 0);
			array[num] = value;
		}
		setMethod.Invoke(obj, invokeAttr, binder, array, culture);
	}

	public override Type[] GetOptionalCustomModifiers()
	{
		return GetCustomModifiers(optional: true);
	}

	public override Type[] GetRequiredCustomModifiers()
	{
		return GetCustomModifiers(optional: false);
	}

	private Type[] GetCustomModifiers(bool optional)
	{
		return GetTypeModifiers(this, optional) ?? Type.EmptyTypes;
	}

	public override IList<CustomAttributeData> GetCustomAttributesData()
	{
		return RuntimeCustomAttributeData.GetCustomAttributesInternal(this);
	}

	public sealed override bool HasSameMetadataDefinitionAs(MemberInfo other)
	{
		return HasSameMetadataDefinitionAsCore<RuntimePropertyInfo>(other);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern int get_metadata_token(RuntimePropertyInfo monoProperty);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern PropertyInfo internal_from_handle_type(nint event_handle, nint type_handle);

	internal static PropertyInfo GetPropertyFromHandle(RuntimePropertyHandle handle, RuntimeTypeHandle reflectedType)
	{
		if (handle.Value == IntPtr.Zero)
		{
			throw new ArgumentException("Argument_InvalidHandle");
		}
		PropertyInfo propertyInfo = internal_from_handle_type(handle.Value, reflectedType.Value);
		if (propertyInfo == null)
		{
			throw new ArgumentException("Argument_FieldPropertyEventAndTypeHandleIncompatibility");
		}
		return propertyInfo;
	}

	internal Type[] GetCustomModifiersFromModifiedType(bool optional, int genericArgumentPosition)
	{
		return GetTypeModifiers(this, optional, genericArgumentPosition) ?? Type.EmptyTypes;
	}

	public override Type GetModifiedPropertyType()
	{
		return ModifiedType.Create(PropertyType, this);
	}
}
