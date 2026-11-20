using System;
using System.Collections;
using System.Collections.Generic;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Kotlin.Reflect;

[Register("kotlin/reflect/KCallable", "", "Kotlin.Reflect.IKCallableInvoker")]
[JavaTypeParameters(new string[] { "R" })]
public interface IKCallable : IKAnnotatedElement, IJavaObject, IDisposable, IJavaPeerable
{
	bool IsAbstract
	{
		[Register("isAbstract", "()Z", "GetIsAbstractHandler:Kotlin.Reflect.IKCallableInvoker, Xamarin.Kotlin.StdLib")]
		get;
	}

	bool IsFinal
	{
		[Register("isFinal", "()Z", "GetIsFinalHandler:Kotlin.Reflect.IKCallableInvoker, Xamarin.Kotlin.StdLib")]
		get;
	}

	bool IsOpen
	{
		[Register("isOpen", "()Z", "GetIsOpenHandler:Kotlin.Reflect.IKCallableInvoker, Xamarin.Kotlin.StdLib")]
		get;
	}

	bool IsSuspend
	{
		[Register("isSuspend", "()Z", "GetIsSuspendHandler:Kotlin.Reflect.IKCallableInvoker, Xamarin.Kotlin.StdLib")]
		get;
	}

	string Name
	{
		[Register("getName", "()Ljava/lang/String;", "GetGetNameHandler:Kotlin.Reflect.IKCallableInvoker, Xamarin.Kotlin.StdLib")]
		get;
	}

	IList<IKParameter> Parameters
	{
		[Register("getParameters", "()Ljava/util/List;", "GetGetParametersHandler:Kotlin.Reflect.IKCallableInvoker, Xamarin.Kotlin.StdLib")]
		get;
	}

	IKType ReturnType
	{
		[Register("getReturnType", "()Lkotlin/reflect/KType;", "GetGetReturnTypeHandler:Kotlin.Reflect.IKCallableInvoker, Xamarin.Kotlin.StdLib")]
		get;
	}

	IList<IKTypeParameter> TypeParameters
	{
		[Register("getTypeParameters", "()Ljava/util/List;", "GetGetTypeParametersHandler:Kotlin.Reflect.IKCallableInvoker, Xamarin.Kotlin.StdLib")]
		get;
	}

	KVisibility? Visibility
	{
		[Register("getVisibility", "()Lkotlin/reflect/KVisibility;", "GetGetVisibilityHandler:Kotlin.Reflect.IKCallableInvoker, Xamarin.Kotlin.StdLib")]
		get;
	}

	[Register("call", "([Ljava/lang/Object;)Ljava/lang/Object;", "GetCall_arrayLjava_lang_Object_Handler:Kotlin.Reflect.IKCallableInvoker, Xamarin.Kotlin.StdLib")]
	Java.Lang.Object? Call(params Java.Lang.Object[] args);

	[Register("callBy", "(Ljava/util/Map;)Ljava/lang/Object;", "GetCallBy_Ljava_util_Map_Handler:Kotlin.Reflect.IKCallableInvoker, Xamarin.Kotlin.StdLib")]
	Java.Lang.Object? CallBy(IDictionary args);
}
