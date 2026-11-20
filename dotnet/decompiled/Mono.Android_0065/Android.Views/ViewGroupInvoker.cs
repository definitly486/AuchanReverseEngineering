using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;

namespace Android.Views;

[Register("android/view/ViewGroup", DoNotGenerateAcw = true)]
internal class ViewGroupInvoker : ViewGroup
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/view/ViewGroup", typeof(ViewGroupInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public ViewGroupInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	protected unsafe override void OnLayout(bool changed, int l, int t, int r, int b)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
		*ptr = new JniArgumentValue(changed ? ((sbyte)1) : ((sbyte)0));
		ptr[1] = new JniArgumentValue(l);
		ptr[2] = new JniArgumentValue(t);
		ptr[3] = new JniArgumentValue(r);
		ptr[4] = new JniArgumentValue(b);
		_members.InstanceMethods.InvokeAbstractVoidMethod("onLayout.(ZIIII)V", this, ptr);
	}
}
