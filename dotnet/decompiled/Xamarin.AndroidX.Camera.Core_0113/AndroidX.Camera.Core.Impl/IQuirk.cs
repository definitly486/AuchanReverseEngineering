using System;
using Android.Runtime;
using Java.Interop;

namespace AndroidX.Camera.Core.Impl;

[Register("androidx/camera/core/impl/Quirk", "", "AndroidX.Camera.Core.Impl.IQuirkInvoker")]
public interface IQuirk : IJavaObject, IDisposable, IJavaPeerable
{
}
