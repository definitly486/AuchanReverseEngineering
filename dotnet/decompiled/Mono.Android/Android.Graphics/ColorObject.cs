using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Graphics;

[Register("android/graphics/Color", DoNotGenerateAcw = true)]
public class ColorObject : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/graphics/Color", typeof(ColorObject));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	protected ColorObject(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register("parseColor", "(Ljava/lang/String;)I", "")]
	public unsafe static int ParseColor(string? colorString)
	{
		nint num = JNIEnv.NewString(colorString);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return _members.StaticMethods.InvokeInt32Method("parseColor.(Ljava/lang/String;)I", ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}
}
