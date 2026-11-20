using System;
using Android.Runtime;
using Android.Widget;

namespace ImageViews.Photo;

[Register("com/github/chrisbanes/photoview/OnOutsidePhotoTapListener", "", "ImageViews.Photo.IOnOutsidePhotoTapListenerInvoker")]
public interface IOnOutsidePhotoTapListener : IJavaObject, IDisposable
{
	[Register("onOutsidePhotoTap", "(Landroid/widget/ImageView;)V", "GetOnOutsidePhotoTap_Landroid_widget_ImageView_Handler:ImageViews.Photo.IOnOutsidePhotoTapListenerInvoker, PhotoView")]
	void OnOutsidePhotoTap(ImageView imageView);
}
