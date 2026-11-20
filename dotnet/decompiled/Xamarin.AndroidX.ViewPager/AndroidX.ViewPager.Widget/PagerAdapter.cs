using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Android.Database;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Java.Interop;
using Java.Lang;

namespace AndroidX.ViewPager.Widget;

[Register("androidx/viewpager/widget/PagerAdapter", DoNotGenerateAcw = true)]
public abstract class PagerAdapter : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/viewpager/widget/PagerAdapter", typeof(PagerAdapter));

	private static Delegate? cb_getCount_GetCount_I;

	private static Delegate? cb_destroyItem_DestroyItem_Landroid_view_View_ILjava_lang_Object__V;

	private static Delegate? cb_destroyItem_DestroyItem_Landroid_view_ViewGroup_ILjava_lang_Object__V;

	private static Delegate? cb_finishUpdate_FinishUpdate_Landroid_view_View__V;

	private static Delegate? cb_finishUpdate_FinishUpdate_Landroid_view_ViewGroup__V;

	private static Delegate? cb_getItemPosition_GetItemPosition_Ljava_lang_Object__I;

	private static Delegate? cb_getPageTitle_GetPageTitle_I_Ljava_lang_CharSequence_;

	private static Delegate? cb_getPageWidth_GetPageWidth_I_F;

	private static Delegate? cb_instantiateItem_InstantiateItem_Landroid_view_View_I_Ljava_lang_Object_;

	private static Delegate? cb_instantiateItem_InstantiateItem_Landroid_view_ViewGroup_I_Ljava_lang_Object_;

	private static Delegate? cb_isViewFromObject_IsViewFromObject_Landroid_view_View_Ljava_lang_Object__Z;

	private static Delegate? cb_notifyDataSetChanged_NotifyDataSetChanged_V;

	private static Delegate? cb_registerDataSetObserver_RegisterDataSetObserver_Landroid_database_DataSetObserver__V;

	private static Delegate? cb_restoreState_RestoreState_Landroid_os_Parcelable_Ljava_lang_ClassLoader__V;

	private static Delegate? cb_saveState_SaveState_Landroid_os_Parcelable_;

	private static Delegate? cb_setPrimaryItem_SetPrimaryItem_Landroid_view_View_ILjava_lang_Object__V;

	private static Delegate? cb_setPrimaryItem_SetPrimaryItem_Landroid_view_ViewGroup_ILjava_lang_Object__V;

	private static Delegate? cb_startUpdate_StartUpdate_Landroid_view_View__V;

	private static Delegate? cb_startUpdate_StartUpdate_Landroid_view_ViewGroup__V;

	private static Delegate? cb_unregisterDataSetObserver_UnregisterDataSetObserver_Landroid_database_DataSetObserver__V;

	internal static nint class_ref => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public abstract int Count
	{
		[Register("getCount", "()I", "GetGetCountHandler")]
		get;
	}

	protected PagerAdapter(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe PagerAdapter()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
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
			return Java.Lang.Object.GetObject<PagerAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Count;
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

	[Obsolete]
	private static Delegate GetDestroyItem_Landroid_view_View_ILjava_lang_Object_Handler()
	{
		return new global::_JniMarshal_PPLIL_V(n_DestroyItem_Landroid_view_View_ILjava_lang_Object_);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_DestroyItem_Landroid_view_View_ILjava_lang_Object_(nint jnienv, nint native__this, nint native_container, int position, nint native__object)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			PagerAdapter? pagerAdapter = Java.Lang.Object.GetObject<PagerAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View container = Java.Lang.Object.GetObject<View>(native_container, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native__object, JniHandleOwnership.DoNotTransfer);
			pagerAdapter.DestroyItem(container, position, obj);
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

	[Obsolete("deprecated")]
	[Register("destroyItem", "(Landroid/view/View;ILjava/lang/Object;)V", "GetDestroyItem_Landroid_view_View_ILjava_lang_Object_Handler")]
	public unsafe virtual void DestroyItem(View container, int position, Java.Lang.Object @object)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(container?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(position);
			ptr[2] = new JniArgumentValue(@object?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("destroyItem.(Landroid/view/View;ILjava/lang/Object;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(container);
			GC.KeepAlive(@object);
		}
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_DestroyItem_Landroid_view_ViewGroup_ILjava_lang_Object_(nint jnienv, nint native__this, nint native_container, int position, nint native__object)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			PagerAdapter? pagerAdapter = Java.Lang.Object.GetObject<PagerAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ViewGroup container = Java.Lang.Object.GetObject<ViewGroup>(native_container, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native__object, JniHandleOwnership.DoNotTransfer);
			pagerAdapter.DestroyItem(container, position, obj);
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

	[Register("destroyItem", "(Landroid/view/ViewGroup;ILjava/lang/Object;)V", "GetDestroyItem_Landroid_view_ViewGroup_ILjava_lang_Object_Handler")]
	public unsafe virtual void DestroyItem(ViewGroup container, int position, Java.Lang.Object @object)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(container?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(position);
			ptr[2] = new JniArgumentValue(@object?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("destroyItem.(Landroid/view/ViewGroup;ILjava/lang/Object;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(container);
			GC.KeepAlive(@object);
		}
	}

	[Obsolete]
	private static Delegate GetFinishUpdate_Landroid_view_View_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_FinishUpdate_Landroid_view_View_);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_FinishUpdate_Landroid_view_View_(nint jnienv, nint native__this, nint native_container)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			PagerAdapter? pagerAdapter = Java.Lang.Object.GetObject<PagerAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View container = Java.Lang.Object.GetObject<View>(native_container, JniHandleOwnership.DoNotTransfer);
			pagerAdapter.FinishUpdate(container);
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

	[Obsolete("deprecated")]
	[Register("finishUpdate", "(Landroid/view/View;)V", "GetFinishUpdate_Landroid_view_View_Handler")]
	public unsafe virtual void FinishUpdate(View container)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(container?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("finishUpdate.(Landroid/view/View;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(container);
		}
	}

	private static Delegate GetFinishUpdate_Landroid_view_ViewGroup_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_FinishUpdate_Landroid_view_ViewGroup_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_FinishUpdate_Landroid_view_ViewGroup_(nint jnienv, nint native__this, nint native_container)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			PagerAdapter? pagerAdapter = Java.Lang.Object.GetObject<PagerAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ViewGroup container = Java.Lang.Object.GetObject<ViewGroup>(native_container, JniHandleOwnership.DoNotTransfer);
			pagerAdapter.FinishUpdate(container);
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

	[Register("finishUpdate", "(Landroid/view/ViewGroup;)V", "GetFinishUpdate_Landroid_view_ViewGroup_Handler")]
	public unsafe virtual void FinishUpdate(ViewGroup container)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(container?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("finishUpdate.(Landroid/view/ViewGroup;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(container);
		}
	}

	private static Delegate GetGetItemPosition_Ljava_lang_Object_Handler()
	{
		return new global::_JniMarshal_PPL_I(n_GetItemPosition_Ljava_lang_Object_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetItemPosition_Ljava_lang_Object_(nint jnienv, nint native__this, nint native__object)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			PagerAdapter? pagerAdapter = Java.Lang.Object.GetObject<PagerAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native__object, JniHandleOwnership.DoNotTransfer);
			return pagerAdapter.GetItemPosition(obj);
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

	[Register("getItemPosition", "(Ljava/lang/Object;)I", "GetGetItemPosition_Ljava_lang_Object_Handler")]
	public unsafe virtual int GetItemPosition(Java.Lang.Object @object)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(@object?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualInt32Method("getItemPosition.(Ljava/lang/Object;)I", this, ptr);
		}
		finally
		{
			GC.KeepAlive(@object);
		}
	}

	private static Delegate GetGetPageTitle_IHandler()
	{
		return new global::_JniMarshal_PPI_L(n_GetPageTitle_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetPageTitle_I(nint jnienv, nint native__this, int position)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return CharSequence.ToLocalJniHandle(Java.Lang.Object.GetObject<PagerAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetPageTitleFormatted(position));
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

	[Register("getPageTitle", "(I)Ljava/lang/CharSequence;", "GetGetPageTitle_IHandler")]
	public unsafe virtual ICharSequence? GetPageTitleFormatted(int position)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(position);
		return Java.Lang.Object.GetObject<ICharSequence>(_members.InstanceMethods.InvokeVirtualObjectMethod("getPageTitle.(I)Ljava/lang/CharSequence;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	public string? GetPageTitle(int position)
	{
		return GetPageTitleFormatted(position)?.ToString();
	}

	private static Delegate GetGetPageWidth_IHandler()
	{
		return new global::_JniMarshal_PPI_F(n_GetPageWidth_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetPageWidth_I(nint jnienv, nint native__this, int position)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<PagerAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetPageWidth(position);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0f;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("getPageWidth", "(I)F", "GetGetPageWidth_IHandler")]
	public unsafe virtual float GetPageWidth(int position)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(position);
		return _members.InstanceMethods.InvokeVirtualSingleMethod("getPageWidth.(I)F", this, ptr);
	}

	[Obsolete]
	private static Delegate GetInstantiateItem_Landroid_view_View_IHandler()
	{
		return new global::_JniMarshal_PPLI_L(n_InstantiateItem_Landroid_view_View_I);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_InstantiateItem_Landroid_view_View_I(nint jnienv, nint native__this, nint native_container, int position)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			PagerAdapter? pagerAdapter = Java.Lang.Object.GetObject<PagerAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View container = Java.Lang.Object.GetObject<View>(native_container, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(pagerAdapter.InstantiateItem(container, position));
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

	[Obsolete("deprecated")]
	[Register("instantiateItem", "(Landroid/view/View;I)Ljava/lang/Object;", "GetInstantiateItem_Landroid_view_View_IHandler")]
	public unsafe virtual Java.Lang.Object InstantiateItem(View container, int position)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(container?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(position);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("instantiateItem.(Landroid/view/View;I)Ljava/lang/Object;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(container);
		}
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_InstantiateItem_Landroid_view_ViewGroup_I(nint jnienv, nint native__this, nint native_container, int position)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			PagerAdapter? pagerAdapter = Java.Lang.Object.GetObject<PagerAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ViewGroup container = Java.Lang.Object.GetObject<ViewGroup>(native_container, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(pagerAdapter.InstantiateItem(container, position));
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

	[Register("instantiateItem", "(Landroid/view/ViewGroup;I)Ljava/lang/Object;", "GetInstantiateItem_Landroid_view_ViewGroup_IHandler")]
	public unsafe virtual Java.Lang.Object InstantiateItem(ViewGroup container, int position)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(container?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(position);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("instantiateItem.(Landroid/view/ViewGroup;I)Ljava/lang/Object;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(container);
		}
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsViewFromObject_Landroid_view_View_Ljava_lang_Object_(nint jnienv, nint native__this, nint native_view, nint native__object)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			PagerAdapter? pagerAdapter = Java.Lang.Object.GetObject<PagerAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View view = Java.Lang.Object.GetObject<View>(native_view, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native__object, JniHandleOwnership.DoNotTransfer);
			return pagerAdapter.IsViewFromObject(view, obj) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("isViewFromObject", "(Landroid/view/View;Ljava/lang/Object;)Z", "GetIsViewFromObject_Landroid_view_View_Ljava_lang_Object_Handler")]
	public abstract bool IsViewFromObject(View view, Java.Lang.Object @object);

	private static Delegate GetNotifyDataSetChangedHandler()
	{
		return new global::_JniMarshal_PP_V(n_NotifyDataSetChanged);
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
			Java.Lang.Object.GetObject<PagerAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).NotifyDataSetChanged();
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
		return new global::_JniMarshal_PPL_V(n_RegisterDataSetObserver_Landroid_database_DataSetObserver_);
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
			PagerAdapter? pagerAdapter = Java.Lang.Object.GetObject<PagerAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			DataSetObserver observer = Java.Lang.Object.GetObject<DataSetObserver>(native_observer, JniHandleOwnership.DoNotTransfer);
			pagerAdapter.RegisterDataSetObserver(observer);
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
	public unsafe virtual void RegisterDataSetObserver(DataSetObserver observer)
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

	private static Delegate GetRestoreState_Landroid_os_Parcelable_Ljava_lang_ClassLoader_Handler()
	{
		return new global::_JniMarshal_PPLL_V(n_RestoreState_Landroid_os_Parcelable_Ljava_lang_ClassLoader_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_RestoreState_Landroid_os_Parcelable_Ljava_lang_ClassLoader_(nint jnienv, nint native__this, nint native_state, nint native_loader)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			PagerAdapter? pagerAdapter = Java.Lang.Object.GetObject<PagerAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IParcelable state = Java.Lang.Object.GetObject<IParcelable>(native_state, JniHandleOwnership.DoNotTransfer);
			ClassLoader loader = Java.Lang.Object.GetObject<ClassLoader>(native_loader, JniHandleOwnership.DoNotTransfer);
			pagerAdapter.RestoreState(state, loader);
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

	[Register("restoreState", "(Landroid/os/Parcelable;Ljava/lang/ClassLoader;)V", "GetRestoreState_Landroid_os_Parcelable_Ljava_lang_ClassLoader_Handler")]
	public unsafe virtual void RestoreState(IParcelable? state, ClassLoader? loader)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue((state == null) ? IntPtr.Zero : ((Java.Lang.Object)state).Handle);
			ptr[1] = new JniArgumentValue(loader?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("restoreState.(Landroid/os/Parcelable;Ljava/lang/ClassLoader;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(state);
			GC.KeepAlive(loader);
		}
	}

	private static Delegate GetSaveStateHandler()
	{
		return new global::_JniMarshal_PP_L(n_SaveState);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_SaveState(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<PagerAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SaveState());
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

	[Register("saveState", "()Landroid/os/Parcelable;", "GetSaveStateHandler")]
	public unsafe virtual IParcelable? SaveState()
	{
		return Java.Lang.Object.GetObject<IParcelable>(_members.InstanceMethods.InvokeVirtualObjectMethod("saveState.()Landroid/os/Parcelable;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Obsolete]
	private static Delegate GetSetPrimaryItem_Landroid_view_View_ILjava_lang_Object_Handler()
	{
		return new global::_JniMarshal_PPLIL_V(n_SetPrimaryItem_Landroid_view_View_ILjava_lang_Object_);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetPrimaryItem_Landroid_view_View_ILjava_lang_Object_(nint jnienv, nint native__this, nint native_container, int position, nint native__object)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			PagerAdapter? pagerAdapter = Java.Lang.Object.GetObject<PagerAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View container = Java.Lang.Object.GetObject<View>(native_container, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native__object, JniHandleOwnership.DoNotTransfer);
			pagerAdapter.SetPrimaryItem(container, position, obj);
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

	[Obsolete("deprecated")]
	[Register("setPrimaryItem", "(Landroid/view/View;ILjava/lang/Object;)V", "GetSetPrimaryItem_Landroid_view_View_ILjava_lang_Object_Handler")]
	public unsafe virtual void SetPrimaryItem(View container, int position, Java.Lang.Object @object)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(container?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(position);
			ptr[2] = new JniArgumentValue(@object?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setPrimaryItem.(Landroid/view/View;ILjava/lang/Object;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(container);
			GC.KeepAlive(@object);
		}
	}

	private static Delegate GetSetPrimaryItem_Landroid_view_ViewGroup_ILjava_lang_Object_Handler()
	{
		return new global::_JniMarshal_PPLIL_V(n_SetPrimaryItem_Landroid_view_ViewGroup_ILjava_lang_Object_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetPrimaryItem_Landroid_view_ViewGroup_ILjava_lang_Object_(nint jnienv, nint native__this, nint native_container, int position, nint native__object)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			PagerAdapter? pagerAdapter = Java.Lang.Object.GetObject<PagerAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ViewGroup container = Java.Lang.Object.GetObject<ViewGroup>(native_container, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native__object, JniHandleOwnership.DoNotTransfer);
			pagerAdapter.SetPrimaryItem(container, position, obj);
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

	[Register("setPrimaryItem", "(Landroid/view/ViewGroup;ILjava/lang/Object;)V", "GetSetPrimaryItem_Landroid_view_ViewGroup_ILjava_lang_Object_Handler")]
	public unsafe virtual void SetPrimaryItem(ViewGroup container, int position, Java.Lang.Object @object)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(container?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(position);
			ptr[2] = new JniArgumentValue(@object?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setPrimaryItem.(Landroid/view/ViewGroup;ILjava/lang/Object;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(container);
			GC.KeepAlive(@object);
		}
	}

	[Obsolete]
	private static Delegate GetStartUpdate_Landroid_view_View_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_StartUpdate_Landroid_view_View_);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_StartUpdate_Landroid_view_View_(nint jnienv, nint native__this, nint native_container)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			PagerAdapter? pagerAdapter = Java.Lang.Object.GetObject<PagerAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View container = Java.Lang.Object.GetObject<View>(native_container, JniHandleOwnership.DoNotTransfer);
			pagerAdapter.StartUpdate(container);
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

	[Obsolete("deprecated")]
	[Register("startUpdate", "(Landroid/view/View;)V", "GetStartUpdate_Landroid_view_View_Handler")]
	public unsafe virtual void StartUpdate(View container)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(container?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("startUpdate.(Landroid/view/View;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(container);
		}
	}

	private static Delegate GetStartUpdate_Landroid_view_ViewGroup_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_StartUpdate_Landroid_view_ViewGroup_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_StartUpdate_Landroid_view_ViewGroup_(nint jnienv, nint native__this, nint native_container)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			PagerAdapter? pagerAdapter = Java.Lang.Object.GetObject<PagerAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ViewGroup container = Java.Lang.Object.GetObject<ViewGroup>(native_container, JniHandleOwnership.DoNotTransfer);
			pagerAdapter.StartUpdate(container);
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

	[Register("startUpdate", "(Landroid/view/ViewGroup;)V", "GetStartUpdate_Landroid_view_ViewGroup_Handler")]
	public unsafe virtual void StartUpdate(ViewGroup container)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(container?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("startUpdate.(Landroid/view/ViewGroup;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(container);
		}
	}

	private static Delegate GetUnregisterDataSetObserver_Landroid_database_DataSetObserver_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_UnregisterDataSetObserver_Landroid_database_DataSetObserver_);
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
			PagerAdapter? pagerAdapter = Java.Lang.Object.GetObject<PagerAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			DataSetObserver observer = Java.Lang.Object.GetObject<DataSetObserver>(native_observer, JniHandleOwnership.DoNotTransfer);
			pagerAdapter.UnregisterDataSetObserver(observer);
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
	public unsafe virtual void UnregisterDataSetObserver(DataSetObserver observer)
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
			Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
			return 0;
		}
	}

	[UnmanagedCallersOnly]
	private static sbyte n_IsViewFromObject_Landroid_view_View_Ljava_lang_Object__mm_wrapper(nint jnienv, nint native__this, nint native_view, nint native__object)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			return n_IsViewFromObject_Landroid_view_View_Ljava_lang_Object_(jnienv, native__this, native_view, native__object);
		}
		catch (System.Exception e)
		{
			Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
			return 0;
		}
	}

	[UnmanagedCallersOnly]
	private static nint n_InstantiateItem_Landroid_view_ViewGroup_I_mm_wrapper(nint jnienv, nint native__this, nint native_container, int position)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			return n_InstantiateItem_Landroid_view_ViewGroup_I(jnienv, native__this, native_container, position);
		}
		catch (System.Exception e)
		{
			Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
			return 0;
		}
	}

	[UnmanagedCallersOnly]
	private static void n_DestroyItem_Landroid_view_ViewGroup_ILjava_lang_Object__mm_wrapper(nint jnienv, nint native__this, nint native_container, int position, nint native__object)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			n_DestroyItem_Landroid_view_ViewGroup_ILjava_lang_Object_(jnienv, native__this, native_container, position, native__object);
		}
		catch (System.Exception e)
		{
			Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
		}
	}
}
