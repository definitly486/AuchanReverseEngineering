using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.OS;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Views;

[Register("android/view/MotionEvent", DoNotGenerateAcw = true)]
public sealed class MotionEvent : InputEvent, IParcelable, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/view/MotionEvent", typeof(MotionEvent));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe MotionEventActions Action => (MotionEventActions)_members.InstanceMethods.InvokeAbstractInt32Method("getAction.()I", this, null);

	public unsafe MotionEventActions ActionMasked => (MotionEventActions)_members.InstanceMethods.InvokeAbstractInt32Method("getActionMasked.()I", this, null);

	public unsafe int HistorySize => _members.InstanceMethods.InvokeAbstractInt32Method("getHistorySize.()I", this, null);

	public unsafe int PointerCount => _members.InstanceMethods.InvokeAbstractInt32Method("getPointerCount.()I", this, null);

	public unsafe float RawX => _members.InstanceMethods.InvokeAbstractSingleMethod("getRawX.()F", this, null);

	public unsafe float RawY => _members.InstanceMethods.InvokeAbstractSingleMethod("getRawY.()F", this, null);

	internal MotionEvent(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	public unsafe int FindPointerIndex(int pointerId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(pointerId);
		return _members.InstanceMethods.InvokeAbstractInt32Method("findPointerIndex.(I)I", this, ptr);
	}

	public unsafe float GetHistoricalY(int pos)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(pos);
		return _members.InstanceMethods.InvokeAbstractSingleMethod("getHistoricalY.(I)F", this, ptr);
	}

	public unsafe int GetPointerId(int pointerIndex)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(pointerIndex);
		return _members.InstanceMethods.InvokeAbstractInt32Method("getPointerId.(I)I", this, ptr);
	}

	public unsafe float GetX()
	{
		return _members.InstanceMethods.InvokeAbstractSingleMethod("getX.()F", this, null);
	}

	public unsafe float GetX(int pointerIndex)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(pointerIndex);
		return _members.InstanceMethods.InvokeAbstractSingleMethod("getX.(I)F", this, ptr);
	}

	public unsafe float GetY()
	{
		return _members.InstanceMethods.InvokeAbstractSingleMethod("getY.()F", this, null);
	}

	public unsafe float GetY(int pointerIndex)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(pointerIndex);
		return _members.InstanceMethods.InvokeAbstractSingleMethod("getY.(I)F", this, ptr);
	}

	public unsafe static MotionEvent? Obtain(MotionEvent? other)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(other?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<MotionEvent>(_members.StaticMethods.InvokeObjectMethod("obtain.(Landroid/view/MotionEvent;)Landroid/view/MotionEvent;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(other);
		}
	}

	public unsafe static MotionEvent? Obtain(long downTime, long eventTime, MotionEventActions action, float x, float y, MetaKeyStates metaState)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[6];
		*ptr = new JniArgumentValue(downTime);
		ptr[1] = new JniArgumentValue(eventTime);
		ptr[2] = new JniArgumentValue((int)action);
		ptr[3] = new JniArgumentValue(x);
		ptr[4] = new JniArgumentValue(y);
		ptr[5] = new JniArgumentValue((int)metaState);
		return Java.Lang.Object.GetObject<MotionEvent>(_members.StaticMethods.InvokeObjectMethod("obtain.(JJIFFI)Landroid/view/MotionEvent;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	public unsafe void Recycle()
	{
		_members.InstanceMethods.InvokeAbstractVoidMethod("recycle.()V", this, null);
	}

	public unsafe override void WriteToParcel(Parcel? @out, ParcelableWriteFlags flags)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(@out?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((int)flags);
			_members.InstanceMethods.InvokeAbstractVoidMethod("writeToParcel.(Landroid/os/Parcel;I)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(@out);
		}
	}

	int IJavaPeerable.get_JniIdentityHashCode()
	{
		return base.JniIdentityHashCode;
	}

	JniObjectReference IJavaPeerable.get_PeerReference()
	{
		return base.PeerReference;
	}

	void IJavaPeerable.UnregisterFromRuntime()
	{
		UnregisterFromRuntime();
	}
}
