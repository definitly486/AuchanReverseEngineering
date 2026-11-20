using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace IO.Appmetrica.Analytics.Profile;

[Register("io/appmetrica/analytics/profile/BooleanAttribute", DoNotGenerateAcw = true)]
public class BooleanAttribute : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("io/appmetrica/analytics/profile/BooleanAttribute", typeof(BooleanAttribute));

	private static Delegate? cb_withValue_WithValue_Z_Lio_appmetrica_analytics_profile_UserProfileUpdate_;

	private static Delegate? cb_withValueIfUndefined_WithValueIfUndefined_Z_Lio_appmetrica_analytics_profile_UserProfileUpdate_;

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

	protected BooleanAttribute(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	private static Delegate GetWithValue_ZHandler()
	{
		if ((object)cb_withValue_WithValue_Z_Lio_appmetrica_analytics_profile_UserProfileUpdate_ == null)
		{
			cb_withValue_WithValue_Z_Lio_appmetrica_analytics_profile_UserProfileUpdate_ = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPZ_L(n_WithValue_Z));
		}
		return cb_withValue_WithValue_Z_Lio_appmetrica_analytics_profile_UserProfileUpdate_;
	}

	private static nint n_WithValue_Z(nint jnienv, nint native__this, bool value)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<BooleanAttribute>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).WithValue(value));
	}

	[Register("withValue", "(Z)Lio/appmetrica/analytics/profile/UserProfileUpdate;", "GetWithValue_ZHandler")]
	public unsafe virtual UserProfileUpdate WithValue(bool value)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(value);
		return Java.Lang.Object.GetObject<UserProfileUpdate>(_members.InstanceMethods.InvokeVirtualObjectMethod("withValue.(Z)Lio/appmetrica/analytics/profile/UserProfileUpdate;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetWithValueIfUndefined_ZHandler()
	{
		if ((object)cb_withValueIfUndefined_WithValueIfUndefined_Z_Lio_appmetrica_analytics_profile_UserProfileUpdate_ == null)
		{
			cb_withValueIfUndefined_WithValueIfUndefined_Z_Lio_appmetrica_analytics_profile_UserProfileUpdate_ = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPZ_L(n_WithValueIfUndefined_Z));
		}
		return cb_withValueIfUndefined_WithValueIfUndefined_Z_Lio_appmetrica_analytics_profile_UserProfileUpdate_;
	}

	private static nint n_WithValueIfUndefined_Z(nint jnienv, nint native__this, bool value)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<BooleanAttribute>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).WithValueIfUndefined(value));
	}

	[Register("withValueIfUndefined", "(Z)Lio/appmetrica/analytics/profile/UserProfileUpdate;", "GetWithValueIfUndefined_ZHandler")]
	public unsafe virtual UserProfileUpdate WithValueIfUndefined(bool value)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(value);
		return Java.Lang.Object.GetObject<UserProfileUpdate>(_members.InstanceMethods.InvokeVirtualObjectMethod("withValueIfUndefined.(Z)Lio/appmetrica/analytics/profile/UserProfileUpdate;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
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
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<BooleanAttribute>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).WithValueReset());
	}

	[Register("withValueReset", "()Lio/appmetrica/analytics/profile/UserProfileUpdate;", "GetWithValueResetHandler")]
	public unsafe virtual UserProfileUpdate WithValueReset()
	{
		return Java.Lang.Object.GetObject<UserProfileUpdate>(_members.InstanceMethods.InvokeVirtualObjectMethod("withValueReset.()Lio/appmetrica/analytics/profile/UserProfileUpdate;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}
}
