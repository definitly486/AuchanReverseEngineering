using System.Runtime.InteropServices;

[UnmanagedFunctionPointer(CallingConvention.Winapi)]
internal delegate nint _JniMarshal_PPIIII_L(nint jnienv, nint klass, int p0, int p1, int p2, int p3);
