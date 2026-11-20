using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Content;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using AndroidX.Camera.View;
using Com.Scanflow.UI.AR;
using Java.Interop;
using Java.Lang;

namespace Com.Scanflow.Datacapture.Sfbarcode;

[Register("com/scanflow/datacapture/sfbarcode/SFCameraView", DoNotGenerateAcw = true)]
public class SFCameraView : FrameLayout
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/scanflow/datacapture/sfbarcode/SFCameraView", typeof(SFCameraView));

	private static Delegate cb_getArOverlayView_GetArOverlayView_Lcom_scanflow_ui_ar_ArOverlayView_;

	private static Delegate cb_getPreviewView_GetPreviewView_Landroidx_camera_view_PreviewView_;

	private static Delegate cb_getSurfaceView_GetSurfaceView_Landroid_view_SurfaceView_;

	private static Delegate cb_isBorderCornersRounded_IsBorderCornersRounded_Ljava_lang_Boolean_;

	private static Delegate cb_mBottomLeftColor_MBottomLeftColor_Ljava_lang_Integer_;

	private static Delegate cb_mBottomRightColor_MBottomRightColor_Ljava_lang_Integer_;

	private static Delegate cb_mTopLeftColor_MTopLeftColor_Ljava_lang_Integer_;

	private static Delegate cb_mTopRightColor_MTopRightColor_Ljava_lang_Integer_;

	private static Delegate cb_setExpiredVisibility_SetExpiredVisibility_Ljava_lang_Boolean_Ljava_lang_String__V;

	private static Delegate cb_textCaptureHeightPercentage_TextCaptureHeightPercentage_Ljava_lang_Integer_;

	private static Delegate cb_textCaptureWidthPercentage_TextCaptureWidthPercentage_Ljava_lang_Integer_;

	internal static nint class_ref => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe virtual ArOverlayView ArOverlayView
	{
		[Register("getArOverlayView", "()Lcom/scanflow/ui/ar/ArOverlayView;", "GetGetArOverlayViewHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ArOverlayView>(_members.InstanceMethods.InvokeVirtualObjectMethod("getArOverlayView.()Lcom/scanflow/ui/ar/ArOverlayView;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual PreviewView PreviewView
	{
		[Register("getPreviewView", "()Landroidx/camera/view/PreviewView;", "GetGetPreviewViewHandler")]
		get
		{
			return Java.Lang.Object.GetObject<PreviewView>(_members.InstanceMethods.InvokeVirtualObjectMethod("getPreviewView.()Landroidx/camera/view/PreviewView;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual SurfaceView SurfaceView
	{
		[Register("getSurfaceView", "()Landroid/view/SurfaceView;", "GetGetSurfaceViewHandler")]
		get
		{
			return Java.Lang.Object.GetObject<SurfaceView>(_members.InstanceMethods.InvokeVirtualObjectMethod("getSurfaceView.()Landroid/view/SurfaceView;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	protected SFCameraView(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroid/content/Context;)V", "")]
	public unsafe SFCameraView(Context p0)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	[Register(".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;)V", "")]
	public unsafe SFCameraView(Context p0, IAttributeSet p1)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((p1 == null) ? IntPtr.Zero : ((Java.Lang.Object)p1).Handle);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
			GC.KeepAlive(p1);
		}
	}

	[Register(".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;I)V", "")]
	public unsafe SFCameraView(Context p0, IAttributeSet p1, int p2)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((p1 == null) ? IntPtr.Zero : ((Java.Lang.Object)p1).Handle);
			ptr[2] = new JniArgumentValue(p2);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;I)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;I)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
			GC.KeepAlive(p1);
		}
	}

	private static Delegate GetGetArOverlayViewHandler()
	{
		if ((object)cb_getArOverlayView_GetArOverlayView_Lcom_scanflow_ui_ar_ArOverlayView_ == null)
		{
			cb_getArOverlayView_GetArOverlayView_Lcom_scanflow_ui_ar_ArOverlayView_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetArOverlayView));
		}
		return cb_getArOverlayView_GetArOverlayView_Lcom_scanflow_ui_ar_ArOverlayView_;
	}

	private static nint n_GetArOverlayView(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<SFCameraView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ArOverlayView);
	}

	private static Delegate GetGetPreviewViewHandler()
	{
		if ((object)cb_getPreviewView_GetPreviewView_Landroidx_camera_view_PreviewView_ == null)
		{
			cb_getPreviewView_GetPreviewView_Landroidx_camera_view_PreviewView_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetPreviewView));
		}
		return cb_getPreviewView_GetPreviewView_Landroidx_camera_view_PreviewView_;
	}

	private static nint n_GetPreviewView(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<SFCameraView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PreviewView);
	}

	private static Delegate GetGetSurfaceViewHandler()
	{
		if ((object)cb_getSurfaceView_GetSurfaceView_Landroid_view_SurfaceView_ == null)
		{
			cb_getSurfaceView_GetSurfaceView_Landroid_view_SurfaceView_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetSurfaceView));
		}
		return cb_getSurfaceView_GetSurfaceView_Landroid_view_SurfaceView_;
	}

	private static nint n_GetSurfaceView(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<SFCameraView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SurfaceView);
	}

	private static Delegate GetIsBorderCornersRoundedHandler()
	{
		if ((object)cb_isBorderCornersRounded_IsBorderCornersRounded_Ljava_lang_Boolean_ == null)
		{
			cb_isBorderCornersRounded_IsBorderCornersRounded_Ljava_lang_Boolean_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_IsBorderCornersRounded));
		}
		return cb_isBorderCornersRounded_IsBorderCornersRounded_Ljava_lang_Boolean_;
	}

	private static nint n_IsBorderCornersRounded(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<SFCameraView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsBorderCornersRounded());
	}

	[Register("isBorderCornersRounded", "()Ljava/lang/Boolean;", "GetIsBorderCornersRoundedHandler")]
	public unsafe virtual Java.Lang.Boolean IsBorderCornersRounded()
	{
		return Java.Lang.Object.GetObject<Java.Lang.Boolean>(_members.InstanceMethods.InvokeVirtualObjectMethod("isBorderCornersRounded.()Ljava/lang/Boolean;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetMBottomLeftColorHandler()
	{
		if ((object)cb_mBottomLeftColor_MBottomLeftColor_Ljava_lang_Integer_ == null)
		{
			cb_mBottomLeftColor_MBottomLeftColor_Ljava_lang_Integer_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_MBottomLeftColor));
		}
		return cb_mBottomLeftColor_MBottomLeftColor_Ljava_lang_Integer_;
	}

	private static nint n_MBottomLeftColor(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<SFCameraView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MBottomLeftColor());
	}

	[Register("mBottomLeftColor", "()Ljava/lang/Integer;", "GetMBottomLeftColorHandler")]
	public unsafe virtual Integer MBottomLeftColor()
	{
		return Java.Lang.Object.GetObject<Integer>(_members.InstanceMethods.InvokeVirtualObjectMethod("mBottomLeftColor.()Ljava/lang/Integer;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetMBottomRightColorHandler()
	{
		if ((object)cb_mBottomRightColor_MBottomRightColor_Ljava_lang_Integer_ == null)
		{
			cb_mBottomRightColor_MBottomRightColor_Ljava_lang_Integer_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_MBottomRightColor));
		}
		return cb_mBottomRightColor_MBottomRightColor_Ljava_lang_Integer_;
	}

	private static nint n_MBottomRightColor(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<SFCameraView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MBottomRightColor());
	}

	[Register("mBottomRightColor", "()Ljava/lang/Integer;", "GetMBottomRightColorHandler")]
	public unsafe virtual Integer MBottomRightColor()
	{
		return Java.Lang.Object.GetObject<Integer>(_members.InstanceMethods.InvokeVirtualObjectMethod("mBottomRightColor.()Ljava/lang/Integer;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetMTopLeftColorHandler()
	{
		if ((object)cb_mTopLeftColor_MTopLeftColor_Ljava_lang_Integer_ == null)
		{
			cb_mTopLeftColor_MTopLeftColor_Ljava_lang_Integer_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_MTopLeftColor));
		}
		return cb_mTopLeftColor_MTopLeftColor_Ljava_lang_Integer_;
	}

	private static nint n_MTopLeftColor(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<SFCameraView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MTopLeftColor());
	}

	[Register("mTopLeftColor", "()Ljava/lang/Integer;", "GetMTopLeftColorHandler")]
	public unsafe virtual Integer MTopLeftColor()
	{
		return Java.Lang.Object.GetObject<Integer>(_members.InstanceMethods.InvokeVirtualObjectMethod("mTopLeftColor.()Ljava/lang/Integer;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetMTopRightColorHandler()
	{
		if ((object)cb_mTopRightColor_MTopRightColor_Ljava_lang_Integer_ == null)
		{
			cb_mTopRightColor_MTopRightColor_Ljava_lang_Integer_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_MTopRightColor));
		}
		return cb_mTopRightColor_MTopRightColor_Ljava_lang_Integer_;
	}

	private static nint n_MTopRightColor(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<SFCameraView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MTopRightColor());
	}

	[Register("mTopRightColor", "()Ljava/lang/Integer;", "GetMTopRightColorHandler")]
	public unsafe virtual Integer MTopRightColor()
	{
		return Java.Lang.Object.GetObject<Integer>(_members.InstanceMethods.InvokeVirtualObjectMethod("mTopRightColor.()Ljava/lang/Integer;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetSetExpiredVisibility_Ljava_lang_Boolean_Ljava_lang_String_Handler()
	{
		if ((object)cb_setExpiredVisibility_SetExpiredVisibility_Ljava_lang_Boolean_Ljava_lang_String__V == null)
		{
			cb_setExpiredVisibility_SetExpiredVisibility_Ljava_lang_Boolean_Ljava_lang_String__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_SetExpiredVisibility_Ljava_lang_Boolean_Ljava_lang_String_));
		}
		return cb_setExpiredVisibility_SetExpiredVisibility_Ljava_lang_Boolean_Ljava_lang_String__V;
	}

	private static void n_SetExpiredVisibility_Ljava_lang_Boolean_Ljava_lang_String_(nint jnienv, nint native__this, nint native_p0, nint native_p1)
	{
		SFCameraView? sFCameraView = Java.Lang.Object.GetObject<SFCameraView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Java.Lang.Boolean p = Java.Lang.Object.GetObject<Java.Lang.Boolean>(native_p0, JniHandleOwnership.DoNotTransfer);
		string p2 = JNIEnv.GetString(native_p1, JniHandleOwnership.DoNotTransfer);
		sFCameraView.SetExpiredVisibility(p, p2);
	}

	[Register("setExpiredVisibility", "(Ljava/lang/Boolean;Ljava/lang/String;)V", "GetSetExpiredVisibility_Ljava_lang_Boolean_Ljava_lang_String_Handler")]
	public unsafe virtual void SetExpiredVisibility(Java.Lang.Boolean p0, string p1)
	{
		nint num = JNIEnv.NewString(p1);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setExpiredVisibility.(Ljava/lang/Boolean;Ljava/lang/String;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetTextCaptureHeightPercentageHandler()
	{
		if ((object)cb_textCaptureHeightPercentage_TextCaptureHeightPercentage_Ljava_lang_Integer_ == null)
		{
			cb_textCaptureHeightPercentage_TextCaptureHeightPercentage_Ljava_lang_Integer_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_TextCaptureHeightPercentage));
		}
		return cb_textCaptureHeightPercentage_TextCaptureHeightPercentage_Ljava_lang_Integer_;
	}

	private static nint n_TextCaptureHeightPercentage(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<SFCameraView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TextCaptureHeightPercentage());
	}

	[Register("textCaptureHeightPercentage", "()Ljava/lang/Integer;", "GetTextCaptureHeightPercentageHandler")]
	public unsafe virtual Integer TextCaptureHeightPercentage()
	{
		return Java.Lang.Object.GetObject<Integer>(_members.InstanceMethods.InvokeVirtualObjectMethod("textCaptureHeightPercentage.()Ljava/lang/Integer;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetTextCaptureWidthPercentageHandler()
	{
		if ((object)cb_textCaptureWidthPercentage_TextCaptureWidthPercentage_Ljava_lang_Integer_ == null)
		{
			cb_textCaptureWidthPercentage_TextCaptureWidthPercentage_Ljava_lang_Integer_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_TextCaptureWidthPercentage));
		}
		return cb_textCaptureWidthPercentage_TextCaptureWidthPercentage_Ljava_lang_Integer_;
	}

	private static nint n_TextCaptureWidthPercentage(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<SFCameraView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TextCaptureWidthPercentage());
	}

	[Register("textCaptureWidthPercentage", "()Ljava/lang/Integer;", "GetTextCaptureWidthPercentageHandler")]
	public unsafe virtual Integer TextCaptureWidthPercentage()
	{
		return Java.Lang.Object.GetObject<Integer>(_members.InstanceMethods.InvokeVirtualObjectMethod("textCaptureWidthPercentage.()Ljava/lang/Integer;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}
}
