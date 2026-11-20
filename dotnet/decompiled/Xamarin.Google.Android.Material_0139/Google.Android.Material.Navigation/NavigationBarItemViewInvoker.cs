using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;

namespace Google.Android.Material.Navigation;

[Register("com/google/android/material/navigation/NavigationBarItemView", DoNotGenerateAcw = true)]
internal class NavigationBarItemViewInvoker : NavigationBarItemView
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/material/navigation/NavigationBarItemView", typeof(NavigationBarItemViewInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	protected unsafe override int ItemLayoutResId
	{
		[Register("getItemLayoutResId", "()I", "GetGetItemLayoutResIdHandler")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("getItemLayoutResId.()I", this, null);
		}
	}

	public NavigationBarItemViewInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}
}
