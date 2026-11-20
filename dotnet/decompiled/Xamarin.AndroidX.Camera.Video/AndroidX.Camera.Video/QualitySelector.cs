using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Android.Util;
using AndroidX.Camera.Core;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Camera.Video;

[Register("androidx/camera/video/QualitySelector", DoNotGenerateAcw = true)]
public sealed class QualitySelector : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/video/QualitySelector", typeof(QualitySelector));

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

	internal QualitySelector(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register("from", "(Landroidx/camera/video/Quality;)Landroidx/camera/video/QualitySelector;", "")]
	public unsafe static QualitySelector From(Quality quality)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(quality?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<QualitySelector>(_members.StaticMethods.InvokeObjectMethod("from.(Landroidx/camera/video/Quality;)Landroidx/camera/video/QualitySelector;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(quality);
		}
	}

	[Register("from", "(Landroidx/camera/video/Quality;Landroidx/camera/video/FallbackStrategy;)Landroidx/camera/video/QualitySelector;", "")]
	public unsafe static QualitySelector From(Quality quality, FallbackStrategy fallbackStrategy)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(quality?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(fallbackStrategy?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<QualitySelector>(_members.StaticMethods.InvokeObjectMethod("from.(Landroidx/camera/video/Quality;Landroidx/camera/video/FallbackStrategy;)Landroidx/camera/video/QualitySelector;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(quality);
			GC.KeepAlive(fallbackStrategy);
		}
	}

	[Register("fromOrderedList", "(Ljava/util/List;)Landroidx/camera/video/QualitySelector;", "")]
	public unsafe static QualitySelector FromOrderedList(IList<Quality> qualities)
	{
		nint num = JavaList<Quality>.ToLocalJniHandle(qualities);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<QualitySelector>(_members.StaticMethods.InvokeObjectMethod("fromOrderedList.(Ljava/util/List;)Landroidx/camera/video/QualitySelector;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(qualities);
		}
	}

	[Register("fromOrderedList", "(Ljava/util/List;Landroidx/camera/video/FallbackStrategy;)Landroidx/camera/video/QualitySelector;", "")]
	public unsafe static QualitySelector FromOrderedList(IList<Quality> qualities, FallbackStrategy fallbackStrategy)
	{
		nint num = JavaList<Quality>.ToLocalJniHandle(qualities);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(fallbackStrategy?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<QualitySelector>(_members.StaticMethods.InvokeObjectMethod("fromOrderedList.(Ljava/util/List;Landroidx/camera/video/FallbackStrategy;)Landroidx/camera/video/QualitySelector;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(qualities);
			GC.KeepAlive(fallbackStrategy);
		}
	}

	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	[Register("getQualityToResolutionMap", "(Landroidx/camera/video/VideoCapabilities;Landroidx/camera/core/DynamicRange;)Ljava/util/Map;", "")]
	public unsafe static IDictionary<Quality, Size> GetQualityToResolutionMap(IVideoCapabilities videoCapabilities, DynamicRange dynamicRange)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue((videoCapabilities == null) ? IntPtr.Zero : ((Java.Lang.Object)videoCapabilities).Handle);
			ptr[1] = new JniArgumentValue(dynamicRange?.Handle ?? IntPtr.Zero);
			return JavaDictionary<Quality, Size>.FromJniHandle(_members.StaticMethods.InvokeObjectMethod("getQualityToResolutionMap.(Landroidx/camera/video/VideoCapabilities;Landroidx/camera/core/DynamicRange;)Ljava/util/Map;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(videoCapabilities);
			GC.KeepAlive(dynamicRange);
		}
	}

	[Register("getResolution", "(Landroidx/camera/core/CameraInfo;Landroidx/camera/video/Quality;)Landroid/util/Size;", "")]
	public unsafe static Size? GetResolution(ICameraInfo cameraInfo, Quality quality)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue((cameraInfo == null) ? IntPtr.Zero : ((Java.Lang.Object)cameraInfo).Handle);
			ptr[1] = new JniArgumentValue(quality?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Size>(_members.StaticMethods.InvokeObjectMethod("getResolution.(Landroidx/camera/core/CameraInfo;Landroidx/camera/video/Quality;)Landroid/util/Size;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(cameraInfo);
			GC.KeepAlive(quality);
		}
	}

	[Obsolete("deprecated")]
	[Register("getSupportedQualities", "(Landroidx/camera/core/CameraInfo;)Ljava/util/List;", "")]
	public unsafe static IList<Quality> GetSupportedQualities(ICameraInfo cameraInfo)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((cameraInfo == null) ? IntPtr.Zero : ((Java.Lang.Object)cameraInfo).Handle);
			return JavaList<Quality>.FromJniHandle(_members.StaticMethods.InvokeObjectMethod("getSupportedQualities.(Landroidx/camera/core/CameraInfo;)Ljava/util/List;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(cameraInfo);
		}
	}

	[Obsolete("deprecated")]
	[Register("isQualitySupported", "(Landroidx/camera/core/CameraInfo;Landroidx/camera/video/Quality;)Z", "")]
	public unsafe static bool IsQualitySupported(ICameraInfo cameraInfo, Quality quality)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue((cameraInfo == null) ? IntPtr.Zero : ((Java.Lang.Object)cameraInfo).Handle);
			ptr[1] = new JniArgumentValue(quality?.Handle ?? IntPtr.Zero);
			return _members.StaticMethods.InvokeBooleanMethod("isQualitySupported.(Landroidx/camera/core/CameraInfo;Landroidx/camera/video/Quality;)Z", ptr);
		}
		finally
		{
			GC.KeepAlive(cameraInfo);
			GC.KeepAlive(quality);
		}
	}
}
