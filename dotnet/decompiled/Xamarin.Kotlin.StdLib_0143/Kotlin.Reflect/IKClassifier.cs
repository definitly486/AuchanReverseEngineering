using System;
using Android.Runtime;
using Java.Interop;

namespace Kotlin.Reflect;

[Register("kotlin/reflect/KClassifier", "", "Kotlin.Reflect.IKClassifierInvoker")]
public interface IKClassifier : IJavaObject, IDisposable, IJavaPeerable
{
}
