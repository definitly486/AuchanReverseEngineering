using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Android.Views;
using Java.Interop;

namespace AndroidX.ConstraintLayout.Motion.Utils;

[Register("androidx/constraintlayout/motion/utils/ViewSpline", DoNotGenerateAcw = true)]
internal class ViewSplineInvoker : ViewSpline
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/motion/utils/ViewSpline", typeof(ViewSplineInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public ViewSplineInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	[Register("setProperty", "(Landroid/view/View;F)V", "GetSetProperty_Landroid_view_View_FHandler")]
	public unsafe override void SetProperty(View? p0, float p1)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(p1);
			_members.InstanceMethods.InvokeAbstractVoidMethod("setProperty.(Landroid/view/View;F)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}
}
