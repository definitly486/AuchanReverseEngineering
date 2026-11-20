using System;
using Android.Runtime;
using Java.Interop;

namespace Kotlin.Reflect;

[Register("kotlin/reflect/KFunction", "", "Kotlin.Reflect.IKFunctionInvoker")]
[JavaTypeParameters(new string[] { "R" })]
public interface IKFunction : IFunction, IJavaObject, IDisposable, IJavaPeerable, IKCallable, IKAnnotatedElement
{
	bool IsExternal
	{
		[Register("isExternal", "()Z", "GetIsExternalHandler:Kotlin.Reflect.IKFunctionInvoker, Xamarin.Kotlin.StdLib")]
		get;
	}

	bool IsInfix
	{
		[Register("isInfix", "()Z", "GetIsInfixHandler:Kotlin.Reflect.IKFunctionInvoker, Xamarin.Kotlin.StdLib")]
		get;
	}

	bool IsInline
	{
		[Register("isInline", "()Z", "GetIsInlineHandler:Kotlin.Reflect.IKFunctionInvoker, Xamarin.Kotlin.StdLib")]
		get;
	}

	bool IsOperator
	{
		[Register("isOperator", "()Z", "GetIsOperatorHandler:Kotlin.Reflect.IKFunctionInvoker, Xamarin.Kotlin.StdLib")]
		get;
	}

	new bool IsSuspend
	{
		[Register("isSuspend", "()Z", "GetIsSuspendHandler:Kotlin.Reflect.IKFunctionInvoker, Xamarin.Kotlin.StdLib")]
		get;
	}
}
