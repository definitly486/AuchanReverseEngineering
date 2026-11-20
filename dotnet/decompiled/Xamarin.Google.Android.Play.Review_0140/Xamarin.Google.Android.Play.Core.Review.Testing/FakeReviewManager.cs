using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.App;
using Android.Content;
using Android.Gms.Tasks;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Xamarin.Google.Android.Play.Core.Review.Testing;

[Register("com/google/android/play/core/review/testing/FakeReviewManager", DoNotGenerateAcw = true)]
public class FakeReviewManager : Java.Lang.Object, IReviewManager, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/play/core/review/testing/FakeReviewManager", typeof(FakeReviewManager));

	private static Delegate? cb_launchReviewFlow_Landroid_app_Activity_Lcom_google_android_play_core_review_ReviewInfo_;

	private static Delegate? cb_requestReviewFlow;

	internal static nint class_ref => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	protected FakeReviewManager(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroid/content/Context;)V", "")]
	public unsafe FakeReviewManager(Context? context)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(context);
		}
	}

	private static Delegate GetLaunchReviewFlow_Landroid_app_Activity_Lcom_google_android_play_core_review_ReviewInfo_Handler()
	{
		if ((object)cb_launchReviewFlow_Landroid_app_Activity_Lcom_google_android_play_core_review_ReviewInfo_ == null)
		{
			cb_launchReviewFlow_Landroid_app_Activity_Lcom_google_android_play_core_review_ReviewInfo_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_LaunchReviewFlow_Landroid_app_Activity_Lcom_google_android_play_core_review_ReviewInfo_));
		}
		return cb_launchReviewFlow_Landroid_app_Activity_Lcom_google_android_play_core_review_ReviewInfo_;
	}

	private static nint n_LaunchReviewFlow_Landroid_app_Activity_Lcom_google_android_play_core_review_ReviewInfo_(nint jnienv, nint native__this, nint native_p0, nint native_reviewInfo)
	{
		FakeReviewManager? fakeReviewManager = Java.Lang.Object.GetObject<FakeReviewManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Activity p = Java.Lang.Object.GetObject<Activity>(native_p0, JniHandleOwnership.DoNotTransfer);
		ReviewInfo reviewInfo = Java.Lang.Object.GetObject<ReviewInfo>(native_reviewInfo, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(fakeReviewManager.LaunchReviewFlow(p, reviewInfo));
	}

	[Register("launchReviewFlow", "(Landroid/app/Activity;Lcom/google/android/play/core/review/ReviewInfo;)Lcom/google/android/gms/tasks/Task;", "GetLaunchReviewFlow_Landroid_app_Activity_Lcom_google_android_play_core_review_ReviewInfo_Handler")]
	public unsafe virtual Task LaunchReviewFlow(Activity p0, ReviewInfo reviewInfo)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(reviewInfo?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Task>(_members.InstanceMethods.InvokeVirtualObjectMethod("launchReviewFlow.(Landroid/app/Activity;Lcom/google/android/play/core/review/ReviewInfo;)Lcom/google/android/gms/tasks/Task;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(p0);
			GC.KeepAlive(reviewInfo);
		}
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
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<FakeReviewManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RequestReviewFlow());
	}

	[Register("requestReviewFlow", "()Lcom/google/android/gms/tasks/Task;", "GetRequestReviewFlowHandler")]
	public unsafe virtual Task RequestReviewFlow()
	{
		return Java.Lang.Object.GetObject<Task>(_members.InstanceMethods.InvokeVirtualObjectMethod("requestReviewFlow.()Lcom/google/android/gms/tasks/Task;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}
}
