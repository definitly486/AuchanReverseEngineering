using System.Runtime.InteropServices;

[UnmanagedFunctionPointer(CallingConvention.Winapi)]
internal delegate nint _JniMarshal_PPIJ_L(nint jnienv, nint klass, int p0, long p1);
