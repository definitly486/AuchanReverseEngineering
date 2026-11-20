using System;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Kotlin.Jvm.Functions;

[Register("kotlin/jvm/functions/Function1", "", "Kotlin.Jvm.Functions.IFunction1Invoker")]
[JavaTypeParameters(new string[] { "P1", "R" })]
public interface IFunction1 : IFunction, IJavaObject, IDisposable, IJavaPeerable
{
	[Register("invoke", "(Ljava/lang/Object;)Ljava/lang/Object;", "GetInvoke_Ljava_lang_Object_Handler:Kotlin.Jvm.Functions.IFunction1Invoker, Xamarin.Kotlin.StdLib")]
	Java.Lang.Object? Invoke(Java.Lang.Object? p0);
}
