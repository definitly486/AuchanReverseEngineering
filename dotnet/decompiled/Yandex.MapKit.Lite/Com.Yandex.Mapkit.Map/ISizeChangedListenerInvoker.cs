using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit.Map;

[Register("com/yandex/mapkit/map/SizeChangedListener", DoNotGenerateAcw = true)]
internal class ISizeChangedListenerInvoker : Java.Lang.Object, ISizeChangedListener, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_com_yandex_mapkit_map_SizeChangedListener = new XAPeerMembers("com/yandex/mapkit/map/SizeChangedListener", typeof(ISizeChangedListenerInvoker));

	private static Delegate? cb_onMapWindowSizeChanged_OnMapWindowSizeChanged_Lcom_yandex_mapkit_map_MapWindow_II_V;

	private static nint java_class_ref => _members_com_yandex_mapkit_map_SizeChangedListener.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_com_yandex_mapkit_map_SizeChangedListener;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_com_yandex_mapkit_map_SizeChangedListener.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_com_yandex_mapkit_map_SizeChangedListener.ManagedPeerType;

	public ISizeChangedListenerInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetOnMapWindowSizeChanged_Lcom_yandex_mapkit_map_MapWindow_IIHandler()
	{
		if ((object)cb_onMapWindowSizeChanged_OnMapWindowSizeChanged_Lcom_yandex_mapkit_map_MapWindow_II_V == null)
		{
			cb_onMapWindowSizeChanged_OnMapWindowSizeChanged_Lcom_yandex_mapkit_map_MapWindow_II_V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLII_V(n_OnMapWindowSizeChanged_Lcom_yandex_mapkit_map_MapWindow_II));
		}
		return cb_onMapWindowSizeChanged_OnMapWindowSizeChanged_Lcom_yandex_mapkit_map_MapWindow_II_V;
	}

	private static void n_OnMapWindowSizeChanged_Lcom_yandex_mapkit_map_MapWindow_II(nint jnienv, nint native__this, nint native_p0, int p1, int p2)
	{
		ISizeChangedListener? sizeChangedListener = Java.Lang.Object.GetObject<ISizeChangedListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IMapWindow p3 = Java.Lang.Object.GetObject<IMapWindow>(native_p0, JniHandleOwnership.DoNotTransfer);
		sizeChangedListener.OnMapWindowSizeChanged(p3, p1, p2);
	}

	public unsafe void OnMapWindowSizeChanged(IMapWindow p0, int p1, int p2)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			ptr[1] = new JniArgumentValue(p1);
			ptr[2] = new JniArgumentValue(p2);
			_members_com_yandex_mapkit_map_SizeChangedListener.InstanceMethods.InvokeAbstractVoidMethod("onMapWindowSizeChanged.(Lcom/yandex/mapkit/map/MapWindow;II)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}
}
