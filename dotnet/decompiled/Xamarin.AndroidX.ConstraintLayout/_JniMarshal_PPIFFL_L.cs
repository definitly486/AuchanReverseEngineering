using System.Runtime.InteropServices;

[UnmanagedFunctionPointer(CallingConvention.Winapi)]
internal delegate nint _JniMarshal_PPIFFL_L(nint jnienv, nint klass, int p0, float p1, float p2, nint p3);
