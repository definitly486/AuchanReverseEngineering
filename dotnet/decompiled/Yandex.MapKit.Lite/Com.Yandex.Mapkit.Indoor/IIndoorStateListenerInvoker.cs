using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit.Indoor;

[Register("com/yandex/mapkit/indoor/IndoorStateListener", DoNotGenerateAcw = true)]
internal class IIndoorStateListenerInvoker : Java.Lang.Object, IIndoorStateListener, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_com_yandex_mapkit_indoor_IndoorStateListener = new XAPeerMembers("com/yandex/mapkit/indoor/IndoorStateListener", typeof(IIndoorStateListenerInvoker));

	private static Delegate? cb_onActiveLevelChanged_OnActiveLevelChanged_Ljava_lang_String__V;

	private static Delegate? cb_onActivePlanFocused_OnActivePlanFocused_Lcom_yandex_mapkit_indoor_IndoorPlan__V;

	private static Delegate? cb_onActivePlanLeft_OnActivePlanLeft_V;

	private static nint java_class_ref => _members_com_yandex_mapkit_indoor_IndoorStateListener.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_com_yandex_mapkit_indoor_IndoorStateListener;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_com_yandex_mapkit_indoor_IndoorStateListener.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_com_yandex_mapkit_indoor_IndoorStateListener.ManagedPeerType;

	public IIndoorStateListenerInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetOnActiveLevelChanged_Ljava_lang_String_Handler()
	{
		if ((object)cb_onActiveLevelChanged_OnActiveLevelChanged_Ljava_lang_String__V == null)
		{
			cb_onActiveLevelChanged_OnActiveLevelChanged_Ljava_lang_String__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnActiveLevelChanged_Ljava_lang_String_));
		}
		return cb_onActiveLevelChanged_OnActiveLevelChanged_Ljava_lang_String__V;
	}

	private static void n_OnActiveLevelChanged_Ljava_lang_String_(nint jnienv, nint native__this, nint native_p0)
	{
		IIndoorStateListener? indoorStateListener = Java.Lang.Object.GetObject<IIndoorStateListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
		indoorStateListener.OnActiveLevelChanged(p);
	}

	public unsafe void OnActiveLevelChanged(string p0)
	{
		nint num = JNIEnv.NewString(p0);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members_com_yandex_mapkit_indoor_IndoorStateListener.InstanceMethods.InvokeAbstractVoidMethod("onActiveLevelChanged.(Ljava/lang/String;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetOnActivePlanFocused_Lcom_yandex_mapkit_indoor_IndoorPlan_Handler()
	{
		if ((object)cb_onActivePlanFocused_OnActivePlanFocused_Lcom_yandex_mapkit_indoor_IndoorPlan__V == null)
		{
			cb_onActivePlanFocused_OnActivePlanFocused_Lcom_yandex_mapkit_indoor_IndoorPlan__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnActivePlanFocused_Lcom_yandex_mapkit_indoor_IndoorPlan_));
		}
		return cb_onActivePlanFocused_OnActivePlanFocused_Lcom_yandex_mapkit_indoor_IndoorPlan__V;
	}

	private static void n_OnActivePlanFocused_Lcom_yandex_mapkit_indoor_IndoorPlan_(nint jnienv, nint native__this, nint native_p0)
	{
		IIndoorStateListener? indoorStateListener = Java.Lang.Object.GetObject<IIndoorStateListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IIndoorPlan p = Java.Lang.Object.GetObject<IIndoorPlan>(native_p0, JniHandleOwnership.DoNotTransfer);
		indoorStateListener.OnActivePlanFocused(p);
	}

	public unsafe void OnActivePlanFocused(IIndoorPlan p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			_members_com_yandex_mapkit_indoor_IndoorStateListener.InstanceMethods.InvokeAbstractVoidMethod("onActivePlanFocused.(Lcom/yandex/mapkit/indoor/IndoorPlan;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetOnActivePlanLeftHandler()
	{
		if ((object)cb_onActivePlanLeft_OnActivePlanLeft_V == null)
		{
			cb_onActivePlanLeft_OnActivePlanLeft_V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_OnActivePlanLeft));
		}
		return cb_onActivePlanLeft_OnActivePlanLeft_V;
	}

	private static void n_OnActivePlanLeft(nint jnienv, nint native__this)
	{
		Java.Lang.Object.GetObject<IIndoorStateListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnActivePlanLeft();
	}

	public unsafe void OnActivePlanLeft()
	{
		_members_com_yandex_mapkit_indoor_IndoorStateListener.InstanceMethods.InvokeAbstractVoidMethod("onActivePlanLeft.()V", this, null);
	}
}
