using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Graphics;

[Register("android/graphics/PorterDuff", DoNotGenerateAcw = true)]
public class PorterDuff : Java.Lang.Object
{
	[Register("android/graphics/PorterDuff$Mode", DoNotGenerateAcw = true)]
	public sealed class Mode : Java.Lang.Enum
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("android/graphics/PorterDuff$Mode", typeof(Mode));

		[Register("SRC_IN")]
		public static Mode? SrcIn => Java.Lang.Object.GetObject<Mode>(_members.StaticFields.GetObjectValue("SRC_IN.Landroid/graphics/PorterDuff$Mode;").Handle, JniHandleOwnership.TransferLocalRef);

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		internal Mode(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("android/graphics/PorterDuff", typeof(PorterDuff));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	protected PorterDuff(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}
}
