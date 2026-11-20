using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Animation;

[Register("android/animation/Animator", DoNotGenerateAcw = true)]
internal class AnimatorInvoker : Animator
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/animation/Animator", typeof(AnimatorInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe override long StartDelay
	{
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeAbstractVoidMethod("setStartDelay.(J)V", this, ptr);
		}
	}

	public AnimatorInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	public unsafe override Animator? SetDuration(long duration)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(duration);
		return Java.Lang.Object.GetObject<Animator>(_members.InstanceMethods.InvokeAbstractObjectMethod("setDuration.(J)Landroid/animation/Animator;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	public unsafe override void SetInterpolator(ITimeInterpolator? value)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((value == null) ? IntPtr.Zero : ((Java.Lang.Object)value).Handle);
			_members.InstanceMethods.InvokeAbstractVoidMethod("setInterpolator.(Landroid/animation/TimeInterpolator;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(value);
		}
	}
}
