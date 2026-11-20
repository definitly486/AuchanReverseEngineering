using System;
using Android.Runtime;
using Android.Views;

namespace ImageViews.Photo;

[Register("com/github/chrisbanes/photoview/OnSingleFlingListener", "", "ImageViews.Photo.IOnSingleFlingListenerInvoker")]
public interface IOnSingleFlingListener : IJavaObject, IDisposable
{
	[Register("onFling", "(Landroid/view/MotionEvent;Landroid/view/MotionEvent;FF)Z", "GetOnFling_Landroid_view_MotionEvent_Landroid_view_MotionEvent_FFHandler:ImageViews.Photo.IOnSingleFlingListenerInvoker, PhotoView")]
	bool OnFling(MotionEvent event1, MotionEvent event2, float velocityX, float velocityY);
}
