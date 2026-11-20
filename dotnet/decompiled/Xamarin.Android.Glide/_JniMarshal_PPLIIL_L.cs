using System.Runtime.InteropServices;

[UnmanagedFunctionPointer(CallingConvention.Winapi)]
internal delegate nint _JniMarshal_PPLIIL_L(nint jnienv, nint klass, nint p0, int p1, int p2, nint p3);
