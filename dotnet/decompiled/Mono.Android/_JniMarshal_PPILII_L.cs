using System.Runtime.InteropServices;

[UnmanagedFunctionPointer(CallingConvention.Winapi)]
internal delegate nint _JniMarshal_PPILII_L(nint jnienv, nint klass, int p0, nint p1, int p2, int p3);
