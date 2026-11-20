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
public abstract class OutputSurface : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/impl/OutputSurface", typeof(OutputSurface));

	private static Delegate? cb_getImageFormat;

	private static Delegate? cb_getSize;

	private static Delegate? cb_getSurface;

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

	public abstract int ImageFormat
	{
		[Register("getImageFormat", "()I", "GetGetImageFormatHandler")]
		get;
	}

	public abstract Size Size
	{
		[Register("getSize", "()Landroid/util/Size;", "GetGetSizeHandler")]
		get;
	}

	public abstract Surface Surface
	{
		[Register("getSurface", "()Landroid/view/Surface;", "GetGetSurfaceHandler")]
		get;
	}

	protected OutputSurface(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe OutputSurface()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	private static Delegate GetGetImageFormatHandler()
	{
		if ((object)cb_getImageFormat == null)
		{
			cb_getImageFormat = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetImageFormat));
		}
		return cb_getImageFormat;
	}

	private static int n_GetImageFormat(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<OutputSurface>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ImageFormat;
	}

	private static Delegate GetGetSizeHandler()
	{
		if ((object)cb_getSize == null)
		{
			cb_getSize = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetSize));
		}
		return cb_getSize;
	}

	private static nint n_GetSize(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<OutputSurface>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Size);
	}

	private static Delegate GetGetSurfaceHandler()
	{
		if ((object)cb_getSurface == null)
		{
			cb_getSurface = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetSurface));
		}
		return cb_getSurface;
	}

	private static nint n_GetSurface(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<OutputSurface>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Surface);
	}

	[Register("create", "(Landroid/view/Surface;Landroid/util/Size;I)Landroidx/camera/core/impl/OutputSurface;", "")]
	public unsafe static OutputSurface Create(Surface surface, Size size, int imageFormat)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(surface?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(size?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(imageFormat);
			return Java.Lang.Object.GetObject<OutputSurface>(_members.StaticMethods.InvokeObjectMethod("create.(Landroid/view/Surface;Landroid/util/Size;I)Landroidx/camera/core/impl/OutputSurface;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(surface);
			GC.KeepAlive(size);
		}
	}
}
