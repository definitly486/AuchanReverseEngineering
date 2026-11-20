using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Camera.Core.Impl;

[Register("androidx/camera/core/impl/OutputSurface", DoNotGenerateAcw = true)]
internal class OutputSurfaceInvoker : OutputSurface
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/impl/OutputSurface", typeof(OutputSurfaceInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe override int ImageFormat
	{
		[Register("getImageFormat", "()I", "GetGetImageFormatHandler")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("getImageFormat.()I", this, null);
		}
	}

	public unsafe override Size Size
	{
		[Register("getSize", "()Landroid/util/Size;", "GetGetSizeHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Size>(_members.InstanceMethods.InvokeAbstractObjectMethod("getSize.()Landroid/util/Size;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe override Surface Surface
	{
		[Register("getSurface", "()Landroid/view/Surface;", "GetGetSurfaceHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Surface>(_members.InstanceMethods.InvokeAbstractObjectMethod("getSurface.()Landroid/view/Surface;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public OutputSurfaceInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}
}
