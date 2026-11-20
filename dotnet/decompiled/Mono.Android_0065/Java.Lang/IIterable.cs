using System;
using System.Diagnostics;
using System.Runtime.Versioning;
using Android.Runtime;
using Java.Interop;
using Java.Util;
using Java.Util.Functions;

namespace Java.Lang;

[Register("java/lang/Iterable", "", "Java.Lang.IIterableInvoker")]
[JavaTypeParameters(new string[] { "T" })]
public interface IIterable : IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("java/lang/Iterable", typeof(IIterable), isInterface: true);

	private static Delegate? cb_forEach_ForEach_Ljava_util_function_Consumer__V;

	private static Delegate? cb_spliterator_Spliterator_Ljava_util_Spliterator_;

	IIterator Iterator();

	[SupportedOSPlatform("android24.0")]
	private static Delegate GetForEach_Ljava_util_function_Consumer_Handler()
	{
		return new _JniMarshal_PPL_V(n_ForEach_Ljava_util_function_Consumer_);
	}

	[SupportedOSPlatform("android24.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_ForEach_Ljava_util_function_Consumer_(nint jnienv, nint native__this, nint native_action)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IIterable? iterable = Object.GetObject<IIterable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IConsumer action = Object.GetObject<IConsumer>(native_action, JniHandleOwnership.DoNotTransfer);
			iterable.ForEach(action);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[SupportedOSPlatform("android24.0")]
	unsafe void ForEach(IConsumer action)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((action == null) ? IntPtr.Zero : ((Object)action).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("forEach.(Ljava/util/function/Consumer;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(action);
		}
	}

	[SupportedOSPlatform("android24.0")]
	private static Delegate GetSpliteratorHandler()
	{
		return new _JniMarshal_PP_L(n_Spliterator);
	}

	[SupportedOSPlatform("android24.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Spliterator(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Object.GetObject<IIterable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Spliterator());
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[SupportedOSPlatform("android24.0")]
	unsafe ISpliterator Spliterator()
	{
		return Object.GetObject<ISpliterator>(_members.InstanceMethods.InvokeVirtualObjectMethod("spliterator.()Ljava/util/Spliterator;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}
}
