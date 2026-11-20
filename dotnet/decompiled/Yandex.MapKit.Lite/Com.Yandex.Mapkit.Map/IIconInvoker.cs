using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Com.Yandex.Runtime.Image;
using Com.Yandex.Runtime.Ui_view;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit.Map;

[Register("com/yandex/mapkit/map/Icon", DoNotGenerateAcw = true)]
internal class IIconInvoker : Java.Lang.Object, IIcon, IPlacemarkPresentation, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_com_yandex_mapkit_map_Icon = new XAPeerMembers("com/yandex/mapkit/map/Icon", typeof(IIconInvoker));

	private static readonly JniPeerMembers _members_com_yandex_mapkit_map_PlacemarkPresentation = new XAPeerMembers("com/yandex/mapkit/map/PlacemarkPresentation", typeof(IIconInvoker));

	private static Delegate? cb_getStyle_GetStyle_Lcom_yandex_mapkit_map_IconStyle_;

	private static Delegate? cb_setStyle_SetStyle_Lcom_yandex_mapkit_map_IconStyle__V;

	private static Delegate? cb_setImage_SetImage_Lcom_yandex_runtime_image_ImageProvider__V;

	private static Delegate? cb_setImage_SetImage_Lcom_yandex_runtime_image_ImageProvider_Lcom_yandex_mapkit_map_IconStyle__V;

	private static Delegate? cb_setImage_SetImage_Lcom_yandex_runtime_image_ImageProvider_Lcom_yandex_mapkit_map_IconStyle_Lcom_yandex_mapkit_map_Callback__V;

	private static Delegate? cb_setView_SetView_Lcom_yandex_runtime_ui_view_ViewProvider__V;

	private static Delegate? cb_setView_SetView_Lcom_yandex_runtime_ui_view_ViewProvider_Lcom_yandex_mapkit_map_IconStyle__V;

	private static Delegate? cb_setView_SetView_Lcom_yandex_runtime_ui_view_ViewProvider_Lcom_yandex_mapkit_map_IconStyle_Lcom_yandex_mapkit_map_Callback__V;

	private static Delegate? cb_isValid_IsValid_Z;

	private static Delegate? cb_remove_Remove_V;

	private static nint java_class_ref => _members_com_yandex_mapkit_map_Icon.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_com_yandex_mapkit_map_Icon;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_com_yandex_mapkit_map_Icon.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_com_yandex_mapkit_map_Icon.ManagedPeerType;

	public unsafe IconStyle Style
	{
		get
		{
			return Java.Lang.Object.GetObject<IconStyle>(_members_com_yandex_mapkit_map_Icon.InstanceMethods.InvokeAbstractObjectMethod("getStyle.()Lcom/yandex/mapkit/map/IconStyle;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members_com_yandex_mapkit_map_Icon.InstanceMethods.InvokeAbstractVoidMethod("setStyle.(Lcom/yandex/mapkit/map/IconStyle;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe bool IsValid => _members_com_yandex_mapkit_map_PlacemarkPresentation.InstanceMethods.InvokeAbstractBooleanMethod("isValid.()Z", this, null);

	public IIconInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetGetStyleHandler()
	{
		if ((object)cb_getStyle_GetStyle_Lcom_yandex_mapkit_map_IconStyle_ == null)
		{
			cb_getStyle_GetStyle_Lcom_yandex_mapkit_map_IconStyle_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetStyle));
		}
		return cb_getStyle_GetStyle_Lcom_yandex_mapkit_map_IconStyle_;
	}

	private static nint n_GetStyle(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IIcon>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Style);
	}

	private static Delegate GetSetStyle_Lcom_yandex_mapkit_map_IconStyle_Handler()
	{
		if ((object)cb_setStyle_SetStyle_Lcom_yandex_mapkit_map_IconStyle__V == null)
		{
			cb_setStyle_SetStyle_Lcom_yandex_mapkit_map_IconStyle__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetStyle_Lcom_yandex_mapkit_map_IconStyle_));
		}
		return cb_setStyle_SetStyle_Lcom_yandex_mapkit_map_IconStyle__V;
	}

	private static void n_SetStyle_Lcom_yandex_mapkit_map_IconStyle_(nint jnienv, nint native__this, nint native_p0)
	{
		IIcon? icon = Java.Lang.Object.GetObject<IIcon>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IconStyle style = Java.Lang.Object.GetObject<IconStyle>(native_p0, JniHandleOwnership.DoNotTransfer);
		icon.Style = style;
	}

	private static Delegate GetSetImage_Lcom_yandex_runtime_image_ImageProvider_Handler()
	{
		if ((object)cb_setImage_SetImage_Lcom_yandex_runtime_image_ImageProvider__V == null)
		{
			cb_setImage_SetImage_Lcom_yandex_runtime_image_ImageProvider__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetImage_Lcom_yandex_runtime_image_ImageProvider_));
		}
		return cb_setImage_SetImage_Lcom_yandex_runtime_image_ImageProvider__V;
	}

	private static void n_SetImage_Lcom_yandex_runtime_image_ImageProvider_(nint jnienv, nint native__this, nint native_p0)
	{
		IIcon? icon = Java.Lang.Object.GetObject<IIcon>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ImageProvider image = Java.Lang.Object.GetObject<ImageProvider>(native_p0, JniHandleOwnership.DoNotTransfer);
		icon.SetImage(image);
	}

	public unsafe void SetImage(ImageProvider p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			_members_com_yandex_mapkit_map_Icon.InstanceMethods.InvokeAbstractVoidMethod("setImage.(Lcom/yandex/runtime/image/ImageProvider;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetSetImage_Lcom_yandex_runtime_image_ImageProvider_Lcom_yandex_mapkit_map_IconStyle_Handler()
	{
		if ((object)cb_setImage_SetImage_Lcom_yandex_runtime_image_ImageProvider_Lcom_yandex_mapkit_map_IconStyle__V == null)
		{
			cb_setImage_SetImage_Lcom_yandex_runtime_image_ImageProvider_Lcom_yandex_mapkit_map_IconStyle__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_SetImage_Lcom_yandex_runtime_image_ImageProvider_Lcom_yandex_mapkit_map_IconStyle_));
		}
		return cb_setImage_SetImage_Lcom_yandex_runtime_image_ImageProvider_Lcom_yandex_mapkit_map_IconStyle__V;
	}

	private static void n_SetImage_Lcom_yandex_runtime_image_ImageProvider_Lcom_yandex_mapkit_map_IconStyle_(nint jnienv, nint native__this, nint native_p0, nint native_p1)
	{
		IIcon? icon = Java.Lang.Object.GetObject<IIcon>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ImageProvider p = Java.Lang.Object.GetObject<ImageProvider>(native_p0, JniHandleOwnership.DoNotTransfer);
		IconStyle p2 = Java.Lang.Object.GetObject<IconStyle>(native_p1, JniHandleOwnership.DoNotTransfer);
		icon.SetImage(p, p2);
	}

	public unsafe void SetImage(ImageProvider p0, IconStyle p1)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
			_members_com_yandex_mapkit_map_Icon.InstanceMethods.InvokeAbstractVoidMethod("setImage.(Lcom/yandex/runtime/image/ImageProvider;Lcom/yandex/mapkit/map/IconStyle;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
			GC.KeepAlive(p1);
		}
	}

	private static Delegate GetSetImage_Lcom_yandex_runtime_image_ImageProvider_Lcom_yandex_mapkit_map_IconStyle_Lcom_yandex_mapkit_map_Callback_Handler()
	{
		if ((object)cb_setImage_SetImage_Lcom_yandex_runtime_image_ImageProvider_Lcom_yandex_mapkit_map_IconStyle_Lcom_yandex_mapkit_map_Callback__V == null)
		{
			cb_setImage_SetImage_Lcom_yandex_runtime_image_ImageProvider_Lcom_yandex_mapkit_map_IconStyle_Lcom_yandex_mapkit_map_Callback__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_V(n_SetImage_Lcom_yandex_runtime_image_ImageProvider_Lcom_yandex_mapkit_map_IconStyle_Lcom_yandex_mapkit_map_Callback_));
		}
		return cb_setImage_SetImage_Lcom_yandex_runtime_image_ImageProvider_Lcom_yandex_mapkit_map_IconStyle_Lcom_yandex_mapkit_map_Callback__V;
	}

	private static void n_SetImage_Lcom_yandex_runtime_image_ImageProvider_Lcom_yandex_mapkit_map_IconStyle_Lcom_yandex_mapkit_map_Callback_(nint jnienv, nint native__this, nint native_p0, nint native_p1, nint native_p2)
	{
		IIcon? icon = Java.Lang.Object.GetObject<IIcon>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ImageProvider p = Java.Lang.Object.GetObject<ImageProvider>(native_p0, JniHandleOwnership.DoNotTransfer);
		IconStyle p2 = Java.Lang.Object.GetObject<IconStyle>(native_p1, JniHandleOwnership.DoNotTransfer);
		ICallback p3 = Java.Lang.Object.GetObject<ICallback>(native_p2, JniHandleOwnership.DoNotTransfer);
		icon.SetImage(p, p2, p3);
	}

	public unsafe void SetImage(ImageProvider p0, IconStyle p1, ICallback p2)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue((p2 == null) ? IntPtr.Zero : ((Java.Lang.Object)p2).Handle);
			_members_com_yandex_mapkit_map_Icon.InstanceMethods.InvokeAbstractVoidMethod("setImage.(Lcom/yandex/runtime/image/ImageProvider;Lcom/yandex/mapkit/map/IconStyle;Lcom/yandex/mapkit/map/Callback;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
			GC.KeepAlive(p1);
			GC.KeepAlive(p2);
		}
	}

	private static Delegate GetSetView_Lcom_yandex_runtime_ui_view_ViewProvider_Handler()
	{
		if ((object)cb_setView_SetView_Lcom_yandex_runtime_ui_view_ViewProvider__V == null)
		{
			cb_setView_SetView_Lcom_yandex_runtime_ui_view_ViewProvider__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetView_Lcom_yandex_runtime_ui_view_ViewProvider_));
		}
		return cb_setView_SetView_Lcom_yandex_runtime_ui_view_ViewProvider__V;
	}

	private static void n_SetView_Lcom_yandex_runtime_ui_view_ViewProvider_(nint jnienv, nint native__this, nint native_p0)
	{
		IIcon? icon = Java.Lang.Object.GetObject<IIcon>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ViewProvider view = Java.Lang.Object.GetObject<ViewProvider>(native_p0, JniHandleOwnership.DoNotTransfer);
		icon.SetView(view);
	}

	public unsafe void SetView(ViewProvider p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			_members_com_yandex_mapkit_map_Icon.InstanceMethods.InvokeAbstractVoidMethod("setView.(Lcom/yandex/runtime/ui_view/ViewProvider;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetSetView_Lcom_yandex_runtime_ui_view_ViewProvider_Lcom_yandex_mapkit_map_IconStyle_Handler()
	{
		if ((object)cb_setView_SetView_Lcom_yandex_runtime_ui_view_ViewProvider_Lcom_yandex_mapkit_map_IconStyle__V == null)
		{
			cb_setView_SetView_Lcom_yandex_runtime_ui_view_ViewProvider_Lcom_yandex_mapkit_map_IconStyle__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_SetView_Lcom_yandex_runtime_ui_view_ViewProvider_Lcom_yandex_mapkit_map_IconStyle_));
		}
		return cb_setView_SetView_Lcom_yandex_runtime_ui_view_ViewProvider_Lcom_yandex_mapkit_map_IconStyle__V;
	}

	private static void n_SetView_Lcom_yandex_runtime_ui_view_ViewProvider_Lcom_yandex_mapkit_map_IconStyle_(nint jnienv, nint native__this, nint native_p0, nint native_p1)
	{
		IIcon? icon = Java.Lang.Object.GetObject<IIcon>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ViewProvider p = Java.Lang.Object.GetObject<ViewProvider>(native_p0, JniHandleOwnership.DoNotTransfer);
		IconStyle p2 = Java.Lang.Object.GetObject<IconStyle>(native_p1, JniHandleOwnership.DoNotTransfer);
		icon.SetView(p, p2);
	}

	public unsafe void SetView(ViewProvider p0, IconStyle p1)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
			_members_com_yandex_mapkit_map_Icon.InstanceMethods.InvokeAbstractVoidMethod("setView.(Lcom/yandex/runtime/ui_view/ViewProvider;Lcom/yandex/mapkit/map/IconStyle;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
			GC.KeepAlive(p1);
		}
	}

	private static Delegate GetSetView_Lcom_yandex_runtime_ui_view_ViewProvider_Lcom_yandex_mapkit_map_IconStyle_Lcom_yandex_mapkit_map_Callback_Handler()
	{
		if ((object)cb_setView_SetView_Lcom_yandex_runtime_ui_view_ViewProvider_Lcom_yandex_mapkit_map_IconStyle_Lcom_yandex_mapkit_map_Callback__V == null)
		{
			cb_setView_SetView_Lcom_yandex_runtime_ui_view_ViewProvider_Lcom_yandex_mapkit_map_IconStyle_Lcom_yandex_mapkit_map_Callback__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_V(n_SetView_Lcom_yandex_runtime_ui_view_ViewProvider_Lcom_yandex_mapkit_map_IconStyle_Lcom_yandex_mapkit_map_Callback_));
		}
		return cb_setView_SetView_Lcom_yandex_runtime_ui_view_ViewProvider_Lcom_yandex_mapkit_map_IconStyle_Lcom_yandex_mapkit_map_Callback__V;
	}

	private static void n_SetView_Lcom_yandex_runtime_ui_view_ViewProvider_Lcom_yandex_mapkit_map_IconStyle_Lcom_yandex_mapkit_map_Callback_(nint jnienv, nint native__this, nint native_p0, nint native_p1, nint native_p2)
	{
		IIcon? icon = Java.Lang.Object.GetObject<IIcon>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ViewProvider p = Java.Lang.Object.GetObject<ViewProvider>(native_p0, JniHandleOwnership.DoNotTransfer);
		IconStyle p2 = Java.Lang.Object.GetObject<IconStyle>(native_p1, JniHandleOwnership.DoNotTransfer);
		ICallback p3 = Java.Lang.Object.GetObject<ICallback>(native_p2, JniHandleOwnership.DoNotTransfer);
		icon.SetView(p, p2, p3);
	}

	public unsafe void SetView(ViewProvider p0, IconStyle p1, ICallback p2)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue((p2 == null) ? IntPtr.Zero : ((Java.Lang.Object)p2).Handle);
			_members_com_yandex_mapkit_map_Icon.InstanceMethods.InvokeAbstractVoidMethod("setView.(Lcom/yandex/runtime/ui_view/ViewProvider;Lcom/yandex/mapkit/map/IconStyle;Lcom/yandex/mapkit/map/Callback;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
			GC.KeepAlive(p1);
			GC.KeepAlive(p2);
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
		return Java.Lang.Object.GetObject<IIcon>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsValid;
	}

	private static Delegate GetRemoveHandler()
	{
		if ((object)cb_remove_Remove_V == null)
		{
			cb_remove_Remove_V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_Remove));
		}
		return cb_remove_Remove_V;
	}

	private static void n_Remove(nint jnienv, nint native__this)
	{
		Java.Lang.Object.GetObject<IIcon>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Remove();
	}

	public unsafe void Remove()
	{
		_members_com_yandex_mapkit_map_PlacemarkPresentation.InstanceMethods.InvokeAbstractVoidMethod("remove.()V", this, null);
	}
}
