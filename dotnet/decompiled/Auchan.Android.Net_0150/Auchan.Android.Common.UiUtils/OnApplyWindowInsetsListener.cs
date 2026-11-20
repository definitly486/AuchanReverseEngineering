using System;
using Android.Runtime;
using Android.Views;
using AndroidX.Core.View;
using Java.Interop;
using Java.Lang;

namespace Auchan.Android.Common.UiUtils;

internal sealed class OnApplyWindowInsetsListener : Java.Lang.Object, IOnApplyWindowInsetsListener, IJavaObject, IDisposable, IJavaPeerable
{
	private readonly Action<WindowInsetsCompat> _onInsetsChanged;

	public OnApplyWindowInsetsListener(Action<WindowInsetsCompat> OnInsetsChanged)
	{
		_onInsetsChanged = OnInsetsChanged;
	}

	public WindowInsetsCompat? OnApplyWindowInsets(View? v, WindowInsetsCompat? insets)
	{
		if (insets != null)
		{
			_onInsetsChanged(insets);
		}
		return insets;
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
