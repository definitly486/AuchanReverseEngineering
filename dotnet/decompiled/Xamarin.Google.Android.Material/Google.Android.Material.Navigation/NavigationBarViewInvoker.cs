using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Content;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Google.Android.Material.Navigation;

[Register("com/google/android/material/navigation/NavigationBarView", DoNotGenerateAcw = true)]
internal class NavigationBarViewInvoker : NavigationBarView
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/material/navigation/NavigationBarView", typeof(NavigationBarViewInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe override int MaxItemCount
	{
		[Register("getMaxItemCount", "()I", "GetGetMaxItemCountHandler")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("getMaxItemCount.()I", this, null);
		}
	}

	public NavigationBarViewInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	[Register("createNavigationBarMenuView", "(Landroid/content/Context;)Lcom/google/android/material/navigation/NavigationBarMenuView;", "GetCreateNavigationBarMenuView_Landroid_content_Context_Handler")]
	protected unsafe override NavigationBarMenuView CreateNavigationBarMenuView(Context p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<NavigationBarMenuView>(_members.InstanceMethods.InvokeAbstractObjectMethod("createNavigationBarMenuView.(Landroid/content/Context;)Lcom/google/android/material/navigation/NavigationBarMenuView;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}
}
