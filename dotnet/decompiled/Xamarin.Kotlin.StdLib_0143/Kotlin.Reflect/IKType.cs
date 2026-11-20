using System;
using System.Collections.Generic;
using Android.Runtime;
using Java.Interop;

namespace Kotlin.Reflect;

[Register("kotlin/reflect/KType", "", "Kotlin.Reflect.IKTypeInvoker")]
public interface IKType : IKAnnotatedElement, IJavaObject, IDisposable, IJavaPeerable
{
	IList<KTypeProjection> Arguments
	{
		[Register("getArguments", "()Ljava/util/List;", "GetGetArgumentsHandler:Kotlin.Reflect.IKTypeInvoker, Xamarin.Kotlin.StdLib")]
		get;
	}

	IKClassifier? Classifier
	{
		[Register("getClassifier", "()Lkotlin/reflect/KClassifier;", "GetGetClassifierHandler:Kotlin.Reflect.IKTypeInvoker, Xamarin.Kotlin.StdLib")]
		get;
	}

	bool IsMarkedNullable
	{
		[Register("isMarkedNullable", "()Z", "GetIsMarkedNullableHandler:Kotlin.Reflect.IKTypeInvoker, Xamarin.Kotlin.StdLib")]
		get;
	}
}
