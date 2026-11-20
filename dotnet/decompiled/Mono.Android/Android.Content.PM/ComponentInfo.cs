using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;

namespace Android.Content.PM;

[Register("android/content/pm/ComponentInfo", DoNotGenerateAcw = true)]
public class ComponentInfo : PackageItemInfo
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/content/pm/ComponentInfo", typeof(ComponentInfo));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	protected ComponentInfo(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}
}
