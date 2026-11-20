using System;
using Android.Runtime;
using Java.Interop;

namespace Java.Lang.Annotation;

[Register("java/lang/annotation/Annotation", "", "Java.Lang.Annotation.IAnnotationInvoker")]
public interface IAnnotation : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("annotationType", "()Ljava/lang/Class;", "GetAnnotationTypeHandler:Java.Lang.Annotation.IAnnotationInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	Class? AnnotationType();

	[Register("equals", "(Ljava/lang/Object;)Z", "GetEquals_Ljava_lang_Object_Handler:Java.Lang.Annotation.IAnnotationInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	bool Equals(Object? obj);

	[Register("hashCode", "()I", "GetGetHashCodeHandler:Java.Lang.Annotation.IAnnotationInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	new int GetHashCode();

	[Register("toString", "()Ljava/lang/String;", "GetToStringHandler:Java.Lang.Annotation.IAnnotationInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	new string? ToString();
}
