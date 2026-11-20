using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Android.Views;
using Java.Interop;

namespace Android.Text.Style;

[Register("android/text/style/ClickableSpan", DoNotGenerateAcw = true)]
internal class ClickableSpanInvoker : ClickableSpan
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/text/style/ClickableSpan", typeof(ClickableSpanInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public ClickableSpanInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	[Register("onClick", "(Landroid/view/View;)V", "GetOnClick_Landroid_view_View_Handler")]
	public unsafe override void OnClick(View widget)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(widget?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeAbstractVoidMethod("onClick.(Landroid/view/View;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(widget);
		}
	}
}
