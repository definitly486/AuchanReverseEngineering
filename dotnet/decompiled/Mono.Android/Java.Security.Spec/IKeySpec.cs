using System;
using Android.Runtime;
using Java.Interop;

namespace Java.Security.Spec;

[Register("java/security/spec/KeySpec", "", "Java.Security.Spec.IKeySpecInvoker")]
public interface IKeySpec : IJavaObject, IDisposable, IJavaPeerable
{
}
