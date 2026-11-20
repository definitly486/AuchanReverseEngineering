using System;
using Android.Runtime;

namespace ImageViews.Photo;

[Register("com/github/chrisbanes/photoview/OnScaleChangedListener", "", "ImageViews.Photo.IOnScaleChangedListenerInvoker")]
public interface IOnScaleChangedListener : IJavaObject, IDisposable
{
	[Register("onScaleChange", "(FFF)V", "GetOnScaleChange_FFFHandler:ImageViews.Photo.IOnScaleChangedListenerInvoker, PhotoView")]
	void OnScaleChange(float scaleFactor, float focusX, float focusY);
}
