using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Graphics;
using Android.Runtime;
using Com.Yandex.Runtime.Bindings;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit.Map;

[Register("com/yandex/mapkit/map/Rect", DoNotGenerateAcw = true)]
public class Rect : Java.Lang.Object, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/yandex/mapkit/map/Rect", typeof(Rect));

	private static Delegate? cb_getMax_GetMax_Landroid_graphics_PointF_;

	private static Delegate? cb_getMin_GetMin_Landroid_graphics_PointF_;

	private static Delegate? cb_serialize_Serialize_Lcom_yandex_runtime_bindings_Archive__V;

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

	public unsafe virtual PointF Max
	{
		[Register("getMax", "()Landroid/graphics/PointF;", "GetGetMaxHandler")]
		get
		{
			return Java.Lang.Object.GetObject<PointF>(_members.InstanceMethods.InvokeVirtualObjectMethod("getMax.()Landroid/graphics/PointF;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual PointF Min
	{
		[Register("getMin", "()Landroid/graphics/PointF;", "GetGetMinHandler")]
		get
		{
			return Java.Lang.Object.GetObject<PointF>(_members.InstanceMethods.InvokeVirtualObjectMethod("getMin.()Landroid/graphics/PointF;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	protected Rect(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe Rect()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	[Register(".ctor", "(Landroid/graphics/PointF;Landroid/graphics/PointF;)V", "")]
	public unsafe Rect(PointF min, PointF max)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(min?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(max?.Handle ?? IntPtr.Zero);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/graphics/PointF;Landroid/graphics/PointF;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/graphics/PointF;Landroid/graphics/PointF;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(min);
			GC.KeepAlive(max);
		}
	}

	private static Delegate GetGetMaxHandler()
	{
		if ((object)cb_getMax_GetMax_Landroid_graphics_PointF_ == null)
		{
			cb_getMax_GetMax_Landroid_graphics_PointF_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetMax));
		}
		return cb_getMax_GetMax_Landroid_graphics_PointF_;
	}

	private static nint n_GetMax(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Rect>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Max);
	}

	private static Delegate GetGetMinHandler()
	{
		if ((object)cb_getMin_GetMin_Landroid_graphics_PointF_ == null)
		{
			cb_getMin_GetMin_Landroid_graphics_PointF_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetMin));
		}
		return cb_getMin_GetMin_Landroid_graphics_PointF_;
	}

	private static nint n_GetMin(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Rect>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Min);
	}

	private static Delegate GetSerialize_Lcom_yandex_runtime_bindings_Archive_Handler()
	{
		if ((object)cb_serialize_Serialize_Lcom_yandex_runtime_bindings_Archive__V == null)
		{
			cb_serialize_Serialize_Lcom_yandex_runtime_bindings_Archive__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_Serialize_Lcom_yandex_runtime_bindings_Archive_));
		}
		return cb_serialize_Serialize_Lcom_yandex_runtime_bindings_Archive__V;
	}

	private static void n_Serialize_Lcom_yandex_runtime_bindings_Archive_(nint jnienv, nint native__this, nint native_archive)
	{
		Rect? rect = Java.Lang.Object.GetObject<Rect>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IArchive archive = Java.Lang.Object.GetObject<IArchive>(native_archive, JniHandleOwnership.DoNotTransfer);
		rect.Serialize(archive);
	}

	[Register("serialize", "(Lcom/yandex/runtime/bindings/Archive;)V", "GetSerialize_Lcom_yandex_runtime_bindings_Archive_Handler")]
	public unsafe virtual void Serialize(IArchive? archive)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((archive == null) ? IntPtr.Zero : ((Java.Lang.Object)archive).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("serialize.(Lcom/yandex/runtime/bindings/Archive;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(archive);
		}
	}
}
