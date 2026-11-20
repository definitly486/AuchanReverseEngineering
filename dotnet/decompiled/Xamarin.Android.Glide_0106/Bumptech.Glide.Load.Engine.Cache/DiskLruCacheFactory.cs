using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.IO;
using Java.Interop;
using Java.Lang;

namespace Bumptech.Glide.Load.Engine.Cache;

[Register("com/bumptech/glide/load/engine/cache/DiskLruCacheFactory", DoNotGenerateAcw = true)]
public class DiskLruCacheFactory : Java.Lang.Object, IDiskCacheFactory, IJavaObject, IDisposable, IJavaPeerable
{
	[Register("com/bumptech/glide/load/engine/cache/DiskLruCacheFactory$CacheDirectoryGetter", "", "Bumptech.Glide.Load.Engine.Cache.DiskLruCacheFactory/ICacheDirectoryGetterInvoker")]
	public interface ICacheDirectoryGetter : IJavaObject, IDisposable, IJavaPeerable
	{
		File? CacheDirectory
		{
			[Register("getCacheDirectory", "()Ljava/io/File;", "GetGetCacheDirectoryHandler:Bumptech.Glide.Load.Engine.Cache.DiskLruCacheFactory/ICacheDirectoryGetterInvoker, Xamarin.Android.Glide")]
			get;
		}
	}

	[Register("com/bumptech/glide/load/engine/cache/DiskLruCacheFactory$CacheDirectoryGetter", DoNotGenerateAcw = true)]
	internal class ICacheDirectoryGetterInvoker : Java.Lang.Object, ICacheDirectoryGetter, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_com_bumptech_glide_load_engine_cache_DiskLruCacheFactory_CacheDirectoryGetter = new XAPeerMembers("com/bumptech/glide/load/engine/cache/DiskLruCacheFactory$CacheDirectoryGetter", typeof(ICacheDirectoryGetterInvoker));

		private static Delegate? cb_getCacheDirectory_GetCacheDirectory_Ljava_io_File_;

		private static nint java_class_ref => _members_com_bumptech_glide_load_engine_cache_DiskLruCacheFactory_CacheDirectoryGetter.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_com_bumptech_glide_load_engine_cache_DiskLruCacheFactory_CacheDirectoryGetter;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_com_bumptech_glide_load_engine_cache_DiskLruCacheFactory_CacheDirectoryGetter.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_com_bumptech_glide_load_engine_cache_DiskLruCacheFactory_CacheDirectoryGetter.ManagedPeerType;

		public unsafe File? CacheDirectory => Java.Lang.Object.GetObject<File>(_members_com_bumptech_glide_load_engine_cache_DiskLruCacheFactory_CacheDirectoryGetter.InstanceMethods.InvokeAbstractObjectMethod("getCacheDirectory.()Ljava/io/File;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

		public ICacheDirectoryGetterInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		private static Delegate GetGetCacheDirectoryHandler()
		{
			return new global::_JniMarshal_PP_L(n_GetCacheDirectory);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_GetCacheDirectory(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ICacheDirectoryGetter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CacheDirectory);
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
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("com/bumptech/glide/load/engine/cache/DiskLruCacheFactory", typeof(DiskLruCacheFactory));

	private static Delegate? cb_build_Build_Lcom_bumptech_glide_load_engine_cache_DiskCache_;

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

	protected DiskLruCacheFactory(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Lcom/bumptech/glide/load/engine/cache/DiskLruCacheFactory$CacheDirectoryGetter;J)V", "")]
	public unsafe DiskLruCacheFactory(ICacheDirectoryGetter? cacheDirectoryGetter, long diskCacheSize)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue((cacheDirectoryGetter == null) ? IntPtr.Zero : ((Java.Lang.Object)cacheDirectoryGetter).Handle);
			ptr[1] = new JniArgumentValue(diskCacheSize);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/bumptech/glide/load/engine/cache/DiskLruCacheFactory$CacheDirectoryGetter;J)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Lcom/bumptech/glide/load/engine/cache/DiskLruCacheFactory$CacheDirectoryGetter;J)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(cacheDirectoryGetter);
		}
	}

	[Register(".ctor", "(Ljava/lang/String;Ljava/lang/String;J)V", "")]
	public unsafe DiskLruCacheFactory(string? diskCacheFolder, string? diskCacheName, long diskCacheSize)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		nint num = JNIEnv.NewString(diskCacheFolder);
		nint num2 = JNIEnv.NewString(diskCacheName);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(num2);
			ptr[2] = new JniArgumentValue(diskCacheSize);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;Ljava/lang/String;J)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;Ljava/lang/String;J)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			JNIEnv.DeleteLocalRef(num2);
		}
	}

	[Register(".ctor", "(Ljava/lang/String;J)V", "")]
	public unsafe DiskLruCacheFactory(string? diskCacheFolder, long diskCacheSize)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		nint num = JNIEnv.NewString(diskCacheFolder);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(diskCacheSize);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;J)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;J)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<DiskLruCacheFactory>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Build());
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

	[Register("build", "()Lcom/bumptech/glide/load/engine/cache/DiskCache;", "GetBuildHandler")]
	public unsafe virtual IDiskCache? Build()
	{
		return Java.Lang.Object.GetObject<IDiskCache>(_members.InstanceMethods.InvokeVirtualObjectMethod("build.()Lcom/bumptech/glide/load/engine/cache/DiskCache;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
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
