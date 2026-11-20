using System.Runtime.InteropServices;

[UnmanagedFunctionPointer(CallingConvention.Winapi)]
internal delegate bool _JniMarshal_PPLII_Z(nint jnienv, nint klass, nint p0, int p1, int p2);
