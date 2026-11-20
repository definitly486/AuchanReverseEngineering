using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Graphics;
using Android.Runtime;
using Android.Util;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Camera.Core;

[Register("androidx/camera/core/ResolutionInfo", DoNotGenerateAcw = true)]
public class ResolutionInfo : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/ResolutionInfo", typeof(ResolutionInfo));

	private static Delegate? cb_getCropRect;

	private static Delegate? cb_getResolution;

	private static Delegate? cb_getRotationDegrees;

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

	public unsafe virtual Rect CropRect
	{
		[Register("getCropRect", "()Landroid/graphics/Rect;", "GetGetCropRectHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Rect>(_members.InstanceMethods.InvokeVirtualObjectMethod("getCropRect.()Landroid/graphics/Rect;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual Size Resolution
	{
		[Register("getResolution", "()Landroid/util/Size;", "GetGetResolutionHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Size>(_members.InstanceMethods.InvokeVirtualObjectMethod("getResolution.()Landroid/util/Size;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual int RotationDegrees
	{
		[Register("getRotationDegrees", "()I", "GetGetRotationDegreesHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getRotationDegrees.()I", this, null);
		}
	}

	protected ResolutionInfo(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroid/util/Size;Landroid/graphics/Rect;I)V", "")]
	public unsafe ResolutionInfo(Size resolution, Rect cropRect, int rotationDegrees)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(resolution?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(cropRect?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(rotationDegrees);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/util/Size;Landroid/graphics/Rect;I)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/util/Size;Landroid/graphics/Rect;I)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(resolution);
			GC.KeepAlive(cropRect);
		}
	}

	private static Delegate GetGetCropRectHandler()
	{
		if ((object)cb_getCropRect == null)
		{
			cb_getCropRect = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetCropRect));
		}
		return cb_getCropRect;
	}

	private static nint n_GetCropRect(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ResolutionInfo>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CropRect);
	}

	private static Delegate GetGetResolutionHandler()
	{
		if ((object)cb_getResolution == null)
		{
			cb_getResolution = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetResolution));
		}
		return cb_getResolution;
	}

	private static nint n_GetResolution(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ResolutionInfo>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Resolution);
	}

	private static Delegate GetGetRotationDegreesHandler()
	{
		if ((object)cb_getRotationDegrees == null)
		{
			cb_getRotationDegrees = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetRotationDegrees));
		}
		return cb_getRotationDegrees;
	}

	private static int n_GetRotationDegrees(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<ResolutionInfo>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RotationDegrees;
	}
}
