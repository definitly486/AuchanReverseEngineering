using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Android.Views;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Core.View;

[Register("androidx/core/view/ActionProvider", DoNotGenerateAcw = true)]
internal class ActionProviderInvoker : ActionProvider
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/core/view/ActionProvider", typeof(ActionProviderInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public ActionProviderInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	[Register("onCreateActionView", "()Landroid/view/View;", "GetOnCreateActionViewHandler")]
	public unsafe override Android.Views.View? OnCreateActionView()
	{
		return Java.Lang.Object.GetObject<Android.Views.View>(_members.InstanceMethods.InvokeAbstractObjectMethod("onCreateActionView.()Landroid/view/View;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}
}
