using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Bumptech.Glide.Load.Engine;
using Java.Interop;
using Java.Lang;

namespace Bumptech.Glide.Load.Resource.Transcode;

[Register("com/bumptech/glide/load/resource/transcode/ResourceTranscoder", DoNotGenerateAcw = true)]
internal class IResourceTranscoderInvoker : Java.Lang.Object, IResourceTranscoder, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_com_bumptech_glide_load_resource_transcode_ResourceTranscoder = new XAPeerMembers("com/bumptech/glide/load/resource/transcode/ResourceTranscoder", typeof(IResourceTranscoderInvoker));

	private static Delegate? cb_transcode_Transcode_Lcom_bumptech_glide_load_engine_Resource_Lcom_bumptech_glide_load_Options__Lcom_bumptech_glide_load_engine_Resource_;

	private static nint java_class_ref => _members_com_bumptech_glide_load_resource_transcode_ResourceTranscoder.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_com_bumptech_glide_load_resource_transcode_ResourceTranscoder;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_com_bumptech_glide_load_resource_transcode_ResourceTranscoder.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_com_bumptech_glide_load_resource_transcode_ResourceTranscoder.ManagedPeerType;

	public IResourceTranscoderInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetTranscode_Lcom_bumptech_glide_load_engine_Resource_Lcom_bumptech_glide_load_Options_Handler()
	{
		return new global::_JniMarshal_PPLL_L(n_Transcode_Lcom_bumptech_glide_load_engine_Resource_Lcom_bumptech_glide_load_Options_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Transcode_Lcom_bumptech_glide_load_engine_Resource_Lcom_bumptech_glide_load_Options_(nint jnienv, nint native__this, nint native_p0, nint native_p1)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IResourceTranscoder? resourceTranscoder = Java.Lang.Object.GetObject<IResourceTranscoder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IResource p = Java.Lang.Object.GetObject<IResource>(native_p0, JniHandleOwnership.DoNotTransfer);
			Options p2 = Java.Lang.Object.GetObject<Options>(native_p1, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(resourceTranscoder.Transcode(p, p2));
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

	public unsafe IResource? Transcode(IResource p0, Options p1)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<IResource>(_members_com_bumptech_glide_load_resource_transcode_ResourceTranscoder.InstanceMethods.InvokeAbstractObjectMethod("transcode.(Lcom/bumptech/glide/load/engine/Resource;Lcom/bumptech/glide/load/Options;)Lcom/bumptech/glide/load/engine/Resource;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
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
