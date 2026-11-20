using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Database;
using Android.Runtime;
using Android.Views;
using Java.Interop;
using Java.Lang;

namespace Android.Widget;

[Register("android/widget/Adapter", DoNotGenerateAcw = true)]
internal class IAdapterInvoker : Java.Lang.Object, IAdapter, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_android_widget_Adapter = new XAPeerMembers("android/widget/Adapter", typeof(IAdapterInvoker));

	private static Delegate? cb_getCount_GetCount_I;

	private static Delegate? cb_hasStableIds_HasStableIds_Z;

	private static Delegate? cb_isEmpty_IsEmpty_Z;

	private static Delegate? cb_getViewTypeCount_GetViewTypeCount_I;

	private static Delegate? cb_getItem_GetItem_I_Ljava_lang_Object_;

	private static Delegate? cb_getItemId_GetItemId_I_J;

	private static Delegate? cb_getItemViewType_GetItemViewType_I_I;

	private static Delegate? cb_getView_GetView_ILandroid_view_View_Landroid_view_ViewGroup__Landroid_view_View_;

	private static Delegate? cb_registerDataSetObserver_RegisterDataSetObserver_Landroid_database_DataSetObserver__V;

	private static Delegate? cb_unregisterDataSetObserver_UnregisterDataSetObserver_Landroid_database_DataSetObserver__V;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_android_widget_Adapter;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_android_widget_Adapter.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_android_widget_Adapter.ManagedPeerType;

	public unsafe int Count => _members_android_widget_Adapter.InstanceMethods.InvokeAbstractInt32Method("getCount.()I", this, null);

	public unsafe bool HasStableIds => _members_android_widget_Adapter.InstanceMethods.InvokeAbstractBooleanMethod("hasStableIds.()Z", this, null);

	public unsafe bool IsEmpty => _members_android_widget_Adapter.InstanceMethods.InvokeAbstractBooleanMethod("isEmpty.()Z", this, null);

	public unsafe int ViewTypeCount => _members_android_widget_Adapter.InstanceMethods.InvokeAbstractInt32Method("getViewTypeCount.()I", this, null);

	public IAdapterInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetGetCountHandler()
	{
		return new _JniMarshal_PP_I(n_GetCount);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetCount(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<IAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Count;
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

	private static Delegate GetHasStableIdsHandler()
	{
		return new _JniMarshal_PP_B(n_HasStableIds);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_HasStableIds(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<IAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HasStableIds ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetIsEmptyHandler()
	{
		return new _JniMarshal_PP_B(n_IsEmpty);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsEmpty(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<IAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsEmpty ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetGetViewTypeCountHandler()
	{
		return new _JniMarshal_PP_I(n_GetViewTypeCount);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetViewTypeCount(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<IAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ViewTypeCount;
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

	private static Delegate GetGetItem_IHandler()
	{
		return new _JniMarshal_PPI_L(n_GetItem_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetItem_I(nint jnienv, nint native__this, int position)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetItem(position));
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

	public unsafe Java.Lang.Object? GetItem(int position)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(position);
		return Java.Lang.Object.GetObject<Java.Lang.Object>(_members_android_widget_Adapter.InstanceMethods.InvokeAbstractObjectMethod("getItem.(I)Ljava/lang/Object;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetGetItemId_IHandler()
	{
		return new _JniMarshal_PPI_J(n_GetItemId_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static long n_GetItemId_I(nint jnienv, nint native__this, int position)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0L;
		}
		try
		{
			return Java.Lang.Object.GetObject<IAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetItemId(position);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0L;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe long GetItemId(int position)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(position);
		return _members_android_widget_Adapter.InstanceMethods.InvokeAbstractInt64Method("getItemId.(I)J", this, ptr);
	}

	private static Delegate GetGetItemViewType_IHandler()
	{
		return new _JniMarshal_PPI_I(n_GetItemViewType_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetItemViewType_I(nint jnienv, nint native__this, int position)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<IAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetItemViewType(position);
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

	public unsafe int GetItemViewType(int position)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(position);
		return _members_android_widget_Adapter.InstanceMethods.InvokeAbstractInt32Method("getItemViewType.(I)I", this, ptr);
	}

	private static Delegate GetGetView_ILandroid_view_View_Landroid_view_ViewGroup_Handler()
	{
		return new _JniMarshal_PPILL_L(n_GetView_ILandroid_view_View_Landroid_view_ViewGroup_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetView_ILandroid_view_View_Landroid_view_ViewGroup_(nint jnienv, nint native__this, int position, nint native_convertView, nint native_parent)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IAdapter? adapter = Java.Lang.Object.GetObject<IAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View convertView = Java.Lang.Object.GetObject<View>(native_convertView, JniHandleOwnership.DoNotTransfer);
			ViewGroup parent = Java.Lang.Object.GetObject<ViewGroup>(native_parent, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(adapter.GetView(position, convertView, parent));
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

	private static Delegate GetRegisterDataSetObserver_Landroid_database_DataSetObserver_Handler()
	{
		return new _JniMarshal_PPL_V(n_RegisterDataSetObserver_Landroid_database_DataSetObserver_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_RegisterDataSetObserver_Landroid_database_DataSetObserver_(nint jnienv, nint native__this, nint native_observer)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IAdapter? adapter = Java.Lang.Object.GetObject<IAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			DataSetObserver observer = Java.Lang.Object.GetObject<DataSetObserver>(native_observer, JniHandleOwnership.DoNotTransfer);
			adapter.RegisterDataSetObserver(observer);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
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

	private static Delegate GetUnregisterDataSetObserver_Landroid_database_DataSetObserver_Handler()
	{
		return new _JniMarshal_PPL_V(n_UnregisterDataSetObserver_Landroid_database_DataSetObserver_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_UnregisterDataSetObserver_Landroid_database_DataSetObserver_(nint jnienv, nint native__this, nint native_observer)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IAdapter? adapter = Java.Lang.Object.GetObject<IAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			DataSetObserver observer = Java.Lang.Object.GetObject<DataSetObserver>(native_observer, JniHandleOwnership.DoNotTransfer);
			adapter.UnregisterDataSetObserver(observer);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
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
