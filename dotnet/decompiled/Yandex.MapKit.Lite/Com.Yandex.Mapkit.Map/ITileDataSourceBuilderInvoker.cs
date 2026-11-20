using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Com.Yandex.Mapkit.Geometry.Geo;
using Com.Yandex.Mapkit.Images;
using Com.Yandex.Mapkit.Layers;
using Com.Yandex.Mapkit.Tiles;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit.Map;

[Register("com/yandex/mapkit/map/TileDataSourceBuilder", DoNotGenerateAcw = true)]
internal class ITileDataSourceBuilderInvoker : Java.Lang.Object, ITileDataSourceBuilder, IBaseDataSourceBuilder, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_com_yandex_mapkit_map_BaseDataSourceBuilder = new XAPeerMembers("com/yandex/mapkit/map/BaseDataSourceBuilder", typeof(ITileDataSourceBuilderInvoker));

	private static readonly JniPeerMembers _members_com_yandex_mapkit_map_TileDataSourceBuilder = new XAPeerMembers("com/yandex/mapkit/map/TileDataSourceBuilder", typeof(ITileDataSourceBuilderInvoker));

	private static Delegate? cb_setProjection_SetProjection_Lcom_yandex_mapkit_geometry_geo_Projection__V;

	private static Delegate? cb_setTileFormat_SetTileFormat_Lcom_yandex_mapkit_layers_TileFormat__V;

	private static Delegate? cb_setTileProvider_SetTileProvider_Lcom_yandex_mapkit_tiles_TileProvider__V;

	private static Delegate? cb_setTileUrlProvider_SetTileUrlProvider_Lcom_yandex_mapkit_tiles_UrlProvider__V;

	private static Delegate? cb_setZoomRanges_SetZoomRanges_Ljava_util_List__V;

	private static Delegate? cb_isValid_IsValid_Z;

	private static Delegate? cb_setImageUrlProvider_SetImageUrlProvider_Lcom_yandex_mapkit_images_ImageUrlProvider__V;

	private static nint java_class_ref => _members_com_yandex_mapkit_map_TileDataSourceBuilder.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_com_yandex_mapkit_map_TileDataSourceBuilder;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_com_yandex_mapkit_map_TileDataSourceBuilder.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_com_yandex_mapkit_map_TileDataSourceBuilder.ManagedPeerType;

	public unsafe bool IsValid => _members_com_yandex_mapkit_map_BaseDataSourceBuilder.InstanceMethods.InvokeAbstractBooleanMethod("isValid.()Z", this, null);

	public ITileDataSourceBuilderInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetSetProjection_Lcom_yandex_mapkit_geometry_geo_Projection_Handler()
	{
		if ((object)cb_setProjection_SetProjection_Lcom_yandex_mapkit_geometry_geo_Projection__V == null)
		{
			cb_setProjection_SetProjection_Lcom_yandex_mapkit_geometry_geo_Projection__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetProjection_Lcom_yandex_mapkit_geometry_geo_Projection_));
		}
		return cb_setProjection_SetProjection_Lcom_yandex_mapkit_geometry_geo_Projection__V;
	}

	private static void n_SetProjection_Lcom_yandex_mapkit_geometry_geo_Projection_(nint jnienv, nint native__this, nint native_p0)
	{
		ITileDataSourceBuilder? tileDataSourceBuilder = Java.Lang.Object.GetObject<ITileDataSourceBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IProjection projection = Java.Lang.Object.GetObject<IProjection>(native_p0, JniHandleOwnership.DoNotTransfer);
		tileDataSourceBuilder.SetProjection(projection);
	}

	public unsafe void SetProjection(IProjection p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			_members_com_yandex_mapkit_map_TileDataSourceBuilder.InstanceMethods.InvokeAbstractVoidMethod("setProjection.(Lcom/yandex/mapkit/geometry/geo/Projection;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetSetTileFormat_Lcom_yandex_mapkit_layers_TileFormat_Handler()
	{
		if ((object)cb_setTileFormat_SetTileFormat_Lcom_yandex_mapkit_layers_TileFormat__V == null)
		{
			cb_setTileFormat_SetTileFormat_Lcom_yandex_mapkit_layers_TileFormat__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetTileFormat_Lcom_yandex_mapkit_layers_TileFormat_));
		}
		return cb_setTileFormat_SetTileFormat_Lcom_yandex_mapkit_layers_TileFormat__V;
	}

	private static void n_SetTileFormat_Lcom_yandex_mapkit_layers_TileFormat_(nint jnienv, nint native__this, nint native_p0)
	{
		ITileDataSourceBuilder? tileDataSourceBuilder = Java.Lang.Object.GetObject<ITileDataSourceBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		TileFormat tileFormat = Java.Lang.Object.GetObject<TileFormat>(native_p0, JniHandleOwnership.DoNotTransfer);
		tileDataSourceBuilder.SetTileFormat(tileFormat);
	}

	public unsafe void SetTileFormat(TileFormat p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			_members_com_yandex_mapkit_map_TileDataSourceBuilder.InstanceMethods.InvokeAbstractVoidMethod("setTileFormat.(Lcom/yandex/mapkit/layers/TileFormat;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetSetTileProvider_Lcom_yandex_mapkit_tiles_TileProvider_Handler()
	{
		if ((object)cb_setTileProvider_SetTileProvider_Lcom_yandex_mapkit_tiles_TileProvider__V == null)
		{
			cb_setTileProvider_SetTileProvider_Lcom_yandex_mapkit_tiles_TileProvider__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetTileProvider_Lcom_yandex_mapkit_tiles_TileProvider_));
		}
		return cb_setTileProvider_SetTileProvider_Lcom_yandex_mapkit_tiles_TileProvider__V;
	}

	private static void n_SetTileProvider_Lcom_yandex_mapkit_tiles_TileProvider_(nint jnienv, nint native__this, nint native_p0)
	{
		ITileDataSourceBuilder? tileDataSourceBuilder = Java.Lang.Object.GetObject<ITileDataSourceBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ITileProvider tileProvider = Java.Lang.Object.GetObject<ITileProvider>(native_p0, JniHandleOwnership.DoNotTransfer);
		tileDataSourceBuilder.SetTileProvider(tileProvider);
	}

	public unsafe void SetTileProvider(ITileProvider p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			_members_com_yandex_mapkit_map_TileDataSourceBuilder.InstanceMethods.InvokeAbstractVoidMethod("setTileProvider.(Lcom/yandex/mapkit/tiles/TileProvider;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetSetTileUrlProvider_Lcom_yandex_mapkit_tiles_UrlProvider_Handler()
	{
		if ((object)cb_setTileUrlProvider_SetTileUrlProvider_Lcom_yandex_mapkit_tiles_UrlProvider__V == null)
		{
			cb_setTileUrlProvider_SetTileUrlProvider_Lcom_yandex_mapkit_tiles_UrlProvider__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetTileUrlProvider_Lcom_yandex_mapkit_tiles_UrlProvider_));
		}
		return cb_setTileUrlProvider_SetTileUrlProvider_Lcom_yandex_mapkit_tiles_UrlProvider__V;
	}

	private static void n_SetTileUrlProvider_Lcom_yandex_mapkit_tiles_UrlProvider_(nint jnienv, nint native__this, nint native_p0)
	{
		ITileDataSourceBuilder? tileDataSourceBuilder = Java.Lang.Object.GetObject<ITileDataSourceBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IUrlProvider tileUrlProvider = Java.Lang.Object.GetObject<IUrlProvider>(native_p0, JniHandleOwnership.DoNotTransfer);
		tileDataSourceBuilder.SetTileUrlProvider(tileUrlProvider);
	}

	public unsafe void SetTileUrlProvider(IUrlProvider p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			_members_com_yandex_mapkit_map_TileDataSourceBuilder.InstanceMethods.InvokeAbstractVoidMethod("setTileUrlProvider.(Lcom/yandex/mapkit/tiles/UrlProvider;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetSetZoomRanges_Ljava_util_List_Handler()
	{
		if ((object)cb_setZoomRanges_SetZoomRanges_Ljava_util_List__V == null)
		{
			cb_setZoomRanges_SetZoomRanges_Ljava_util_List__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetZoomRanges_Ljava_util_List_));
		}
		return cb_setZoomRanges_SetZoomRanges_Ljava_util_List__V;
	}

	private static void n_SetZoomRanges_Ljava_util_List_(nint jnienv, nint native__this, nint native_p0)
	{
		ITileDataSourceBuilder? tileDataSourceBuilder = Java.Lang.Object.GetObject<ITileDataSourceBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IList<ZoomRange> zoomRanges = JavaList<ZoomRange>.FromJniHandle(native_p0, JniHandleOwnership.DoNotTransfer);
		tileDataSourceBuilder.SetZoomRanges(zoomRanges);
	}

	public unsafe void SetZoomRanges(IList<ZoomRange> p0)
	{
		nint num = JavaList<ZoomRange>.ToLocalJniHandle(p0);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members_com_yandex_mapkit_map_TileDataSourceBuilder.InstanceMethods.InvokeAbstractVoidMethod("setZoomRanges.(Ljava/util/List;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(p0);
		}
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
		return Java.Lang.Object.GetObject<ITileDataSourceBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsValid;
	}

	private static Delegate GetSetImageUrlProvider_Lcom_yandex_mapkit_images_ImageUrlProvider_Handler()
	{
		if ((object)cb_setImageUrlProvider_SetImageUrlProvider_Lcom_yandex_mapkit_images_ImageUrlProvider__V == null)
		{
			cb_setImageUrlProvider_SetImageUrlProvider_Lcom_yandex_mapkit_images_ImageUrlProvider__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetImageUrlProvider_Lcom_yandex_mapkit_images_ImageUrlProvider_));
		}
		return cb_setImageUrlProvider_SetImageUrlProvider_Lcom_yandex_mapkit_images_ImageUrlProvider__V;
	}

	private static void n_SetImageUrlProvider_Lcom_yandex_mapkit_images_ImageUrlProvider_(nint jnienv, nint native__this, nint native_p0)
	{
		ITileDataSourceBuilder? tileDataSourceBuilder = Java.Lang.Object.GetObject<ITileDataSourceBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IImageUrlProvider imageUrlProvider = Java.Lang.Object.GetObject<IImageUrlProvider>(native_p0, JniHandleOwnership.DoNotTransfer);
		tileDataSourceBuilder.SetImageUrlProvider(imageUrlProvider);
	}

	public unsafe void SetImageUrlProvider(IImageUrlProvider p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			_members_com_yandex_mapkit_map_BaseDataSourceBuilder.InstanceMethods.InvokeAbstractVoidMethod("setImageUrlProvider.(Lcom/yandex/mapkit/images/ImageUrlProvider;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}
}
