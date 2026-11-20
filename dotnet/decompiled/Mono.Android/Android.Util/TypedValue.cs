using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Util;

[Register("android/util/TypedValue", DoNotGenerateAcw = true)]
public class TypedValue : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/util/TypedValue", typeof(TypedValue));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	protected TypedValue(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register("applyDimension", "(IFLandroid/util/DisplayMetrics;)F", "")]
	public unsafe static float ApplyDimension(ComplexUnitType unit, float value, DisplayMetrics? metrics)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue((int)unit);
			ptr[1] = new JniArgumentValue(value);
			ptr[2] = new JniArgumentValue(metrics?.Handle ?? IntPtr.Zero);
			return _members.StaticMethods.InvokeSingleMethod("applyDimension.(IFLandroid/util/DisplayMetrics;)F", ptr);
		}
		finally
		{
			GC.KeepAlive(metrics);
		}
	}
}
