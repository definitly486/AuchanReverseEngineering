using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.ConstraintLayout.Core.Motion.Utils;

[Register("androidx/constraintlayout/core/motion/utils/FloatRect", DoNotGenerateAcw = true)]
public class FloatRect : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/core/motion/utils/FloatRect", typeof(FloatRect));

	[Register("bottom")]
	public float Bottom
	{
		get
		{
			return _members.InstanceFields.GetSingleValue("bottom.F", this);
		}
		set
		{
			_members.InstanceFields.SetValue("bottom.F", this, value);
		}
	}

	[Register("left")]
	public float Left
	{
		get
		{
			return _members.InstanceFields.GetSingleValue("left.F", this);
		}
		set
		{
			_members.InstanceFields.SetValue("left.F", this, value);
		}
	}

	[Register("right")]
	public float Right
	{
		get
		{
			return _members.InstanceFields.GetSingleValue("right.F", this);
		}
		set
		{
			_members.InstanceFields.SetValue("right.F", this, value);
		}
	}

	[Register("top")]
	public float Top
	{
		get
		{
			return _members.InstanceFields.GetSingleValue("top.F", this);
		}
		set
		{
			_members.InstanceFields.SetValue("top.F", this, value);
		}
	}

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

	protected FloatRect(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe FloatRect()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	[Register("centerX", "()F", "")]
	public unsafe float CenterX()
	{
		return _members.InstanceMethods.InvokeNonvirtualSingleMethod("centerX.()F", this, null);
	}

	[Register("centerY", "()F", "")]
	public unsafe float CenterY()
	{
		return _members.InstanceMethods.InvokeNonvirtualSingleMethod("centerY.()F", this, null);
	}
}
