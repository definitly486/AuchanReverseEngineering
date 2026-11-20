using System.Runtime.InteropServices;

[UnmanagedFunctionPointer(CallingConvention.Winapi)]
internal delegate void _JniMarshal_PPLLLIIII_V(nint jnienv, nint klass, nint p0, nint p1, nint p2, int p3, int p4, int p5, int p6);
