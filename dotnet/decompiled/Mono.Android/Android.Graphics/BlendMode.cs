using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Versioning;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Graphics;

[SupportedOSPlatform("android29.0")]
[Register("android/graphics/BlendMode", DoNotGenerateAcw = true, ApiSince = 29)]
public sealed class BlendMode : Java.Lang.Enum
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/graphics/BlendMode", typeof(BlendMode));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	internal BlendMode(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}
}
