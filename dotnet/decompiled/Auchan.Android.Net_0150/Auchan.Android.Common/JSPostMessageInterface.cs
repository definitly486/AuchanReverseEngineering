using System;
using Android.Webkit;
using Java.Interop;
using Java.Lang;

namespace Auchan.Android.Common;

public class JSPostMessageInterface : Java.Lang.Object
{
	public Action<string> OnMessageReceived;

	public JSPostMessageInterface(Action<string> onMessageReceived)
	{
		OnMessageReceived = onMessageReceived;
	}

	[JavascriptInterface]
	[Export("OnPostMessage")]
	public void OnPostMessage(string message)
	{
		OnMessageReceived?.Invoke(message);
	}
}
