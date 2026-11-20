using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Graphics;
using Android.Runtime;
using Java.Interop;

namespace Android.Views;

[Register("android/view/ViewOutlineProvider", DoNotGenerateAcw = true)]
internal class ViewOutlineProviderInvoker : ViewOutlineProvider
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/view/ViewOutlineProvider", typeof(ViewOutlineProviderInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public ViewOutlineProviderInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	[Register("getOutline", "(Landroid/view/View;Landroid/graphics/Outline;)V", "GetGetOutline_Landroid_view_View_Landroid_graphics_Outline_Handler")]
	public unsafe override void GetOutline(View? view, Outline? outline)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(outline?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeAbstractVoidMethod("getOutline.(Landroid/view/View;Landroid/graphics/Outline;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(view);
			GC.KeepAlive(outline);
		}
	}
}
