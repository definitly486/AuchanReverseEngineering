using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace IO.Appmetrica.Analytics;

[Register("io/appmetrica/analytics/DeferredDeeplinkParametersListener", DoNotGenerateAcw = true)]
internal class IDeferredDeeplinkParametersListenerInvoker : Java.Lang.Object, IDeferredDeeplinkParametersListener, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_io_appmetrica_analytics_DeferredDeeplinkParametersListener = new XAPeerMembers("io/appmetrica/analytics/DeferredDeeplinkParametersListener", typeof(IDeferredDeeplinkParametersListenerInvoker));

	private static Delegate? cb_onError_OnError_Lio_appmetrica_analytics_DeferredDeeplinkParametersListener_Error_Ljava_lang_String__V;

	private static Delegate? cb_onParametersLoaded_OnParametersLoaded_Ljava_util_Map__V;

	private static nint java_class_ref => _members_io_appmetrica_analytics_DeferredDeeplinkParametersListener.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_io_appmetrica_analytics_DeferredDeeplinkParametersListener;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_io_appmetrica_analytics_DeferredDeeplinkParametersListener.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_io_appmetrica_analytics_DeferredDeeplinkParametersListener.ManagedPeerType;

	public IDeferredDeeplinkParametersListenerInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetOnError_Lio_appmetrica_analytics_DeferredDeeplinkParametersListener_Error_Ljava_lang_String_Handler()
	{
		if ((object)cb_onError_OnError_Lio_appmetrica_analytics_DeferredDeeplinkParametersListener_Error_Ljava_lang_String__V == null)
		{
			cb_onError_OnError_Lio_appmetrica_analytics_DeferredDeeplinkParametersListener_Error_Ljava_lang_String__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_OnError_Lio_appmetrica_analytics_DeferredDeeplinkParametersListener_Error_Ljava_lang_String_));
		}
		return cb_onError_OnError_Lio_appmetrica_analytics_DeferredDeeplinkParametersListener_Error_Ljava_lang_String__V;
	}

	private static void n_OnError_Lio_appmetrica_analytics_DeferredDeeplinkParametersListener_Error_Ljava_lang_String_(nint jnienv, nint native__this, nint native_p0, nint native_p1)
	{
		IDeferredDeeplinkParametersListener? deferredDeeplinkParametersListener = Java.Lang.Object.GetObject<IDeferredDeeplinkParametersListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IDeferredDeeplinkParametersListener.Error p = Java.Lang.Object.GetObject<IDeferredDeeplinkParametersListener.Error>(native_p0, JniHandleOwnership.DoNotTransfer);
		string p2 = JNIEnv.GetString(native_p1, JniHandleOwnership.DoNotTransfer);
		deferredDeeplinkParametersListener.OnError(p, p2);
	}

	public unsafe void OnError(IDeferredDeeplinkParametersListener.Error p0, string p1)
	{
		nint num = JNIEnv.NewString(p1);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			_members_io_appmetrica_analytics_DeferredDeeplinkParametersListener.InstanceMethods.InvokeAbstractVoidMethod("onError.(Lio/appmetrica/analytics/DeferredDeeplinkParametersListener$Error;Ljava/lang/String;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetOnParametersLoaded_Ljava_util_Map_Handler()
	{
		if ((object)cb_onParametersLoaded_OnParametersLoaded_Ljava_util_Map__V == null)
		{
			cb_onParametersLoaded_OnParametersLoaded_Ljava_util_Map__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnParametersLoaded_Ljava_util_Map_));
		}
		return cb_onParametersLoaded_OnParametersLoaded_Ljava_util_Map__V;
	}

	private static void n_OnParametersLoaded_Ljava_util_Map_(nint jnienv, nint native__this, nint native_p0)
	{
		IDeferredDeeplinkParametersListener? deferredDeeplinkParametersListener = Java.Lang.Object.GetObject<IDeferredDeeplinkParametersListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IDictionary<string, string> p = JavaDictionary<string, string>.FromJniHandle(native_p0, JniHandleOwnership.DoNotTransfer);
		deferredDeeplinkParametersListener.OnParametersLoaded(p);
	}

	public unsafe void OnParametersLoaded(IDictionary<string, string> p0)
	{
		nint num = JavaDictionary<string, string>.ToLocalJniHandle(p0);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members_io_appmetrica_analytics_DeferredDeeplinkParametersListener.InstanceMethods.InvokeAbstractVoidMethod("onParametersLoaded.(Ljava/util/Map;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(p0);
		}
	}
}
