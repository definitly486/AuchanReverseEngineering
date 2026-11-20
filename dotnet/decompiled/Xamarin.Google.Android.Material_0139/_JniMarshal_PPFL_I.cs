using System.Runtime.InteropServices;

[UnmanagedFunctionPointer(CallingConvention.Winapi)]
internal delegate int _JniMarshal_PPFL_I(nint jnienv, nint klass, float p0, nint p1);
