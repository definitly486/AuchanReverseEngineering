using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Bumptech.Glide.Load.Data;

[Register("com/bumptech/glide/load/data/DataRewinder", DoNotGenerateAcw = true)]
internal class IDataRewinderInvoker : Java.Lang.Object, IDataRewinder, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_com_bumptech_glide_load_data_DataRewinder = new XAPeerMembers("com/bumptech/glide/load/data/DataRewinder", typeof(IDataRewinderInvoker));

	private static Delegate? cb_cleanup_Cleanup_V;

	private static Delegate? cb_rewindAndGet_RewindAndGet_Ljava_lang_Object_;

	private static nint java_class_ref => _members_com_bumptech_glide_load_data_DataRewinder.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_com_bumptech_glide_load_data_DataRewinder;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_com_bumptech_glide_load_data_DataRewinder.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_com_bumptech_glide_load_data_DataRewinder.ManagedPeerType;

	public IDataRewinderInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetCleanupHandler()
	{
		return new global::_JniMarshal_PP_V(n_Cleanup);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Cleanup(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IDataRewinder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Cleanup();
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

	public unsafe void Cleanup()
	{
		_members_com_bumptech_glide_load_data_DataRewinder.InstanceMethods.InvokeAbstractVoidMethod("cleanup.()V", this, null);
	}

	private static Delegate GetRewindAndGetHandler()
	{
		return new global::_JniMarshal_PP_L(n_RewindAndGet);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_RewindAndGet(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IDataRewinder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RewindAndGet());
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

	public unsafe Java.Lang.Object RewindAndGet()
	{
		return Java.Lang.Object.GetObject<Java.Lang.Object>(_members_com_bumptech_glide_load_data_DataRewinder.InstanceMethods.InvokeAbstractObjectMethod("rewindAndGet.()Ljava/lang/Object;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
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
