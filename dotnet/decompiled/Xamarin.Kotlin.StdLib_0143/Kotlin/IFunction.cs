using System;
using Android.Runtime;
using Java.Interop;

namespace Kotlin;

[Register("kotlin/Function", "", "Kotlin.IFunctionInvoker")]
[JavaTypeParameters(new string[] { "R" })]
public interface IFunction : IJavaObject, IDisposable, IJavaPeerable
{
}
