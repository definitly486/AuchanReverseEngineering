using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Kotlin.Jvm.Functions;

[Register("kotlin/jvm/functions/Function1", DoNotGenerateAcw = true)]
internal class IFunction1Invoker : Java.Lang.Object, IFunction1, IFunction, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_kotlin_Function = new XAPeerMembers("kotlin/Function", typeof(IFunction1Invoker));

	private static readonly JniPeerMembers _members_kotlin_jvm_functions_Function1 = new XAPeerMembers("kotlin/jvm/functions/Function1", typeof(IFunction1Invoker));

	private static Delegate? cb_invoke_Invoke_Ljava_lang_Object__Ljava_lang_Object_;

	private static nint java_class_ref => _members_kotlin_jvm_functions_Function1.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_kotlin_jvm_functions_Function1;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_kotlin_jvm_functions_Function1.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_kotlin_jvm_functions_Function1.ManagedPeerType;

	public IFunction1Invoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetInvoke_Ljava_lang_Object_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_Invoke_Ljava_lang_Object_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Invoke_Ljava_lang_Object_(nint jnienv, nint native__this, nint native_p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IFunction1? function = Java.Lang.Object.GetObject<IFunction1>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object p = Java.Lang.Object.GetObject<Java.Lang.Object>(native_p0, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(function.Invoke(p));
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

	public unsafe Java.Lang.Object? Invoke(Java.Lang.Object? p0)
	{
		nint num = JNIEnv.ToLocalJniHandle(p0);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members_kotlin_jvm_functions_Function1.InstanceMethods.InvokeAbstractObjectMethod("invoke.(Ljava/lang/Object;)Ljava/lang/Object;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(p0);
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
