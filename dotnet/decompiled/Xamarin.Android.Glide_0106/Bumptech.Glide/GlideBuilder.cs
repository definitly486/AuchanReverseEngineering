using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Content;
using Android.Runtime;
using Bumptech.Glide.Load.Engine.BitmapRecycle;
using Bumptech.Glide.Load.Engine.Cache;
using Bumptech.Glide.Load.Engine.Executor;
using Bumptech.Glide.Manager;
using Bumptech.Glide.Request;
using Java.Interop;
using Java.Lang;

namespace Bumptech.Glide;

[Register("com/bumptech/glide/GlideBuilder", DoNotGenerateAcw = true)]
public sealed class GlideBuilder : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/bumptech/glide/GlideBuilder", typeof(GlideBuilder));

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

	internal GlideBuilder(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe GlideBuilder()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	[Register("addGlobalRequestListener", "(Lcom/bumptech/glide/request/RequestListener;)Lcom/bumptech/glide/GlideBuilder;", "")]
	public unsafe GlideBuilder AddGlobalRequestListener(IRequestListener listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			return Java.Lang.Object.GetObject<GlideBuilder>(_members.InstanceMethods.InvokeAbstractObjectMethod("addGlobalRequestListener.(Lcom/bumptech/glide/request/RequestListener;)Lcom/bumptech/glide/GlideBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	[Register("setAnimationExecutor", "(Lcom/bumptech/glide/load/engine/executor/GlideExecutor;)Lcom/bumptech/glide/GlideBuilder;", "")]
	public unsafe GlideBuilder SetAnimationExecutor(GlideExecutor? service)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(service?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<GlideBuilder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setAnimationExecutor.(Lcom/bumptech/glide/load/engine/executor/GlideExecutor;)Lcom/bumptech/glide/GlideBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(service);
		}
	}

	[Register("setArrayPool", "(Lcom/bumptech/glide/load/engine/bitmap_recycle/ArrayPool;)Lcom/bumptech/glide/GlideBuilder;", "")]
	public unsafe GlideBuilder SetArrayPool(IArrayPool? arrayPool)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((arrayPool == null) ? IntPtr.Zero : ((Java.Lang.Object)arrayPool).Handle);
			return Java.Lang.Object.GetObject<GlideBuilder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setArrayPool.(Lcom/bumptech/glide/load/engine/bitmap_recycle/ArrayPool;)Lcom/bumptech/glide/GlideBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(arrayPool);
		}
	}

	[Register("setBitmapPool", "(Lcom/bumptech/glide/load/engine/bitmap_recycle/BitmapPool;)Lcom/bumptech/glide/GlideBuilder;", "")]
	public unsafe GlideBuilder SetBitmapPool(IBitmapPool? bitmapPool)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((bitmapPool == null) ? IntPtr.Zero : ((Java.Lang.Object)bitmapPool).Handle);
			return Java.Lang.Object.GetObject<GlideBuilder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setBitmapPool.(Lcom/bumptech/glide/load/engine/bitmap_recycle/BitmapPool;)Lcom/bumptech/glide/GlideBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(bitmapPool);
		}
	}

	[Register("setConnectivityMonitorFactory", "(Lcom/bumptech/glide/manager/ConnectivityMonitorFactory;)Lcom/bumptech/glide/GlideBuilder;", "")]
	public unsafe GlideBuilder SetConnectivityMonitorFactory(IConnectivityMonitorFactory? factory)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((factory == null) ? IntPtr.Zero : ((Java.Lang.Object)factory).Handle);
			return Java.Lang.Object.GetObject<GlideBuilder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setConnectivityMonitorFactory.(Lcom/bumptech/glide/manager/ConnectivityMonitorFactory;)Lcom/bumptech/glide/GlideBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(factory);
		}
	}

	[Register("setDefaultRequestOptions", "(Lcom/bumptech/glide/Glide$RequestOptionsFactory;)Lcom/bumptech/glide/GlideBuilder;", "")]
	public unsafe GlideBuilder SetDefaultRequestOptions(Glide.IRequestOptionsFactory factory)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((factory == null) ? IntPtr.Zero : ((Java.Lang.Object)factory).Handle);
			return Java.Lang.Object.GetObject<GlideBuilder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setDefaultRequestOptions.(Lcom/bumptech/glide/Glide$RequestOptionsFactory;)Lcom/bumptech/glide/GlideBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(factory);
		}
	}

	[Register("setDefaultRequestOptions", "(Lcom/bumptech/glide/request/RequestOptions;)Lcom/bumptech/glide/GlideBuilder;", "")]
	public unsafe GlideBuilder SetDefaultRequestOptions(RequestOptions? requestOptions)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(requestOptions?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<GlideBuilder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setDefaultRequestOptions.(Lcom/bumptech/glide/request/RequestOptions;)Lcom/bumptech/glide/GlideBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(requestOptions);
		}
	}

	[Register("setDefaultTransitionOptions", "(Ljava/lang/Class;Lcom/bumptech/glide/TransitionOptions;)Lcom/bumptech/glide/GlideBuilder;", "")]
	[JavaTypeParameters(new string[] { "T" })]
	public unsafe GlideBuilder SetDefaultTransitionOptions(Class clazz, TransitionOptions? options)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(clazz?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(options?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<GlideBuilder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setDefaultTransitionOptions.(Ljava/lang/Class;Lcom/bumptech/glide/TransitionOptions;)Lcom/bumptech/glide/GlideBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(clazz);
			GC.KeepAlive(options);
		}
	}

	[Obsolete("deprecated")]
	[Register("setDisableHardwareBitmapsOnO", "(Z)Lcom/bumptech/glide/GlideBuilder;", "")]
	public unsafe GlideBuilder? SetDisableHardwareBitmapsOnO(bool disableHardwareBitmapsOnO)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(disableHardwareBitmapsOnO ? ((sbyte)1) : ((sbyte)0));
		return Java.Lang.Object.GetObject<GlideBuilder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setDisableHardwareBitmapsOnO.(Z)Lcom/bumptech/glide/GlideBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("setDiskCache", "(Lcom/bumptech/glide/load/engine/cache/DiskCache$Factory;)Lcom/bumptech/glide/GlideBuilder;", "")]
	public unsafe GlideBuilder SetDiskCache(IDiskCacheFactory? diskCacheFactory)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((diskCacheFactory == null) ? IntPtr.Zero : ((Java.Lang.Object)diskCacheFactory).Handle);
			return Java.Lang.Object.GetObject<GlideBuilder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setDiskCache.(Lcom/bumptech/glide/load/engine/cache/DiskCache$Factory;)Lcom/bumptech/glide/GlideBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(diskCacheFactory);
		}
	}

	[Register("setDiskCacheExecutor", "(Lcom/bumptech/glide/load/engine/executor/GlideExecutor;)Lcom/bumptech/glide/GlideBuilder;", "")]
	public unsafe GlideBuilder SetDiskCacheExecutor(GlideExecutor? service)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(service?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<GlideBuilder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setDiskCacheExecutor.(Lcom/bumptech/glide/load/engine/executor/GlideExecutor;)Lcom/bumptech/glide/GlideBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(service);
		}
	}

	[Register("setImageDecoderEnabledForBitmaps", "(Z)Lcom/bumptech/glide/GlideBuilder;", "")]
	public unsafe GlideBuilder? SetImageDecoderEnabledForBitmaps(bool isEnabled)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(isEnabled ? ((sbyte)1) : ((sbyte)0));
		return Java.Lang.Object.GetObject<GlideBuilder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setImageDecoderEnabledForBitmaps.(Z)Lcom/bumptech/glide/GlideBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("setIsActiveResourceRetentionAllowed", "(Z)Lcom/bumptech/glide/GlideBuilder;", "")]
	public unsafe GlideBuilder SetIsActiveResourceRetentionAllowed(bool isActiveResourceRetentionAllowed)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(isActiveResourceRetentionAllowed ? ((sbyte)1) : ((sbyte)0));
		return Java.Lang.Object.GetObject<GlideBuilder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setIsActiveResourceRetentionAllowed.(Z)Lcom/bumptech/glide/GlideBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("setLogLevel", "(I)Lcom/bumptech/glide/GlideBuilder;", "")]
	public unsafe GlideBuilder SetLogLevel(int logLevel)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(logLevel);
		return Java.Lang.Object.GetObject<GlideBuilder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setLogLevel.(I)Lcom/bumptech/glide/GlideBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("setLogRequestOrigins", "(Z)Lcom/bumptech/glide/GlideBuilder;", "")]
	public unsafe GlideBuilder? SetLogRequestOrigins(bool isEnabled)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(isEnabled ? ((sbyte)1) : ((sbyte)0));
		return Java.Lang.Object.GetObject<GlideBuilder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setLogRequestOrigins.(Z)Lcom/bumptech/glide/GlideBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("setMemoryCache", "(Lcom/bumptech/glide/load/engine/cache/MemoryCache;)Lcom/bumptech/glide/GlideBuilder;", "")]
	public unsafe GlideBuilder SetMemoryCache(IMemoryCache? memoryCache)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((memoryCache == null) ? IntPtr.Zero : ((Java.Lang.Object)memoryCache).Handle);
			return Java.Lang.Object.GetObject<GlideBuilder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setMemoryCache.(Lcom/bumptech/glide/load/engine/cache/MemoryCache;)Lcom/bumptech/glide/GlideBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(memoryCache);
		}
	}

	[Register("setMemorySizeCalculator", "(Lcom/bumptech/glide/load/engine/cache/MemorySizeCalculator;)Lcom/bumptech/glide/GlideBuilder;", "")]
	public unsafe GlideBuilder SetMemorySizeCalculator(MemorySizeCalculator? calculator)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(calculator?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<GlideBuilder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setMemorySizeCalculator.(Lcom/bumptech/glide/load/engine/cache/MemorySizeCalculator;)Lcom/bumptech/glide/GlideBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(calculator);
		}
	}

	[Register("setMemorySizeCalculator", "(Lcom/bumptech/glide/load/engine/cache/MemorySizeCalculator$Builder;)Lcom/bumptech/glide/GlideBuilder;", "")]
	public unsafe GlideBuilder SetMemorySizeCalculator(MemorySizeCalculator.Builder builder)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(builder?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<GlideBuilder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setMemorySizeCalculator.(Lcom/bumptech/glide/load/engine/cache/MemorySizeCalculator$Builder;)Lcom/bumptech/glide/GlideBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(builder);
		}
	}

	[Obsolete("deprecated")]
	[Register("setResizeExecutor", "(Lcom/bumptech/glide/load/engine/executor/GlideExecutor;)Lcom/bumptech/glide/GlideBuilder;", "")]
	public unsafe GlideBuilder? SetResizeExecutor(GlideExecutor? service)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(service?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<GlideBuilder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setResizeExecutor.(Lcom/bumptech/glide/load/engine/executor/GlideExecutor;)Lcom/bumptech/glide/GlideBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(service);
		}
	}

	[Register("setSourceExecutor", "(Lcom/bumptech/glide/load/engine/executor/GlideExecutor;)Lcom/bumptech/glide/GlideBuilder;", "")]
	public unsafe GlideBuilder SetSourceExecutor(GlideExecutor? service)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(service?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<GlideBuilder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setSourceExecutor.(Lcom/bumptech/glide/load/engine/executor/GlideExecutor;)Lcom/bumptech/glide/GlideBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(service);
		}
	}

	[Register("build", "(Landroid/content/Context;)Lcom/bumptech/glide/Glide;", "")]
	public unsafe Glide Build(Context context)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Glide>(_members.InstanceMethods.InvokeAbstractObjectMethod("build.(Landroid/content/Context;)Lcom/bumptech/glide/Glide;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(context);
		}
	}
}
