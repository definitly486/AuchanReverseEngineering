using System;
using Android.Runtime;
using Java.Interop;
using Java.Lang;
using Kotlin.Coroutines;

namespace Xamarin.KotlinX.Coroutines.Flow;

[Register("kotlinx/coroutines/flow/Flow", "", "Xamarin.KotlinX.Coroutines.Flow.IFlowInvoker")]
[JavaTypeParameters(new string[] { "T" })]
public interface IFlow : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("collect", "(Lkotlinx/coroutines/flow/FlowCollector;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;", "GetCollect_Lkotlinx_coroutines_flow_FlowCollector_Lkotlin_coroutines_Continuation_Handler:Xamarin.KotlinX.Coroutines.Flow.IFlowInvoker, Xamarin.KotlinX.Coroutines.Core.Jvm")]
	Java.Lang.Object? Collect(IFlowCollector collector, IContinuation p1);
}
