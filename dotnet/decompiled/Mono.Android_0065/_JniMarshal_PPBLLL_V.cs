using System.Runtime.InteropServices;

[UnmanagedFunctionPointer(CallingConvention.Winapi)]
internal delegate void _JniMarshal_PPBLLL_V(nint jnienv, nint klass, sbyte p0, nint p1, nint p2, nint p3);
