using System;
using Android.Runtime;
using Java.Interop;
using Java.Lang;
using Kotlin.Coroutines;

namespace Xamarin.KotlinX.Coroutines.Flow;

[Register("kotlinx/coroutines/flow/FlowCollector", "", "Xamarin.KotlinX.Coroutines.Flow.IFlowCollectorInvoker")]
[JavaTypeParameters(new string[] { "T" })]
public interface IFlowCollector : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("emit", "(Ljava/lang/Object;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;", "GetEmit_Ljava_lang_Object_Lkotlin_coroutines_Continuation_Handler:Xamarin.KotlinX.Coroutines.Flow.IFlowCollectorInvoker, Xamarin.KotlinX.Coroutines.Core.Jvm")]
	Java.Lang.Object? Emit(Java.Lang.Object? value, IContinuation p1);
}
