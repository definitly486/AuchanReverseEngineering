using System.Buffers.Binary;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.InteropServices;

namespace System.Reflection.Emit;

[StructLayout(LayoutKind.Sequential)]
internal sealed class RuntimeMethodBuilder : MethodBuilder
{
	private RuntimeMethodHandle mhandle;

	private Type rtype;

	internal Type[] parameters;

	private MethodAttributes attrs;

	private MethodImplAttributes iattrs;

	private string name;

	private int table_idx;

	private byte[] code;

	private RuntimeILGenerator ilgen;

	private RuntimeTypeBuilder type;

	internal ParameterBuilder[] pinfo;

	private CustomAttributeBuilder[] cattrs;

	private MethodInfo[] override_methods;

	private string pi_dll;

	private string pi_entry;

	private CharSet charset;

	private uint extra_flags;

	private CallingConvention native_cc;

	private CallingConventions call_conv;

	private bool init_locals = true;

	private nint generic_container;

	internal RuntimeGenericTypeParameterBuilder[] generic_params;

	private Type[] returnModReq;

	private Type[] returnModOpt;

	private Type[][] paramModReq;

	private Type[][] paramModOpt;

	private RuntimeMethodInfo created;

	public override bool ContainsGenericParameters
	{
		get
		{
			throw new NotSupportedException();
		}
	}

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
			throw NotSupported();
		}
	}

	internal RuntimeMethodHandle MethodHandleInternal => mhandle;

	public override Type ReturnType => rtype;

	public override Type ReflectedType => type;

	public override Type DeclaringType
	{
		get
		{
			if (type.is_hidden_global_type)
			{
				return null;
			}
			return type;
		}
	}

	public override string Name => name;

	public override MethodAttributes Attributes => attrs;

	public override ICustomAttributeProvider ReturnTypeCustomAttributes => null;

	public override CallingConventions CallingConvention => call_conv;

	internal bool BestFitMapping
	{
		set
		{
			extra_flags = (uint)((extra_flags & -49) | (uint)(value ? 16 : 32));
		}
	}

	internal bool ThrowOnUnmappableChar
	{
		set
		{
			extra_flags = (uint)((extra_flags & -12289) | (uint)(value ? 4096 : 8192));
		}
	}

	internal bool ExactSpelling
	{
		set
		{
			extra_flags = (uint)((ulong)(extra_flags & -2) | (value ? 1uL : 0uL));
		}
	}

	internal bool SetLastError
	{
		set
		{
			extra_flags = (uint)((extra_flags & -65) | (uint)(value ? 64 : 0));
		}
	}

	public override bool IsGenericMethodDefinition => generic_params != null;

	public override bool IsGenericMethod => generic_params != null;

	public override Module Module => GetModule();

	public override ParameterInfo ReturnParameter
	{
		get
		{
			if (!type.is_created)
			{
				throw new InvalidOperationException("InvalidOperation_TypeNotCreated");
			}
			if ((object)created == null)
			{
				created = (RuntimeMethodInfo)MethodBase.GetMethodFromHandle(mhandle);
			}
			return created.ReturnParameter;
		}
	}

	internal RuntimeMethodBuilder(RuntimeTypeBuilder tb, string name, MethodAttributes attributes, CallingConventions callingConvention, Type returnType, Type[] returnModReq, Type[] returnModOpt, Type[] parameterTypes, Type[][] paramModReq, Type[][] paramModOpt)
	{
		this.name = name;
		attrs = attributes;
		call_conv = callingConvention;
		rtype = returnType;
		this.returnModReq = returnModReq;
		this.returnModOpt = returnModOpt;
		this.paramModReq = paramModReq;
		this.paramModOpt = paramModOpt;
		if ((attributes & MethodAttributes.Static) == 0)
		{
			call_conv |= CallingConventions.HasThis;
		}
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
		table_idx = get_next_table_index(6, 1);
		((RuntimeModuleBuilder)tb.Module).RegisterToken(this, MetadataToken);
	}

	internal RuntimeMethodBuilder(RuntimeTypeBuilder tb, string name, MethodAttributes attributes, CallingConventions callingConvention, Type returnType, Type[] returnModReq, Type[] returnModOpt, Type[] parameterTypes, Type[][] paramModReq, Type[][] paramModOpt, string dllName, string entryName, CallingConvention nativeCConv, CharSet nativeCharset)
		: this(tb, name, attributes, callingConvention, returnType, returnModReq, returnModOpt, parameterTypes, paramModReq, paramModOpt)
	{
		pi_dll = dllName;
		pi_entry = entryName;
		native_cc = nativeCConv;
		charset = nativeCharset;
	}

	public override MethodInfo GetBaseDefinition()
	{
		return this;
	}

	public override MethodImplAttributes GetMethodImplementationFlags()
	{
		return iattrs;
	}

	public override ParameterInfo[] GetParameters()
	{
		if (!type.is_created)
		{
			throw NotSupported();
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

	internal MethodBase RuntimeResolve()
	{
		return type.RuntimeResolve().GetMethod(this);
	}

	internal Module GetModule()
	{
		return type.Module;
	}

	public override object Invoke(object obj, BindingFlags invokeAttr, Binder binder, object[] parameters, CultureInfo culture)
	{
		throw NotSupported();
	}

	public override bool IsDefined(Type attributeType, bool inherit)
	{
		throw NotSupported();
	}

	public override object[] GetCustomAttributes(bool inherit)
	{
		if (type.is_created)
		{
			return CustomAttribute.GetCustomAttributes(this, inherit);
		}
		throw NotSupported();
	}

	public override object[] GetCustomAttributes(Type attributeType, bool inherit)
	{
		if (type.is_created)
		{
			return CustomAttribute.GetCustomAttributes(this, attributeType, inherit);
		}
		throw NotSupported();
	}

	protected override ILGenerator GetILGeneratorCore(int size)
	{
		if ((iattrs & MethodImplAttributes.CodeTypeMask) != MethodImplAttributes.IL || (iattrs & MethodImplAttributes.ManagedMask) != MethodImplAttributes.IL)
		{
			throw new InvalidOperationException("InvalidOperation_ShouldNotHaveMethodBody");
		}
		if (ilgen != null)
		{
			return ilgen;
		}
		ilgen = new RuntimeILGenerator(type.Module, ((RuntimeModuleBuilder)type.Module).GetTokenGenerator(), size);
		return ilgen;
	}

	protected override ParameterBuilder DefineParameterCore(int position, ParameterAttributes attributes, string strParamName)
	{
		RejectIfCreated();
		if (position < 0 || parameters == null || position > parameters.Length)
		{
			throw new ArgumentOutOfRangeException("position");
		}
		ParameterBuilder parameterBuilder = new RuntimeParameterBuilder(this, position, attributes, strParamName);
		if (pinfo == null)
		{
			pinfo = new ParameterBuilder[parameters.Length + 1];
		}
		pinfo[position] = parameterBuilder;
		return parameterBuilder;
	}

	internal void check_override()
	{
		if (override_methods == null)
		{
			return;
		}
		MethodInfo[] array = override_methods;
		foreach (MethodInfo methodInfo in array)
		{
			if (methodInfo.IsVirtual && !base.IsVirtual && !base.IsStatic && !ReflectedType.IsInterface)
			{
				throw new TypeLoadException(SR.Format("TypeLoad_MethodOverrideNotVirtual", name, methodInfo));
			}
		}
	}

	internal void fixup()
	{
		if ((attrs & (MethodAttributes.Abstract | MethodAttributes.PinvokeImpl)) == 0 && (iattrs & (MethodImplAttributes)4099) == 0 && (ilgen == null || ilgen.ILOffset == 0) && (code == null || code.Length == 0))
		{
			throw new InvalidOperationException(SR.Format("InvalidOperation_BadEmptyMethodBody", Name));
		}
		ilgen?.label_fixup(this);
	}

	internal void ResolveUserTypes()
	{
		rtype = RuntimeTypeBuilder.ResolveUserType(rtype);
		RuntimeTypeBuilder.ResolveUserTypes(parameters);
		RuntimeTypeBuilder.ResolveUserTypes(returnModReq);
		RuntimeTypeBuilder.ResolveUserTypes(returnModOpt);
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

	protected override void SetCustomAttributeCore(ConstructorInfo con, ReadOnlySpan<byte> binaryAttribute)
	{
		switch (con.ReflectedType.FullName)
		{
		case "System.Runtime.CompilerServices.MethodImplAttribute":
		{
			int num = BinaryPrimitives.ReadUInt16LittleEndian(binaryAttribute.Slice(2));
			iattrs |= (MethodImplAttributes)num;
			return;
		}
		case "System.Runtime.InteropServices.DllImportAttribute":
		{
			CustomAttributeBuilder.CustomAttributeInfo customAttributeInfo = CustomAttributeBuilder.decode_cattr(con, binaryAttribute);
			bool flag = true;
			pi_dll = (string)customAttributeInfo.ctorArgs[0];
			if (pi_dll == null || pi_dll.Length == 0)
			{
				throw new ArgumentException("Arg_DllNameCannotBeEmpty");
			}
			native_cc = System.Runtime.InteropServices.CallingConvention.Winapi;
			for (int i = 0; i < customAttributeInfo.namedParamNames.Length; i++)
			{
				string text = customAttributeInfo.namedParamNames[i];
				object obj = customAttributeInfo.namedParamValues[i];
				switch (text)
				{
				case "CallingConvention":
					native_cc = (CallingConvention)obj;
					break;
				case "CharSet":
					charset = (CharSet)obj;
					break;
				case "EntryPoint":
					pi_entry = (string)obj;
					break;
				case "ExactSpelling":
					ExactSpelling = (bool)obj;
					break;
				case "SetLastError":
					SetLastError = (bool)obj;
					break;
				case "PreserveSig":
					flag = (bool)obj;
					break;
				case "BestFitMapping":
					BestFitMapping = (bool)obj;
					break;
				case "ThrowOnUnmappableChar":
					ThrowOnUnmappableChar = (bool)obj;
					break;
				}
			}
			attrs |= MethodAttributes.PinvokeImpl;
			if (flag)
			{
				iattrs |= MethodImplAttributes.PreserveSig;
			}
			return;
		}
		case "System.Runtime.InteropServices.PreserveSigAttribute":
			iattrs |= MethodImplAttributes.PreserveSig;
			return;
		case "System.Runtime.CompilerServices.SpecialNameAttribute":
			attrs |= MethodAttributes.SpecialName;
			return;
		case "System.Security.SuppressUnmanagedCodeSecurityAttribute":
			attrs |= MethodAttributes.HasSecurity;
			break;
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
		RejectIfCreated();
		iattrs = attributes;
	}

	public override string ToString()
	{
		return "MethodBuilder [" + type.Name + "::" + name + "]";
	}

	public override bool Equals(object obj)
	{
		return base.Equals(obj);
	}

	public override int GetHashCode()
	{
		return name.GetHashCode();
	}

	internal override int get_next_table_index(int table, int count)
	{
		return type.get_next_table_index(table, count);
	}

	private static void ExtendArray<T>([NotNull] ref T[] array, T elem)
	{
		if (array == null)
		{
			array = new T[1];
		}
		else
		{
			T[] array2 = new T[array.Length + 1];
			Array.Copy(array, array2, array.Length);
			array = array2;
		}
		array[array.Length - 1] = elem;
	}

	internal void set_override(MethodInfo mdecl)
	{
		ExtendArray(ref override_methods, mdecl);
	}

	private void RejectIfCreated()
	{
		if (type.is_created)
		{
			throw new InvalidOperationException("InvalidOperation_MethodBaked");
		}
	}

	private static NotSupportedException NotSupported()
	{
		return new NotSupportedException("NotSupported_DynamicModule");
	}

	[RequiresDynamicCode("The native code for this instantiation might not be available at runtime.")]
	[RequiresUnreferencedCode("If some of the generic arguments are annotated (either with DynamicallyAccessedMembersAttribute, or generic constraints), trimming can't validate that the requirements of those annotations are met.")]
	public override MethodInfo MakeGenericMethod(params Type[] typeArguments)
	{
		if (!IsGenericMethodDefinition)
		{
			throw new InvalidOperationException("Argument_NeedGenericMethodDefinition");
		}
		ArgumentNullException.ThrowIfNull(typeArguments, "typeArguments");
		for (int i = 0; i < typeArguments.Length; i++)
		{
			ArgumentNullException.ThrowIfNull(typeArguments[i], "typeArguments");
		}
		return new MethodOnTypeBuilderInstantiation(this, typeArguments);
	}

	public override MethodInfo GetGenericMethodDefinition()
	{
		if (!IsGenericMethodDefinition)
		{
			throw new InvalidOperationException();
		}
		return this;
	}

	public override Type[] GetGenericArguments()
	{
		if (generic_params == null)
		{
			return Type.EmptyTypes;
		}
		Type[] array = new Type[generic_params.Length];
		for (int i = 0; i < generic_params.Length; i++)
		{
			array[i] = generic_params[i];
		}
		return array;
	}

	protected override GenericTypeParameterBuilder[] DefineGenericParametersCore(params string[] names)
	{
		type.check_not_created();
		generic_params = new RuntimeGenericTypeParameterBuilder[names.Length];
		for (int i = 0; i < names.Length; i++)
		{
			string argument = names[i];
			ArgumentNullException.ThrowIfNull(argument, "names");
			generic_params[i] = new RuntimeGenericTypeParameterBuilder(type, this, argument, i);
		}
		return generic_params;
	}

	protected override void SetSignatureCore(Type returnType, Type[] returnTypeRequiredCustomModifiers, Type[] returnTypeOptionalCustomModifiers, Type[] parameterTypes, Type[][] parameterTypeRequiredCustomModifiers, Type[][] parameterTypeOptionalCustomModifiers)
	{
		if (parameterTypes != null)
		{
			for (int i = 0; i < parameterTypes.Length; i++)
			{
				ArgumentNullException.ThrowIfNull(parameterTypes[i], "parameterTypes");
			}
			parameters = new Type[parameterTypes.Length];
			Array.Copy(parameterTypes, parameters, parameterTypes.Length);
		}
		if (returnType != null)
		{
			rtype = returnType;
		}
		returnModReq = returnTypeRequiredCustomModifiers;
		returnModOpt = returnTypeOptionalCustomModifiers;
		paramModReq = parameterTypeRequiredCustomModifiers;
		paramModOpt = parameterTypeOptionalCustomModifiers;
	}
}
