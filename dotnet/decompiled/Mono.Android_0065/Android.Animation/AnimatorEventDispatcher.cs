using System;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Animation;

[Register("mono/android/animation/AnimatorEventDispatcher")]
internal class AnimatorEventDispatcher : Java.Lang.Object, Animator.IAnimatorListener, IJavaObject, IDisposable, IJavaPeerable
{
	public EventHandler? AnimationCancel;

	public EventHandler? AnimationEnd;

	public EventHandler? AnimationRepeat;

	public EventHandler? AnimationStart;

	public AnimatorEventDispatcher()
		: base(JNIEnv.StartCreateInstance("mono/android/animation/AnimatorEventDispatcher", "()V"), JniHandleOwnership.TransferLocalRef)
	{
		JNIEnv.FinishCreateInstance(base.Handle, "()V");
	}

	public void OnAnimationCancel(Animator? animation)
	{
		AnimationCancel?.Invoke(animation, EventArgs.Empty);
	}

	public void OnAnimationEnd(Animator? animation)
	{
		AnimationEnd?.Invoke(animation, EventArgs.Empty);
	}

	public void OnAnimationRepeat(Animator? animation)
	{
		AnimationRepeat?.Invoke(animation, EventArgs.Empty);
	}

	public void OnAnimationStart(Animator? animation)
	{
		AnimationStart?.Invoke(animation, EventArgs.Empty);
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
