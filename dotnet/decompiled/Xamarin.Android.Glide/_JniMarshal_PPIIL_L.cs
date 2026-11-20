using System.Runtime.InteropServices;

[UnmanagedFunctionPointer(CallingConvention.Winapi)]
internal delegate nint _JniMarshal_PPIIL_L(nint jnienv, nint klass, int p0, int p1, nint p2);
