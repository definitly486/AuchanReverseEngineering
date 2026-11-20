using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Text;

[Register("android/text/TextUtils", DoNotGenerateAcw = true)]
public class TextUtils : Java.Lang.Object
{
	[Register("android/text/TextUtils$TruncateAt", DoNotGenerateAcw = true)]
	public sealed class TruncateAt : Java.Lang.Enum
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("android/text/TextUtils$TruncateAt", typeof(TruncateAt));

		[Register("END")]
		public static TruncateAt? End => Java.Lang.Object.GetObject<TruncateAt>(_members.StaticFields.GetObjectValue("END.Landroid/text/TextUtils$TruncateAt;").Handle, JniHandleOwnership.TransferLocalRef);

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		internal TruncateAt(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("android/text/TextUtils", typeof(TextUtils));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	protected TextUtils(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}
}
