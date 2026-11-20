using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Camera.Core;

[Register("androidx/camera/core/FocusMeteringAction", DoNotGenerateAcw = true)]
public sealed class FocusMeteringAction : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/FocusMeteringAction", typeof(FocusMeteringAction));

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

	public unsafe long AutoCancelDurationInMillis
	{
		[Register("getAutoCancelDurationInMillis", "()J", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractInt64Method("getAutoCancelDurationInMillis.()J", this, null);
		}
	}

	public unsafe bool IsAutoCancelEnabled
	{
		[Register("isAutoCancelEnabled", "()Z", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("isAutoCancelEnabled.()Z", this, null);
		}
	}

	public unsafe IList<MeteringPoint> MeteringPointsAe
	{
		[Register("getMeteringPointsAe", "()Ljava/util/List;", "")]
		get
		{
			return JavaList<MeteringPoint>.FromJniHandle(_members.InstanceMethods.InvokeAbstractObjectMethod("getMeteringPointsAe.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe IList<MeteringPoint> MeteringPointsAf
	{
		[Register("getMeteringPointsAf", "()Ljava/util/List;", "")]
		get
		{
			return JavaList<MeteringPoint>.FromJniHandle(_members.InstanceMethods.InvokeAbstractObjectMethod("getMeteringPointsAf.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe IList<MeteringPoint> MeteringPointsAwb
	{
		[Register("getMeteringPointsAwb", "()Ljava/util/List;", "")]
		get
		{
			return JavaList<MeteringPoint>.FromJniHandle(_members.InstanceMethods.InvokeAbstractObjectMethod("getMeteringPointsAwb.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	internal FocusMeteringAction(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}
}
