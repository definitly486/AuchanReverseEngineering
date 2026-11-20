using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Android.Views;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Fragment.App;

[Register("androidx/fragment/app/FragmentContainer", DoNotGenerateAcw = true)]
internal class FragmentContainerInvoker : FragmentContainer
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/fragment/app/FragmentContainer", typeof(FragmentContainerInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public FragmentContainerInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	[Register("onFindViewById", "(I)Landroid/view/View;", "GetOnFindViewById_IHandler")]
	public unsafe override View? OnFindViewById(int id)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(id);
		return Java.Lang.Object.GetObject<View>(_members.InstanceMethods.InvokeAbstractObjectMethod("onFindViewById.(I)Landroid/view/View;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("onHasView", "()Z", "GetOnHasViewHandler")]
	public unsafe override bool OnHasView()
	{
		return _members.InstanceMethods.InvokeAbstractBooleanMethod("onHasView.()Z", this, null);
	}
}
