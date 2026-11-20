using System;
using Android.Graphics;
using Android.Runtime;
using Java.Lang;

namespace ImageViews.Photo;

[Register("mono/com/github/chrisbanes/photoview/OnMatrixChangedListenerImplementor")]
internal sealed class IOnMatrixChangedListenerImplementor : Java.Lang.Object, IOnMatrixChangedListener, IJavaObject, IDisposable
{
	private object sender;

	public EventHandler<MatrixChangedEventArgs> Handler;

	public IOnMatrixChangedListenerImplementor(object sender)
		: base(JNIEnv.StartCreateInstance("mono/com/github/chrisbanes/photoview/OnMatrixChangedListenerImplementor", "()V"), JniHandleOwnership.TransferLocalRef)
	{
		JNIEnv.FinishCreateInstance(base.Handle, "()V");
		this.sender = sender;
	}

	public void OnMatrixChanged(RectF rect)
	{
		Handler?.Invoke(sender, new MatrixChangedEventArgs(rect));
	}

	internal static bool __IsEmpty(IOnMatrixChangedListenerImplementor value)
	{
		return value.Handler == null;
	}
}
