using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace IO.Appmetrica.Analytics.Profile;

[Register("io/appmetrica/analytics/profile/Attribute", DoNotGenerateAcw = true)]
public sealed class Attribute : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("io/appmetrica/analytics/profile/Attribute", typeof(Attribute));

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

	internal Attribute(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register("birthDate", "()Lio/appmetrica/analytics/profile/BirthDateAttribute;", "")]
	public unsafe static BirthDateAttribute BirthDate()
	{
		return Java.Lang.Object.GetObject<BirthDateAttribute>(_members.StaticMethods.InvokeObjectMethod("birthDate.()Lio/appmetrica/analytics/profile/BirthDateAttribute;", null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("customBoolean", "(Ljava/lang/String;)Lio/appmetrica/analytics/profile/BooleanAttribute;", "")]
	public unsafe static BooleanAttribute CustomBoolean(string key)
	{
		nint num = JNIEnv.NewString(key);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<BooleanAttribute>(_members.StaticMethods.InvokeObjectMethod("customBoolean.(Ljava/lang/String;)Lio/appmetrica/analytics/profile/BooleanAttribute;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	[Register("customCounter", "(Ljava/lang/String;)Lio/appmetrica/analytics/profile/CounterAttribute;", "")]
	public unsafe static CounterAttribute CustomCounter(string key)
	{
		nint num = JNIEnv.NewString(key);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<CounterAttribute>(_members.StaticMethods.InvokeObjectMethod("customCounter.(Ljava/lang/String;)Lio/appmetrica/analytics/profile/CounterAttribute;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	[Register("customNumber", "(Ljava/lang/String;)Lio/appmetrica/analytics/profile/NumberAttribute;", "")]
	public unsafe static NumberAttribute CustomNumber(string key)
	{
		nint num = JNIEnv.NewString(key);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<NumberAttribute>(_members.StaticMethods.InvokeObjectMethod("customNumber.(Ljava/lang/String;)Lio/appmetrica/analytics/profile/NumberAttribute;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	[Register("customString", "(Ljava/lang/String;)Lio/appmetrica/analytics/profile/StringAttribute;", "")]
	public unsafe static StringAttribute CustomString(string key)
	{
		nint num = JNIEnv.NewString(key);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<StringAttribute>(_members.StaticMethods.InvokeObjectMethod("customString.(Ljava/lang/String;)Lio/appmetrica/analytics/profile/StringAttribute;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	[Register("emailHash", "()Lio/appmetrica/analytics/profile/FirstPartyDataEmailSha256Attribute;", "")]
	public unsafe static FirstPartyDataEmailSha256Attribute EmailHash()
	{
		return Java.Lang.Object.GetObject<FirstPartyDataEmailSha256Attribute>(_members.StaticMethods.InvokeObjectMethod("emailHash.()Lio/appmetrica/analytics/profile/FirstPartyDataEmailSha256Attribute;", null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("gender", "()Lio/appmetrica/analytics/profile/GenderAttribute;", "")]
	public unsafe static GenderAttribute Gender()
	{
		return Java.Lang.Object.GetObject<GenderAttribute>(_members.StaticMethods.InvokeObjectMethod("gender.()Lio/appmetrica/analytics/profile/GenderAttribute;", null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("name", "()Lio/appmetrica/analytics/profile/NameAttribute;", "")]
	public unsafe static NameAttribute Name()
	{
		return Java.Lang.Object.GetObject<NameAttribute>(_members.StaticMethods.InvokeObjectMethod("name.()Lio/appmetrica/analytics/profile/NameAttribute;", null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("notificationsEnabled", "()Lio/appmetrica/analytics/profile/NotificationsEnabledAttribute;", "")]
	public unsafe static NotificationsEnabledAttribute NotificationsEnabled()
	{
		return Java.Lang.Object.GetObject<NotificationsEnabledAttribute>(_members.StaticMethods.InvokeObjectMethod("notificationsEnabled.()Lio/appmetrica/analytics/profile/NotificationsEnabledAttribute;", null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("phoneHash", "()Lio/appmetrica/analytics/profile/FirstPartyDataPhoneSha256Attribute;", "")]
	public unsafe static FirstPartyDataPhoneSha256Attribute PhoneHash()
	{
		return Java.Lang.Object.GetObject<FirstPartyDataPhoneSha256Attribute>(_members.StaticMethods.InvokeObjectMethod("phoneHash.()Lio/appmetrica/analytics/profile/FirstPartyDataPhoneSha256Attribute;", null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("telegramLoginHash", "()Lio/appmetrica/analytics/profile/FirstPartyDataTelegramLoginSha256Attribute;", "")]
	public unsafe static FirstPartyDataTelegramLoginSha256Attribute TelegramLoginHash()
	{
		return Java.Lang.Object.GetObject<FirstPartyDataTelegramLoginSha256Attribute>(_members.StaticMethods.InvokeObjectMethod("telegramLoginHash.()Lio/appmetrica/analytics/profile/FirstPartyDataTelegramLoginSha256Attribute;", null).Handle, JniHandleOwnership.TransferLocalRef);
	}
}
