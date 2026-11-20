using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Telephony;

[Register("android/telephony/PhoneNumberUtils", DoNotGenerateAcw = true)]
public class PhoneNumberUtils : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/telephony/PhoneNumberUtils", typeof(PhoneNumberUtils));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	protected PhoneNumberUtils(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	public unsafe static string? FormatNumber(string? phoneNumber, string? defaultCountryIso)
	{
		nint num = JNIEnv.NewString(phoneNumber);
		nint num2 = JNIEnv.NewString(defaultCountryIso);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(num2);
			return JNIEnv.GetString(_members.StaticMethods.InvokeObjectMethod("formatNumber.(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			JNIEnv.DeleteLocalRef(num2);
		}
	}
}
