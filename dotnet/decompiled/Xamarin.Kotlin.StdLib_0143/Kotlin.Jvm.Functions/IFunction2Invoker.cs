using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Kotlin.Jvm.Functions;

[Register("kotlin/jvm/functions/Function2", DoNotGenerateAcw = true)]
internal class IFunction2Invoker : Java.Lang.Object, IFunction2, IFunction, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_kotlin_Function = new XAPeerMembers("kotlin/Function", typeof(IFunction2Invoker));

	private static readonly JniPeerMembers _members_kotlin_jvm_functions_Function2 = new XAPeerMembers("kotlin/jvm/functions/Function2", typeof(IFunction2Invoker));

	private static Delegate? cb_invoke_Invoke_Ljava_lang_Object_Ljava_lang_Object__Ljava_lang_Object_;

	private static nint java_class_ref => _members_kotlin_jvm_functions_Function2.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_kotlin_jvm_functions_Function2;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_kotlin_jvm_functions_Function2.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_kotlin_jvm_functions_Function2.ManagedPeerType;

	public IFunction2Invoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetInvoke_Ljava_lang_Object_Ljava_lang_Object_Handler()
	{
		return new global::_JniMarshal_PPLL_L(n_Invoke_Ljava_lang_Object_Ljava_lang_Object_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Invoke_Ljava_lang_Object_Ljava_lang_Object_(nint jnienv, nint native__this, nint native_p0, nint native_p1)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IFunction2? function = Java.Lang.Object.GetObject<IFunction2>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object p = Java.Lang.Object.GetObject<Java.Lang.Object>(native_p0, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object p2 = Java.Lang.Object.GetObject<Java.Lang.Object>(native_p1, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(function.Invoke(p, p2));
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

	public unsafe Java.Lang.Object? Invoke(Java.Lang.Object? p0, Java.Lang.Object? p1)
	{
		nint num = JNIEnv.ToLocalJniHandle(p0);
		nint num2 = JNIEnv.ToLocalJniHandle(p1);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(num2);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members_kotlin_jvm_functions_Function2.InstanceMethods.InvokeAbstractObjectMethod("invoke.(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			JNIEnv.DeleteLocalRef(num2);
			GC.KeepAlive(p0);
			GC.KeepAlive(p1);
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
