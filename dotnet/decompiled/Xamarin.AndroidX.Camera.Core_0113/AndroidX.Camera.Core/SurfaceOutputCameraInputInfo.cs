using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Graphics;
using Android.Runtime;
using Android.Util;
using AndroidX.Camera.Core.Impl;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Camera.Core;

[Obsolete("While this type is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
[Register("androidx/camera/core/SurfaceOutput$CameraInputInfo", DoNotGenerateAcw = true)]
public abstract class SurfaceOutputCameraInputInfo : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/SurfaceOutput$CameraInputInfo", typeof(SurfaceOutputCameraInputInfo));

	private static Delegate? cb_getCameraInternal;

	private static Delegate? cb_getInputCropRect;

	private static Delegate? cb_getInputSize;

	private static Delegate? cb_getMirroring;

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

	public abstract ICameraInternal? CameraInternal
	{
		[Register("getCameraInternal", "()Landroidx/camera/core/impl/CameraInternal;", "GetGetCameraInternalHandler")]
		get;
	}

	public abstract Rect InputCropRect
	{
		[Register("getInputCropRect", "()Landroid/graphics/Rect;", "GetGetInputCropRectHandler")]
		get;
	}

	public abstract Size InputSize
	{
		[Register("getInputSize", "()Landroid/util/Size;", "GetGetInputSizeHandler")]
		get;
	}

	public abstract bool Mirroring
	{
		[Register("getMirroring", "()Z", "GetGetMirroringHandler")]
		get;
	}

	public abstract int RotationDegrees
	{
		[Register("getRotationDegrees", "()I", "GetGetRotationDegreesHandler")]
		get;
	}

	protected SurfaceOutputCameraInputInfo(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe SurfaceOutputCameraInputInfo()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	private static Delegate GetGetCameraInternalHandler()
	{
		if ((object)cb_getCameraInternal == null)
		{
			cb_getCameraInternal = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetCameraInternal));
		}
		return cb_getCameraInternal;
	}

	private static nint n_GetCameraInternal(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<SurfaceOutputCameraInputInfo>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CameraInternal);
	}

	private static Delegate GetGetInputCropRectHandler()
	{
		if ((object)cb_getInputCropRect == null)
		{
			cb_getInputCropRect = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetInputCropRect));
		}
		return cb_getInputCropRect;
	}

	private static nint n_GetInputCropRect(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<SurfaceOutputCameraInputInfo>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).InputCropRect);
	}

	private static Delegate GetGetInputSizeHandler()
	{
		if ((object)cb_getInputSize == null)
		{
			cb_getInputSize = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetInputSize));
		}
		return cb_getInputSize;
	}

	private static nint n_GetInputSize(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<SurfaceOutputCameraInputInfo>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).InputSize);
	}

	private static Delegate GetGetMirroringHandler()
	{
		if ((object)cb_getMirroring == null)
		{
			cb_getMirroring = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_GetMirroring));
		}
		return cb_getMirroring;
	}

	private static bool n_GetMirroring(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<SurfaceOutputCameraInputInfo>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Mirroring;
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
		return Java.Lang.Object.GetObject<SurfaceOutputCameraInputInfo>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RotationDegrees;
	}

	[Register("of", "(Landroid/util/Size;Landroid/graphics/Rect;Landroidx/camera/core/impl/CameraInternal;IZ)Landroidx/camera/core/SurfaceOutput$CameraInputInfo;", "")]
	public unsafe static SurfaceOutputCameraInputInfo Of(Size inputSize, Rect inputCropRect, ICameraInternal? cameraInternal, int rotationDegrees, bool mirroring)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
			*ptr = new JniArgumentValue(inputSize?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(inputCropRect?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue((cameraInternal == null) ? IntPtr.Zero : ((Java.Lang.Object)cameraInternal).Handle);
			ptr[3] = new JniArgumentValue(rotationDegrees);
			ptr[4] = new JniArgumentValue(mirroring);
			return Java.Lang.Object.GetObject<SurfaceOutputCameraInputInfo>(_members.StaticMethods.InvokeObjectMethod("of.(Landroid/util/Size;Landroid/graphics/Rect;Landroidx/camera/core/impl/CameraInternal;IZ)Landroidx/camera/core/SurfaceOutput$CameraInputInfo;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(inputSize);
			GC.KeepAlive(inputCropRect);
			GC.KeepAlive(cameraInternal);
		}
	}
}
