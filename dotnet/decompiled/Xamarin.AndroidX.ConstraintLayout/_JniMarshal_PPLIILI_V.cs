using System.Runtime.InteropServices;

[UnmanagedFunctionPointer(CallingConvention.Winapi)]
internal delegate void _JniMarshal_PPLIILI_V(nint jnienv, nint klass, nint p0, int p1, int p2, nint p3, int p4);
