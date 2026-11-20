using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;
using Java.Util;

namespace IO.Appmetrica.Analytics.Profile;

[Register("io/appmetrica/analytics/profile/BirthDateAttribute", DoNotGenerateAcw = true)]
public class BirthDateAttribute : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("io/appmetrica/analytics/profile/BirthDateAttribute", typeof(BirthDateAttribute));

	private static Delegate? cb_withAge_WithAge_I_Lio_appmetrica_analytics_profile_UserProfileUpdate_;

	private static Delegate? cb_withAgeIfUndefined_WithAgeIfUndefined_I_Lio_appmetrica_analytics_profile_UserProfileUpdate_;

	private static Delegate? cb_withBirthDate_WithBirthDate_I_Lio_appmetrica_analytics_profile_UserProfileUpdate_;

	private static Delegate? cb_withBirthDate_WithBirthDate_II_Lio_appmetrica_analytics_profile_UserProfileUpdate_;

	private static Delegate? cb_withBirthDate_WithBirthDate_III_Lio_appmetrica_analytics_profile_UserProfileUpdate_;

	private static Delegate? cb_withBirthDate_WithBirthDate_Ljava_util_Calendar__Lio_appmetrica_analytics_profile_UserProfileUpdate_;

	private static Delegate? cb_withBirthDateIfUndefined_WithBirthDateIfUndefined_I_Lio_appmetrica_analytics_profile_UserProfileUpdate_;

	private static Delegate? cb_withBirthDateIfUndefined_WithBirthDateIfUndefined_II_Lio_appmetrica_analytics_profile_UserProfileUpdate_;

	private static Delegate? cb_withBirthDateIfUndefined_WithBirthDateIfUndefined_III_Lio_appmetrica_analytics_profile_UserProfileUpdate_;

	private static Delegate? cb_withBirthDateIfUndefined_WithBirthDateIfUndefined_Ljava_util_Calendar__Lio_appmetrica_analytics_profile_UserProfileUpdate_;

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

	protected BirthDateAttribute(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	private static Delegate GetWithAge_IHandler()
	{
		if ((object)cb_withAge_WithAge_I_Lio_appmetrica_analytics_profile_UserProfileUpdate_ == null)
		{
			cb_withAge_WithAge_I_Lio_appmetrica_analytics_profile_UserProfileUpdate_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_L(n_WithAge_I));
		}
		return cb_withAge_WithAge_I_Lio_appmetrica_analytics_profile_UserProfileUpdate_;
	}

	private static nint n_WithAge_I(nint jnienv, nint native__this, int age)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<BirthDateAttribute>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).WithAge(age));
	}

	[Register("withAge", "(I)Lio/appmetrica/analytics/profile/UserProfileUpdate;", "GetWithAge_IHandler")]
	public unsafe virtual UserProfileUpdate? WithAge(int age)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(age);
		return Java.Lang.Object.GetObject<UserProfileUpdate>(_members.InstanceMethods.InvokeVirtualObjectMethod("withAge.(I)Lio/appmetrica/analytics/profile/UserProfileUpdate;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetWithAgeIfUndefined_IHandler()
	{
		if ((object)cb_withAgeIfUndefined_WithAgeIfUndefined_I_Lio_appmetrica_analytics_profile_UserProfileUpdate_ == null)
		{
			cb_withAgeIfUndefined_WithAgeIfUndefined_I_Lio_appmetrica_analytics_profile_UserProfileUpdate_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_L(n_WithAgeIfUndefined_I));
		}
		return cb_withAgeIfUndefined_WithAgeIfUndefined_I_Lio_appmetrica_analytics_profile_UserProfileUpdate_;
	}

	private static nint n_WithAgeIfUndefined_I(nint jnienv, nint native__this, int age)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<BirthDateAttribute>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).WithAgeIfUndefined(age));
	}

	[Register("withAgeIfUndefined", "(I)Lio/appmetrica/analytics/profile/UserProfileUpdate;", "GetWithAgeIfUndefined_IHandler")]
	public unsafe virtual UserProfileUpdate? WithAgeIfUndefined(int age)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(age);
		return Java.Lang.Object.GetObject<UserProfileUpdate>(_members.InstanceMethods.InvokeVirtualObjectMethod("withAgeIfUndefined.(I)Lio/appmetrica/analytics/profile/UserProfileUpdate;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetWithBirthDate_IHandler()
	{
		if ((object)cb_withBirthDate_WithBirthDate_I_Lio_appmetrica_analytics_profile_UserProfileUpdate_ == null)
		{
			cb_withBirthDate_WithBirthDate_I_Lio_appmetrica_analytics_profile_UserProfileUpdate_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_L(n_WithBirthDate_I));
		}
		return cb_withBirthDate_WithBirthDate_I_Lio_appmetrica_analytics_profile_UserProfileUpdate_;
	}

	private static nint n_WithBirthDate_I(nint jnienv, nint native__this, int year)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<BirthDateAttribute>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).WithBirthDate(year));
	}

	[Register("withBirthDate", "(I)Lio/appmetrica/analytics/profile/UserProfileUpdate;", "GetWithBirthDate_IHandler")]
	public unsafe virtual UserProfileUpdate? WithBirthDate(int year)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(year);
		return Java.Lang.Object.GetObject<UserProfileUpdate>(_members.InstanceMethods.InvokeVirtualObjectMethod("withBirthDate.(I)Lio/appmetrica/analytics/profile/UserProfileUpdate;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetWithBirthDate_IIHandler()
	{
		if ((object)cb_withBirthDate_WithBirthDate_II_Lio_appmetrica_analytics_profile_UserProfileUpdate_ == null)
		{
			cb_withBirthDate_WithBirthDate_II_Lio_appmetrica_analytics_profile_UserProfileUpdate_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPII_L(n_WithBirthDate_II));
		}
		return cb_withBirthDate_WithBirthDate_II_Lio_appmetrica_analytics_profile_UserProfileUpdate_;
	}

	private static nint n_WithBirthDate_II(nint jnienv, nint native__this, int year, int month)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<BirthDateAttribute>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).WithBirthDate(year, month));
	}

	[Register("withBirthDate", "(II)Lio/appmetrica/analytics/profile/UserProfileUpdate;", "GetWithBirthDate_IIHandler")]
	public unsafe virtual UserProfileUpdate? WithBirthDate(int year, int month)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(year);
		ptr[1] = new JniArgumentValue(month);
		return Java.Lang.Object.GetObject<UserProfileUpdate>(_members.InstanceMethods.InvokeVirtualObjectMethod("withBirthDate.(II)Lio/appmetrica/analytics/profile/UserProfileUpdate;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetWithBirthDate_IIIHandler()
	{
		if ((object)cb_withBirthDate_WithBirthDate_III_Lio_appmetrica_analytics_profile_UserProfileUpdate_ == null)
		{
			cb_withBirthDate_WithBirthDate_III_Lio_appmetrica_analytics_profile_UserProfileUpdate_ = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPIII_L(n_WithBirthDate_III));
		}
		return cb_withBirthDate_WithBirthDate_III_Lio_appmetrica_analytics_profile_UserProfileUpdate_;
	}

	private static nint n_WithBirthDate_III(nint jnienv, nint native__this, int year, int month, int dayOfMonth)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<BirthDateAttribute>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).WithBirthDate(year, month, dayOfMonth));
	}

	[Register("withBirthDate", "(III)Lio/appmetrica/analytics/profile/UserProfileUpdate;", "GetWithBirthDate_IIIHandler")]
	public unsafe virtual UserProfileUpdate? WithBirthDate(int year, int month, int dayOfMonth)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
		*ptr = new JniArgumentValue(year);
		ptr[1] = new JniArgumentValue(month);
		ptr[2] = new JniArgumentValue(dayOfMonth);
		return Java.Lang.Object.GetObject<UserProfileUpdate>(_members.InstanceMethods.InvokeVirtualObjectMethod("withBirthDate.(III)Lio/appmetrica/analytics/profile/UserProfileUpdate;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetWithBirthDate_Ljava_util_Calendar_Handler()
	{
		if ((object)cb_withBirthDate_WithBirthDate_Ljava_util_Calendar__Lio_appmetrica_analytics_profile_UserProfileUpdate_ == null)
		{
			cb_withBirthDate_WithBirthDate_Ljava_util_Calendar__Lio_appmetrica_analytics_profile_UserProfileUpdate_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_WithBirthDate_Ljava_util_Calendar_));
		}
		return cb_withBirthDate_WithBirthDate_Ljava_util_Calendar__Lio_appmetrica_analytics_profile_UserProfileUpdate_;
	}

	private static nint n_WithBirthDate_Ljava_util_Calendar_(nint jnienv, nint native__this, nint native_date)
	{
		BirthDateAttribute? birthDateAttribute = Java.Lang.Object.GetObject<BirthDateAttribute>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Calendar date = Java.Lang.Object.GetObject<Calendar>(native_date, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(birthDateAttribute.WithBirthDate(date));
	}

	[Register("withBirthDate", "(Ljava/util/Calendar;)Lio/appmetrica/analytics/profile/UserProfileUpdate;", "GetWithBirthDate_Ljava_util_Calendar_Handler")]
	public unsafe virtual UserProfileUpdate? WithBirthDate(Calendar date)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(date?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<UserProfileUpdate>(_members.InstanceMethods.InvokeVirtualObjectMethod("withBirthDate.(Ljava/util/Calendar;)Lio/appmetrica/analytics/profile/UserProfileUpdate;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(date);
		}
	}

	private static Delegate GetWithBirthDateIfUndefined_IHandler()
	{
		if ((object)cb_withBirthDateIfUndefined_WithBirthDateIfUndefined_I_Lio_appmetrica_analytics_profile_UserProfileUpdate_ == null)
		{
			cb_withBirthDateIfUndefined_WithBirthDateIfUndefined_I_Lio_appmetrica_analytics_profile_UserProfileUpdate_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_L(n_WithBirthDateIfUndefined_I));
		}
		return cb_withBirthDateIfUndefined_WithBirthDateIfUndefined_I_Lio_appmetrica_analytics_profile_UserProfileUpdate_;
	}

	private static nint n_WithBirthDateIfUndefined_I(nint jnienv, nint native__this, int year)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<BirthDateAttribute>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).WithBirthDateIfUndefined(year));
	}

	[Register("withBirthDateIfUndefined", "(I)Lio/appmetrica/analytics/profile/UserProfileUpdate;", "GetWithBirthDateIfUndefined_IHandler")]
	public unsafe virtual UserProfileUpdate? WithBirthDateIfUndefined(int year)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(year);
		return Java.Lang.Object.GetObject<UserProfileUpdate>(_members.InstanceMethods.InvokeVirtualObjectMethod("withBirthDateIfUndefined.(I)Lio/appmetrica/analytics/profile/UserProfileUpdate;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetWithBirthDateIfUndefined_IIHandler()
	{
		if ((object)cb_withBirthDateIfUndefined_WithBirthDateIfUndefined_II_Lio_appmetrica_analytics_profile_UserProfileUpdate_ == null)
		{
			cb_withBirthDateIfUndefined_WithBirthDateIfUndefined_II_Lio_appmetrica_analytics_profile_UserProfileUpdate_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPII_L(n_WithBirthDateIfUndefined_II));
		}
		return cb_withBirthDateIfUndefined_WithBirthDateIfUndefined_II_Lio_appmetrica_analytics_profile_UserProfileUpdate_;
	}

	private static nint n_WithBirthDateIfUndefined_II(nint jnienv, nint native__this, int year, int month)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<BirthDateAttribute>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).WithBirthDateIfUndefined(year, month));
	}

	[Register("withBirthDateIfUndefined", "(II)Lio/appmetrica/analytics/profile/UserProfileUpdate;", "GetWithBirthDateIfUndefined_IIHandler")]
	public unsafe virtual UserProfileUpdate? WithBirthDateIfUndefined(int year, int month)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(year);
		ptr[1] = new JniArgumentValue(month);
		return Java.Lang.Object.GetObject<UserProfileUpdate>(_members.InstanceMethods.InvokeVirtualObjectMethod("withBirthDateIfUndefined.(II)Lio/appmetrica/analytics/profile/UserProfileUpdate;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetWithBirthDateIfUndefined_IIIHandler()
	{
		if ((object)cb_withBirthDateIfUndefined_WithBirthDateIfUndefined_III_Lio_appmetrica_analytics_profile_UserProfileUpdate_ == null)
		{
			cb_withBirthDateIfUndefined_WithBirthDateIfUndefined_III_Lio_appmetrica_analytics_profile_UserProfileUpdate_ = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPIII_L(n_WithBirthDateIfUndefined_III));
		}
		return cb_withBirthDateIfUndefined_WithBirthDateIfUndefined_III_Lio_appmetrica_analytics_profile_UserProfileUpdate_;
	}

	private static nint n_WithBirthDateIfUndefined_III(nint jnienv, nint native__this, int year, int month, int dayOfMonth)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<BirthDateAttribute>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).WithBirthDateIfUndefined(year, month, dayOfMonth));
	}

	[Register("withBirthDateIfUndefined", "(III)Lio/appmetrica/analytics/profile/UserProfileUpdate;", "GetWithBirthDateIfUndefined_IIIHandler")]
	public unsafe virtual UserProfileUpdate? WithBirthDateIfUndefined(int year, int month, int dayOfMonth)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
		*ptr = new JniArgumentValue(year);
		ptr[1] = new JniArgumentValue(month);
		ptr[2] = new JniArgumentValue(dayOfMonth);
		return Java.Lang.Object.GetObject<UserProfileUpdate>(_members.InstanceMethods.InvokeVirtualObjectMethod("withBirthDateIfUndefined.(III)Lio/appmetrica/analytics/profile/UserProfileUpdate;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetWithBirthDateIfUndefined_Ljava_util_Calendar_Handler()
	{
		if ((object)cb_withBirthDateIfUndefined_WithBirthDateIfUndefined_Ljava_util_Calendar__Lio_appmetrica_analytics_profile_UserProfileUpdate_ == null)
		{
			cb_withBirthDateIfUndefined_WithBirthDateIfUndefined_Ljava_util_Calendar__Lio_appmetrica_analytics_profile_UserProfileUpdate_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_WithBirthDateIfUndefined_Ljava_util_Calendar_));
		}
		return cb_withBirthDateIfUndefined_WithBirthDateIfUndefined_Ljava_util_Calendar__Lio_appmetrica_analytics_profile_UserProfileUpdate_;
	}

	private static nint n_WithBirthDateIfUndefined_Ljava_util_Calendar_(nint jnienv, nint native__this, nint native_date)
	{
		BirthDateAttribute? birthDateAttribute = Java.Lang.Object.GetObject<BirthDateAttribute>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Calendar date = Java.Lang.Object.GetObject<Calendar>(native_date, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(birthDateAttribute.WithBirthDateIfUndefined(date));
	}

	[Register("withBirthDateIfUndefined", "(Ljava/util/Calendar;)Lio/appmetrica/analytics/profile/UserProfileUpdate;", "GetWithBirthDateIfUndefined_Ljava_util_Calendar_Handler")]
	public unsafe virtual UserProfileUpdate? WithBirthDateIfUndefined(Calendar date)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(date?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<UserProfileUpdate>(_members.InstanceMethods.InvokeVirtualObjectMethod("withBirthDateIfUndefined.(Ljava/util/Calendar;)Lio/appmetrica/analytics/profile/UserProfileUpdate;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(date);
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
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<BirthDateAttribute>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).WithValueReset());
	}

	[Register("withValueReset", "()Lio/appmetrica/analytics/profile/UserProfileUpdate;", "GetWithValueResetHandler")]
	public unsafe virtual UserProfileUpdate? WithValueReset()
	{
		return Java.Lang.Object.GetObject<UserProfileUpdate>(_members.InstanceMethods.InvokeVirtualObjectMethod("withValueReset.()Lio/appmetrica/analytics/profile/UserProfileUpdate;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}
}
