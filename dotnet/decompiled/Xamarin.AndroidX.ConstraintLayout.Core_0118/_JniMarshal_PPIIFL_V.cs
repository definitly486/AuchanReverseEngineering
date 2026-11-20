using System.Runtime.InteropServices;

[UnmanagedFunctionPointer(CallingConvention.Winapi)]
internal delegate void _JniMarshal_PPIIFL_V(nint jnienv, nint klass, int p0, int p1, float p2, nint p3);
