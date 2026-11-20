using System;
using Android.Runtime;
using Java.Interop;
using Kotlin.Coroutines;

namespace Xamarin.KotlinX.Coroutines;

[Register("kotlinx/coroutines/CoroutineScope", "", "Xamarin.KotlinX.Coroutines.ICoroutineScopeInvoker")]
public interface ICoroutineScope : IJavaObject, IDisposable, IJavaPeerable
{
	ICoroutineContext CoroutineContext
	{
		[Register("getCoroutineContext", "()Lkotlin/coroutines/CoroutineContext;", "GetGetCoroutineContextHandler:Xamarin.KotlinX.Coroutines.ICoroutineScopeInvoker, Xamarin.KotlinX.Coroutines.Core.Jvm")]
		get;
	}
}
