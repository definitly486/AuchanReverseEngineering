using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using Android.Database;
using Android.Runtime;
using Android.Views;
using Java.Interop;
using Java.Lang;

namespace Android.Widget;

[Register("android/widget/BaseAdapter", DoNotGenerateAcw = true)]
public abstract class BaseAdapter<T> : BaseAdapter
{
	private static nint java_class_handle;

	private static nint id_ctor;

	private new static nint class_ref => JNIEnv.FindClass("android/widget/BaseAdapter", ref java_class_handle);

	public abstract T this[int position]
	{
		[Register("getItem", "(I)Ljava/lang/Object;", "GetGetItem_IHandler")]
		get;
	}

	public BaseAdapter(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public BaseAdapter()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		if (GetType() != typeof(BaseAdapter))
		{
			SetHandle(JNIEnv.StartCreateInstance(GetType(), "()V"), JniHandleOwnership.TransferLocalRef);
			JNIEnv.FinishCreateInstance(base.Handle, "()V");
			return;
		}
		if (id_ctor == IntPtr.Zero)
		{
			id_ctor = JNIEnv.GetMethodID(class_ref, "<init>", "()V");
		}
		SetHandle(JNIEnv.StartCreateInstance(class_ref, id_ctor), JniHandleOwnership.TransferLocalRef);
		JNIEnv.FinishCreateInstance(base.Handle, class_ref, id_ctor);
	}

	public override Java.Lang.Object? GetItem(int position)
	{
		return JavaObjectExtensions.JavaCast<Java.Lang.Object>(JavaConvert.ToJavaObject(this[position]));
	}
}
[Register("android/widget/BaseAdapter", DoNotGenerateAcw = true)]
public abstract class BaseAdapter : Java.Lang.Object, IListAdapter, IAdapter, IJavaObject, IDisposable, IJavaPeerable, ISpinnerAdapter
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/widget/BaseAdapter", typeof(BaseAdapter));

	private static Delegate? cb_hasStableIds_HasStableIds_Z;

	private static Delegate? cb_isEmpty_IsEmpty_Z;

	private static Delegate? cb_getViewTypeCount_GetViewTypeCount_I;

	private static Delegate? cb_areAllItemsEnabled_AreAllItemsEnabled_Z;

	private static Delegate? cb_getAutofillOptions_GetAutofillOptions_arrayLjava_lang_CharSequence_;

	private static Delegate? cb_getDropDownView_GetDropDownView_ILandroid_view_View_Landroid_view_ViewGroup__Landroid_view_View_;

	private static Delegate? cb_getItemViewType_GetItemViewType_I_I;

	private static Delegate? cb_isEnabled_IsEnabled_I_Z;

	private static Delegate? cb_notifyDataSetChanged_NotifyDataSetChanged_V;

	private static Delegate? cb_registerDataSetObserver_RegisterDataSetObserver_Landroid_database_DataSetObserver__V;

	private static Delegate? cb_unregisterDataSetObserver_UnregisterDataSetObserver_Landroid_database_DataSetObserver__V;

	private static Delegate? cb_getItem_GetItem_I_Ljava_lang_Object_;

	private static Delegate? cb_getItemId_GetItemId_I_J;

	private static Delegate? cb_getView_GetView_ILandroid_view_View_Landroid_view_ViewGroup__Landroid_view_View_;

	private static Delegate? cb_getCount_GetCount_I;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe virtual bool HasStableIds
	{
		[Register("hasStableIds", "()Z", "GetHasStableIdsHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("hasStableIds.()Z", this, null);
		}
	}

	public unsafe virtual bool IsEmpty
	{
		[Register("isEmpty", "()Z", "GetIsEmptyHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isEmpty.()Z", this, null);
		}
	}

	public unsafe virtual int ViewTypeCount
	{
		[Register("getViewTypeCount", "()I", "GetGetViewTypeCountHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getViewTypeCount.()I", this, null);
		}
	}

	public abstract int Count
	{
		[Register("getCount", "()I", "GetGetCountHandler")]
		get;
	}

	protected BaseAdapter(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
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
			return Java.Lang.Object.GetObject<BaseAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HasStableIds ? ((sbyte)1) : ((sbyte)0);
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
			return Java.Lang.Object.GetObject<BaseAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsEmpty ? ((sbyte)1) : ((sbyte)0);
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
			return Java.Lang.Object.GetObject<BaseAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ViewTypeCount;
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
			return Java.Lang.Object.GetObject<BaseAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AreAllItemsEnabled() ? ((sbyte)1) : ((sbyte)0);
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

	[Register("areAllItemsEnabled", "()Z", "GetAreAllItemsEnabledHandler")]
	public unsafe virtual bool AreAllItemsEnabled()
	{
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("areAllItemsEnabled.()Z", this, null);
	}

	[SupportedOSPlatform("android27.0")]
	private static Delegate GetGetAutofillOptionsHandler()
	{
		return new _JniMarshal_PP_L(n_GetAutofillOptions);
	}

	[SupportedOSPlatform("android27.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetAutofillOptions(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewArray(Java.Lang.Object.GetObject<BaseAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetAutofillOptionsFormatted());
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

	[SupportedOSPlatform("android27.0")]
	[Register("getAutofillOptions", "()[Ljava/lang/CharSequence;", "GetGetAutofillOptionsHandler", ApiSince = 27)]
	public unsafe virtual ICharSequence[]? GetAutofillOptionsFormatted()
	{
		return (ICharSequence[])JNIEnv.GetArray(_members.InstanceMethods.InvokeVirtualObjectMethod("getAutofillOptions.()[Ljava/lang/CharSequence;", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(ICharSequence));
	}

	[SupportedOSPlatform("android27.0")]
	public string[]? GetAutofillOptions()
	{
		return CharSequence.ArrayToStringArray(GetAutofillOptionsFormatted());
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
			BaseAdapter? baseAdapter = Java.Lang.Object.GetObject<BaseAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View convertView = Java.Lang.Object.GetObject<View>(native_convertView, JniHandleOwnership.DoNotTransfer);
			ViewGroup parent = Java.Lang.Object.GetObject<ViewGroup>(native_parent, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(baseAdapter.GetDropDownView(position, convertView, parent));
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

	[Register("getDropDownView", "(ILandroid/view/View;Landroid/view/ViewGroup;)Landroid/view/View;", "GetGetDropDownView_ILandroid_view_View_Landroid_view_ViewGroup_Handler")]
	public unsafe virtual View? GetDropDownView(int position, View? convertView, ViewGroup? parent)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(position);
			ptr[1] = new JniArgumentValue(convertView?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(parent?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<View>(_members.InstanceMethods.InvokeVirtualObjectMethod("getDropDownView.(ILandroid/view/View;Landroid/view/ViewGroup;)Landroid/view/View;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(convertView);
			GC.KeepAlive(parent);
		}
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
			return Java.Lang.Object.GetObject<BaseAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetItemViewType(position);
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

	[Register("getItemViewType", "(I)I", "GetGetItemViewType_IHandler")]
	public unsafe virtual int GetItemViewType(int position)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(position);
		return _members.InstanceMethods.InvokeVirtualInt32Method("getItemViewType.(I)I", this, ptr);
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
			return Java.Lang.Object.GetObject<BaseAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsEnabled(position) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("isEnabled", "(I)Z", "GetIsEnabled_IHandler")]
	public unsafe virtual bool IsEnabled(int position)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(position);
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("isEnabled.(I)Z", this, ptr);
	}

	private static Delegate GetNotifyDataSetChangedHandler()
	{
		return new _JniMarshal_PP_V(n_NotifyDataSetChanged);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_NotifyDataSetChanged(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<BaseAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).NotifyDataSetChanged();
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

	[Register("notifyDataSetChanged", "()V", "GetNotifyDataSetChangedHandler")]
	public unsafe virtual void NotifyDataSetChanged()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("notifyDataSetChanged.()V", this, null);
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
			BaseAdapter? baseAdapter = Java.Lang.Object.GetObject<BaseAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			DataSetObserver observer = Java.Lang.Object.GetObject<DataSetObserver>(native_observer, JniHandleOwnership.DoNotTransfer);
			baseAdapter.RegisterDataSetObserver(observer);
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

	[Register("registerDataSetObserver", "(Landroid/database/DataSetObserver;)V", "GetRegisterDataSetObserver_Landroid_database_DataSetObserver_Handler")]
	public unsafe virtual void RegisterDataSetObserver(DataSetObserver? observer)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(observer?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("registerDataSetObserver.(Landroid/database/DataSetObserver;)V", this, ptr);
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
			BaseAdapter? baseAdapter = Java.Lang.Object.GetObject<BaseAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			DataSetObserver observer = Java.Lang.Object.GetObject<DataSetObserver>(native_observer, JniHandleOwnership.DoNotTransfer);
			baseAdapter.UnregisterDataSetObserver(observer);
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

	[Register("unregisterDataSetObserver", "(Landroid/database/DataSetObserver;)V", "GetUnregisterDataSetObserver_Landroid_database_DataSetObserver_Handler")]
	public unsafe virtual void UnregisterDataSetObserver(DataSetObserver? observer)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(observer?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("unregisterDataSetObserver.(Landroid/database/DataSetObserver;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(observer);
		}
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<BaseAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetItem(position));
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

	[Register("getItem", "(I)Ljava/lang/Object;", "GetGetItem_IHandler")]
	public abstract Java.Lang.Object? GetItem(int position);

	[DebuggerDisableUserUnhandledExceptions]
	private static long n_GetItemId_I(nint jnienv, nint native__this, int position)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0L;
		}
		try
		{
			return Java.Lang.Object.GetObject<BaseAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetItemId(position);
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

	[Register("getItemId", "(I)J", "GetGetItemId_IHandler")]
	public abstract long GetItemId(int position);

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetView_ILandroid_view_View_Landroid_view_ViewGroup_(nint jnienv, nint native__this, int position, nint native_convertView, nint native_parent)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			BaseAdapter? baseAdapter = Java.Lang.Object.GetObject<BaseAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View convertView = Java.Lang.Object.GetObject<View>(native_convertView, JniHandleOwnership.DoNotTransfer);
			ViewGroup parent = Java.Lang.Object.GetObject<ViewGroup>(native_parent, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(baseAdapter.GetView(position, convertView, parent));
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

	[Register("getView", "(ILandroid/view/View;Landroid/view/ViewGroup;)Landroid/view/View;", "GetGetView_ILandroid_view_View_Landroid_view_ViewGroup_Handler")]
	public abstract View? GetView(int position, View? convertView, ViewGroup? parent);

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetCount(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<BaseAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Count;
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

	[UnmanagedCallersOnly]
	private static nint n_GetItem_I_mm_wrapper(nint jnienv, nint native__this, int position)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			return n_GetItem_I(jnienv, native__this, position);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
			return 0;
		}
	}

	[UnmanagedCallersOnly]
	private static int n_GetCount_mm_wrapper(nint jnienv, nint native__this)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			return n_GetCount(jnienv, native__this);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
			return 0;
		}
	}

	[UnmanagedCallersOnly]
	private static long n_GetItemId_I_mm_wrapper(nint jnienv, nint native__this, int position)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			return n_GetItemId_I(jnienv, native__this, position);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
			return 0L;
		}
	}

	[UnmanagedCallersOnly]
	private static nint n_GetView_ILandroid_view_View_Landroid_view_ViewGroup__mm_wrapper(nint jnienv, nint native__this, int position, nint native_convertView, nint native_parent)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			return n_GetView_ILandroid_view_View_Landroid_view_ViewGroup_(jnienv, native__this, position, native_convertView, native_parent);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
			return 0;
		}
	}
}
