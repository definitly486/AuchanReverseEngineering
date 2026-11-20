using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Bumptech.Glide.Load.Data;

[Register("com/bumptech/glide/load/data/DataFetcher$DataCallback", DoNotGenerateAcw = true)]
internal class IDataFetcherDataCallbackInvoker : Java.Lang.Object, IDataFetcherDataCallback, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_com_bumptech_glide_load_data_DataFetcher_DataCallback = new XAPeerMembers("com/bumptech/glide/load/data/DataFetcher$DataCallback", typeof(IDataFetcherDataCallbackInvoker));

	private static Delegate? cb_onDataReady_OnDataReady_Ljava_lang_Object__V;

	private static Delegate? cb_onLoadFailed_OnLoadFailed_Ljava_lang_Exception__V;

	private static nint java_class_ref => _members_com_bumptech_glide_load_data_DataFetcher_DataCallback.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_com_bumptech_glide_load_data_DataFetcher_DataCallback;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_com_bumptech_glide_load_data_DataFetcher_DataCallback.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_com_bumptech_glide_load_data_DataFetcher_DataCallback.ManagedPeerType;

	public IDataFetcherDataCallbackInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetOnDataReady_Ljava_lang_Object_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_OnDataReady_Ljava_lang_Object_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnDataReady_Ljava_lang_Object_(nint jnienv, nint native__this, nint native_p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IDataFetcherDataCallback? dataFetcherDataCallback = Java.Lang.Object.GetObject<IDataFetcherDataCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object p = Java.Lang.Object.GetObject<Java.Lang.Object>(native_p0, JniHandleOwnership.DoNotTransfer);
			dataFetcherDataCallback.OnDataReady(p);
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

	public unsafe void OnDataReady(Java.Lang.Object? p0)
	{
		nint num = JNIEnv.ToLocalJniHandle(p0);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members_com_bumptech_glide_load_data_DataFetcher_DataCallback.InstanceMethods.InvokeAbstractVoidMethod("onDataReady.(Ljava/lang/Object;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetOnLoadFailed_Ljava_lang_Exception_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_OnLoadFailed_Ljava_lang_Exception_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnLoadFailed_Ljava_lang_Exception_(nint jnienv, nint native__this, nint native_p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IDataFetcherDataCallback? dataFetcherDataCallback = Java.Lang.Object.GetObject<IDataFetcherDataCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Exception p = Java.Lang.Object.GetObject<Java.Lang.Exception>(native_p0, JniHandleOwnership.DoNotTransfer);
			dataFetcherDataCallback.OnLoadFailed(p);
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

	public unsafe void OnLoadFailed(Java.Lang.Exception p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			_members_com_bumptech_glide_load_data_DataFetcher_DataCallback.InstanceMethods.InvokeAbstractVoidMethod("onLoadFailed.(Ljava/lang/Exception;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
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
