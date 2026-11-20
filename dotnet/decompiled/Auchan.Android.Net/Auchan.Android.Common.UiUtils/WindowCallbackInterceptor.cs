using System;
using System.Runtime.Versioning;
using Android.Runtime;
using Android.Views;
using Android.Views.Accessibility;
using Java.Interop;
using Java.Lang;

namespace Auchan.Android.Common.UiUtils;

public class WindowCallbackInterceptor : Java.Lang.Object, Window.ICallback, IJavaObject, IDisposable, IJavaPeerable
{
	private readonly Window _window;

	private readonly Window.ICallback? _wrappedCallback;

	public event EventHandler<MotionEvent>? BeforeDispatchTouchEvent;

	public WindowCallbackInterceptor(Window window)
	{
		_window = window;
		_wrappedCallback = window.Callback;
	}

	public static WindowCallbackInterceptor Setup(Window window)
	{
		return (WindowCallbackInterceptor)(window.Callback = new WindowCallbackInterceptor(window));
	}

	public bool DispatchGenericMotionEvent(MotionEvent e)
	{
		return _wrappedCallback?.DispatchGenericMotionEvent(e) ?? _window.SuperDispatchGenericMotionEvent(e);
	}

	public bool DispatchKeyEvent(KeyEvent e)
	{
		return _wrappedCallback?.DispatchKeyEvent(e) ?? _window.SuperDispatchKeyEvent(e);
	}

	public bool DispatchKeyShortcutEvent(KeyEvent e)
	{
		return _wrappedCallback?.DispatchKeyShortcutEvent(e) ?? _window.SuperDispatchKeyShortcutEvent(e);
	}

	public bool DispatchPopulateAccessibilityEvent(AccessibilityEvent e)
	{
		return _wrappedCallback?.DispatchPopulateAccessibilityEvent(e) ?? false;
	}

	public bool DispatchTouchEvent(MotionEvent e)
	{
		this.BeforeDispatchTouchEvent?.Invoke(this, e);
		return _wrappedCallback?.DispatchTouchEvent(e) ?? _window.SuperDispatchTouchEvent(e);
	}

	public bool DispatchTrackballEvent(MotionEvent e)
	{
		return _wrappedCallback?.DispatchTrackballEvent(e) ?? _window.SuperDispatchTrackballEvent(e);
	}

	public void OnActionModeFinished(ActionMode mode)
	{
		_wrappedCallback?.OnActionModeFinished(mode);
	}

	public void OnActionModeStarted(ActionMode mode)
	{
		_wrappedCallback?.OnActionModeStarted(mode);
	}

	public void OnAttachedToWindow()
	{
		_wrappedCallback?.OnAttachedToWindow();
	}

	public void OnContentChanged()
	{
		_wrappedCallback?.OnContentChanged();
	}

	public bool OnCreatePanelMenu(int featureId, IMenu menu)
	{
		return _wrappedCallback?.OnCreatePanelMenu(featureId, menu) ?? true;
	}

	public View? OnCreatePanelView(int featureId)
	{
		return _wrappedCallback?.OnCreatePanelView(featureId);
	}

	public void OnDetachedFromWindow()
	{
		_wrappedCallback?.OnDetachedFromWindow();
	}

	public bool OnMenuItemSelected(int featureId, IMenuItem item)
	{
		return _wrappedCallback?.OnMenuItemSelected(featureId, item) ?? true;
	}

	public bool OnMenuOpened(int featureId, IMenu menu)
	{
		return _wrappedCallback?.OnMenuOpened(featureId, menu) ?? true;
	}

	public void OnPanelClosed(int featureId, IMenu menu)
	{
		_wrappedCallback?.OnPanelClosed(featureId, menu);
	}

	public bool OnPreparePanel(int featureId, View view, IMenu menu)
	{
		return _wrappedCallback?.OnPreparePanel(featureId, view, menu) ?? true;
	}

	public bool OnSearchRequested()
	{
		return _wrappedCallback?.OnSearchRequested() ?? true;
	}

	[SupportedOSPlatform("android23.0")]
	public bool OnSearchRequested(SearchEvent searchEvent)
	{
		return _wrappedCallback?.OnSearchRequested(searchEvent) ?? true;
	}

	public void OnWindowAttributesChanged(WindowManagerLayoutParams attrs)
	{
		_wrappedCallback?.OnWindowAttributesChanged(attrs);
	}

	public void OnWindowFocusChanged(bool hasFocus)
	{
		_wrappedCallback?.OnWindowFocusChanged(hasFocus);
	}

	public ActionMode? OnWindowStartingActionMode(ActionMode.ICallback callback)
	{
		return _wrappedCallback?.OnWindowStartingActionMode(callback);
	}

	public ActionMode? OnWindowStartingActionMode(ActionMode.ICallback callback, ActionModeType type)
	{
		return _wrappedCallback?.OnWindowStartingActionMode(callback, type);
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
