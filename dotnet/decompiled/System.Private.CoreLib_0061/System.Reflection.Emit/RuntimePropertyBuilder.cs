using System.Globalization;
using System.Runtime.InteropServices;

namespace System.Reflection.Emit;

[StructLayout(LayoutKind.Sequential)]
internal sealed class RuntimePropertyBuilder : PropertyBuilder
{
	private PropertyAttributes attrs;

	private string name;

	private Type type;

	private Type[] parameters;

	private CustomAttributeBuilder[] cattrs;

	private object def_value;

	private MethodBuilder set_method;

	private MethodBuilder get_method;

	private int table_idx;

	internal RuntimeTypeBuilder typeb;

	private Type[] returnModReq;

	private Type[] returnModOpt;

	private Type[][] paramModReq;

	private Type[][] paramModOpt;

	private CallingConventions callingConvention;

	public override PropertyAttributes Attributes => attrs;

	public override bool CanRead => get_method != null;

	public override bool CanWrite => set_method != null;

	public override Type DeclaringType => typeb;

	public override string Name => name;

	public override Type PropertyType => type;

	public override Type ReflectedType => typeb;

	public override Module Module => base.Module;

	internal RuntimePropertyBuilder(RuntimeTypeBuilder tb, string name, PropertyAttributes attributes, CallingConventions callingConvention, Type returnType, Type[] returnModReq, Type[] returnModOpt, Type[] parameterTypes, Type[][] paramModReq, Type[][] paramModOpt)
	{
		this.name = name;
		attrs = attributes;
		this.callingConvention = callingConvention;
		type = returnType ?? typeof(void);
		this.returnModReq = returnModReq;
		this.returnModOpt = returnModOpt;
		this.paramModReq = paramModReq;
		this.paramModOpt = paramModOpt;
		if (parameterTypes != null)
		{
			parameters = new Type[parameterTypes.Length];
			Array.Copy(parameterTypes, parameters, parameters.Length);
		}
		typeb = tb;
		table_idx = tb.get_next_table_index(23, 1);
	}

	protected override void AddOtherMethodCore(MethodBuilder mdBuilder)
	{
		ArgumentNullException.ThrowIfNull(mdBuilder, "mdBuilder");
		typeb.check_not_created();
	}

	public override MethodInfo[] GetAccessors(bool nonPublic)
	{
		return null;
	}

	public override object[] GetCustomAttributes(bool inherit)
	{
		throw not_supported();
	}

	public override object[] GetCustomAttributes(Type attributeType, bool inherit)
	{
		throw not_supported();
	}

	public override MethodInfo GetGetMethod(bool nonPublic)
	{
		return get_method;
	}

	public override ParameterInfo[] GetIndexParameters()
	{
		throw not_supported();
	}

	public override MethodInfo GetSetMethod(bool nonPublic)
	{
		return set_method;
	}

	public override object GetValue(object obj, object[] index)
	{
		throw not_supported();
	}

	public override object GetValue(object obj, BindingFlags invokeAttr, Binder binder, object[] index, CultureInfo culture)
	{
		throw not_supported();
	}

	public override bool IsDefined(Type attributeType, bool inherit)
	{
		throw not_supported();
	}

	protected override void SetConstantCore(object defaultValue)
	{
		typeb.check_not_created();
		def_value = defaultValue;
	}

	protected override void SetCustomAttributeCore(ConstructorInfo con, ReadOnlySpan<byte> binaryAttribute)
	{
		typeb.check_not_created();
		if (con.ReflectedType.FullName == "System.Runtime.CompilerServices.SpecialNameAttribute")
		{
			attrs |= PropertyAttributes.SpecialName;
			return;
		}
		CustomAttributeBuilder customAttributeBuilder = new CustomAttributeBuilder(con, binaryAttribute);
		if (cattrs != null)
		{
			CustomAttributeBuilder[] array = new CustomAttributeBuilder[cattrs.Length + 1];
			cattrs.CopyTo(array, 0);
			array[cattrs.Length] = customAttributeBuilder;
			cattrs = array;
		}
		else
		{
			cattrs = new CustomAttributeBuilder[1];
			cattrs[0] = customAttributeBuilder;
		}
	}

	protected override void SetGetMethodCore(MethodBuilder mdBuilder)
	{
		typeb.check_not_created();
		ArgumentNullException.ThrowIfNull(mdBuilder, "mdBuilder");
		get_method = mdBuilder;
	}

	protected override void SetSetMethodCore(MethodBuilder mdBuilder)
	{
		ArgumentNullException.ThrowIfNull(mdBuilder, "mdBuilder");
		set_method = mdBuilder;
	}

	public override void SetValue(object obj, object value, object[] index)
	{
		throw not_supported();
	}

	public override void SetValue(object obj, object value, BindingFlags invokeAttr, Binder binder, object[] index, CultureInfo culture)
	{
		throw not_supported();
	}

	private static NotSupportedException not_supported()
	{
		return new NotSupportedException("NotSupported_DynamicModule");
	}
}
