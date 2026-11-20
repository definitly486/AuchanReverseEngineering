using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Graphics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Runtime.View;

[Register("com/yandex/runtime/view/Surface", DoNotGenerateAcw = true)]
internal class ISurfaceInvoker : Java.Lang.Object, ISurface, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_com_yandex_runtime_view_Surface = new XAPeerMembers("com/yandex/runtime/view/Surface", typeof(ISurfaceInvoker));

	private static Delegate? cb_getAnchorPoint_GetAnchorPoint_Landroid_graphics_PointF_;

	private static Delegate? cb_setAnchorPoint_SetAnchorPoint_Landroid_graphics_PointF__V;

	private static nint java_class_ref => _members_com_yandex_runtime_view_Surface.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_com_yandex_runtime_view_Surface;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_com_yandex_runtime_view_Surface.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_com_yandex_runtime_view_Surface.ManagedPeerType;

	public unsafe PointF AnchorPoint
	{
		get
		{
			return Java.Lang.Object.GetObject<PointF>(_members_com_yandex_runtime_view_Surface.InstanceMethods.InvokeAbstractObjectMethod("getAnchorPoint.()Landroid/graphics/PointF;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members_com_yandex_runtime_view_Surface.InstanceMethods.InvokeAbstractVoidMethod("setAnchorPoint.(Landroid/graphics/PointF;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public ISurfaceInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetGetAnchorPointHandler()
	{
		if ((object)cb_getAnchorPoint_GetAnchorPoint_Landroid_graphics_PointF_ == null)
		{
			cb_getAnchorPoint_GetAnchorPoint_Landroid_graphics_PointF_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetAnchorPoint));
		}
		return cb_getAnchorPoint_GetAnchorPoint_Landroid_graphics_PointF_;
	}

	private static nint n_GetAnchorPoint(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ISurface>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnchorPoint);
	}

	private static Delegate GetSetAnchorPoint_Landroid_graphics_PointF_Handler()
	{
		if ((object)cb_setAnchorPoint_SetAnchorPoint_Landroid_graphics_PointF__V == null)
		{
			cb_setAnchorPoint_SetAnchorPoint_Landroid_graphics_PointF__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetAnchorPoint_Landroid_graphics_PointF_));
		}
		return cb_setAnchorPoint_SetAnchorPoint_Landroid_graphics_PointF__V;
	}

	private static void n_SetAnchorPoint_Landroid_graphics_PointF_(nint jnienv, nint native__this, nint native_p0)
	{
		ISurface? surface = Java.Lang.Object.GetObject<ISurface>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		PointF anchorPoint = Java.Lang.Object.GetObject<PointF>(native_p0, JniHandleOwnership.DoNotTransfer);
		surface.AnchorPoint = anchorPoint;
	}
}
