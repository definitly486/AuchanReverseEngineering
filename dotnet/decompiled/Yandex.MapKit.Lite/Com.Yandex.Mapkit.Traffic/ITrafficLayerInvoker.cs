using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit.Traffic;

[Register("com/yandex/mapkit/traffic/TrafficLayer", DoNotGenerateAcw = true)]
internal class ITrafficLayerInvoker : Java.Lang.Object, ITrafficLayer, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_com_yandex_mapkit_traffic_TrafficLayer = new XAPeerMembers("com/yandex/mapkit/traffic/TrafficLayer", typeof(ITrafficLayerInvoker));

	private static Delegate? cb_isValid_IsValid_Z;

	private static Delegate? cb_isTrafficVisible_IsTrafficVisible_Z;

	private static Delegate? cb_setTrafficVisible_SetTrafficVisible_Z_V;

	private static Delegate? cb_addTrafficListener_AddTrafficListener_Lcom_yandex_mapkit_traffic_TrafficListener__V;

	private static Delegate? cb_removeTrafficListener_RemoveTrafficListener_Lcom_yandex_mapkit_traffic_TrafficListener__V;

	private static Delegate? cb_resetTrafficStyles_ResetTrafficStyles_V;

	private static Delegate? cb_setTrafficStyle_SetTrafficStyle_ILjava_lang_String__Z;

	private static Delegate? cb_setTrafficStyle_SetTrafficStyle_Ljava_lang_String__Z;

	private static nint java_class_ref => _members_com_yandex_mapkit_traffic_TrafficLayer.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_com_yandex_mapkit_traffic_TrafficLayer;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_com_yandex_mapkit_traffic_TrafficLayer.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_com_yandex_mapkit_traffic_TrafficLayer.ManagedPeerType;

	public unsafe bool IsValid => _members_com_yandex_mapkit_traffic_TrafficLayer.InstanceMethods.InvokeAbstractBooleanMethod("isValid.()Z", this, null);

	public unsafe bool TrafficVisible
	{
		get
		{
			return _members_com_yandex_mapkit_traffic_TrafficLayer.InstanceMethods.InvokeAbstractBooleanMethod("isTrafficVisible.()Z", this, null);
		}
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members_com_yandex_mapkit_traffic_TrafficLayer.InstanceMethods.InvokeAbstractVoidMethod("setTrafficVisible.(Z)V", this, ptr);
		}
	}

	public ITrafficLayerInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetIsValidHandler()
	{
		if ((object)cb_isValid_IsValid_Z == null)
		{
			cb_isValid_IsValid_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsValid));
		}
		return cb_isValid_IsValid_Z;
	}

	private static bool n_IsValid(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<ITrafficLayer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsValid;
	}

	private static Delegate GetIsTrafficVisibleHandler()
	{
		if ((object)cb_isTrafficVisible_IsTrafficVisible_Z == null)
		{
			cb_isTrafficVisible_IsTrafficVisible_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsTrafficVisible));
		}
		return cb_isTrafficVisible_IsTrafficVisible_Z;
	}

	private static bool n_IsTrafficVisible(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<ITrafficLayer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TrafficVisible;
	}

	private static Delegate GetSetTrafficVisible_ZHandler()
	{
		if ((object)cb_setTrafficVisible_SetTrafficVisible_Z_V == null)
		{
			cb_setTrafficVisible_SetTrafficVisible_Z_V = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPZ_V(n_SetTrafficVisible_Z));
		}
		return cb_setTrafficVisible_SetTrafficVisible_Z_V;
	}

	private static void n_SetTrafficVisible_Z(nint jnienv, nint native__this, bool p0)
	{
		Java.Lang.Object.GetObject<ITrafficLayer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TrafficVisible = p0;
	}

	private static Delegate GetAddTrafficListener_Lcom_yandex_mapkit_traffic_TrafficListener_Handler()
	{
		if ((object)cb_addTrafficListener_AddTrafficListener_Lcom_yandex_mapkit_traffic_TrafficListener__V == null)
		{
			cb_addTrafficListener_AddTrafficListener_Lcom_yandex_mapkit_traffic_TrafficListener__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_AddTrafficListener_Lcom_yandex_mapkit_traffic_TrafficListener_));
		}
		return cb_addTrafficListener_AddTrafficListener_Lcom_yandex_mapkit_traffic_TrafficListener__V;
	}

	private static void n_AddTrafficListener_Lcom_yandex_mapkit_traffic_TrafficListener_(nint jnienv, nint native__this, nint native_p0)
	{
		ITrafficLayer? trafficLayer = Java.Lang.Object.GetObject<ITrafficLayer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ITrafficListener p = Java.Lang.Object.GetObject<ITrafficListener>(native_p0, JniHandleOwnership.DoNotTransfer);
		trafficLayer.AddTrafficListener(p);
	}

	public unsafe void AddTrafficListener(ITrafficListener p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			_members_com_yandex_mapkit_traffic_TrafficLayer.InstanceMethods.InvokeAbstractVoidMethod("addTrafficListener.(Lcom/yandex/mapkit/traffic/TrafficListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetRemoveTrafficListener_Lcom_yandex_mapkit_traffic_TrafficListener_Handler()
	{
		if ((object)cb_removeTrafficListener_RemoveTrafficListener_Lcom_yandex_mapkit_traffic_TrafficListener__V == null)
		{
			cb_removeTrafficListener_RemoveTrafficListener_Lcom_yandex_mapkit_traffic_TrafficListener__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_RemoveTrafficListener_Lcom_yandex_mapkit_traffic_TrafficListener_));
		}
		return cb_removeTrafficListener_RemoveTrafficListener_Lcom_yandex_mapkit_traffic_TrafficListener__V;
	}

	private static void n_RemoveTrafficListener_Lcom_yandex_mapkit_traffic_TrafficListener_(nint jnienv, nint native__this, nint native_p0)
	{
		ITrafficLayer? trafficLayer = Java.Lang.Object.GetObject<ITrafficLayer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ITrafficListener p = Java.Lang.Object.GetObject<ITrafficListener>(native_p0, JniHandleOwnership.DoNotTransfer);
		trafficLayer.RemoveTrafficListener(p);
	}

	public unsafe void RemoveTrafficListener(ITrafficListener p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			_members_com_yandex_mapkit_traffic_TrafficLayer.InstanceMethods.InvokeAbstractVoidMethod("removeTrafficListener.(Lcom/yandex/mapkit/traffic/TrafficListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetResetTrafficStylesHandler()
	{
		if ((object)cb_resetTrafficStyles_ResetTrafficStyles_V == null)
		{
			cb_resetTrafficStyles_ResetTrafficStyles_V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_ResetTrafficStyles));
		}
		return cb_resetTrafficStyles_ResetTrafficStyles_V;
	}

	private static void n_ResetTrafficStyles(nint jnienv, nint native__this)
	{
		Java.Lang.Object.GetObject<ITrafficLayer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ResetTrafficStyles();
	}

	public unsafe void ResetTrafficStyles()
	{
		_members_com_yandex_mapkit_traffic_TrafficLayer.InstanceMethods.InvokeAbstractVoidMethod("resetTrafficStyles.()V", this, null);
	}

	private static Delegate GetSetTrafficStyle_ILjava_lang_String_Handler()
	{
		if ((object)cb_setTrafficStyle_SetTrafficStyle_ILjava_lang_String__Z == null)
		{
			cb_setTrafficStyle_SetTrafficStyle_ILjava_lang_String__Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPIL_Z(n_SetTrafficStyle_ILjava_lang_String_));
		}
		return cb_setTrafficStyle_SetTrafficStyle_ILjava_lang_String__Z;
	}

	private static bool n_SetTrafficStyle_ILjava_lang_String_(nint jnienv, nint native__this, int p0, nint native_p1)
	{
		ITrafficLayer? trafficLayer = Java.Lang.Object.GetObject<ITrafficLayer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		string p1 = JNIEnv.GetString(native_p1, JniHandleOwnership.DoNotTransfer);
		return trafficLayer.SetTrafficStyle(p0, p1);
	}

	public unsafe bool SetTrafficStyle(int p0, string p1)
	{
		nint num = JNIEnv.NewString(p1);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(p0);
			ptr[1] = new JniArgumentValue(num);
			return _members_com_yandex_mapkit_traffic_TrafficLayer.InstanceMethods.InvokeAbstractBooleanMethod("setTrafficStyle.(ILjava/lang/String;)Z", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetSetTrafficStyle_Ljava_lang_String_Handler()
	{
		if ((object)cb_setTrafficStyle_SetTrafficStyle_Ljava_lang_String__Z == null)
		{
			cb_setTrafficStyle_SetTrafficStyle_Ljava_lang_String__Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_SetTrafficStyle_Ljava_lang_String_));
		}
		return cb_setTrafficStyle_SetTrafficStyle_Ljava_lang_String__Z;
	}

	private static bool n_SetTrafficStyle_Ljava_lang_String_(nint jnienv, nint native__this, nint native_p0)
	{
		ITrafficLayer? trafficLayer = Java.Lang.Object.GetObject<ITrafficLayer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		string trafficStyle = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
		return trafficLayer.SetTrafficStyle(trafficStyle);
	}

	public unsafe bool SetTrafficStyle(string p0)
	{
		nint num = JNIEnv.NewString(p0);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return _members_com_yandex_mapkit_traffic_TrafficLayer.InstanceMethods.InvokeAbstractBooleanMethod("setTrafficStyle.(Ljava/lang/String;)Z", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}
}
