using System.Runtime.InteropServices;

[UnmanagedFunctionPointer(CallingConvention.Winapi)]
internal delegate void _JniMarshal_PPIIIILLI_V(nint jnienv, nint klass, int p0, int p1, int p2, int p3, nint p4, nint p5, int p6);
