using System;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Kotlin.Coroutines;

[Register("kotlin/coroutines/Continuation", "", "Kotlin.Coroutines.IContinuationInvoker")]
[JavaTypeParameters(new string[] { "T" })]
public interface IContinuation : IJavaObject, IDisposable, IJavaPeerable
{
	ICoroutineContext Context
	{
		[Register("getContext", "()Lkotlin/coroutines/CoroutineContext;", "GetGetContextHandler:Kotlin.Coroutines.IContinuationInvoker, Xamarin.Kotlin.StdLib")]
		get;
	}

	[Register("resumeWith", "(Ljava/lang/Object;)V", "GetResumeWith_Ljava_lang_Object_Handler:Kotlin.Coroutines.IContinuationInvoker, Xamarin.Kotlin.StdLib")]
	void ResumeWith(Java.Lang.Object result);
}
