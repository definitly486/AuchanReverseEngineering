using System.Runtime.InteropServices;

[UnmanagedFunctionPointer(CallingConvention.Winapi)]
internal delegate void _JniMarshal_PPLLF_V(nint jnienv, nint klass, nint p0, nint p1, float p2);
