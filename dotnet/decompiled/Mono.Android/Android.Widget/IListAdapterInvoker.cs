using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Database;
using Android.Runtime;
using Android.Views;
using Java.Interop;
using Java.Lang;

namespace Android.Widget;

[Register("android/widget/ListAdapter", DoNotGenerateAcw = true)]
internal class IListAdapterInvoker : Java.Lang.Object, IListAdapter, IAdapter, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_android_widget_Adapter = new XAPeerMembers("android/widget/Adapter", typeof(IListAdapterInvoker));

	private static readonly JniPeerMembers _members_android_widget_ListAdapter = new XAPeerMembers("android/widget/ListAdapter", typeof(IListAdapterInvoker));

	private static Delegate? cb_areAllItemsEnabled_AreAllItemsEnabled_Z;

	private static Delegate? cb_isEnabled_IsEnabled_I_Z;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_android_widget_ListAdapter;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_android_widget_ListAdapter.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_android_widget_ListAdapter.ManagedPeerType;

	public unsafe int Count => _members_android_widget_Adapter.InstanceMethods.InvokeAbstractInt32Method("getCount.()I", this, null);

	public unsafe bool HasStableIds => _members_android_widget_Adapter.InstanceMethods.InvokeAbstractBooleanMethod("hasStableIds.()Z", this, null);

	public unsafe bool IsEmpty => _members_android_widget_Adapter.InstanceMethods.InvokeAbstractBooleanMethod("isEmpty.()Z", this, null);

	public unsafe int ViewTypeCount => _members_android_widget_Adapter.InstanceMethods.InvokeAbstractInt32Method("getViewTypeCount.()I", this, null);

	public IListAdapterInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetAreAllItemsEnabledHandler()
	{
		return new _JniMarshal_PP_B(n_AreAllItemsEnabled);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_AreAllItemsEnabled(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<IListAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AreAllItemsEnabled() ? ((sbyte)1) : ((sbyte)0);
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

	public unsafe bool AreAllItemsEnabled()
	{
		return _members_android_widget_ListAdapter.InstanceMethods.InvokeAbstractBooleanMethod("areAllItemsEnabled.()Z", this, null);
	}

	private static Delegate GetIsEnabled_IHandler()
	{
		return new _JniMarshal_PPI_B(n_IsEnabled_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsEnabled_I(nint jnienv, nint native__this, int position)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<IListAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsEnabled(position) ? ((sbyte)1) : ((sbyte)0);
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

	public unsafe bool IsEnabled(int position)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(position);
		return _members_android_widget_ListAdapter.InstanceMethods.InvokeAbstractBooleanMethod("isEnabled.(I)Z", this, ptr);
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
