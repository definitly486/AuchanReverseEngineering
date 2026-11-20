using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.IO;
using Java.Interop;
using Java.Lang;

namespace Bumptech.Glide.Load.Engine.Cache;

[Register("com/bumptech/glide/load/engine/cache/DiskCache", DoNotGenerateAcw = true)]
internal class IDiskCacheInvoker : Java.Lang.Object, IDiskCache, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_com_bumptech_glide_load_engine_cache_DiskCache = new XAPeerMembers("com/bumptech/glide/load/engine/cache/DiskCache", typeof(IDiskCacheInvoker));

	private static Delegate? cb_clear_Clear_V;

	private static Delegate? cb_delete_Delete_Lcom_bumptech_glide_load_Key__V;

	private static Delegate? cb_get_Get_Lcom_bumptech_glide_load_Key__Ljava_io_File_;

	private static Delegate? cb_put_Put_Lcom_bumptech_glide_load_Key_Lcom_bumptech_glide_load_engine_cache_DiskCache_Writer__V;

	private static nint java_class_ref => _members_com_bumptech_glide_load_engine_cache_DiskCache.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_com_bumptech_glide_load_engine_cache_DiskCache;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_com_bumptech_glide_load_engine_cache_DiskCache.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_com_bumptech_glide_load_engine_cache_DiskCache.ManagedPeerType;

	public IDiskCacheInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetClearHandler()
	{
		return new global::_JniMarshal_PP_V(n_Clear);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Clear(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IDiskCache>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Clear();
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

	public unsafe void Clear()
	{
		_members_com_bumptech_glide_load_engine_cache_DiskCache.InstanceMethods.InvokeAbstractVoidMethod("clear.()V", this, null);
	}

	private static Delegate GetDelete_Lcom_bumptech_glide_load_Key_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_Delete_Lcom_bumptech_glide_load_Key_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Delete_Lcom_bumptech_glide_load_Key_(nint jnienv, nint native__this, nint native_p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IDiskCache? diskCache = Java.Lang.Object.GetObject<IDiskCache>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IKey p = Java.Lang.Object.GetObject<IKey>(native_p0, JniHandleOwnership.DoNotTransfer);
			diskCache.Delete(p);
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

	public unsafe void Delete(IKey? p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			_members_com_bumptech_glide_load_engine_cache_DiskCache.InstanceMethods.InvokeAbstractVoidMethod("delete.(Lcom/bumptech/glide/load/Key;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetGet_Lcom_bumptech_glide_load_Key_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_Get_Lcom_bumptech_glide_load_Key_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Get_Lcom_bumptech_glide_load_Key_(nint jnienv, nint native__this, nint native_p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IDiskCache? diskCache = Java.Lang.Object.GetObject<IDiskCache>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IKey p = Java.Lang.Object.GetObject<IKey>(native_p0, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(diskCache.Get(p));
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

	public unsafe File? Get(IKey? p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			return Java.Lang.Object.GetObject<File>(_members_com_bumptech_glide_load_engine_cache_DiskCache.InstanceMethods.InvokeAbstractObjectMethod("get.(Lcom/bumptech/glide/load/Key;)Ljava/io/File;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetPut_Lcom_bumptech_glide_load_Key_Lcom_bumptech_glide_load_engine_cache_DiskCache_Writer_Handler()
	{
		return new global::_JniMarshal_PPLL_V(n_Put_Lcom_bumptech_glide_load_Key_Lcom_bumptech_glide_load_engine_cache_DiskCache_Writer_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Put_Lcom_bumptech_glide_load_Key_Lcom_bumptech_glide_load_engine_cache_DiskCache_Writer_(nint jnienv, nint native__this, nint native_p0, nint native_p1)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IDiskCache? diskCache = Java.Lang.Object.GetObject<IDiskCache>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IKey p = Java.Lang.Object.GetObject<IKey>(native_p0, JniHandleOwnership.DoNotTransfer);
			IDiskCacheWriter p2 = Java.Lang.Object.GetObject<IDiskCacheWriter>(native_p1, JniHandleOwnership.DoNotTransfer);
			diskCache.Put(p, p2);
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

	public unsafe void Put(IKey? p0, IDiskCacheWriter? p1)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			ptr[1] = new JniArgumentValue((p1 == null) ? IntPtr.Zero : ((Java.Lang.Object)p1).Handle);
			_members_com_bumptech_glide_load_engine_cache_DiskCache.InstanceMethods.InvokeAbstractVoidMethod("put.(Lcom/bumptech/glide/load/Key;Lcom/bumptech/glide/load/engine/cache/DiskCache$Writer;)V", this, ptr);
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
