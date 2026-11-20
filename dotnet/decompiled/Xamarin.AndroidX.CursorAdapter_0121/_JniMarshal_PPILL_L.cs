using System.Runtime.InteropServices;

[UnmanagedFunctionPointer(CallingConvention.Winapi)]
internal delegate nint _JniMarshal_PPILL_L(nint jnienv, nint klass, int p0, nint p1, nint p2);
