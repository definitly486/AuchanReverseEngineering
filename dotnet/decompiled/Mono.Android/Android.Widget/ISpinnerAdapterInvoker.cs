using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Database;
using Android.Runtime;
using Android.Views;
using Java.Interop;
using Java.Lang;

namespace Android.Widget;

[Register("android/widget/SpinnerAdapter", DoNotGenerateAcw = true)]
internal class ISpinnerAdapterInvoker : Java.Lang.Object, ISpinnerAdapter, IAdapter, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_android_widget_Adapter = new XAPeerMembers("android/widget/Adapter", typeof(ISpinnerAdapterInvoker));

	private static readonly JniPeerMembers _members_android_widget_SpinnerAdapter = new XAPeerMembers("android/widget/SpinnerAdapter", typeof(ISpinnerAdapterInvoker));

	private static Delegate? cb_getDropDownView_GetDropDownView_ILandroid_view_View_Landroid_view_ViewGroup__Landroid_view_View_;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_android_widget_SpinnerAdapter;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_android_widget_SpinnerAdapter.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_android_widget_SpinnerAdapter.ManagedPeerType;

	public unsafe int Count => _members_android_widget_Adapter.InstanceMethods.InvokeAbstractInt32Method("getCount.()I", this, null);

	public unsafe bool HasStableIds => _members_android_widget_Adapter.InstanceMethods.InvokeAbstractBooleanMethod("hasStableIds.()Z", this, null);

	public unsafe bool IsEmpty => _members_android_widget_Adapter.InstanceMethods.InvokeAbstractBooleanMethod("isEmpty.()Z", this, null);

	public unsafe int ViewTypeCount => _members_android_widget_Adapter.InstanceMethods.InvokeAbstractInt32Method("getViewTypeCount.()I", this, null);

	public ISpinnerAdapterInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetGetDropDownView_ILandroid_view_View_Landroid_view_ViewGroup_Handler()
	{
		return new _JniMarshal_PPILL_L(n_GetDropDownView_ILandroid_view_View_Landroid_view_ViewGroup_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetDropDownView_ILandroid_view_View_Landroid_view_ViewGroup_(nint jnienv, nint native__this, int position, nint native_convertView, nint native_parent)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			ISpinnerAdapter? spinnerAdapter = Java.Lang.Object.GetObject<ISpinnerAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View convertView = Java.Lang.Object.GetObject<View>(native_convertView, JniHandleOwnership.DoNotTransfer);
			ViewGroup parent = Java.Lang.Object.GetObject<ViewGroup>(native_parent, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(spinnerAdapter.GetDropDownView(position, convertView, parent));
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe View? GetDropDownView(int position, View? convertView, ViewGroup? parent)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(position);
			ptr[1] = new JniArgumentValue(convertView?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(parent?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<View>(_members_android_widget_SpinnerAdapter.InstanceMethods.InvokeAbstractObjectMethod("getDropDownView.(ILandroid/view/View;Landroid/view/ViewGroup;)Landroid/view/View;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(convertView);
			GC.KeepAlive(parent);
		}
	}

	public unsafe Java.Lang.Object? GetItem(int position)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(position);
		return Java.Lang.Object.GetObject<Java.Lang.Object>(_members_android_widget_Adapter.InstanceMethods.InvokeAbstractObjectMethod("getItem.(I)Ljava/lang/Object;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	public unsafe long GetItemId(int position)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(position);
		return _members_android_widget_Adapter.InstanceMethods.InvokeAbstractInt64Method("getItemId.(I)J", this, ptr);
	}

	public unsafe int GetItemViewType(int position)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(position);
		return _members_android_widget_Adapter.InstanceMethods.InvokeAbstractInt32Method("getItemViewType.(I)I", this, ptr);
	}

	public unsafe View? GetView(int position, View? convertView, ViewGroup? parent)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(position);
			ptr[1] = new JniArgumentValue(convertView?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(parent?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<View>(_members_android_widget_Adapter.InstanceMethods.InvokeAbstractObjectMethod("getView.(ILandroid/view/View;Landroid/view/ViewGroup;)Landroid/view/View;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(convertView);
			GC.KeepAlive(parent);
		}
	}

	public unsafe void RegisterDataSetObserver(DataSetObserver? observer)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(observer?.Handle ?? IntPtr.Zero);
			_members_android_widget_Adapter.InstanceMethods.InvokeAbstractVoidMethod("registerDataSetObserver.(Landroid/database/DataSetObserver;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(observer);
		}
	}

	public unsafe void UnregisterDataSetObserver(DataSetObserver? observer)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(observer?.Handle ?? IntPtr.Zero);
			_members_android_widget_Adapter.InstanceMethods.InvokeAbstractVoidMethod("unregisterDataSetObserver.(Landroid/database/DataSetObserver;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(observer);
		}
	}

	int IJavaPeerable.get_JniIdentityHashCode()
	{
		return base.JniIdentityHashCode;
	}

	JniObjectReference IJavaPeerable.get_PeerReference()
	{
		return base.PeerReference;
	}

	void IJavaPeerable.UnregisterFromRuntime()
	{
		UnregisterFromRuntime();
	}
}
