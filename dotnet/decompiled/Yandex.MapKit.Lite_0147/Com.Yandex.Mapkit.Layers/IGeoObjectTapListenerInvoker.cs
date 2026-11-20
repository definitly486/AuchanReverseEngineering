using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit.Layers;

[Register("com/yandex/mapkit/layers/GeoObjectTapListener", DoNotGenerateAcw = true)]
internal class IGeoObjectTapListenerInvoker : Java.Lang.Object, IGeoObjectTapListener, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_com_yandex_mapkit_layers_GeoObjectTapListener = new XAPeerMembers("com/yandex/mapkit/layers/GeoObjectTapListener", typeof(IGeoObjectTapListenerInvoker));

	private static Delegate? cb_onObjectTap_OnObjectTap_Lcom_yandex_mapkit_layers_GeoObjectTapEvent__Z;

	private static nint java_class_ref => _members_com_yandex_mapkit_layers_GeoObjectTapListener.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_com_yandex_mapkit_layers_GeoObjectTapListener;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_com_yandex_mapkit_layers_GeoObjectTapListener.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_com_yandex_mapkit_layers_GeoObjectTapListener.ManagedPeerType;

	public IGeoObjectTapListenerInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetOnObjectTap_Lcom_yandex_mapkit_layers_GeoObjectTapEvent_Handler()
	{
		if ((object)cb_onObjectTap_OnObjectTap_Lcom_yandex_mapkit_layers_GeoObjectTapEvent__Z == null)
		{
			cb_onObjectTap_OnObjectTap_Lcom_yandex_mapkit_layers_GeoObjectTapEvent__Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_OnObjectTap_Lcom_yandex_mapkit_layers_GeoObjectTapEvent_));
		}
		return cb_onObjectTap_OnObjectTap_Lcom_yandex_mapkit_layers_GeoObjectTapEvent__Z;
	}

	private static bool n_OnObjectTap_Lcom_yandex_mapkit_layers_GeoObjectTapEvent_(nint jnienv, nint native__this, nint native_p0)
	{
		IGeoObjectTapListener? geoObjectTapListener = Java.Lang.Object.GetObject<IGeoObjectTapListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IGeoObjectTapEvent p = Java.Lang.Object.GetObject<IGeoObjectTapEvent>(native_p0, JniHandleOwnership.DoNotTransfer);
		return geoObjectTapListener.OnObjectTap(p);
	}

	public unsafe bool OnObjectTap(IGeoObjectTapEvent p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			return _members_com_yandex_mapkit_layers_GeoObjectTapListener.InstanceMethods.InvokeAbstractBooleanMethod("onObjectTap.(Lcom/yandex/mapkit/layers/GeoObjectTapEvent;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}
}
