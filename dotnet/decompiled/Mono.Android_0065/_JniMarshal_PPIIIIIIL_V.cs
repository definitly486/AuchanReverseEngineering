using System.Runtime.InteropServices;

[UnmanagedFunctionPointer(CallingConvention.Winapi)]
internal delegate void _JniMarshal_PPIIIIIIL_V(nint jnienv, nint klass, int p0, int p1, int p2, int p3, int p4, int p5, nint p6);
