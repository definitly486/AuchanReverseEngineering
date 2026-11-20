using System;
using Android.Graphics;
using Android.Runtime;

namespace ImageViews.Photo;

[Register("com/github/chrisbanes/photoview/OnMatrixChangedListener", "", "ImageViews.Photo.IOnMatrixChangedListenerInvoker")]
public interface IOnMatrixChangedListener : IJavaObject, IDisposable
{
	[Register("onMatrixChanged", "(Landroid/graphics/RectF;)V", "GetOnMatrixChanged_Landroid_graphics_RectF_Handler:ImageViews.Photo.IOnMatrixChangedListenerInvoker, PhotoView")]
	void OnMatrixChanged(RectF rect);
}
