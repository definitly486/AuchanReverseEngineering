using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.App;
using Android.Gms.Tasks;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Xamarin.Google.Android.Play.Core.Review;

[Register("com/google/android/play/core/review/ReviewManager", DoNotGenerateAcw = true)]
internal class IReviewManagerInvoker : Java.Lang.Object, IReviewManager, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/play/core/review/ReviewManager", typeof(IReviewManagerInvoker));

	private nint class_ref;

	private static Delegate? cb_launchReviewFlow_Landroid_app_Activity_Lcom_google_android_play_core_review_ReviewInfo_;

	private nint id_launchReviewFlow_Landroid_app_Activity_Lcom_google_android_play_core_review_ReviewInfo_;

	private static Delegate? cb_requestReviewFlow;

	private nint id_requestReviewFlow;

	private static nint java_class_ref => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => class_ref;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public static IReviewManager? GetObject(nint handle, JniHandleOwnership transfer)
	{
		return Java.Lang.Object.GetObject<IReviewManager>(handle, transfer);
	}

	private static nint Validate(nint handle)
	{
		if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
		{
			throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'com.google.android.play.core.review.ReviewManager'.");
		}
		return handle;
	}

	protected override void Dispose(bool disposing)
	{
		if (class_ref != IntPtr.Zero)
		{
			JNIEnv.DeleteGlobalRef(class_ref);
		}
		class_ref = IntPtr.Zero;
		base.Dispose(disposing);
	}

	public IReviewManagerInvoker(nint handle, JniHandleOwnership transfer)
		: base(Validate(handle), transfer)
	{
		nint objectClass = JNIEnv.GetObjectClass(base.Handle);
		class_ref = JNIEnv.NewGlobalRef(objectClass);
		JNIEnv.DeleteLocalRef(objectClass);
	}

	private static Delegate GetLaunchReviewFlow_Landroid_app_Activity_Lcom_google_android_play_core_review_ReviewInfo_Handler()
	{
		if ((object)cb_launchReviewFlow_Landroid_app_Activity_Lcom_google_android_play_core_review_ReviewInfo_ == null)
		{
			cb_launchReviewFlow_Landroid_app_Activity_Lcom_google_android_play_core_review_ReviewInfo_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_LaunchReviewFlow_Landroid_app_Activity_Lcom_google_android_play_core_review_ReviewInfo_));
		}
		return cb_launchReviewFlow_Landroid_app_Activity_Lcom_google_android_play_core_review_ReviewInfo_;
	}

	private static nint n_LaunchReviewFlow_Landroid_app_Activity_Lcom_google_android_play_core_review_ReviewInfo_(nint jnienv, nint native__this, nint native_p0, nint native_p1)
	{
		IReviewManager? reviewManager = Java.Lang.Object.GetObject<IReviewManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Activity p = Java.Lang.Object.GetObject<Activity>(native_p0, JniHandleOwnership.DoNotTransfer);
		ReviewInfo p2 = Java.Lang.Object.GetObject<ReviewInfo>(native_p1, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(reviewManager.LaunchReviewFlow(p, p2));
	}

	public unsafe Task LaunchReviewFlow(Activity p0, ReviewInfo p1)
	{
		if (id_launchReviewFlow_Landroid_app_Activity_Lcom_google_android_play_core_review_ReviewInfo_ == IntPtr.Zero)
		{
			id_launchReviewFlow_Landroid_app_Activity_Lcom_google_android_play_core_review_ReviewInfo_ = JNIEnv.GetMethodID(class_ref, "launchReviewFlow", "(Landroid/app/Activity;Lcom/google/android/play/core/review/ReviewInfo;)Lcom/google/android/gms/tasks/Task;");
		}
		JValue* ptr = stackalloc JValue[2];
		*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
		ptr[1] = new JValue(p1?.Handle ?? IntPtr.Zero);
		return Java.Lang.Object.GetObject<Task>(JNIEnv.CallObjectMethod(base.Handle, id_launchReviewFlow_Landroid_app_Activity_Lcom_google_android_play_core_review_ReviewInfo_, ptr), JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetRequestReviewFlowHandler()
	{
		if ((object)cb_requestReviewFlow == null)
		{
			cb_requestReviewFlow = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_RequestReviewFlow));
		}
		return cb_requestReviewFlow;
	}

	private static nint n_RequestReviewFlow(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IReviewManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RequestReviewFlow());
	}

	public Task RequestReviewFlow()
	{
		if (id_requestReviewFlow == IntPtr.Zero)
		{
			id_requestReviewFlow = JNIEnv.GetMethodID(class_ref, "requestReviewFlow", "()Lcom/google/android/gms/tasks/Task;");
		}
		return Java.Lang.Object.GetObject<Task>(JNIEnv.CallObjectMethod(base.Handle, id_requestReviewFlow), JniHandleOwnership.TransferLocalRef);
	}
}
