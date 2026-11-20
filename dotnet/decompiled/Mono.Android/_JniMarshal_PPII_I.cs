using System.Runtime.InteropServices;

[UnmanagedFunctionPointer(CallingConvention.Winapi)]
internal delegate int _JniMarshal_PPII_I(nint jnienv, nint klass, int p0, int p1);
