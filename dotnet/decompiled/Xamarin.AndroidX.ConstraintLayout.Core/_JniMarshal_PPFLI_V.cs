using System.Runtime.InteropServices;

[UnmanagedFunctionPointer(CallingConvention.Winapi)]
internal delegate void _JniMarshal_PPFLI_V(nint jnienv, nint klass, float p0, nint p1, int p2);
