using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Com.Yandex.Mapkit.Layers;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit.User_location;

[Register("com/yandex/mapkit/user_location/UserLocationObjectListener", DoNotGenerateAcw = true)]
internal class IUserLocationObjectListenerInvoker : Java.Lang.Object, IUserLocationObjectListener, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_com_yandex_mapkit_user_location_UserLocationObjectListener = new XAPeerMembers("com/yandex/mapkit/user_location/UserLocationObjectListener", typeof(IUserLocationObjectListenerInvoker));

	private static Delegate? cb_onObjectAdded_OnObjectAdded_Lcom_yandex_mapkit_user_location_UserLocationView__V;

	private static Delegate? cb_onObjectRemoved_OnObjectRemoved_Lcom_yandex_mapkit_user_location_UserLocationView__V;

	private static Delegate? cb_onObjectUpdated_OnObjectUpdated_Lcom_yandex_mapkit_user_location_UserLocationView_Lcom_yandex_mapkit_layers_ObjectEvent__V;

	private static nint java_class_ref => _members_com_yandex_mapkit_user_location_UserLocationObjectListener.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_com_yandex_mapkit_user_location_UserLocationObjectListener;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_com_yandex_mapkit_user_location_UserLocationObjectListener.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_com_yandex_mapkit_user_location_UserLocationObjectListener.ManagedPeerType;

	public IUserLocationObjectListenerInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetOnObjectAdded_Lcom_yandex_mapkit_user_location_UserLocationView_Handler()
	{
		if ((object)cb_onObjectAdded_OnObjectAdded_Lcom_yandex_mapkit_user_location_UserLocationView__V == null)
		{
			cb_onObjectAdded_OnObjectAdded_Lcom_yandex_mapkit_user_location_UserLocationView__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnObjectAdded_Lcom_yandex_mapkit_user_location_UserLocationView_));
		}
		return cb_onObjectAdded_OnObjectAdded_Lcom_yandex_mapkit_user_location_UserLocationView__V;
	}

	private static void n_OnObjectAdded_Lcom_yandex_mapkit_user_location_UserLocationView_(nint jnienv, nint native__this, nint native_p0)
	{
		IUserLocationObjectListener? userLocationObjectListener = Java.Lang.Object.GetObject<IUserLocationObjectListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IUserLocationView p = Java.Lang.Object.GetObject<IUserLocationView>(native_p0, JniHandleOwnership.DoNotTransfer);
		userLocationObjectListener.OnObjectAdded(p);
	}

	public unsafe void OnObjectAdded(IUserLocationView p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			_members_com_yandex_mapkit_user_location_UserLocationObjectListener.InstanceMethods.InvokeAbstractVoidMethod("onObjectAdded.(Lcom/yandex/mapkit/user_location/UserLocationView;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetOnObjectRemoved_Lcom_yandex_mapkit_user_location_UserLocationView_Handler()
	{
		if ((object)cb_onObjectRemoved_OnObjectRemoved_Lcom_yandex_mapkit_user_location_UserLocationView__V == null)
		{
			cb_onObjectRemoved_OnObjectRemoved_Lcom_yandex_mapkit_user_location_UserLocationView__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnObjectRemoved_Lcom_yandex_mapkit_user_location_UserLocationView_));
		}
		return cb_onObjectRemoved_OnObjectRemoved_Lcom_yandex_mapkit_user_location_UserLocationView__V;
	}

	private static void n_OnObjectRemoved_Lcom_yandex_mapkit_user_location_UserLocationView_(nint jnienv, nint native__this, nint native_p0)
	{
		IUserLocationObjectListener? userLocationObjectListener = Java.Lang.Object.GetObject<IUserLocationObjectListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IUserLocationView p = Java.Lang.Object.GetObject<IUserLocationView>(native_p0, JniHandleOwnership.DoNotTransfer);
		userLocationObjectListener.OnObjectRemoved(p);
	}

	public unsafe void OnObjectRemoved(IUserLocationView p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			_members_com_yandex_mapkit_user_location_UserLocationObjectListener.InstanceMethods.InvokeAbstractVoidMethod("onObjectRemoved.(Lcom/yandex/mapkit/user_location/UserLocationView;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetOnObjectUpdated_Lcom_yandex_mapkit_user_location_UserLocationView_Lcom_yandex_mapkit_layers_ObjectEvent_Handler()
	{
		if ((object)cb_onObjectUpdated_OnObjectUpdated_Lcom_yandex_mapkit_user_location_UserLocationView_Lcom_yandex_mapkit_layers_ObjectEvent__V == null)
		{
			cb_onObjectUpdated_OnObjectUpdated_Lcom_yandex_mapkit_user_location_UserLocationView_Lcom_yandex_mapkit_layers_ObjectEvent__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_OnObjectUpdated_Lcom_yandex_mapkit_user_location_UserLocationView_Lcom_yandex_mapkit_layers_ObjectEvent_));
		}
		return cb_onObjectUpdated_OnObjectUpdated_Lcom_yandex_mapkit_user_location_UserLocationView_Lcom_yandex_mapkit_layers_ObjectEvent__V;
	}

	private static void n_OnObjectUpdated_Lcom_yandex_mapkit_user_location_UserLocationView_Lcom_yandex_mapkit_layers_ObjectEvent_(nint jnienv, nint native__this, nint native_p0, nint native_p1)
	{
		IUserLocationObjectListener? userLocationObjectListener = Java.Lang.Object.GetObject<IUserLocationObjectListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IUserLocationView p = Java.Lang.Object.GetObject<IUserLocationView>(native_p0, JniHandleOwnership.DoNotTransfer);
		IObjectEvent p2 = Java.Lang.Object.GetObject<IObjectEvent>(native_p1, JniHandleOwnership.DoNotTransfer);
		userLocationObjectListener.OnObjectUpdated(p, p2);
	}

	public unsafe void OnObjectUpdated(IUserLocationView p0, IObjectEvent p1)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			ptr[1] = new JniArgumentValue((p1 == null) ? IntPtr.Zero : ((Java.Lang.Object)p1).Handle);
			_members_com_yandex_mapkit_user_location_UserLocationObjectListener.InstanceMethods.InvokeAbstractVoidMethod("onObjectUpdated.(Lcom/yandex/mapkit/user_location/UserLocationView;Lcom/yandex/mapkit/layers/ObjectEvent;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
			GC.KeepAlive(p1);
		}
	}
}
