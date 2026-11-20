using System.Runtime.InteropServices;

[UnmanagedFunctionPointer(CallingConvention.Winapi)]
internal delegate void _JniMarshal_PPBLI_V(nint jnienv, nint klass, sbyte p0, nint p1, int p2);
