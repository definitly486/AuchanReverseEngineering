using System.Runtime.InteropServices;

[UnmanagedFunctionPointer(CallingConvention.Winapi)]
internal delegate nint _JniMarshal_PPLIIII_L(nint jnienv, nint klass, nint p0, int p1, int p2, int p3, int p4);
