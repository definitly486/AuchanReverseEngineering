using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Camera.Core.Impl;

[Register("androidx/camera/core/impl/OutputSurfaceConfiguration", DoNotGenerateAcw = true)]
public abstract class OutputSurfaceConfiguration : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/impl/OutputSurfaceConfiguration", typeof(OutputSurfaceConfiguration));

	private static Delegate? cb_getImageAnalysisOutputSurface;

	private static Delegate? cb_getImageCaptureOutputSurface;

	private static Delegate? cb_getPostviewOutputSurface;

	private static Delegate? cb_getPreviewOutputSurface;

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

	public abstract OutputSurface? ImageAnalysisOutputSurface
	{
		[Register("getImageAnalysisOutputSurface", "()Landroidx/camera/core/impl/OutputSurface;", "GetGetImageAnalysisOutputSurfaceHandler")]
		get;
	}

	public abstract OutputSurface ImageCaptureOutputSurface
	{
		[Register("getImageCaptureOutputSurface", "()Landroidx/camera/core/impl/OutputSurface;", "GetGetImageCaptureOutputSurfaceHandler")]
		get;
	}

	public abstract OutputSurface? PostviewOutputSurface
	{
		[Register("getPostviewOutputSurface", "()Landroidx/camera/core/impl/OutputSurface;", "GetGetPostviewOutputSurfaceHandler")]
		get;
	}

	public abstract OutputSurface PreviewOutputSurface
	{
		[Register("getPreviewOutputSurface", "()Landroidx/camera/core/impl/OutputSurface;", "GetGetPreviewOutputSurfaceHandler")]
		get;
	}

	protected OutputSurfaceConfiguration(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe OutputSurfaceConfiguration()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	private static Delegate GetGetImageAnalysisOutputSurfaceHandler()
	{
		if ((object)cb_getImageAnalysisOutputSurface == null)
		{
			cb_getImageAnalysisOutputSurface = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetImageAnalysisOutputSurface));
		}
		return cb_getImageAnalysisOutputSurface;
	}

	private static nint n_GetImageAnalysisOutputSurface(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<OutputSurfaceConfiguration>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ImageAnalysisOutputSurface);
	}

	private static Delegate GetGetImageCaptureOutputSurfaceHandler()
	{
		if ((object)cb_getImageCaptureOutputSurface == null)
		{
			cb_getImageCaptureOutputSurface = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetImageCaptureOutputSurface));
		}
		return cb_getImageCaptureOutputSurface;
	}

	private static nint n_GetImageCaptureOutputSurface(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<OutputSurfaceConfiguration>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ImageCaptureOutputSurface);
	}

	private static Delegate GetGetPostviewOutputSurfaceHandler()
	{
		if ((object)cb_getPostviewOutputSurface == null)
		{
			cb_getPostviewOutputSurface = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetPostviewOutputSurface));
		}
		return cb_getPostviewOutputSurface;
	}

	private static nint n_GetPostviewOutputSurface(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<OutputSurfaceConfiguration>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PostviewOutputSurface);
	}

	private static Delegate GetGetPreviewOutputSurfaceHandler()
	{
		if ((object)cb_getPreviewOutputSurface == null)
		{
			cb_getPreviewOutputSurface = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetPreviewOutputSurface));
		}
		return cb_getPreviewOutputSurface;
	}

	private static nint n_GetPreviewOutputSurface(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<OutputSurfaceConfiguration>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PreviewOutputSurface);
	}

	[Register("create", "(Landroidx/camera/core/impl/OutputSurface;Landroidx/camera/core/impl/OutputSurface;Landroidx/camera/core/impl/OutputSurface;Landroidx/camera/core/impl/OutputSurface;)Landroidx/camera/core/impl/OutputSurfaceConfiguration;", "")]
	public unsafe static OutputSurfaceConfiguration Create(OutputSurface previewOutputSurface, OutputSurface imageCaptureOutputSurface, OutputSurface? imageAnalysisOutputSurface, OutputSurface? postviewOutputSurface)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(previewOutputSurface?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(imageCaptureOutputSurface?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(imageAnalysisOutputSurface?.Handle ?? IntPtr.Zero);
			ptr[3] = new JniArgumentValue(postviewOutputSurface?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<OutputSurfaceConfiguration>(_members.StaticMethods.InvokeObjectMethod("create.(Landroidx/camera/core/impl/OutputSurface;Landroidx/camera/core/impl/OutputSurface;Landroidx/camera/core/impl/OutputSurface;Landroidx/camera/core/impl/OutputSurface;)Landroidx/camera/core/impl/OutputSurfaceConfiguration;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(previewOutputSurface);
			GC.KeepAlive(imageCaptureOutputSurface);
			GC.KeepAlive(imageAnalysisOutputSurface);
			GC.KeepAlive(postviewOutputSurface);
		}
	}
}
