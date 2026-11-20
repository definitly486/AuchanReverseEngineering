using System;
using Android.Content;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Auchan.Android.Common.UiUtils;

public class DialogInterfaceOnDismissListener : Java.Lang.Object, IDialogInterfaceOnDismissListener, IJavaObject, IDisposable, IJavaPeerable, IDialogInterfaceOnCancelListener
{
	private readonly Action _action;

	private bool _invoked;

	public DialogInterfaceOnDismissListener(Action action)
	{
		_action = action;
	}

	public void OnDismiss(IDialogInterface dialog)
	{
		if (!_invoked)
		{
			_action?.Invoke();
			_invoked = true;
		}
	}

	public void OnCancel(IDialogInterface? dialog)
	{
		if (!_invoked)
		{
			_action?.Invoke();
			_invoked = true;
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
