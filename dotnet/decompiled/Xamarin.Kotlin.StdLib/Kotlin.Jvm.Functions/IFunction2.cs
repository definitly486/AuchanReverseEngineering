using System;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Kotlin.Jvm.Functions;

[Register("kotlin/jvm/functions/Function2", "", "Kotlin.Jvm.Functions.IFunction2Invoker")]
[JavaTypeParameters(new string[] { "P1", "P2", "R" })]
public interface IFunction2 : IFunction, IJavaObject, IDisposable, IJavaPeerable
{
	[Register("invoke", "(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;", "GetInvoke_Ljava_lang_Object_Ljava_lang_Object_Handler:Kotlin.Jvm.Functions.IFunction2Invoker, Xamarin.Kotlin.StdLib")]
	Java.Lang.Object? Invoke(Java.Lang.Object? p0, Java.Lang.Object? p1);
}
