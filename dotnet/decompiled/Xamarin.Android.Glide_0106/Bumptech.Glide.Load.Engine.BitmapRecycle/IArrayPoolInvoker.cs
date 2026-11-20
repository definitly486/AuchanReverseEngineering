using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Bumptech.Glide.Load.Engine.BitmapRecycle;

[Register("com/bumptech/glide/load/engine/bitmap_recycle/ArrayPool", DoNotGenerateAcw = true)]
internal class IArrayPoolInvoker : Java.Lang.Object, IArrayPool, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_com_bumptech_glide_load_engine_bitmap_recycle_ArrayPool = new XAPeerMembers("com/bumptech/glide/load/engine/bitmap_recycle/ArrayPool", typeof(IArrayPoolInvoker));

	private static Delegate? cb_clearMemory_ClearMemory_V;

	private static Delegate? cb_get_Get_ILjava_lang_Class__Ljava_lang_Object_;

	private static Delegate? cb_getExact_GetExact_ILjava_lang_Class__Ljava_lang_Object_;

	private static Delegate? cb_put_Put_Ljava_lang_Object__V;

	private static Delegate? cb_put_Put_Ljava_lang_Object_Ljava_lang_Class__V;

	private static Delegate? cb_trimMemory_TrimMemory_I_V;

	private static nint java_class_ref => _members_com_bumptech_glide_load_engine_bitmap_recycle_ArrayPool.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_com_bumptech_glide_load_engine_bitmap_recycle_ArrayPool;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_com_bumptech_glide_load_engine_bitmap_recycle_ArrayPool.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_com_bumptech_glide_load_engine_bitmap_recycle_ArrayPool.ManagedPeerType;

	public IArrayPoolInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
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
			Java.Lang.Object.GetObject<IArrayPool>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ClearMemory();
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
		_members_com_bumptech_glide_load_engine_bitmap_recycle_ArrayPool.InstanceMethods.InvokeAbstractVoidMethod("clearMemory.()V", this, null);
	}

	private static Delegate GetGet_ILjava_lang_Class_Handler()
	{
		return new global::_JniMarshal_PPIL_L(n_Get_ILjava_lang_Class_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Get_ILjava_lang_Class_(nint jnienv, nint native__this, int p0, nint native_p1)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IArrayPool? arrayPool = Java.Lang.Object.GetObject<IArrayPool>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Class p1 = Java.Lang.Object.GetObject<Class>(native_p1, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(arrayPool.Get(p0, p1));
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

	public unsafe Java.Lang.Object? Get(int p0, Class? p1)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(p0);
			ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members_com_bumptech_glide_load_engine_bitmap_recycle_ArrayPool.InstanceMethods.InvokeAbstractObjectMethod("get.(ILjava/lang/Class;)Ljava/lang/Object;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(p1);
		}
	}

	private static Delegate GetGetExact_ILjava_lang_Class_Handler()
	{
		return new global::_JniMarshal_PPIL_L(n_GetExact_ILjava_lang_Class_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetExact_ILjava_lang_Class_(nint jnienv, nint native__this, int p0, nint native_p1)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IArrayPool? arrayPool = Java.Lang.Object.GetObject<IArrayPool>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Class p1 = Java.Lang.Object.GetObject<Class>(native_p1, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(arrayPool.GetExact(p0, p1));
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

	public unsafe Java.Lang.Object? GetExact(int p0, Class? p1)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(p0);
			ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members_com_bumptech_glide_load_engine_bitmap_recycle_ArrayPool.InstanceMethods.InvokeAbstractObjectMethod("getExact.(ILjava/lang/Class;)Ljava/lang/Object;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(p1);
		}
	}

	private static Delegate GetPut_Ljava_lang_Object_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_Put_Ljava_lang_Object_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Put_Ljava_lang_Object_(nint jnienv, nint native__this, nint native_p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IArrayPool? arrayPool = Java.Lang.Object.GetObject<IArrayPool>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object p = Java.Lang.Object.GetObject<Java.Lang.Object>(native_p0, JniHandleOwnership.DoNotTransfer);
			arrayPool.Put(p);
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

	public unsafe void Put(Java.Lang.Object? p0)
	{
		nint num = JNIEnv.ToLocalJniHandle(p0);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members_com_bumptech_glide_load_engine_bitmap_recycle_ArrayPool.InstanceMethods.InvokeAbstractVoidMethod("put.(Ljava/lang/Object;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(p0);
		}
	}

	[Obsolete]
	private static Delegate GetPut_Ljava_lang_Object_Ljava_lang_Class_Handler()
	{
		return new global::_JniMarshal_PPLL_V(n_Put_Ljava_lang_Object_Ljava_lang_Class_);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Put_Ljava_lang_Object_Ljava_lang_Class_(nint jnienv, nint native__this, nint native_p0, nint native_p1)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IArrayPool? arrayPool = Java.Lang.Object.GetObject<IArrayPool>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object p = Java.Lang.Object.GetObject<Java.Lang.Object>(native_p0, JniHandleOwnership.DoNotTransfer);
			Class p2 = Java.Lang.Object.GetObject<Class>(native_p1, JniHandleOwnership.DoNotTransfer);
			arrayPool.Put(p, p2);
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

	public unsafe void Put(Java.Lang.Object? p0, Class? p1)
	{
		nint num = JNIEnv.ToLocalJniHandle(p0);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
			_members_com_bumptech_glide_load_engine_bitmap_recycle_ArrayPool.InstanceMethods.InvokeAbstractVoidMethod("put.(Ljava/lang/Object;Ljava/lang/Class;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(p0);
			GC.KeepAlive(p1);
		}
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
			Java.Lang.Object.GetObject<IArrayPool>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TrimMemory(p0);
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
		_members_com_bumptech_glide_load_engine_bitmap_recycle_ArrayPool.InstanceMethods.InvokeAbstractVoidMethod("trimMemory.(I)V", this, ptr);
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
