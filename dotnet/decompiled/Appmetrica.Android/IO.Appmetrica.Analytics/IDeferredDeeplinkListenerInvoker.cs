using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace IO.Appmetrica.Analytics;

[Register("io/appmetrica/analytics/DeferredDeeplinkListener", DoNotGenerateAcw = true)]
internal class IDeferredDeeplinkListenerInvoker : Java.Lang.Object, IDeferredDeeplinkListener, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_io_appmetrica_analytics_DeferredDeeplinkListener = new XAPeerMembers("io/appmetrica/analytics/DeferredDeeplinkListener", typeof(IDeferredDeeplinkListenerInvoker));

	private static Delegate? cb_onDeeplinkLoaded_OnDeeplinkLoaded_Ljava_lang_String__V;

	private static Delegate? cb_onError_OnError_Lio_appmetrica_analytics_DeferredDeeplinkListener_Error_Ljava_lang_String__V;

	private static nint java_class_ref => _members_io_appmetrica_analytics_DeferredDeeplinkListener.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_io_appmetrica_analytics_DeferredDeeplinkListener;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_io_appmetrica_analytics_DeferredDeeplinkListener.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_io_appmetrica_analytics_DeferredDeeplinkListener.ManagedPeerType;

	public IDeferredDeeplinkListenerInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static void n_OnDeeplinkLoaded_Ljava_lang_String_(nint jnienv, nint native__this, nint native_p0)
	{
		IDeferredDeeplinkListener? deferredDeeplinkListener = Java.Lang.Object.GetObject<IDeferredDeeplinkListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
		deferredDeeplinkListener.OnDeeplinkLoaded(p);
	}

	public unsafe void OnDeeplinkLoaded(string p0)
	{
		nint num = JNIEnv.NewString(p0);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members_io_appmetrica_analytics_DeferredDeeplinkListener.InstanceMethods.InvokeAbstractVoidMethod("onDeeplinkLoaded.(Ljava/lang/String;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static void n_OnError_Lio_appmetrica_analytics_DeferredDeeplinkListener_Error_Ljava_lang_String_(nint jnienv, nint native__this, nint native_p0, nint native_p1)
	{
		IDeferredDeeplinkListener? deferredDeeplinkListener = Java.Lang.Object.GetObject<IDeferredDeeplinkListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IDeferredDeeplinkListener.Error p = Java.Lang.Object.GetObject<IDeferredDeeplinkListener.Error>(native_p0, JniHandleOwnership.DoNotTransfer);
		string p2 = JNIEnv.GetString(native_p1, JniHandleOwnership.DoNotTransfer);
		deferredDeeplinkListener.OnError(p, p2);
	}

	public unsafe void OnError(IDeferredDeeplinkListener.Error p0, string? p1)
	{
		nint num = JNIEnv.NewString(p1);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			_members_io_appmetrica_analytics_DeferredDeeplinkListener.InstanceMethods.InvokeAbstractVoidMethod("onError.(Lio/appmetrica/analytics/DeferredDeeplinkListener$Error;Ljava/lang/String;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(p0);
		}
	}

	[UnmanagedCallersOnly]
	private static void n_OnDeeplinkLoaded_Ljava_lang_String__mm_wrapper(nint jnienv, nint native__this, nint native_p0)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			n_OnDeeplinkLoaded_Ljava_lang_String_(jnienv, native__this, native_p0);
		}
		catch (System.Exception e)
		{
			Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
		}
	}

	[UnmanagedCallersOnly]
	private static void n_OnError_Lio_appmetrica_analytics_DeferredDeeplinkListener_Error_Ljava_lang_String__mm_wrapper(nint jnienv, nint native__this, nint native_p0, nint native_p1)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			n_OnError_Lio_appmetrica_analytics_DeferredDeeplinkListener_Error_Ljava_lang_String_(jnienv, native__this, native_p0, native_p1);
		}
		catch (System.Exception e)
		{
			Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
		}
	}
}
