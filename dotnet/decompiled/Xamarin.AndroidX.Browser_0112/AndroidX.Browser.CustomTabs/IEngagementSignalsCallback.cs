using System;
using Android.OS;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Browser.CustomTabs;

[Register("androidx/browser/customtabs/EngagementSignalsCallback", "", "AndroidX.Browser.CustomTabs.IEngagementSignalsCallbackInvoker")]
public interface IEngagementSignalsCallback : IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/browser/customtabs/EngagementSignalsCallback", typeof(IEngagementSignalsCallback), isInterface: true);

	private static Delegate? cb_onGreatestScrollPercentageIncreased_ILandroid_os_Bundle_;

	private static Delegate? cb_onSessionEnded_ZLandroid_os_Bundle_;

	private static Delegate? cb_onVerticalScrollEvent_ZLandroid_os_Bundle_;

	private static Delegate GetOnGreatestScrollPercentageIncreased_ILandroid_os_Bundle_Handler()
	{
		if ((object)cb_onGreatestScrollPercentageIncreased_ILandroid_os_Bundle_ == null)
		{
			cb_onGreatestScrollPercentageIncreased_ILandroid_os_Bundle_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPIL_V(n_OnGreatestScrollPercentageIncreased_ILandroid_os_Bundle_));
		}
		return cb_onGreatestScrollPercentageIncreased_ILandroid_os_Bundle_;
	}

	private static void n_OnGreatestScrollPercentageIncreased_ILandroid_os_Bundle_(nint jnienv, nint native__this, int scrollPercentage, nint native_extras)
	{
		IEngagementSignalsCallback? engagementSignalsCallback = Java.Lang.Object.GetObject<IEngagementSignalsCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Bundle extras = Java.Lang.Object.GetObject<Bundle>(native_extras, JniHandleOwnership.DoNotTransfer);
		engagementSignalsCallback.OnGreatestScrollPercentageIncreased(scrollPercentage, extras);
	}

	[Register("onGreatestScrollPercentageIncreased", "(ILandroid/os/Bundle;)V", "GetOnGreatestScrollPercentageIncreased_ILandroid_os_Bundle_Handler:AndroidX.Browser.CustomTabs.IEngagementSignalsCallback, Xamarin.AndroidX.Browser")]
	unsafe void OnGreatestScrollPercentageIncreased(int scrollPercentage, Bundle extras)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(scrollPercentage);
			ptr[1] = new JniArgumentValue(extras?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onGreatestScrollPercentageIncreased.(ILandroid/os/Bundle;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(extras);
		}
	}

	private static Delegate GetOnSessionEnded_ZLandroid_os_Bundle_Handler()
	{
		if ((object)cb_onSessionEnded_ZLandroid_os_Bundle_ == null)
		{
			cb_onSessionEnded_ZLandroid_os_Bundle_ = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPZL_V(n_OnSessionEnded_ZLandroid_os_Bundle_));
		}
		return cb_onSessionEnded_ZLandroid_os_Bundle_;
	}

	private static void n_OnSessionEnded_ZLandroid_os_Bundle_(nint jnienv, nint native__this, bool didUserInteract, nint native_extras)
	{
		IEngagementSignalsCallback? engagementSignalsCallback = Java.Lang.Object.GetObject<IEngagementSignalsCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Bundle extras = Java.Lang.Object.GetObject<Bundle>(native_extras, JniHandleOwnership.DoNotTransfer);
		engagementSignalsCallback.OnSessionEnded(didUserInteract, extras);
	}

	[Register("onSessionEnded", "(ZLandroid/os/Bundle;)V", "GetOnSessionEnded_ZLandroid_os_Bundle_Handler:AndroidX.Browser.CustomTabs.IEngagementSignalsCallback, Xamarin.AndroidX.Browser")]
	unsafe void OnSessionEnded(bool didUserInteract, Bundle extras)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(didUserInteract);
			ptr[1] = new JniArgumentValue(extras?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onSessionEnded.(ZLandroid/os/Bundle;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(extras);
		}
	}

	private static Delegate GetOnVerticalScrollEvent_ZLandroid_os_Bundle_Handler()
	{
		if ((object)cb_onVerticalScrollEvent_ZLandroid_os_Bundle_ == null)
		{
			cb_onVerticalScrollEvent_ZLandroid_os_Bundle_ = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPZL_V(n_OnVerticalScrollEvent_ZLandroid_os_Bundle_));
		}
		return cb_onVerticalScrollEvent_ZLandroid_os_Bundle_;
	}

	private static void n_OnVerticalScrollEvent_ZLandroid_os_Bundle_(nint jnienv, nint native__this, bool isDirectionUp, nint native_extras)
	{
		IEngagementSignalsCallback? engagementSignalsCallback = Java.Lang.Object.GetObject<IEngagementSignalsCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Bundle extras = Java.Lang.Object.GetObject<Bundle>(native_extras, JniHandleOwnership.DoNotTransfer);
		engagementSignalsCallback.OnVerticalScrollEvent(isDirectionUp, extras);
	}

	[Register("onVerticalScrollEvent", "(ZLandroid/os/Bundle;)V", "GetOnVerticalScrollEvent_ZLandroid_os_Bundle_Handler:AndroidX.Browser.CustomTabs.IEngagementSignalsCallback, Xamarin.AndroidX.Browser")]
	unsafe void OnVerticalScrollEvent(bool isDirectionUp, Bundle extras)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(isDirectionUp);
			ptr[1] = new JniArgumentValue(extras?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onVerticalScrollEvent.(ZLandroid/os/Bundle;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(extras);
		}
	}
}
