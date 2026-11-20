using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Versioning;
using Android.Graphics;
using Android.Runtime;
using Java.Interop;

namespace Android.Text;

[Register("android/text/TextPaint", DoNotGenerateAcw = true)]
public class TextPaint : Paint
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/text/TextPaint", typeof(TextPaint));

	[SupportedOSPlatform("android29.0")]
	[Register("underlineColor", ApiSince = 29)]
	public int UnderlineColor
	{
		set
		{
			_members.InstanceFields.SetValue("underlineColor.I", this, value);
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	protected TextPaint(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}
}
