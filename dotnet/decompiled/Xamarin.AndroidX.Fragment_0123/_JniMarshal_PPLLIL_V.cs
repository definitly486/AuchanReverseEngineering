using System.Runtime.InteropServices;

[UnmanagedFunctionPointer(CallingConvention.Winapi)]
internal delegate void _JniMarshal_PPLLIL_V(nint jnienv, nint klass, nint p0, nint p1, int p2, nint p3);
