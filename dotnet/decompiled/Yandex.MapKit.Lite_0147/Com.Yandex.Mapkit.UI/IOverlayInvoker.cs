using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Com.Yandex.Runtime.Image;
using Com.Yandex.Runtime.Ui_view;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit.UI;

[Register("com/yandex/mapkit/ui/Overlay", DoNotGenerateAcw = true)]
internal class IOverlayInvoker : Java.Lang.Object, IOverlay, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_com_yandex_mapkit_ui_Overlay = new XAPeerMembers("com/yandex/mapkit/ui/Overlay", typeof(IOverlayInvoker));

	private static Delegate? cb_isValid_IsValid_Z;

	private static Delegate? cb_remove_Remove_V;

	private static Delegate? cb_setImage_SetImage_Lcom_yandex_runtime_image_ImageProvider_Lcom_yandex_mapkit_ScreenRect__V;

	private static Delegate? cb_setView_SetView_Lcom_yandex_runtime_ui_view_ViewProvider_Lcom_yandex_mapkit_ScreenRect__V;

	private static nint java_class_ref => _members_com_yandex_mapkit_ui_Overlay.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_com_yandex_mapkit_ui_Overlay;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_com_yandex_mapkit_ui_Overlay.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_com_yandex_mapkit_ui_Overlay.ManagedPeerType;

	public unsafe bool IsValid => _members_com_yandex_mapkit_ui_Overlay.InstanceMethods.InvokeAbstractBooleanMethod("isValid.()Z", this, null);

	public IOverlayInvoker(nint handle, JniHandleOwnership transfer)
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
		return Java.Lang.Object.GetObject<IOverlay>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsValid;
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
		Java.Lang.Object.GetObject<IOverlay>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Remove();
	}

	public unsafe void Remove()
	{
		_members_com_yandex_mapkit_ui_Overlay.InstanceMethods.InvokeAbstractVoidMethod("remove.()V", this, null);
	}

	private static Delegate GetSetImage_Lcom_yandex_runtime_image_ImageProvider_Lcom_yandex_mapkit_ScreenRect_Handler()
	{
		if ((object)cb_setImage_SetImage_Lcom_yandex_runtime_image_ImageProvider_Lcom_yandex_mapkit_ScreenRect__V == null)
		{
			cb_setImage_SetImage_Lcom_yandex_runtime_image_ImageProvider_Lcom_yandex_mapkit_ScreenRect__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_SetImage_Lcom_yandex_runtime_image_ImageProvider_Lcom_yandex_mapkit_ScreenRect_));
		}
		return cb_setImage_SetImage_Lcom_yandex_runtime_image_ImageProvider_Lcom_yandex_mapkit_ScreenRect__V;
	}

	private static void n_SetImage_Lcom_yandex_runtime_image_ImageProvider_Lcom_yandex_mapkit_ScreenRect_(nint jnienv, nint native__this, nint native_p0, nint native_p1)
	{
		IOverlay? overlay = Java.Lang.Object.GetObject<IOverlay>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ImageProvider p = Java.Lang.Object.GetObject<ImageProvider>(native_p0, JniHandleOwnership.DoNotTransfer);
		ScreenRect p2 = Java.Lang.Object.GetObject<ScreenRect>(native_p1, JniHandleOwnership.DoNotTransfer);
		overlay.SetImage(p, p2);
	}

	public unsafe void SetImage(ImageProvider p0, ScreenRect p1)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
			_members_com_yandex_mapkit_ui_Overlay.InstanceMethods.InvokeAbstractVoidMethod("setImage.(Lcom/yandex/runtime/image/ImageProvider;Lcom/yandex/mapkit/ScreenRect;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
			GC.KeepAlive(p1);
		}
	}

	private static Delegate GetSetView_Lcom_yandex_runtime_ui_view_ViewProvider_Lcom_yandex_mapkit_ScreenRect_Handler()
	{
		if ((object)cb_setView_SetView_Lcom_yandex_runtime_ui_view_ViewProvider_Lcom_yandex_mapkit_ScreenRect__V == null)
		{
			cb_setView_SetView_Lcom_yandex_runtime_ui_view_ViewProvider_Lcom_yandex_mapkit_ScreenRect__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_SetView_Lcom_yandex_runtime_ui_view_ViewProvider_Lcom_yandex_mapkit_ScreenRect_));
		}
		return cb_setView_SetView_Lcom_yandex_runtime_ui_view_ViewProvider_Lcom_yandex_mapkit_ScreenRect__V;
	}

	private static void n_SetView_Lcom_yandex_runtime_ui_view_ViewProvider_Lcom_yandex_mapkit_ScreenRect_(nint jnienv, nint native__this, nint native_p0, nint native_p1)
	{
		IOverlay? overlay = Java.Lang.Object.GetObject<IOverlay>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ViewProvider p = Java.Lang.Object.GetObject<ViewProvider>(native_p0, JniHandleOwnership.DoNotTransfer);
		ScreenRect p2 = Java.Lang.Object.GetObject<ScreenRect>(native_p1, JniHandleOwnership.DoNotTransfer);
		overlay.SetView(p, p2);
	}

	public unsafe void SetView(ViewProvider p0, ScreenRect p1)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
			_members_com_yandex_mapkit_ui_Overlay.InstanceMethods.InvokeAbstractVoidMethod("setView.(Lcom/yandex/runtime/ui_view/ViewProvider;Lcom/yandex/mapkit/ScreenRect;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
			GC.KeepAlive(p1);
		}
	}
}
