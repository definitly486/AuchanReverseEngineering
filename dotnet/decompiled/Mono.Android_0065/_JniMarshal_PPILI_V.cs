using System.Runtime.InteropServices;

[UnmanagedFunctionPointer(CallingConvention.Winapi)]
internal delegate void _JniMarshal_PPILI_V(nint jnienv, nint klass, int p0, nint p1, int p2);
