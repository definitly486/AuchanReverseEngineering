using System.Runtime.InteropServices;

[UnmanagedFunctionPointer(CallingConvention.Winapi)]
internal delegate void _JniMarshal_PPLLLLFI_V(nint jnienv, nint klass, nint p0, nint p1, nint p2, nint p3, float p4, int p5);
