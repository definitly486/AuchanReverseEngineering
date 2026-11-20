using System.Runtime.InteropServices;

[UnmanagedFunctionPointer(CallingConvention.Winapi)]
internal delegate nint _JniMarshal_PPIII_L(nint jnienv, nint klass, int p0, int p1, int p2);
