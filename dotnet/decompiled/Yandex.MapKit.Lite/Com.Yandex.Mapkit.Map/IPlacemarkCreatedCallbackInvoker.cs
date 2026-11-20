using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit.Map;

[Register("com/yandex/mapkit/map/PlacemarkCreatedCallback", DoNotGenerateAcw = true)]
internal class IPlacemarkCreatedCallbackInvoker : Java.Lang.Object, IPlacemarkCreatedCallback, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_com_yandex_mapkit_map_PlacemarkCreatedCallback = new XAPeerMembers("com/yandex/mapkit/map/PlacemarkCreatedCallback", typeof(IPlacemarkCreatedCallbackInvoker));

	private static Delegate? cb_onPlacemarkCreated_OnPlacemarkCreated_Lcom_yandex_mapkit_map_PlacemarkMapObject__V;

	private static nint java_class_ref => _members_com_yandex_mapkit_map_PlacemarkCreatedCallback.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_com_yandex_mapkit_map_PlacemarkCreatedCallback;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_com_yandex_mapkit_map_PlacemarkCreatedCallback.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_com_yandex_mapkit_map_PlacemarkCreatedCallback.ManagedPeerType;

	public IPlacemarkCreatedCallbackInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetOnPlacemarkCreated_Lcom_yandex_mapkit_map_PlacemarkMapObject_Handler()
	{
		if ((object)cb_onPlacemarkCreated_OnPlacemarkCreated_Lcom_yandex_mapkit_map_PlacemarkMapObject__V == null)
		{
			cb_onPlacemarkCreated_OnPlacemarkCreated_Lcom_yandex_mapkit_map_PlacemarkMapObject__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnPlacemarkCreated_Lcom_yandex_mapkit_map_PlacemarkMapObject_));
		}
		return cb_onPlacemarkCreated_OnPlacemarkCreated_Lcom_yandex_mapkit_map_PlacemarkMapObject__V;
	}

	private static void n_OnPlacemarkCreated_Lcom_yandex_mapkit_map_PlacemarkMapObject_(nint jnienv, nint native__this, nint native_p0)
	{
		IPlacemarkCreatedCallback? placemarkCreatedCallback = Java.Lang.Object.GetObject<IPlacemarkCreatedCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IPlacemarkMapObject p = Java.Lang.Object.GetObject<IPlacemarkMapObject>(native_p0, JniHandleOwnership.DoNotTransfer);
		placemarkCreatedCallback.OnPlacemarkCreated(p);
	}

	public unsafe void OnPlacemarkCreated(IPlacemarkMapObject p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			_members_com_yandex_mapkit_map_PlacemarkCreatedCallback.InstanceMethods.InvokeAbstractVoidMethod("onPlacemarkCreated.(Lcom/yandex/mapkit/map/PlacemarkMapObject;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}
}
