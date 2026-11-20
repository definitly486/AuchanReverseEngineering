using System.Runtime.InteropServices;

[UnmanagedFunctionPointer(CallingConvention.Winapi)]
internal delegate nint _JniMarshal_PPIBI_L(nint jnienv, nint klass, int p0, sbyte p1, int p2);
