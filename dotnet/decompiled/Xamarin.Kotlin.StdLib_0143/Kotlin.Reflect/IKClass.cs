using System;
using System.Collections.Generic;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Kotlin.Reflect;

[Register("kotlin/reflect/KClass", "", "Kotlin.Reflect.IKClassInvoker")]
[JavaTypeParameters(new string[] { "T" })]
public interface IKClass : IKAnnotatedElement, IJavaObject, IDisposable, IJavaPeerable, IKClassifier, IKDeclarationContainer
{
	ICollection<IKFunction> Constructors
	{
		[Register("getConstructors", "()Ljava/util/Collection;", "GetGetConstructorsHandler:Kotlin.Reflect.IKClassInvoker, Xamarin.Kotlin.StdLib")]
		get;
	}

	bool IsAbstract
	{
		[Register("isAbstract", "()Z", "GetIsAbstractHandler:Kotlin.Reflect.IKClassInvoker, Xamarin.Kotlin.StdLib")]
		get;
	}

	bool IsCompanion
	{
		[Register("isCompanion", "()Z", "GetIsCompanionHandler:Kotlin.Reflect.IKClassInvoker, Xamarin.Kotlin.StdLib")]
		get;
	}

	bool IsData
	{
		[Register("isData", "()Z", "GetIsDataHandler:Kotlin.Reflect.IKClassInvoker, Xamarin.Kotlin.StdLib")]
		get;
	}

	bool IsFinal
	{
		[Register("isFinal", "()Z", "GetIsFinalHandler:Kotlin.Reflect.IKClassInvoker, Xamarin.Kotlin.StdLib")]
		get;
	}

	bool IsFun
	{
		[Register("isFun", "()Z", "GetIsFunHandler:Kotlin.Reflect.IKClassInvoker, Xamarin.Kotlin.StdLib")]
		get;
	}

	bool IsInner
	{
		[Register("isInner", "()Z", "GetIsInnerHandler:Kotlin.Reflect.IKClassInvoker, Xamarin.Kotlin.StdLib")]
		get;
	}

	bool IsOpen
	{
		[Register("isOpen", "()Z", "GetIsOpenHandler:Kotlin.Reflect.IKClassInvoker, Xamarin.Kotlin.StdLib")]
		get;
	}

	bool IsSealed
	{
		[Register("isSealed", "()Z", "GetIsSealedHandler:Kotlin.Reflect.IKClassInvoker, Xamarin.Kotlin.StdLib")]
		get;
	}

	bool IsValue
	{
		[Register("isValue", "()Z", "GetIsValueHandler:Kotlin.Reflect.IKClassInvoker, Xamarin.Kotlin.StdLib")]
		get;
	}

	new ICollection<IKCallable> Members
	{
		[Register("getMembers", "()Ljava/util/Collection;", "GetGetMembersHandler:Kotlin.Reflect.IKClassInvoker, Xamarin.Kotlin.StdLib")]
		get;
	}

	ICollection<IKClass> NestedClasses
	{
		[Register("getNestedClasses", "()Ljava/util/Collection;", "GetGetNestedClassesHandler:Kotlin.Reflect.IKClassInvoker, Xamarin.Kotlin.StdLib")]
		get;
	}

	Java.Lang.Object? ObjectInstance
	{
		[Register("getObjectInstance", "()Ljava/lang/Object;", "GetGetObjectInstanceHandler:Kotlin.Reflect.IKClassInvoker, Xamarin.Kotlin.StdLib")]
		get;
	}

	string? QualifiedName
	{
		[Register("getQualifiedName", "()Ljava/lang/String;", "GetGetQualifiedNameHandler:Kotlin.Reflect.IKClassInvoker, Xamarin.Kotlin.StdLib")]
		get;
	}

	IList<IKClass> SealedSubclasses
	{
		[Register("getSealedSubclasses", "()Ljava/util/List;", "GetGetSealedSubclassesHandler:Kotlin.Reflect.IKClassInvoker, Xamarin.Kotlin.StdLib")]
		get;
	}

	string? SimpleName
	{
		[Register("getSimpleName", "()Ljava/lang/String;", "GetGetSimpleNameHandler:Kotlin.Reflect.IKClassInvoker, Xamarin.Kotlin.StdLib")]
		get;
	}

	IList<IKType> Supertypes
	{
		[Register("getSupertypes", "()Ljava/util/List;", "GetGetSupertypesHandler:Kotlin.Reflect.IKClassInvoker, Xamarin.Kotlin.StdLib")]
		get;
	}

	IList<IKTypeParameter> TypeParameters
	{
		[Register("getTypeParameters", "()Ljava/util/List;", "GetGetTypeParametersHandler:Kotlin.Reflect.IKClassInvoker, Xamarin.Kotlin.StdLib")]
		get;
	}

	KVisibility? Visibility
	{
		[Register("getVisibility", "()Lkotlin/reflect/KVisibility;", "GetGetVisibilityHandler:Kotlin.Reflect.IKClassInvoker, Xamarin.Kotlin.StdLib")]
		get;
	}

	[Register("equals", "(Ljava/lang/Object;)Z", "GetEquals_Ljava_lang_Object_Handler:Kotlin.Reflect.IKClassInvoker, Xamarin.Kotlin.StdLib")]
	bool Equals(Java.Lang.Object? other);

	[Register("hashCode", "()I", "GetGetHashCodeHandler:Kotlin.Reflect.IKClassInvoker, Xamarin.Kotlin.StdLib")]
	new int GetHashCode();

	[Register("isInstance", "(Ljava/lang/Object;)Z", "GetIsInstance_Ljava_lang_Object_Handler:Kotlin.Reflect.IKClassInvoker, Xamarin.Kotlin.StdLib")]
	bool IsInstance(Java.Lang.Object? value);
}
