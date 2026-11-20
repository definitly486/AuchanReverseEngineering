using System.Runtime.InteropServices;

[UnmanagedFunctionPointer(CallingConvention.Winapi)]
internal delegate void _JniMarshal_PPLJFLL_V(nint jnienv, nint klass, nint p0, long p1, float p2, nint p3, nint p4);
