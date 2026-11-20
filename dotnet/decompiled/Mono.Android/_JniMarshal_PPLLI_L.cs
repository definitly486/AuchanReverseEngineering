using System.Runtime.InteropServices;

[UnmanagedFunctionPointer(CallingConvention.Winapi)]
internal delegate nint _JniMarshal_PPLLI_L(nint jnienv, nint klass, nint p0, nint p1, int p2);
