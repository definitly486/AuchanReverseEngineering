using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using AndroidX.Camera.Core.Impl;
using Java.Interop;
using Java.Lang;
using Java.Util;

namespace AndroidX.Camera.Core;

[Register("androidx/camera/core/CameraSelector", DoNotGenerateAcw = true)]
public sealed class CameraSelector : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/CameraSelector", typeof(CameraSelector));

	[Register("DEFAULT_BACK_CAMERA")]
	public static CameraSelector DefaultBackCamera => Java.Lang.Object.GetObject<CameraSelector>(_members.StaticFields.GetObjectValue("DEFAULT_BACK_CAMERA.Landroidx/camera/core/CameraSelector;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("DEFAULT_FRONT_CAMERA")]
	public static CameraSelector DefaultFrontCamera => Java.Lang.Object.GetObject<CameraSelector>(_members.StaticFields.GetObjectValue("DEFAULT_FRONT_CAMERA.Landroidx/camera/core/CameraSelector;").Handle, JniHandleOwnership.TransferLocalRef);

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

	public unsafe LinkedHashSet CameraFilterSet
	{
		[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
		[Register("getCameraFilterSet", "()Ljava/util/LinkedHashSet;", "")]
		get
		{
			return Java.Lang.Object.GetObject<LinkedHashSet>(_members.InstanceMethods.InvokeAbstractObjectMethod("getCameraFilterSet.()Ljava/util/LinkedHashSet;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe Integer? LensFacing
	{
		[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
		[Register("getLensFacing", "()Ljava/lang/Integer;", "")]
		get
		{
			return Java.Lang.Object.GetObject<Integer>(_members.InstanceMethods.InvokeAbstractObjectMethod("getLensFacing.()Ljava/lang/Integer;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe string? PhysicalCameraId
	{
		[Register("getPhysicalCameraId", "()Ljava/lang/String;", "")]
		get
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getPhysicalCameraId.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	internal CameraSelector(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	[Register("filter", "(Ljava/util/LinkedHashSet;)Ljava/util/LinkedHashSet;", "")]
	public unsafe LinkedHashSet Filter(LinkedHashSet cameras)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(cameras?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<LinkedHashSet>(_members.InstanceMethods.InvokeAbstractObjectMethod("filter.(Ljava/util/LinkedHashSet;)Ljava/util/LinkedHashSet;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(cameras);
		}
	}

	[Register("filter", "(Ljava/util/List;)Ljava/util/List;", "")]
	public unsafe IList<ICameraInfo> Filter(IList<ICameraInfo> cameraInfos)
	{
		nint num = JavaList<ICameraInfo>.ToLocalJniHandle(cameraInfos);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return JavaList<ICameraInfo>.FromJniHandle(_members.InstanceMethods.InvokeAbstractObjectMethod("filter.(Ljava/util/List;)Ljava/util/List;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(cameraInfos);
		}
	}

	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	[Register("select", "(Ljava/util/LinkedHashSet;)Landroidx/camera/core/impl/CameraInternal;", "")]
	public unsafe ICameraInternal Select(LinkedHashSet cameras)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(cameras?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<ICameraInternal>(_members.InstanceMethods.InvokeAbstractObjectMethod("select.(Ljava/util/LinkedHashSet;)Landroidx/camera/core/impl/CameraInternal;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(cameras);
		}
	}
}
