using System.Runtime.InteropServices;

[UnmanagedFunctionPointer(CallingConvention.Winapi)]
internal delegate void _JniMarshal_PPDL_V(nint jnienv, nint klass, double p0, nint p1);
