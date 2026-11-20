using System.Runtime.InteropServices;

[UnmanagedFunctionPointer(CallingConvention.Winapi)]
internal delegate void _JniMarshal_PPLLFI_V(nint jnienv, nint klass, nint p0, nint p1, float p2, int p3);
