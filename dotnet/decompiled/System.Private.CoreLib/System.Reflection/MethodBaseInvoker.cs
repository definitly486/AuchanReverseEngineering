using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace System.Reflection;

internal sealed class MethodBaseInvoker
{
	private InvokerEmitUtil.InvokeFunc_ObjSpanArgs _invokeFunc_ObjSpanArgs;

	private InvokerEmitUtil.InvokeFunc_RefArgs _invokeFunc_RefArgs;

	private MethodBase.InvokerStrategy _strategy;

	internal readonly InvocationFlags _invocationFlags;

	private readonly MethodBase.InvokerArgFlags[] _invokerArgFlags;

	private readonly RuntimeType[] _argTypes;

	private readonly MethodBase _method;

	private readonly int _argCount;

	private readonly bool _needsByRefStrategy;

	internal unsafe MethodBaseInvoker(RuntimeMethodInfo method)
		: this(method, method.ArgumentTypes)
	{
		_invocationFlags = method.ComputeAndUpdateInvocationFlags();
		_invokeFunc_RefArgs = InterpretedInvoke_Method;
	}

	internal unsafe MethodBaseInvoker(RuntimeConstructorInfo constructor)
		: this(constructor, constructor.ArgumentTypes)
	{
		_invocationFlags = constructor.ComputeAndUpdateInvocationFlags();
		_invokeFunc_RefArgs = InterpretedInvoke_Constructor;
	}

	private unsafe object InterpretedInvoke_Method(object obj, nint* args)
	{
		Exception exc;
		object result = ((RuntimeMethodInfo)_method).InternalInvoke(obj, args, out exc);
		if (exc != null)
		{
			throw exc;
		}
		return result;
	}

	internal unsafe object InterpretedInvoke_Constructor(object obj, nint* args)
	{
		Exception exc;
		object result = ((RuntimeConstructorInfo)_method).InternalInvoke(obj, args, out exc);
		if (exc != null)
		{
			throw exc;
		}
		if (obj != null)
		{
			return null;
		}
		return result;
	}

	private MethodBaseInvoker(MethodBase method, RuntimeType[] argumentTypes)
	{
		_method = method;
		_argTypes = argumentTypes;
		_argCount = _argTypes.Length;
		MethodInvokerCommon.Initialize(argumentTypes, out _strategy, out _invokerArgFlags, out _needsByRefStrategy);
	}

	[DoesNotReturn]
	internal static void ThrowTargetParameterCountException()
	{
		throw new TargetParameterCountException("Arg_ParmCnt");
	}

	internal unsafe object InvokeWithNoArgs(object obj, BindingFlags invokeAttr)
	{
		if ((_strategy & MethodBase.InvokerStrategy.StrategyDetermined_RefArgs) == 0)
		{
			MethodInvokerCommon.DetermineStrategy_RefArgs(ref _strategy, ref _invokeFunc_RefArgs, _method, backwardsCompat: true);
		}
		try
		{
			return _invokeFunc_RefArgs(obj, null);
		}
		catch (Exception inner) when ((invokeAttr & BindingFlags.DoNotWrapExceptions) == 0)
		{
			throw new TargetInvocationException(inner);
		}
	}

	internal object InvokeWithOneArg(object obj, BindingFlags invokeAttr, Binder binder, object[] parameters, CultureInfo culture)
	{
		object reference = parameters[0];
		ReadOnlySpan<object> parameters2 = new ReadOnlySpan<object>(in reference);
		object reference2 = null;
		Span<object> span = new Span<object>(ref reference2);
		bool reference3 = false;
		Span<bool> shouldCopyBack = new Span<bool>(ref reference3);
		if ((_strategy & MethodBase.InvokerStrategy.StrategyDetermined_ObjSpanArgs) == 0)
		{
			MethodInvokerCommon.DetermineStrategy_ObjSpanArgs(ref _strategy, ref _invokeFunc_ObjSpanArgs, _method, _needsByRefStrategy, backwardsCompat: true);
		}
		CheckArguments(parameters2, span, shouldCopyBack, binder, culture, invokeAttr);
		object result;
		if (_invokeFunc_ObjSpanArgs != null)
		{
			try
			{
				result = _invokeFunc_ObjSpanArgs(obj, span);
			}
			catch (Exception inner) when ((invokeAttr & BindingFlags.DoNotWrapExceptions) == 0)
			{
				throw new TargetInvocationException(inner);
			}
		}
		else
		{
			result = InvokeDirectByRefWithFewArgs(obj, span, invokeAttr);
		}
		CopyBack(parameters, span, shouldCopyBack);
		return result;
	}

	internal object InvokeWithFewArgs(object obj, BindingFlags invokeAttr, Binder binder, object[] parameters, CultureInfo culture)
	{
		MethodBase.StackAllocatedArgumentsWithCopyBack stackAllocatedArgumentsWithCopyBack = default(MethodBase.StackAllocatedArgumentsWithCopyBack);
		Span<object> span = _003CPrivateImplementationDetails_003E.InlineArrayAsSpan<MethodBase.ArgumentData<object>, object>(ref stackAllocatedArgumentsWithCopyBack._args, 4).Slice(0, _argCount);
		Span<bool> shouldCopyBack = _003CPrivateImplementationDetails_003E.InlineArrayAsSpan<MethodBase.ArgumentData<bool>, bool>(ref stackAllocatedArgumentsWithCopyBack._shouldCopyBack, 4).Slice(0, _argCount);
		if ((_strategy & MethodBase.InvokerStrategy.StrategyDetermined_ObjSpanArgs) == 0)
		{
			MethodInvokerCommon.DetermineStrategy_ObjSpanArgs(ref _strategy, ref _invokeFunc_ObjSpanArgs, _method, _needsByRefStrategy, backwardsCompat: true);
		}
		CheckArguments(parameters, span, shouldCopyBack, binder, culture, invokeAttr);
		object result;
		if (_invokeFunc_ObjSpanArgs != null)
		{
			try
			{
				result = _invokeFunc_ObjSpanArgs(obj, span);
			}
			catch (Exception inner) when ((invokeAttr & BindingFlags.DoNotWrapExceptions) == 0)
			{
				throw new TargetInvocationException(inner);
			}
		}
		else
		{
			result = InvokeDirectByRefWithFewArgs(obj, span, invokeAttr);
		}
		CopyBack(parameters, span, shouldCopyBack);
		return result;
	}

	internal unsafe object InvokeDirectByRefWithFewArgs(object obj, Span<object> copyOfArgs, BindingFlags invokeAttr)
	{
		if ((_strategy & MethodBase.InvokerStrategy.StrategyDetermined_RefArgs) == 0)
		{
			MethodInvokerCommon.DetermineStrategy_RefArgs(ref _strategy, ref _invokeFunc_RefArgs, _method, backwardsCompat: true);
		}
		MethodBase.StackAllocatedByRefs stackAllocatedByRefs = default(MethodBase.StackAllocatedByRefs);
		nint* ptr = (nint*)(&stackAllocatedByRefs);
		for (int i = 0; i < _argCount; i++)
		{
			Unsafe.Write((byte*)ptr + (nint)i * (nint)8, ((_invokerArgFlags[i] & MethodBase.InvokerArgFlags.IsValueType) != 0) ? ByReference.Create(ref copyOfArgs[i].GetRawData()) : ByReference.Create(ref copyOfArgs[i]));
		}
		try
		{
			return _invokeFunc_RefArgs(obj, ptr);
		}
		catch (Exception inner) when ((invokeAttr & BindingFlags.DoNotWrapExceptions) == 0)
		{
			throw new TargetInvocationException(inner);
		}
	}

	internal unsafe object InvokeWithManyArgs(object obj, BindingFlags invokeAttr, Binder binder, object[] parameters, CultureInfo culture)
	{
		if ((_strategy & MethodBase.InvokerStrategy.StrategyDetermined_ObjSpanArgs) == 0)
		{
			MethodInvokerCommon.DetermineStrategy_ObjSpanArgs(ref _strategy, ref _invokeFunc_ObjSpanArgs, _method, _needsByRefStrategy, backwardsCompat: true);
		}
		object result;
		if (_invokeFunc_ObjSpanArgs != null)
		{
			nint* ptr = (nint*)stackalloc byte[(int)checked(unchecked((nuint)(uint)(_argCount * 2)) * (nuint)8u)];
			NativeMemory.Clear(ptr, (nuint)((nint)_argCount * (nint)8 * 2));
			Span<object> span = new Span<object>(ref Unsafe.AsRef<object>(ptr), _argCount);
			new GCFrameRegistration(ptr, (uint)_argCount, areByRefs: false);
			Span<bool> shouldCopyBack = new Span<bool>((byte*)ptr + (nint)_argCount * (nint)8, _argCount);
			try
			{
				CheckArguments(parameters, span, shouldCopyBack, binder, culture, invokeAttr);
				try
				{
					result = _invokeFunc_ObjSpanArgs(obj, span);
				}
				catch (Exception inner) when ((invokeAttr & BindingFlags.DoNotWrapExceptions) == 0)
				{
					throw new TargetInvocationException(inner);
				}
				CopyBack(parameters, span, shouldCopyBack);
			}
			finally
			{
			}
		}
		else
		{
			if ((_strategy & MethodBase.InvokerStrategy.StrategyDetermined_RefArgs) == 0)
			{
				MethodInvokerCommon.DetermineStrategy_RefArgs(ref _strategy, ref _invokeFunc_RefArgs, _method, backwardsCompat: true);
			}
			nint* ptr2 = (nint*)stackalloc byte[(int)checked(unchecked((nuint)(uint)(3 * _argCount)) * (nuint)8u)];
			NativeMemory.Clear(ptr2, (nuint)(3 * _argCount) * (nuint)8u);
			Span<object> span = new Span<object>(ref Unsafe.AsRef<object>(ptr2), _argCount);
			new GCFrameRegistration(ptr2, (uint)_argCount, areByRefs: false);
			nint* ptr3 = (nint*)((byte*)ptr2 + (nint)_argCount * (nint)8);
			new GCFrameRegistration(ptr3, (uint)_argCount);
			Span<bool> shouldCopyBack = new Span<bool>((byte*)ptr2 + (nint)(_argCount * 2) * (nint)8, _argCount);
			try
			{
				CheckArguments(parameters, span, shouldCopyBack, binder, culture, invokeAttr);
				for (int i = 0; i < _argCount; i++)
				{
					Unsafe.Write((byte*)ptr3 + (nint)i * (nint)8, ((_invokerArgFlags[i] & MethodBase.InvokerArgFlags.IsValueType) != 0) ? ByReference.Create(ref Unsafe.AsRef<object>((byte*)ptr2 + (nint)i * (nint)8).GetRawData()) : ByReference.Create(ref Unsafe.AsRef<object>((byte*)ptr2 + (nint)i * (nint)8)));
				}
				try
				{
					result = _invokeFunc_RefArgs(obj, ptr3);
				}
				catch (Exception inner2) when ((invokeAttr & BindingFlags.DoNotWrapExceptions) == 0)
				{
					throw new TargetInvocationException(inner2);
				}
				CopyBack(parameters, span, shouldCopyBack);
			}
			finally
			{
			}
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal void CopyBack(object[] dest, Span<object> copyOfParameters, Span<bool> shouldCopyBack)
	{
		for (int i = 0; i < dest.Length; i++)
		{
			if (shouldCopyBack[i])
			{
				if ((_invokerArgFlags[i] & MethodBase.InvokerArgFlags.IsNullableOfT) != 0)
				{
					dest[i] = RuntimeMethodHandle.ReboxFromNullable(copyOfParameters[i]);
				}
				else
				{
					dest[i] = copyOfParameters[i];
				}
			}
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal void CheckArguments(ReadOnlySpan<object> parameters, Span<object> copyOfParameters, Span<bool> shouldCopyBack, Binder binder, CultureInfo culture, BindingFlags invokeAttr)
	{
		for (int i = 0; i < parameters.Length; i++)
		{
			object arg = parameters[i];
			RuntimeType runtimeType = _argTypes[i];
			if (arg == Type.Missing)
			{
				arg = MethodBase.HandleTypeMissing(_method.GetParametersAsSpan()[i], runtimeType);
				shouldCopyBack[i] = true;
			}
			if (arg == null)
			{
				if ((_invokerArgFlags[i] & MethodBase.InvokerArgFlags.IsValueType_ByRef_Or_Pointer) != 0)
				{
					shouldCopyBack[i] = runtimeType.CheckValue(ref arg, binder, culture, invokeAttr);
				}
			}
			else if ((object)arg.GetType() != runtimeType)
			{
				if (TryByRefFastPath(runtimeType, ref arg))
				{
					shouldCopyBack[i] = true;
				}
				else
				{
					shouldCopyBack[i] = runtimeType.CheckValue(ref arg, binder, culture, invokeAttr);
				}
			}
			copyOfParameters[i] = arg;
		}
	}

	private static bool TryByRefFastPath(RuntimeType type, ref object arg)
	{
		if (RuntimeType.TryGetByRefElementType(type, out var elementType) && (object)elementType == arg.GetType())
		{
			if (elementType.IsValueType)
			{
				arg = RuntimeType.AllocateValueType(elementType, arg);
			}
			return true;
		}
		return false;
	}

	internal unsafe object InvokeConstructorWithoutAlloc(object obj, BindingFlags invokeAttr, Binder binder, object[] parameters, CultureInfo culture)
	{
		bool flag = (invokeAttr & BindingFlags.DoNotWrapExceptions) == 0;
		int argCount = _argCount;
		Span<bool> shouldCopyBack = stackalloc bool[argCount];
		nint* ptr = (nint*)stackalloc byte[(int)checked(unchecked((nuint)(uint)(2 * argCount)) * (nuint)8u)];
		NativeMemory.Clear(ptr, (nuint)(2 * argCount) * (nuint)8u);
		Span<object> copyOfParameters = new Span<object>(ref Unsafe.AsRef<object>(ptr), argCount);
		new GCFrameRegistration(ptr, (uint)argCount, areByRefs: false);
		nint* ptr2 = (nint*)((byte*)ptr + (nint)argCount * (nint)8);
		new GCFrameRegistration(ptr2, (uint)argCount);
		try
		{
			CheckArguments(parameters, copyOfParameters, shouldCopyBack, binder, culture, invokeAttr);
			for (int i = 0; i < argCount; i++)
			{
				Unsafe.Write((byte*)ptr2 + (nint)i * (nint)8, ((_invokerArgFlags[i] & MethodBase.InvokerArgFlags.IsValueType) != 0) ? ByReference.Create(ref Unsafe.AsRef<object>((byte*)ptr + (nint)i * (nint)8).GetRawData()) : ByReference.Create(ref Unsafe.AsRef<object>((byte*)ptr + (nint)i * (nint)8)));
			}
			object result;
			try
			{
				result = InterpretedInvoke_Constructor(obj, ptr2);
			}
			catch (Exception inner) when (flag)
			{
				throw new TargetInvocationException(inner);
			}
			CopyBack(parameters, copyOfParameters, shouldCopyBack);
			return result;
		}
		finally
		{
		}
	}

	internal unsafe object InvokeConstructorWithoutAlloc(object obj, bool wrapInTargetInvocationException)
	{
		try
		{
			return InterpretedInvoke_Constructor(obj, null);
		}
		catch (Exception inner) when (wrapInTargetInvocationException)
		{
			throw new TargetInvocationException(inner);
		}
	}
}
