using System;
using Android.Runtime;

namespace ImageViews.Photo;

[Register("com/github/chrisbanes/photoview/OnViewDragListener", "", "ImageViews.Photo.IOnViewDragListenerInvoker")]
public interface IOnViewDragListener : IJavaObject, IDisposable
{
	[Register("onDrag", "(FF)V", "GetOnDrag_FFHandler:ImageViews.Photo.IOnViewDragListenerInvoker, PhotoView")]
	void OnDrag(float deltaX, float deltaY);
}
