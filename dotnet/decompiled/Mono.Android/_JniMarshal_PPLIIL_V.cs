using System.Runtime.InteropServices;

[UnmanagedFunctionPointer(CallingConvention.Winapi)]
internal delegate void _JniMarshal_PPLIIL_V(nint jnienv, nint klass, nint p0, int p1, int p2, nint p3);
