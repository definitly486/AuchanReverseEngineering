using System.Runtime.InteropServices;

[UnmanagedFunctionPointer(CallingConvention.Winapi)]
internal delegate void _JniMarshal_PPFFL_V(nint jnienv, nint klass, float p0, float p1, nint p2);
