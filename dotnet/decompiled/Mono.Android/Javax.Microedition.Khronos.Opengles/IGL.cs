using System;
using Android.Runtime;
using Java.Interop;

namespace Javax.Microedition.Khronos.Opengles;

[Register("javax/microedition/khronos/opengles/GL", "", "Javax.Microedition.Khronos.Opengles.IGLInvoker")]
public interface IGL : IJavaObject, IDisposable, IJavaPeerable
{
}
