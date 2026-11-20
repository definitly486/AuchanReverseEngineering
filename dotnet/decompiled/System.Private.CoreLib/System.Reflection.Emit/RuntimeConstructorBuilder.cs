using System.Buffers.Binary;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.InteropServices;

namespace System.Reflection.Emit;

[StructLayout(LayoutKind.Sequential)]
internal sealed class RuntimeConstructorBuilder : ConstructorBuilder
{
	private RuntimeMethodHandle mhandle;

	private RuntimeILGenerator ilgen;

	internal Type[] parameters;

	private MethodAttributes attrs;

	private MethodImplAttributes iattrs;

	private int table_idx;

	private CallingConventions call_conv;

	private RuntimeTypeBuilder type;

	internal ParameterBuilder[] pinfo;

	private CustomAttributeBuilder[] cattrs;

	private bool init_locals = true;

	private Type[][] paramModReq;

	private Type[][] paramModOpt;

	internal bool finished;

	public override CallingConventions CallingConvention => call_conv;

	protected override bool InitLocalsCore
	{
		get
		{
			return init_locals;
		}
		set
		{
			init_locals = value;
		}
	}

	internal RuntimeTypeBuilder TypeBuilder => type;

	public override int MetadataToken => 0x6000000 | table_idx;

	public override RuntimeMethodHandle MethodHandle
	{
		get
		{
			throw not_supported();
		}
	}

	public override MethodAttributes Attributes => attrs;

	public override Type ReflectedType => type;

	public override Type DeclaringType => type;

	public override string Name
	{
		get
		{
			if ((attrs & MethodAttributes.Static) == 0)
			{
				return ConstructorInfo.ConstructorName;
			}
			return ConstructorInfo.TypeConstructorName;
		}
	}

	public override Module Module => type.Module;

	internal RuntimeConstructorBuilder(RuntimeTypeBuilder tb, MethodAttributes attributes, CallingConventions callingConvention, Type[] parameterTypes, Type[][] paramModReq, Type[][] paramModOpt)
	{
		attrs = attributes | MethodAttributes.SpecialName | MethodAttributes.RTSpecialName;
		call_conv = callingConvention;
		if (parameterTypes != null)
		{
			for (int i = 0; i < parameterTypes.Length; i++)
			{
				ArgumentNullException.ThrowIfNull(parameterTypes[i], "parameterTypes");
			}
			parameters = new Type[parameterTypes.Length];
			Array.Copy(parameterTypes, parameters, parameterTypes.Length);
		}
		type = tb;
		this.paramModReq = paramModReq;
		this.paramModOpt = paramModOpt;
		table_idx = get_next_table_index(6, 1);
		((RuntimeModuleBuilder)tb.Module).RegisterToken(this, MetadataToken);
	}

	public override MethodImplAttributes GetMethodImplementationFlags()
	{
		return iattrs;
	}

	public override ParameterInfo[] GetParameters()
	{
		if (!type.is_created)
		{
			throw not_created();
		}
		return GetParametersInternal();
	}

	internal override ParameterInfo[] GetParametersInternal()
	{
		if (parameters == null)
		{
			return Array.Empty<ParameterInfo>();
		}
		ParameterInfo[] array = new ParameterInfo[parameters.Length];
		for (int i = 0; i < parameters.Length; i++)
		{
			int num = i;
			ParameterBuilder[] array2 = pinfo;
			array[num] = RuntimeParameterInfo.New((array2 != null) ? array2[i + 1] : null, parameters[i], this, i + 1);
		}
		return array;
	}

	internal override int GetParametersCount()
	{
		if (parameters == null)
		{
			return 0;
		}
		return parameters.Length;
	}

	internal override Type GetParameterType(int pos)
	{
		return parameters[pos];
	}

	[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2075:UnrecognizedReflectionPattern", Justification = "Linker doesn't analyze RuntimeResolve but it's an identity function")]
	internal MethodBase RuntimeResolve()
	{
		return type.RuntimeResolve().GetConstructor(this);
	}

	public override object Invoke(object obj, BindingFlags invokeAttr, Binder binder, object[] parameters, CultureInfo culture)
	{
		throw not_supported();
	}

	public override object Invoke(BindingFlags invokeAttr, Binder binder, object[] parameters, CultureInfo culture)
	{
		throw not_supported();
	}

	protected override ParameterBuilder DefineParameterCore(int iSequence, ParameterAttributes attributes, string strParamName)
	{
		ArgumentOutOfRangeException.ThrowIfNegative(iSequence, "iSequence");
		ArgumentOutOfRangeException.ThrowIfGreaterThan(iSequence, GetParametersCount(), "iSequence");
		if (type.is_created)
		{
			throw not_after_created();
		}
		ParameterBuilder parameterBuilder = new RuntimeParameterBuilder(this, iSequence, attributes, strParamName);
		if (pinfo == null)
		{
			pinfo = new ParameterBuilder[parameters.Length + 1];
		}
		pinfo[iSequence] = parameterBuilder;
		return parameterBuilder;
	}

	public override bool IsDefined(Type attributeType, bool inherit)
	{
		throw not_supported();
	}

	public override object[] GetCustomAttributes(bool inherit)
	{
		throw not_supported();
	}

	public override object[] GetCustomAttributes(Type attributeType, bool inherit)
	{
		throw not_supported();
	}

	protected override ILGenerator GetILGeneratorCore(int streamSize)
	{
		if (finished)
		{
			throw new InvalidOperationException();
		}
		if (ilgen != null)
		{
			return ilgen;
		}
		if ((attrs & (MethodAttributes.Abstract | MethodAttributes.PinvokeImpl)) != MethodAttributes.PrivateScope || (iattrs & (MethodImplAttributes)4099) != MethodImplAttributes.IL)
		{
			throw new InvalidOperationException();
		}
		ilgen = new RuntimeILGenerator(type.Module, ((RuntimeModuleBuilder)type.Module).GetTokenGenerator(), streamSize);
		return ilgen;
	}

	protected override void SetCustomAttributeCore(ConstructorInfo con, ReadOnlySpan<byte> binaryAttribute)
	{
		if (con.ReflectedType.FullName == "System.Runtime.CompilerServices.MethodImplAttribute")
		{
			int implementationFlags = BinaryPrimitives.ReadUInt16LittleEndian(binaryAttribute.Slice(2));
			SetImplementationFlags((MethodImplAttributes)implementationFlags);
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

	protected override void SetImplementationFlagsCore(MethodImplAttributes attributes)
	{
		if (type.is_created)
		{
			throw not_after_created();
		}
		iattrs = attributes;
	}

	public override string ToString()
	{
		return "Name: " + Name;
	}

	internal void fixup()
	{
		if ((attrs & (MethodAttributes.Abstract | MethodAttributes.PinvokeImpl)) == 0 && (iattrs & (MethodImplAttributes)4099) == 0 && (ilgen == null || ilgen.ILOffset == 0))
		{
			throw new InvalidOperationException(SR.Format("InvalidOperation_BadEmptyMethodBody", Name));
		}
		if (base.IsStatic && ((call_conv & CallingConventions.VarArgs) != 0 || (call_conv & CallingConventions.HasThis) != 0))
		{
			throw new TypeLoadException();
		}
		ilgen?.label_fixup(this);
	}

	internal void ResolveUserTypes()
	{
		RuntimeTypeBuilder.ResolveUserTypes(parameters);
		if (paramModReq != null)
		{
			Type[][] array = paramModReq;
			for (int i = 0; i < array.Length; i++)
			{
				RuntimeTypeBuilder.ResolveUserTypes(array[i]);
			}
		}
		if (paramModOpt != null)
		{
			Type[][] array = paramModOpt;
			for (int i = 0; i < array.Length; i++)
			{
				RuntimeTypeBuilder.ResolveUserTypes(array[i]);
			}
		}
	}

	internal override int get_next_table_index(int table, int count)
	{
		return type.get_next_table_index(table, count);
	}

	private static NotSupportedException not_supported()
	{
		return new NotSupportedException("NotSupported_DynamicModule");
	}

	private static InvalidOperationException not_after_created()
	{
		return new InvalidOperationException("InvalidOperation_TypeHasBeenCreated");
	}

	private static NotSupportedException not_created()
	{
		return new NotSupportedException("InvalidOperation_TypeNotCreated");
	}
}
