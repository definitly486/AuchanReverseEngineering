using System;
using Android.Runtime;
using Android.Widget;

namespace ImageViews.Photo;

[Register("com/github/chrisbanes/photoview/OnPhotoTapListener", "", "ImageViews.Photo.IOnPhotoTapListenerInvoker")]
public interface IOnPhotoTapListener : IJavaObject, IDisposable
{
	[Register("onPhotoTap", "(Landroid/widget/ImageView;FF)V", "GetOnPhotoTap_Landroid_widget_ImageView_FFHandler:ImageViews.Photo.IOnPhotoTapListenerInvoker, PhotoView")]
	void OnPhotoTap(ImageView view, float x, float y);
}
