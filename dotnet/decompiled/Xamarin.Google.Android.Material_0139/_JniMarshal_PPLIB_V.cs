using System.Runtime.InteropServices;

[UnmanagedFunctionPointer(CallingConvention.Winapi)]
internal delegate void _JniMarshal_PPLIB_V(nint jnienv, nint klass, nint p0, int p1, sbyte p2);
