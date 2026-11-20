using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Camera.Video;

[Register("androidx/camera/video/FallbackStrategy", DoNotGenerateAcw = true)]
public class FallbackStrategy : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/video/FallbackStrategy", typeof(FallbackStrategy));

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

	protected FallbackStrategy(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register("higherQualityOrLowerThan", "(Landroidx/camera/video/Quality;)Landroidx/camera/video/FallbackStrategy;", "")]
	public unsafe static FallbackStrategy HigherQualityOrLowerThan(Quality quality)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(quality?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<FallbackStrategy>(_members.StaticMethods.InvokeObjectMethod("higherQualityOrLowerThan.(Landroidx/camera/video/Quality;)Landroidx/camera/video/FallbackStrategy;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(quality);
		}
	}

	[Register("higherQualityThan", "(Landroidx/camera/video/Quality;)Landroidx/camera/video/FallbackStrategy;", "")]
	public unsafe static FallbackStrategy HigherQualityThan(Quality quality)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(quality?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<FallbackStrategy>(_members.StaticMethods.InvokeObjectMethod("higherQualityThan.(Landroidx/camera/video/Quality;)Landroidx/camera/video/FallbackStrategy;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(quality);
		}
	}

	[Register("lowerQualityOrHigherThan", "(Landroidx/camera/video/Quality;)Landroidx/camera/video/FallbackStrategy;", "")]
	public unsafe static FallbackStrategy LowerQualityOrHigherThan(Quality quality)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(quality?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<FallbackStrategy>(_members.StaticMethods.InvokeObjectMethod("lowerQualityOrHigherThan.(Landroidx/camera/video/Quality;)Landroidx/camera/video/FallbackStrategy;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(quality);
		}
	}

	[Register("lowerQualityThan", "(Landroidx/camera/video/Quality;)Landroidx/camera/video/FallbackStrategy;", "")]
	public unsafe static FallbackStrategy LowerQualityThan(Quality quality)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(quality?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<FallbackStrategy>(_members.StaticMethods.InvokeObjectMethod("lowerQualityThan.(Landroidx/camera/video/Quality;)Landroidx/camera/video/FallbackStrategy;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(quality);
		}
	}
}
