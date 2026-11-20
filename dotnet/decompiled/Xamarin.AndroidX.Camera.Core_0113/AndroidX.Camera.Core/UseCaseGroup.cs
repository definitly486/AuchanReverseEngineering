using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Camera.Core;

[Register("androidx/camera/core/UseCaseGroup", DoNotGenerateAcw = true)]
public sealed class UseCaseGroup : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/UseCaseGroup", typeof(UseCaseGroup));

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

	public unsafe IList<CameraEffect> Effects
	{
		[Register("getEffects", "()Ljava/util/List;", "")]
		get
		{
			return JavaList<CameraEffect>.FromJniHandle(_members.InstanceMethods.InvokeAbstractObjectMethod("getEffects.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe IList<UseCase> UseCases
	{
		[Register("getUseCases", "()Ljava/util/List;", "")]
		get
		{
			return JavaList<UseCase>.FromJniHandle(_members.InstanceMethods.InvokeAbstractObjectMethod("getUseCases.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe ViewPort? ViewPort
	{
		[Register("getViewPort", "()Landroidx/camera/core/ViewPort;", "")]
		get
		{
			return Java.Lang.Object.GetObject<ViewPort>(_members.InstanceMethods.InvokeAbstractObjectMethod("getViewPort.()Landroidx/camera/core/ViewPort;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	internal UseCaseGroup(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}
}
