using System;
using System.Collections.Generic;
using Android.Runtime;
using Java.Interop;

namespace Kotlin.Reflect;

[Register("kotlin/reflect/KTypeParameter", "", "Kotlin.Reflect.IKTypeParameterInvoker")]
public interface IKTypeParameter : IKClassifier, IJavaObject, IDisposable, IJavaPeerable
{
	bool IsReified
	{
		[Register("isReified", "()Z", "GetIsReifiedHandler:Kotlin.Reflect.IKTypeParameterInvoker, Xamarin.Kotlin.StdLib")]
		get;
	}

	string Name
	{
		[Register("getName", "()Ljava/lang/String;", "GetGetNameHandler:Kotlin.Reflect.IKTypeParameterInvoker, Xamarin.Kotlin.StdLib")]
		get;
	}

	IList<IKType> UpperBounds
	{
		[Register("getUpperBounds", "()Ljava/util/List;", "GetGetUpperBoundsHandler:Kotlin.Reflect.IKTypeParameterInvoker, Xamarin.Kotlin.StdLib")]
		get;
	}

	KVariance Variance
	{
		[Register("getVariance", "()Lkotlin/reflect/KVariance;", "GetGetVarianceHandler:Kotlin.Reflect.IKTypeParameterInvoker, Xamarin.Kotlin.StdLib")]
		get;
	}
}
