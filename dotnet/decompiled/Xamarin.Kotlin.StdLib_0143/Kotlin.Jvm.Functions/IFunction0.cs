using System;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Kotlin.Jvm.Functions;

[Register("kotlin/jvm/functions/Function0", "", "Kotlin.Jvm.Functions.IFunction0Invoker")]
[JavaTypeParameters(new string[] { "R" })]
public interface IFunction0 : IFunction, IJavaObject, IDisposable, IJavaPeerable
{
	[Register("invoke", "()Ljava/lang/Object;", "GetInvokeHandler:Kotlin.Jvm.Functions.IFunction0Invoker, Xamarin.Kotlin.StdLib")]
	Java.Lang.Object? Invoke();
}
