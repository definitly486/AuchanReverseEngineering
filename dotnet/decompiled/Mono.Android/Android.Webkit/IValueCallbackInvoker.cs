using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Webkit;

[Register("android/webkit/ValueCallback", DoNotGenerateAcw = true)]
internal class IValueCallbackInvoker : Java.Lang.Object, IValueCallback, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_android_webkit_ValueCallback = new XAPeerMembers("android/webkit/ValueCallback", typeof(IValueCallbackInvoker));

	private static Delegate? cb_onReceiveValue_OnReceiveValue_Ljava_lang_Object__V;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_android_webkit_ValueCallback;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_android_webkit_ValueCallback.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_android_webkit_ValueCallback.ManagedPeerType;

	public IValueCallbackInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetOnReceiveValue_Ljava_lang_Object_Handler()
	{
		return new _JniMarshal_PPL_V(n_OnReceiveValue_Ljava_lang_Object_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnReceiveValue_Ljava_lang_Object_(nint jnienv, nint native__this, nint native_value)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IValueCallback? valueCallback = Java.Lang.Object.GetObject<IValueCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object value = Java.Lang.Object.GetObject<Java.Lang.Object>(native_value, JniHandleOwnership.DoNotTransfer);
			valueCallback.OnReceiveValue(value);
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

	public unsafe void OnReceiveValue(Java.Lang.Object? value)
	{
		nint num = JNIEnv.ToLocalJniHandle(value);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members_android_webkit_ValueCallback.InstanceMethods.InvokeAbstractVoidMethod("onReceiveValue.(Ljava/lang/Object;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(value);
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
