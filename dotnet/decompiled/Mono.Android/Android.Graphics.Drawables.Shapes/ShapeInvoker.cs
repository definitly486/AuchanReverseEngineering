using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;

namespace Android.Graphics.Drawables.Shapes;

[Register("android/graphics/drawable/shapes/Shape", DoNotGenerateAcw = true)]
internal class ShapeInvoker : Shape
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/graphics/drawable/shapes/Shape", typeof(ShapeInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public ShapeInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}
}
