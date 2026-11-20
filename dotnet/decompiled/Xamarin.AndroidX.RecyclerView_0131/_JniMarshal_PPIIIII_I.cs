using System.Runtime.InteropServices;

[UnmanagedFunctionPointer(CallingConvention.Winapi)]
internal delegate int _JniMarshal_PPIIIII_I(nint jnienv, nint klass, int p0, int p1, int p2, int p3, int p4);
