using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;
using Kotlin.Coroutines;

namespace Xamarin.KotlinX.Coroutines.Flow;

[Register("kotlinx/coroutines/flow/FlowCollector", DoNotGenerateAcw = true)]
internal class IFlowCollectorInvoker : Java.Lang.Object, IFlowCollector, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_kotlinx_coroutines_flow_FlowCollector = new XAPeerMembers("kotlinx/coroutines/flow/FlowCollector", typeof(IFlowCollectorInvoker));

	private static Delegate? cb_emit_Emit_Ljava_lang_Object_Lkotlin_coroutines_Continuation__Ljava_lang_Object_;

	private static nint java_class_ref => _members_kotlinx_coroutines_flow_FlowCollector.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_kotlinx_coroutines_flow_FlowCollector;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_kotlinx_coroutines_flow_FlowCollector.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_kotlinx_coroutines_flow_FlowCollector.ManagedPeerType;

	public IFlowCollectorInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetEmit_Ljava_lang_Object_Lkotlin_coroutines_Continuation_Handler()
	{
		return new global::_JniMarshal_PPLL_L(n_Emit_Ljava_lang_Object_Lkotlin_coroutines_Continuation_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Emit_Ljava_lang_Object_Lkotlin_coroutines_Continuation_(nint jnienv, nint native__this, nint native_value, nint native_p1)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IFlowCollector? flowCollector = Java.Lang.Object.GetObject<IFlowCollector>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object value = Java.Lang.Object.GetObject<Java.Lang.Object>(native_value, JniHandleOwnership.DoNotTransfer);
			IContinuation p = Java.Lang.Object.GetObject<IContinuation>(native_p1, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(flowCollector.Emit(value, p));
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

	public unsafe Java.Lang.Object? Emit(Java.Lang.Object? value, IContinuation p1)
	{
		nint num = JNIEnv.ToLocalJniHandle(value);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue((p1 == null) ? IntPtr.Zero : ((Java.Lang.Object)p1).Handle);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members_kotlinx_coroutines_flow_FlowCollector.InstanceMethods.InvokeAbstractObjectMethod("emit.(Ljava/lang/Object;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(value);
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
