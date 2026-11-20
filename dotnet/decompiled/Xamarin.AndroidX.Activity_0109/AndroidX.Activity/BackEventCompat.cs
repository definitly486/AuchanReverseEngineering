using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Android.Window;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Activity;

[Register("androidx/activity/BackEventCompat", DoNotGenerateAcw = true)]
public sealed class BackEventCompat : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/activity/BackEventCompat", typeof(BackEventCompat));

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

	public unsafe float Progress
	{
		[Register("getProgress", "()F", "")]
		get
		{
			return _members.InstanceMethods.InvokeNonvirtualSingleMethod("getProgress.()F", this, null);
		}
	}

	public unsafe int SwipeEdge
	{
		[Register("getSwipeEdge", "()I", "")]
		get
		{
			return _members.InstanceMethods.InvokeNonvirtualInt32Method("getSwipeEdge.()I", this, null);
		}
	}

	public unsafe float TouchX
	{
		[Register("getTouchX", "()F", "")]
		get
		{
			return _members.InstanceMethods.InvokeNonvirtualSingleMethod("getTouchX.()F", this, null);
		}
	}

	public unsafe float TouchY
	{
		[Register("getTouchY", "()F", "")]
		get
		{
			return _members.InstanceMethods.InvokeNonvirtualSingleMethod("getTouchY.()F", this, null);
		}
	}

	internal BackEventCompat(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroid/window/BackEvent;)V", "")]
	public unsafe BackEventCompat(BackEvent backEvent)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(backEvent?.Handle ?? IntPtr.Zero);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/window/BackEvent;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/window/BackEvent;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(backEvent);
		}
	}

	[Register(".ctor", "(FFFI)V", "")]
	public unsafe BackEventCompat(float touchX, float touchY, float progress, int swipeEdge)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(touchX);
			ptr[1] = new JniArgumentValue(touchY);
			ptr[2] = new JniArgumentValue(progress);
			ptr[3] = new JniArgumentValue(swipeEdge);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(FFFI)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(FFFI)V", this, ptr);
		}
	}

	[Register("toBackEvent", "()Landroid/window/BackEvent;", "")]
	public unsafe BackEvent ToBackEvent()
	{
		return Java.Lang.Object.GetObject<BackEvent>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("toBackEvent.()Landroid/window/BackEvent;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}
}
