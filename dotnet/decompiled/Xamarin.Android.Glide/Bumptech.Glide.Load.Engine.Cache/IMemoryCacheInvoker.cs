using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Bumptech.Glide.Load.Engine.Cache;

[Register("com/bumptech/glide/load/engine/cache/MemoryCache", DoNotGenerateAcw = true)]
internal class IMemoryCacheInvoker : Java.Lang.Object, IMemoryCache, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_com_bumptech_glide_load_engine_cache_MemoryCache = new XAPeerMembers("com/bumptech/glide/load/engine/cache/MemoryCache", typeof(IMemoryCacheInvoker));

	private static Delegate? cb_getCurrentSize_GetCurrentSize_J;

	private static Delegate? cb_getMaxSize_GetMaxSize_J;

	private static Delegate? cb_clearMemory_ClearMemory_V;

	private static Delegate? cb_put_Put_Lcom_bumptech_glide_load_Key_Lcom_bumptech_glide_load_engine_Resource__Lcom_bumptech_glide_load_engine_Resource_;

	private static Delegate? cb_remove_Remove_Lcom_bumptech_glide_load_Key__Lcom_bumptech_glide_load_engine_Resource_;

	private static Delegate? cb_setResourceRemovedListener_SetResourceRemovedListener_Lcom_bumptech_glide_load_engine_cache_MemoryCache_ResourceRemovedListener__V;

	private static Delegate? cb_setSizeMultiplier_SetSizeMultiplier_F_V;

	private static Delegate? cb_trimMemory_TrimMemory_I_V;

	private static nint java_class_ref => _members_com_bumptech_glide_load_engine_cache_MemoryCache.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_com_bumptech_glide_load_engine_cache_MemoryCache;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_com_bumptech_glide_load_engine_cache_MemoryCache.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_com_bumptech_glide_load_engine_cache_MemoryCache.ManagedPeerType;

	public unsafe long CurrentSize => _members_com_bumptech_glide_load_engine_cache_MemoryCache.InstanceMethods.InvokeAbstractInt64Method("getCurrentSize.()J", this, null);

	public unsafe long MaxSize => _members_com_bumptech_glide_load_engine_cache_MemoryCache.InstanceMethods.InvokeAbstractInt64Method("getMaxSize.()J", this, null);

	public IMemoryCacheInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetGetCurrentSizeHandler()
	{
		return new global::_JniMarshal_PP_J(n_GetCurrentSize);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static long n_GetCurrentSize(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0L;
		}
		try
		{
			return Java.Lang.Object.GetObject<IMemoryCache>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CurrentSize;
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

	private static Delegate GetGetMaxSizeHandler()
	{
		return new global::_JniMarshal_PP_J(n_GetMaxSize);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static long n_GetMaxSize(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0L;
		}
		try
		{
			return Java.Lang.Object.GetObject<IMemoryCache>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MaxSize;
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

	private static Delegate GetClearMemoryHandler()
	{
		return new global::_JniMarshal_PP_V(n_ClearMemory);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_ClearMemory(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IMemoryCache>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ClearMemory();
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

	public unsafe void ClearMemory()
	{
		_members_com_bumptech_glide_load_engine_cache_MemoryCache.InstanceMethods.InvokeAbstractVoidMethod("clearMemory.()V", this, null);
	}

	private static Delegate GetPut_Lcom_bumptech_glide_load_Key_Lcom_bumptech_glide_load_engine_Resource_Handler()
	{
		return new global::_JniMarshal_PPLL_L(n_Put_Lcom_bumptech_glide_load_Key_Lcom_bumptech_glide_load_engine_Resource_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Put_Lcom_bumptech_glide_load_Key_Lcom_bumptech_glide_load_engine_Resource_(nint jnienv, nint native__this, nint native_p0, nint native_p1)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IMemoryCache? memoryCache = Java.Lang.Object.GetObject<IMemoryCache>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IKey p = Java.Lang.Object.GetObject<IKey>(native_p0, JniHandleOwnership.DoNotTransfer);
			IResource p2 = Java.Lang.Object.GetObject<IResource>(native_p1, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(memoryCache.Put(p, p2));
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

	public unsafe IResource? Put(IKey p0, IResource? p1)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			ptr[1] = new JniArgumentValue((p1 == null) ? IntPtr.Zero : ((Java.Lang.Object)p1).Handle);
			return Java.Lang.Object.GetObject<IResource>(_members_com_bumptech_glide_load_engine_cache_MemoryCache.InstanceMethods.InvokeAbstractObjectMethod("put.(Lcom/bumptech/glide/load/Key;Lcom/bumptech/glide/load/engine/Resource;)Lcom/bumptech/glide/load/engine/Resource;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(p0);
			GC.KeepAlive(p1);
		}
	}

	private static Delegate GetRemove_Lcom_bumptech_glide_load_Key_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_Remove_Lcom_bumptech_glide_load_Key_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Remove_Lcom_bumptech_glide_load_Key_(nint jnienv, nint native__this, nint native_p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IMemoryCache? memoryCache = Java.Lang.Object.GetObject<IMemoryCache>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IKey p = Java.Lang.Object.GetObject<IKey>(native_p0, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(memoryCache.Remove(p));
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

	public unsafe IResource? Remove(IKey p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			return Java.Lang.Object.GetObject<IResource>(_members_com_bumptech_glide_load_engine_cache_MemoryCache.InstanceMethods.InvokeAbstractObjectMethod("remove.(Lcom/bumptech/glide/load/Key;)Lcom/bumptech/glide/load/engine/Resource;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetSetResourceRemovedListener_Lcom_bumptech_glide_load_engine_cache_MemoryCache_ResourceRemovedListener_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetResourceRemovedListener_Lcom_bumptech_glide_load_engine_cache_MemoryCache_ResourceRemovedListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetResourceRemovedListener_Lcom_bumptech_glide_load_engine_cache_MemoryCache_ResourceRemovedListener_(nint jnienv, nint native__this, nint native_p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IMemoryCache? memoryCache = Java.Lang.Object.GetObject<IMemoryCache>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IMemoryCacheResourceRemovedListener resourceRemovedListener = Java.Lang.Object.GetObject<IMemoryCacheResourceRemovedListener>(native_p0, JniHandleOwnership.DoNotTransfer);
			memoryCache.SetResourceRemovedListener(resourceRemovedListener);
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

	public unsafe void SetResourceRemovedListener(IMemoryCacheResourceRemovedListener p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			_members_com_bumptech_glide_load_engine_cache_MemoryCache.InstanceMethods.InvokeAbstractVoidMethod("setResourceRemovedListener.(Lcom/bumptech/glide/load/engine/cache/MemoryCache$ResourceRemovedListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetSetSizeMultiplier_FHandler()
	{
		return new global::_JniMarshal_PPF_V(n_SetSizeMultiplier_F);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetSizeMultiplier_F(nint jnienv, nint native__this, float p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IMemoryCache>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetSizeMultiplier(p0);
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

	public unsafe void SetSizeMultiplier(float p0)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(p0);
		_members_com_bumptech_glide_load_engine_cache_MemoryCache.InstanceMethods.InvokeAbstractVoidMethod("setSizeMultiplier.(F)V", this, ptr);
	}

	private static Delegate GetTrimMemory_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_TrimMemory_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_TrimMemory_I(nint jnienv, nint native__this, int p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IMemoryCache>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TrimMemory(p0);
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

	public unsafe void TrimMemory(int p0)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(p0);
		_members_com_bumptech_glide_load_engine_cache_MemoryCache.InstanceMethods.InvokeAbstractVoidMethod("trimMemory.(I)V", this, ptr);
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
