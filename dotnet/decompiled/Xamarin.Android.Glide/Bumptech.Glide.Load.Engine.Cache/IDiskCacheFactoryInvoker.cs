using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Bumptech.Glide.Load.Engine.Cache;

[Register("com/bumptech/glide/load/engine/cache/DiskCache$Factory", DoNotGenerateAcw = true)]
internal class IDiskCacheFactoryInvoker : Java.Lang.Object, IDiskCacheFactory, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_com_bumptech_glide_load_engine_cache_DiskCache_Factory = new XAPeerMembers("com/bumptech/glide/load/engine/cache/DiskCache$Factory", typeof(IDiskCacheFactoryInvoker));

	private static Delegate? cb_build_Build_Lcom_bumptech_glide_load_engine_cache_DiskCache_;

	private static nint java_class_ref => _members_com_bumptech_glide_load_engine_cache_DiskCache_Factory.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_com_bumptech_glide_load_engine_cache_DiskCache_Factory;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_com_bumptech_glide_load_engine_cache_DiskCache_Factory.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_com_bumptech_glide_load_engine_cache_DiskCache_Factory.ManagedPeerType;

	public IDiskCacheFactoryInvoker(nint handle, JniHandleOwnership transfer)
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IDiskCacheFactory>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Build());
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

	public unsafe IDiskCache? Build()
	{
		return Java.Lang.Object.GetObject<IDiskCache>(_members_com_bumptech_glide_load_engine_cache_DiskCache_Factory.InstanceMethods.InvokeAbstractObjectMethod("build.()Lcom/bumptech/glide/load/engine/cache/DiskCache;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
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
