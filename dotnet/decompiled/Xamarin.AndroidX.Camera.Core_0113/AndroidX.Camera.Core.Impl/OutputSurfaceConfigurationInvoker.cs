using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Camera.Core.Impl;

[Register("androidx/camera/core/impl/OutputSurfaceConfiguration", DoNotGenerateAcw = true)]
internal class OutputSurfaceConfigurationInvoker : OutputSurfaceConfiguration
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/impl/OutputSurfaceConfiguration", typeof(OutputSurfaceConfigurationInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe override OutputSurface? ImageAnalysisOutputSurface
	{
		[Register("getImageAnalysisOutputSurface", "()Landroidx/camera/core/impl/OutputSurface;", "GetGetImageAnalysisOutputSurfaceHandler")]
		get
		{
			return Java.Lang.Object.GetObject<OutputSurface>(_members.InstanceMethods.InvokeAbstractObjectMethod("getImageAnalysisOutputSurface.()Landroidx/camera/core/impl/OutputSurface;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe override OutputSurface ImageCaptureOutputSurface
	{
		[Register("getImageCaptureOutputSurface", "()Landroidx/camera/core/impl/OutputSurface;", "GetGetImageCaptureOutputSurfaceHandler")]
		get
		{
			return Java.Lang.Object.GetObject<OutputSurface>(_members.InstanceMethods.InvokeAbstractObjectMethod("getImageCaptureOutputSurface.()Landroidx/camera/core/impl/OutputSurface;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe override OutputSurface? PostviewOutputSurface
	{
		[Register("getPostviewOutputSurface", "()Landroidx/camera/core/impl/OutputSurface;", "GetGetPostviewOutputSurfaceHandler")]
		get
		{
			return Java.Lang.Object.GetObject<OutputSurface>(_members.InstanceMethods.InvokeAbstractObjectMethod("getPostviewOutputSurface.()Landroidx/camera/core/impl/OutputSurface;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe override OutputSurface PreviewOutputSurface
	{
		[Register("getPreviewOutputSurface", "()Landroidx/camera/core/impl/OutputSurface;", "GetGetPreviewOutputSurfaceHandler")]
		get
		{
			return Java.Lang.Object.GetObject<OutputSurface>(_members.InstanceMethods.InvokeAbstractObjectMethod("getPreviewOutputSurface.()Landroidx/camera/core/impl/OutputSurface;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public OutputSurfaceConfigurationInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}
}
