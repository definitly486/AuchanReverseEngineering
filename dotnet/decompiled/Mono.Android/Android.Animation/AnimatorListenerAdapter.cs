using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Animation;

[Register("android/animation/AnimatorListenerAdapter", DoNotGenerateAcw = true)]
public abstract class AnimatorListenerAdapter : Java.Lang.Object, Animator.IAnimatorListener, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/animation/AnimatorListenerAdapter", typeof(AnimatorListenerAdapter));

	private static Delegate? cb_onAnimationCancel_OnAnimationCancel_Landroid_animation_Animator__V;

	private static Delegate? cb_onAnimationEnd_OnAnimationEnd_Landroid_animation_Animator__V;

	private static Delegate? cb_onAnimationRepeat_OnAnimationRepeat_Landroid_animation_Animator__V;

	private static Delegate? cb_onAnimationStart_OnAnimationStart_Landroid_animation_Animator__V;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	protected AnimatorListenerAdapter(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	private static Delegate GetOnAnimationCancel_Landroid_animation_Animator_Handler()
	{
		return new _JniMarshal_PPL_V(n_OnAnimationCancel_Landroid_animation_Animator_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnAnimationCancel_Landroid_animation_Animator_(nint jnienv, nint native__this, nint native_animation)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AnimatorListenerAdapter? animatorListenerAdapter = Java.Lang.Object.GetObject<AnimatorListenerAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Animator animation = Java.Lang.Object.GetObject<Animator>(native_animation, JniHandleOwnership.DoNotTransfer);
			animatorListenerAdapter.OnAnimationCancel(animation);
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

	[Register("onAnimationCancel", "(Landroid/animation/Animator;)V", "GetOnAnimationCancel_Landroid_animation_Animator_Handler")]
	public unsafe virtual void OnAnimationCancel(Animator? animation)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(animation?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onAnimationCancel.(Landroid/animation/Animator;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(animation);
		}
	}

	private static Delegate GetOnAnimationEnd_Landroid_animation_Animator_Handler()
	{
		return new _JniMarshal_PPL_V(n_OnAnimationEnd_Landroid_animation_Animator_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnAnimationEnd_Landroid_animation_Animator_(nint jnienv, nint native__this, nint native_animation)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AnimatorListenerAdapter? animatorListenerAdapter = Java.Lang.Object.GetObject<AnimatorListenerAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Animator animation = Java.Lang.Object.GetObject<Animator>(native_animation, JniHandleOwnership.DoNotTransfer);
			animatorListenerAdapter.OnAnimationEnd(animation);
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

	[Register("onAnimationEnd", "(Landroid/animation/Animator;)V", "GetOnAnimationEnd_Landroid_animation_Animator_Handler")]
	public unsafe virtual void OnAnimationEnd(Animator? animation)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(animation?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onAnimationEnd.(Landroid/animation/Animator;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(animation);
		}
	}

	private static Delegate GetOnAnimationRepeat_Landroid_animation_Animator_Handler()
	{
		return new _JniMarshal_PPL_V(n_OnAnimationRepeat_Landroid_animation_Animator_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnAnimationRepeat_Landroid_animation_Animator_(nint jnienv, nint native__this, nint native_animation)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AnimatorListenerAdapter? animatorListenerAdapter = Java.Lang.Object.GetObject<AnimatorListenerAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Animator animation = Java.Lang.Object.GetObject<Animator>(native_animation, JniHandleOwnership.DoNotTransfer);
			animatorListenerAdapter.OnAnimationRepeat(animation);
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

	[Register("onAnimationRepeat", "(Landroid/animation/Animator;)V", "GetOnAnimationRepeat_Landroid_animation_Animator_Handler")]
	public unsafe virtual void OnAnimationRepeat(Animator? animation)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(animation?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onAnimationRepeat.(Landroid/animation/Animator;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(animation);
		}
	}

	private static Delegate GetOnAnimationStart_Landroid_animation_Animator_Handler()
	{
		return new _JniMarshal_PPL_V(n_OnAnimationStart_Landroid_animation_Animator_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnAnimationStart_Landroid_animation_Animator_(nint jnienv, nint native__this, nint native_animation)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AnimatorListenerAdapter? animatorListenerAdapter = Java.Lang.Object.GetObject<AnimatorListenerAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Animator animation = Java.Lang.Object.GetObject<Animator>(native_animation, JniHandleOwnership.DoNotTransfer);
			animatorListenerAdapter.OnAnimationStart(animation);
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

	[Register("onAnimationStart", "(Landroid/animation/Animator;)V", "GetOnAnimationStart_Landroid_animation_Animator_Handler")]
	public unsafe virtual void OnAnimationStart(Animator? animation)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(animation?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onAnimationStart.(Landroid/animation/Animator;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(animation);
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
