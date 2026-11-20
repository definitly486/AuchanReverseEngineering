using System.Runtime.InteropServices;

[UnmanagedFunctionPointer(CallingConvention.Winapi)]
internal delegate bool _JniMarshal_PPIL_Z(nint jnienv, nint klass, int p0, nint p1);
