using System;
using Android.Runtime;
using Android.Views;
using Java.Lang;

namespace ImageViews.Photo;

[Register("mono/com/github/chrisbanes/photoview/OnViewTapListenerImplementor")]
internal sealed class IOnViewTapListenerImplementor : Java.Lang.Object, IOnViewTapListener, IJavaObject, IDisposable
{
	private object sender;

	public EventHandler<ViewTapEventArgs> Handler;

	public IOnViewTapListenerImplementor(object sender)
		: base(JNIEnv.StartCreateInstance("mono/com/github/chrisbanes/photoview/OnViewTapListenerImplementor", "()V"), JniHandleOwnership.TransferLocalRef)
	{
		JNIEnv.FinishCreateInstance(base.Handle, "()V");
		this.sender = sender;
	}

	public void OnViewTap(View view, float x, float y)
	{
		Handler?.Invoke(sender, new ViewTapEventArgs(view, x, y));
	}

	internal static bool __IsEmpty(IOnViewTapListenerImplementor value)
	{
		return value.Handler == null;
	}
}
