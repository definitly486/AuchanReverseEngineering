using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Bumptech.Glide.Load.Data;

[Register("com/bumptech/glide/load/data/DataFetcher", DoNotGenerateAcw = true)]
internal class IDataFetcherInvoker : Java.Lang.Object, IDataFetcher, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_com_bumptech_glide_load_data_DataFetcher = new XAPeerMembers("com/bumptech/glide/load/data/DataFetcher", typeof(IDataFetcherInvoker));

	private static Delegate? cb_getDataClass_GetDataClass_Ljava_lang_Class_;

	private static Delegate? cb_getDataSource_GetDataSource_Lcom_bumptech_glide_load_DataSource_;

	private static Delegate? cb_cancel_Cancel_V;

	private static Delegate? cb_cleanup_Cleanup_V;

	private static Delegate? cb_loadData_LoadData_Lcom_bumptech_glide_Priority_Lcom_bumptech_glide_load_data_DataFetcher_DataCallback__V;

	private static nint java_class_ref => _members_com_bumptech_glide_load_data_DataFetcher.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_com_bumptech_glide_load_data_DataFetcher;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_com_bumptech_glide_load_data_DataFetcher.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_com_bumptech_glide_load_data_DataFetcher.ManagedPeerType;

	public unsafe Class DataClass => Java.Lang.Object.GetObject<Class>(_members_com_bumptech_glide_load_data_DataFetcher.InstanceMethods.InvokeAbstractObjectMethod("getDataClass.()Ljava/lang/Class;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public unsafe DataSource DataSource => Java.Lang.Object.GetObject<DataSource>(_members_com_bumptech_glide_load_data_DataFetcher.InstanceMethods.InvokeAbstractObjectMethod("getDataSource.()Lcom/bumptech/glide/load/DataSource;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public IDataFetcherInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetGetDataClassHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetDataClass);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetDataClass(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IDataFetcher>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DataClass);
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

	private static Delegate GetGetDataSourceHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetDataSource);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetDataSource(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IDataFetcher>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DataSource);
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

	private static Delegate GetCancelHandler()
	{
		return new global::_JniMarshal_PP_V(n_Cancel);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Cancel(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IDataFetcher>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Cancel();
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

	public unsafe void Cancel()
	{
		_members_com_bumptech_glide_load_data_DataFetcher.InstanceMethods.InvokeAbstractVoidMethod("cancel.()V", this, null);
	}

	private static Delegate GetCleanupHandler()
	{
		return new global::_JniMarshal_PP_V(n_Cleanup);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Cleanup(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IDataFetcher>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Cleanup();
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

	public unsafe void Cleanup()
	{
		_members_com_bumptech_glide_load_data_DataFetcher.InstanceMethods.InvokeAbstractVoidMethod("cleanup.()V", this, null);
	}

	private static Delegate GetLoadData_Lcom_bumptech_glide_Priority_Lcom_bumptech_glide_load_data_DataFetcher_DataCallback_Handler()
	{
		return new global::_JniMarshal_PPLL_V(n_LoadData_Lcom_bumptech_glide_Priority_Lcom_bumptech_glide_load_data_DataFetcher_DataCallback_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_LoadData_Lcom_bumptech_glide_Priority_Lcom_bumptech_glide_load_data_DataFetcher_DataCallback_(nint jnienv, nint native__this, nint native_p0, nint native_p1)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IDataFetcher? dataFetcher = Java.Lang.Object.GetObject<IDataFetcher>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Priority p = Java.Lang.Object.GetObject<Priority>(native_p0, JniHandleOwnership.DoNotTransfer);
			IDataFetcherDataCallback p2 = Java.Lang.Object.GetObject<IDataFetcherDataCallback>(native_p1, JniHandleOwnership.DoNotTransfer);
			dataFetcher.LoadData(p, p2);
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

	public unsafe void LoadData(Priority p0, IDataFetcherDataCallback p1)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((p1 == null) ? IntPtr.Zero : ((Java.Lang.Object)p1).Handle);
			_members_com_bumptech_glide_load_data_DataFetcher.InstanceMethods.InvokeAbstractVoidMethod("loadData.(Lcom/bumptech/glide/Priority;Lcom/bumptech/glide/load/data/DataFetcher$DataCallback;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
			GC.KeepAlive(p1);
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
