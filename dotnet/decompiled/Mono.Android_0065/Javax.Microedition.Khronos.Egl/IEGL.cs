using System;
using Android.Runtime;
using Java.Interop;

namespace Javax.Microedition.Khronos.Egl;

[Register("javax/microedition/khronos/egl/EGL", "", "Javax.Microedition.Khronos.Egl.IEGLInvoker")]
public interface IEGL : IJavaObject, IDisposable, IJavaPeerable
{
}
