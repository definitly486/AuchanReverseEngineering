using System;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Me.Relex.CircleIndicatorLib;

[Register("me/relex/circleindicator/Config", DoNotGenerateAcw = true)]
public class Config : Java.Lang.Object
{
	internal static readonly JniPeerMembers _members = new XAPeerMembers("me/relex/circleindicator/Config", typeof(Config));

	internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

	public override JniPeerMembers JniPeerMembers => _members;

	protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	protected override Type ThresholdType => _members.ManagedPeerType;

	protected Config(IntPtr javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}
}
