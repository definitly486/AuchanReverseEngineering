using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit.Tiles;

[Register("com/yandex/mapkit/tiles/UrlProvider", DoNotGenerateAcw = true)]
internal class IUrlProviderInvoker : Java.Lang.Object, IUrlProvider, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_com_yandex_mapkit_tiles_UrlProvider = new XAPeerMembers("com/yandex/mapkit/tiles/UrlProvider", typeof(IUrlProviderInvoker));

	private static Delegate? cb_formatUrl_FormatUrl_Lcom_yandex_mapkit_TileId_Lcom_yandex_mapkit_Version_Ljava_util_Map__Ljava_lang_String_;

	private static nint java_class_ref => _members_com_yandex_mapkit_tiles_UrlProvider.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_com_yandex_mapkit_tiles_UrlProvider;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_com_yandex_mapkit_tiles_UrlProvider.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_com_yandex_mapkit_tiles_UrlProvider.ManagedPeerType;

	public IUrlProviderInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetFormatUrl_Lcom_yandex_mapkit_TileId_Lcom_yandex_mapkit_Version_Ljava_util_Map_Handler()
	{
		if ((object)cb_formatUrl_FormatUrl_Lcom_yandex_mapkit_TileId_Lcom_yandex_mapkit_Version_Ljava_util_Map__Ljava_lang_String_ == null)
		{
			cb_formatUrl_FormatUrl_Lcom_yandex_mapkit_TileId_Lcom_yandex_mapkit_Version_Ljava_util_Map__Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_L(n_FormatUrl_Lcom_yandex_mapkit_TileId_Lcom_yandex_mapkit_Version_Ljava_util_Map_));
		}
		return cb_formatUrl_FormatUrl_Lcom_yandex_mapkit_TileId_Lcom_yandex_mapkit_Version_Ljava_util_Map__Ljava_lang_String_;
	}

	private static nint n_FormatUrl_Lcom_yandex_mapkit_TileId_Lcom_yandex_mapkit_Version_Ljava_util_Map_(nint jnienv, nint native__this, nint native_p0, nint native_p1, nint native_p2)
	{
		IUrlProvider? urlProvider = Java.Lang.Object.GetObject<IUrlProvider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		TileId p = Java.Lang.Object.GetObject<TileId>(native_p0, JniHandleOwnership.DoNotTransfer);
		Version p2 = Java.Lang.Object.GetObject<Version>(native_p1, JniHandleOwnership.DoNotTransfer);
		IDictionary<string, string> p3 = JavaDictionary<string, string>.FromJniHandle(native_p2, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.NewString(urlProvider.FormatUrl(p, p2, p3));
	}

	public unsafe string FormatUrl(TileId p0, Version p1, IDictionary<string, string> p2)
	{
		nint num = JavaDictionary<string, string>.ToLocalJniHandle(p2);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(num);
			return JNIEnv.GetString(_members_com_yandex_mapkit_tiles_UrlProvider.InstanceMethods.InvokeAbstractObjectMethod("formatUrl.(Lcom/yandex/mapkit/TileId;Lcom/yandex/mapkit/Version;Ljava/util/Map;)Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(p0);
			GC.KeepAlive(p1);
			GC.KeepAlive(p2);
		}
	}
}
