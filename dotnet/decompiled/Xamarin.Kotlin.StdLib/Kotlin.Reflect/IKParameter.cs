using System;
using Android.Runtime;
using Java.Interop;

namespace Kotlin.Reflect;

[Register("kotlin/reflect/KParameter", "", "Kotlin.Reflect.IKParameterInvoker")]
public interface IKParameter : IKAnnotatedElement, IJavaObject, IDisposable, IJavaPeerable
{
	int Index
	{
		[Register("getIndex", "()I", "GetGetIndexHandler:Kotlin.Reflect.IKParameterInvoker, Xamarin.Kotlin.StdLib")]
		get;
	}

	bool IsOptional
	{
		[Register("isOptional", "()Z", "GetIsOptionalHandler:Kotlin.Reflect.IKParameterInvoker, Xamarin.Kotlin.StdLib")]
		get;
	}

	bool IsVararg
	{
		[Register("isVararg", "()Z", "GetIsVarargHandler:Kotlin.Reflect.IKParameterInvoker, Xamarin.Kotlin.StdLib")]
		get;
	}

	KParameterKind Kind
	{
		[Register("getKind", "()Lkotlin/reflect/KParameter$Kind;", "GetGetKindHandler:Kotlin.Reflect.IKParameterInvoker, Xamarin.Kotlin.StdLib")]
		get;
	}

	string? Name
	{
		[Register("getName", "()Ljava/lang/String;", "GetGetNameHandler:Kotlin.Reflect.IKParameterInvoker, Xamarin.Kotlin.StdLib")]
		get;
	}

	IKType Type
	{
		[Register("getType", "()Lkotlin/reflect/KType;", "GetGetTypeHandler:Kotlin.Reflect.IKParameterInvoker, Xamarin.Kotlin.StdLib")]
		get;
	}
}
