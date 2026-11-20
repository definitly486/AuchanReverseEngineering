using System;
using Android.App;
using Android.Gms.Tasks;
using Android.Runtime;
using Java.Interop;

namespace Xamarin.Google.Android.Play.Core.Review;

[Register("com/google/android/play/core/review/ReviewManager", "", "Xamarin.Google.Android.Play.Core.Review.IReviewManagerInvoker")]
public interface IReviewManager : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("launchReviewFlow", "(Landroid/app/Activity;Lcom/google/android/play/core/review/ReviewInfo;)Lcom/google/android/gms/tasks/Task;", "GetLaunchReviewFlow_Landroid_app_Activity_Lcom_google_android_play_core_review_ReviewInfo_Handler:Xamarin.Google.Android.Play.Core.Review.IReviewManagerInvoker, Xamarin.Google.Android.Play.Review")]
	Task LaunchReviewFlow(Activity p0, ReviewInfo p1);

	[Register("requestReviewFlow", "()Lcom/google/android/gms/tasks/Task;", "GetRequestReviewFlowHandler:Xamarin.Google.Android.Play.Core.Review.IReviewManagerInvoker, Xamarin.Google.Android.Play.Review")]
	Task RequestReviewFlow();
}
