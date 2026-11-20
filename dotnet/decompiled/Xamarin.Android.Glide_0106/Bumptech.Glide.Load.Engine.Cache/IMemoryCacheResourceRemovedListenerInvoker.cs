using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Bumptech.Glide.Load.Engine.Cache;

[Register("com/bumptech/glide/load/engine/cache/MemoryCache$ResourceRemovedListener", DoNotGenerateAcw = true)]
internal class IMemoryCacheResourceRemovedListenerInvoker : Java.Lang.Object, IMemoryCacheResourceRemovedListener, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_com_bumptech_glide_load_engine_cache_MemoryCache_ResourceRemovedListener = new XAPeerMembers("com/bumptech/glide/load/engine/cache/MemoryCache$ResourceRemovedListener", typeof(IMemoryCacheResourceRemovedListenerInvoker));

	private static Delegate? cb_onResourceRemoved_OnResourceRemoved_Lcom_bumptech_glide_load_engine_Resource__V;

	private static nint java_class_ref => _members_com_bumptech_glide_load_engine_cache_MemoryCache_ResourceRemovedListener.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_com_bumptech_glide_load_engine_cache_MemoryCache_ResourceRemovedListener;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_com_bumptech_glide_load_engine_cache_MemoryCache_ResourceRemovedListener.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_com_bumptech_glide_load_engine_cache_MemoryCache_ResourceRemovedListener.ManagedPeerType;

	public IMemoryCacheResourceRemovedListenerInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetOnResourceRemoved_Lcom_bumptech_glide_load_engine_Resource_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_OnResourceRemoved_Lcom_bumptech_glide_load_engine_Resource_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnResourceRemoved_Lcom_bumptech_glide_load_engine_Resource_(nint jnienv, nint native__this, nint native_p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IMemoryCacheResourceRemovedListener? memoryCacheResourceRemovedListener = Java.Lang.Object.GetObject<IMemoryCacheResourceRemovedListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IResource p = Java.Lang.Object.GetObject<IResource>(native_p0, JniHandleOwnership.DoNotTransfer);
			memoryCacheResourceRemovedListener.OnResourceRemoved(p);
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

	public unsafe void OnResourceRemoved(IResource p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			_members_com_bumptech_glide_load_engine_cache_MemoryCache_ResourceRemovedListener.InstanceMethods.InvokeAbstractVoidMethod("onResourceRemoved.(Lcom/bumptech/glide/load/engine/Resource;)V", this, ptr);
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
