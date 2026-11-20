using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Content;
using Android.Database;
using Android.Runtime;
using Android.Views;
using Java.Interop;
using Java.Lang;

namespace AndroidX.CursorAdapter.Widget;

[Register("androidx/cursoradapter/widget/CursorAdapter", DoNotGenerateAcw = true)]
internal class CursorAdapterInvoker : CursorAdapter
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/cursoradapter/widget/CursorAdapter", typeof(CursorAdapterInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public CursorAdapterInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	[Register("bindView", "(Landroid/view/View;Landroid/content/Context;Landroid/database/Cursor;)V", "GetBindView_Landroid_view_View_Landroid_content_Context_Landroid_database_Cursor_Handler")]
	public unsafe override void BindView(View? view, Context? context, ICursor? cursor)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue((cursor == null) ? IntPtr.Zero : ((Java.Lang.Object)cursor).Handle);
			_members.InstanceMethods.InvokeAbstractVoidMethod("bindView.(Landroid/view/View;Landroid/content/Context;Landroid/database/Cursor;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(view);
			GC.KeepAlive(context);
			GC.KeepAlive(cursor);
		}
	}

	[Register("newView", "(Landroid/content/Context;Landroid/database/Cursor;Landroid/view/ViewGroup;)Landroid/view/View;", "GetNewView_Landroid_content_Context_Landroid_database_Cursor_Landroid_view_ViewGroup_Handler")]
	public unsafe override View? NewView(Context? context, ICursor? cursor, ViewGroup? parent)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((cursor == null) ? IntPtr.Zero : ((Java.Lang.Object)cursor).Handle);
			ptr[2] = new JniArgumentValue(parent?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<View>(_members.InstanceMethods.InvokeAbstractObjectMethod("newView.(Landroid/content/Context;Landroid/database/Cursor;Landroid/view/ViewGroup;)Landroid/view/View;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(context);
			GC.KeepAlive(cursor);
			GC.KeepAlive(parent);
		}
	}
}
