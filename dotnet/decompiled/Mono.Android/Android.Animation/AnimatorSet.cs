using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Animation;

[Register("android/animation/AnimatorSet", DoNotGenerateAcw = true)]
public sealed class AnimatorSet : Animator
{
	private static Delegate cb_setDuration_SetDuration_J_Landroid_animation_Animator_;

	private static readonly JniPeerMembers _members = new XAPeerMembers("android/animation/AnimatorSet", typeof(AnimatorSet));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe override long StartDelay
	{
		[Register("setStartDelay", "(J)V", "")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeAbstractVoidMethod("setStartDelay.(J)V", this, ptr);
		}
	}

	[Register("setDuration", "(J)Landroid/animation/Animator;", "GetSetDuration_JHandler")]
	public unsafe override Animator SetDuration(long duration)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(duration);
		return Java.Lang.Object.GetObject<Animator>(_members.InstanceMethods.InvokeVirtualObjectMethod("setDuration.(J)Landroid/animation/Animator;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetSetDuration_JHandler()
	{
		return new _JniMarshal_PPJ_L(n_SetDuration_J);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_SetDuration_J(nint jnienv, nint native__this, long duration)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<AnimatorSet>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetDuration(duration));
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	internal AnimatorSet(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe AnimatorSet()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	[Register("playTogether", "([Landroid/animation/Animator;)V", "")]
	public unsafe void PlayTogether(params Animator[]? items)
	{
		nint num = JNIEnv.NewArray(items);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeAbstractVoidMethod("playTogether.([Landroid/animation/Animator;)V", this, ptr);
		}
		finally
		{
			if (items != null)
			{
				JNIEnv.CopyArray(num, items);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(items);
		}
	}

	[Register("setInterpolator", "(Landroid/animation/TimeInterpolator;)V", "")]
	public unsafe override void SetInterpolator(ITimeInterpolator? interpolator)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((interpolator == null) ? IntPtr.Zero : ((Java.Lang.Object)interpolator).Handle);
			_members.InstanceMethods.InvokeAbstractVoidMethod("setInterpolator.(Landroid/animation/TimeInterpolator;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(interpolator);
		}
	}
}
