using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit.Geometry.Geo;

[Register("com/yandex/mapkit/geometry/geo/Projection", DoNotGenerateAcw = true)]
internal class IProjectionInvoker : Java.Lang.Object, IProjection, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_com_yandex_mapkit_geometry_geo_Projection = new XAPeerMembers("com/yandex/mapkit/geometry/geo/Projection", typeof(IProjectionInvoker));

	private static Delegate? cb_isValid_IsValid_Z;

	private static Delegate? cb_worldToXY_WorldToXY_Lcom_yandex_mapkit_geometry_Point_I_Lcom_yandex_mapkit_geometry_geo_XYPoint_;

	private static Delegate? cb_xyToWorld_XyToWorld_Lcom_yandex_mapkit_geometry_geo_XYPoint_I_Lcom_yandex_mapkit_geometry_Point_;

	private static nint java_class_ref => _members_com_yandex_mapkit_geometry_geo_Projection.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_com_yandex_mapkit_geometry_geo_Projection;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_com_yandex_mapkit_geometry_geo_Projection.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_com_yandex_mapkit_geometry_geo_Projection.ManagedPeerType;

	public unsafe bool IsValid => _members_com_yandex_mapkit_geometry_geo_Projection.InstanceMethods.InvokeAbstractBooleanMethod("isValid.()Z", this, null);

	public IProjectionInvoker(nint handle, JniHandleOwnership transfer)
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
		return Java.Lang.Object.GetObject<IProjection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsValid;
	}

	private static Delegate GetWorldToXY_Lcom_yandex_mapkit_geometry_Point_IHandler()
	{
		if ((object)cb_worldToXY_WorldToXY_Lcom_yandex_mapkit_geometry_Point_I_Lcom_yandex_mapkit_geometry_geo_XYPoint_ == null)
		{
			cb_worldToXY_WorldToXY_Lcom_yandex_mapkit_geometry_Point_I_Lcom_yandex_mapkit_geometry_geo_XYPoint_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLI_L(n_WorldToXY_Lcom_yandex_mapkit_geometry_Point_I));
		}
		return cb_worldToXY_WorldToXY_Lcom_yandex_mapkit_geometry_Point_I_Lcom_yandex_mapkit_geometry_geo_XYPoint_;
	}

	private static nint n_WorldToXY_Lcom_yandex_mapkit_geometry_Point_I(nint jnienv, nint native__this, nint native_p0, int p1)
	{
		IProjection? projection = Java.Lang.Object.GetObject<IProjection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Point p2 = Java.Lang.Object.GetObject<Point>(native_p0, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(projection.WorldToXY(p2, p1));
	}

	public unsafe XYPoint WorldToXY(Point p0, int p1)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(p1);
			return Java.Lang.Object.GetObject<XYPoint>(_members_com_yandex_mapkit_geometry_geo_Projection.InstanceMethods.InvokeAbstractObjectMethod("worldToXY.(Lcom/yandex/mapkit/geometry/Point;I)Lcom/yandex/mapkit/geometry/geo/XYPoint;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetXyToWorld_Lcom_yandex_mapkit_geometry_geo_XYPoint_IHandler()
	{
		if ((object)cb_xyToWorld_XyToWorld_Lcom_yandex_mapkit_geometry_geo_XYPoint_I_Lcom_yandex_mapkit_geometry_Point_ == null)
		{
			cb_xyToWorld_XyToWorld_Lcom_yandex_mapkit_geometry_geo_XYPoint_I_Lcom_yandex_mapkit_geometry_Point_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLI_L(n_XyToWorld_Lcom_yandex_mapkit_geometry_geo_XYPoint_I));
		}
		return cb_xyToWorld_XyToWorld_Lcom_yandex_mapkit_geometry_geo_XYPoint_I_Lcom_yandex_mapkit_geometry_Point_;
	}

	private static nint n_XyToWorld_Lcom_yandex_mapkit_geometry_geo_XYPoint_I(nint jnienv, nint native__this, nint native_p0, int p1)
	{
		IProjection? projection = Java.Lang.Object.GetObject<IProjection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		XYPoint p2 = Java.Lang.Object.GetObject<XYPoint>(native_p0, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(projection.XyToWorld(p2, p1));
	}

	public unsafe Point XyToWorld(XYPoint p0, int p1)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(p1);
			return Java.Lang.Object.GetObject<Point>(_members_com_yandex_mapkit_geometry_geo_Projection.InstanceMethods.InvokeAbstractObjectMethod("xyToWorld.(Lcom/yandex/mapkit/geometry/geo/XYPoint;I)Lcom/yandex/mapkit/geometry/Point;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}
}
