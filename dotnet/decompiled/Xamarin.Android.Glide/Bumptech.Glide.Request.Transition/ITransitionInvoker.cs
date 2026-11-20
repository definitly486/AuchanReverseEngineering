using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Bumptech.Glide.Request.Transition;

[Register("com/bumptech/glide/request/transition/Transition", DoNotGenerateAcw = true)]
internal class ITransitionInvoker : Java.Lang.Object, ITransition, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_com_bumptech_glide_request_transition_Transition = new XAPeerMembers("com/bumptech/glide/request/transition/Transition", typeof(ITransitionInvoker));

	private static Delegate? cb_transition_Transition_Ljava_lang_Object_Lcom_bumptech_glide_request_transition_Transition_ViewAdapter__Z;

	private static nint java_class_ref => _members_com_bumptech_glide_request_transition_Transition.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_com_bumptech_glide_request_transition_Transition;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_com_bumptech_glide_request_transition_Transition.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_com_bumptech_glide_request_transition_Transition.ManagedPeerType;

	public ITransitionInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetTransition_Ljava_lang_Object_Lcom_bumptech_glide_request_transition_Transition_ViewAdapter_Handler()
	{
		return new global::_JniMarshal_PPLL_B(n_Transition_Ljava_lang_Object_Lcom_bumptech_glide_request_transition_Transition_ViewAdapter_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_Transition_Ljava_lang_Object_Lcom_bumptech_glide_request_transition_Transition_ViewAdapter_(nint jnienv, nint native__this, nint native_p0, nint native_p1)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			ITransition? transition2 = Java.Lang.Object.GetObject<ITransition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object p = Java.Lang.Object.GetObject<Java.Lang.Object>(native_p0, JniHandleOwnership.DoNotTransfer);
			ITransitionViewAdapter p2 = Java.Lang.Object.GetObject<ITransitionViewAdapter>(native_p1, JniHandleOwnership.DoNotTransfer);
			return transition2.Transition(p, p2) ? ((sbyte)1) : ((sbyte)0);
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

	public unsafe bool Transition(Java.Lang.Object? p0, ITransitionViewAdapter? p1)
	{
		nint num = JNIEnv.ToLocalJniHandle(p0);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue((p1 == null) ? IntPtr.Zero : ((Java.Lang.Object)p1).Handle);
			return _members_com_bumptech_glide_request_transition_Transition.InstanceMethods.InvokeAbstractBooleanMethod("transition.(Ljava/lang/Object;Lcom/bumptech/glide/request/transition/Transition$ViewAdapter;)Z", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
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
