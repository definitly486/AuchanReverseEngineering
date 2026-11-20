using System;
using System.Collections;
using Android.Runtime;
using Java.Interop;
using Java.Lang;
using Kotlin.Coroutines;

namespace Xamarin.KotlinX.Coroutines.Flow;

[Register("kotlinx/coroutines/flow/SharedFlow", "", "Xamarin.KotlinX.Coroutines.Flow.ISharedFlowInvoker")]
[JavaTypeParameters(new string[] { "T" })]
public interface ISharedFlow : IFlow, IJavaObject, IDisposable, IJavaPeerable
{
	IList ReplayCache
	{
		[Register("getReplayCache", "()Ljava/util/List;", "GetGetReplayCacheHandler:Xamarin.KotlinX.Coroutines.Flow.ISharedFlowInvoker, Xamarin.KotlinX.Coroutines.Core.Jvm")]
		get;
	}

	[Register("collect", "(Lkotlinx/coroutines/flow/FlowCollector;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;", "GetCollect_Lkotlinx_coroutines_flow_FlowCollector_Lkotlin_coroutines_Continuation_Handler:Xamarin.KotlinX.Coroutines.Flow.ISharedFlowInvoker, Xamarin.KotlinX.Coroutines.Core.Jvm")]
	new Java.Lang.Object? Collect(IFlowCollector collector, IContinuation p1);
}
