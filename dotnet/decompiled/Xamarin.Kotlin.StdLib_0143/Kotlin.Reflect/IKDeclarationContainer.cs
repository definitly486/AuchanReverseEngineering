using System;
using System.Collections.Generic;
using Android.Runtime;
using Java.Interop;

namespace Kotlin.Reflect;

[Register("kotlin/reflect/KDeclarationContainer", "", "Kotlin.Reflect.IKDeclarationContainerInvoker")]
public interface IKDeclarationContainer : IJavaObject, IDisposable, IJavaPeerable
{
	ICollection<IKCallable> Members
	{
		[Register("getMembers", "()Ljava/util/Collection;", "GetGetMembersHandler:Kotlin.Reflect.IKDeclarationContainerInvoker, Xamarin.Kotlin.StdLib")]
		get;
	}
}
