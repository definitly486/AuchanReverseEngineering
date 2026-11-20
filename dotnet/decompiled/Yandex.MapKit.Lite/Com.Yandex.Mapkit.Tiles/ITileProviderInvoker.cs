using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit.Tiles;

[Register("com/yandex/mapkit/tiles/TileProvider", DoNotGenerateAcw = true)]
internal class ITileProviderInvoker : Java.Lang.Object, ITileProvider, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_com_yandex_mapkit_tiles_TileProvider = new XAPeerMembers("com/yandex/mapkit/tiles/TileProvider", typeof(ITileProviderInvoker));

	private static Delegate? cb_load_Load_Lcom_yandex_mapkit_TileId_Lcom_yandex_mapkit_Version_Ljava_util_Map_Ljava_lang_String__Lcom_yandex_mapkit_RawTile_;

	private static nint java_class_ref => _members_com_yandex_mapkit_tiles_TileProvider.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_com_yandex_mapkit_tiles_TileProvider;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_com_yandex_mapkit_tiles_TileProvider.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_com_yandex_mapkit_tiles_TileProvider.ManagedPeerType;

	public ITileProviderInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetLoad_Lcom_yandex_mapkit_TileId_Lcom_yandex_mapkit_Version_Ljava_util_Map_Ljava_lang_String_Handler()
	{
		if ((object)cb_load_Load_Lcom_yandex_mapkit_TileId_Lcom_yandex_mapkit_Version_Ljava_util_Map_Ljava_lang_String__Lcom_yandex_mapkit_RawTile_ == null)
		{
			cb_load_Load_Lcom_yandex_mapkit_TileId_Lcom_yandex_mapkit_Version_Ljava_util_Map_Ljava_lang_String__Lcom_yandex_mapkit_RawTile_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLLL_L(n_Load_Lcom_yandex_mapkit_TileId_Lcom_yandex_mapkit_Version_Ljava_util_Map_Ljava_lang_String_));
		}
		return cb_load_Load_Lcom_yandex_mapkit_TileId_Lcom_yandex_mapkit_Version_Ljava_util_Map_Ljava_lang_String__Lcom_yandex_mapkit_RawTile_;
	}

	private static nint n_Load_Lcom_yandex_mapkit_TileId_Lcom_yandex_mapkit_Version_Ljava_util_Map_Ljava_lang_String_(nint jnienv, nint native__this, nint native_p0, nint native_p1, nint native_p2, nint native_p3)
	{
		ITileProvider? tileProvider = Java.Lang.Object.GetObject<ITileProvider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		TileId p = Java.Lang.Object.GetObject<TileId>(native_p0, JniHandleOwnership.DoNotTransfer);
		Version p2 = Java.Lang.Object.GetObject<Version>(native_p1, JniHandleOwnership.DoNotTransfer);
		IDictionary<string, string> p3 = JavaDictionary<string, string>.FromJniHandle(native_p2, JniHandleOwnership.DoNotTransfer);
		string p4 = JNIEnv.GetString(native_p3, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(tileProvider.Load(p, p2, p3, p4));
	}

	public unsafe RawTile Load(TileId p0, Version p1, IDictionary<string, string> p2, string p3)
	{
		nint num = JavaDictionary<string, string>.ToLocalJniHandle(p2);
		nint num2 = JNIEnv.NewString(p3);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(num);
			ptr[3] = new JniArgumentValue(num2);
			return Java.Lang.Object.GetObject<RawTile>(_members_com_yandex_mapkit_tiles_TileProvider.InstanceMethods.InvokeAbstractObjectMethod("load.(Lcom/yandex/mapkit/TileId;Lcom/yandex/mapkit/Version;Ljava/util/Map;Ljava/lang/String;)Lcom/yandex/mapkit/RawTile;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			JNIEnv.DeleteLocalRef(num2);
			GC.KeepAlive(p0);
			GC.KeepAlive(p1);
			GC.KeepAlive(p2);
		}
	}
}
