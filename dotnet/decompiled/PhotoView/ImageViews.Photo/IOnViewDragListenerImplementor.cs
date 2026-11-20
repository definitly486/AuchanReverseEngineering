using System;
using Android.Runtime;
using Java.Lang;

namespace ImageViews.Photo;

[Register("mono/com/github/chrisbanes/photoview/OnViewDragListenerImplementor")]
internal sealed class IOnViewDragListenerImplementor : Java.Lang.Object, IOnViewDragListener, IJavaObject, IDisposable
{
	private object sender;

	public EventHandler<ViewDragEventArgs> Handler;

	public IOnViewDragListenerImplementor(object sender)
		: base(JNIEnv.StartCreateInstance("mono/com/github/chrisbanes/photoview/OnViewDragListenerImplementor", "()V"), JniHandleOwnership.TransferLocalRef)
	{
		JNIEnv.FinishCreateInstance(base.Handle, "()V");
		this.sender = sender;
	}

	public void OnDrag(float deltaX, float deltaY)
	{
		Handler?.Invoke(sender, new ViewDragEventArgs(deltaX, deltaY));
	}

	internal static bool __IsEmpty(IOnViewDragListenerImplementor value)
	{
		return value.Handler == null;
	}
}
