using System.Runtime.InteropServices;

[UnmanagedFunctionPointer(CallingConvention.Winapi)]
internal delegate void _JniMarshal_PPDLL_V(nint jnienv, nint klass, double p0, nint p1, nint p2);
