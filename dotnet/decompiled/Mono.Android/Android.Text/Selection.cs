using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Text;

[Register("android/text/Selection", DoNotGenerateAcw = true)]
public class Selection : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/text/Selection", typeof(Selection));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	protected Selection(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register("removeSelection", "(Landroid/text/Spannable;)V", "")]
	public unsafe static void RemoveSelection(ISpannable? text)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((text == null) ? IntPtr.Zero : ((Java.Lang.Object)text).Handle);
			_members.StaticMethods.InvokeVoidMethod("removeSelection.(Landroid/text/Spannable;)V", ptr);
		}
		finally
		{
			GC.KeepAlive(text);
		}
	}
}
