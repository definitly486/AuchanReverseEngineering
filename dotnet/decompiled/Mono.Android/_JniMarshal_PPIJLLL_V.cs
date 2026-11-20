using System.Runtime.InteropServices;

[UnmanagedFunctionPointer(CallingConvention.Winapi)]
internal delegate void _JniMarshal_PPIJLLL_V(nint jnienv, nint klass, int p0, long p1, nint p2, nint p3, nint p4);
