using System;
using Android.Runtime;
using Java.Interop;

namespace Java.Lang.Annotation;

[Register("java/lang/annotation/Annotation", "", "Java.Lang.Annotation.IAnnotationInvoker")]
public interface IAnnotation : IJavaObject, IDisposable, IJavaPeerable
{
	Class? AnnotationType();

	bool Equals(Object? obj);

	new int GetHashCode();

	new string? ToString();
}
