using System.Runtime.InteropServices;

[UnmanagedFunctionPointer(CallingConvention.Winapi)]
internal delegate int _JniMarshal_PPIFL_I(nint jnienv, nint klass, int p0, float p1, nint p2);
