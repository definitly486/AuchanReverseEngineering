using System;
using Android.Animation;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Auchan.Android.Controls;

public class AnimationListener : Java.Lang.Object, Animator.IAnimatorListener, IJavaObject, IDisposable, IJavaPeerable
{
	private readonly ICustomAnimationListener _listener;

	private readonly int _position;

	private readonly DotDirection _dotDirection;

	public AnimationListener(ICustomAnimationListener listener, int position, DotDirection dotDirection)
	{
		_listener = listener;
		_position = position;
		_dotDirection = dotDirection;
	}

	public void OnAnimationCancel(Animator animation)
	{
	}

	public void OnAnimationEnd(Animator animation)
	{
		if (_listener != null)
		{
			_listener.OnAnimationEnd(_dotDirection, _position);
		}
	}

	public void OnAnimationRepeat(Animator animation)
	{
	}

	public void OnAnimationStart(Animator animation)
	{
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
