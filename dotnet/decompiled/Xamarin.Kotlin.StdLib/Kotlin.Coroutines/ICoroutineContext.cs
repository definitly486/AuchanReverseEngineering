using System;
using Android.Runtime;
using Java.Interop;
using Java.Lang;
using Kotlin.Jvm.Functions;

namespace Kotlin.Coroutines;

[Register("kotlin/coroutines/CoroutineContext", "", "Kotlin.Coroutines.ICoroutineContextInvoker")]
public interface ICoroutineContext : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("fold", "(Ljava/lang/Object;Lkotlin/jvm/functions/Function2;)Ljava/lang/Object;", "GetFold_Ljava_lang_Object_Lkotlin_jvm_functions_Function2_Handler:Kotlin.Coroutines.ICoroutineContextInvoker, Xamarin.Kotlin.StdLib")]
	[JavaTypeParameters(new string[] { "R" })]
	Java.Lang.Object? Fold(Java.Lang.Object? initial, IFunction2 operation);

	[Register("get", "(Lkotlin/coroutines/CoroutineContext$Key;)Lkotlin/coroutines/CoroutineContext$Element;", "GetGet_Lkotlin_coroutines_CoroutineContext_Key_Handler:Kotlin.Coroutines.ICoroutineContextInvoker, Xamarin.Kotlin.StdLib")]
	[JavaTypeParameters(new string[] { "E extends kotlin.coroutines.CoroutineContext.Element" })]
	Java.Lang.Object? Get(ICoroutineContextKey key);

	[Register("minusKey", "(Lkotlin/coroutines/CoroutineContext$Key;)Lkotlin/coroutines/CoroutineContext;", "GetMinusKey_Lkotlin_coroutines_CoroutineContext_Key_Handler:Kotlin.Coroutines.ICoroutineContextInvoker, Xamarin.Kotlin.StdLib")]
	ICoroutineContext MinusKey(ICoroutineContextKey key);

	[Register("plus", "(Lkotlin/coroutines/CoroutineContext;)Lkotlin/coroutines/CoroutineContext;", "GetPlus_Lkotlin_coroutines_CoroutineContext_Handler:Kotlin.Coroutines.ICoroutineContextInvoker, Xamarin.Kotlin.StdLib")]
	ICoroutineContext Plus(ICoroutineContext context);
}
