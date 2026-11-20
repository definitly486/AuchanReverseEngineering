using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace IO.Appmetrica.Analytics.Profile;

[Register("io/appmetrica/analytics/profile/NumberAttribute", DoNotGenerateAcw = true)]
public sealed class NumberAttribute : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("io/appmetrica/analytics/profile/NumberAttribute", typeof(NumberAttribute));

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

	internal NumberAttribute(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register("withValue", "(D)Lio/appmetrica/analytics/profile/UserProfileUpdate;", "")]
	public unsafe UserProfileUpdate WithValue(double value)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(value);
		return Java.Lang.Object.GetObject<UserProfileUpdate>(_members.InstanceMethods.InvokeAbstractObjectMethod("withValue.(D)Lio/appmetrica/analytics/profile/UserProfileUpdate;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("withValueIfUndefined", "(D)Lio/appmetrica/analytics/profile/UserProfileUpdate;", "")]
	public unsafe UserProfileUpdate WithValueIfUndefined(double value)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(value);
		return Java.Lang.Object.GetObject<UserProfileUpdate>(_members.InstanceMethods.InvokeAbstractObjectMethod("withValueIfUndefined.(D)Lio/appmetrica/analytics/profile/UserProfileUpdate;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("withValueReset", "()Lio/appmetrica/analytics/profile/UserProfileUpdate;", "")]
	public unsafe UserProfileUpdate WithValueReset()
	{
		return Java.Lang.Object.GetObject<UserProfileUpdate>(_members.InstanceMethods.InvokeAbstractObjectMethod("withValueReset.()Lio/appmetrica/analytics/profile/UserProfileUpdate;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}
}
