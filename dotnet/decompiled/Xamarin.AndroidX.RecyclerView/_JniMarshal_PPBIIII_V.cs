using System.Runtime.InteropServices;

[UnmanagedFunctionPointer(CallingConvention.Winapi)]
internal delegate void _JniMarshal_PPBIIII_V(nint jnienv, nint klass, sbyte p0, int p1, int p2, int p3, int p4);
