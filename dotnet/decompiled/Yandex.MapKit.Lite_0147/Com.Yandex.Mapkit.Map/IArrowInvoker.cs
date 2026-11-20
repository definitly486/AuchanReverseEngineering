using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Com.Yandex.Mapkit.Geometry;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit.Map;

[Register("com/yandex/mapkit/map/Arrow", DoNotGenerateAcw = true)]
internal class IArrowInvoker : Java.Lang.Object, IArrow, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_com_yandex_mapkit_map_Arrow = new XAPeerMembers("com/yandex/mapkit/map/Arrow", typeof(IArrowInvoker));

	private static Delegate? cb_getFillColor_GetFillColor_I;

	private static Delegate? cb_setFillColor_SetFillColor_I_V;

	private static Delegate? cb_isValid_IsValid_Z;

	private static Delegate? cb_getLength_GetLength_F;

	private static Delegate? cb_setLength_SetLength_F_V;

	private static Delegate? cb_getOutlineColor_GetOutlineColor_I;

	private static Delegate? cb_setOutlineColor_SetOutlineColor_I_V;

	private static Delegate? cb_getOutlineWidth_GetOutlineWidth_F;

	private static Delegate? cb_setOutlineWidth_SetOutlineWidth_F_V;

	private static Delegate? cb_getPosition_GetPosition_Lcom_yandex_mapkit_geometry_PolylinePosition_;

	private static Delegate? cb_getTriangleHeight_GetTriangleHeight_F;

	private static Delegate? cb_setTriangleHeight_SetTriangleHeight_F_V;

	private static Delegate? cb_isVisible_IsVisible_Z;

	private static Delegate? cb_setVisible_SetVisible_Z_V;

	private static nint java_class_ref => _members_com_yandex_mapkit_map_Arrow.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_com_yandex_mapkit_map_Arrow;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_com_yandex_mapkit_map_Arrow.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_com_yandex_mapkit_map_Arrow.ManagedPeerType;

	public unsafe int FillColor
	{
		get
		{
			return _members_com_yandex_mapkit_map_Arrow.InstanceMethods.InvokeAbstractInt32Method("getFillColor.()I", this, null);
		}
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members_com_yandex_mapkit_map_Arrow.InstanceMethods.InvokeAbstractVoidMethod("setFillColor.(I)V", this, ptr);
		}
	}

	public unsafe bool IsValid => _members_com_yandex_mapkit_map_Arrow.InstanceMethods.InvokeAbstractBooleanMethod("isValid.()Z", this, null);

	public unsafe float Length
	{
		get
		{
			return _members_com_yandex_mapkit_map_Arrow.InstanceMethods.InvokeAbstractSingleMethod("getLength.()F", this, null);
		}
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members_com_yandex_mapkit_map_Arrow.InstanceMethods.InvokeAbstractVoidMethod("setLength.(F)V", this, ptr);
		}
	}

	public unsafe int OutlineColor
	{
		get
		{
			return _members_com_yandex_mapkit_map_Arrow.InstanceMethods.InvokeAbstractInt32Method("getOutlineColor.()I", this, null);
		}
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members_com_yandex_mapkit_map_Arrow.InstanceMethods.InvokeAbstractVoidMethod("setOutlineColor.(I)V", this, ptr);
		}
	}

	public unsafe float OutlineWidth
	{
		get
		{
			return _members_com_yandex_mapkit_map_Arrow.InstanceMethods.InvokeAbstractSingleMethod("getOutlineWidth.()F", this, null);
		}
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members_com_yandex_mapkit_map_Arrow.InstanceMethods.InvokeAbstractVoidMethod("setOutlineWidth.(F)V", this, ptr);
		}
	}

	public unsafe PolylinePosition Position => Java.Lang.Object.GetObject<PolylinePosition>(_members_com_yandex_mapkit_map_Arrow.InstanceMethods.InvokeAbstractObjectMethod("getPosition.()Lcom/yandex/mapkit/geometry/PolylinePosition;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public unsafe float TriangleHeight
	{
		get
		{
			return _members_com_yandex_mapkit_map_Arrow.InstanceMethods.InvokeAbstractSingleMethod("getTriangleHeight.()F", this, null);
		}
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members_com_yandex_mapkit_map_Arrow.InstanceMethods.InvokeAbstractVoidMethod("setTriangleHeight.(F)V", this, ptr);
		}
	}

	public unsafe bool Visible
	{
		get
		{
			return _members_com_yandex_mapkit_map_Arrow.InstanceMethods.InvokeAbstractBooleanMethod("isVisible.()Z", this, null);
		}
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members_com_yandex_mapkit_map_Arrow.InstanceMethods.InvokeAbstractVoidMethod("setVisible.(Z)V", this, ptr);
		}
	}

	public IArrowInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetGetFillColorHandler()
	{
		if ((object)cb_getFillColor_GetFillColor_I == null)
		{
			cb_getFillColor_GetFillColor_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetFillColor));
		}
		return cb_getFillColor_GetFillColor_I;
	}

	private static int n_GetFillColor(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<IArrow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FillColor;
	}

	private static Delegate GetSetFillColor_IHandler()
	{
		if ((object)cb_setFillColor_SetFillColor_I_V == null)
		{
			cb_setFillColor_SetFillColor_I_V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_SetFillColor_I));
		}
		return cb_setFillColor_SetFillColor_I_V;
	}

	private static void n_SetFillColor_I(nint jnienv, nint native__this, int p0)
	{
		Java.Lang.Object.GetObject<IArrow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FillColor = p0;
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
		return Java.Lang.Object.GetObject<IArrow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsValid;
	}

	private static Delegate GetGetLengthHandler()
	{
		if ((object)cb_getLength_GetLength_F == null)
		{
			cb_getLength_GetLength_F = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_F(n_GetLength));
		}
		return cb_getLength_GetLength_F;
	}

	private static float n_GetLength(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<IArrow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Length;
	}

	private static Delegate GetSetLength_FHandler()
	{
		if ((object)cb_setLength_SetLength_F_V == null)
		{
			cb_setLength_SetLength_F_V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPF_V(n_SetLength_F));
		}
		return cb_setLength_SetLength_F_V;
	}

	private static void n_SetLength_F(nint jnienv, nint native__this, float p0)
	{
		Java.Lang.Object.GetObject<IArrow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Length = p0;
	}

	private static Delegate GetGetOutlineColorHandler()
	{
		if ((object)cb_getOutlineColor_GetOutlineColor_I == null)
		{
			cb_getOutlineColor_GetOutlineColor_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetOutlineColor));
		}
		return cb_getOutlineColor_GetOutlineColor_I;
	}

	private static int n_GetOutlineColor(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<IArrow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OutlineColor;
	}

	private static Delegate GetSetOutlineColor_IHandler()
	{
		if ((object)cb_setOutlineColor_SetOutlineColor_I_V == null)
		{
			cb_setOutlineColor_SetOutlineColor_I_V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_SetOutlineColor_I));
		}
		return cb_setOutlineColor_SetOutlineColor_I_V;
	}

	private static void n_SetOutlineColor_I(nint jnienv, nint native__this, int p0)
	{
		Java.Lang.Object.GetObject<IArrow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OutlineColor = p0;
	}

	private static Delegate GetGetOutlineWidthHandler()
	{
		if ((object)cb_getOutlineWidth_GetOutlineWidth_F == null)
		{
			cb_getOutlineWidth_GetOutlineWidth_F = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_F(n_GetOutlineWidth));
		}
		return cb_getOutlineWidth_GetOutlineWidth_F;
	}

	private static float n_GetOutlineWidth(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<IArrow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OutlineWidth;
	}

	private static Delegate GetSetOutlineWidth_FHandler()
	{
		if ((object)cb_setOutlineWidth_SetOutlineWidth_F_V == null)
		{
			cb_setOutlineWidth_SetOutlineWidth_F_V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPF_V(n_SetOutlineWidth_F));
		}
		return cb_setOutlineWidth_SetOutlineWidth_F_V;
	}

	private static void n_SetOutlineWidth_F(nint jnienv, nint native__this, float p0)
	{
		Java.Lang.Object.GetObject<IArrow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OutlineWidth = p0;
	}

	private static Delegate GetGetPositionHandler()
	{
		if ((object)cb_getPosition_GetPosition_Lcom_yandex_mapkit_geometry_PolylinePosition_ == null)
		{
			cb_getPosition_GetPosition_Lcom_yandex_mapkit_geometry_PolylinePosition_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetPosition));
		}
		return cb_getPosition_GetPosition_Lcom_yandex_mapkit_geometry_PolylinePosition_;
	}

	private static nint n_GetPosition(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IArrow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Position);
	}

	private static Delegate GetGetTriangleHeightHandler()
	{
		if ((object)cb_getTriangleHeight_GetTriangleHeight_F == null)
		{
			cb_getTriangleHeight_GetTriangleHeight_F = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_F(n_GetTriangleHeight));
		}
		return cb_getTriangleHeight_GetTriangleHeight_F;
	}

	private static float n_GetTriangleHeight(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<IArrow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TriangleHeight;
	}

	private static Delegate GetSetTriangleHeight_FHandler()
	{
		if ((object)cb_setTriangleHeight_SetTriangleHeight_F_V == null)
		{
			cb_setTriangleHeight_SetTriangleHeight_F_V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPF_V(n_SetTriangleHeight_F));
		}
		return cb_setTriangleHeight_SetTriangleHeight_F_V;
	}

	private static void n_SetTriangleHeight_F(nint jnienv, nint native__this, float p0)
	{
		Java.Lang.Object.GetObject<IArrow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TriangleHeight = p0;
	}

	private static Delegate GetIsVisibleHandler()
	{
		if ((object)cb_isVisible_IsVisible_Z == null)
		{
			cb_isVisible_IsVisible_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsVisible));
		}
		return cb_isVisible_IsVisible_Z;
	}

	private static bool n_IsVisible(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<IArrow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Visible;
	}

	private static Delegate GetSetVisible_ZHandler()
	{
		if ((object)cb_setVisible_SetVisible_Z_V == null)
		{
			cb_setVisible_SetVisible_Z_V = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPZ_V(n_SetVisible_Z));
		}
		return cb_setVisible_SetVisible_Z_V;
	}

	private static void n_SetVisible_Z(nint jnienv, nint native__this, bool p0)
	{
		Java.Lang.Object.GetObject<IArrow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Visible = p0;
	}
}
