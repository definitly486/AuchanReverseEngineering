using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace System.Reflection;

[StructLayout(LayoutKind.Sequential)]
internal sealed class RuntimeConstructorInfo : ConstructorInfo
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

	internal MethodBaseInvoker Invoker
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

	public override bool ContainsGenericParameters => DeclaringType.ContainsGenericParameters;

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
			return RuntimeMethodInfo.get_name(this);
		}
	}

	public override int MetadataToken => get_metadata_token(this);

	internal RuntimeModule GetRuntimeModule()
	{
		return RuntimeTypeHandle.GetModule((RuntimeType)DeclaringType);
	}

	public override MethodImplAttributes GetMethodImplementationFlags()
	{
		return MonoMethodInfo.GetMethodImplementationFlags(mhandle);
	}

	public override ParameterInfo[] GetParameters()
	{
		return MonoMethodInfo.GetParametersInfo(mhandle, this);
	}

	internal override ParameterInfo[] GetParametersInternal()
	{
		return MonoMethodInfo.GetParametersInfo(mhandle, this);
	}

	internal override int GetParametersCount()
	{
		ParameterInfo[] parametersInfo = MonoMethodInfo.GetParametersInfo(mhandle, this);
		if (parametersInfo != null)
		{
			return parametersInfo.Length;
		}
		return 0;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern void InvokeClassConstructor(QCallTypeHandle type);

	private void InvokeClassConstructor()
	{
		RuntimeType type = (RuntimeType)DeclaringType;
		InvokeClassConstructor(new QCallTypeHandle(ref type));
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

	[RequiresUnreferencedCode("Trimming may change method bodies. For example it can change some instructions, remove branches or local variables.")]
	public override MethodBody GetMethodBody()
	{
		return RuntimeMethodInfo.GetMethodBody(mhandle);
	}

	public override string ToString()
	{
		if (toString == null)
		{
			ValueStringBuilder sbParamList = new ValueStringBuilder(100);
			sbParamList.Append("Void ");
			sbParamList.Append(Name);
			sbParamList.Append('(');
			MethodBase.AppendParameters(ref sbParamList, GetParameterTypes(), CallingConvention);
			sbParamList.Append(')');
			toString = sbParamList.ToString();
		}
		return toString;
	}

	public override IList<CustomAttributeData> GetCustomAttributesData()
	{
		return RuntimeCustomAttributeData.GetCustomAttributesInternal(this);
	}

	public sealed override bool HasSameMetadataDefinitionAs(MemberInfo other)
	{
		return HasSameMetadataDefinitionAsCore<RuntimeConstructorInfo>(other);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern int get_metadata_token(RuntimeConstructorInfo method);

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal InvocationFlags ComputeAndUpdateInvocationFlags()
	{
		InvocationFlags invocationFlags = InvocationFlags.IsConstructor;
		Type declaringType = DeclaringType;
		if (declaringType == typeof(void) || (declaringType != null && declaringType.ContainsGenericParameters) || (CallingConvention & CallingConventions.VarArgs) == CallingConventions.VarArgs)
		{
			invocationFlags |= InvocationFlags.NoInvoke;
		}
		else if (base.IsStatic)
		{
			invocationFlags |= InvocationFlags.RunClassConstructor | InvocationFlags.NoConstructorInvoke;
		}
		else if (declaringType != null && declaringType.IsAbstract)
		{
			invocationFlags |= InvocationFlags.NoConstructorInvoke;
		}
		else
		{
			if (declaringType != null && declaringType.IsByRefLike)
			{
				invocationFlags |= InvocationFlags.ContainsStackPointers;
			}
			if (typeof(Delegate).IsAssignableFrom(DeclaringType))
			{
				invocationFlags |= InvocationFlags.IsDelegateConstructor;
			}
		}
		return invocationFlags | InvocationFlags.Initialized;
	}

	internal static void CheckCanCreateInstance(Type declaringType, bool isVarArg)
	{
		ArgumentNullException.ThrowIfNull(declaringType, "declaringType");
		if (declaringType.IsInterface)
		{
			throw new MemberAccessException(SR.Format("Acc_CreateInterfaceEx", declaringType));
		}
		if (declaringType.IsAbstract)
		{
			throw new MemberAccessException(SR.Format("Acc_CreateAbstEx", declaringType));
		}
		if (declaringType.GetRootElementType() == typeof(ArgIterator))
		{
			throw new NotSupportedException();
		}
		if (isVarArg)
		{
			throw new NotSupportedException();
		}
		if (declaringType.ContainsGenericParameters)
		{
			throw new MemberAccessException(SR.Format("Acc_CreateGenericEx", declaringType));
		}
		if (declaringType == typeof(void))
		{
			throw new MemberAccessException("Access_Void");
		}
	}

	[DoesNotReturn]
	internal void ThrowNoInvokeException()
	{
		CheckCanCreateInstance(DeclaringType, (CallingConvention & CallingConventions.VarArgs) == CallingConventions.VarArgs);
		if ((Attributes & MethodAttributes.Static) == MethodAttributes.Static)
		{
			throw new MemberAccessException("Acc_NotClassInit");
		}
		throw new TargetException();
	}

	[DebuggerStepThrough]
	[DebuggerHidden]
	public override object Invoke(object obj, BindingFlags invokeAttr, Binder binder, object[] parameters, CultureInfo culture)
	{
		if ((InvocationFlags & InvocationFlags.NoInvoke) != InvocationFlags.Unknown)
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
		if ((InvocationFlags & InvocationFlags.RunClassConstructor) != InvocationFlags.Unknown)
		{
			InvokeClassConstructor();
			return null;
		}
		if (num != 0)
		{
			return Invoker.InvokeConstructorWithoutAlloc(obj, invokeAttr, binder, parameters, culture);
		}
		return Invoker.InvokeConstructorWithoutAlloc(obj, (invokeAttr & BindingFlags.DoNotWrapExceptions) == 0);
	}

	[DebuggerStepThrough]
	[DebuggerHidden]
	public override object Invoke(BindingFlags invokeAttr, Binder binder, object[] parameters, CultureInfo culture)
	{
		if ((InvocationFlags & (InvocationFlags.NoInvoke | InvocationFlags.NoConstructorInvoke | InvocationFlags.ContainsStackPointers)) != InvocationFlags.Unknown)
		{
			ThrowNoInvokeException();
		}
		int num = ((parameters != null) ? parameters.Length : 0);
		if (ArgumentTypes.Length != num)
		{
			MethodBaseInvoker.ThrowTargetParameterCountException();
		}
		switch (num)
		{
		case 0:
			return Invoker.InvokeWithNoArgs(null, invokeAttr);
		case 1:
			return Invoker.InvokeWithOneArg(null, invokeAttr, binder, parameters, culture);
		case 2:
		case 3:
		case 4:
			return Invoker.InvokeWithFewArgs(null, invokeAttr, binder, parameters, culture);
		default:
			return Invoker.InvokeWithManyArgs(null, invokeAttr, binder, parameters, culture);
		}
	}
}
