using System.Runtime.InteropServices;

[UnmanagedFunctionPointer(CallingConvention.Winapi)]
internal delegate void _JniMarshal_PPLLLLI_V(nint jnienv, nint klass, nint p0, nint p1, nint p2, nint p3, int p4);
