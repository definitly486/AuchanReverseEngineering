using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace IO.Appmetrica.Analytics.Profile;

[Register("io/appmetrica/analytics/profile/GenderAttribute", DoNotGenerateAcw = true)]
public class GenderAttribute : Java.Lang.Object
{
	[Register("io/appmetrica/analytics/profile/GenderAttribute$Gender", DoNotGenerateAcw = true)]
	public sealed class Gender : Java.Lang.Enum
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("io/appmetrica/analytics/profile/GenderAttribute$Gender", typeof(Gender));

		[Register("FEMALE")]
		public static Gender? Female => Java.Lang.Object.GetObject<Gender>(_members.StaticFields.GetObjectValue("FEMALE.Lio/appmetrica/analytics/profile/GenderAttribute$Gender;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("MALE")]
		public static Gender? Male => Java.Lang.Object.GetObject<Gender>(_members.StaticFields.GetObjectValue("MALE.Lio/appmetrica/analytics/profile/GenderAttribute$Gender;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("OTHER")]
		public static Gender? Other => Java.Lang.Object.GetObject<Gender>(_members.StaticFields.GetObjectValue("OTHER.Lio/appmetrica/analytics/profile/GenderAttribute$Gender;").Handle, JniHandleOwnership.TransferLocalRef);

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

		public unsafe string? StringValue
		{
			[Register("getStringValue", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getStringValue.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		internal Gender(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("valueOf", "(Ljava/lang/String;)Lio/appmetrica/analytics/profile/GenderAttribute$Gender;", "")]
		public unsafe static Gender? ValueOf(string? name)
		{
			nint num = JNIEnv.NewString(name);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				return Java.Lang.Object.GetObject<Gender>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Lio/appmetrica/analytics/profile/GenderAttribute$Gender;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}

		[Register("values", "()[Lio/appmetrica/analytics/profile/GenderAttribute$Gender;", "")]
		public unsafe static Gender[]? Values()
		{
			return (Gender[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lio/appmetrica/analytics/profile/GenderAttribute$Gender;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(Gender));
		}
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("io/appmetrica/analytics/profile/GenderAttribute", typeof(GenderAttribute));

	private static Delegate? cb_withValue_WithValue_Lio_appmetrica_analytics_profile_GenderAttribute_Gender__Lio_appmetrica_analytics_profile_UserProfileUpdate_;

	private static Delegate? cb_withValueIfUndefined_WithValueIfUndefined_Lio_appmetrica_analytics_profile_GenderAttribute_Gender__Lio_appmetrica_analytics_profile_UserProfileUpdate_;

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

	protected GenderAttribute(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	private static Delegate GetWithValue_Lio_appmetrica_analytics_profile_GenderAttribute_Gender_Handler()
	{
		if ((object)cb_withValue_WithValue_Lio_appmetrica_analytics_profile_GenderAttribute_Gender__Lio_appmetrica_analytics_profile_UserProfileUpdate_ == null)
		{
			cb_withValue_WithValue_Lio_appmetrica_analytics_profile_GenderAttribute_Gender__Lio_appmetrica_analytics_profile_UserProfileUpdate_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_WithValue_Lio_appmetrica_analytics_profile_GenderAttribute_Gender_));
		}
		return cb_withValue_WithValue_Lio_appmetrica_analytics_profile_GenderAttribute_Gender__Lio_appmetrica_analytics_profile_UserProfileUpdate_;
	}

	private static nint n_WithValue_Lio_appmetrica_analytics_profile_GenderAttribute_Gender_(nint jnienv, nint native__this, nint native_value)
	{
		GenderAttribute? genderAttribute = Java.Lang.Object.GetObject<GenderAttribute>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Gender value = Java.Lang.Object.GetObject<Gender>(native_value, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(genderAttribute.WithValue(value));
	}

	[Register("withValue", "(Lio/appmetrica/analytics/profile/GenderAttribute$Gender;)Lio/appmetrica/analytics/profile/UserProfileUpdate;", "GetWithValue_Lio_appmetrica_analytics_profile_GenderAttribute_Gender_Handler")]
	public unsafe virtual UserProfileUpdate WithValue(Gender value)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<UserProfileUpdate>(_members.InstanceMethods.InvokeVirtualObjectMethod("withValue.(Lio/appmetrica/analytics/profile/GenderAttribute$Gender;)Lio/appmetrica/analytics/profile/UserProfileUpdate;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(value);
		}
	}

	private static Delegate GetWithValueIfUndefined_Lio_appmetrica_analytics_profile_GenderAttribute_Gender_Handler()
	{
		if ((object)cb_withValueIfUndefined_WithValueIfUndefined_Lio_appmetrica_analytics_profile_GenderAttribute_Gender__Lio_appmetrica_analytics_profile_UserProfileUpdate_ == null)
		{
			cb_withValueIfUndefined_WithValueIfUndefined_Lio_appmetrica_analytics_profile_GenderAttribute_Gender__Lio_appmetrica_analytics_profile_UserProfileUpdate_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_WithValueIfUndefined_Lio_appmetrica_analytics_profile_GenderAttribute_Gender_));
		}
		return cb_withValueIfUndefined_WithValueIfUndefined_Lio_appmetrica_analytics_profile_GenderAttribute_Gender__Lio_appmetrica_analytics_profile_UserProfileUpdate_;
	}

	private static nint n_WithValueIfUndefined_Lio_appmetrica_analytics_profile_GenderAttribute_Gender_(nint jnienv, nint native__this, nint native_value)
	{
		GenderAttribute? genderAttribute = Java.Lang.Object.GetObject<GenderAttribute>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Gender value = Java.Lang.Object.GetObject<Gender>(native_value, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(genderAttribute.WithValueIfUndefined(value));
	}

	[Register("withValueIfUndefined", "(Lio/appmetrica/analytics/profile/GenderAttribute$Gender;)Lio/appmetrica/analytics/profile/UserProfileUpdate;", "GetWithValueIfUndefined_Lio_appmetrica_analytics_profile_GenderAttribute_Gender_Handler")]
	public unsafe virtual UserProfileUpdate WithValueIfUndefined(Gender value)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<UserProfileUpdate>(_members.InstanceMethods.InvokeVirtualObjectMethod("withValueIfUndefined.(Lio/appmetrica/analytics/profile/GenderAttribute$Gender;)Lio/appmetrica/analytics/profile/UserProfileUpdate;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(value);
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
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<GenderAttribute>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).WithValueReset());
	}

	[Register("withValueReset", "()Lio/appmetrica/analytics/profile/UserProfileUpdate;", "GetWithValueResetHandler")]
	public unsafe virtual UserProfileUpdate WithValueReset()
	{
		return Java.Lang.Object.GetObject<UserProfileUpdate>(_members.InstanceMethods.InvokeVirtualObjectMethod("withValueReset.()Lio/appmetrica/analytics/profile/UserProfileUpdate;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}
}
