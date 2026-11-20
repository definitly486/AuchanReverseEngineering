using System.Runtime.InteropServices;

[UnmanagedFunctionPointer(CallingConvention.Winapi)]
internal delegate bool _JniMarshal_PPLIL_Z(nint jnienv, nint klass, nint p0, int p1, nint p2);
