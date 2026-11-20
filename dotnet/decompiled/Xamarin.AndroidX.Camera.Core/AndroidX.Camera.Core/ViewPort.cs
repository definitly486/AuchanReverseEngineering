using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Android.Util;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Camera.Core;

[Register("androidx/camera/core/ViewPort", DoNotGenerateAcw = true)]
public sealed class ViewPort : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/ViewPort", typeof(ViewPort));

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

	public unsafe Rational AspectRatio
	{
		[Register("getAspectRatio", "()Landroid/util/Rational;", "")]
		get
		{
			return Java.Lang.Object.GetObject<Rational>(_members.InstanceMethods.InvokeAbstractObjectMethod("getAspectRatio.()Landroid/util/Rational;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe int LayoutDirection
	{
		[Register("getLayoutDirection", "()I", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("getLayoutDirection.()I", this, null);
		}
	}

	public unsafe int Rotation
	{
		[Register("getRotation", "()I", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("getRotation.()I", this, null);
		}
	}

	public unsafe int ScaleType
	{
		[Register("getScaleType", "()I", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("getScaleType.()I", this, null);
		}
	}

	internal ViewPort(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}
}
