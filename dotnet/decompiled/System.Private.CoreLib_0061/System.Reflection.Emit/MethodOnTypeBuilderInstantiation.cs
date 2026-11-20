using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace System.Reflection.Emit;

internal sealed class MethodOnTypeBuilderInstantiation : MethodInfo
{
	private Type[] _typeArguments;

	private MethodInfo _genericMethodDefinition;

	internal MethodInfo _method;

	private Type _type;

	public override bool IsGenericMethodDefinition
	{
		get
		{
			if (_method.IsGenericMethodDefinition)
			{
				return _typeArguments == null;
			}
			return false;
		}
	}

	public override MemberTypes MemberType => _method.MemberType;

	public override string Name => _method.Name;

	public override Type DeclaringType => _type;

	public override Type ReflectedType => _type;

	public override Module Module => _method.Module;

	public override RuntimeMethodHandle MethodHandle => _method.MethodHandle;

	public override MethodAttributes Attributes => _method.Attributes;

	public override CallingConventions CallingConvention => _method.CallingConvention;

	public override bool ContainsGenericParameters
	{
		get
		{
			if (_method.ContainsGenericParameters || _type.ContainsGenericParameters)
			{
				return true;
			}
			if (!IsGenericMethod)
			{
				return false;
			}
			Type[] genericArguments = GetGenericArguments();
			for (int i = 0; i < genericArguments.Length; i++)
			{
				if (genericArguments[i].ContainsGenericParameters)
				{
					return true;
				}
			}
			return false;
		}
	}

	public override bool IsGenericMethod => _method.IsGenericMethod;

	public override Type ReturnType => _method.ReturnType;

	public override ParameterInfo ReturnParameter => _method.ReturnParameter;

	public override ICustomAttributeProvider ReturnTypeCustomAttributes
	{
		get
		{
			throw new NotSupportedException();
		}
	}

	internal MethodOnTypeBuilderInstantiation(MethodOnTypeBuilderInstantiation gmd, Type[] typeArguments)
		: this(gmd._method, gmd._type)
	{
		_typeArguments = new Type[typeArguments.Length];
		typeArguments.CopyTo(_typeArguments, 0);
		_genericMethodDefinition = gmd;
	}

	internal MethodOnTypeBuilderInstantiation(MethodInfo method, Type[] typeArguments)
		: this(ExtractBaseMethod(method), method.DeclaringType)
	{
		_typeArguments = new Type[typeArguments.Length];
		typeArguments.CopyTo(_typeArguments, 0);
		if (_method != method)
		{
			_genericMethodDefinition = method;
		}
	}

	public override Type[] GetGenericArguments()
	{
		if (!_method.IsGenericMethodDefinition)
		{
			return Type.EmptyTypes;
		}
		Type[] obj = _typeArguments ?? _method.GetGenericArguments();
		Type[] array = new Type[obj.Length];
		obj.CopyTo(array, 0);
		return array;
	}

	public override MethodInfo GetGenericMethodDefinition()
	{
		return _genericMethodDefinition ?? _method;
	}

	[RequiresUnreferencedCode("If some of the generic arguments are annotated (either with DynamicallyAccessedMembersAttribute, or generic constraints), trimming can't validate that the requirements of those annotations are met.")]
	public override MethodInfo MakeGenericMethod(params Type[] typeArgs)
	{
		if (!_method.IsGenericMethodDefinition || _typeArguments != null)
		{
			throw new InvalidOperationException("Argument_NeedGenericMethodDefinition");
		}
		ArgumentNullException.ThrowIfNull(typeArgs, "typeArgs");
		if (_method.GetGenericArguments().Length != typeArgs.Length)
		{
			throw new ArgumentException(SR.Format("Argument_NotEnoughGenArguments", _method.GetGenericArguments().Length, typeArgs.Length));
		}
		for (int i = 0; i < typeArgs.Length; i++)
		{
			ArgumentNullException.ThrowIfNull(typeArgs[i], "typeArgs");
		}
		return new MethodOnTypeBuilderInstantiation(this, typeArgs);
	}

	[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2060:MakeGenericMethod", Justification = "MethodOnTypeBuilderInst is Reflection.Emit's underlying implementation of MakeGenericMethod. Callers of the outer calls to MakeGenericMethod will be warned as appropriate.")]
	internal MethodInfo RuntimeResolve()
	{
		MethodInfo methodInfo = _type.InternalResolve().GetMethod(_method);
		if (_typeArguments != null)
		{
			Type[] array = new Type[_typeArguments.Length];
			for (int i = 0; i < _typeArguments.Length; i++)
			{
				array[i] = _typeArguments[i].InternalResolve();
			}
			methodInfo = methodInfo.MakeGenericMethod(array);
		}
		return methodInfo;
	}

	internal override int GetParametersCount()
	{
		return _method.GetParametersCount();
	}

	internal static MethodInfo GetMethod(MethodInfo method, TypeBuilderInstantiation type)
	{
		return new MethodOnTypeBuilderInstantiation(method, type);
	}

	internal MethodOnTypeBuilderInstantiation(MethodInfo method, Type type)
	{
		_method = method;
		_type = type;
	}

	[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "Reflection.Emit is not subject to trimming")]
	private static MethodInfo ExtractBaseMethod(MethodInfo info)
	{
		if (info is MethodBuilder)
		{
			return info;
		}
		if (info is MethodOnTypeBuilderInstantiation methodOnTypeBuilderInstantiation)
		{
			return methodOnTypeBuilderInstantiation._method;
		}
		if (info.IsGenericMethod)
		{
			info = info.GetGenericMethodDefinition();
		}
		Type declaringType = info.DeclaringType;
		if (!declaringType.IsGenericType || declaringType.IsGenericTypeDefinition)
		{
			return info;
		}
		return (MethodInfo)declaringType.Module.ResolveMethod(info.MetadataToken);
	}

	public override object[] GetCustomAttributes(bool inherit)
	{
		return _method.GetCustomAttributes(inherit);
	}

	public override object[] GetCustomAttributes(Type attributeType, bool inherit)
	{
		return _method.GetCustomAttributes(attributeType, inherit);
	}

	public override bool IsDefined(Type attributeType, bool inherit)
	{
		return _method.IsDefined(attributeType, inherit);
	}

	public override ParameterInfo[] GetParameters()
	{
		return _method.GetParameters();
	}

	public override MethodImplAttributes GetMethodImplementationFlags()
	{
		return _method.GetMethodImplementationFlags();
	}

	public override object Invoke(object obj, BindingFlags invokeAttr, Binder binder, object[] parameters, CultureInfo culture)
	{
		throw new NotSupportedException();
	}

	public override MethodInfo GetBaseDefinition()
	{
		throw new NotSupportedException();
	}

	internal override Type[] GetParameterTypes()
	{
		return _method.GetParameterTypes();
	}
}
