using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Android.Views;
using Java.Interop;
using Java.Lang;

namespace Android.Widget;

[Register("android/widget/BaseAdapter", DoNotGenerateAcw = true)]
internal class BaseAdapterInvoker : BaseAdapter
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/widget/BaseAdapter", typeof(BaseAdapterInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe override int Count => _members.InstanceMethods.InvokeAbstractInt32Method("getCount.()I", this, null);

	public BaseAdapterInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	public unsafe override Java.Lang.Object? GetItem(int position)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(position);
		return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeAbstractObjectMethod("getItem.(I)Ljava/lang/Object;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	public unsafe override long GetItemId(int position)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(position);
		return _members.InstanceMethods.InvokeAbstractInt64Method("getItemId.(I)J", this, ptr);
	}

	public unsafe override View? GetView(int position, View? convertView, ViewGroup? parent)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(position);
			ptr[1] = new JniArgumentValue(convertView?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(parent?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<View>(_members.InstanceMethods.InvokeAbstractObjectMethod("getView.(ILandroid/view/View;Landroid/view/ViewGroup;)Landroid/view/View;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(convertView);
			GC.KeepAlive(parent);
		}
	}
}
