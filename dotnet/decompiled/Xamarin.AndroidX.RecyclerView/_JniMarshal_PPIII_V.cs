using System.Runtime.InteropServices;

[UnmanagedFunctionPointer(CallingConvention.Winapi)]
internal delegate void _JniMarshal_PPIII_V(nint jnienv, nint klass, int p0, int p1, int p2);
