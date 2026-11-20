using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System;

[StructLayout(LayoutKind.Sequential)]
public abstract class Delegate : ICloneable, ISerializable
{
	public struct InvocationListEnumerator<TDelegate> where TDelegate : Delegate
	{
		private readonly MulticastDelegate _delegate;

		private int _index;

		private TDelegate _current;

		public TDelegate Current => _current;

		internal InvocationListEnumerator(MulticastDelegate d)
		{
			_current = null;
			_delegate = d;
			_index = -1;
		}

		public bool MoveNext()
		{
			int index = _index + 1;
			if ((_current = Unsafe.As<TDelegate>(_delegate?.TryGetAt(index))) == null)
			{
				return false;
			}
			_index = index;
			return true;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public InvocationListEnumerator<TDelegate> GetEnumerator()
		{
			return this;
		}
	}

	private nint method_ptr;

	private nint invoke_impl;

	private object _target;

	private nint method;

	private nint delegate_trampoline;

	private nint extra_arg;

	private nint method_code;

	private nint interp_method;

	private nint interp_invoke_impl;

	private MethodInfo method_info;

	private MethodInfo original_method_info;

	private DelegateData data;

	private bool method_is_virtual;

	private bool bound;

	public object? Target => GetTarget();

	public bool HasSingleTarget => Unsafe.As<MulticastDelegate>(this).HasSingleTarget;

	public MethodInfo Method => GetMethodImpl();

	[RequiresUnreferencedCode("The target method might be removed")]
	protected Delegate(object target, string method)
	{
		ArgumentNullException.ThrowIfNull(target, "target");
		ArgumentNullException.ThrowIfNull(method, "method");
		_target = target;
		data = new DelegateData
		{
			method_name = method
		};
	}

	protected Delegate([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.AllMethods)] Type target, string method)
	{
		ArgumentNullException.ThrowIfNull(target, "target");
		if (target.ContainsGenericParameters)
		{
			throw new ArgumentException("Arg_UnboundGenParam", "target");
		}
		ArgumentNullException.ThrowIfNull(method, "method");
		if (!(target is RuntimeType))
		{
			throw new ArgumentException("Argument_MustBeRuntimeType", "target");
		}
		data = new DelegateData
		{
			method_name = method,
			target_type = target
		};
	}

	internal virtual object GetTarget()
	{
		return _target;
	}

	public static Delegate CreateDelegate(Type type, object? firstArgument, MethodInfo method, bool throwOnBindFailure)
	{
		return CreateDelegate(type, firstArgument, method, throwOnBindFailure, allowClosed: true);
	}

	public static Delegate? CreateDelegate(Type type, MethodInfo method, bool throwOnBindFailure)
	{
		return CreateDelegate(type, null, method, throwOnBindFailure, allowClosed: false);
	}

	private static Delegate CreateDelegate(Type type, object firstArgument, MethodInfo method, bool throwOnBindFailure, bool allowClosed)
	{
		ArgumentNullException.ThrowIfNull(type, "type");
		ArgumentNullException.ThrowIfNull(method, "method");
		RuntimeType type2 = type as RuntimeType;
		if ((object)type2 == null)
		{
			throw new ArgumentException("Argument_MustBeRuntimeType", "type");
		}
		if (!(method is RuntimeMethodInfo) && !(method is DynamicMethod))
		{
			throw new ArgumentException("Argument_MustBeRuntimeMethodInfo", "method");
		}
		if (!type2.IsDelegate())
		{
			throw new ArgumentException("Arg_MustBeDelegate", "type");
		}
		if (!IsMatchingCandidate(type2, firstArgument, method, allowClosed, out var delegateData))
		{
			if (throwOnBindFailure)
			{
				throw new ArgumentException("Arg_DlgtTargMeth");
			}
			return null;
		}
		Delegate obj = CreateDelegate_internal(new QCallTypeHandle(ref type2), firstArgument, method, throwOnBindFailure);
		if ((object)obj != null)
		{
			obj.original_method_info = method;
			obj.data = delegateData;
		}
		return obj;
	}

	[RequiresUnreferencedCode("The target method might be removed")]
	public static Delegate? CreateDelegate(Type type, object target, string method, bool ignoreCase, bool throwOnBindFailure)
	{
		ArgumentNullException.ThrowIfNull(type, "type");
		ArgumentNullException.ThrowIfNull(target, "target");
		ArgumentNullException.ThrowIfNull(method, "method");
		RuntimeType type2 = type as RuntimeType;
		if ((object)type2 == null)
		{
			throw new ArgumentException("Argument_MustBeRuntimeType", "type");
		}
		if (!type2.IsDelegate())
		{
			throw new ArgumentException("Arg_MustBeDelegate", "type");
		}
		MethodInfo candidateMethod = GetCandidateMethod(type2, target.GetType(), method, BindingFlags.Instance, ignoreCase);
		if ((object)candidateMethod == null)
		{
			if (throwOnBindFailure)
			{
				throw new ArgumentException("Arg_DlgtTargMeth");
			}
			return null;
		}
		return CreateDelegate_internal(new QCallTypeHandle(ref type2), target, candidateMethod, throwOnBindFailure);
	}

	public static Delegate? CreateDelegate(Type type, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.AllMethods)] Type target, string method, bool ignoreCase, bool throwOnBindFailure)
	{
		ArgumentNullException.ThrowIfNull(type, "type");
		ArgumentNullException.ThrowIfNull(target, "target");
		if (target.ContainsGenericParameters)
		{
			throw new ArgumentException("Arg_UnboundGenParam", "target");
		}
		ArgumentNullException.ThrowIfNull(method, "method");
		RuntimeType type2 = type as RuntimeType;
		if ((object)type2 == null)
		{
			throw new ArgumentException("Argument_MustBeRuntimeType", "type");
		}
		if (!(target is RuntimeType))
		{
			throw new ArgumentException("Argument_MustBeRuntimeType", "target");
		}
		if (!type2.IsDelegate())
		{
			throw new ArgumentException("Arg_MustBeDelegate", "type");
		}
		MethodInfo candidateMethod = GetCandidateMethod(type2, target, method, BindingFlags.Static, ignoreCase);
		if ((object)candidateMethod == null)
		{
			if (throwOnBindFailure)
			{
				throw new ArgumentException("Arg_DlgtTargMeth");
			}
			return null;
		}
		return CreateDelegate_internal(new QCallTypeHandle(ref type2), null, candidateMethod, throwOnBindFailure);
	}

	private static MethodInfo GetCandidateMethod(RuntimeType type, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.AllMethods)] Type target, string method, BindingFlags bflags, bool ignoreCase)
	{
		MethodInfo delegateInvokeMethod = GetDelegateInvokeMethod(type);
		if ((object)delegateInvokeMethod == null)
		{
			return null;
		}
		ReadOnlySpan<ParameterInfo> parametersAsSpan = delegateInvokeMethod.GetParametersAsSpan();
		Type[] array = new Type[parametersAsSpan.Length];
		for (int i = 0; i < parametersAsSpan.Length; i++)
		{
			array[i] = parametersAsSpan[i].ParameterType;
		}
		BindingFlags bindingFlags = BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.ExactBinding | bflags;
		if (ignoreCase)
		{
			bindingFlags |= BindingFlags.IgnoreCase;
		}
		Type type2 = target;
		while (type2 != null)
		{
			MethodInfo methodInfo = type2.GetMethod(method, bindingFlags, null, array, Array.Empty<ParameterModifier>());
			if (methodInfo != null && IsReturnTypeMatch(delegateInvokeMethod.ReturnType, methodInfo.ReturnType))
			{
				return methodInfo;
			}
			type2 = type2.BaseType;
		}
		return null;
	}

	private static bool IsMatchingCandidate(RuntimeType type, object target, MethodInfo method, bool allowClosed, out DelegateData delegateData)
	{
		MethodInfo delegateInvokeMethod = GetDelegateInvokeMethod(type);
		if (delegateInvokeMethod == null || !IsReturnTypeMatch(delegateInvokeMethod.ReturnType, method.ReturnType))
		{
			delegateData = null;
			return false;
		}
		ReadOnlySpan<ParameterInfo> parametersAsSpan = delegateInvokeMethod.GetParametersAsSpan();
		ReadOnlySpan<ParameterInfo> parametersAsSpan2 = method.GetParametersAsSpan();
		bool flag;
		if (target != null)
		{
			flag = (method.IsStatic ? (parametersAsSpan2.Length == parametersAsSpan.Length + 1) : (parametersAsSpan2.Length == parametersAsSpan.Length));
		}
		else if (!method.IsStatic)
		{
			flag = parametersAsSpan2.Length + 1 == parametersAsSpan.Length;
			if (!flag)
			{
				flag = parametersAsSpan2.Length == parametersAsSpan.Length;
			}
		}
		else
		{
			flag = parametersAsSpan2.Length == parametersAsSpan.Length;
			if (!flag)
			{
				flag = parametersAsSpan2.Length == parametersAsSpan.Length + 1;
			}
		}
		if (!flag)
		{
			delegateData = null;
			return false;
		}
		delegateData = new DelegateData();
		bool flag2;
		if (target != null)
		{
			if (!method.IsStatic)
			{
				flag2 = IsArgumentTypeMatchWithThis(target.GetType(), method.DeclaringType, boxedThis: true);
				for (int i = 0; i < parametersAsSpan2.Length; i++)
				{
					flag2 &= IsArgumentTypeMatch(parametersAsSpan[i].ParameterType, parametersAsSpan2[i].ParameterType);
				}
			}
			else
			{
				flag2 = IsArgumentTypeMatch(target.GetType(), parametersAsSpan2[0].ParameterType);
				for (int j = 1; j < parametersAsSpan2.Length; j++)
				{
					flag2 &= IsArgumentTypeMatch(parametersAsSpan[j - 1].ParameterType, parametersAsSpan2[j].ParameterType);
				}
				delegateData.curried_first_arg = true;
			}
		}
		else if (!method.IsStatic)
		{
			if (parametersAsSpan2.Length + 1 == parametersAsSpan.Length)
			{
				flag2 = IsArgumentTypeMatchWithThis(parametersAsSpan[0].ParameterType, method.DeclaringType, boxedThis: false);
				for (int k = 0; k < parametersAsSpan2.Length; k++)
				{
					flag2 &= IsArgumentTypeMatch(parametersAsSpan[k + 1].ParameterType, parametersAsSpan2[k].ParameterType);
				}
			}
			else
			{
				flag2 = allowClosed;
				for (int l = 0; l < parametersAsSpan2.Length; l++)
				{
					flag2 &= IsArgumentTypeMatch(parametersAsSpan[l].ParameterType, parametersAsSpan2[l].ParameterType);
				}
			}
		}
		else if (parametersAsSpan.Length + 1 == parametersAsSpan2.Length)
		{
			flag2 = !parametersAsSpan2[0].ParameterType.IsValueType && !parametersAsSpan2[0].ParameterType.IsByRef && allowClosed;
			for (int m = 0; m < parametersAsSpan.Length; m++)
			{
				flag2 &= IsArgumentTypeMatch(parametersAsSpan[m].ParameterType, parametersAsSpan2[m + 1].ParameterType);
			}
			delegateData.curried_first_arg = true;
		}
		else
		{
			flag2 = true;
			for (int n = 0; n < parametersAsSpan2.Length; n++)
			{
				flag2 &= IsArgumentTypeMatch(parametersAsSpan[n].ParameterType, parametersAsSpan2[n].ParameterType);
			}
		}
		return flag2;
	}

	[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2070:UnrecognizedReflectionPattern", Justification = "ILLinker will never remove the Invoke method from delegates.")]
	private static MethodInfo GetDelegateInvokeMethod(RuntimeType type)
	{
		return type.GetMethod("Invoke");
	}

	private static bool IsReturnTypeMatch(Type delReturnType, Type returnType)
	{
		bool flag = returnType == delReturnType;
		if (!flag)
		{
			if (!returnType.IsValueType && delReturnType.IsAssignableFrom(returnType))
			{
				flag = true;
			}
			else
			{
				bool isEnum = delReturnType.IsEnum;
				bool isEnum2 = returnType.IsEnum;
				if (isEnum2 && isEnum)
				{
					flag = Enum.GetUnderlyingType(delReturnType) == Enum.GetUnderlyingType(returnType);
				}
				else if (isEnum && Enum.GetUnderlyingType(delReturnType) == returnType)
				{
					flag = true;
				}
				else if (isEnum2 && Enum.GetUnderlyingType(returnType) == delReturnType)
				{
					flag = true;
				}
			}
		}
		return flag;
	}

	private static bool IsArgumentTypeMatch(Type delArgType, Type argType)
	{
		bool flag = delArgType == argType;
		if (!flag && !argType.IsValueType && argType.IsAssignableFrom(delArgType))
		{
			flag = true;
		}
		if (!flag)
		{
			if (delArgType.IsEnum && Enum.GetUnderlyingType(delArgType) == argType)
			{
				flag = true;
			}
			else if (argType.IsEnum && Enum.GetUnderlyingType(argType) == delArgType)
			{
				flag = true;
			}
		}
		return flag;
	}

	private static bool IsArgumentTypeMatchWithThis(Type delArgType, Type argType, bool boxedThis)
	{
		if (argType.IsValueType)
		{
			return (delArgType.IsByRef && delArgType.GetElementType() == argType) || (boxedThis && delArgType == argType);
		}
		return delArgType == argType || argType.IsAssignableFrom(delArgType);
	}

	protected virtual object? DynamicInvokeImpl(object?[]? args)
	{
		MethodInfo methodInfo = Method;
		object obj = _target;
		if (data == null)
		{
			data = CreateDelegateData();
		}
		MethodInfo methodInfo2 = GetType().GetMethod("Invoke");
		if (methodInfo2 != null && args != null)
		{
			ReadOnlySpan<ParameterInfo> parametersAsSpan = methodInfo2.GetParametersAsSpan();
			for (int i = 0; i < args.Length; i++)
			{
				if (args[i] == Type.Missing)
				{
					ParameterInfo parameterInfo = parametersAsSpan[i];
					if (parameterInfo.HasDefaultValue)
					{
						args[i] = parameterInfo.DefaultValue;
					}
				}
			}
		}
		if (methodInfo.IsStatic)
		{
			if (data.curried_first_arg)
			{
				if (args == null)
				{
					args = new object[1] { obj };
				}
				else
				{
					Array.Resize(ref args, args.Length + 1);
					Array.Copy(args, 0, args, 1, args.Length - 1);
					args[0] = obj;
				}
				obj = null;
			}
		}
		else if (_target == null && args != null && args.Length != 0)
		{
			obj = args[0];
			Array.Copy(args, 1, args, 0, args.Length - 1);
			Array.Resize(ref args, args.Length - 1);
		}
		return methodInfo.Invoke(obj, args);
	}

	public override bool Equals([NotNullWhen(true)] object? obj)
	{
		if (!(obj is Delegate obj2) || !InternalEqualTypes(this, obj))
		{
			return false;
		}
		if (obj2._target == _target && obj2.Method == Method)
		{
			if (obj2.data != null || data != null)
			{
				if (obj2.data != null && data != null)
				{
					if (obj2.data.target_type == data.target_type)
					{
						return obj2.data.method_name == data.method_name;
					}
					return false;
				}
				if (obj2.data != null)
				{
					return (object)obj2.data.target_type == null;
				}
				if (data != null)
				{
					return (object)data.target_type == null;
				}
				return false;
			}
			return true;
		}
		return false;
	}

	public override int GetHashCode()
	{
		MethodInfo methodInfo = Method;
		return ((methodInfo != null) ? methodInfo.GetHashCode() : GetType().GetHashCode()) ^ RuntimeHelpers.GetHashCode(_target);
	}

	protected virtual MethodInfo GetMethodImpl()
	{
		if (method_info != null)
		{
			return method_info;
		}
		if (method != IntPtr.Zero)
		{
			if (!method_is_virtual)
			{
				method_info = (MethodInfo)RuntimeMethodInfo.GetMethodFromHandleNoGenericCheck(new RuntimeMethodHandle(method));
			}
			else
			{
				method_info = GetVirtualMethod_internal();
			}
		}
		return method_info;
	}

	private DelegateData CreateDelegateData()
	{
		DelegateData delegateData = new DelegateData();
		if (method_info.IsStatic)
		{
			if (_target != null)
			{
				delegateData.curried_first_arg = true;
			}
			else
			{
				MethodInfo methodInfo = GetType().GetMethod("Invoke");
				if (methodInfo != null && methodInfo.GetParametersCount() + 1 == method_info.GetParametersCount())
				{
					delegateData.curried_first_arg = true;
				}
			}
		}
		return delegateData;
	}

	internal static bool InternalEqualTypes(object source, object value)
	{
		return source.GetType() == value.GetType();
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private protected static extern MulticastDelegate AllocDelegateLike_internal(Delegate d);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern Delegate CreateDelegate_internal(QCallTypeHandle type, object target, MethodInfo info, bool throwOnBindFailure);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private extern MethodInfo GetVirtualMethod_internal();

	public virtual object Clone()
	{
		return MemberwiseClone();
	}

	[return: NotNullIfNotNull("a")]
	[return: NotNullIfNotNull("b")]
	public static Delegate? Combine(Delegate? a, Delegate? b)
	{
		if ((object)a == null)
		{
			return b;
		}
		return a.CombineImpl(b);
	}

	public static Delegate? Combine(params Delegate?[]? delegates)
	{
		return Combine((ReadOnlySpan<Delegate>)delegates);
	}

	public static Delegate? Combine([ParamCollection] scoped ReadOnlySpan<Delegate?> delegates)
	{
		Delegate obj = null;
		if (!delegates.IsEmpty)
		{
			obj = delegates[0];
			for (int i = 1; i < delegates.Length; i++)
			{
				obj = Combine(obj, delegates[i]);
			}
		}
		return obj;
	}

	public static Delegate CreateDelegate(Type type, object? firstArgument, MethodInfo method)
	{
		return CreateDelegate(type, firstArgument, method, throwOnBindFailure: true);
	}

	public static Delegate CreateDelegate(Type type, MethodInfo method)
	{
		return CreateDelegate(type, method, throwOnBindFailure: true);
	}

	[RequiresUnreferencedCode("The target method might be removed")]
	public static Delegate CreateDelegate(Type type, object target, string method)
	{
		return CreateDelegate(type, target, method, ignoreCase: false, throwOnBindFailure: true);
	}

	[RequiresUnreferencedCode("The target method might be removed")]
	public static Delegate CreateDelegate(Type type, object target, string method, bool ignoreCase)
	{
		return CreateDelegate(type, target, method, ignoreCase, throwOnBindFailure: true);
	}

	public static Delegate CreateDelegate(Type type, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.AllMethods)] Type target, string method)
	{
		return CreateDelegate(type, target, method, ignoreCase: false, throwOnBindFailure: true);
	}

	public static Delegate CreateDelegate(Type type, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.AllMethods)] Type target, string method, bool ignoreCase)
	{
		return CreateDelegate(type, target, method, ignoreCase, throwOnBindFailure: true);
	}

	protected virtual Delegate CombineImpl(Delegate? d)
	{
		throw new MulticastNotSupportedException("Multicast_Combine");
	}

	protected virtual Delegate? RemoveImpl(Delegate d)
	{
		if (!d.Equals(this))
		{
			return this;
		}
		return null;
	}

	public virtual Delegate[] GetInvocationList()
	{
		return new Delegate[1] { this };
	}

	public static InvocationListEnumerator<TDelegate> EnumerateInvocationList<TDelegate>(TDelegate? d) where TDelegate : Delegate
	{
		return new InvocationListEnumerator<TDelegate>(Unsafe.As<MulticastDelegate>(d));
	}

	public object? DynamicInvoke(params object?[]? args)
	{
		return DynamicInvokeImpl(args);
	}

	[Obsolete("This API supports obsolete formatter-based serialization. It should not be called or extended by application code.", DiagnosticId = "SYSLIB0051", UrlFormat = "https://aka.ms/dotnet-warnings/{0}")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		throw new PlatformNotSupportedException();
	}

	public static Delegate? Remove(Delegate? source, Delegate? value)
	{
		if ((object)source == null)
		{
			return null;
		}
		if ((object)value == null)
		{
			return source;
		}
		if (!InternalEqualTypes(source, value))
		{
			throw new ArgumentException("Arg_DlgtTypeMis");
		}
		return source.RemoveImpl(value);
	}

	public static Delegate? RemoveAll(Delegate? source, Delegate? value)
	{
		Delegate obj;
		do
		{
			obj = source;
			source = Remove(source, value);
		}
		while (obj != source);
		return obj;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(Delegate? d1, Delegate? d2)
	{
		if ((object)d2 == null)
		{
			return (object)d1 == null;
		}
		if ((object)d2 != d1)
		{
			return d2.Equals(d1);
		}
		return true;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(Delegate? d1, Delegate? d2)
	{
		if ((object)d2 == null)
		{
			return (object)d1 != null;
		}
		if ((object)d2 != d1)
		{
			return !d2.Equals(d1);
		}
		return false;
	}
}
