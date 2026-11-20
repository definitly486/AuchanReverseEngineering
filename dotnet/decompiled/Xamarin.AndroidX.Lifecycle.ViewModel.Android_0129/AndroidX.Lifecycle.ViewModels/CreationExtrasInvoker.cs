using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Lifecycle.ViewModels;

[Register("androidx/lifecycle/viewmodel/CreationExtras", DoNotGenerateAcw = true)]
internal class CreationExtrasInvoker : CreationExtras
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/lifecycle/viewmodel/CreationExtras", typeof(CreationExtrasInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public CreationExtrasInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	[Register("get", "(Landroidx/lifecycle/viewmodel/CreationExtras$Key;)Ljava/lang/Object;", "GetGet_Landroidx_lifecycle_viewmodel_CreationExtras_Key_Handler")]
	[JavaTypeParameters(new string[] { "T" })]
	public unsafe override Java.Lang.Object? Get(IKey key)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((key == null) ? IntPtr.Zero : ((Java.Lang.Object)key).Handle);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeAbstractObjectMethod("get.(Landroidx/lifecycle/viewmodel/CreationExtras$Key;)Ljava/lang/Object;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(key);
		}
	}
}
