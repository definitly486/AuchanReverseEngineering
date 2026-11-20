using System;
using Android.Runtime;
using Java.Lang;

namespace ImageViews.Photo;

[Register("mono/com/github/chrisbanes/photoview/OnScaleChangedListenerImplementor")]
internal sealed class IOnScaleChangedListenerImplementor : Java.Lang.Object, IOnScaleChangedListener, IJavaObject, IDisposable
{
	private object sender;

	public EventHandler<ScaleChangedEventArgs> Handler;

	public IOnScaleChangedListenerImplementor(object sender)
		: base(JNIEnv.StartCreateInstance("mono/com/github/chrisbanes/photoview/OnScaleChangedListenerImplementor", "()V"), JniHandleOwnership.TransferLocalRef)
	{
		JNIEnv.FinishCreateInstance(base.Handle, "()V");
		this.sender = sender;
	}

	public void OnScaleChange(float scaleFactor, float focusX, float focusY)
	{
		Handler?.Invoke(sender, new ScaleChangedEventArgs(scaleFactor, focusX, focusY));
	}

	internal static bool __IsEmpty(IOnScaleChangedListenerImplementor value)
	{
		return value.Handler == null;
	}
}
