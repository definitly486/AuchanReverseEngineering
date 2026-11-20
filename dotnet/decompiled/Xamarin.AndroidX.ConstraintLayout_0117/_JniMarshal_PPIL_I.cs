using System.Runtime.InteropServices;

[UnmanagedFunctionPointer(CallingConvention.Winapi)]
internal delegate int _JniMarshal_PPIL_I(nint jnienv, nint klass, int p0, nint p1);
