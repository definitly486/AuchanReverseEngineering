using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;

namespace Android.Text.Style;

[Register("android/text/style/CharacterStyle", DoNotGenerateAcw = true)]
internal class CharacterStyleInvoker : CharacterStyle
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/text/style/CharacterStyle", typeof(CharacterStyleInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public CharacterStyleInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	public unsafe override void UpdateDrawState(TextPaint? tp)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(tp?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeAbstractVoidMethod("updateDrawState.(Landroid/text/TextPaint;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(tp);
		}
	}
}
