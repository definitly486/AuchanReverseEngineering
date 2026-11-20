using System.Runtime.InteropServices;

[UnmanagedFunctionPointer(CallingConvention.Winapi)]
internal delegate nint _JniMarshal_PPLIL_L(nint jnienv, nint klass, nint p0, int p1, nint p2);
