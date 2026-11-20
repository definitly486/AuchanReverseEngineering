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

[Register("androidx/camera/core/SurfaceOutput$CameraInputInfo", DoNotGenerateAcw = true)]
internal class SurfaceOutputCameraInputInfoInvoker : SurfaceOutputCameraInputInfo
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/SurfaceOutput$CameraInputInfo", typeof(SurfaceOutputCameraInputInfoInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe override ICameraInternal? CameraInternal
	{
		[Register("getCameraInternal", "()Landroidx/camera/core/impl/CameraInternal;", "GetGetCameraInternalHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ICameraInternal>(_members.InstanceMethods.InvokeAbstractObjectMethod("getCameraInternal.()Landroidx/camera/core/impl/CameraInternal;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe override Rect InputCropRect
	{
		[Register("getInputCropRect", "()Landroid/graphics/Rect;", "GetGetInputCropRectHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Rect>(_members.InstanceMethods.InvokeAbstractObjectMethod("getInputCropRect.()Landroid/graphics/Rect;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe override Size InputSize
	{
		[Register("getInputSize", "()Landroid/util/Size;", "GetGetInputSizeHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Size>(_members.InstanceMethods.InvokeAbstractObjectMethod("getInputSize.()Landroid/util/Size;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe override bool Mirroring
	{
		[Register("getMirroring", "()Z", "GetGetMirroringHandler")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("getMirroring.()Z", this, null);
		}
	}

	public unsafe override int RotationDegrees
	{
		[Register("getRotationDegrees", "()I", "GetGetRotationDegreesHandler")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("getRotationDegrees.()I", this, null);
		}
	}

	public SurfaceOutputCameraInputInfoInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}
}
