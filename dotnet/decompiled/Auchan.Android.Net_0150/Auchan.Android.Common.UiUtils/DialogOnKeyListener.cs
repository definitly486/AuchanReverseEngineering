using System;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Java.Interop;
using Java.Lang;

namespace Auchan.Android.Common.UiUtils;

public class DialogOnKeyListener : Java.Lang.Object, IDialogInterfaceOnKeyListener, IJavaObject, IDisposable, IJavaPeerable
{
	private Func<IDialogInterface, Keycode, KeyEvent, bool> _action;

	public DialogOnKeyListener(Func<IDialogInterface, Keycode, KeyEvent, bool> action)
	{
		_action = action;
	}

	public bool OnKey(IDialogInterface dialog, Keycode keyCode, KeyEvent e)
	{
		return _action(dialog, keyCode, e);
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
