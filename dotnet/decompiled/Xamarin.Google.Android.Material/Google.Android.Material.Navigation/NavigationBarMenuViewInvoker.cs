using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Content;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Google.Android.Material.Navigation;

[Register("com/google/android/material/navigation/NavigationBarMenuView", DoNotGenerateAcw = true)]
internal class NavigationBarMenuViewInvoker : NavigationBarMenuView
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/material/navigation/NavigationBarMenuView", typeof(NavigationBarMenuViewInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public NavigationBarMenuViewInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	[Register("createNavigationBarItemView", "(Landroid/content/Context;)Lcom/google/android/material/navigation/NavigationBarItemView;", "GetCreateNavigationBarItemView_Landroid_content_Context_Handler")]
	protected unsafe override NavigationBarItemView CreateNavigationBarItemView(Context p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<NavigationBarItemView>(_members.InstanceMethods.InvokeAbstractObjectMethod("createNavigationBarItemView.(Landroid/content/Context;)Lcom/google/android/material/navigation/NavigationBarItemView;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	[Register("onLayout", "(ZIIII)V", "GetOnLayout_ZIIIIHandler")]
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
