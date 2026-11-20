using System;
using Android.Runtime;
using Android.Widget;
using Java.Lang;

namespace ImageViews.Photo;

[Register("mono/com/github/chrisbanes/photoview/OnOutsidePhotoTapListenerImplementor")]
internal sealed class IOnOutsidePhotoTapListenerImplementor : Java.Lang.Object, IOnOutsidePhotoTapListener, IJavaObject, IDisposable
{
	private object sender;

	public EventHandler<OutsidePhotoTapEventArgs> Handler;

	public IOnOutsidePhotoTapListenerImplementor(object sender)
		: base(JNIEnv.StartCreateInstance("mono/com/github/chrisbanes/photoview/OnOutsidePhotoTapListenerImplementor", "()V"), JniHandleOwnership.TransferLocalRef)
	{
		JNIEnv.FinishCreateInstance(base.Handle, "()V");
		this.sender = sender;
	}

	public void OnOutsidePhotoTap(ImageView imageView)
	{
		Handler?.Invoke(sender, new OutsidePhotoTapEventArgs(imageView));
	}

	internal static bool __IsEmpty(IOnOutsidePhotoTapListenerImplementor value)
	{
		return value.Handler == null;
	}
}
