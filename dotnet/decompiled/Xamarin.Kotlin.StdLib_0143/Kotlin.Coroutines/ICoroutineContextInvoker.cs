using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;
using Kotlin.Jvm.Functions;

namespace Kotlin.Coroutines;

[Register("kotlin/coroutines/CoroutineContext", DoNotGenerateAcw = true)]
internal class ICoroutineContextInvoker : Java.Lang.Object, ICoroutineContext, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_kotlin_coroutines_CoroutineContext = new XAPeerMembers("kotlin/coroutines/CoroutineContext", typeof(ICoroutineContextInvoker));

	private static Delegate? cb_fold_Fold_Ljava_lang_Object_Lkotlin_jvm_functions_Function2__Ljava_lang_Object_;

	private static Delegate? cb_get_Get_Lkotlin_coroutines_CoroutineContext_Key__Lkotlin_coroutines_CoroutineContext_Element_;

	private static Delegate? cb_minusKey_MinusKey_Lkotlin_coroutines_CoroutineContext_Key__Lkotlin_coroutines_CoroutineContext_;

	private static Delegate? cb_plus_Plus_Lkotlin_coroutines_CoroutineContext__Lkotlin_coroutines_CoroutineContext_;

	private static nint java_class_ref => _members_kotlin_coroutines_CoroutineContext.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_kotlin_coroutines_CoroutineContext;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_kotlin_coroutines_CoroutineContext.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_kotlin_coroutines_CoroutineContext.ManagedPeerType;

	public ICoroutineContextInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetFold_Ljava_lang_Object_Lkotlin_jvm_functions_Function2_Handler()
	{
		return new global::_JniMarshal_PPLL_L(n_Fold_Ljava_lang_Object_Lkotlin_jvm_functions_Function2_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Fold_Ljava_lang_Object_Lkotlin_jvm_functions_Function2_(nint jnienv, nint native__this, nint native_initial, nint native_operation)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			ICoroutineContext? coroutineContext = Java.Lang.Object.GetObject<ICoroutineContext>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object initial = Java.Lang.Object.GetObject<Java.Lang.Object>(native_initial, JniHandleOwnership.DoNotTransfer);
			IFunction2 operation = Java.Lang.Object.GetObject<IFunction2>(native_operation, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(coroutineContext.Fold(initial, operation));
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

	public unsafe Java.Lang.Object? Fold(Java.Lang.Object? initial, IFunction2 operation)
	{
		nint num = JNIEnv.ToLocalJniHandle(initial);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue((operation == null) ? IntPtr.Zero : ((Java.Lang.Object)operation).Handle);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members_kotlin_coroutines_CoroutineContext.InstanceMethods.InvokeAbstractObjectMethod("fold.(Ljava/lang/Object;Lkotlin/jvm/functions/Function2;)Ljava/lang/Object;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(initial);
			GC.KeepAlive(operation);
		}
	}

	private static Delegate GetGet_Lkotlin_coroutines_CoroutineContext_Key_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_Get_Lkotlin_coroutines_CoroutineContext_Key_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Get_Lkotlin_coroutines_CoroutineContext_Key_(nint jnienv, nint native__this, nint native_key)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			ICoroutineContext? coroutineContext = Java.Lang.Object.GetObject<ICoroutineContext>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICoroutineContextKey key = Java.Lang.Object.GetObject<ICoroutineContextKey>(native_key, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(coroutineContext.Get(key));
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

	public unsafe Java.Lang.Object? Get(ICoroutineContextKey key)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((key == null) ? IntPtr.Zero : ((Java.Lang.Object)key).Handle);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members_kotlin_coroutines_CoroutineContext.InstanceMethods.InvokeAbstractObjectMethod("get.(Lkotlin/coroutines/CoroutineContext$Key;)Lkotlin/coroutines/CoroutineContext$Element;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(key);
		}
	}

	private static Delegate GetMinusKey_Lkotlin_coroutines_CoroutineContext_Key_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_MinusKey_Lkotlin_coroutines_CoroutineContext_Key_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_MinusKey_Lkotlin_coroutines_CoroutineContext_Key_(nint jnienv, nint native__this, nint native_key)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			ICoroutineContext? coroutineContext = Java.Lang.Object.GetObject<ICoroutineContext>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICoroutineContextKey key = Java.Lang.Object.GetObject<ICoroutineContextKey>(native_key, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(coroutineContext.MinusKey(key));
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

	public unsafe ICoroutineContext MinusKey(ICoroutineContextKey key)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((key == null) ? IntPtr.Zero : ((Java.Lang.Object)key).Handle);
			return Java.Lang.Object.GetObject<ICoroutineContext>(_members_kotlin_coroutines_CoroutineContext.InstanceMethods.InvokeAbstractObjectMethod("minusKey.(Lkotlin/coroutines/CoroutineContext$Key;)Lkotlin/coroutines/CoroutineContext;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(key);
		}
	}

	private static Delegate GetPlus_Lkotlin_coroutines_CoroutineContext_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_Plus_Lkotlin_coroutines_CoroutineContext_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Plus_Lkotlin_coroutines_CoroutineContext_(nint jnienv, nint native__this, nint native_context)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			ICoroutineContext? coroutineContext = Java.Lang.Object.GetObject<ICoroutineContext>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICoroutineContext context = Java.Lang.Object.GetObject<ICoroutineContext>(native_context, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(coroutineContext.Plus(context));
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

	public unsafe ICoroutineContext Plus(ICoroutineContext context)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((context == null) ? IntPtr.Zero : ((Java.Lang.Object)context).Handle);
			return Java.Lang.Object.GetObject<ICoroutineContext>(_members_kotlin_coroutines_CoroutineContext.InstanceMethods.InvokeAbstractObjectMethod("plus.(Lkotlin/coroutines/CoroutineContext;)Lkotlin/coroutines/CoroutineContext;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(context);
		}
	}

	int IJavaPeerable.get_JniIdentityHashCode()
	{
		return base.JniIdentityHashCode;
	}

	JniObjectReference IJavaPeerable.get_PeerReference()
	{
		return base.PeerReference;
	}

	void IJavaPeerable.UnregisterFromRuntime()
	{
		UnregisterFromRuntime();
	}
}
