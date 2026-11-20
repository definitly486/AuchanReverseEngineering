using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Kotlin.Jvm.Functions;

[Register("kotlin/jvm/functions/Function0", DoNotGenerateAcw = true)]
internal class IFunction0Invoker : Java.Lang.Object, IFunction0, IFunction, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_kotlin_Function = new XAPeerMembers("kotlin/Function", typeof(IFunction0Invoker));

	private static readonly JniPeerMembers _members_kotlin_jvm_functions_Function0 = new XAPeerMembers("kotlin/jvm/functions/Function0", typeof(IFunction0Invoker));

	private static Delegate? cb_invoke_Invoke_Ljava_lang_Object_;

	private static nint java_class_ref => _members_kotlin_jvm_functions_Function0.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_kotlin_jvm_functions_Function0;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_kotlin_jvm_functions_Function0.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_kotlin_jvm_functions_Function0.ManagedPeerType;

	public IFunction0Invoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetInvokeHandler()
	{
		return new global::_JniMarshal_PP_L(n_Invoke);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Invoke(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IFunction0>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Invoke());
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

	public unsafe Java.Lang.Object? Invoke()
	{
		return Java.Lang.Object.GetObject<Java.Lang.Object>(_members_kotlin_jvm_functions_Function0.InstanceMethods.InvokeAbstractObjectMethod("invoke.()Ljava/lang/Object;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
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
