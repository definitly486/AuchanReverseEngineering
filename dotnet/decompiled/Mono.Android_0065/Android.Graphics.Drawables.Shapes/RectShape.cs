using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;

namespace Android.Graphics.Drawables.Shapes;

[Register("android/graphics/drawable/shapes/RectShape", DoNotGenerateAcw = true)]
public class RectShape : Shape
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/graphics/drawable/shapes/RectShape", typeof(RectShape));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	protected RectShape(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}
}
