using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.Runtime;
using Android.Views;
using AndroidX.Fragment.App;
using Bumptech.Glide.Load.Engine.BitmapRecycle;
using Bumptech.Glide.Load.Engine.Prefill;
using Bumptech.Glide.Manager;
using Bumptech.Glide.Request;
using Java.IO;
using Java.Interop;
using Java.Lang;

namespace Bumptech.Glide;

[Register("com/bumptech/glide/Glide", DoNotGenerateAcw = true)]
public class Glide : Java.Lang.Object, IJavaObject, IDisposable, IJavaPeerable
{
	[Register("com/bumptech/glide/Glide$RequestOptionsFactory", "", "Bumptech.Glide.Glide/IRequestOptionsFactoryInvoker")]
	public interface IRequestOptionsFactory : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("build", "()Lcom/bumptech/glide/request/RequestOptions;", "GetBuildHandler:Bumptech.Glide.Glide/IRequestOptionsFactoryInvoker, Xamarin.Android.Glide")]
		RequestOptions Build();
	}

	[Register("com/bumptech/glide/Glide$RequestOptionsFactory", DoNotGenerateAcw = true)]
	internal class IRequestOptionsFactoryInvoker : Java.Lang.Object, IRequestOptionsFactory, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_com_bumptech_glide_Glide_RequestOptionsFactory = new XAPeerMembers("com/bumptech/glide/Glide$RequestOptionsFactory", typeof(IRequestOptionsFactoryInvoker));

		private static Delegate? cb_build_Build_Lcom_bumptech_glide_request_RequestOptions_;

		private static nint java_class_ref => _members_com_bumptech_glide_Glide_RequestOptionsFactory.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_com_bumptech_glide_Glide_RequestOptionsFactory;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_com_bumptech_glide_Glide_RequestOptionsFactory.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_com_bumptech_glide_Glide_RequestOptionsFactory.ManagedPeerType;

		public IRequestOptionsFactoryInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		private static Delegate GetBuildHandler()
		{
			return new global::_JniMarshal_PP_L(n_Build);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_Build(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IRequestOptionsFactory>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Build());
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

		public unsafe RequestOptions Build()
		{
			return Java.Lang.Object.GetObject<RequestOptions>(_members_com_bumptech_glide_Glide_RequestOptionsFactory.InstanceMethods.InvokeAbstractObjectMethod("build.()Lcom/bumptech/glide/request/RequestOptions;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
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

	private static readonly JniPeerMembers _members = new XAPeerMembers("com/bumptech/glide/Glide", typeof(Glide));

	private static Delegate? cb_getArrayPool_GetArrayPool_Lcom_bumptech_glide_load_engine_bitmap_recycle_ArrayPool_;

	private static Delegate? cb_getBitmapPool_GetBitmapPool_Lcom_bumptech_glide_load_engine_bitmap_recycle_BitmapPool_;

	private static Delegate? cb_getContext_GetContext_Landroid_content_Context_;

	private static Delegate? cb_getRegistry_GetRegistry_Lcom_bumptech_glide_Registry_;

	private static Delegate? cb_getRequestManagerRetriever_GetRequestManagerRetriever_Lcom_bumptech_glide_manager_RequestManagerRetriever_;

	private static Delegate? cb_clearDiskCache_ClearDiskCache_V;

	private static Delegate? cb_clearMemory_ClearMemory_V;

	private static Delegate? cb_onConfigurationChanged_OnConfigurationChanged_Landroid_content_res_Configuration__V;

	private static Delegate? cb_onLowMemory_OnLowMemory_V;

	private static Delegate? cb_onTrimMemory_OnTrimMemory_I_V;

	private static Delegate? cb_preFillBitmapPool_PreFillBitmapPool_arrayLcom_bumptech_glide_load_engine_prefill_PreFillType_Builder__V;

	private static Delegate? cb_setMemoryCategory_SetMemoryCategory_Lcom_bumptech_glide_MemoryCategory__Lcom_bumptech_glide_MemoryCategory_;

	private static Delegate? cb_trimMemory_TrimMemory_I_V;

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

	public unsafe virtual IArrayPool ArrayPool
	{
		[Register("getArrayPool", "()Lcom/bumptech/glide/load/engine/bitmap_recycle/ArrayPool;", "GetGetArrayPoolHandler")]
		get
		{
			return Java.Lang.Object.GetObject<IArrayPool>(_members.InstanceMethods.InvokeVirtualObjectMethod("getArrayPool.()Lcom/bumptech/glide/load/engine/bitmap_recycle/ArrayPool;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual IBitmapPool BitmapPool
	{
		[Register("getBitmapPool", "()Lcom/bumptech/glide/load/engine/bitmap_recycle/BitmapPool;", "GetGetBitmapPoolHandler")]
		get
		{
			return Java.Lang.Object.GetObject<IBitmapPool>(_members.InstanceMethods.InvokeVirtualObjectMethod("getBitmapPool.()Lcom/bumptech/glide/load/engine/bitmap_recycle/BitmapPool;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual Context Context
	{
		[Register("getContext", "()Landroid/content/Context;", "GetGetContextHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Context>(_members.InstanceMethods.InvokeVirtualObjectMethod("getContext.()Landroid/content/Context;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe static bool IsInitialized
	{
		[Register("isInitialized", "()Z", "")]
		get
		{
			return _members.StaticMethods.InvokeBooleanMethod("isInitialized.()Z", null);
		}
	}

	public unsafe virtual Registry Registry
	{
		[Register("getRegistry", "()Lcom/bumptech/glide/Registry;", "GetGetRegistryHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Registry>(_members.InstanceMethods.InvokeVirtualObjectMethod("getRegistry.()Lcom/bumptech/glide/Registry;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual RequestManagerRetriever RequestManagerRetriever
	{
		[Register("getRequestManagerRetriever", "()Lcom/bumptech/glide/manager/RequestManagerRetriever;", "GetGetRequestManagerRetrieverHandler")]
		get
		{
			return Java.Lang.Object.GetObject<RequestManagerRetriever>(_members.InstanceMethods.InvokeVirtualObjectMethod("getRequestManagerRetriever.()Lcom/bumptech/glide/manager/RequestManagerRetriever;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	protected Glide(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	private static Delegate GetGetArrayPoolHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetArrayPool);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetArrayPool(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Glide>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ArrayPool);
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

	private static Delegate GetGetBitmapPoolHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetBitmapPool);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetBitmapPool(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Glide>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).BitmapPool);
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

	private static Delegate GetGetContextHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetContext);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetContext(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Glide>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Context);
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

	private static Delegate GetGetRegistryHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetRegistry);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetRegistry(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Glide>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Registry);
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

	private static Delegate GetGetRequestManagerRetrieverHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetRequestManagerRetriever);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetRequestManagerRetriever(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Glide>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RequestManagerRetriever);
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

	private static Delegate GetClearDiskCacheHandler()
	{
		return new global::_JniMarshal_PP_V(n_ClearDiskCache);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_ClearDiskCache(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Glide>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ClearDiskCache();
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

	[Register("clearDiskCache", "()V", "GetClearDiskCacheHandler")]
	public unsafe virtual void ClearDiskCache()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("clearDiskCache.()V", this, null);
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
			Java.Lang.Object.GetObject<Glide>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ClearMemory();
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

	[Register("clearMemory", "()V", "GetClearMemoryHandler")]
	public unsafe virtual void ClearMemory()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("clearMemory.()V", this, null);
	}

	[Register("enableHardwareBitmaps", "()V", "")]
	public unsafe static void EnableHardwareBitmaps()
	{
		_members.StaticMethods.InvokeVoidMethod("enableHardwareBitmaps.()V", null);
	}

	[Register("get", "(Landroid/content/Context;)Lcom/bumptech/glide/Glide;", "")]
	public unsafe static Glide Get(Context context)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Glide>(_members.StaticMethods.InvokeObjectMethod("get.(Landroid/content/Context;)Lcom/bumptech/glide/Glide;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(context);
		}
	}

	[Register("getPhotoCacheDir", "(Landroid/content/Context;)Ljava/io/File;", "")]
	public unsafe static File? GetPhotoCacheDir(Context context)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<File>(_members.StaticMethods.InvokeObjectMethod("getPhotoCacheDir.(Landroid/content/Context;)Ljava/io/File;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(context);
		}
	}

	[Register("getPhotoCacheDir", "(Landroid/content/Context;Ljava/lang/String;)Ljava/io/File;", "")]
	public unsafe static File? GetPhotoCacheDir(Context context, string cacheName)
	{
		nint num = JNIEnv.NewString(cacheName);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<File>(_members.StaticMethods.InvokeObjectMethod("getPhotoCacheDir.(Landroid/content/Context;Ljava/lang/String;)Ljava/io/File;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(context);
		}
	}

	[Register("init", "(Landroid/content/Context;Lcom/bumptech/glide/GlideBuilder;)V", "")]
	public unsafe static void Init(Context context, GlideBuilder builder)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(builder?.Handle ?? IntPtr.Zero);
			_members.StaticMethods.InvokeVoidMethod("init.(Landroid/content/Context;Lcom/bumptech/glide/GlideBuilder;)V", ptr);
		}
		finally
		{
			GC.KeepAlive(context);
			GC.KeepAlive(builder);
		}
	}

	[Obsolete("deprecated")]
	[Register("init", "(Lcom/bumptech/glide/Glide;)V", "")]
	public unsafe static void Init(Glide? glide)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(glide?.Handle ?? IntPtr.Zero);
			_members.StaticMethods.InvokeVoidMethod("init.(Lcom/bumptech/glide/Glide;)V", ptr);
		}
		finally
		{
			GC.KeepAlive(glide);
		}
	}

	private static Delegate GetOnConfigurationChanged_Landroid_content_res_Configuration_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_OnConfigurationChanged_Landroid_content_res_Configuration_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnConfigurationChanged_Landroid_content_res_Configuration_(nint jnienv, nint native__this, nint native_newConfig)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Glide? glide = Java.Lang.Object.GetObject<Glide>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Configuration newConfig = Java.Lang.Object.GetObject<Configuration>(native_newConfig, JniHandleOwnership.DoNotTransfer);
			glide.OnConfigurationChanged(newConfig);
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

	[Register("onConfigurationChanged", "(Landroid/content/res/Configuration;)V", "GetOnConfigurationChanged_Landroid_content_res_Configuration_Handler")]
	public unsafe virtual void OnConfigurationChanged(Configuration? newConfig)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(newConfig?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onConfigurationChanged.(Landroid/content/res/Configuration;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(newConfig);
		}
	}

	private static Delegate GetOnLowMemoryHandler()
	{
		return new global::_JniMarshal_PP_V(n_OnLowMemory);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnLowMemory(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Glide>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnLowMemory();
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

	[Register("onLowMemory", "()V", "GetOnLowMemoryHandler")]
	public unsafe virtual void OnLowMemory()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("onLowMemory.()V", this, null);
	}

	private static Delegate GetOnTrimMemory_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_OnTrimMemory_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnTrimMemory_I(nint jnienv, nint native__this, int native_level)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Glide>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnTrimMemory((TrimMemory)native_level);
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

	[Register("onTrimMemory", "(I)V", "GetOnTrimMemory_IHandler")]
	public unsafe virtual void OnTrimMemory(TrimMemory level)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue((int)level);
		_members.InstanceMethods.InvokeVirtualVoidMethod("onTrimMemory.(I)V", this, ptr);
	}

	private static Delegate GetPreFillBitmapPool_arrayLcom_bumptech_glide_load_engine_prefill_PreFillType_Builder_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_PreFillBitmapPool_arrayLcom_bumptech_glide_load_engine_prefill_PreFillType_Builder_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_PreFillBitmapPool_arrayLcom_bumptech_glide_load_engine_prefill_PreFillType_Builder_(nint jnienv, nint native__this, nint native_bitmapAttributeBuilders)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Glide? glide = Java.Lang.Object.GetObject<Glide>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			PreFillType.Builder[] array = (PreFillType.Builder[])JNIEnv.GetArray(native_bitmapAttributeBuilders, JniHandleOwnership.DoNotTransfer, typeof(PreFillType.Builder));
			glide.PreFillBitmapPool(array);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_bitmapAttributeBuilders);
			}
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

	[Register("preFillBitmapPool", "([Lcom/bumptech/glide/load/engine/prefill/PreFillType$Builder;)V", "GetPreFillBitmapPool_arrayLcom_bumptech_glide_load_engine_prefill_PreFillType_Builder_Handler")]
	public unsafe virtual void PreFillBitmapPool(params PreFillType.Builder[] bitmapAttributeBuilders)
	{
		nint num = JNIEnv.NewArray(bitmapAttributeBuilders);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeVirtualVoidMethod("preFillBitmapPool.([Lcom/bumptech/glide/load/engine/prefill/PreFillType$Builder;)V", this, ptr);
		}
		finally
		{
			if (bitmapAttributeBuilders != null)
			{
				JNIEnv.CopyArray(num, bitmapAttributeBuilders);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(bitmapAttributeBuilders);
		}
	}

	private static Delegate GetSetMemoryCategory_Lcom_bumptech_glide_MemoryCategory_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_SetMemoryCategory_Lcom_bumptech_glide_MemoryCategory_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_SetMemoryCategory_Lcom_bumptech_glide_MemoryCategory_(nint jnienv, nint native__this, nint native_memoryCategory)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Glide? glide = Java.Lang.Object.GetObject<Glide>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			MemoryCategory memoryCategory = Java.Lang.Object.GetObject<MemoryCategory>(native_memoryCategory, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(glide.SetMemoryCategory(memoryCategory));
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

	[Register("setMemoryCategory", "(Lcom/bumptech/glide/MemoryCategory;)Lcom/bumptech/glide/MemoryCategory;", "GetSetMemoryCategory_Lcom_bumptech_glide_MemoryCategory_Handler")]
	public unsafe virtual MemoryCategory SetMemoryCategory(MemoryCategory memoryCategory)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(memoryCategory?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<MemoryCategory>(_members.InstanceMethods.InvokeVirtualObjectMethod("setMemoryCategory.(Lcom/bumptech/glide/MemoryCategory;)Lcom/bumptech/glide/MemoryCategory;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(memoryCategory);
		}
	}

	[Register("tearDown", "()V", "")]
	public unsafe static void TearDown()
	{
		_members.StaticMethods.InvokeVoidMethod("tearDown.()V", null);
	}

	private static Delegate GetTrimMemory_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_TrimMemory_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_TrimMemory_I(nint jnienv, nint native__this, int level)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Glide>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TrimMemory(level);
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

	[Register("trimMemory", "(I)V", "GetTrimMemory_IHandler")]
	public unsafe virtual void TrimMemory(int level)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(level);
		_members.InstanceMethods.InvokeVirtualVoidMethod("trimMemory.(I)V", this, ptr);
	}

	[Obsolete("deprecated")]
	[Register("with", "(Landroid/app/Activity;)Lcom/bumptech/glide/RequestManager;", "")]
	public unsafe static RequestManager With(Activity activity)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(activity?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<RequestManager>(_members.StaticMethods.InvokeObjectMethod("with.(Landroid/app/Activity;)Lcom/bumptech/glide/RequestManager;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(activity);
		}
	}

	[Obsolete("deprecated")]
	[Register("with", "(Landroid/app/Fragment;)Lcom/bumptech/glide/RequestManager;", "")]
	public unsafe static RequestManager With(Android.App.Fragment fragment)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(fragment?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<RequestManager>(_members.StaticMethods.InvokeObjectMethod("with.(Landroid/app/Fragment;)Lcom/bumptech/glide/RequestManager;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(fragment);
		}
	}

	[Register("with", "(Landroid/content/Context;)Lcom/bumptech/glide/RequestManager;", "")]
	public unsafe static RequestManager With(Context context)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<RequestManager>(_members.StaticMethods.InvokeObjectMethod("with.(Landroid/content/Context;)Lcom/bumptech/glide/RequestManager;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(context);
		}
	}

	[Register("with", "(Landroid/view/View;)Lcom/bumptech/glide/RequestManager;", "")]
	public unsafe static RequestManager With(View view)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<RequestManager>(_members.StaticMethods.InvokeObjectMethod("with.(Landroid/view/View;)Lcom/bumptech/glide/RequestManager;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	[Register("with", "(Landroidx/fragment/app/Fragment;)Lcom/bumptech/glide/RequestManager;", "")]
	public unsafe static RequestManager With(AndroidX.Fragment.App.Fragment fragment)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(fragment?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<RequestManager>(_members.StaticMethods.InvokeObjectMethod("with.(Landroidx/fragment/app/Fragment;)Lcom/bumptech/glide/RequestManager;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(fragment);
		}
	}

	[Register("with", "(Landroidx/fragment/app/FragmentActivity;)Lcom/bumptech/glide/RequestManager;", "")]
	public unsafe static RequestManager With(FragmentActivity activity)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(((Java.Lang.Object)(object)activity)?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<RequestManager>(_members.StaticMethods.InvokeObjectMethod("with.(Landroidx/fragment/app/FragmentActivity;)Lcom/bumptech/glide/RequestManager;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(activity);
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
