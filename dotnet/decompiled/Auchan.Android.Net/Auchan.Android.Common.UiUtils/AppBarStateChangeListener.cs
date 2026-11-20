using System;
using Android.Runtime;
using Google.Android.Material.AppBar;
using Java.Interop;
using Java.Lang;

namespace Auchan.Android.Common.UiUtils;

internal class AppBarStateChangeListener : Java.Lang.Object, AppBarLayout.IOnOffsetChangedListener, IJavaObject, IDisposable, IJavaPeerable
{
	public enum State
	{
		Expanded,
		Collapsed,
		Idle
	}

	private State currentState = State.Idle;

	private readonly Action<AppBarLayout, State> onStateChanged;

	public AppBarStateChangeListener(Action<State> onStateChanged)
		: this(delegate(AppBarLayout v, State s)
		{
			onStateChanged(s);
		})
	{
	}

	public AppBarStateChangeListener(Action<AppBarLayout, State> onStateChanged)
	{
		this.onStateChanged = onStateChanged;
	}

	public void OnOffsetChanged(AppBarLayout appBarLayout, int verticalOffset)
	{
		if (verticalOffset == 0)
		{
			if (currentState != State.Expanded)
			{
				OnStateChanged(appBarLayout, State.Expanded);
			}
			currentState = State.Expanded;
		}
		else if (System.Math.Abs(verticalOffset) >= appBarLayout.TotalScrollRange)
		{
			if (currentState != State.Collapsed)
			{
				OnStateChanged(appBarLayout, State.Collapsed);
			}
			currentState = State.Collapsed;
		}
		else
		{
			if (currentState != State.Idle)
			{
				OnStateChanged(appBarLayout, State.Idle);
			}
			currentState = State.Idle;
		}
	}

	protected virtual void OnStateChanged(AppBarLayout appBarLayout, State state)
	{
		onStateChanged(appBarLayout, state);
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
