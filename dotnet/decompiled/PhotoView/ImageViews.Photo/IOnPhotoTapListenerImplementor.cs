using System;
using Android.Runtime;
using Android.Widget;
using Java.Lang;

namespace ImageViews.Photo;

[Register("mono/com/github/chrisbanes/photoview/OnPhotoTapListenerImplementor")]
internal sealed class IOnPhotoTapListenerImplementor : Java.Lang.Object, IOnPhotoTapListener, IJavaObject, IDisposable
{
	private object sender;

	public EventHandler<PhotoTapEventArgs> Handler;

	public IOnPhotoTapListenerImplementor(object sender)
		: base(JNIEnv.StartCreateInstance("mono/com/github/chrisbanes/photoview/OnPhotoTapListenerImplementor", "()V"), JniHandleOwnership.TransferLocalRef)
	{
		JNIEnv.FinishCreateInstance(base.Handle, "()V");
		this.sender = sender;
	}

	public void OnPhotoTap(ImageView view, float x, float y)
	{
		Handler?.Invoke(sender, new PhotoTapEventArgs(view, x, y));
	}

	internal static bool __IsEmpty(IOnPhotoTapListenerImplementor value)
	{
		return value.Handler == null;
	}
}
