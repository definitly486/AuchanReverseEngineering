using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Versioning;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Views;

[SupportedOSPlatform("android30.0")]
[Register("android/view/WindowInsetsAnimation", DoNotGenerateAcw = true, ApiSince = 30)]
public sealed class WindowInsetsAnimation : Java.Lang.Object
{
	[SupportedOSPlatform("android30.0")]
	[Register("android/view/WindowInsetsAnimation$Bounds", DoNotGenerateAcw = true, ApiSince = 30)]
	public sealed class Bounds : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("android/view/WindowInsetsAnimation$Bounds", typeof(Bounds));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		internal Bounds(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("android/view/WindowInsetsAnimation", typeof(WindowInsetsAnimation));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	internal WindowInsetsAnimation(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}
}
