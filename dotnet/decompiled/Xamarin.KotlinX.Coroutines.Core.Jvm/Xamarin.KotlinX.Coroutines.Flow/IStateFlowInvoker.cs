using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;
using Kotlin.Coroutines;

namespace Xamarin.KotlinX.Coroutines.Flow;

[Register("kotlinx/coroutines/flow/StateFlow", DoNotGenerateAcw = true)]
internal class IStateFlowInvoker : Java.Lang.Object, IStateFlow, ISharedFlow, IFlow, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_kotlinx_coroutines_flow_Flow = new XAPeerMembers("kotlinx/coroutines/flow/Flow", typeof(IStateFlowInvoker));

	private static readonly JniPeerMembers _members_kotlinx_coroutines_flow_SharedFlow = new XAPeerMembers("kotlinx/coroutines/flow/SharedFlow", typeof(IStateFlowInvoker));

	private static readonly JniPeerMembers _members_kotlinx_coroutines_flow_StateFlow = new XAPeerMembers("kotlinx/coroutines/flow/StateFlow", typeof(IStateFlowInvoker));

	private static Delegate? cb_getValue_GetValue_Ljava_lang_Object_;

	private static Delegate? cb_getReplayCache_GetReplayCache_Ljava_util_List_;

	private static Delegate? cb_collect_Collect_Lkotlinx_coroutines_flow_FlowCollector_Lkotlin_coroutines_Continuation__Ljava_lang_Object_;

	private static nint java_class_ref => _members_kotlinx_coroutines_flow_StateFlow.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_kotlinx_coroutines_flow_StateFlow;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_kotlinx_coroutines_flow_StateFlow.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_kotlinx_coroutines_flow_StateFlow.ManagedPeerType;

	public unsafe Java.Lang.Object? Value => Java.Lang.Object.GetObject<Java.Lang.Object>(_members_kotlinx_coroutines_flow_StateFlow.InstanceMethods.InvokeAbstractObjectMethod("getValue.()Ljava/lang/Object;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public unsafe IList ReplayCache => JavaList.FromJniHandle(_members_kotlinx_coroutines_flow_SharedFlow.InstanceMethods.InvokeAbstractObjectMethod("getReplayCache.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public IStateFlowInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetGetValueHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetValue);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetValue(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IStateFlow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Value);
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

	private static Delegate GetGetReplayCacheHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetReplayCache);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetReplayCache(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JavaList.ToLocalJniHandle(Java.Lang.Object.GetObject<IStateFlow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ReplayCache);
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

	private static Delegate GetCollect_Lkotlinx_coroutines_flow_FlowCollector_Lkotlin_coroutines_Continuation_Handler()
	{
		return new global::_JniMarshal_PPLL_L(n_Collect_Lkotlinx_coroutines_flow_FlowCollector_Lkotlin_coroutines_Continuation_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Collect_Lkotlinx_coroutines_flow_FlowCollector_Lkotlin_coroutines_Continuation_(nint jnienv, nint native__this, nint native_collector, nint native_p1)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IStateFlow? stateFlow = Java.Lang.Object.GetObject<IStateFlow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IFlowCollector collector = Java.Lang.Object.GetObject<IFlowCollector>(native_collector, JniHandleOwnership.DoNotTransfer);
			IContinuation p = Java.Lang.Object.GetObject<IContinuation>(native_p1, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(stateFlow.Collect(collector, p));
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

	public unsafe Java.Lang.Object? Collect(IFlowCollector collector, IContinuation p1)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue((collector == null) ? IntPtr.Zero : ((Java.Lang.Object)collector).Handle);
			ptr[1] = new JniArgumentValue((p1 == null) ? IntPtr.Zero : ((Java.Lang.Object)p1).Handle);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members_kotlinx_coroutines_flow_SharedFlow.InstanceMethods.InvokeAbstractObjectMethod("collect.(Lkotlinx/coroutines/flow/FlowCollector;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(collector);
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
