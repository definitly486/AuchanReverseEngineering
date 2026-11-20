using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace IO.Appmetrica.Analytics.Profile;

[Register("io/appmetrica/analytics/profile/StringAttribute", DoNotGenerateAcw = true)]
public class StringAttribute : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("io/appmetrica/analytics/profile/StringAttribute", typeof(StringAttribute));

	private static Delegate? cb_withValue_WithValue_Ljava_lang_String__Lio_appmetrica_analytics_profile_UserProfileUpdate_;

	private static Delegate? cb_withValueIfUndefined_WithValueIfUndefined_Ljava_lang_String__Lio_appmetrica_analytics_profile_UserProfileUpdate_;

	private static Delegate? cb_withValueReset_WithValueReset_Lio_appmetrica_analytics_profile_UserProfileUpdate_;

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

	protected StringAttribute(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	private static Delegate GetWithValue_Ljava_lang_String_Handler()
	{
		if ((object)cb_withValue_WithValue_Ljava_lang_String__Lio_appmetrica_analytics_profile_UserProfileUpdate_ == null)
		{
			cb_withValue_WithValue_Ljava_lang_String__Lio_appmetrica_analytics_profile_UserProfileUpdate_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_WithValue_Ljava_lang_String_));
		}
		return cb_withValue_WithValue_Ljava_lang_String__Lio_appmetrica_analytics_profile_UserProfileUpdate_;
	}

	private static nint n_WithValue_Ljava_lang_String_(nint jnienv, nint native__this, nint native_value)
	{
		StringAttribute? stringAttribute = Java.Lang.Object.GetObject<StringAttribute>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		string value = JNIEnv.GetString(native_value, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(stringAttribute.WithValue(value));
	}

	[Register("withValue", "(Ljava/lang/String;)Lio/appmetrica/analytics/profile/UserProfileUpdate;", "GetWithValue_Ljava_lang_String_Handler")]
	public unsafe virtual UserProfileUpdate WithValue(string value)
	{
		nint num = JNIEnv.NewString(value);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<UserProfileUpdate>(_members.InstanceMethods.InvokeVirtualObjectMethod("withValue.(Ljava/lang/String;)Lio/appmetrica/analytics/profile/UserProfileUpdate;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetWithValueIfUndefined_Ljava_lang_String_Handler()
	{
		if ((object)cb_withValueIfUndefined_WithValueIfUndefined_Ljava_lang_String__Lio_appmetrica_analytics_profile_UserProfileUpdate_ == null)
		{
			cb_withValueIfUndefined_WithValueIfUndefined_Ljava_lang_String__Lio_appmetrica_analytics_profile_UserProfileUpdate_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_WithValueIfUndefined_Ljava_lang_String_));
		}
		return cb_withValueIfUndefined_WithValueIfUndefined_Ljava_lang_String__Lio_appmetrica_analytics_profile_UserProfileUpdate_;
	}

	private static nint n_WithValueIfUndefined_Ljava_lang_String_(nint jnienv, nint native__this, nint native_value)
	{
		StringAttribute? stringAttribute = Java.Lang.Object.GetObject<StringAttribute>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		string value = JNIEnv.GetString(native_value, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(stringAttribute.WithValueIfUndefined(value));
	}

	[Register("withValueIfUndefined", "(Ljava/lang/String;)Lio/appmetrica/analytics/profile/UserProfileUpdate;", "GetWithValueIfUndefined_Ljava_lang_String_Handler")]
	public unsafe virtual UserProfileUpdate WithValueIfUndefined(string value)
	{
		nint num = JNIEnv.NewString(value);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<UserProfileUpdate>(_members.InstanceMethods.InvokeVirtualObjectMethod("withValueIfUndefined.(Ljava/lang/String;)Lio/appmetrica/analytics/profile/UserProfileUpdate;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetWithValueResetHandler()
	{
		if ((object)cb_withValueReset_WithValueReset_Lio_appmetrica_analytics_profile_UserProfileUpdate_ == null)
		{
			cb_withValueReset_WithValueReset_Lio_appmetrica_analytics_profile_UserProfileUpdate_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_WithValueReset));
		}
		return cb_withValueReset_WithValueReset_Lio_appmetrica_analytics_profile_UserProfileUpdate_;
	}

	private static nint n_WithValueReset(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<StringAttribute>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).WithValueReset());
	}

	[Register("withValueReset", "()Lio/appmetrica/analytics/profile/UserProfileUpdate;", "GetWithValueResetHandler")]
	public unsafe virtual UserProfileUpdate WithValueReset()
	{
		return Java.Lang.Object.GetObject<UserProfileUpdate>(_members.InstanceMethods.InvokeVirtualObjectMethod("withValueReset.()Lio/appmetrica/analytics/profile/UserProfileUpdate;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}
}
