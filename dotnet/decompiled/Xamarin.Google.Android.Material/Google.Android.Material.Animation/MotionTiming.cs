using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Animation;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Google.Android.Material.Animation;

[Register("com/google/android/material/animation/MotionTiming", DoNotGenerateAcw = true)]
public class MotionTiming : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/material/animation/MotionTiming", typeof(MotionTiming));

	private static Delegate? cb_getDelay_GetDelay_J;

	private static Delegate? cb_getDuration_GetDuration_J;

	private static Delegate? cb_getInterpolator_GetInterpolator_Landroid_animation_TimeInterpolator_;

	private static Delegate? cb_getRepeatCount_GetRepeatCount_I;

	private static Delegate? cb_getRepeatMode_GetRepeatMode_I;

	private static Delegate? cb_apply_Apply_Landroid_animation_Animator__V;

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

	public unsafe virtual long Delay
	{
		[Register("getDelay", "()J", "GetGetDelayHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt64Method("getDelay.()J", this, null);
		}
	}

	public unsafe virtual long Duration
	{
		[Register("getDuration", "()J", "GetGetDurationHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt64Method("getDuration.()J", this, null);
		}
	}

	public unsafe virtual ITimeInterpolator? Interpolator
	{
		[Register("getInterpolator", "()Landroid/animation/TimeInterpolator;", "GetGetInterpolatorHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ITimeInterpolator>(_members.InstanceMethods.InvokeVirtualObjectMethod("getInterpolator.()Landroid/animation/TimeInterpolator;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual int RepeatCount
	{
		[Register("getRepeatCount", "()I", "GetGetRepeatCountHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getRepeatCount.()I", this, null);
		}
	}

	public unsafe virtual int RepeatMode
	{
		[Register("getRepeatMode", "()I", "GetGetRepeatModeHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getRepeatMode.()I", this, null);
		}
	}

	protected MotionTiming(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(JJ)V", "")]
	public unsafe MotionTiming(long delay, long duration)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(delay);
			ptr[1] = new JniArgumentValue(duration);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(JJ)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(JJ)V", this, ptr);
		}
	}

	[Register(".ctor", "(JJLandroid/animation/TimeInterpolator;)V", "")]
	public unsafe MotionTiming(long delay, long duration, ITimeInterpolator interpolator)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(delay);
			ptr[1] = new JniArgumentValue(duration);
			ptr[2] = new JniArgumentValue((interpolator == null) ? IntPtr.Zero : ((Java.Lang.Object)interpolator).Handle);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(JJLandroid/animation/TimeInterpolator;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(JJLandroid/animation/TimeInterpolator;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(interpolator);
		}
	}

	private static Delegate GetGetDelayHandler()
	{
		return new global::_JniMarshal_PP_J(n_GetDelay);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static long n_GetDelay(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0L;
		}
		try
		{
			return Java.Lang.Object.GetObject<MotionTiming>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Delay;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0L;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetGetDurationHandler()
	{
		return new global::_JniMarshal_PP_J(n_GetDuration);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static long n_GetDuration(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0L;
		}
		try
		{
			return Java.Lang.Object.GetObject<MotionTiming>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Duration;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0L;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetGetInterpolatorHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetInterpolator);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetInterpolator(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<MotionTiming>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Interpolator);
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

	private static Delegate GetGetRepeatCountHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetRepeatCount);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetRepeatCount(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<MotionTiming>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RepeatCount;
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

	private static Delegate GetGetRepeatModeHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetRepeatMode);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetRepeatMode(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<MotionTiming>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RepeatMode;
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

	private static Delegate GetApply_Landroid_animation_Animator_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_Apply_Landroid_animation_Animator_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Apply_Landroid_animation_Animator_(nint jnienv, nint native__this, nint native_animator)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MotionTiming? motionTiming = Java.Lang.Object.GetObject<MotionTiming>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Animator animator = Java.Lang.Object.GetObject<Animator>(native_animator, JniHandleOwnership.DoNotTransfer);
			motionTiming.Apply(animator);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("apply", "(Landroid/animation/Animator;)V", "GetApply_Landroid_animation_Animator_Handler")]
	public unsafe virtual void Apply(Animator animator)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(animator?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("apply.(Landroid/animation/Animator;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(animator);
		}
	}
}
