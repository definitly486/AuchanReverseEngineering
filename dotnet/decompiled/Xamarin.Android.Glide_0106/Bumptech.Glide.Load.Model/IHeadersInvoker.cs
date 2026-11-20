using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Bumptech.Glide.Load.Model;

[Register("com/bumptech/glide/load/model/Headers", DoNotGenerateAcw = true)]
internal class IHeadersInvoker : Java.Lang.Object, IHeaders, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_com_bumptech_glide_load_model_Headers = new XAPeerMembers("com/bumptech/glide/load/model/Headers", typeof(IHeadersInvoker));

	private static Delegate? cb_getHeaders_GetHeaders_Ljava_util_Map_;

	private static nint java_class_ref => _members_com_bumptech_glide_load_model_Headers.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_com_bumptech_glide_load_model_Headers;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_com_bumptech_glide_load_model_Headers.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_com_bumptech_glide_load_model_Headers.ManagedPeerType;

	public unsafe IDictionary<string, string>? Headers => JavaDictionary<string, string>.FromJniHandle(_members_com_bumptech_glide_load_model_Headers.InstanceMethods.InvokeAbstractObjectMethod("getHeaders.()Ljava/util/Map;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public IHeadersInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetGetHeadersHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetHeaders);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetHeaders(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JavaDictionary<string, string>.ToLocalJniHandle(Java.Lang.Object.GetObject<IHeaders>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Headers);
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
