using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Graphics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Bumptech.Glide.Load.Engine.BitmapRecycle;

[Register("com/bumptech/glide/load/engine/bitmap_recycle/BitmapPool", DoNotGenerateAcw = true)]
internal class IBitmapPoolInvoker : Java.Lang.Object, IBitmapPool, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_com_bumptech_glide_load_engine_bitmap_recycle_BitmapPool = new XAPeerMembers("com/bumptech/glide/load/engine/bitmap_recycle/BitmapPool", typeof(IBitmapPoolInvoker));

	private static Delegate? cb_getMaxSize_GetMaxSize_J;

	private static Delegate? cb_clearMemory_ClearMemory_V;

	private static Delegate? cb_get_Get_IILandroid_graphics_Bitmap_Config__Landroid_graphics_Bitmap_;

	private static Delegate? cb_getDirty_GetDirty_IILandroid_graphics_Bitmap_Config__Landroid_graphics_Bitmap_;

	private static Delegate? cb_put_Put_Landroid_graphics_Bitmap__V;

	private static Delegate? cb_setSizeMultiplier_SetSizeMultiplier_F_V;

	private static Delegate? cb_trimMemory_TrimMemory_I_V;

	private static nint java_class_ref => _members_com_bumptech_glide_load_engine_bitmap_recycle_BitmapPool.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_com_bumptech_glide_load_engine_bitmap_recycle_BitmapPool;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_com_bumptech_glide_load_engine_bitmap_recycle_BitmapPool.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_com_bumptech_glide_load_engine_bitmap_recycle_BitmapPool.ManagedPeerType;

	public unsafe long MaxSize => _members_com_bumptech_glide_load_engine_bitmap_recycle_BitmapPool.InstanceMethods.InvokeAbstractInt64Method("getMaxSize.()J", this, null);

	public IBitmapPoolInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
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
			return Java.Lang.Object.GetObject<IBitmapPool>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MaxSize;
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
			Java.Lang.Object.GetObject<IBitmapPool>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ClearMemory();
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
		_members_com_bumptech_glide_load_engine_bitmap_recycle_BitmapPool.InstanceMethods.InvokeAbstractVoidMethod("clearMemory.()V", this, null);
	}

	private static Delegate GetGet_IILandroid_graphics_Bitmap_Config_Handler()
	{
		return new global::_JniMarshal_PPIIL_L(n_Get_IILandroid_graphics_Bitmap_Config_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Get_IILandroid_graphics_Bitmap_Config_(nint jnienv, nint native__this, int p0, int p1, nint native_p2)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IBitmapPool? bitmapPool = Java.Lang.Object.GetObject<IBitmapPool>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Bitmap.Config p2 = Java.Lang.Object.GetObject<Bitmap.Config>(native_p2, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(bitmapPool.Get(p0, p1, p2));
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

	public unsafe Bitmap Get(int p0, int p1, Bitmap.Config? p2)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(p0);
			ptr[1] = new JniArgumentValue(p1);
			ptr[2] = new JniArgumentValue(p2?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Bitmap>(_members_com_bumptech_glide_load_engine_bitmap_recycle_BitmapPool.InstanceMethods.InvokeAbstractObjectMethod("get.(IILandroid/graphics/Bitmap$Config;)Landroid/graphics/Bitmap;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(p2);
		}
	}

	private static Delegate GetGetDirty_IILandroid_graphics_Bitmap_Config_Handler()
	{
		return new global::_JniMarshal_PPIIL_L(n_GetDirty_IILandroid_graphics_Bitmap_Config_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetDirty_IILandroid_graphics_Bitmap_Config_(nint jnienv, nint native__this, int p0, int p1, nint native_p2)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IBitmapPool? bitmapPool = Java.Lang.Object.GetObject<IBitmapPool>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Bitmap.Config p2 = Java.Lang.Object.GetObject<Bitmap.Config>(native_p2, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(bitmapPool.GetDirty(p0, p1, p2));
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

	public unsafe Bitmap GetDirty(int p0, int p1, Bitmap.Config? p2)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(p0);
			ptr[1] = new JniArgumentValue(p1);
			ptr[2] = new JniArgumentValue(p2?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Bitmap>(_members_com_bumptech_glide_load_engine_bitmap_recycle_BitmapPool.InstanceMethods.InvokeAbstractObjectMethod("getDirty.(IILandroid/graphics/Bitmap$Config;)Landroid/graphics/Bitmap;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(p2);
		}
	}

	private static Delegate GetPut_Landroid_graphics_Bitmap_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_Put_Landroid_graphics_Bitmap_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Put_Landroid_graphics_Bitmap_(nint jnienv, nint native__this, nint native_p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IBitmapPool? bitmapPool = Java.Lang.Object.GetObject<IBitmapPool>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Bitmap p = Java.Lang.Object.GetObject<Bitmap>(native_p0, JniHandleOwnership.DoNotTransfer);
			bitmapPool.Put(p);
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

	public unsafe void Put(Bitmap? p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			_members_com_bumptech_glide_load_engine_bitmap_recycle_BitmapPool.InstanceMethods.InvokeAbstractVoidMethod("put.(Landroid/graphics/Bitmap;)V", this, ptr);
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
			Java.Lang.Object.GetObject<IBitmapPool>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetSizeMultiplier(p0);
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
		_members_com_bumptech_glide_load_engine_bitmap_recycle_BitmapPool.InstanceMethods.InvokeAbstractVoidMethod("setSizeMultiplier.(F)V", this, ptr);
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
			Java.Lang.Object.GetObject<IBitmapPool>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TrimMemory(p0);
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
		_members_com_bumptech_glide_load_engine_bitmap_recycle_BitmapPool.InstanceMethods.InvokeAbstractVoidMethod("trimMemory.(I)V", this, ptr);
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
