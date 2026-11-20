using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace IO.Appmetrica.Analytics.Profile;

[Register("io/appmetrica/analytics/profile/FirstPartyDataEmailSha256Attribute", DoNotGenerateAcw = true)]
public class FirstPartyDataEmailSha256Attribute : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("io/appmetrica/analytics/profile/FirstPartyDataEmailSha256Attribute", typeof(FirstPartyDataEmailSha256Attribute));

	private static Delegate? cb_withEmailValues_WithEmailValues_Ljava_lang_Iterable__Lio_appmetrica_analytics_profile_UserProfileUpdate_;

	private static Delegate? cb_withEmailValues_WithEmailValues_arrayLjava_lang_String__Lio_appmetrica_analytics_profile_UserProfileUpdate_;

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

	protected FirstPartyDataEmailSha256Attribute(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	private static Delegate GetWithEmailValues_Ljava_lang_Iterable_Handler()
	{
		if ((object)cb_withEmailValues_WithEmailValues_Ljava_lang_Iterable__Lio_appmetrica_analytics_profile_UserProfileUpdate_ == null)
		{
			cb_withEmailValues_WithEmailValues_Ljava_lang_Iterable__Lio_appmetrica_analytics_profile_UserProfileUpdate_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_WithEmailValues_Ljava_lang_Iterable_));
		}
		return cb_withEmailValues_WithEmailValues_Ljava_lang_Iterable__Lio_appmetrica_analytics_profile_UserProfileUpdate_;
	}

	private static nint n_WithEmailValues_Ljava_lang_Iterable_(nint jnienv, nint native__this, nint native_values)
	{
		FirstPartyDataEmailSha256Attribute? firstPartyDataEmailSha256Attribute = Java.Lang.Object.GetObject<FirstPartyDataEmailSha256Attribute>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IIterable values = Java.Lang.Object.GetObject<IIterable>(native_values, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(firstPartyDataEmailSha256Attribute.WithEmailValues(values));
	}

	[Register("withEmailValues", "(Ljava/lang/Iterable;)Lio/appmetrica/analytics/profile/UserProfileUpdate;", "GetWithEmailValues_Ljava_lang_Iterable_Handler")]
	public unsafe virtual UserProfileUpdate WithEmailValues(IIterable values)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((values == null) ? IntPtr.Zero : ((Java.Lang.Object)values).Handle);
			return Java.Lang.Object.GetObject<UserProfileUpdate>(_members.InstanceMethods.InvokeVirtualObjectMethod("withEmailValues.(Ljava/lang/Iterable;)Lio/appmetrica/analytics/profile/UserProfileUpdate;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(values);
		}
	}

	private static Delegate GetWithEmailValues_arrayLjava_lang_String_Handler()
	{
		if ((object)cb_withEmailValues_WithEmailValues_arrayLjava_lang_String__Lio_appmetrica_analytics_profile_UserProfileUpdate_ == null)
		{
			cb_withEmailValues_WithEmailValues_arrayLjava_lang_String__Lio_appmetrica_analytics_profile_UserProfileUpdate_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_WithEmailValues_arrayLjava_lang_String_));
		}
		return cb_withEmailValues_WithEmailValues_arrayLjava_lang_String__Lio_appmetrica_analytics_profile_UserProfileUpdate_;
	}

	private static nint n_WithEmailValues_arrayLjava_lang_String_(nint jnienv, nint native__this, nint native_values)
	{
		FirstPartyDataEmailSha256Attribute? firstPartyDataEmailSha256Attribute = Java.Lang.Object.GetObject<FirstPartyDataEmailSha256Attribute>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		string[] array = (string[])JNIEnv.GetArray(native_values, JniHandleOwnership.DoNotTransfer, typeof(string));
		nint result = JNIEnv.ToLocalJniHandle(firstPartyDataEmailSha256Attribute.WithEmailValues(array));
		if (array != null)
		{
			JNIEnv.CopyArray(array, native_values);
		}
		return result;
	}

	[Register("withEmailValues", "([Ljava/lang/String;)Lio/appmetrica/analytics/profile/UserProfileUpdate;", "GetWithEmailValues_arrayLjava_lang_String_Handler")]
	public unsafe virtual UserProfileUpdate WithEmailValues(params string[] values)
	{
		nint num = JNIEnv.NewArray(values);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<UserProfileUpdate>(_members.InstanceMethods.InvokeVirtualObjectMethod("withEmailValues.([Ljava/lang/String;)Lio/appmetrica/analytics/profile/UserProfileUpdate;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			if (values != null)
			{
				JNIEnv.CopyArray(num, values);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(values);
		}
	}
}
