using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Loader;
using System.Text;

namespace System.Reflection.Emit;

[StructLayout(LayoutKind.Sequential)]
public sealed class DynamicMethod : MethodInfo
{
	private sealed class DynamicMethodTokenGenerator : ITokenGenerator
	{
		private readonly DynamicMethod _m;

		public DynamicMethodTokenGenerator(DynamicMethod m)
		{
			_m = m;
		}

		public int GetToken(string str)
		{
			return _m.AddRef(str);
		}

		public int GetToken(MethodBase method, Type[] opt_paratypes)
		{
			throw new InvalidOperationException();
		}

		public int GetToken(MemberInfo member, bool create_open_instance)
		{
			return _m.AddRef(member);
		}

		public int GetToken(SignatureHelper helper)
		{
			return _m.AddRef(helper);
		}
	}

	private RuntimeMethodHandle _mhandle;

	private RuntimeType _returnType;

	private RuntimeType[] _parameterTypes;

	private Module _module;

	private bool _skipVisibility;

	private bool _restrictedSkipVisibility;

	private bool _initLocals;

	private RuntimeILGenerator _ilGenerator;

	private int _nrefs;

	private object[] _refs;

	private nint _referencedBy;

	private RuntimeType _typeOwner;

	private string _name;

	private MethodAttributes _attributes;

	private CallingConventions _callingConvention;

	private RuntimeParameterInfo[] _parameters;

	private Delegate _deleg;

	private RuntimeMethodInfo _method;

	private bool _creating;

	private DynamicILInfo _dynamicILInfo;

	private object _methodHandle;

	private static volatile Module s_anonymouslyHostedDynamicMethodsModule;

	private static readonly object s_anonymouslyHostedDynamicMethodsModuleLock = new object();

	public override string Name => _name;

	public override Type? DeclaringType => null;

	public override Type? ReflectedType => null;

	public override Module Module => _module;

	public override RuntimeMethodHandle MethodHandle
	{
		get
		{
			throw new InvalidOperationException("InvalidOperation_NotAllowedInDynamicMethod");
		}
	}

	public override MethodAttributes Attributes => _attributes;

	public override CallingConventions CallingConvention => _callingConvention;

	public override bool IsSecurityCritical => true;

	public override bool IsSecuritySafeCritical => false;

	public override bool IsSecurityTransparent => false;

	public override Type ReturnType => _returnType;

	public override ParameterInfo ReturnParameter => new RuntimeParameterInfo(this, null, _returnType, -1);

	public override ICustomAttributeProvider ReturnTypeCustomAttributes => new EmptyCAHolder();

	public bool InitLocals
	{
		get
		{
			return _initLocals;
		}
		set
		{
			_initLocals = value;
		}
	}

	internal RuntimeType[] ArgumentTypes => _parameterTypes;

	public sealed override Delegate CreateDelegate(Type delegateType)
	{
		ArgumentNullException.ThrowIfNull(delegateType, "delegateType");
		if ((object)_deleg != null)
		{
			return _deleg;
		}
		CreateDynMethod();
		return _deleg = Delegate.CreateDelegate(delegateType, null, this);
	}

	public sealed override Delegate CreateDelegate(Type delegateType, object? target)
	{
		ArgumentNullException.ThrowIfNull(delegateType, "delegateType");
		CreateDynMethod();
		return Delegate.CreateDelegate(delegateType, target, this);
	}

	public DynamicILInfo GetDynamicILInfo()
	{
		return _dynamicILInfo ?? (_dynamicILInfo = new DynamicILInfo(this));
	}

	public ILGenerator GetILGenerator(int streamSize)
	{
		return GetILGeneratorInternal(streamSize);
	}

	internal RuntimeILGenerator GetRuntimeILGenerator()
	{
		return GetILGeneratorInternal(64);
	}

	private RuntimeILGenerator GetILGeneratorInternal(int streamSize)
	{
		return _ilGenerator ?? (_ilGenerator = new RuntimeILGenerator(Module, new DynamicMethodTokenGenerator(this), streamSize));
	}

	public override object? Invoke(object? obj, BindingFlags invokeAttr, Binder? binder, object?[]? parameters, CultureInfo? culture)
	{
		if ((CallingConvention & CallingConventions.VarArgs) == CallingConventions.VarArgs)
		{
			throw new NotSupportedException("NotSupported_CallToVarArg");
		}
		try
		{
			CreateDynMethod();
			return GetRuntimeMethodInfo().Invoke(obj, invokeAttr, binder, parameters, culture);
		}
		catch (MethodAccessException inner)
		{
			throw new TargetInvocationException("TargetInvocation_MethodCannotBeInvoked", inner);
		}
	}

	internal RuntimeMethodInfo GetRuntimeMethodInfo()
	{
		if ((object)_method == null)
		{
			_method = new RuntimeMethodInfo(_mhandle);
		}
		return _method;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void create_dynamic_method(DynamicMethod m, string name, MethodAttributes attributes, CallingConventions callingConvention);

	private void CreateDynMethod()
	{
		lock (this)
		{
			if (_mhandle.Value != IntPtr.Zero)
			{
				return;
			}
			if (_ilGenerator == null || _ilGenerator.ILOffset == 0)
			{
				throw new InvalidOperationException(SR.Format("InvalidOperation_BadEmptyMethodBody", Name));
			}
			_ilGenerator.label_fixup(this);
			try
			{
				_creating = true;
				if (_refs != null)
				{
					for (int i = 0; i < _refs.Length; i++)
					{
						if (_refs[i] is DynamicMethod { _creating: false } dynamicMethod)
						{
							dynamicMethod.CreateDynMethod();
						}
					}
				}
			}
			finally
			{
				_creating = false;
			}
			create_dynamic_method(this, Name, Attributes, CallingConvention);
			_ilGenerator = null;
		}
	}

	private int AddRef(object reference)
	{
		if (_refs == null)
		{
			_refs = new object[4];
		}
		if (_nrefs >= _refs.Length - 1)
		{
			object[] array = new object[_refs.Length * 2];
			Array.Copy(_refs, array, _refs.Length);
			_refs = array;
		}
		_refs[_nrefs] = reference;
		_refs[_nrefs + 1] = null;
		_nrefs += 2;
		return _nrefs - 1;
	}

	internal override int GetParametersCount()
	{
		return GetParametersAsSpan().Length;
	}

	[RequiresDynamicCode("Creating a DynamicMethod requires dynamic code.")]
	public DynamicMethod(string name, Type? returnType, Type[]? parameterTypes)
	{
		Init(name, MethodAttributes.Public | MethodAttributes.Static, CallingConventions.Standard, returnType, parameterTypes, null, null, skipVisibility: false, transparentMethod: true);
	}

	[RequiresDynamicCode("Creating a DynamicMethod requires dynamic code.")]
	public DynamicMethod(string name, Type? returnType, Type[]? parameterTypes, bool restrictedSkipVisibility)
	{
		Init(name, MethodAttributes.Public | MethodAttributes.Static, CallingConventions.Standard, returnType, parameterTypes, null, null, restrictedSkipVisibility, transparentMethod: true);
	}

	[RequiresDynamicCode("Creating a DynamicMethod requires dynamic code.")]
	public DynamicMethod(string name, Type? returnType, Type[]? parameterTypes, Module m)
	{
		ArgumentNullException.ThrowIfNull(m, "m");
		Init(name, MethodAttributes.Public | MethodAttributes.Static, CallingConventions.Standard, returnType, parameterTypes, null, m, skipVisibility: false, transparentMethod: false);
	}

	[RequiresDynamicCode("Creating a DynamicMethod requires dynamic code.")]
	public DynamicMethod(string name, Type? returnType, Type[]? parameterTypes, Module m, bool skipVisibility)
	{
		ArgumentNullException.ThrowIfNull(m, "m");
		Init(name, MethodAttributes.Public | MethodAttributes.Static, CallingConventions.Standard, returnType, parameterTypes, null, m, skipVisibility, transparentMethod: false);
	}

	[RequiresDynamicCode("Creating a DynamicMethod requires dynamic code.")]
	public DynamicMethod(string name, MethodAttributes attributes, CallingConventions callingConvention, Type? returnType, Type[]? parameterTypes, Module m, bool skipVisibility)
	{
		ArgumentNullException.ThrowIfNull(m, "m");
		Init(name, attributes, callingConvention, returnType, parameterTypes, null, m, skipVisibility, transparentMethod: false);
	}

	[RequiresDynamicCode("Creating a DynamicMethod requires dynamic code.")]
	public DynamicMethod(string name, Type? returnType, Type[]? parameterTypes, Type owner)
	{
		ArgumentNullException.ThrowIfNull(owner, "owner");
		Init(name, MethodAttributes.Public | MethodAttributes.Static, CallingConventions.Standard, returnType, parameterTypes, owner, null, skipVisibility: false, transparentMethod: false);
	}

	[RequiresDynamicCode("Creating a DynamicMethod requires dynamic code.")]
	public DynamicMethod(string name, Type? returnType, Type[]? parameterTypes, Type owner, bool skipVisibility)
	{
		ArgumentNullException.ThrowIfNull(owner, "owner");
		Init(name, MethodAttributes.Public | MethodAttributes.Static, CallingConventions.Standard, returnType, parameterTypes, owner, null, skipVisibility, transparentMethod: false);
	}

	[RequiresDynamicCode("Creating a DynamicMethod requires dynamic code.")]
	public DynamicMethod(string name, MethodAttributes attributes, CallingConventions callingConvention, Type? returnType, Type[]? parameterTypes, Type owner, bool skipVisibility)
	{
		ArgumentNullException.ThrowIfNull(owner, "owner");
		Init(name, attributes, callingConvention, returnType, parameterTypes, owner, null, skipVisibility, transparentMethod: false);
	}

	private static Module GetDynamicMethodsModule()
	{
		if (s_anonymouslyHostedDynamicMethodsModule != null)
		{
			return s_anonymouslyHostedDynamicMethodsModule;
		}
		AssemblyBuilder.EnsureDynamicCodeSupported();
		lock (s_anonymouslyHostedDynamicMethodsModuleLock)
		{
			if (s_anonymouslyHostedDynamicMethodsModule != null)
			{
				return s_anonymouslyHostedDynamicMethodsModule;
			}
			s_anonymouslyHostedDynamicMethodsModule = RuntimeAssemblyBuilder.InternalDefineDynamicAssembly(new AssemblyName("Anonymously Hosted DynamicMethods Assembly"), AssemblyBuilderAccess.Run, AssemblyLoadContext.Default, null).ManifestModule;
		}
		return s_anonymouslyHostedDynamicMethodsModule;
	}

	[MemberNotNull("_parameterTypes")]
	[MemberNotNull("_returnType")]
	[MemberNotNull("_module")]
	[MemberNotNull("_name")]
	private void Init(string name, MethodAttributes attributes, CallingConventions callingConvention, Type returnType, Type[] signature, Type owner, Module m, bool skipVisibility, bool transparentMethod)
	{
		ArgumentNullException.ThrowIfNull(name, "name");
		AssemblyBuilder.EnsureDynamicCodeSupported();
		if (attributes != (MethodAttributes.Public | MethodAttributes.Static) || callingConvention != CallingConventions.Standard)
		{
			throw new NotSupportedException("NotSupported_DynamicMethodFlags");
		}
		if (signature != null)
		{
			_parameterTypes = new RuntimeType[signature.Length];
			for (int i = 0; i < signature.Length; i++)
			{
				if (signature[i] == null)
				{
					throw new ArgumentException("Arg_InvalidTypeInSignature");
				}
				_parameterTypes[i] = signature[i].UnderlyingSystemType as RuntimeType;
				if (_parameterTypes[i] == null || _parameterTypes[i] == typeof(void))
				{
					throw new ArgumentException("Arg_InvalidTypeInSignature");
				}
			}
		}
		else
		{
			_parameterTypes = Array.Empty<RuntimeType>();
		}
		_returnType = (((object)returnType == null) ? ((RuntimeType)typeof(void)) : ((returnType.UnderlyingSystemType as RuntimeType) ?? throw new NotSupportedException("Arg_InvalidTypeInRetType")));
		if (transparentMethod)
		{
			_module = GetDynamicMethodsModule();
			_restrictedSkipVisibility = skipVisibility;
		}
		else
		{
			if (m != null)
			{
				_module = RuntimeModuleBuilder.GetRuntimeModuleFromModule(m);
			}
			else if (owner?.UnderlyingSystemType is RuntimeType runtimeType)
			{
				if (runtimeType.HasElementType || runtimeType.ContainsGenericParameters || runtimeType.IsGenericParameter || runtimeType.IsActualInterface)
				{
					throw new ArgumentException("Argument_InvalidTypeForDynamicMethod");
				}
				_typeOwner = runtimeType;
				_module = runtimeType.GetRuntimeModule();
			}
			else
			{
				_module = null;
			}
			_skipVisibility = skipVisibility;
		}
		_ilGenerator = null;
		_initLocals = true;
		_methodHandle = null;
		_name = name;
		_attributes = attributes;
		_callingConvention = callingConvention;
	}

	public override string ToString()
	{
		ValueStringBuilder sbParamList = new ValueStringBuilder(100);
		sbParamList.Append(ReturnType.FormatTypeName());
		sbParamList.Append(' ');
		sbParamList.Append(Name);
		sbParamList.Append('(');
		MethodBase.AppendParameters(ref sbParamList, GetParameterTypes(), CallingConvention);
		sbParamList.Append(')');
		return sbParamList.ToString();
	}

	public override MethodInfo GetBaseDefinition()
	{
		return this;
	}

	public override ParameterInfo[] GetParameters()
	{
		return GetParametersAsSpan().ToArray();
	}

	internal override ReadOnlySpan<ParameterInfo> GetParametersAsSpan()
	{
		ParameterInfo[] array = LoadParameters();
		return array;
	}

	public override MethodImplAttributes GetMethodImplementationFlags()
	{
		return MethodImplAttributes.NoInlining;
	}

	public override object[] GetCustomAttributes(Type attributeType, bool inherit)
	{
		ArgumentNullException.ThrowIfNull(attributeType, "attributeType");
		RuntimeType caType = (attributeType.UnderlyingSystemType as RuntimeType) ?? throw new ArgumentException("Arg_MustBeType", "attributeType");
		bool flag = attributeType.IsAssignableFrom(typeof(MethodImplAttribute));
		object[] array = CustomAttribute.CreateAttributeArrayHelper(caType, flag ? 1 : 0);
		if (flag)
		{
			array[0] = new MethodImplAttribute((MethodImplOptions)GetMethodImplementationFlags());
		}
		return array;
	}

	public override object[] GetCustomAttributes(bool inherit)
	{
		return new object[1]
		{
			new MethodImplAttribute((MethodImplOptions)GetMethodImplementationFlags())
		};
	}

	public override bool IsDefined(Type attributeType, bool inherit)
	{
		ArgumentNullException.ThrowIfNull(attributeType, "attributeType");
		return attributeType.IsAssignableFrom(typeof(MethodImplAttribute));
	}

	public ParameterBuilder? DefineParameter(int position, ParameterAttributes attributes, string? parameterName)
	{
		if (position < 0 || position > _parameterTypes.Length)
		{
			throw new ArgumentOutOfRangeException("ArgumentOutOfRange_ParamSequence");
		}
		position--;
		if (position >= 0)
		{
			RuntimeParameterInfo[] array = LoadParameters();
			array[position].SetName(parameterName);
			array[position].SetAttributes(attributes);
		}
		return null;
	}

	public ILGenerator GetILGenerator()
	{
		return GetILGenerator(64);
	}

	private RuntimeParameterInfo[] LoadParameters()
	{
		if (_parameters == null)
		{
			Type[] parameterTypes = _parameterTypes;
			Type[] array = parameterTypes;
			RuntimeParameterInfo[] array2 = new RuntimeParameterInfo[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array2[i] = new RuntimeParameterInfo(this, null, array[i], i);
			}
			if (_parameters == null)
			{
				_parameters = array2;
			}
		}
		return _parameters;
	}
}
