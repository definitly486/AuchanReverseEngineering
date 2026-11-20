using System.Runtime.InteropServices;

[UnmanagedFunctionPointer(CallingConvention.Winapi)]
internal delegate nint _JniMarshal_PPJL_L(nint jnienv, nint klass, long p0, nint p1);
