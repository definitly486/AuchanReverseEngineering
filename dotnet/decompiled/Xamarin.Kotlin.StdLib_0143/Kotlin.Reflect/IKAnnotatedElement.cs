using System;
using System.Collections.Generic;
using Android.Runtime;
using Java.Interop;
using Java.Lang.Annotation;

namespace Kotlin.Reflect;

[Register("kotlin/reflect/KAnnotatedElement", "", "Kotlin.Reflect.IKAnnotatedElementInvoker")]
public interface IKAnnotatedElement : IJavaObject, IDisposable, IJavaPeerable
{
	IList<IAnnotation> Annotations
	{
		[Register("getAnnotations", "()Ljava/util/List;", "GetGetAnnotationsHandler:Kotlin.Reflect.IKAnnotatedElementInvoker, Xamarin.Kotlin.StdLib")]
		get;
	}
}
