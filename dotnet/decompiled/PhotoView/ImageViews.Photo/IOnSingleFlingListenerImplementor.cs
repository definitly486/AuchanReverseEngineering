using System;
using Android.Runtime;
using Android.Views;
using Java.Lang;

namespace ImageViews.Photo;

[Register("mono/com/github/chrisbanes/photoview/OnSingleFlingListenerImplementor")]
internal sealed class IOnSingleFlingListenerImplementor : Java.Lang.Object, IOnSingleFlingListener, IJavaObject, IDisposable
{
	private object sender;

	public EventHandler<SingleFlingEventArgs> Handler;

	public IOnSingleFlingListenerImplementor(object sender)
		: base(JNIEnv.StartCreateInstance("mono/com/github/chrisbanes/photoview/OnSingleFlingListenerImplementor", "()V"), JniHandleOwnership.TransferLocalRef)
	{
		JNIEnv.FinishCreateInstance(base.Handle, "()V");
		this.sender = sender;
	}

	public bool OnFling(MotionEvent event1, MotionEvent event2, float velocityX, float velocityY)
	{
		EventHandler<SingleFlingEventArgs> handler = Handler;
		if (handler == null)
		{
			return false;
		}
		SingleFlingEventArgs e = new SingleFlingEventArgs(handled: true, event1, event2, velocityX, velocityY);
		handler(sender, e);
		return e.Handled;
	}

	internal static bool __IsEmpty(IOnSingleFlingListenerImplementor value)
	{
		return value.Handler == null;
	}
}
