using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit.Map;

[Register("com/yandex/mapkit/map/CreateTileDataSource", DoNotGenerateAcw = true)]
internal class ICreateTileDataSourceInvoker : Java.Lang.Object, ICreateTileDataSource, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_com_yandex_mapkit_map_CreateTileDataSource = new XAPeerMembers("com/yandex/mapkit/map/CreateTileDataSource", typeof(ICreateTileDataSourceInvoker));

	private static Delegate? cb_createTileDataSource_CreateTileDataSource_Lcom_yandex_mapkit_map_TileDataSourceBuilder__V;

	private static nint java_class_ref => _members_com_yandex_mapkit_map_CreateTileDataSource.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_com_yandex_mapkit_map_CreateTileDataSource;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_com_yandex_mapkit_map_CreateTileDataSource.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_com_yandex_mapkit_map_CreateTileDataSource.ManagedPeerType;

	public ICreateTileDataSourceInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetCreateTileDataSource_Lcom_yandex_mapkit_map_TileDataSourceBuilder_Handler()
	{
		if ((object)cb_createTileDataSource_CreateTileDataSource_Lcom_yandex_mapkit_map_TileDataSourceBuilder__V == null)
		{
			cb_createTileDataSource_CreateTileDataSource_Lcom_yandex_mapkit_map_TileDataSourceBuilder__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_CreateTileDataSource_Lcom_yandex_mapkit_map_TileDataSourceBuilder_));
		}
		return cb_createTileDataSource_CreateTileDataSource_Lcom_yandex_mapkit_map_TileDataSourceBuilder__V;
	}

	private static void n_CreateTileDataSource_Lcom_yandex_mapkit_map_TileDataSourceBuilder_(nint jnienv, nint native__this, nint native_p0)
	{
		ICreateTileDataSource? createTileDataSource = Java.Lang.Object.GetObject<ICreateTileDataSource>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ITileDataSourceBuilder p = Java.Lang.Object.GetObject<ITileDataSourceBuilder>(native_p0, JniHandleOwnership.DoNotTransfer);
		createTileDataSource.CreateTileDataSource(p);
	}

	public unsafe void CreateTileDataSource(ITileDataSourceBuilder p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			_members_com_yandex_mapkit_map_CreateTileDataSource.InstanceMethods.InvokeAbstractVoidMethod("createTileDataSource.(Lcom/yandex/mapkit/map/TileDataSourceBuilder;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}
}
