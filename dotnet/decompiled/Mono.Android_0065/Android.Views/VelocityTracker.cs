using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Views;

[Register("android/view/VelocityTracker", DoNotGenerateAcw = true)]
public sealed class VelocityTracker : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/view/VelocityTracker", typeof(VelocityTracker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	internal VelocityTracker(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	public unsafe void AddMovement(MotionEvent? e)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(e?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeAbstractVoidMethod("addMovement.(Landroid/view/MotionEvent;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(e);
		}
	}

	public unsafe void Clear()
	{
		_members.InstanceMethods.InvokeAbstractVoidMethod("clear.()V", this, null);
	}

	public unsafe void ComputeCurrentVelocity(int units, float maxVelocity)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(units);
		ptr[1] = new JniArgumentValue(maxVelocity);
		_members.InstanceMethods.InvokeAbstractVoidMethod("computeCurrentVelocity.(IF)V", this, ptr);
	}

	public unsafe float GetYVelocity(int id)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(id);
		return _members.InstanceMethods.InvokeAbstractSingleMethod("getYVelocity.(I)F", this, ptr);
	}

	public unsafe static VelocityTracker? Obtain()
	{
		return Java.Lang.Object.GetObject<VelocityTracker>(_members.StaticMethods.InvokeObjectMethod("obtain.()Landroid/view/VelocityTracker;", null).Handle, JniHandleOwnership.TransferLocalRef);
	}
}
