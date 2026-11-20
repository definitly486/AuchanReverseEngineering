using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace System.Reflection;

[StructLayout(LayoutKind.Sequential)]
internal sealed class RuntimeMethodInfo : MethodInfo
{
	internal nint mhandle;

	private string name;

	private Type reftype;

	private string toString;

	private RuntimeType[] parameterTypes;

	private MethodBaseInvoker invoker;

	internal InvocationFlags InvocationFlags
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get
		{
			return Invoker._invocationFlags;
		}
	}

	private MethodBaseInvoker Invoker
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get
		{
			if (invoker == null)
			{
				invoker = new MethodBaseInvoker(this);
			}
			return invoker;
		}
	}

	public override Module Module => GetRuntimeModule();

	public override bool IsCollectible => false;

	public override ParameterInfo ReturnParameter => MonoMethodInfo.GetReturnParameterInfo(this);

	public override Type ReturnType => MonoMethodInfo.GetReturnType(mhandle);

	public override ICustomAttributeProvider ReturnTypeCustomAttributes => MonoMethodInfo.GetReturnParameterInfo(this);

	public override int MetadataToken => get_metadata_token(this);

	internal RuntimeType[] ArgumentTypes
	{
		get
		{
			if (parameterTypes != null)
			{
				return parameterTypes;
			}
			ParameterInfo[] parametersInternal = GetParametersInternal();
			RuntimeType[] array = new RuntimeType[parametersInternal.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = (RuntimeType)parametersInternal[i].ParameterType;
			}
			Interlocked.CompareExchange(ref parameterTypes, array, null);
			return array;
		}
	}

	public override RuntimeMethodHandle MethodHandle => new RuntimeMethodHandle(mhandle);

	public override MethodAttributes Attributes => MonoMethodInfo.GetAttributes(mhandle);

	public override CallingConventions CallingConvention => MonoMethodInfo.GetCallingConvention(mhandle);

	public override Type ReflectedType => reftype;

	public override Type DeclaringType => MonoMethodInfo.GetDeclaringType(mhandle);

	public override string Name
	{
		get
		{
			if (name != null)
			{
				return name;
			}
			return get_name(this);
		}
	}

	public override extern bool IsGenericMethodDefinition
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		get;
	}

	public override extern bool IsGenericMethod
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		get;
	}

	public override bool ContainsGenericParameters
	{
		get
		{
			if (IsGenericMethod)
			{
				Type[] genericArguments = GetGenericArguments();
				for (int i = 0; i < genericArguments.Length; i++)
				{
					if (genericArguments[i].ContainsGenericParameters)
					{
						return true;
					}
				}
			}
			return DeclaringType.ContainsGenericParameters;
		}
	}

	public override Delegate CreateDelegate(Type delegateType)
	{
		return Delegate.CreateDelegate(delegateType, this);
	}

	public override Delegate CreateDelegate(Type delegateType, object target)
	{
		return Delegate.CreateDelegate(delegateType, target, this);
	}

	public override string ToString()
	{
		if (toString == null)
		{
			ValueStringBuilder sbParamList = new ValueStringBuilder(100);
			sbParamList.Append(ReturnType.FormatTypeName());
			sbParamList.Append(' ');
			sbParamList.Append(Name);
			if (IsGenericMethod)
			{
				sbParamList.Append(RuntimeMethodHandle.ConstructInstantiation(this));
			}
			sbParamList.Append('(');
			MethodBase.AppendParameters(ref sbParamList, GetParameterTypes(), CallingConvention);
			sbParamList.Append(')');
			toString = sbParamList.ToString();
		}
		return toString;
	}

	internal RuntimeModule GetRuntimeModule()
	{
		return ((RuntimeType)DeclaringType).GetRuntimeModule();
	}

	internal static MethodBase GetMethodFromHandleNoGenericCheck(RuntimeMethodHandle handle)
	{
		return GetMethodFromHandleInternalType_native(handle.Value, IntPtr.Zero, genericCheck: false);
	}

	internal static MethodBase GetMethodFromHandleNoGenericCheck(RuntimeMethodHandle handle, RuntimeTypeHandle reflectedType)
	{
		return GetMethodFromHandleInternalType_native(handle.Value, reflectedType.Value, genericCheck: false);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern MethodBody GetMethodBodyInternal(nint handle);

	[RequiresUnreferencedCode("Trimming may change method bodies. For example it can change some instructions, remove branches or local variables.")]
	internal static MethodBody GetMethodBody(nint handle)
	{
		return GetMethodBodyInternal(handle);
	}

	internal static MethodBase GetMethodFromHandleInternalType(nint method_handle, nint type_handle)
	{
		return GetMethodFromHandleInternalType_native(method_handle, type_handle, genericCheck: true);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern MethodBase GetMethodFromHandleInternalType_native(nint method_handle, nint type_handle, bool genericCheck);

	internal RuntimeMethodInfo()
	{
	}

	internal RuntimeMethodInfo(RuntimeMethodHandle mhandle)
	{
		this.mhandle = mhandle.Value;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern string get_name(MethodBase method);

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern RuntimeMethodInfo get_base_method(RuntimeMethodInfo method, bool definition);

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern int get_metadata_token(RuntimeMethodInfo method);

	public override MethodInfo GetBaseDefinition()
	{
		return get_base_method(this, definition: true);
	}

	internal MethodInfo GetBaseMethod()
	{
		return get_base_method(this, definition: false);
	}

	public override MethodImplAttributes GetMethodImplementationFlags()
	{
		return MonoMethodInfo.GetMethodImplementationFlags(mhandle);
	}

	public override ParameterInfo[] GetParameters()
	{
		ParameterInfo[] o = MonoMethodInfo.GetParametersInfo(mhandle, this);
		if (o.Length == 0)
		{
			return o;
		}
		ParameterInfo[] o2 = new ParameterInfo[o.Length];
		Array.FastCopy(ObjectHandleOnStack.Create(ref o), 0, ObjectHandleOnStack.Create(ref o2), 0, o.Length);
		return o2;
	}

	internal override ParameterInfo[] GetParametersInternal()
	{
		return MonoMethodInfo.GetParametersInfo(mhandle, this);
	}

	internal override int GetParametersCount()
	{
		return MonoMethodInfo.GetParametersInfo(mhandle, this).Length;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal unsafe extern object InternalInvoke(object obj, nint* args, out Exception exc);

	public override bool IsDefined(Type attributeType, bool inherit)
	{
		return CustomAttribute.IsDefined(this, attributeType, inherit);
	}

	public override object[] GetCustomAttributes(bool inherit)
	{
		return CustomAttribute.GetCustomAttributes(this, inherit);
	}

	public override object[] GetCustomAttributes(Type attributeType, bool inherit)
	{
		return CustomAttribute.GetCustomAttributes(this, attributeType, inherit);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal extern void GetPInvoke(out PInvokeAttributes flags, out string entryPoint, out string dllName);

	internal object[] GetPseudoCustomAttributes()
	{
		int num = 0;
		MonoMethodInfo methodInfo = MonoMethodInfo.GetMethodInfo(mhandle);
		if ((methodInfo.iattrs & MethodImplAttributes.PreserveSig) != MethodImplAttributes.IL)
		{
			num++;
		}
		if ((methodInfo.attrs & MethodAttributes.PinvokeImpl) != MethodAttributes.PrivateScope)
		{
			num++;
		}
		if (num == 0)
		{
			return null;
		}
		object[] array = new object[num];
		num = 0;
		if ((methodInfo.iattrs & MethodImplAttributes.PreserveSig) != MethodImplAttributes.IL)
		{
			array[num++] = new PreserveSigAttribute();
		}
		if ((methodInfo.attrs & MethodAttributes.PinvokeImpl) != MethodAttributes.PrivateScope)
		{
			array[num++] = GetDllImportAttribute();
		}
		return array;
	}

	private DllImportAttribute GetDllImportAttribute()
	{
		GetPInvoke(out var flags, out var entryPoint, out var dllName);
		CharSet charSet = CharSet.None;
		switch (flags & PInvokeAttributes.CharSetMask)
		{
		case PInvokeAttributes.CharSetNotSpec:
			charSet = CharSet.None;
			break;
		case PInvokeAttributes.CharSetAnsi:
			charSet = CharSet.Ansi;
			break;
		case PInvokeAttributes.CharSetUnicode:
			charSet = CharSet.Unicode;
			break;
		case PInvokeAttributes.CharSetMask:
			charSet = CharSet.Auto;
			break;
		}
		CallingConvention callingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl;
		switch (flags & PInvokeAttributes.CallConvMask)
		{
		case PInvokeAttributes.CallConvWinapi:
			callingConvention = System.Runtime.InteropServices.CallingConvention.Winapi;
			break;
		case PInvokeAttributes.CallConvCdecl:
			callingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl;
			break;
		case PInvokeAttributes.CallConvStdcall:
			callingConvention = System.Runtime.InteropServices.CallingConvention.StdCall;
			break;
		case PInvokeAttributes.CallConvThiscall:
			callingConvention = System.Runtime.InteropServices.CallingConvention.ThisCall;
			break;
		case PInvokeAttributes.CallConvFastcall:
			callingConvention = System.Runtime.InteropServices.CallingConvention.FastCall;
			break;
		}
		bool exactSpelling = (flags & PInvokeAttributes.NoMangle) != 0;
		bool setLastError = (flags & PInvokeAttributes.SupportsLastError) != 0;
		bool bestFitMapping = (flags & PInvokeAttributes.BestFitMask) == PInvokeAttributes.BestFitEnabled;
		bool throwOnUnmappableChar = (flags & PInvokeAttributes.ThrowOnUnmappableCharMask) == PInvokeAttributes.ThrowOnUnmappableCharEnabled;
		bool preserveSig = (GetMethodImplementationFlags() & MethodImplAttributes.PreserveSig) != 0;
		return new DllImportAttribute(dllName)
		{
			EntryPoint = entryPoint,
			CharSet = charSet,
			SetLastError = setLastError,
			ExactSpelling = exactSpelling,
			PreserveSig = preserveSig,
			BestFitMapping = bestFitMapping,
			ThrowOnUnmappableChar = throwOnUnmappableChar,
			CallingConvention = callingConvention
		};
	}

	internal CustomAttributeData[] GetPseudoCustomAttributesData()
	{
		int num = 0;
		MonoMethodInfo methodInfo = MonoMethodInfo.GetMethodInfo(mhandle);
		if ((methodInfo.iattrs & MethodImplAttributes.PreserveSig) != MethodImplAttributes.IL)
		{
			num++;
		}
		if ((methodInfo.attrs & MethodAttributes.PinvokeImpl) != MethodAttributes.PrivateScope)
		{
			num++;
		}
		if (num == 0)
		{
			return null;
		}
		CustomAttributeData[] array = new CustomAttributeData[num];
		num = 0;
		if ((methodInfo.iattrs & MethodImplAttributes.PreserveSig) != MethodImplAttributes.IL)
		{
			array[num++] = new RuntimeCustomAttributeData(typeof(PreserveSigAttribute).GetConstructor(Type.EmptyTypes));
		}
		if ((methodInfo.attrs & MethodAttributes.PinvokeImpl) != MethodAttributes.PrivateScope)
		{
			array[num++] = GetDllImportAttributeData();
		}
		return array;
	}

	private RuntimeCustomAttributeData GetDllImportAttributeData()
	{
		if ((Attributes & MethodAttributes.PinvokeImpl) == 0)
		{
			return null;
		}
		GetPInvoke(out var flags, out var entryPoint, out var dllName);
		CharSet charSet = (flags & PInvokeAttributes.CharSetMask) switch
		{
			PInvokeAttributes.CharSetNotSpec => CharSet.None, 
			PInvokeAttributes.CharSetAnsi => CharSet.Ansi, 
			PInvokeAttributes.CharSetUnicode => CharSet.Unicode, 
			PInvokeAttributes.CharSetMask => CharSet.Auto, 
			_ => CharSet.None, 
		};
		CallingConvention callingConvention = (flags & PInvokeAttributes.CallConvMask) switch
		{
			PInvokeAttributes.CallConvWinapi => System.Runtime.InteropServices.CallingConvention.Winapi, 
			PInvokeAttributes.CallConvCdecl => System.Runtime.InteropServices.CallingConvention.Cdecl, 
			PInvokeAttributes.CallConvStdcall => System.Runtime.InteropServices.CallingConvention.StdCall, 
			PInvokeAttributes.CallConvThiscall => System.Runtime.InteropServices.CallingConvention.ThisCall, 
			PInvokeAttributes.CallConvFastcall => System.Runtime.InteropServices.CallingConvention.FastCall, 
			_ => System.Runtime.InteropServices.CallingConvention.Cdecl, 
		};
		bool flag = (flags & PInvokeAttributes.NoMangle) != 0;
		bool flag2 = (flags & PInvokeAttributes.SupportsLastError) != 0;
		bool flag3 = (flags & PInvokeAttributes.BestFitMask) == PInvokeAttributes.BestFitEnabled;
		bool flag4 = (flags & PInvokeAttributes.ThrowOnUnmappableCharMask) == PInvokeAttributes.ThrowOnUnmappableCharEnabled;
		bool flag5 = (GetMethodImplementationFlags() & MethodImplAttributes.PreserveSig) != 0;
		CustomAttributeTypedArgument[] ctorArgs = new CustomAttributeTypedArgument[1]
		{
			new CustomAttributeTypedArgument(typeof(string), dllName)
		};
		Type typeFromHandle = typeof(DllImportAttribute);
		CustomAttributeNamedArgument[] namedArgs = new CustomAttributeNamedArgument[8]
		{
			new CustomAttributeNamedArgument(typeFromHandle.GetField("EntryPoint"), entryPoint),
			new CustomAttributeNamedArgument(typeFromHandle.GetField("CharSet"), charSet),
			new CustomAttributeNamedArgument(typeFromHandle.GetField("ExactSpelling"), flag),
			new CustomAttributeNamedArgument(typeFromHandle.GetField("SetLastError"), flag2),
			new CustomAttributeNamedArgument(typeFromHandle.GetField("PreserveSig"), flag5),
			new CustomAttributeNamedArgument(typeFromHandle.GetField("CallingConvention"), callingConvention),
			new CustomAttributeNamedArgument(typeFromHandle.GetField("BestFitMapping"), flag3),
			new CustomAttributeNamedArgument(typeFromHandle.GetField("ThrowOnUnmappableChar"), flag4)
		};
		return new RuntimeCustomAttributeData(typeFromHandle.GetConstructor(new Type[1] { typeof(string) }), ctorArgs, namedArgs);
	}

	[RequiresUnreferencedCode("If some of the generic arguments are annotated (either with DynamicallyAccessedMembersAttribute, or generic constraints), trimming can't validate that the requirements of those annotations are met.")]
	public override MethodInfo MakeGenericMethod(params Type[] methodInstantiation)
	{
		ArgumentNullException.ThrowIfNull(methodInstantiation, "methodInstantiation");
		if (!IsGenericMethodDefinition)
		{
			throw new InvalidOperationException(SR.Format("Arg_NotGenericMethodDefinition", this));
		}
		if (GetGenericArguments().Length != methodInstantiation.Length)
		{
			throw new ArgumentException(SR.Format("Argument_NotEnoughGenArguments", GetGenericArguments().Length, methodInstantiation.Length));
		}
		bool flag = false;
		foreach (Type obj in methodInstantiation)
		{
			if (obj == null)
			{
				throw new ArgumentNullException();
			}
			if (!(obj is RuntimeType))
			{
				flag = true;
			}
		}
		if (flag)
		{
			_ = 1;
			return new MethodOnTypeBuilderInstantiation(this, methodInstantiation);
		}
		MethodInfo methodInfo = MakeGenericMethod_impl(methodInstantiation);
		if (methodInfo == null)
		{
			throw new ArgumentException(SR.Format("Argument_NotEnoughGenArguments", GetGenericArguments().Length, methodInstantiation.Length));
		}
		return methodInfo;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private extern MethodInfo MakeGenericMethod_impl(Type[] types);

	[MethodImpl(MethodImplOptions.InternalCall)]
	public override extern Type[] GetGenericArguments();

	[MethodImpl(MethodImplOptions.InternalCall)]
	private extern MethodInfo GetGenericMethodDefinition_impl();

	public override MethodInfo GetGenericMethodDefinition()
	{
		MethodInfo genericMethodDefinition_impl = GetGenericMethodDefinition_impl();
		if (genericMethodDefinition_impl == null)
		{
			throw new InvalidOperationException();
		}
		return genericMethodDefinition_impl;
	}

	[RequiresUnreferencedCode("Trimming may change method bodies. For example it can change some instructions, remove branches or local variables.")]
	public override MethodBody GetMethodBody()
	{
		return GetMethodBody(mhandle);
	}

	public override IList<CustomAttributeData> GetCustomAttributesData()
	{
		return RuntimeCustomAttributeData.GetCustomAttributesInternal(this);
	}

	public sealed override bool HasSameMetadataDefinitionAs(MemberInfo other)
	{
		return HasSameMetadataDefinitionAsCore<RuntimeMethodInfo>(other);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal InvocationFlags ComputeAndUpdateInvocationFlags()
	{
		InvocationFlags invocationFlags = InvocationFlags.Unknown;
		Type declaringType = DeclaringType;
		if (ContainsGenericParameters || IsDisallowedByRefType(ReturnType) || (CallingConvention & CallingConventions.VarArgs) == CallingConventions.VarArgs)
		{
			invocationFlags = InvocationFlags.NoInvoke;
		}
		else
		{
			if (declaringType != null)
			{
				if (declaringType.ContainsGenericParameters)
				{
					invocationFlags = InvocationFlags.NoInvoke;
				}
				else if (declaringType.IsByRefLike)
				{
					invocationFlags |= InvocationFlags.ContainsStackPointers;
				}
			}
			if (ReturnType.IsByRefLike)
			{
				invocationFlags |= InvocationFlags.ContainsStackPointers;
			}
		}
		return invocationFlags | InvocationFlags.Initialized;
		static bool IsDisallowedByRefType(Type type)
		{
			if (!type.IsByRef)
			{
				return false;
			}
			Type elementType = type.GetElementType();
			if (!elementType.IsByRefLike)
			{
				return elementType == typeof(void);
			}
			return true;
		}
	}

	[DoesNotReturn]
	internal void ThrowNoInvokeException()
	{
		if ((InvocationFlags & InvocationFlags.ContainsStackPointers) != InvocationFlags.Unknown)
		{
			throw new NotSupportedException();
		}
		if ((CallingConvention & CallingConventions.VarArgs) == CallingConventions.VarArgs)
		{
			throw new NotSupportedException();
		}
		if (DeclaringType.ContainsGenericParameters || ContainsGenericParameters)
		{
			throw new InvalidOperationException("Arg_UnboundGenParam");
		}
		if (base.IsAbstract)
		{
			throw new MemberAccessException();
		}
		if (ReturnType.IsByRef)
		{
			Type? elementType = ReturnType.GetElementType();
			if (elementType.IsByRefLike)
			{
				throw new NotSupportedException("NotSupported_ByRefToByRefLikeReturn");
			}
			if (elementType == typeof(void))
			{
				throw new NotSupportedException("NotSupported_ByRefToVoidReturn");
			}
		}
		throw new TargetException();
	}

	[DebuggerStepThrough]
	[DebuggerHidden]
	public override object Invoke(object obj, BindingFlags invokeAttr, Binder binder, object[] parameters, CultureInfo culture)
	{
		if ((InvocationFlags & (InvocationFlags.NoInvoke | InvocationFlags.ContainsStackPointers)) != InvocationFlags.Unknown)
		{
			ThrowNoInvokeException();
		}
		if (!base.IsStatic)
		{
			MethodInvokerCommon.ValidateInvokeTarget(obj, this);
		}
		int num = ((parameters != null) ? parameters.Length : 0);
		if (ArgumentTypes.Length != num)
		{
			MethodBaseInvoker.ThrowTargetParameterCountException();
		}
		switch (num)
		{
		case 0:
			return Invoker.InvokeWithNoArgs(obj, invokeAttr);
		case 1:
			return Invoker.InvokeWithOneArg(obj, invokeAttr, binder, parameters, culture);
		case 2:
		case 3:
		case 4:
			return Invoker.InvokeWithFewArgs(obj, invokeAttr, binder, parameters, culture);
		default:
			return Invoker.InvokeWithManyArgs(obj, invokeAttr, binder, parameters, culture);
		}
	}
}
