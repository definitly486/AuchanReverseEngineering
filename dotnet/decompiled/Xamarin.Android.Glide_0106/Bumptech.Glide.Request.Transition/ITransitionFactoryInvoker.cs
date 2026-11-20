using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Bumptech.Glide.Load;
using Java.Interop;
using Java.Lang;

namespace Bumptech.Glide.Request.Transition;

[Register("com/bumptech/glide/request/transition/TransitionFactory", DoNotGenerateAcw = true)]
internal class ITransitionFactoryInvoker : Java.Lang.Object, ITransitionFactory, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_com_bumptech_glide_request_transition_TransitionFactory = new XAPeerMembers("com/bumptech/glide/request/transition/TransitionFactory", typeof(ITransitionFactoryInvoker));

	private static Delegate? cb_build_Build_Lcom_bumptech_glide_load_DataSource_Z_Lcom_bumptech_glide_request_transition_Transition_;

	private static nint java_class_ref => _members_com_bumptech_glide_request_transition_TransitionFactory.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_com_bumptech_glide_request_transition_TransitionFactory;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_com_bumptech_glide_request_transition_TransitionFactory.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_com_bumptech_glide_request_transition_TransitionFactory.ManagedPeerType;

	public ITransitionFactoryInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetBuild_Lcom_bumptech_glide_load_DataSource_ZHandler()
	{
		return new global::_JniMarshal_PPLB_L(n_Build_Lcom_bumptech_glide_load_DataSource_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Build_Lcom_bumptech_glide_load_DataSource_Z(nint jnienv, nint native__this, nint native_p0, sbyte native_p1)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			ITransitionFactory? transitionFactory = Java.Lang.Object.GetObject<ITransitionFactory>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			DataSource p = Java.Lang.Object.GetObject<DataSource>(native_p0, JniHandleOwnership.DoNotTransfer);
			bool p2 = native_p1 != 0;
			return JNIEnv.ToLocalJniHandle(transitionFactory.Build(p, p2));
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

	public unsafe ITransition? Build(DataSource? p0, bool p1)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(p1 ? ((sbyte)1) : ((sbyte)0));
			return Java.Lang.Object.GetObject<ITransition>(_members_com_bumptech_glide_request_transition_TransitionFactory.InstanceMethods.InvokeAbstractObjectMethod("build.(Lcom/bumptech/glide/load/DataSource;Z)Lcom/bumptech/glide/request/transition/Transition;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
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
