using System.Runtime.InteropServices;

[UnmanagedFunctionPointer(CallingConvention.Winapi)]
internal delegate nint _JniMarshal_PPIILII_L(nint jnienv, nint klass, int p0, int p1, nint p2, int p3, int p4);
