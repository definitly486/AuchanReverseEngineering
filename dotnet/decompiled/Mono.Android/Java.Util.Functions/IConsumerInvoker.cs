using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Versioning;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Java.Util.Functions;

[Register("java/util/function/Consumer", DoNotGenerateAcw = true, ApiSince = 24)]
internal class IConsumerInvoker : Java.Lang.Object, IConsumer, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_java_util_function_Consumer = new XAPeerMembers("java/util/function/Consumer", typeof(IConsumerInvoker));

	private static Delegate? cb_accept_Accept_Ljava_lang_Object__V;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_java_util_function_Consumer;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_java_util_function_Consumer.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_java_util_function_Consumer.ManagedPeerType;

	public IConsumerInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	[SupportedOSPlatform("android24.0")]
	private static Delegate GetAccept_Ljava_lang_Object_Handler()
	{
		return new _JniMarshal_PPL_V(n_Accept_Ljava_lang_Object_);
	}

	[SupportedOSPlatform("android24.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Accept_Ljava_lang_Object_(nint jnienv, nint native__this, nint native_t)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IConsumer? consumer = Java.Lang.Object.GetObject<IConsumer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object t = Java.Lang.Object.GetObject<Java.Lang.Object>(native_t, JniHandleOwnership.DoNotTransfer);
			consumer.Accept(t);
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
	public unsafe void Accept(Java.Lang.Object? t)
	{
		nint num = JNIEnv.ToLocalJniHandle(t);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members_java_util_function_Consumer.InstanceMethods.InvokeAbstractVoidMethod("accept.(Ljava/lang/Object;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(t);
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
