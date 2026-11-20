using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Camera.Core.Impl;

[Register("androidx/camera/core/impl/UseCaseConfigFactory$CaptureType", DoNotGenerateAcw = true)]
public sealed class UseCaseConfigFactoryCaptureType : Java.Lang.Enum
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/impl/UseCaseConfigFactory$CaptureType", typeof(UseCaseConfigFactoryCaptureType));

	[Register("IMAGE_ANALYSIS")]
	public static UseCaseConfigFactoryCaptureType? ImageAnalysis => Java.Lang.Object.GetObject<UseCaseConfigFactoryCaptureType>(_members.StaticFields.GetObjectValue("IMAGE_ANALYSIS.Landroidx/camera/core/impl/UseCaseConfigFactory$CaptureType;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("IMAGE_CAPTURE")]
	public static UseCaseConfigFactoryCaptureType? ImageCapture => Java.Lang.Object.GetObject<UseCaseConfigFactoryCaptureType>(_members.StaticFields.GetObjectValue("IMAGE_CAPTURE.Landroidx/camera/core/impl/UseCaseConfigFactory$CaptureType;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("METERING_REPEATING")]
	public static UseCaseConfigFactoryCaptureType? MeteringRepeating => Java.Lang.Object.GetObject<UseCaseConfigFactoryCaptureType>(_members.StaticFields.GetObjectValue("METERING_REPEATING.Landroidx/camera/core/impl/UseCaseConfigFactory$CaptureType;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("PREVIEW")]
	public static UseCaseConfigFactoryCaptureType? Preview => Java.Lang.Object.GetObject<UseCaseConfigFactoryCaptureType>(_members.StaticFields.GetObjectValue("PREVIEW.Landroidx/camera/core/impl/UseCaseConfigFactory$CaptureType;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("STREAM_SHARING")]
	public static UseCaseConfigFactoryCaptureType? StreamSharing => Java.Lang.Object.GetObject<UseCaseConfigFactoryCaptureType>(_members.StaticFields.GetObjectValue("STREAM_SHARING.Landroidx/camera/core/impl/UseCaseConfigFactory$CaptureType;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("VIDEO_CAPTURE")]
	public static UseCaseConfigFactoryCaptureType? VideoCapture => Java.Lang.Object.GetObject<UseCaseConfigFactoryCaptureType>(_members.StaticFields.GetObjectValue("VIDEO_CAPTURE.Landroidx/camera/core/impl/UseCaseConfigFactory$CaptureType;").Handle, JniHandleOwnership.TransferLocalRef);

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

	internal UseCaseConfigFactoryCaptureType(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register("valueOf", "(Ljava/lang/String;)Landroidx/camera/core/impl/UseCaseConfigFactory$CaptureType;", "")]
	public unsafe static UseCaseConfigFactoryCaptureType? ValueOf(string? name)
	{
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<UseCaseConfigFactoryCaptureType>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Landroidx/camera/core/impl/UseCaseConfigFactory$CaptureType;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	[Register("values", "()[Landroidx/camera/core/impl/UseCaseConfigFactory$CaptureType;", "")]
	public unsafe static UseCaseConfigFactoryCaptureType[]? Values()
	{
		return (UseCaseConfigFactoryCaptureType[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Landroidx/camera/core/impl/UseCaseConfigFactory$CaptureType;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(UseCaseConfigFactoryCaptureType));
	}
}
